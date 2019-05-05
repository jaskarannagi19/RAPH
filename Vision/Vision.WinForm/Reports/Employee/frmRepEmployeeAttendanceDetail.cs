using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.WinForm.Reports.Employee
{
    public partial class frmRepEmployeeAttendanceDetail : Vision.WinForm.Template.frmNormalTemplate
    {
        DAL.Reports.Employee.EmployeeAttendanceDetailReportDAL ReportDALObj;
        DAL.Employee.EmployeeDAL EmployeeDALObj;
        List<Model.Employee.EmployeeLookupListModel> dsEmployee;

        bool FormLoading;
        public frmRepEmployeeAttendanceDetail()
        {
            FormLoading = true;
            InitializeComponent();

            EmployeeDALObj = new DAL.Employee.EmployeeDAL();
            ReportDALObj = new DAL.Reports.Employee.EmployeeAttendanceDetailReportDAL();

            DateTime DateTo = DateTime.Now.Date;
            DateTime DateFrom = (DateTo.DayOfWeek == DayOfWeek.Sunday ? DateTo : DateTo.AddDays(1-(int)DateTo.DayOfWeek));

            dtpDateFrom.DateTime = (DateTime.Now.Date < Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom ?
                Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom : DateTime.Now.Date);
            dtpDateTo.DateTime = (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo != null
                && DateTime.Now.Date > Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date ?
                Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.Date : DateTime.Now.Date);

            FirstControl = lookupEmployee;
        }

        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsEmployee.Insert(0, new Model.Employee.EmployeeLookupListModel() { EmployeeID = -1, FirstName = "(All)" });
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DataSource = dsEmployee;
            lookupEmployee.EditValue = -1;

            base.AssignLookupDataSource();
        }

        public override void AssignFormValues()
        {
            FormLoading = false;
            FillData();
            base.AssignFormValues();
        }

        public override void ClearValues()
        {
            base.ClearValues();
            FillData();
        }

        private void lookupEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEmployee.EditValue == null)
            {
                ErrorProvider.SetError(lookupEmployee, "Please select employee.");
            }
            else
            {
                ErrorProvider.SetError(lookupEmployee, "");
            }
        }

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDateFrom.EditValue != null && dtpDateFrom.DateTime.Date > dtpDateTo.DateTime.Date)
            {
                ErrorProvider.SetError(dtpDateTo, "Date to can not be greater than date from.");
            }
            else
            {
                ErrorProvider.SetError(dtpDateTo, "");
            }
        }

        void FillData()
        {
            if (FormLoading) { return; }

            gcAttendance.DataSource =  ReportDALObj.GetReportData(
                (lookupEmployee.EditValue == null || (int)lookupEmployee.EditValue == -1 ? null : (int?)lookupEmployee.EditValue),
                (DateTime?)dtpDateFrom.EditValue, 
                (DateTime?)dtpDateTo.EditValue);

            for (int rdi = 0; rdi < gvAttendance.RowCount; rdi++)
            {
                int ri = gvAttendance.GetRowHandle(rdi);
                gvAttendance.ExpandMasterRow(ri);
            }
        }

        private void lookupEmployee_EditValueChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void dtpDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void dtpDateTo_EditValueChanged(object sender, EventArgs e)
        {
            FillData();
        }
    }
}
