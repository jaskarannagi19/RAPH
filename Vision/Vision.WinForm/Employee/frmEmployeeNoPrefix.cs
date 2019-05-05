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
    public partial class frmEmployeeNoPrefix : Template.frmCRUDTemplate
    {
        EmployeeNoPrefixDAL DALObject;

        public frmEmployeeNoPrefix()
        {
            InitializeComponent();
            DALObject = new EmployeeNoPrefixDAL();
            FirstControl = txtEmployeeNoPrefixName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeNoPrefix SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeNoPrefix();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EmployeeNoPrefixEditListModel)EditRecordDataSource).EmployeeNoPrefixID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeNoPrefixName = txtEmployeeNoPrefixName.Text;
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
            EmployeeNoPrefixEditListModel EditingRecord = (EmployeeNoPrefixEditListModel)RecordToFill;
            DAL.tblEmployeeNoPrefix SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.EmployeeNoPrefixID);

            if (SaveModel == null) return;

            txtEmployeeNoPrefixName.Text = SaveModel.EmployeeNoPrefixName;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EmployeeNoPrefixEditListModel)EditRecordDataSource).EmployeeNoPrefixID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EmployeeNoPrefixEditListModel)EditRecordDataSource).EmployeeNoPrefixID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EmployeeNoPrefixEditListModel)EditRecordDataSource).EmployeeNoPrefixID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EmployeeNoPrefixEditListModel)EditRecordDataSource).EmployeeNoPrefixID);
        }

        private void txtEmployeeNoPrefixName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmployeeNoPrefixName.Text))
            {
                ErrorProvider.SetError(txtEmployeeNoPrefixName, "Can not accept blank Employee No Prefix Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtEmployeeNoPrefixName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeNoPrefixEditListModel)EditRecordDataSource).EmployeeNoPrefixID : 0)))
            {
                ErrorProvider.SetError(txtEmployeeNoPrefixName, "Can not accept duplicate Employee No Prefix Name.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeNoPrefixName, "");
            }
        }
    }
}
