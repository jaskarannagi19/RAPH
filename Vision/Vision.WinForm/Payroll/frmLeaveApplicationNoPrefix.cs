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
    public partial class frmLeaveApplicationNoPrefix : Template.frmCRUDTemplate
    {
        LeaveApplicationNoPrefixDAL DALObject;

        public frmLeaveApplicationNoPrefix()
        {
            InitializeComponent();
            DALObject = new LeaveApplicationNoPrefixDAL();
            FirstControl = txtLeaveApplicationNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLeaveApplicationNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblLeaveApplicationNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LeaveApplicationNoPrefixEditListModel)EditRecordDataSource).LeaveApplicationNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LeaveApplicationNoPrefixName = txtLeaveApplicationNoPrefixName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblLeaveApplicationNoPrefix EditingRecord = DALObject.FindSaveModelByPrimeKey(((LeaveApplicationNoPrefixEditListModel)RecordToFill).LeaveApplicationNoPrefixID);

            if (EditingRecord == null)
            {
                return;
            }

            txtLeaveApplicationNoPrefixName.Text = EditingRecord.LeaveApplicationNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LeaveApplicationNoPrefixEditListModel)EditRecordDataSource).LeaveApplicationNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LeaveApplicationNoPrefixEditListModel)EditRecordDataSource).LeaveApplicationNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LeaveApplicationNoPrefixEditListModel)EditRecordDataSource).LeaveApplicationNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LeaveApplicationNoPrefixEditListModel)EditRecordDataSource).LeaveApplicationNoPrefixID);
        }

        private void txtLeaveApplicationNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLeaveApplicationNoPrefixName.Text == "")
            {
                ErrorProvider.SetError(txtLeaveApplicationNoPrefixName, "Can not accept blank prefix name.");
            }
            else if (DALObject.IsDuplicateRecord(txtLeaveApplicationNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((LeaveApplicationNoPrefixEditListModel)EditRecordDataSource).LeaveApplicationNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtLeaveApplicationNoPrefixName, "Can not accept duplicate prefix name.");
            }
            else
            {
                ErrorProvider.SetError(txtLeaveApplicationNoPrefixName, "");
            }
        }
    }
}