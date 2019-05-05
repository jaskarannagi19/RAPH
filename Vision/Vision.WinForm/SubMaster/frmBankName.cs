using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.SubMaster;
using Vision.Model;
using Vision.Model.SubMaster;

namespace Vision.WinForm.SubMaster
{
    public partial class frmBankName : Template.frmCRUDTemplate
    {
        BankNameDAL DALObject;

        public frmBankName()
        {
            InitializeComponent();
            DALObject = new BankNameDAL();
            FirstControl = txtBankName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblBankName SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblBankName();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((BankNameEditListModel)EditRecordDataSource).BankNameID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.BankName = txtBankName.Text;
            SaveModel.ShortName = txtShortName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            BankNameEditListModel EditingRecord = (BankNameEditListModel)RecordToFill;

            txtBankName.Text = EditingRecord.BankName;
            txtShortName.Text = EditingRecord.ShortName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((BankNameEditListModel)EditRecordDataSource).BankNameID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((BankNameEditListModel)EditRecordDataSource).BankNameID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((BankNameEditListModel)EditRecordDataSource).BankNameID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((BankNameEditListModel)EditRecordDataSource).BankNameID);
        }

        private void txtBankName_Validating(object sender, CancelEventArgs e)
        {
            if (txtBankName.Text == "")
            {
                ErrorProvider.SetError(txtBankName, "Can not accept blank BankName name.");
            }
            else if (DALObject.IsDuplicateRecord(txtBankName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((BankNameEditListModel)EditRecordDataSource).BankNameID : 0)))
            {
                ErrorProvider.SetError(txtBankName, "Can not accept duplicate BankName name.");
            }
            else
            {
                ErrorProvider.SetError(txtBankName, "");
            }
        }
    }
}
