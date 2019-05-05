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
    public partial class frmLeaveEncashmentNoPrefix : Template.frmCRUDTemplate
    {
        LeaveEncashmentNoPrefixDAL DALObject;

        public frmLeaveEncashmentNoPrefix()
        {
            InitializeComponent();
            DALObject = new LeaveEncashmentNoPrefixDAL();
            FirstControl = txtLeaveEncashmentNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLeaveEncashmentNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblLeaveEncashmentNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LeaveEncashmentNoPrefixEditListModel)EditRecordDataSource).LeaveEncashmentNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LeaveEncashmentNoPrefixName = txtLeaveEncashmentNoPrefixName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblLeaveEncashmentNoPrefix EditingRecord = DALObject.FindSaveModelByPrimeKey(((LeaveEncashmentNoPrefixEditListModel)RecordToFill).LeaveEncashmentNoPrefixID);

            if (EditingRecord == null)
            {
                return;
            }

            txtLeaveEncashmentNoPrefixName.Text = EditingRecord.LeaveEncashmentNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LeaveEncashmentNoPrefixEditListModel)EditRecordDataSource).LeaveEncashmentNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LeaveEncashmentNoPrefixEditListModel)EditRecordDataSource).LeaveEncashmentNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LeaveEncashmentNoPrefixEditListModel)EditRecordDataSource).LeaveEncashmentNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LeaveEncashmentNoPrefixEditListModel)EditRecordDataSource).LeaveEncashmentNoPrefixID);
        }

        private void txtLeaveEncashmentNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLeaveEncashmentNoPrefixName.Text == "")
            {
                ErrorProvider.SetError(txtLeaveEncashmentNoPrefixName, "Can not accept blank prefix name.");
            }
            else if (DALObject.IsDuplicateRecord(txtLeaveEncashmentNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((LeaveEncashmentNoPrefixEditListModel)EditRecordDataSource).LeaveEncashmentNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtLeaveEncashmentNoPrefixName, "Can not accept duplicate prefix name.");
            }
            else
            {
                ErrorProvider.SetError(txtLeaveEncashmentNoPrefixName, "");
            }
        }
    }
}