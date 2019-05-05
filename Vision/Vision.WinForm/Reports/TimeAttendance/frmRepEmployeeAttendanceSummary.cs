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
    public partial class frmRepEmployeeAttendanceSummary : WinForm.Template.frmNormalTemplate
    {
        DAL.Reports.TimeAttendance.EmployeeAttendanceSummaryDAL ReportDALObj;

        public frmRepEmployeeAttendanceSummary()
        {
            InitializeComponent();

            FirstControl = ucEmployeeFilter1;

            ReportDALObj = new DAL.Reports.TimeAttendance.EmployeeAttendanceSummaryDAL();
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

            int? EmployementTypeID = ucEmployeeFilter1.EmploymentType - 1;
            if (EmployementTypeID == -1) { EmployementTypeID = null; }

            var ds = ReportDALObj.GetReportData(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo,
                DepartmentID, DesignationID, LocationID, EmployementTypeID);
            //--
            employeeAttendanceSummaryReportModelBindingSource.DataSource = ds;
            gridControlData.Focus();

            txtNofDays.EditValue = ds.Count;
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            employeeAttendanceSummaryReportModelBindingSource.Clear();
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
