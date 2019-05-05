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
    public partial class frmLeaveAdjustmentNoPrefix : Template.frmCRUDTemplate
    {
        LeaveAdjustmentNoPrefixDAL DALObject;

        public frmLeaveAdjustmentNoPrefix()
        {
            InitializeComponent();
            DALObject = new LeaveAdjustmentNoPrefixDAL();
            FirstControl = txtLeaveAdjustmentNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLeaveAdjustmentNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblLeaveAdjustmentNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LeaveAdjustmentNoPrefixEditListModel)EditRecordDataSource).LeaveAdjustmentNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LeaveAdjustmentNoPrefixName = txtLeaveAdjustmentNoPrefixName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblLeaveAdjustmentNoPrefix EditingRecord = DALObject.FindSaveModelByPrimeKey(((LeaveAdjustmentNoPrefixEditListModel)RecordToFill).LeaveAdjustmentNoPrefixID);

            if (EditingRecord == null)
            {
                return;
            }

            txtLeaveAdjustmentNoPrefixName.Text = EditingRecord.LeaveAdjustmentNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LeaveAdjustmentNoPrefixEditListModel)EditRecordDataSource).LeaveAdjustmentNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LeaveAdjustmentNoPrefixEditListModel)EditRecordDataSource).LeaveAdjustmentNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LeaveAdjustmentNoPrefixEditListModel)EditRecordDataSource).LeaveAdjustmentNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LeaveAdjustmentNoPrefixEditListModel)EditRecordDataSource).LeaveAdjustmentNoPrefixID);
        }

        private void txtLeaveAdjustmentNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLeaveAdjustmentNoPrefixName.Text == "")
            {
                ErrorProvider.SetError(txtLeaveAdjustmentNoPrefixName, "Can not accept blank prefix name.");
            }
            else if (DALObject.IsDuplicateRecord(txtLeaveAdjustmentNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((LeaveAdjustmentNoPrefixEditListModel)EditRecordDataSource).LeaveAdjustmentNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtLeaveAdjustmentNoPrefixName, "Can not accept duplicate prefix name.");
            }
            else
            {
                ErrorProvider.SetError(txtLeaveAdjustmentNoPrefixName, "");
            }
        }
    }
}