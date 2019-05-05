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
using Vision.DAL.Loan;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Loan;
using Vision.Model.Payroll;

namespace Vision.WinForm.Loan
{
    public partial class frmLoanAdjustmentNoPrefix : Template.frmCRUDTemplate
    {
        LoanAdjustmentNoPrefixDAL DALObject;

        public frmLoanAdjustmentNoPrefix()
        {
            InitializeComponent();
            DALObject = new LoanAdjustmentNoPrefixDAL();
            FirstControl = txtLoanAdjustmentNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLoanAdjustmentNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblLoanAdjustmentNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LoanAdjustmentNoPrefixEditListModel)EditRecordDataSource).LoanAdjustmentNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LoanAdjustmentNoPrefixName = txtLoanAdjustmentNoPrefixName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblLoanAdjustmentNoPrefix EditingRecord = DALObject.FindSaveModelByPrimeKey(((LoanAdjustmentNoPrefixEditListModel)RecordToFill).LoanAdjustmentNoPrefixID);

            if (EditingRecord == null)
            {
                return;
            }

            txtLoanAdjustmentNoPrefixName.Text = EditingRecord.LoanAdjustmentNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LoanAdjustmentNoPrefixEditListModel)EditRecordDataSource).LoanAdjustmentNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LoanAdjustmentNoPrefixEditListModel)EditRecordDataSource).LoanAdjustmentNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LoanAdjustmentNoPrefixEditListModel)EditRecordDataSource).LoanAdjustmentNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LoanAdjustmentNoPrefixEditListModel)EditRecordDataSource).LoanAdjustmentNoPrefixID);
        }

        private void txtLoanAdjustmentNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLoanAdjustmentNoPrefixName.Text == "")
            {
                ErrorProvider.SetError(txtLoanAdjustmentNoPrefixName, "Can not accept blank prefix name.");
            }
            else if (DALObject.IsDuplicateRecord(txtLoanAdjustmentNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((LoanAdjustmentNoPrefixEditListModel)EditRecordDataSource).LoanAdjustmentNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtLoanAdjustmentNoPrefixName, "Can not accept duplicate prefix name.");
            }
            else
            {
                ErrorProvider.SetError(txtLoanAdjustmentNoPrefixName, "");
            }
        }
    }
}
