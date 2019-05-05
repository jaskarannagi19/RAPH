using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.Employee;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.WinForm.Employee
{
    public partial class frmEmployeeAccountingLedger : Template.frmCRUDTemplate
    {
        EmployeeAccountingLedgerDAL DALObject;

        public frmEmployeeAccountingLedger()
        {
            InitializeComponent();
            DALObject = new EmployeeAccountingLedgerDAL();

            FirstControl = txtEmployeeAccountingLedgerName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeAccountingLedger SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeAccountingLedger();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EmployeeAccountingLedgerEditListModel)EditRecordDataSource).EmployeeAccountingLedgerID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeAccountingLedgerName = txtEmployeeAccountingLedgerName.Text;
            //SaveModel.ISDCode = txtISDCode.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            EmployeeAccountingLedgerEditListModel EditingRecord = (EmployeeAccountingLedgerEditListModel)RecordToFill;
            DAL.tblEmployeeAccountingLedger SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.EmployeeAccountingLedgerID);

            if (SaveModel == null) return;

            txtEmployeeAccountingLedgerName.Text = SaveModel.EmployeeAccountingLedgerName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EmployeeAccountingLedgerEditListModel)EditRecordDataSource).EmployeeAccountingLedgerID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EmployeeAccountingLedgerEditListModel)EditRecordDataSource).EmployeeAccountingLedgerID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EmployeeAccountingLedgerEditListModel)EditRecordDataSource).EmployeeAccountingLedgerID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EmployeeAccountingLedgerEditListModel)EditRecordDataSource).EmployeeAccountingLedgerID);
        }

        private void txtEmployeeAccountingLedgerName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmployeeAccountingLedgerName.Text))
            {
                ErrorProvider.SetError(txtEmployeeAccountingLedgerName, "Can not accept blank Employee Department Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtEmployeeAccountingLedgerName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeAccountingLedgerEditListModel)EditRecordDataSource).EmployeeAccountingLedgerID : 0)))
            {
                ErrorProvider.SetError(txtEmployeeAccountingLedgerName, "Can not accept duplicate Employee Department Name.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeAccountingLedgerName, "");
            }
        }
    }
}
