using DevExpress.XtraEditors.Repository;
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
    public partial class frmRepEmployeeSalaryIncrementReport : Vision.WinForm.Template.frmNormalTemplate
    {
        DAL.Reports.Employee.EmployeeSalaryIncrementReportDAL ReportDALObj;
        DAL.Employee.EmployeeDAL EmployeeDALObj;
        List<Model.Employee.EmployeeLookupListModel> dsEmployee;
        bool FormLoading;

        public frmRepEmployeeSalaryIncrementReport()
        {
            FormLoading = true;
            InitializeComponent();

            EmployeeDALObj = new DAL.Employee.EmployeeDAL();
            ReportDALObj = new DAL.Reports.Employee.EmployeeSalaryIncrementReportDAL();
            DateTime DateTo = DateTime.Now.Date;
            DateTime DateFrom = (DateTo.DayOfWeek == DayOfWeek.Sunday ? DateTo : DateTo.AddDays(1 - (int)DateTo.DayOfWeek));
            ucEmployeeFilter1.EmploymentType = 0;

            var From = new DateTime(FromDate.DateTime.Year, FromDate.DateTime.Month, 1);
            var To = From.AddMonths(1).AddDays(-1);
            FromDate.DateTime = (DateTime.Now.Date < Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom ? Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom : DateTime.Now.Date);
        }
        public override void LoadLookupDataSource()
        {
            ucEmployeeFilter1.LoadLookupDataSource();
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsEmployee.Insert(0, new Model.Employee.EmployeeLookupListModel() { EmployeeID = -1, FirstName = "(All)" });
            base.LoadLookupDataSource();
        }
        public override void AssignLookupDataSource()
        {
            ucEmployeeFilter1.AssignLookupDataSource();
            base.AssignLookupDataSource();
        }
        public override void AssignFormValues()
        {
            FormLoading = false;
            base.AssignFormValues();
        }
        public override void ClearValues()
        {
            base.ClearValues();
        }

        void FillData()
        {
            if (FormLoading) { return; }

            if (!base.ProcessValidationFormControls())
            {
                return;
            }

            int? DepartmentID = ucEmployeeFilter1.DepartmentID;
            if (DepartmentID == -1) { DepartmentID = null; }

            int? DesignationID = ucEmployeeFilter1.DesignationID;
            if (DesignationID == -1) { DesignationID = null; }

            int? LocationID = ucEmployeeFilter1.LocationID;
            if (LocationID == -1) { LocationID = null; }

            int? EmployementTypeID = ucEmployeeFilter1.EmploymentType - 1;
            if (EmployementTypeID == -1) { EmployementTypeID = null; }

            var From = new DateTime(FromDate.DateTime.Year, FromDate.DateTime.Month, 1);
            var To = From.AddMonths(1).AddDays(-1);

            var Res = ReportDALObj.GetReportData(From, To, DepartmentID, DesignationID, LocationID, EmployementTypeID);
            txtNofRecords.EditValue = Res.Count();
            gcEmployeeSalaryIncrement.DataSource = Res;

            //gvData.Columns["EmployeeNoPrefix"].Visible = true;            
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            FillData();
        }

        void ClearGrid()
        {
            gcEmployeeSalaryIncrement.DataSource = null;
            txtNofRecords.EditValue = 0;
            FromDate.DateTime = DateTime.Now;
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void ucEmployeeFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
