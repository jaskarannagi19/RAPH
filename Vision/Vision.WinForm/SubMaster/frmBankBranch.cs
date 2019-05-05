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
using Vision.DAL.SubMaster;
using Vision.Model;
using Vision.Model.SubMaster;

namespace Vision.WinForm.SubMaster
{
    public partial class frmBankBranch : Template.frmCRUDTemplate
    {
        BankBranchDAL DALObject;
        DAL.City.CityDAL CityDALObj;
        DAL.SubMaster.BankNameDAL BankNameDALObj;

        List<Model.City.CityLookupListModel> dsCity;
        List<Model.SubMaster.BankNameLookupListModel> dsBankName;

        public frmBankBranch()
        {
            InitializeComponent();
            DALObject = new BankBranchDAL();
            CityDALObj = new DAL.City.CityDAL();
            BankNameDALObj = new BankNameDAL();

            FirstControl = lookupBank;
        }

        public override void LoadLookupDataSource()
        {
            dsCity = CityDALObj.GetLookupList();
            dsBankName = BankNameDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupBank.Properties.ValueMember = "BankNameID";
            lookupBank.Properties.DisplayMember = "BankName";
            lookupBank.Properties.DataSource = dsBankName;

            lookupCity.Properties.ValueMember = "CityID";
            lookupCity.Properties.DisplayMember = "CityName";
            lookupCity.Properties.DataSource = dsCity;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblBankBranch SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblBankBranch();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((BankBranchEditListModel)EditRecordDataSource).BankBranchID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.BankBranchName = txtBranchName.Text;
            SaveModel.BankNameID = (int)lookupBank.EditValue;
            SaveModel.Address1 = txtAddressLine1.Text;
            SaveModel.Address2 = txtAddressLine2.Text;
            SaveModel.Address3 = txtAddressLine3.Text;
            SaveModel.CityID = (int)lookupCity.EditValue;
            SaveModel.PIN = txtPIN.Text;
            SaveModel.SortCode = txtSortCode.Text;
            SaveModel.SwiftCode = txtSwiftCode.Text;
            SaveModel.BankCode = txtBankCode.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblBankBranch EditingRecord = DALObject.FindSaveModelByPrimeKey( ((BankBranchEditListModel)RecordToFill).BankBranchID);

            txtBranchName.Text = EditingRecord.BankBranchName;
            lookupBank.EditValue = EditingRecord.BankNameID;
            txtAddressLine1.Text = EditingRecord.Address1;
            txtAddressLine2.Text = EditingRecord.Address2;
            txtAddressLine3.Text = EditingRecord.Address3;
            lookupCity.EditValue = EditingRecord.CityID;
            txtPIN.Text = EditingRecord.PIN;
            txtSortCode.Text = EditingRecord.SortCode;
            txtSwiftCode.Text = EditingRecord.SwiftCode;
            txtBankCode.Text = EditingRecord.BankCode;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((BankBranchEditListModel)EditRecordDataSource).BankBranchID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((BankBranchEditListModel)EditRecordDataSource).BankBranchID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((BankBranchEditListModel)EditRecordDataSource).BankBranchID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((BankBranchEditListModel)EditRecordDataSource).BankBranchID);
        }

        private void txtBankBranchName_Validating(object sender, CancelEventArgs e)
        {
            if (txtBranchName.Text == "")
            {
                ErrorProvider.SetError(txtBranchName, "Can not accept blank Branch name.");
            }
            else if (DALObject.IsDuplicateRecord(txtBranchName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((BankBranchEditListModel)EditRecordDataSource).BankBranchID : 0)))
            {
                ErrorProvider.SetError(txtBranchName, "Can not accept duplicate Branch name.");
            }
            else
            {
                ErrorProvider.SetError(txtBranchName, "");
            }
        }

        private void lookupBank_Validating(object sender, CancelEventArgs e)
        {
            if(lookupBank.EditValue == null)
            {
                ErrorProvider.SetError(lookupBank, "Please select a bank name.");
            }
            else
            {
                ErrorProvider.SetError(lookupBank, "");
            }
        }

        private void txtSortCode_Validating(object sender, CancelEventArgs e)
        {
            //if(String.IsNullOrWhiteSpace( txtSortCode.Text))
            //{
            //    ErrorProvider.SetError(txtSortCode, "Please enter sort code.");
            //}
            //else if(txtSortCode.Text.Length < 10)
            //{
            //    ErrorProvider.SetError(txtSortCode, "Please enter 10 digit sort code");
            //}
            //else
            //{
            //    ErrorProvider.SetError(txtSortCode, "");
            //}
        }

        private void txtSwiftCode_Validating(object sender, CancelEventArgs e)
        {
            //if (String.IsNullOrWhiteSpace(txtSwiftCode.Text))
            //{
            //    ErrorProvider.SetError(txtSwiftCode, "Please enter swift code.");
            //}
            //else if (txtSwiftCode.Text.Length < 10)
            //{
            //    ErrorProvider.SetError(txtSwiftCode, "Please enter 10 digit swift code");
            //}
            //else
            //{
            //    ErrorProvider.SetError(txtSwiftCode, "");
            //}
        }
    }
}
