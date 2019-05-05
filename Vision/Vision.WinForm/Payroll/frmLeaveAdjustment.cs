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
using DevExpress.XtraGrid.Views.Grid;

namespace Vision.WinForm.Payroll
{
    public partial class frmLeaveAdjustment : Template.frmCRUDTemplate
    {
        #region Fields
        LeaveAdjustmentDAL DALObject;
        EmployeeDAL EmployeeDALObj;
        LeaveTypeDAL LeaveTypeDALObj;
        HolidayDAL HolidayDALObj;
        DAL.Settings.LocationDAL LocationDALObj;
        LeaveAdjustmentNoPrefixDAL LeaveAdjustmentNoPrefixDALObj;

        List<EmployeeLookupListModel> dsEmployee;
        List<LeaveTypeLookupListModel> dsLeaveType;
        List<LeaveAdjustmentNoPrefixLookupListModel> dsLeaveAdjustmentNoPrefix;
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
                RemainingLeaveBalance = LeaveBalance + LeaveDays;
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
        public frmLeaveAdjustment()
        {
            InitializeComponent();
            DALObject = new LeaveAdjustmentDAL();
            EmployeeDALObj = new EmployeeDAL();
            LeaveTypeDALObj = new LeaveTypeDAL();
            HolidayDALObj = new HolidayDAL();
            LocationDALObj = new DAL.Settings.LocationDAL();
            LeaveAdjustmentNoPrefixDALObj = new LeaveAdjustmentNoPrefixDAL();

            FirstControl = lookupLeaveAdjustmentNoPrefix;
        }
        #endregion

        #region Template
        public override void InitializeDefaultValues()
        {
            deLeaveAdjustmentDate.EditValue = DateTime.Now.Date;

            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                //txtLeaveAdjustmentNo.EditValue = DALObject.GenerateLeaveAdjustmentNo();
                if (dsLeaveAdjustmentNoPrefix.Count > 0)
                {
                    lookupLeaveAdjustmentNoPrefix.EditValue = dsLeaveAdjustmentNoPrefix.First().LeaveAdjustmentNoPrefixID;
                }
            }

            LeaveAdjustmentDayDetailBindingSource.Clear();
            lookupEmployee.EditValue = null;
            lookupLeaveType.EditValue = null;
        }

        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsLeaveType = LeaveTypeDALObj.GetLookupList();
            dsLeaveAdjustmentNoPrefix = LeaveAdjustmentNoPrefixDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupLeaveAdjustmentNoPrefix.Properties.DisplayMember = "LeaveAdjustmentNoPrefixName";
            lookupLeaveAdjustmentNoPrefix.Properties.ValueMember = "LeaveAdjustmentNoPrefixID";
            lookupLeaveAdjustmentNoPrefix.Properties.DataSource = dsLeaveAdjustmentNoPrefix;

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            lookupLeaveType.Properties.ValueMember = "LeaveTypeID";
            lookupLeaveType.Properties.DisplayMember = "LeaveTypeName";
            lookupLeaveType.Properties.DataSource = dsLeaveType;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLeaveAdjustment SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblLeaveAdjustment();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LeaveAdjustmentEditListModel)EditRecordDataSource).LeaveAdjustmentID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LeaveAdjustmentDate = deLeaveAdjustmentDate.DateTime.Date;
            SaveModel.LeaveAdjustmentNoPrefixID = (int)lookupLeaveAdjustmentNoPrefix.EditValue;
            SaveModel.LeaveAdjustmentNo = Model.CommonFunctions.ParseInt(txtLeaveAdjustmentNo.Text);
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
                    string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LeaveAdjustmentDocument));
                    string DocumentNewFileName = Path.Combine(DocumentNewPath,
                        "LED" + CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                        SaveModel.LeaveAdjustmentNo.ToString("0000000000") + Path.GetExtension(txtDocument.Text));
                    try
                    {
                        if (!Directory.Exists(DocumentNewPath))
                        {
                            Directory.CreateDirectory(DocumentNewPath);
                        }
                        // Allow to overwrite the document only if in edit mode 
                        File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.LeaveAdjustmentID != 0));
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
            LeaveAdjustmentEditListModel EditingRecord = (LeaveAdjustmentEditListModel)RecordToFill;
            tblLeaveAdjustment SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.LeaveAdjustmentID);

            if(SaveModel == null)
            {
                return;
            }

            deLeaveAdjustmentDate.DateTime = SaveModel.LeaveAdjustmentDate;
            lookupLeaveAdjustmentNoPrefix.EditValue = SaveModel.LeaveAdjustmentNoPrefixID;
            txtLeaveAdjustmentNo.EditValue = SaveModel.LeaveAdjustmentNo;
            lookupEmployee.EditValue = SaveModel.EmployeeID;
            lookupLeaveType.EditValue = SaveModel.LeaveTypeID;

            txtNofDays.EditValue = SaveModel.NofLeaves;
            LeaveBalance = LeaveTypeDALObj.GetLeaveBalance(SaveModel.EmployeeID, SaveModel.LeaveTypeID, deLeaveAdjustmentDate.DateTime) - SaveModel.NofLeaves;

            txtRemarks.Text = SaveModel.Remarks;
            txtDocument.Text = SaveModel.ApplicationDocumentFileName;

            base.FillSelectedRecordInContent(RecordToFill);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LeaveAdjustmentEditListModel)EditRecordDataSource).LeaveAdjustmentID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LeaveAdjustmentEditListModel)EditRecordDataSource).LeaveAdjustmentID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LeaveAdjustmentEditListModel)EditRecordDataSource).LeaveAdjustmentID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LeaveAdjustmentEditListModel)EditRecordDataSource).LeaveAdjustmentID);
        }

        #endregion

        #region Validation

        private void deLeaveAdjustmentDate_Validating(object sender, CancelEventArgs e)
        {
            if(deLeaveAdjustmentDate.EditValue == null)
            {
                ErrorProvider.SetError(deLeaveAdjustmentDate, "Please select Leave Adjustment date.");
            }
            else
            {
                ErrorProvider.SetError(deLeaveAdjustmentDate, "");
            }
        }

        private void lookupLeaveAdjustmentNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            if(lookupLeaveAdjustmentNoPrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupLeaveAdjustmentNoPrefix, "Please select prefix");
            }
            else
            {
                ErrorProvider.SetError(lookupLeaveAdjustmentNoPrefix, "");
            }
        }

        private void txtLeaveAdjustmentNo_Validating(object sender, CancelEventArgs e)
        {
            if(Model.CommonFunctions.ParseInt (txtLeaveAdjustmentNo.Text) == 0)
            {
                ErrorProvider.SetError(txtLeaveAdjustmentNo, "Please enter Leave Adjustment number.");
            }
            else
            {
                ErrorProvider.SetError(txtLeaveAdjustmentNo, "");
            }
        }

        private void txtNofDays_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider.SetError(txtNofDays, "");
            if(LeaveDays == 0)
            {
                ErrorProvider.SetError(txtNofDays, "Please enter leave days.");
            }
        }
        #endregion

        #region Other Events 
        private void lookupLeaveAdjustmentNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupLeaveAdjustmentNoPrefix.EditValue != null)
            {
                txtLeaveAdjustmentNo.EditValue = DALObject.GenerateLeaveAdjustmentNo((int)lookupLeaveAdjustmentNoPrefix.EditValue);
            }
            else
            {
                txtLeaveAdjustmentNo.EditValue = 0;
            }
        }

        private void lookupEmployee_EditValueChanged(object sender, EventArgs e)
        {
            UpdateBalance();
        }

        private void lookupLeaveType_EditValueChanged(object sender, EventArgs e)
        {
            UpdateBalance();
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

        private void deLeaveAdjustmentDate_EditValueChanged(object sender, EventArgs e)
        {
            UpdateBalance();
        }

        void UpdateBalance()
        {
            if (lookupEmployee.EditValue != null && lookupLeaveType.EditValue != null && deLeaveAdjustmentDate.EditValue != null)
            {
                LeaveBalance = LeaveTypeDALObj.GetLeaveBalance((int)lookupEmployee.EditValue, (int)lookupLeaveType.EditValue, deLeaveAdjustmentDate.DateTime);
            }
            else
            {
                LeaveBalance = 0;
            }
        }

        private void txtNofDays_EditValueChanged(object sender, EventArgs e)
        {
            RemainingLeaveBalance = LeaveBalance + LeaveDays;
        }
    }
}
