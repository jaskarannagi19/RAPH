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

    public partial class frmTAApproval : Template.frmCRUDTemplate
    {
        #region Fields
        TAApprovalDAL DALObject;
        EmployeeDAL EmployeeDALObj;
        TAApprovalNoPrefixDAL TAApprovalNoPrefixDALObj;

        List<TAApprovalNoPrefixLookupListModel> dsTAApprovalNoPrefix;
        List<EmployeeLookupListModel> dsEmployee;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public frmTAApproval()
        {
            InitializeComponent();
            DALObject = new TAApprovalDAL();
            EmployeeDALObj = new EmployeeDAL();
            TAApprovalNoPrefixDALObj = new TAApprovalNoPrefixDAL();

            FirstControl = lookupTAApprovalNoPrefix;
        }
        #endregion

        #region Template
        public override void InitializeDefaultValues()
        {
            deTAApprovalDate.EditValue = DateTime.Now.Date;

            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                if (dsTAApprovalNoPrefix.Count > 0)
                {
                    lookupTAApprovalNoPrefix.EditValue = dsTAApprovalNoPrefix.First().TAApprovalNoPrefixID;
                }
            }

            deApprovedDate.EditValue = null;
            lookupEmployee.EditValue = null;
        }

        public override void LoadLookupDataSource()
        {
            dsTAApprovalNoPrefix = TAApprovalNoPrefixDALObj.GetLookupList();
            dsEmployee = EmployeeDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupTAApprovalNoPrefix.Properties.DisplayMember = "TAApprovalNoPrefixName";
            lookupTAApprovalNoPrefix.Properties.ValueMember = "TAApprovalNoPrefixID";
            lookupTAApprovalNoPrefix.Properties.DataSource = dsTAApprovalNoPrefix;

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblTAApproval SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblTAApproval();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((TAApprovalEditListModel)EditRecordDataSource).TAApprovalID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.TAApprovalDate = deTAApprovalDate.DateTime.Date;
            SaveModel.TAApprovalNoPrefixID = (int)lookupTAApprovalNoPrefix.EditValue;
            SaveModel.TAApprovalNo = Model.CommonFunctions.ParseInt(txtTAApprovalNo.Text);
            SaveModel.EmployeeID = (int)lookupEmployee.EditValue;

            SaveModel.ApprovedDate = deApprovedDate.DateTime;
            SaveModel.ApprovalTypeID = (byte)cmbApprovalType.SelectedIndex;
            SaveModel.ApprovedHours = txtNofHours.EditValueToDecimal();

            SaveModel.Remarks = txtRemarks.Text;

            // if new record or document has been changed then update it.
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || SaveModel.ApplicationDocumentFileName != txtDocument.Text)
            {
                SaveModel.ApplicationDocumentFileName = null;
                if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
                {
                    string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_TAApprovalDocument));
                    string DocumentNewFileName = Path.Combine(DocumentNewPath,
                        "TAAD" + 
                        CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") + 
                        CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                        lookupTAApprovalNoPrefix.Text +
                        SaveModel.TAApprovalNo.ToString("0000000000") + 
                        Path.GetExtension(txtDocument.Text));
                    try
                    {
                        if (!Directory.Exists(DocumentNewPath))
                        {
                            Directory.CreateDirectory(DocumentNewPath);
                        }
                        // Allow to overwrite the document only if in edit mode 
                        File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.TAApprovalID != 0));
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
            TAApprovalEditListModel EditingRecord = (TAApprovalEditListModel)RecordToFill;
            tblTAApproval SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.TAApprovalID);

            if (SaveModel == null)
            {
                return;
            }

            deTAApprovalDate.DateTime = SaveModel.TAApprovalDate;
            lookupTAApprovalNoPrefix.EditValue = SaveModel.TAApprovalNoPrefixID;
            txtTAApprovalNo.EditValue = SaveModel.TAApprovalNo;
            lookupEmployee.EditValue = SaveModel.EmployeeID;

            deApprovedDate.DateTime = SaveModel.ApprovedDate;
            cmbApprovalType.SelectedIndex = SaveModel.ApprovalTypeID;
            txtNofHours.EditValue = SaveModel.ApprovedHours;

            txtRemarks.Text = SaveModel.Remarks;
            txtDocument.Text = SaveModel.ApplicationDocumentFileName;

            base.FillSelectedRecordInContent(RecordToFill);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((TAApprovalEditListModel)EditRecordDataSource).TAApprovalID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((TAApprovalEditListModel)EditRecordDataSource).TAApprovalID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((TAApprovalEditListModel)EditRecordDataSource).TAApprovalID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((TAApprovalEditListModel)EditRecordDataSource).TAApprovalID);
        }
        #endregion

        #region Validation

        private void deTAApprovalDate_Validating(object sender, CancelEventArgs e)
        {
            if (deTAApprovalDate.EditValue == null)
            {
                ErrorProvider.SetError(deTAApprovalDate, "Please select TA Approval date.");
            }
            else
            {
                ErrorProvider.SetError(deTAApprovalDate, "");
            }
        }

        private void lookupTAApprovalNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            if (lookupTAApprovalNoPrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupTAApprovalNoPrefix, "Please select prefix");
            }
            else
            {
                ErrorProvider.SetError(lookupTAApprovalNoPrefix, "");
            }
        }

        private void txtTAApprovalNo_Validating(object sender, CancelEventArgs e)
        {
            if (Model.CommonFunctions.ParseInt(txtTAApprovalNo.Text) == 0)
            {
                ErrorProvider.SetError(txtTAApprovalNo, "Please enter TA Approval number.");
            }
            else
            {
                ErrorProvider.SetError(txtTAApprovalNo, "");
            }
        }

        private void deApprovedDate_Validating(object sender, CancelEventArgs e)
        {
            if (deApprovedDate.EditValue == null)
            {
                ErrorProvider.SetError(deApprovedDate, "Please enter Approved Date.");
            }
            else
            {
                ErrorProvider.SetError(deApprovedDate, "");
            }
        }
        #endregion

        #region Other Events 
        private void lookupTAApprovalNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupTAApprovalNoPrefix.EditValue != null)
            {
                txtTAApprovalNo.EditValue = DALObject.GenerateTAApprovalNo((int)lookupTAApprovalNoPrefix.EditValue);
            }
            else
            {
                txtTAApprovalNo.EditValue = 0;
            }
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

        #region Helping Method 

        #endregion

    }
}