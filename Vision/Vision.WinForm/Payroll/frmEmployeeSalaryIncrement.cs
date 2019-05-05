using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vision.DAL.Payroll;
using Vision.DAL;
using Vision.DAL.Employee;
using Vision.Model.Employee;
using Vision.Model;
using Vision.Model.Payroll;
using System.Data.SqlClient;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;

namespace Vision.WinForm.Payroll
{
    public partial class frmEmployeeSalaryIncrement : Template.frmCRUDTemplate
    {
        #region Fields
        Int32 EmployeeSalaryIncrementID;
        EmployeeSalaryIncrementDAL DALObj;
        EmployeeDAL EmployeeDALObj;
        List<EmployeeLookupListModel> dsEmployee;

        DateTime DateFrom { get; set; }
        DateTime DateTo { get; set; }
        #endregion

        #region Initialize Default Values
        public override void InitializeDefaultValues()
        {
            cmbIncrementType.SelectedIndex = 0;
            txtIncrementPercentage.EditValue = 0M;
            txtLastIncAmount.EditValue = 0M;
            txtCurrentBasicSalary.EditValue = 0M;
            txtIncrementAmount.EditValue = 0M;
            txtNewBasicSalary.EditValue = 0M;
            dtpEffectiveMonth.EditValue = DateTime.Now.ToString("MMMM-yyyy");
            dtpTransectionDate.EditValue = DateTime.Now.ToString("dd-MM-yyyy");
            txtTransectionNo.EditValue = DALObj.AutoGen();
            base.InitializeDefaultValues();
        }

        public override void FormatEditListGridView(GridView EditListGrid)
        {
            EditListGrid.Columns["EffectiveYear"].GroupIndex = 0;
            EditListGrid.Columns["EffectiveMonth"].GroupIndex = 1;
            EditListGrid.Columns["EmployeeName"].MaxWidth = 250;
            base.FormatEditListGridView(EditListGrid);
        }
        #endregion

        #region Load Lookup Data Source
        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();
            base.LoadLookupDataSource();
        }
        #endregion

        #region Assign Lookup Data Source
        public override void AssignLookupDataSource()
        {
            txtEmployee.Properties.ValueMember = "EmployeeID";
            txtEmployee.Properties.DisplayMember = "EmployeeName";
            txtEmployee.Properties.DataSource = dsEmployee;
            txtRemarks.Properties.MaxLength = 100;
            base.AssignLookupDataSource();
        }
        #endregion

        #region Constractor
        public frmEmployeeSalaryIncrement()
        {
            InitializeComponent();
            DALObj = new EmployeeSalaryIncrementDAL();
            EmployeeDALObj = new EmployeeDAL();
            FirstControl = dtpEffectiveMonth;

            DateTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1).Add(new TimeSpan(23, 59, 59));
            DateFrom = new DateTime(DateTo.Year, DateTo.Month, 1);
            dtpEffectiveMonth.Text = DateFrom.ToString("MMMM-yyyy");
        }
        #endregion

        #region Validating
        private void txtEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmployee.EditValue == null)
            {
                ErrorProvider.SetError(txtEmployee, "Please select employee");
            }
            else if (dtpTransectionDate.EditValue != null && DALObj.IsDuplicateIncremetnRecord(Convert.ToDateTime((dtpTransectionDate.EditValue).ToString()), Convert.ToInt32(txtEmployee.EditValue), EmployeeSalaryIncrementID))
            {
                ErrorProvider.SetError(dtpTransectionDate, "Can not accept duplicate Employee No. with in same month.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployee, "");
            }
        }

        private void txtIncrementAmount_Validating(object sender, CancelEventArgs e)
        {
            if (txtIncrementAmount.EditValue == null)
            {
                ErrorProvider.SetError(txtIncrementAmount, "Please insert increment amount");
            }
            else
            {
                ErrorProvider.SetError(txtIncrementAmount, "");
            }
        }

        private void txtTransectionNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtTransectionNo.EditValue == null)
            {
                ErrorProvider.SetError(txtTransectionNo, "Please insert transaction no.");
            }
            else if (DALObj.IsDuplicateRecord(Convert.ToInt32(txtTransectionNo.EditValue), EmployeeSalaryIncrementID))
            {
                ErrorProvider.SetError(txtTransectionNo, "Can not accept duplicate Increament No.");
            }
            else
            {
                ErrorProvider.SetError(txtTransectionNo, "");
            }
        }

        private void dtpTransectionDate_Validating(object sender, CancelEventArgs e)
        {
            if (dtpTransectionDate.EditValue == null)
            {
                ErrorProvider.SetError(dtpTransectionDate, "Please select transaction date");
            }
            else
            {
                ErrorProvider.SetError(dtpTransectionDate, "");
            }
        }

        private void dtpEffectiveMonth_Validating(object sender, CancelEventArgs e)
        {
            if (dtpEffectiveMonth.EditValue == null)
            {
                ErrorProvider.SetError(dtpEffectiveMonth, "Please select effective month");
            }
            else
            {
                ErrorProvider.SetError(dtpEffectiveMonth, "");
            }
        }
        #endregion

        #region Fill Selected Record InContent
        public override void FillSelectedRecordInContent(object RecordToFill)
        {            
            EmployeeSalaryIncrementID = ((EmployeeSalaryIncrementEditListModel)RecordToFill).EmployeeSalaryIncrementID;
            tblEmployeeSalaryIncrement SaveModel = DALObj.FindSaveModelByPrimeKey(EmployeeSalaryIncrementID);
            if (SaveModel == null)
            {
                return;
            }

            txtEmployee.EditValue = SaveModel.EmployeeID;
            txtTransectionNo.EditValue = SaveModel.EmployeeSalaryIncrementNo;
            txtCurrentBasicSalary.EditValue = SaveModel.CurrentBasicSalary;
            cmbIncrementType.SelectedIndex = SaveModel.IncrementType;
            txtIncrementAmount.EditValue = SaveModel.IncrementAmount;
            txtIncrementPercentage.EditValue = SaveModel.IncrementPercentage;
            dtpTransectionDate.EditValue = SaveModel.EmployeeSalaryIncrementDate;
            dtpEffectiveMonth.EditValue = DateFrom.ToString("MMMM-yyyy");
            txtNewBasicSalary.EditValue = SaveModel.NewBasicSalary;
            txtLastIncAmount.EditValue = SaveModel.LastIncAmount;
            dtpLastIncDate.Text = SaveModel.LastIncDate == null ? "" : SaveModel.LastIncDate.Value.ToString("dd-MM-yyyy");
            txtRemarks.EditValue = SaveModel.Remarks;
            base.FillSelectedRecordInContent(RecordToFill);
        }
        #endregion

        #region Get Edit List DataSource
        public override object GetEditListDataSource()
        {   
            return DALObj.GetEmployeeList();
        }
        #endregion

        #region Save Records
        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeSalaryIncrement SaveModel = null;
            int EmployeeID = (int)txtEmployee.EditValue;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeSalaryIncrement();
            }
            else
            {
                SaveModel = DALObj.FindSaveModelByPrimeKey(((EmployeeSalaryIncrementEditListModel)EditRecordDataSource).EmployeeSalaryIncrementID);
                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }
            if (Model.CommonFunctions.ParseDecimal(txtIncrementAmount.Text) > 0)
            {
                SaveModel.EmployeeID = EmployeeID;
                SaveModel.LastIncAmount = Model.CommonFunctions.ParseDecimal(txtLastIncAmount.Text) > 0 ? Model.CommonFunctions.ParseDecimal(txtLastIncAmount.Text) : (decimal?)null;
                SaveModel.LastIncDate = !string.IsNullOrEmpty(dtpLastIncDate.Text) ? dtpLastIncDate.DateTime : (DateTime?)null;
                SaveModel.EffectiveMonth = dtpEffectiveMonth.DateTime.Month;
                SaveModel.EffectiveYear = dtpEffectiveMonth.DateTime.Year;
                SaveModel.CurrentBasicSalary = Model.CommonFunctions.ParseDecimal(txtCurrentBasicSalary.Text);
                SaveModel.IncrementType = (int)cmbIncrementType.SelectedIndex;
                SaveModel.IncrementPercentage = (decimal)txtIncrementPercentage.EditValue;
                SaveModel.EmployeeSalaryIncrementNo = Convert.ToInt32(txtTransectionNo.Text);
                SaveModel.EmployeeSalaryIncrementDate = dtpTransectionDate.DateTime;
                SaveModel.IncrementAmount = Model.CommonFunctions.ParseDecimal(txtIncrementAmount.Text);
                SaveModel.NewBasicSalary = Model.CommonFunctions.ParseDecimal(txtNewBasicSalary.Text);
                SaveModel.Remarks = txtRemarks.Text;
                Paras.SavingResult = DALObj.SaveNewRecord(SaveModel);
                base.SaveRecord(Paras);
            }
            else
            {
                Paras.SavingResult = new SavingResult();
                Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                Paras.SavingResult.ValidationError = "Increment Amount should be greater then Zero.";
                return;
            }
        }
        #endregion

        #region Selected Index Change Event
        private void cmbIncrementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((eEmployeeSalaryIncrementType)cmbIncrementType.SelectedIndex) == eEmployeeSalaryIncrementType.Percentage)
            {
                txtIncrementPercentage.Enabled = true;
                txtIncrementAmount.Enabled = false;
                txtIncrementAmount.Text = "";
                txtIncrementPercentage.Properties.Mask.EditMask = "p4";
            }
            else
            {
                dbVisionEntities db = new dbVisionEntities();
                txtIncrementPercentage.Enabled = false;
                txtIncrementAmount.Enabled = true;
                txtIncrementAmount.Properties.Mask.EditMask = "n2";
            }
        }
        #endregion

        #region Edit Value Change
        private void txtEmployee_EditValueChanged(object sender, EventArgs e)
        {
            if (txtEmployee.EditValue != null)
            {
                var employeeDetail = DALObj.GetEmployeeDetail((int)txtEmployee.EditValue);
                if (employeeDetail != null)
                {
                    dtpLastIncDate.EditValue = employeeDetail.LastIncDate;
                    txtLastIncAmount.EditValue = employeeDetail.LastIncAmount;
                    txtCurrentBasicSalary.EditValue = employeeDetail.CurrentBasicSalary;
                }
            }
        }

        private void txtIncrementAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtNewBasicSalary.EditValue = Convert.ToDecimal(txtCurrentBasicSalary.EditValue) + Convert.ToDecimal(txtIncrementAmount.EditValue);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void txtIncrementPercentage_EditValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                decimal Current = Convert.ToDecimal(txtCurrentBasicSalary.EditValue == null ? 0 : txtCurrentBasicSalary.EditValue);
                decimal Percentage = Convert.ToDecimal(txtIncrementPercentage.EditValue == null ? 0 : txtIncrementPercentage.EditValue);
                decimal IncrementAmount = Current * (Percentage == 0 ? 1 : Percentage);
                decimal Total = Current + IncrementAmount;
                txtIncrementAmount.EditValue = IncrementAmount;
                txtNewBasicSalary.EditValue = Total;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion

        #region Authorize
        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObj.Authorize(((EmployeeSalaryIncrementEditListModel)EditRecordDataSource).EmployeeSalaryIncrementID);
        }
        #endregion

        #region UnAuthorize
        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObj.UnAuthorize(((EmployeeSalaryIncrementEditListModel)EditRecordDataSource).EmployeeSalaryIncrementID);
        }
        #endregion

        #region Delete Record
        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObj.ValidateBeforeDelete(((EmployeeSalaryIncrementEditListModel)EditRecordDataSource).EmployeeSalaryIncrementID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObj.DeleteRecord(((EmployeeSalaryIncrementEditListModel)EditRecordDataSource).EmployeeSalaryIncrementID);
            base.DeleteRecord(Paras);
        }
        #endregion        
    }
}
