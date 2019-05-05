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
    public partial class frmMinimumWageCategory : Template.frmCRUDTemplate
    {
        MinimumWageCategoryDAL DALObject;

        public frmMinimumWageCategory()
        {
            InitializeComponent();
            DALObject = new MinimumWageCategoryDAL();
            FirstControl = txtMinimumWageCategoryName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblMinimumWageCategory SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblMinimumWageCategory();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((MinimumWageCategoryEditListModel)EditRecordDataSource).MinimumWageCategoryID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.MinimumWageCategoryName = txtMinimumWageCategoryName.Text;
            SaveModel.ApplyOn = (byte)cmbApplyOn.SelectedIndex;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            int MinimumWageCategoryID = ((MinimumWageCategoryEditListModel)RecordToFill).MinimumWageCategoryID;
            tblMinimumWageCategory EditingRecord = DALObject.FindSaveModelByPrimeKey(MinimumWageCategoryID);

            if (EditingRecord == null)
            {
                return;
            }

            txtMinimumWageCategoryName.Text = EditingRecord.MinimumWageCategoryName;
            cmbApplyOn.SelectedIndex = EditingRecord.ApplyOn;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((MinimumWageCategoryEditListModel)EditRecordDataSource).MinimumWageCategoryID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((MinimumWageCategoryEditListModel)EditRecordDataSource).MinimumWageCategoryID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((MinimumWageCategoryEditListModel)EditRecordDataSource).MinimumWageCategoryID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((MinimumWageCategoryEditListModel)EditRecordDataSource).MinimumWageCategoryID);
        }

        private void txtMinimumWageCategoryName_Validating(object sender, CancelEventArgs e)
        {
            if (txtMinimumWageCategoryName.Text == "")
            {
                ErrorProvider.SetError(txtMinimumWageCategoryName, "Can not accept blank name.");
            }
            else if (DALObject.IsDuplicateRecord(txtMinimumWageCategoryName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((MinimumWageCategoryEditListModel)EditRecordDataSource).MinimumWageCategoryID : 0)))
            {
                ErrorProvider.SetError(txtMinimumWageCategoryName, "Can not accept duplicate name.");
            }
            else
            {
                ErrorProvider.SetError(txtMinimumWageCategoryName, "");
            }
        }

        private void cmbApplyOn_Validating(object sender, CancelEventArgs e)
        {
            if(cmbApplyOn.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbApplyOn, "Please select Apply on");
            }
            else
            {
                ErrorProvider.SetError(cmbApplyOn, "");
            }
        }
    }
}
