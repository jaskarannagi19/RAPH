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
using Vision.DAL.Loan;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Loan;

namespace Vision.WinForm.Loan
{
    public partial class frmLoanApplication : Template.frmCRUDTemplate
    {
        #region Fields
        LoanApplicationDAL DALObject;
        EmployeeDAL EmployeeDALObj;
        LoanApplicationNoPrefixDAL LoanApplicationNoPrefixDALObj;

        List<EmployeeLookupListModel> dsEmployee;
        List<LoanApplicationNoPrefixLookupListModel> dsLoanApplicationNoPrefix;
        #endregion

        #region Properties
        int NofInstallments_;
        int NofInstallments
        {
            get
            {
                return NofInstallments_;
            }

            set
            {
                NofInstallments_ = value;
                txtNofInstallment.EditValue = NofInstallments_;

            }
        }

        decimal InstallmentAmount_;
        decimal InstallmentAmount
        {
            get
            {
                return InstallmentAmount_;
            }
            set
            {
                InstallmentAmount_ = value;
                txtInstallmentAmount.EditValue = value;
            }
        }
        #endregion

        #region Constructor
        public frmLoanApplication()
        {
            InitializeComponent();
            DALObject = new LoanApplicationDAL();
            EmployeeDALObj = new EmployeeDAL();
            LoanApplicationNoPrefixDALObj = new LoanApplicationNoPrefixDAL();

            FirstControl = lookupLoanApplicationNoPrefix;
        }
        #endregion

        #region Template
        public override void InitializeDefaultValues()
        {
            deLoanApplicationDate.EditValue = DateTime.Now.Date;

            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                if (dsLoanApplicationNoPrefix.Count > 0)
                {
                    lookupLoanApplicationNoPrefix.EditValue = dsLoanApplicationNoPrefix.First().LoanApplicationNoPrefixID;
                }
            }

            deDateFrom.EditValue = null;
            deDateTo.EditValue = null;
            lookupEmployee.EditValue = null;
        }

        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsLoanApplicationNoPrefix = LoanApplicationNoPrefixDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupLoanApplicationNoPrefix.Properties.DisplayMember = "LoanApplicationNoPrefixName";
            lookupLoanApplicationNoPrefix.Properties.ValueMember = "LoanApplicationNoPrefixID";
            lookupLoanApplicationNoPrefix.Properties.DataSource = dsLoanApplicationNoPrefix;

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLoanApplication SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblLoanApplication();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LoanApplicationEditListModel)EditRecordDataSource).LoanApplicationID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LoanApplicationDate = deLoanApplicationDate.DateTime.Date;
            SaveModel.LoanApplicationNoPrefixID = (int)lookupLoanApplicationNoPrefix.EditValue;
            SaveModel.LoanApplicationNo = Model.CommonFunctions.ParseInt(txtLoanApplicationNo.Text);
            SaveModel.EmployeeID = (int)lookupEmployee.EditValue;

            SaveModel.MonthFrom = deDateFrom.DateTime.Month;
            SaveModel.YearFrom = deDateFrom.DateTime.Year;
            SaveModel.MonthTo = deDateTo.DateTime.Month;
            SaveModel.YearTo = deDateTo.DateTime.Year;

            SaveModel.LoanAmount = Model.CommonFunctions.ParseDecimal(txtLoanAmount.Text);
            SaveModel.InstallmentAmount = InstallmentAmount;

            SaveModel.LoanPurpose = txtLoanPurpose.Text;
            SaveModel.Remarks = txtRemarks.Text;

            // if new record or document has been changed then update it.
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || SaveModel.ApplicationDocumentFileName != txtDocument.Text)
            {
                SaveModel.ApplicationDocumentFileName = null;
                if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
                {
                    string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LoanApplicationDocument));
                    string DocumentNewFileName = Path.Combine(DocumentNewPath,
                        "LAD" + CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                        SaveModel.LoanApplicationNo.ToString("0000000000") + Path.GetExtension(txtDocument.Text));
                    try
                    {
                        if (!Directory.Exists(DocumentNewPath))
                        {
                            Directory.CreateDirectory(DocumentNewPath);
                        }
                        // Allow to overwrite the document only if in edit mode 
                        File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.LoanApplicationID != 0));
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
            LoanApplicationEditListModel EditingRecord = (LoanApplicationEditListModel)RecordToFill;
            tblLoanApplication SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.LoanApplicationID);

            if(SaveModel == null)
            {
                return;
            }

            deLoanApplicationDate.DateTime = SaveModel.LoanApplicationDate;
            lookupLoanApplicationNoPrefix.EditValue = SaveModel.LoanApplicationNoPrefixID;
            txtLoanApplicationNo.EditValue = SaveModel.LoanApplicationNo;
            lookupEmployee.EditValue = SaveModel.EmployeeID;

            deDateFrom.DateTime = new DateTime(SaveModel.YearFrom, SaveModel.MonthFrom, 1);
            deDateTo.DateTime = new DateTime(SaveModel.YearTo, SaveModel.MonthTo, 1);

            txtLoanAmount.EditValue = SaveModel.LoanAmount;
            InstallmentAmount = SaveModel.InstallmentAmount;

            txtLoanPurpose.Text = SaveModel.LoanPurpose;
            txtRemarks.Text = SaveModel.Remarks;
            txtDocument.Text = SaveModel.ApplicationDocumentFileName;

            base.FillSelectedRecordInContent(RecordToFill);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LoanApplicationEditListModel)EditRecordDataSource).LoanApplicationID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LoanApplicationEditListModel)EditRecordDataSource).LoanApplicationID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LoanApplicationEditListModel)EditRecordDataSource).LoanApplicationID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LoanApplicationEditListModel)EditRecordDataSource).LoanApplicationID);
        }
        #endregion

        #region Validation

        private void deLoanApplicationDate_Validating(object sender, CancelEventArgs e)
        {
            if(deLoanApplicationDate.EditValue == null)
            {
                ErrorProvider.SetError(deLoanApplicationDate, "Please select Loan Application date.");
            }
            else
            {
                ErrorProvider.SetError(deLoanApplicationDate, "");
            }
        }

        private void lookupLoanApplicationNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            if(lookupLoanApplicationNoPrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupLoanApplicationNoPrefix, "Please select prefix");
            }
            else
            {
                ErrorProvider.SetError(lookupLoanApplicationNoPrefix, "");
            }
        }

        private void txtLoanApplicationNo_Validating(object sender, CancelEventArgs e)
        {
            if(Model.CommonFunctions.ParseInt (txtLoanApplicationNo.Text) == 0)
            {
                ErrorProvider.SetError(txtLoanApplicationNo, "Please enter Loan Application number.");
            }
            else
            {
                ErrorProvider.SetError(txtLoanApplicationNo, "");
            }
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if(deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please select date from.");
            }
            else if (deDateTo.DateTime < deDateFrom.DateTime)
            {
                ErrorProvider.SetError(deDateFrom, "Date from can not be greater than date to");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, "");
            }
        }

        private void deDateTo_Validating(object sender, CancelEventArgs e)
        {
            if(deDateTo.EditValue == null)
            {
                ErrorProvider.SetError(deDateTo, "Please select date to");
            }
            else if(deDateTo.DateTime < deDateFrom.DateTime)
            {
                ErrorProvider.SetError(deDateTo, "Date to can not be less than date from");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, "");
            }
        }
        
        #endregion

        #region Other Events 
        private void lookupLoanApplicationNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupLoanApplicationNoPrefix.EditValue != null)
            {
                txtLoanApplicationNo.EditValue = DALObject.GenerateLoanApplicationNo((int)lookupLoanApplicationNoPrefix.EditValue);
            }
            else
            {
                txtLoanApplicationNo.EditValue = 0;
            }
        }


        private void deDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            NofInstallments = Model.CommonFunctions.GetMonthDifference(deDateFrom.DateTime, deDateTo.DateTime) + 1;
            CalculateInstallmentAmount();
        }

        private void deDateTo_EditValueChanged(object sender, EventArgs e)
        {
            NofInstallments = Model.CommonFunctions.GetMonthDifference(deDateFrom.DateTime, deDateTo.DateTime) + 1;
            CalculateInstallmentAmount();
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

        private void txtLoanAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateInstallmentAmount();
        }

        private void txtLoanAmount_Validating(object sender, CancelEventArgs e)
        {
            if (Model.CommonFunctions.ParseDecimal(txtLoanAmount.Text) == 0)
            {
                ErrorProvider.SetError(txtLoanAmount, "Please enter loan amount.");
            }
            else
            {
                ErrorProvider.SetError(txtLoanAmount, "");
            }
        }
        #endregion

        #region Helping Method 
        void CalculateInstallmentAmount()
        {
            InstallmentAmount = Math.Round(Model.CommonFunctions.ParseDecimal(txtLoanAmount.Text) / (NofInstallments != 0 ? NofInstallments : 1), 2);
        }
        #endregion
    }
}
