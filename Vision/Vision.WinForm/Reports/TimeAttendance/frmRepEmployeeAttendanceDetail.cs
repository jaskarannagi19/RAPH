using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.WinForm.Reports.TimeAttendance
{
    public partial class frmRepEmployeeAttendanceDetail : WinForm.Template.frmNormalTemplate
    {
        DAL.Reports.TimeAttendance.EmployeeAttendanceDetailDAL ReportDALObj;

        public frmRepEmployeeAttendanceDetail()
        {
            InitializeComponent();

            FirstControl = ucEmployeeFilter1;

            ReportDALObj = new DAL.Reports.TimeAttendance.EmployeeAttendanceDetailDAL();
            //--
            ucEmployeeFilter1.DateFrom = DateTime.Now.Date.AddDays(1 - (int)DateTime.Now.Date.DayOfWeek);
            ucEmployeeFilter1.DateTo = DateTime.Now.Date;

            ucEmployeeFilter1.EmploymentType = 0;

            btnSave.Caption = "Print Preview";
        }

        public override void LoadLookupDataSource()
        {
            ucEmployeeFilter1.LoadLookupDataSource();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            ucEmployeeFilter1.AssignLookupDataSource();

            base.AssignLookupDataSource();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            btnGetReport.PerformClick();
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            if (!base.ProcessValidationFormControls())
            {
                return;
            }

            int? DepartmentID = (int?)ucEmployeeFilter1.DepartmentID;
            if (DepartmentID == -1) { DepartmentID = null; }

            int? DesignationID = (int?)ucEmployeeFilter1.DesignationID;
            if (DesignationID == -1) { DesignationID = null; }

            int? LocationID = (int?)ucEmployeeFilter1.LocationID;
            if (LocationID == -1) { LocationID = null; }

            int? EmployementTypeID = ucEmployeeFilter1.EmploymentType-1;
            if (EmployementTypeID == -1) { EmployementTypeID = null; }

            var dsEmployee = ReportDALObj.GetReportData(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo,
                DepartmentID, DesignationID, LocationID, EmployementTypeID);
            //--

            DataTable dt = new DataTable("dsReport" + DateTime.Now.Ticks.ToString());
            //dt.Columns.Add("EmployeeID", typeof(int));
            dt.Columns.Add("EmployeeNoPrefix", typeof(string));
            dt.Columns.Add("EmployeeNo", typeof(int));
            dt.Columns.Add("EmployeeName", typeof(string));

            for (DateTime r = ucEmployeeFilter1.DateFrom; r <= ucEmployeeFilter1.DateTo; r = r.AddDays(1))
            {
                string dtname = r.ToString("ddMMyyyy");
                dt.Columns.Add("DAY" + dtname, typeof(string));
            }

            dt.Columns.Add("Present", typeof(decimal));
            dt.Columns.Add("Absent", typeof(decimal));
            dt.Columns.Add("Weekend", typeof(decimal));
            dt.Columns.Add("WeekendWorked", typeof(decimal));
            dt.Columns.Add("RestDay", typeof(decimal));
            dt.Columns.Add("RestDayWorked", typeof(decimal));
            dt.Columns.Add("Holiday", typeof(decimal));
            dt.Columns.Add("HolidayWorked", typeof(decimal));
            dt.Columns.Add("Leave", typeof(decimal));
            dt.Columns.Add("Safari", typeof(decimal));
            dt.Columns.Add("Total", typeof(decimal));

            foreach (var Employee in dsEmployee)
            {
                DataRow dr = dt.Rows.Add();
                dr["EmployeeName"] = Employee.EmployeeName;
                dr["EmployeeNoPrefix"] = Employee.EmployeeNoPrefix;
                dr["EmployeeNo"] = Employee.EmployeeNo;

                dr["Present"] = Employee.Present;
                dr["Absent"] = Employee.Absent;
                dr["Weekend"] = Employee.Weekend;
                dr["WeekendWorked"] = Employee.WeekendWorked;
                dr["RestDay"] = Employee.RestDay;
                dr["RestDayWorked"] = Employee.RestDayWorked;
                dr["Holiday"] = Employee.Holiday;
                dr["HolidayWorked"] = Employee.HolidayWorked;
                dr["Leave"] = Employee.Leave;
                dr["Safari"] = Employee.Safari;
                dr["Total"] = Employee.Total;

                foreach (var att in Employee.AttendanceDetail)
                {
                    dr["DAY" + att.Day.ToString("ddMMyyyy")] = att.DayStatus;
                }
            }

            //dt.DefaultView.Sort = "EmployeeNo";

            ClearGrid();
            gridControlData.DataSource = dt;//.DefaultView.ToTable();
            txtNofRecords.EditValue = dt.Rows.Count;

            GridColumn myGridColumn = null;
            myGridColumn = gridViewData.Columns["EmployeeNoPrefix"];
            myGridColumn.Caption = "E. Prefix";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 150;
            //myGridColumn.SortIndex = 0;
            myGridColumn.Visible = false;

            myGridColumn = gridViewData.Columns["EmployeeNo"];
            myGridColumn.Caption = "Emp Code";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 150;
            //myGridColumn.SortIndex = 0;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["EmployeeName"];
            myGridColumn.Caption = "Name";
            myGridColumn.MinWidth = 200;
            myGridColumn.MaxWidth = 500;
            myGridColumn.Visible = true;

            for (DateTime r = ucEmployeeFilter1.DateFrom; r <= ucEmployeeFilter1.DateTo; r = r.AddDays(1))
            {
                string dtname = r.ToString("ddMMyyyy");
                //--
                GridColumn column = gridViewData.Columns["DAY" + dtname];
                column.Caption = r.ToString("dMMM");
                column.MinWidth = 50;
                column.MaxWidth = 70;
                column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.Visible = true;
            }

            myGridColumn = gridViewData.Columns["Present"];
            myGridColumn.Caption = "Present";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["Absent"];
            myGridColumn.Caption = "Absent";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["Weekend"];
            myGridColumn.Caption = "Weekend";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["WeekendWorked"];
            myGridColumn.Caption = "Weekend Worked";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["Holiday"];
            myGridColumn.Caption = "Holiday";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["HolidayWorked"];
            myGridColumn.Caption = "Holiday Worked";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["Leave"];
            myGridColumn.Caption = "Leave";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["Safari"];
            myGridColumn.Caption = "Safari";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["Total"];
            myGridColumn.Caption = "Total";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            myGridColumn.Visible = true;

            //employeeAttendanceDetailReportModelBindingSource.DataSource = ds;
            gridControlData.Focus();
        }
        
        private void btnClearData_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            gridControlData.ShowRibbonPrintPreview();
            base.AfterSaving(Paras);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel|*.xlsx";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                gridControlData.ExportToXlsx(sfd.FileName);

                if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        void ClearGrid()
        {
            gridControlData.DataSource = null;
            gridViewData.Columns.Clear();
        }

    }
}
