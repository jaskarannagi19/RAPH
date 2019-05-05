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
    public partial class frmLoanApplicationNoPrefix : Template.frmCRUDTemplate
    {
        LoanApplicationNoPrefixDAL DALObject;

        public frmLoanApplicationNoPrefix()
        {
            InitializeComponent();
            DALObject = new LoanApplicationNoPrefixDAL();
            FirstControl = txtLoanApplicationNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLoanApplicationNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblLoanApplicationNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LoanApplicationNoPrefixEditListModel)EditRecordDataSource).LoanApplicationNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LoanApplicationNoPrefixName = txtLoanApplicationNoPrefixName.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblLoanApplicationNoPrefix EditingRecord = DALObject.FindSaveModelByPrimeKey(((LoanApplicationNoPrefixEditListModel)RecordToFill).LoanApplicationNoPrefixID);

            if (EditingRecord == null)
            {
                return;
            }

            txtLoanApplicationNoPrefixName.Text = EditingRecord.LoanApplicationNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LoanApplicationNoPrefixEditListModel)EditRecordDataSource).LoanApplicationNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LoanApplicationNoPrefixEditListModel)EditRecordDataSource).LoanApplicationNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LoanApplicationNoPrefixEditListModel)EditRecordDataSource).LoanApplicationNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LoanApplicationNoPrefixEditListModel)EditRecordDataSource).LoanApplicationNoPrefixID);
        }

        private void txtLoanApplicationNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLoanApplicationNoPrefixName.Text == "")
            {
                ErrorProvider.SetError(txtLoanApplicationNoPrefixName, "Can not accept blank prefix name.");
            }
            else if (DALObject.IsDuplicateRecord(txtLoanApplicationNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((LoanApplicationNoPrefixEditListModel)EditRecordDataSource).LoanApplicationNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtLoanApplicationNoPrefixName, "Can not accept duplicate prefix name.");
            }
            else
            {
                ErrorProvider.SetError(txtLoanApplicationNoPrefixName, "");
            }
        }
    }
}