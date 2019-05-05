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
    public partial class frmTAApprovalNoPrefix : Template.frmCRUDTemplate
    {
        TAApprovalNoPrefixDAL DALObject;

        public frmTAApprovalNoPrefix()
        {
            InitializeComponent();
            DALObject = new TAApprovalNoPrefixDAL();
            FirstControl = txtTAApprovalNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblTAApprovalNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblTAApprovalNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((TAApprovalNoPrefixEditListModel)EditRecordDataSource).TAApprovalNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.TAApprovalNoPrefixName = txtTAApprovalNoPrefixName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblTAApprovalNoPrefix EditingRecord = DALObject.FindSaveModelByPrimeKey(((TAApprovalNoPrefixEditListModel)RecordToFill).TAApprovalNoPrefixID);

            if (EditingRecord == null)
            {
                return;
            }

            txtTAApprovalNoPrefixName.Text = EditingRecord.TAApprovalNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((TAApprovalNoPrefixEditListModel)EditRecordDataSource).TAApprovalNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((TAApprovalNoPrefixEditListModel)EditRecordDataSource).TAApprovalNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((TAApprovalNoPrefixEditListModel)EditRecordDataSource).TAApprovalNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((TAApprovalNoPrefixEditListModel)EditRecordDataSource).TAApprovalNoPrefixID);
        }

        private void txtTAApprovalNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (txtTAApprovalNoPrefixName.Text == "")
            {
                ErrorProvider.SetError(txtTAApprovalNoPrefixName, "Can not accept blank prefix name.");
            }
            else if (DALObject.IsDuplicateRecord(txtTAApprovalNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((TAApprovalNoPrefixEditListModel)EditRecordDataSource).TAApprovalNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtTAApprovalNoPrefixName, "Can not accept duplicate prefix name.");
            }
            else
            {
                ErrorProvider.SetError(txtTAApprovalNoPrefixName, "");
            }
        }
    }
}