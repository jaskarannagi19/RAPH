using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL;
using Vision.DAL.Account;
using Vision.DAL.SubMaster;
using Vision.Model;
using Vision.Model.Account;
using Vision.Model.SubMaster;

namespace Vision.WinForm.Account
{
    public partial class frmBankAccount : Template.frmCRUDTemplate
    {
        BankAccountDAL DALObject;
        BankNameDAL BankNameDALObj;
        BankBranchDAL BankBranchDALObj;
        CurrencyDAL CurrencyDALObj;

        List<BankNameLookupListModel> dsBankName;
        List<CurrencyLookupListModel> dsCurrency;

        public frmBankAccount()
        {
            InitializeComponent();

            DALObject = new BankAccountDAL();
            BankNameDALObj = new BankNameDAL();
            BankBranchDALObj = new BankBranchDAL();
            CurrencyDALObj = new CurrencyDAL();

            FirstControl = txtBankAcNo;
        }

        public override void LoadLookupDataSource()
        {
            dsBankName = BankNameDALObj.GetLookupList();
            dsCurrency = CurrencyDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupBank.Properties.ValueMember = "BankNameID";
            lookupBank.Properties.DisplayMember = "BankName";
            lookupBank.Properties.DataSource = dsBankName;

            lookupBranch.Properties.ValueMember = "BankBranchID";
            lookupBranch.Properties.DisplayMember = "BankBranchName";

            lookupCurrency.Properties.ValueMember = "CurrencyID";
            lookupCurrency.Properties.DisplayMember = "CurrencyName";
            lookupCurrency.Properties.DataSource = dsCurrency;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblAccount SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblAccount();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((BankAccountEditListModel)EditRecordDataSource).BankAccountID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.AccountName = txtBankAcName.Text;
            SaveModel.BankAccountNo = txtBankAcNo.Text;
            SaveModel.BankNameID = (int)lookupBank.EditValue;
            SaveModel.BranchID = (int)lookupBranch.EditValue;
            SaveModel.CurrencyID = (int?)lookupCurrency.EditValue;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblAccount EditingRecord = DALObject.FindSaveModelByPrimeKey(((BankAccountEditListModel)RecordToFill).BankAccountID);

            txtBankAcName.Text = EditingRecord.AccountName;
            txtBankAcNo.Text = EditingRecord.BankAccountNo;
            lookupBank.EditValue = EditingRecord.BankNameID;
            lookupBranch.EditValue = EditingRecord.BranchID;
            lookupCurrency.EditValue = EditingRecord.CurrencyID;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((BankAccountEditListModel)EditRecordDataSource).BankAccountID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((BankAccountEditListModel)EditRecordDataSource).BankAccountID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((BankAccountEditListModel)EditRecordDataSource).BankAccountID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((BankAccountEditListModel)EditRecordDataSource).BankAccountID);
        }

        private void txtBankAcName_Validating(object sender, CancelEventArgs e)
        {
            if (txtBankAcName.Text == "")
            {
                ErrorProvider.SetError(txtBankAcName, "Can not accept blank account holder name.");
            }
            else
            {
                ErrorProvider.SetError(txtBankAcName, "");
            }
        }

        private void txtBankAcNo_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtBankAcNo.Text))
            {
                ErrorProvider.SetError(txtBankAcNo, "Please enter bank acounnt number");
            }
            else if (DALObject.IsDuplicateBankAcNo(txtBankAcNo.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((BankAccountEditListModel)EditRecordDataSource).BankAccountID : 0)))
            {
                ErrorProvider.SetError(txtBankAcNo, "Can not accept duplicate Bank Account number.");
            }
            else
            {
                ErrorProvider.SetError(txtBankAcNo, "");
            }
        }

        private void lookupBank_EditValueChanged(object sender, EventArgs e)
        {
            lookupBranch.Properties.DataSource = BankBranchDALObj.GetLookupList((int?)lookupBank.EditValue ?? 0);
        }

        private void lookupBank_Validating(object sender, CancelEventArgs e)
        {
            if(lookupBank.EditValue == null)
            {
                ErrorProvider.SetError(lookupBank, "Please select bank");
            }
            else
            {
                ErrorProvider.SetError(lookupBank, "");
            }
        }

        private void lookupBranch_Validating(object sender, CancelEventArgs e)
        {
            if(lookupBranch.EditValue == null)
            {
                ErrorProvider.SetError(lookupBranch, "Please select branch");
            }
            else
            {
                ErrorProvider.SetError(lookupBranch, "");
            }
        }

        private void lookupCurrency_Validating(object sender, CancelEventArgs e)
        {
            if(lookupCurrency.EditValue == null)
            {
                ErrorProvider.SetError(lookupCurrency, "Please select currency.");
            }
            else
            {
                ErrorProvider.SetError(lookupCurrency, "");
            }
        }
    }
}
