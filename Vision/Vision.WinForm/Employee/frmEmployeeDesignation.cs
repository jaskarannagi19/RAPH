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
    public partial class frmEmployeeDesignation : Template.frmCRUDTemplate
    {
        EmployeeDesignationDAL DALObject;

        public frmEmployeeDesignation()
        {
            InitializeComponent();
            DALObject = new EmployeeDesignationDAL();
            FirstControl = txtEmployeeDesignationName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeDesignation SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeDesignation();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EmployeeDesignationEditListModel)EditRecordDataSource).EmployeeDesignationID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeDesignationName = txtEmployeeDesignationName.Text;
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
            EmployeeDesignationEditListModel EditingRecord = (EmployeeDesignationEditListModel)RecordToFill;
            DAL.tblEmployeeDesignation SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.EmployeeDesignationID);

            if (SaveModel == null) return;

            txtEmployeeDesignationName.Text = SaveModel.EmployeeDesignationName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EmployeeDesignationEditListModel)EditRecordDataSource).EmployeeDesignationID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EmployeeDesignationEditListModel)EditRecordDataSource).EmployeeDesignationID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EmployeeDesignationEditListModel)EditRecordDataSource).EmployeeDesignationID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EmployeeDesignationEditListModel)EditRecordDataSource).EmployeeDesignationID);
        }

        private void txtEmployeeDesignationName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmployeeDesignationName.Text))
            {
                ErrorProvider.SetError(txtEmployeeDesignationName, "Can not accept blank Employee Designation Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtEmployeeDesignationName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeDesignationEditListModel)EditRecordDataSource).EmployeeDesignationID : 0)))
            {
                ErrorProvider.SetError(txtEmployeeDesignationName, "Can not accept duplicate Employee Designation Name.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeDesignationName, "");
            }
        }
    }
}
