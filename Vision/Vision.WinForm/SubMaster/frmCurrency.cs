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
    public partial class frmCurrency : Template.frmCRUDTemplate
    {
        CurrencyDAL DALObject;

        public frmCurrency()
        {
            InitializeComponent();
            DALObject = new CurrencyDAL();
            FirstControl = txtCurrencyName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblCurrency SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblCurrency();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((CurrencyEditListModel)EditRecordDataSource).CurrencyID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.CurrencyName = txtCurrencyName.Text;
            SaveModel.CurrencySymbole = txtSymbole.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            CurrencyEditListModel EditingRecord = (CurrencyEditListModel)RecordToFill;

            txtCurrencyName.Text = EditingRecord.CurrencyName;
            txtSymbole.Text = EditingRecord.CurrencySymbole;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((CurrencyEditListModel)EditRecordDataSource).CurrencyID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((CurrencyEditListModel)EditRecordDataSource).CurrencyID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((CurrencyEditListModel)EditRecordDataSource).CurrencyID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((CurrencyEditListModel)EditRecordDataSource).CurrencyID);
        }

        private void txtCurrencyName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrencyName.Text == "")
            {
                ErrorProvider.SetError(txtCurrencyName, "Can not accept blank Currency name.");
            }
            else if (DALObject.IsDuplicateRecord(txtCurrencyName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((CurrencyEditListModel)EditRecordDataSource).CurrencyID : 0)))
            {
                ErrorProvider.SetError(txtCurrencyName, "Can not accept duplicate Currency name.");
            }
            else
            {
                ErrorProvider.SetError(txtCurrencyName, "");
            }
        }
    }
}
