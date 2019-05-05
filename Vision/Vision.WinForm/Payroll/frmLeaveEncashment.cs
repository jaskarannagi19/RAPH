using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL;
using Vision.DAL.Employee;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmLeaveEncashment : Template.frmCRUDTemplate
    {
        #region Fields
        LeaveEncashmentDAL DALObject;
        EmployeeDAL EmployeeDALObj;
        LeaveTypeDAL LeaveTypeDALObj;
        HolidayDAL HolidayDALObj;
        DAL.Settings.LocationDAL LocationDALObj;
        LeaveEncashmentNoPrefixDAL LeaveEncashmentNoPrefixDALObj;

        List<EmployeeLookupListModel> dsEmployee;
        List<LeaveTypeLookupListModel> dsLeaveType;
        List<LeaveEncashmentNoPrefixLookupListModel> dsLeaveEncashmentNoPrefix;
        #endregion

        #region Properties
        decimal LeaveBalance_;
        public decimal LeaveBalance
        {
            get
            {
                return LeaveBalance_;
            }

            set
            {
                LeaveBalance_ = value;
                txtLeaveBalance.EditValue = LeaveBalance_;
                RemainingLeaveBalance = LeaveBalance - LeaveDays;
            }
        }

        public decimal LeaveDays
        {
            get
            {
                return Model.CommonFunctions.ParseDecimal(txtNofDays.Text);
            }
        }

        decimal RemainingLeaveBalance_ = 0;
        public decimal RemainingLeaveBalance
        {
            get
            {
                return RemainingLeaveBalance_;
            }
            set
            {
                RemainingLeaveBalance_ = value;
                txtRemainingLeaveBalance.EditValue = RemainingLeaveBalance_;
            }
        }

        #endregion

        #region Constructor
        public frmLeaveEncashment()
        {
            InitializeComponent();
            DALObject = new LeaveEncashmentDAL();
            EmployeeDALObj = new EmployeeDAL();
            LeaveTypeDALObj = new LeaveTypeDAL();
            HolidayDALObj = new HolidayDAL();
            LocationDALObj = new DAL.Settings.LocationDAL();
            LeaveEncashmentNoPrefixDALObj = new LeaveEncashmentNoPrefixDAL();

            FirstControl = lookupLeaveEncashmentNoPrefix;
        }
        #endregion

        #region Template
        public override void InitializeDefaultValues()
        {
            deLeaveEncashmentDate.EditValue = DateTime.Now.Date;

            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                //txtLeaveEncashmentNo.EditValue = DALObject.GenerateLeaveEncashmentNo();
                if (dsLeaveEncashmentNoPrefix.Count > 0)
                {
                    lookupLeaveEncashmentNoPrefix.EditValue = dsLeaveEncashmentNoPrefix.First().LeaveEncashmentNoPrefixID;
                }
            }

            LeaveEncashmentDayDetailBindingSource.Clear();
            lookupEmployee.EditValue = null;
            lookupLeaveType.EditValue = null;
        }

        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsLeaveType = LeaveTypeDALObj.GetLookupList();
            dsLeaveEncashmentNoPrefix = LeaveEncashmentNoPrefixDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupLeaveEncashmentNoPrefix.Properties.DisplayMember = "LeaveEncashmentNoPrefixName";
            lookupLeaveEncashmentNoPrefix.Properties.ValueMember = "LeaveEncashmentNoPrefixID";
            lookupLeaveEncashmentNoPrefix.Properties.DataSource = dsLeaveEncashmentNoPrefix;

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            lookupLeaveType.Properties.ValueMember = "LeaveTypeID";
            lookupLeaveType.Properties.DisplayMember = "LeaveTypeName";
            lookupLeaveType.Properties.DataSource = dsLeaveType.Where(r=> r.Encashable);

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLeaveEncashment SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblLeaveEncashment();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LeaveEncashmentEditListModel)EditRecordDataSource).LeaveEncashmentID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LeaveEncashmentDate = deLeaveEncashmentDate.DateTime.Date;
            SaveModel.LeaveEncashmentNoPrefixID = (int)lookupLeaveEncashmentNoPrefix.EditValue;
            SaveModel.LeaveEncashmentNo = Model.CommonFunctions.ParseInt(txtLeaveEncashmentNo.Text);
            SaveModel.EmployeeID = (int)lookupEmployee.EditValue;
            SaveModel.LeaveTypeID = (int)lookupLeaveType.EditValue;
            SaveModel.NofLeaves = Model.CommonFunctions.ParseDecimal(txtNofDays.Text);
            SaveModel.Remarks = txtRemarks.Text;

            // if new record or document has been changed then update it.
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || SaveModel.ApplicationDocumentFileName != txtDocument.Text)
            {
                SaveModel.ApplicationDocumentFileName = null;
                if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
                {
                    string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LeaveEncashmentDocument));
                    string DocumentNewFileName = Path.Combine(DocumentNewPath,
                        "LED" + CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                        SaveModel.LeaveEncashmentNo.ToString("0000000000") + Path.GetExtension(txtDocument.Text));
                    try
                    {
                        if (!Directory.Exists(DocumentNewPath))
                        {
                            Directory.CreateDirectory(DocumentNewPath);
                        }
                        // Allow to overwrite the document only if in edit mode 
                        File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.LeaveEncashmentID != 0));
                    }
                    catch (System.IO.IOException ex)
                    {
                        SavingResult res = new SavingResult();
                        DAL.CommonFunctions.GetFinalError(res, ex);
                        Paras.SavingResult = res;
                        return;
                    }
                    SaveModel.ApplicationDocumentFileName = DocumentNewFileName;
                }
            }

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);

            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            LeaveEncashmentEditListModel EditingRecord = (LeaveEncashmentEditListModel)RecordToFill;
            tblLeaveEncashment SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.LeaveEncashmentID);

            if(SaveModel == null)
            {
                return;
            }

            deLeaveEncashmentDate.DateTime = SaveModel.LeaveEncashmentDate;
            lookupLeaveEncashmentNoPrefix.EditValue = SaveModel.LeaveEncashmentNoPrefixID;
            txtLeaveEncashmentNo.EditValue = SaveModel.LeaveEncashmentNo;
            lookupEmployee.EditValue = SaveModel.EmployeeID;
            lookupLeaveType.EditValue = SaveModel.LeaveTypeID;

            txtNofDays.EditValue = SaveModel.NofLeaves;
            LeaveBalance = SaveModel.NofLeaves + LeaveTypeDALObj.GetLeaveBalance(SaveModel.EmployeeID, SaveModel.LeaveTypeID, deLeaveEncashmentDate.DateTime);

            txtRemarks.Text = SaveModel.Remarks;
            txtDocument.Text = SaveModel.ApplicationDocumentFileName;

            base.FillSelectedRecordInContent(RecordToFill);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LeaveEncashmentEditListModel)EditRecordDataSource).LeaveEncashmentID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LeaveEncashmentEditListModel)EditRecordDataSource).LeaveEncashmentID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LeaveEncashmentEditListModel)EditRecordDataSource).LeaveEncashmentID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LeaveEncashmentEditListModel)EditRecordDataSource).LeaveEncashmentID);
        }

        #endregion

        #region Validation

        private void deLeaveEncashmentDate_Validating(object sender, CancelEventArgs e)
        {
            if(deLeaveEncashmentDate.EditValue == null)
            {
                ErrorProvider.SetError(deLeaveEncashmentDate, "Please select Leave Encashment date.");
            }
            else
            {
                ErrorProvider.SetError(deLeaveEncashmentDate, "");
            }
        }

        private void lookupLeaveEncashmentNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            if(lookupLeaveEncashmentNoPrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupLeaveEncashmentNoPrefix, "Please select prefix");
            }
            else
            {
                ErrorProvider.SetError(lookupLeaveEncashmentNoPrefix, "");
            }
        }

        private void txtLeaveEncashmentNo_Validating(object sender, CancelEventArgs e)
        {
            if(Model.CommonFunctions.ParseInt (txtLeaveEncashmentNo.Text) == 0)
            {
                ErrorProvider.SetError(txtLeaveEncashmentNo, "Please enter Leave Encashment number.");
            }
            else
            {
                ErrorProvider.SetError(txtLeaveEncashmentNo, "");
            }
        }


        private void txtNofDays_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider.SetError(txtNofDays, "");
            if (LeaveBalance < LeaveDays)
            {
                ErrorProvider.SetError(txtNofDays, "Number of leaves can not be greater than balance leaves. ");
            }
            else if(LeaveDays <= 0)
            {
                ErrorProvider.SetError(txtNofDays, "Please enter leave days greater than zero.");
            }
        }
        #endregion

        #region Other Events 
        private void lookupLeaveEncashmentNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupLeaveEncashmentNoPrefix.EditValue != null)
            {
                txtLeaveEncashmentNo.EditValue = DALObject.GenerateLeaveEncashmentNo((int)lookupLeaveEncashmentNoPrefix.EditValue);
            }
            else
            {
                txtLeaveEncashmentNo.EditValue = 0;
            }
        }

        private void lookupEmployee_EditValueChanged(object sender, EventArgs e)
        {
            UpdateLeaveBalance();
        }

        private void lookupLeaveType_EditValueChanged(object sender, EventArgs e)
        {
            UpdateLeaveBalance();
        }

        private void btnBrowseDocument_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDocument.Text = ofd.FileName;
                }
            }
        }

        private void btnOpenDocument_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
            {
                System.Diagnostics.Process.Start(txtDocument.Text);
            }
        }

        #endregion

        private void deLeaveEncashmentDate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateLeaveBalance();
        }

        void UpdateLeaveBalance()
        {
            if (lookupEmployee.EditValue != null && lookupLeaveType.EditValue != null && deLeaveEncashmentDate.EditValue != null)
            {
                LeaveBalance = LeaveTypeDALObj.GetLeaveBalance((int)lookupEmployee.EditValue, (int)lookupLeaveType.EditValue, deLeaveEncashmentDate.DateTime);
            }
            else
            {
                LeaveBalance = 0;
            }
        }

        private void txtNofDays_EditValueChanged(object sender, EventArgs e)
        {
            RemainingLeaveBalance = LeaveBalance - LeaveDays;
        }
    }
}
