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
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmSafariApplicationNoPrefix : Template.frmCRUDTemplate
    {
        SafariApplicationNoPrefixDAL DALObject;

        public frmSafariApplicationNoPrefix()
        {
            InitializeComponent();
            DALObject = new SafariApplicationNoPrefixDAL();
            FirstControl = txtSafariApplicationNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblSafariApplicationNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblSafariApplicationNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((SafariApplicationNoPrefixEditListModel)EditRecordDataSource).SafariApplicationNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.SafariApplicationNoPrefixName = txtSafariApplicationNoPrefixName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblSafariApplicationNoPrefix EditingRecord = DALObject.FindSaveModelByPrimeKey(((SafariApplicationNoPrefixEditListModel)RecordToFill).SafariApplicationNoPrefixID);

            if (EditingRecord == null)
            {
                return;
            }

            txtSafariApplicationNoPrefixName.Text = EditingRecord.SafariApplicationNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((SafariApplicationNoPrefixEditListModel)EditRecordDataSource).SafariApplicationNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((SafariApplicationNoPrefixEditListModel)EditRecordDataSource).SafariApplicationNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((SafariApplicationNoPrefixEditListModel)EditRecordDataSource).SafariApplicationNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((SafariApplicationNoPrefixEditListModel)EditRecordDataSource).SafariApplicationNoPrefixID);
        }

        private void txtSafariApplicationNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (txtSafariApplicationNoPrefixName.Text == "")
            {
                ErrorProvider.SetError(txtSafariApplicationNoPrefixName, "Can not accept blank Safari Type name.");
            }
            else if (DALObject.IsDuplicateRecord(txtSafariApplicationNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((SafariApplicationNoPrefixEditListModel)EditRecordDataSource).SafariApplicationNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtSafariApplicationNoPrefixName, "Can not accept duplicate Safari Type name.");
            }
            else
            {
                ErrorProvider.SetError(txtSafariApplicationNoPrefixName, "");
            }
        }
    }
}