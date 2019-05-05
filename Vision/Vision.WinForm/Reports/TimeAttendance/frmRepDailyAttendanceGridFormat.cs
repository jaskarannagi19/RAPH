using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.Model.Reports.TimeAttendance;
using Vision.Model;

namespace Vision.WinForm.Reports.TimeAttendance
{
    public partial class frmRepDailyAttendanceGridFormat : Vision.WinForm.Template.frmNormalTemplate
    {
        public enum eReportType
        {
            All = 0,
            LateComing = 1,
            EarlyGoing = 2,
            MissedPunch = 3
        }

        DAL.Reports.TimeAttendance.DailyAttendanceReportDAL DailyReportDALObj;

        DAL.Employee.EmployeeDAL EmployeeDAL;
        List<Model.Employee.EmployeeLookupListModel> dsEmployeeLookup;

        TimeSpan ShiftStart;
        TimeSpan ShiftEnd;

        bool ShowShift
        {
            get
            {
                return cmbShowShift.SelectedIndex == 1;
            }
        }

        public frmRepDailyAttendanceGridFormat()
        {
            InitializeComponent();

            DailyReportDALObj = new DAL.Reports.TimeAttendance.DailyAttendanceReportDAL();
            EmployeeDAL = new DAL.Employee.EmployeeDAL();
            //--
            ucEmployeeFilter1.DateFrom = DateTime.Now.Date.AddDays(1 - (int)DateTime.Now.Date.DayOfWeek);
            ucEmployeeFilter1.DateTo = DateTime.Now.Date;

            ShiftStart = new TimeSpan(08, 0, 0);
            ShiftEnd = new TimeSpan(17, 0, 0);

            cmbType.SelectedIndex = 0;
            ucEmployeeFilter1.EmploymentType = 0;

            gridViewData.Columns.Clear();
            gridViewData.Bands.Clear();

            btnSave.Caption = "Print Preview";
        }

        public override void LoadLookupDataSource()
        {
            dsEmployeeLookup = EmployeeDAL.GetLookupList();
            ucEmployeeFilter1.LoadLookupDataSource();
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            ucEmployeeFilter1.AssignLookupDataSource();
            base.AssignLookupDataSource();
        }

        public override void AssignFormValues()
        {
            cmbShowShift.SelectedIndex = 0;
            base.AssignFormValues();
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

            int? DepartmentID = ucEmployeeFilter1.DepartmentID;
            if(DepartmentID == -1) { DepartmentID = null; }

            int? DesignationID = ucEmployeeFilter1.DesignationID;
            if (DesignationID == -1) { DesignationID = null; }

            int? LocationID = ucEmployeeFilter1.LocationID;
            if (LocationID == -1) { LocationID = null; }

            int? EmployementTypeID = ucEmployeeFilter1.EmploymentType - 1;
            if (EmployementTypeID == -1) { EmployementTypeID = null; }

            var ds = (new DAL.Payroll.EmployeeAttendanceDAL()).GetEmployeeAttendanceData(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo,
                DepartmentID, DesignationID, LocationID, EmployementTypeID);


            eReportType ReportType = (eReportType)cmbType.SelectedIndex;

            switch(ReportType)
            {
                case eReportType.LateComing:
                    ds = ds.Where(r => r.LateIn).ToList();
                    break;
                case eReportType.EarlyGoing:
                    ds = ds.Where(r => r.EarlyGoing).ToList();
                    break;
                case eReportType.MissedPunch:
                    ds = ds.Where(r => r.MissedPunch).ToList();
                    break;
            }

            var filteredEmployees = (from r in ds
                            group r by r.EmployeeID into gr
                            select gr.Key);

            DataTable dt = new DataTable("dsReport" + DateTime.Now.Ticks.ToString());            
            dt.Columns.Add("EmployeeNoPrefix", typeof(string));
            dt.Columns.Add("EmployeeNo", typeof(int));
            dt.Columns.Add("EmployeeName", typeof(string));
            //dt.Columns.Add("DepartmentName", typeof(string));
            //dt.Columns.Add("DesignationName", typeof(string));
            //dt.Columns.Add("LocationName", typeof(string));
            //dt.Columns.Add("EmployementType", typeof(string));

            for (DateTime r = ucEmployeeFilter1.DateFrom; r <= ucEmployeeFilter1.DateTo; r = r.AddDays(1))
            {
                string dtname = r.ToString("ddMMyyyy");

                dt.Columns.Add("ShiftName" + dtname, typeof(string));

                if (ReportType != eReportType.EarlyGoing)
                {
                    dt.Columns.Add("DTIN" + dtname, typeof(TimeSpan));
                }

                if (ReportType != eReportType.LateComing)
                {
                    dt.Columns.Add("DTOUT" + dtname, typeof(TimeSpan));
                }
            }

            foreach (var emp in filteredEmployees)
            {
                var Employee = dsEmployeeLookup.Find(r => r.EmployeeID == emp);
                if (Employee == null || Employee.EmployeeID == -1)
                {
                    continue;
                }
                DataRow dr = dt.Rows.Add();
                //dr["EmployeeID"] = emp;
                dr["EmployeeName"] = Employee.EmployeeName;
                dr["EmployeeNoPrefix"] = Employee.EmployeeNoPrefix;
                dr["EmployeeNo"] = Employee.EmployeeNo;
                //dr["DepartmentName"] = Employee.Department;
                //dr["DesignationName"] = Employee.Designation;
                //dr["LocationName"] = Employee.Location;
                //dr["EmployementType"] = Employee.EmployementType;


                for (DateTime date = ucEmployeeFilter1.DateFrom; date <= ucEmployeeFilter1.DateTo; date = date.AddDays(1))
                {
                    var attendances = ds.Where(r => r.EmployeeID == emp && r.Day == date);
                    foreach (var attendance in attendances)
                    {
                        if (attendance != null)
                        {
                            dr["ShiftName" + date.ToString("ddMMyyyy")] = attendance.EmployeeShiftName;

                            if (attendance.InTime != null && ReportType != eReportType.EarlyGoing)
                            {
                                dr["DTIN" + date.ToString("ddMMyyyy")] = attendance.InTime;
                            }
                            if (attendance.OutTime != null && ReportType != eReportType.LateComing)
                            {
                                dr["DTOUT" + date.ToString("ddMMyyyy")] = attendance.OutTime;
                            }
                        }
                    }
                }
            }
            dt.DefaultView.Sort = "EmployeeNo";

            ClearGrid();
            gridControlData.DataSource = dt;//.DefaultView.ToTable();

            txtNofRecords.EditValue = dt.Rows.Count;

            GridBand EmployeeBand = new DevExpress.XtraGrid.Views.BandedGrid.GridBand()
            {
                Name = "EmployeeBand",
                Caption = "Employee",
                MinWidth = 100,
            };
            EmployeeBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridViewData.Bands.Add(EmployeeBand);

            BandedGridColumn myGridColumn = null;

            myGridColumn = gridViewData.Columns["EmployeeNoPrefix"];
            myGridColumn.Caption = "Prefix";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            //myGridColumn.SortIndex = 0;
            myGridColumn.OwnerBand = EmployeeBand;
            myGridColumn.Width = 100;
            myGridColumn.Visible = false;

            myGridColumn = gridViewData.Columns["EmployeeNo"];
            myGridColumn.Caption = "No.";
            myGridColumn.MinWidth = 70;
            myGridColumn.MaxWidth = 100;
            //myGridColumn.SortIndex = 0;
            myGridColumn.OwnerBand = EmployeeBand;
            myGridColumn.Width = 100;
            myGridColumn.Visible = true;

            myGridColumn = gridViewData.Columns["EmployeeName"];
            myGridColumn.Caption = "Name";
            myGridColumn.MinWidth = 200;
            //myGridColumn.MaxWidth = 500;
            myGridColumn.OwnerBand = EmployeeBand;
            myGridColumn.Visible = true;
            myGridColumn.Width = 1000;
            //myGridColumn = gridViewData.Columns["DepartmentName"];
            //myGridColumn.Caption = "Department";
            //myGridColumn.MinWidth = 100;
            //myGridColumn.MaxWidth = 300;
            //myGridColumn.OwnerBand = EmployeeBand;
            //myGridColumn.Visible = false;

            //myGridColumn = gridViewData.Columns["DesignationName"];
            //myGridColumn.Caption = "Designation";
            //myGridColumn.MinWidth = 100;
            //myGridColumn.MaxWidth = 300;
            //myGridColumn.OwnerBand = EmployeeBand;
            //myGridColumn.Visible = false;

            //myGridColumn = gridViewData.Columns["LocationName"];
            //myGridColumn.Caption = "Location";
            //myGridColumn.MinWidth = 100;
            //myGridColumn.MaxWidth = 300;
            //myGridColumn.OwnerBand = EmployeeBand;
            //myGridColumn.Visible = false;

            //myGridColumn = gridViewData.Columns["EmployementType"];
            //myGridColumn.Caption = "Employement Type";
            //myGridColumn.MinWidth = 70;
            //myGridColumn.MaxWidth = 200;
            //myGridColumn.OwnerBand = EmployeeBand;
            //myGridColumn.Visible = false;

            int ColumnIndex = 0;
            for (DateTime r = ucEmployeeFilter1.DateFrom; r <= ucEmployeeFilter1.DateTo; r = r.AddDays(1))
            {
                string dtname = r.ToString("ddMMyyyy");
                //--
                GridBand DateBand = new GridBand()
                {
                    Name = "DateBand" + dtname,
                    Caption = r.ToString("dd-MM-yyyy"),
                };
                DateBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridViewData.Bands.Add(DateBand);
                //--
                BandedGridColumn column = null;

                Color AlternateBackColor = Color.WhiteSmoke;

                column = gridViewData.Columns["ShiftName" + dtname];
                column.Caption = "Shift";
                column.MinWidth = 75;
                column.MaxWidth = 300;
                column.OwnerBand = DateBand;
                column.Width = 100;
                column.Visible = ShowShift;
                if ((ColumnIndex % 2 == 0))
                {
                    column.AppearanceCell.BackColor = AlternateBackColor;
                }

                if (ReportType != eReportType.EarlyGoing)
                {    
                    column = gridViewData.Columns["DTIN" + dtname];
                    column.Caption = "In";
                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    column.DisplayFormat.FormatString = "hh\\:mm";
                    column.MinWidth = 55;
                    column.MaxWidth = 100;
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.OwnerBand = DateBand;
                    column.Width = 100;
                    column.Visible = true;
                    if ((ColumnIndex % 2 == 0))
                    {
                        column.AppearanceCell.BackColor = AlternateBackColor;
                    }
                }

                if (ReportType != eReportType.LateComing)
                {
                    column = gridViewData.Columns["DTOUT" + dtname];
                    column.Caption = "Out";
                    column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    column.DisplayFormat.FormatString = "hh\\:mm";
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.OwnerBand = DateBand;
                    column.MinWidth = 55;
                    column.MaxWidth = 100;
                    column.Width = 100;
                    column.Visible = true;
                    if ((ColumnIndex % 2 == 0))
                    {
                        column.AppearanceCell.BackColor = AlternateBackColor;
                    }
                }

                if (ReportType == eReportType.LateComing || ReportType == eReportType.EarlyGoing)
                {
                    DateBand.Width = 100;
                }
                else
                {
                    DateBand.Width = 200;
                }
                ColumnIndex++;
            }
            //--
            gridControlData.RefreshDataSource();
            gridViewData.BestFitColumns();
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        void ClearGrid()
        {
            gridControlData.DataSource = null;
            gridViewData.Bands.Clear();
            gridViewData.Columns.Clear();
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
    }
}
