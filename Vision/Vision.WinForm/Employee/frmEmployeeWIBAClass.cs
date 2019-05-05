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
    public partial class frmEmployeeWIBAClass : Template.frmCRUDTemplate
    {
        EmployeeWIBAClassDAL DALObject;

        public frmEmployeeWIBAClass()
        {
            InitializeComponent();
            DALObject = new EmployeeWIBAClassDAL();
            FirstControl = txtEmployeeWIBAClassName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeWIBAClass SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeWIBAClass();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EmployeeWIBAClassEditListModel)EditRecordDataSource).EmployeeWIBAClassID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeWIBAClassName = txtEmployeeWIBAClassName.Text;
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
            EmployeeWIBAClassEditListModel EditingRecord = (EmployeeWIBAClassEditListModel)RecordToFill;
            DAL.tblEmployeeWIBAClass SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.EmployeeWIBAClassID);

            if (SaveModel == null) return;

            txtEmployeeWIBAClassName.Text = SaveModel.EmployeeWIBAClassName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EmployeeWIBAClassEditListModel)EditRecordDataSource).EmployeeWIBAClassID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EmployeeWIBAClassEditListModel)EditRecordDataSource).EmployeeWIBAClassID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EmployeeWIBAClassEditListModel)EditRecordDataSource).EmployeeWIBAClassID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EmployeeWIBAClassEditListModel)EditRecordDataSource).EmployeeWIBAClassID);
        }

        private void txtEmployeeWIBAClassName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmployeeWIBAClassName.Text))
            {
                ErrorProvider.SetError(txtEmployeeWIBAClassName, "Can not accept blank Employee WIBAClass Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtEmployeeWIBAClassName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeWIBAClassEditListModel)EditRecordDataSource).EmployeeWIBAClassID : 0)))
            {
                ErrorProvider.SetError(txtEmployeeWIBAClassName, "Can not accept duplicate Employee WIBAClass Name.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeWIBAClassName, "");
            }
        }
    }
}
