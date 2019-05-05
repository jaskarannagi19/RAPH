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
using Vision.DAL.Reports.TimeAttendance;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.WinForm.Reports.TimeAttendance
{
    public partial class frmRepTimeAttendanceReport : WinForm.Template.frmNormalTemplate
    {
        public enum eReportType
        {
            AttendancePerformance = 0,
            EmployeeAttendancePerformance = 1,
            EmployeeAttendanceMonthlySummary = 2,
            WeekendHolidayRestDayAttendanceReport = 3
        }

        public eReportType ReportType { get { return (eReportType)cmbReportType.SelectedIndex; } }

        DAL.Reports.TimeAttendance.EmployeeAttendanceDetailDAL ReportDALObj;
        DAL.Payroll.LeaveTypeDAL LeaveTypeDALObj;
        List<Model.Payroll.LeaveTypeLookupListModel> dsLeaveType;

        DAL.Employee.EmployeeDAL EmployeeDALObj;
        List<Model.Employee.EmployeeLookupListModel> dsEmployee;

        public frmRepTimeAttendanceReport()
        {
            InitializeComponent();

            FirstControl = ucEmployeeFilter1;

            ReportDALObj = new DAL.Reports.TimeAttendance.EmployeeAttendanceDetailDAL();
            LeaveTypeDALObj = new DAL.Payroll.LeaveTypeDAL();
            EmployeeDALObj = new DAL.Employee.EmployeeDAL();
            //--
            ucEmployeeFilter1.DateFrom = DateTime.Now.Date.AddDays(1 - (int)DateTime.Now.Date.DayOfWeek);
            ucEmployeeFilter1.DateTo = DateTime.Now.Date;

            ucEmployeeFilter1.EmploymentType = 0;

            cmbReportType.SelectedIndex = 0;

            btnSave.Caption = "Print Preview";
        }

        public override void LoadLookupDataSource()
        {
            ucEmployeeFilter1.LoadLookupDataSource();
            dsLeaveType = LeaveTypeDALObj.GetLookupList();

            dsEmployee = EmployeeDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            ucEmployeeFilter1.AssignLookupDataSource();

            lookupLeaveType.Properties.DisplayMember = "LeaveTypeName";
            lookupLeaveType.Properties.ValueMember = "LeaveTypeID";
            lookupLeaveType.Properties.DataSource = dsLeaveType;

            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DataSource = dsEmployee;

            base.AssignLookupDataSource();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            btnGetReport.PerformClick();
        }

        int? DepartmentID = null;
        int? DesignationID = null;
        int? LocationID = null;
        int? EmployementTypeID = null;

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            ErrorProvider.SetError(lookupLeaveType, null);

            if (!base.ProcessValidationFormControls())
            {
                return;
            }

            DepartmentID = (int?)ucEmployeeFilter1.DepartmentID;
            if (DepartmentID == -1) { DepartmentID = null; }

            DesignationID = (int?)ucEmployeeFilter1.DesignationID;
            if (DesignationID == -1) { DesignationID = null; }

            LocationID = (int?)ucEmployeeFilter1.LocationID;
            if (LocationID == -1) { LocationID = null; }

            EmployementTypeID = ucEmployeeFilter1.EmploymentType - 1;
            if (EmployementTypeID == -1) { EmployementTypeID = null; }

            gridControlData.DataSource = null;
            gridViewData.Columns.Clear();

            switch (ReportType)
            {
                case eReportType.AttendancePerformance:
                    AttendancePerformanceReport();
                    break;
                case eReportType.EmployeeAttendancePerformance:
                    EmployeeAttendancePerformanceReport();
                    break;
                case eReportType.EmployeeAttendanceMonthlySummary:
                    EmployeeMonthlyAttendanceSummary();
                    break;
                case eReportType.WeekendHolidayRestDayAttendanceReport:
                    EmployeeWeekendAttendanceReport();
                    break;
            }

            txtNofRecords.EditValue = gridViewData.RowCount;

            gridControlData.Focus();
        }

        void AttendancePerformanceReport()
        {
            gridControlData.DataSource = (new AttendancePerformanceDAL()).GetReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo,  DepartmentID, DesignationID, LocationID, EmployementTypeID);

            gridControlData.RefreshDataSource();

            GridColumn column = null;
            column = gridViewData.Columns["EmployeeNoPrefix"];
            column.MaxWidth = 125;
            column.MinWidth = 75;
            column.Visible = false;

            column = gridViewData.Columns["EmployeeNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeName"];
            //column.MaxWidth = 120;
            column.MinWidth = 100;

            column = gridViewData.Columns["Absent"];
            column.MaxWidth = 100;
            column.MinWidth = 75;
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";

            column = gridViewData.Columns["LateIn"];
            column.MaxWidth = 100;
            column.MinWidth = 75;
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";

            column = gridViewData.Columns["EarlyGoing"];
            column.MaxWidth = 100;
            column.MinWidth = 75;
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";

            column = gridViewData.Columns["MissedPunch"];
            column.MaxWidth = 100;
            column.MinWidth = 75;
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            column.SummaryItem.DisplayFormat = "{0:n0}";

        }

        void EmployeeAttendancePerformanceReport()
        {
            gridControlData.DataSource = (new DAL.Reports.TimeAttendance.EmployeeAttendancePerformanceDAL()).GetReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, (int)lookupEmployee.EditValue);

            gridControlData.RefreshDataSource();

            GridColumn column = null;

            column = gridViewData.Columns["Day"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Absent"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["LateIn"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["EarlyGoing"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["MissedPunch"];
            column.MaxWidth = 125;
            column.MinWidth = 75;
        }

        void EmployeeMonthlyAttendanceSummary()
        {
            gridControlData.DataSource = (new DAL.Reports.TimeAttendance.EmployeeMonthlyAttendanceSummaryDAL()).GetReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, (int)lookupEmployee.EditValue);

            gridControlData.RefreshDataSource();

            GridColumn column = null;

            column = gridViewData.Columns["MonthYear"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Present"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["Absent"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["Weekend"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["WeekendWorked"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["Holiday"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["HolidayWorked"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["Leave"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["Safari"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["TotalDays"];
            column.AppearanceCell.BackColor = Color.WhiteSmoke;
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["LateIn"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["EarlyGoing"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["MissedPunch"];
            column.MaxWidth = 125;
            column.MinWidth = 75;
        }

        void EmployeeWeekendAttendanceReport()
        {
            var ds = (new DAL.Payroll.EmployeeAttendanceDAL()).GetEmployeeAttendanceData(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID)
                .Where(r => r.Weekend == Model.Payroll.eEmployeeWeekendDayType.WeekendWorked ||
                            r.RestDay == Model.Payroll.eEmployeeRestDayDayType.RestDayWorked ||
                            r.Holiday == Model.Payroll.eEmployeeHolidayDayType.HolidayWorked).ToList(); 

            //var ds1 = (from r in ds
            //           where String.IsNullOrWhiteSpace(r.DayStatus) && (r.ActualWeekend == Model.Payroll.eEmployeeWeekendDayType.WeekendWorked || r.ActualHoliday == Model.Payroll.eEmployeeHolidayDayType.HolidayWorked)
            //           select r).ToList();

            var Days = (from r in ds
                        //where r.ActualWeekend == Model.Payroll.eEmployeeWeekendDayType.Weekend || r.ActualWeekend == Model.Payroll.eEmployeeWeekendDayType.WeekendWorked ||
                        //    r.ActualHoliday != Model.Payroll.eEmployeeHolidayDayType.None
                        group r by r.Day into gr
                        select gr.Key).OrderBy(r=> r).ToList();

            var ds1 = ds.Where(r => r.ActualWeekend == Model.Payroll.eEmployeeWeekendDayType.WeekendWorked ||
                            r.ActualHoliday != Model.Payroll.eEmployeeHolidayDayType.HolidayWorked).ToList();

            var FilteredEmployeeIDs = (from r in ds
                                       group r by r.EmployeeID into gr
                                       select gr.Key);

            DataTable dt = new DataTable("dsReport" + DateTime.Now.Ticks.ToString());
            //dt.Columns.Add("EmployeeID", typeof(int));
            dt.Columns.Add("EmployeeNoPrefix", typeof(string));
            dt.Columns.Add("EmployeeNo", typeof(int));
            dt.Columns.Add("EmployeeName", typeof(string));

            foreach (DateTime r in Days)
            {
                string dtname = r.ToString("ddMMyyyy");
                dt.Columns.Add("DATE" + dtname, typeof(string));
            }

            dt.Columns.Add("TotalWHWorked", typeof(int));

            foreach (var emp in (from r in dsEmployee
                                 join fe in FilteredEmployeeIDs on r.EmployeeID equals fe
                                 orderby r.EmployeeNo
                                 select r))
            {                
                var Employee = dsEmployee.Find(r => r.EmployeeID == emp.EmployeeID);
                if (Employee == null || Employee.EmployeeID == -1)
                {
                    continue;
                }

                DataRow dr = dt.Rows.Add();
                dr["EmployeeName"] = Employee.EmployeeName;
                dr["EmployeeNoPrefix"] = Employee.EmployeeNoPrefix;
                dr["EmployeeNo"] = Employee.EmployeeNo;

                int TotalWHWorked = 0;
                foreach (var date in Days)
                {
                    var attendance = ds.FirstOrDefault(r => r.EmployeeID == emp.EmployeeID && r.Day == date);
                    if (attendance != null)
                    {
                        string dtname = date.ToString("ddMMyyyy");
                        dr["DATE" + dtname] = attendance.DayStatus;
                        TotalWHWorked++;
                    }
                }
                dr["TotalWHWorked"] = TotalWHWorked;
            }
            //dt.DefaultView.Sort = "EmployeeNo";

            ClearGrid();
            gridControlData.DataSource = dt;//.DefaultView.ToTable();

            txtNofRecords.EditValue = dt.Rows.Count;


            GridColumn column = null;
            column = gridViewData.Columns["EmployeeNoPrefix"];
            column.Caption = "E. Prefix";
            column.MaxWidth = 125;
            column.MinWidth = 75;
            column.Visible = false;

            column = gridViewData.Columns["EmployeeNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeName"];
            //column.MaxWidth = 120;
            column.MinWidth = 100;

            foreach (var date in Days)
            {
                string dtname = date.ToString("ddMMyyyy");
                //--
                column = gridViewData.Columns["DATE" + dtname];
                column.Caption = date.ToString("dd MMM ddd");
                column.MinWidth = 40;
                column.MaxWidth = 100;
                column.Width = 50;
                column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                column.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                column.Visible = true;
            }
            //--

            column = gridViewData.Columns["TotalWHWorked"];
            column.Caption = "Total";
            column.MaxWidth = 100;
            column.MinWidth = 75;

            gridControlData.RefreshDataSource();
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

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ReportType == eReportType.EmployeeAttendancePerformance || ReportType == eReportType.EmployeeAttendanceMonthlySummary )
            {
                lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                ErrorProvider.SetError(lookupEmployee, "");
            }

            //lcgLeaveType.Visibility = (ReportType == eReportType.LeaveBalance || ReportType == eReportType.LeaveDetail ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);

            //if (ReportType == eReportType.LeaveDetail)
            //{
            //    lcgEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //    LoadEmployeeLookupDataSource();
            //}
            //else
            //{
            //    lcgEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //}
        }

        private void lookupLeaveType_Validating(object sender, CancelEventArgs e)
        {
            //if((ReportType == eReportType.LeaveBalance || ReportType == eReportType.LeaveDetail) && lookupLeaveType.EditValue == null)
            //{
            //    ErrorProvider.SetError(lookupLeaveType, "Please select leave type.");
            //}
            //else
            //{
            //    ErrorProvider.SetError(lookupLeaveType, "");
            //}
        }

        private void lookupEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (lciEmployee.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always && lookupEmployee.EditValue == null)
            {
                ErrorProvider.SetError(lookupEmployee, "Please select employee.");
            }
            else
            {
                ErrorProvider.SetError(lookupEmployee, "");
            }
        }

        private void ucEmployeeFilter1_FilterItemIDChanged(object sender, EventArgs e)
        {
            if (ReportType == eReportType.EmployeeAttendancePerformance || ReportType == eReportType.EmployeeAttendanceMonthlySummary)
            {
                LoadEmployeeLookupDataSource();
            }
        }

        void LoadEmployeeLookupDataSource()
        {
            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = EmployeeDALObj.GetLookupList(DepartmentID, DesignationID, LocationID, EmployementTypeID);
        }

        private void ucEmployeeFilter1_Validating(object sender, CancelEventArgs e)
        {
            if(ucEmployeeFilter1.DateFrom > ucEmployeeFilter1.DateTo)
            {
                ErrorProvider.SetError(ucEmployeeFilter1, "Date from can not less than date to");
            }
            else
            {
                ErrorProvider.SetError(ucEmployeeFilter1, "");
            }
        }
    }
}
