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
using Vision.DAL.Account;
using Vision.DAL.Employee;
using Vision.DAL.Loan;
using Vision.DAL.SubMaster;
using Vision.Model;
using Vision.Model.Account;
using Vision.Model.Employee;
using Vision.Model.Loan;
using Vision.Model.SubMaster;

namespace Vision.WinForm.Loan
{
    public partial class frmLoanAdjustment : Template.frmCRUDTemplate
    {
        #region Fields
        LoanAdjustmentDAL DALObject;
        EmployeeDAL EmployeeDALObj;
        LoanAdjustmentNoPrefixDAL LoanAdjustmentNoPrefixDALObj;
        LoanApplicationDAL LoanApplicationDALObj;
        BankAccountDAL BankAccountDALObj;

        List<LoanAdjustmentNoPrefixLookupListModel> dsLoanAdjustmentNoPrefix;
        List<EmployeeLookupListModel> dsEmployee;
        List<BankAccountLookupListModel> dsBankAccount;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public frmLoanAdjustment()
        {
            InitializeComponent();
            DALObject = new LoanAdjustmentDAL();
            EmployeeDALObj = new EmployeeDAL();
            LoanAdjustmentNoPrefixDALObj = new LoanAdjustmentNoPrefixDAL();
            LoanApplicationDALObj = new LoanApplicationDAL();
            BankAccountDALObj = new BankAccountDAL();

            FirstControl = lookupLoanAdjustmentNoPrefix;
        }
        #endregion

        #region Template
        public override void InitializeDefaultValues()
        {
            deLoanAdjustmentDate.EditValue = DateTime.Now.Date;

            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                if (dsLoanAdjustmentNoPrefix.Count > 0)
                {
                    lookupLoanAdjustmentNoPrefix.EditValue = dsLoanAdjustmentNoPrefix.First().LoanAdjustmentNoPrefixID;
                }
            }

            deDateOfDeposite.EditValue = null;
            lookupEmployee.EditValue = null;
        }

        public override void LoadLookupDataSource()
        {
            dsLoanAdjustmentNoPrefix = LoanAdjustmentNoPrefixDALObj.GetLookupList();
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsBankAccount = BankAccountDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupLoanAdjustmentNoPrefix.Properties.DisplayMember = "LoanAdjustmentNoPrefixName";
            lookupLoanAdjustmentNoPrefix.Properties.ValueMember = "LoanAdjustmentNoPrefixID";
            lookupLoanAdjustmentNoPrefix.Properties.DataSource = dsLoanAdjustmentNoPrefix;

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            lookupBankAccount.Properties.ValueMember = "BankAccountID";
            lookupBankAccount.Properties.DisplayMember = "BankAccountName";
            lookupBankAccount.Properties.DataSource = dsBankAccount;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLoanAdjustment SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblLoanAdjustment();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LoanAdjustmentEditListModel)EditRecordDataSource).LoanAdjustmentID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LoanAdjustmentDate = deLoanAdjustmentDate.DateTime.Date;
            SaveModel.LoanAdjustmentNoPrefixID = (int)lookupLoanAdjustmentNoPrefix.EditValue;
            SaveModel.LoanAdjustmentNo = Model.CommonFunctions.ParseInt(txtLoanAdjustmentNo.Text);
            SaveModel.EmployeeID = (int)lookupEmployee.EditValue;
            SaveModel.LoanApplicationID = (int)lookupLoan.EditValue;
            SaveModel.PaymentModeID = (byte)cmbPaymentMode.SelectedIndex;
            SaveModel.DateOfDeposite = deDateOfDeposite.DateTime.Date;
            SaveModel.CompanyBankAccountID = (int?)lookupBankAccount.EditValue;
            SaveModel.LoanAdjustmentAmount = Model.CommonFunctions.ParseDecimal(txtLoanAdjustmentAmount.Text);
            SaveModel.ReasonForLoanAdjustment = txtReasonForLoanAdj.Text;
            SaveModel.Remarks = txtRemarks.Text;

            // if new record or document has been changed then update it.
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || SaveModel.ApplicationDocumentFileName != txtDocument.Text)
            {
                SaveModel.ApplicationDocumentFileName = null;
                if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
                {
                    string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LoanAdjustmentDocument));
                    string DocumentNewFileName = Path.Combine(DocumentNewPath,
                        "LAdjD" + CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                        SaveModel.LoanAdjustmentNo.ToString("0000000000") + Path.GetExtension(txtDocument.Text));
                    try
                    {
                        if (!Directory.Exists(DocumentNewPath))
                        {
                            Directory.CreateDirectory(DocumentNewPath);
                        }
                        // Allow to overwrite the document only if in edit mode 
                        File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.LoanAdjustmentID != 0));
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
            LoanAdjustmentEditListModel EditingRecord = (LoanAdjustmentEditListModel)RecordToFill;
            tblLoanAdjustment SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.LoanAdjustmentID);

            if(SaveModel == null)
            {
                return;
            }

            deLoanAdjustmentDate.DateTime = SaveModel.LoanAdjustmentDate;
            lookupLoanAdjustmentNoPrefix.EditValue = SaveModel.LoanAdjustmentNoPrefixID;
            txtLoanAdjustmentNo.EditValue = SaveModel.LoanAdjustmentNo;
            lookupEmployee.EditValue = SaveModel.EmployeeID;
            lookupLoan.EditValue = SaveModel.LoanApplicationID;

            var loan = ((List<LoanApplicationLookupListModel>)lookupLoan.Properties.DataSource).FirstOrDefault(r => r.LoanApplicationID == SaveModel.LoanApplicationID);
            if (loan != null)
            {
                txtLoanAmount.EditValue = loan.LoanApplicationAmount;
            }

            txtLoanAdjustmentAmount.EditValue = SaveModel.LoanAdjustmentAmount;
            deDateOfDeposite.DateTime = SaveModel.DateOfDeposite;
            cmbPaymentMode.SelectedIndex = SaveModel.PaymentModeID;
            lookupBankAccount.EditValue = SaveModel.CompanyBankAccountID;
            txtReasonForLoanAdj.Text = SaveModel.ReasonForLoanAdjustment;
            txtRemarks.Text = SaveModel.Remarks;
            txtDocument.Text = SaveModel.ApplicationDocumentFileName;

            base.FillSelectedRecordInContent(RecordToFill);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LoanAdjustmentEditListModel)EditRecordDataSource).LoanAdjustmentID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LoanAdjustmentEditListModel)EditRecordDataSource).LoanAdjustmentID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LoanAdjustmentEditListModel)EditRecordDataSource).LoanAdjustmentID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LoanAdjustmentEditListModel)EditRecordDataSource).LoanAdjustmentID);
        }
        #endregion

        #region Validation

        private void deLoanAdjustmentDate_Validating(object sender, CancelEventArgs e)
        {
            if(deLoanAdjustmentDate.EditValue == null)
            {
                ErrorProvider.SetError(deLoanAdjustmentDate, "Please select Loan Adjustment date.");
            }
            else
            {
                ErrorProvider.SetError(deLoanAdjustmentDate, "");
            }
        }

        private void lookupLoanAdjustmentNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            if(lookupLoanAdjustmentNoPrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupLoanAdjustmentNoPrefix, "Please select prefix");
            }
            else
            {
                ErrorProvider.SetError(lookupLoanAdjustmentNoPrefix, "");
            }
        }

        private void txtLoanAdjustmentNo_Validating(object sender, CancelEventArgs e)
        {
            if(Model.CommonFunctions.ParseInt (txtLoanAdjustmentNo.Text) == 0)
            {
                ErrorProvider.SetError(txtLoanAdjustmentNo, "Please enter Loan Adjustment number.");
            }
            else
            {
                ErrorProvider.SetError(txtLoanAdjustmentNo, "");
            }
        }

        private void deDateOfDeposite_Validating(object sender, CancelEventArgs e)
        {
            if(deDateOfDeposite.EditValue == null)
            {
                ErrorProvider.SetError(deDateOfDeposite, "Please select date of deposite.");
            }
            else
            {
                ErrorProvider.SetError(deDateOfDeposite, "");
            }
        }

        private void lookupLoan_Validating(object sender, CancelEventArgs e)
        {
            if (lookupLoan.EditValue == null)
            {
                ErrorProvider.SetError(lookupLoan, "Please select Loan");
            }
            else
            {
                ErrorProvider.SetError(lookupLoan, "");
            }
        }
        #endregion

        #region Other Events 
        private void lookupLoanAdjustmentNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupLoanAdjustmentNoPrefix.EditValue != null)
            {
                txtLoanAdjustmentNo.EditValue = DALObject.GenerateLoanAdjustmentNo((int)lookupLoanAdjustmentNoPrefix.EditValue);
            }
            else
            {
                txtLoanAdjustmentNo.EditValue = 0;
            }
        }


        private void lookupEmployee_EditValueChanged(object sender, EventArgs e)
        {
            LoadLoanDataSource();
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
        void LoadLoanDataSource()
        {
            if (lookupEmployee.EditValue != null)
            {
                lookupLoan.Properties.ValueMember = "LoanApplicationID";
                lookupLoan.Properties.DisplayMember = "LoanFromTo";
                lookupLoan.Properties.DataSource = LoanApplicationDALObj.GetLookupList((int)lookupEmployee.EditValue);
            }
            else
            {
                lookupLoan.Properties.DataSource = null;
                lookupEmployee.EditValue = null;
            }
        }

        #endregion

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((eLoanAdjustment_PaymentMode)cmbPaymentMode.SelectedIndex) != eLoanAdjustment_PaymentMode.Bank)
            {
                lookupBankAccount.Enabled = false;
                lookupBankAccount.EditValue = null;
            }
            else
            {
                lookupBankAccount.Enabled = true;
            }
        }
    }
}
