using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.Settings;
using Vision.DAL;
using Vision.Model;

namespace Vision.WinForm.Settings
{
    public partial class frmPayrollMonth : Template.frmNormalTemplate
    {
        PayrollMonthDAL DALObject;

        public frmPayrollMonth()
        {
            InitializeComponent();
            DALObject = new PayrollMonthDAL();
        }

        public void FillValue()
        {
            tblPayrollMonth Record = DALObject.GetLatestPayrollMonthByCompanyID(Vision.Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);

            if (Record != null)
            {
                txtPayrollStartDate.EditValue = Record.PayrollMonthStartDate.ToShortDateString();
                txtPayrollEndDate.EditValue = Record.PayrollMonthEndDate.ToShortDateString();
                txtPreviousMonthName.EditValue = Record.PayrollMonthName;

                txtNextMonthEndDate.EditValue = Record.PayrollMonthEndDate.AddMonths(1).ToShortDateString();
                txtNextMonthStartDate.EditValue = Record.PayrollMonthEndDate.AddDays(1).ToShortDateString();
                txtNextMonthName.EditValue = Record.PayrollMonth.AddMonths(1).ToString("MMMM-yyyy");
                //txtPayrollEndDate.EditValue = Record.PayrollMonthEndDate.AddMonths(1).ToShortDateString();
            }

        }

        public override void LoadFormValues()
        {
            //FillValue();
            base.LoadFormValues();
        }

        public override void AssignFormValues()
        
        {
            FillValue();
            base.AssignFormValues();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {

            DialogResult result= MessageBox.Show("Are you sure? you want to close current payroll month?","Close Payroll month", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes) { 
            tblPayrollMonth SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew)
            {
                SaveModel = new tblPayrollMonth();
            }
            //SaveModel.tblCompany =
            SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                SaveModel.PayrollMonthName = txtNextMonthName.EditValue.ToString();
            SaveModel.PayrollMonth = Convert.ToDateTime(txtNextMonthName.EditValue);
            SaveModel.PayrollMonthEndDate =Convert.ToDateTime(txtNextMonthEndDate.EditValue);
            SaveModel.PayrollMonthStartDate = Convert.ToDateTime(txtNextMonthStartDate.EditValue);
                //SaveModel.rcdt = DateTime.Now;
                //SaveModel.rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
              SavingParemeter SaveResult = new SavingParemeter();
              SaveResult.SavingResult = DALObject.SaveNewRecord(SaveModel);
                AfterSaving(SaveResult);
            }

        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)//i need to set this result from data layer.
            {
                
                MessageBox.Show("New Payroll month was created successfully. Please login again.","Logout",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                Vision.WinForm.Navigation.frmDashBoard.DashBoard.Logout();
            }
            base.AfterSaving(Paras);
        }


    }
}
