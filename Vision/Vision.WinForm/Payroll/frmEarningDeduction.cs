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
    public partial class frmEarningDeduction : Template.frmCRUDTemplate
    {
        EarningDeductionDAL DALObject;

        public frmEarningDeduction()
        {
            InitializeComponent();
            DALObject = new EarningDeductionDAL();
            FirstControl = txtEarningDeductionName;
        }

        public override void InitializeDefaultValues()
        {
            cmbEarningDeductionType.SelectedIndex = 0;
            cmbValueType.SelectedIndex = 0;
            cmbTaxable.SelectedIndex = 0;
            cmbRecurring.SelectedIndex = 0;

            txtEarningDeductionNo.EditValue = DALObject.GenerateNo((eEarningDeductionType)cmbEarningDeductionType.SelectedIndex);

            base.InitializeDefaultValues();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeEarningDeduction SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeEarningDeduction();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EarningDeductionEditListModel)EditRecordDataSource).EmployeeEarningDeductionID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeEarningDeductionNo = (int)txtEarningDeductionNo.EditValue;
            SaveModel.EmployeeEarningDeductionName = txtEarningDeductionName.Text;
            SaveModel.EarningDeductionType = (byte)cmbEarningDeductionType.SelectedIndex;
            SaveModel.Taxable = (cmbTaxable.SelectedIndex == 1);
            SaveModel.Recurring = (cmbRecurring.SelectedIndex == 1);
            SaveModel.ValueType = (byte)cmbValueType.SelectedIndex;
            SaveModel.Remarks = txtRemarks.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblEmployeeEarningDeduction EditingRecord = DALObject.FindSaveModelByPrimeKey(((EarningDeductionEditListModel)RecordToFill).EmployeeEarningDeductionID);

            if (EditingRecord == null)
            {
                return;
            }

            cmbEarningDeductionType.SelectedIndex = (int)EditingRecord.EarningDeductionType;
            txtEarningDeductionNo.EditValue = EditingRecord.EmployeeEarningDeductionNo;
            txtEarningDeductionName.Text = EditingRecord.EmployeeEarningDeductionName;
            cmbTaxable.SelectedIndex = (EditingRecord.Taxable ? 1 : 0);
            cmbRecurring.SelectedIndex = (EditingRecord.Recurring ? 1 : 0);
            cmbValueType.SelectedIndex = (int)EditingRecord.ValueType;
            txtRemarks.Text = EditingRecord.Remarks;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EarningDeductionEditListModel)EditRecordDataSource).EmployeeEarningDeductionID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EarningDeductionEditListModel)EditRecordDataSource).EmployeeEarningDeductionID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EarningDeductionEditListModel)EditRecordDataSource).EmployeeEarningDeductionID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EarningDeductionEditListModel)EditRecordDataSource).EmployeeEarningDeductionID);
        }

        private void txtEarningDeductionName_Validating(object sender, CancelEventArgs e)
        {
            if (txtEarningDeductionName.Text == "")
            {
                ErrorProvider.SetError(txtEarningDeductionName, "Can not accept blank Earning & Deduction name.");
            }
            else if (DALObject.IsDuplicateRecord(txtEarningDeductionName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((EarningDeductionEditListModel)EditRecordDataSource).EmployeeEarningDeductionID : 0)))
            {
                ErrorProvider.SetError(txtEarningDeductionName, "Can not accept duplicate Earning & Deduction name.");
            }
            else
            {
                ErrorProvider.SetError(txtEarningDeductionName, "");
            }
        }

        public override Size GetLargestControlSize()
        {
            return (txtEarningDeductionName == null ? Size.Empty : txtEarningDeductionName.Size);
        }

        private void cmbEarningDeductionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((eEarningDeductionType)cmbEarningDeductionType.SelectedIndex) == eEarningDeductionType.Earning)
            {
                lciName.Text = "Earning Name";
                lciNo.Text = "Earning No.";
            }
            else
            {
                lciName.Text = "Deduction Name";
                lciNo.Text = "Deduction No.";
            }
            txtEarningDeductionNo.EditValue = DALObject.GenerateNo((eEarningDeductionType)cmbEarningDeductionType.SelectedIndex);
        }

        private void txtEarningDeductionNo_Validating(object sender, CancelEventArgs e)
        {
            if(txtEarningDeductionNo.EditValue == null || (int)txtEarningDeductionNo.EditValue == 0)
            {
                ErrorProvider.SetError(txtEarningDeductionNo, "Please enter number.");
            }
            else if(DALObject.IsDuplicateNo((int)txtEarningDeductionNo.EditValue, ( FormCurrentUI == eFormCurrentUI.Edit && EditRecordDataSource != null ? ((EarningDeductionEditListModel)EditRecordDataSource).EmployeeEarningDeductionID : 0)))
            {
                ErrorProvider.SetError(txtEarningDeductionNo, "Duplicate number not accepted.");
            }
            else
            {
                ErrorProvider.SetError(txtEarningDeductionNo, null);
            }
        }
    }
}
