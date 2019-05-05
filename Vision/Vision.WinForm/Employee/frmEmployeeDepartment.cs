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
    public partial class frmEmployeeDepartment : Template.frmCRUDTemplate
    {
        EmployeeDepartmentDAL DALObject;

        public frmEmployeeDepartment()
        {
            InitializeComponent();
            DALObject = new EmployeeDepartmentDAL();
            FirstControl = txtEmployeeDepartmentName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeDepartment SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeDepartment();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EmployeeDepartmentEditListModel)EditRecordDataSource).EmployeeDepartmentID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeDepartmentName = txtEmployeeDepartmentName.Text;
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
            EmployeeDepartmentEditListModel EditingRecord = (EmployeeDepartmentEditListModel)RecordToFill;
            DAL.tblEmployeeDepartment SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.EmployeeDepartmentID);

            if (SaveModel == null) return;

            txtEmployeeDepartmentName.Text = SaveModel.EmployeeDepartmentName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EmployeeDepartmentEditListModel)EditRecordDataSource).EmployeeDepartmentID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EmployeeDepartmentEditListModel)EditRecordDataSource).EmployeeDepartmentID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EmployeeDepartmentEditListModel)EditRecordDataSource).EmployeeDepartmentID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EmployeeDepartmentEditListModel)EditRecordDataSource).EmployeeDepartmentID);
        }

        private void txtEmployeeDepartmentName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmployeeDepartmentName.Text))
            {
                ErrorProvider.SetError(txtEmployeeDepartmentName, "Can not accept blank Employee Department Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtEmployeeDepartmentName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeDepartmentEditListModel)EditRecordDataSource).EmployeeDepartmentID : 0)))
            {
                ErrorProvider.SetError(txtEmployeeDepartmentName, "Can not accept duplicate Employee Department Name.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeDepartmentName, "");
            }
        }
    }
}
