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
    public partial class frmRepEmployeeLeaveSafariTransactionReport : WinForm.Template.frmNormalTemplate
    {
        public enum eReportType
        {
            LeaveTransaction = 0,
            LeaveBalance = 1,
            LeaveEncashmentAdjustment = 2,
            SafariTransaction = 3,
            LeaveDetail = 4
        }

        public eReportType ReportType { get { return (eReportType)cmbReportType.SelectedIndex; } }

        DAL.Reports.TimeAttendance.EmployeeAttendanceDetailDAL ReportDALObj;
        DAL.Payroll.LeaveTypeDAL LeaveTypeDALObj;
        List<Model.Payroll.LeaveTypeLookupListModel> dsLeaveType;
        DAL.Employee.EmployeeDAL EmployeeDALObj;

        public frmRepEmployeeLeaveSafariTransactionReport()
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

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            ucEmployeeFilter1.AssignLookupDataSource();

            lookupLeaveType.Properties.DisplayMember = "LeaveTypeName";
            lookupLeaveType.Properties.ValueMember = "LeaveTypeID";
            lookupLeaveType.Properties.DataSource = dsLeaveType;

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

            if(EmployementTypeID != null && EmployementTypeID == (int)Model.Employee.eEmploymentType.Casual)
            {
                MessageBox.Show("Casual employment doesn't posses any leave.", "Leave Report", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            gridControlData.DataSource = null;
            gridViewData.Columns.Clear();

            switch (ReportType)
            {
                case eReportType.LeaveTransaction:
                    LeaveTransactionReport();
                    break;
                case eReportType.LeaveBalance:
                    LeaveBalanceReport();
                    break;
                case eReportType.LeaveEncashmentAdjustment:
                    LeaveEncashmentAdjustmentTransactionReport();
                    break;
                case eReportType.SafariTransaction:
                    SafariTransactionReport();
                    break;
                case eReportType.LeaveDetail:
                    LeaveDetailReport();
                    break;
            }
        
            gridControlData.Focus();
        }

        void LeaveTransactionReport()
        {
            List<LeaveTransactionReportModel> res = (new LeaveTransactionReportDAL()).GetLeaveTransactionReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID);

            gridControlData.DataSource = res;
            txtNofRecords.EditValue = res.Count;

            gridControlData.RefreshDataSource();

            GridColumn column = null;
            column = gridViewData.Columns["LeaveApplicationDate"];
            column.MaxWidth = 135;
            column.MinWidth = 70;

            column = gridViewData.Columns["LeaveApplicationNoPrefixName"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["LeaveApplicationNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeNoPrefix"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["EmployeeNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeName"];
            //column.MaxWidth = 120;
            column.MinWidth = 100;

            column = gridViewData.Columns["LeaveTypeName"];
            column.MaxWidth = 150;
            column.MinWidth = 100;

            column = gridViewData.Columns["FromDate"];
            column.MaxWidth = 135;
            column.MinWidth = 100;

            column = gridViewData.Columns["ToDate"];
            column.MaxWidth = 135;
            column.MinWidth = 100;

            column = gridViewData.Columns["NofDays"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["AbsentDays"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Remarks"];
            //column.MaxWidth = 135;
            column.MinWidth = 100;
        }

        void LeaveBalanceReport()
        {
            int SelectedLeaveTypeID = (int)lookupLeaveType.EditValue;
            var SelectedLeaveType = LeaveTypeDALObj.FindSaveModelByPrimeKey(SelectedLeaveTypeID);
            if(SelectedLeaveType == null)
            {
                return;
            }

            List<LeaveBalanceReportModel> res = (new LeaveBalanceReportDAL()).GetLeaveBalanceReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, SelectedLeaveTypeID, DepartmentID, DesignationID, LocationID, EmployementTypeID);
            gridControlData.DataSource = res;

            txtNofRecords.EditValue = res.Count;

            gridControlData.RefreshDataSource();
            GridColumn column = null;


            column = gridViewData.Columns["EmployeeNoPrefix"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["EmployeeNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeName"];
            //column.MaxWidth = 120;
            column.MinWidth = 100;


            column = gridViewData.Columns["OpeningBalance"];
            if (SelectedLeaveType.CanCarryForward)
            {
                column.Caption = "Op. Balance";
                column.MaxWidth = 100;
                column.MinWidth = 75;
            }
            else
            {
                column.Visible = false;
            }

            column = gridViewData.Columns["Accured"];
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = "n2";
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Adjustment"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["LeaveTaken"];
            column.Caption = "Taken";
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["LeaveEncashment"];
            if (SelectedLeaveType.IsEncashable)
            {
                column.Caption = "Encashment";
                column.MaxWidth = 100;
                column.MinWidth = 75;
            }
            else
            {
                column.Visible = false;
            }

            column = gridViewData.Columns["ClosingBalance"];
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            column.DisplayFormat.FormatString = "n2";
            column.Caption = "Balance";
            column.MaxWidth = 100;
            column.MinWidth = 75;
        }

        void LeaveEncashmentAdjustmentTransactionReport()
        {

            List<LeaveEncashmentAdjustmentTransactionReportModel> res = (new LeaveEncashmentAdjustmentTransactionReportDAL()).GetLeaveEncashmentAdjustmentTransactionReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID);
            gridControlData.DataSource = res;
            gridControlData.RefreshDataSource();

            txtNofRecords.EditValue = res.Count;

            GridColumn column = null;
            column = gridViewData.Columns["TransactionDate"];
            column.MaxWidth = 135;
            column.MinWidth = 70;

            column = gridViewData.Columns["TransactionNoPrefixName"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["TransactionNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeNoPrefix"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["EmployeeNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeName"];
            //column.MaxWidth = 120;
            column.MinWidth = 100;

            column = gridViewData.Columns["NofDays"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Remarks"];
            //column.MaxWidth = 135;
            column.MinWidth = 100;

            column = gridViewData.Columns["Description"];
            column.MaxWidth = 100;
            column.MinWidth = 50;
        }

        void SafariTransactionReport()
        {
            List<SafariTransactionReportModel> res = (new SafariTransactionReportDAL()).GetSafariTransactionReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID);

            gridControlData.DataSource = res;
            gridControlData.RefreshDataSource();

            txtNofRecords.EditValue = res.Count;

            GridColumn column = null;
            column = gridViewData.Columns["SafariApplicationDate"];
            column.MaxWidth = 135;
            column.MinWidth = 70;

            column = gridViewData.Columns["SafariApplicationNoPrefixName"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["SafariApplicationNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeNoPrefix"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["EmployeeNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["EmployeeName"];
            //column.MaxWidth = 120;
            column.MinWidth = 100;

            column = gridViewData.Columns["FromDate"];
            column.MaxWidth = 135;
            column.MinWidth = 100;

            column = gridViewData.Columns["ToDate"];
            column.MaxWidth = 135;
            column.MinWidth = 100;

            column = gridViewData.Columns["NofDays"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Remarks"];
            //column.MaxWidth = 135;
            column.MinWidth = 100;
        }

        void LeaveDetailReport()
        {
            List<LeaveDetailReportModel> res = (new LeaveDetaiReportDAL()).GetLeaveDetailReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, (int)lookupLeaveType.EditValue, (int)lookupEmployee.EditValue);

            gridControlData.DataSource = res;
            gridControlData.RefreshDataSource();

            if (res == null)
            {
                return;
            }
            txtNofRecords.EditValue = res.Count;

            GridColumn column = null;
            column = gridViewData.Columns["TransactionDate"];
            column.MaxWidth = 135;
            column.MinWidth = 70;

            column = gridViewData.Columns["TransactionName"];
            column.MaxWidth = 120;
            column.MinWidth = 70;

            column = gridViewData.Columns["TransactionNoPrefixName"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
            column.Visible = false;

            column = gridViewData.Columns["TransactionNo"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Earned"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Utilized"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["Balance"];
            column.MaxWidth = 100;
            column.MinWidth = 75;
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
            lciLeaveType.Visibility = (ReportType == eReportType.LeaveBalance || ReportType == eReportType.LeaveDetail ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);

            if (ReportType == eReportType.LeaveDetail)
            {
                lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                LoadEmployeeLookupDataSource();
            }
            else
            {
                lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void lookupLeaveType_Validating(object sender, CancelEventArgs e)
        {
            if((ReportType == eReportType.LeaveBalance || ReportType == eReportType.LeaveDetail) && lookupLeaveType.EditValue == null)
            {
                ErrorProvider.SetError(lookupLeaveType, "Please select leave type.");
            }
            else
            {
                ErrorProvider.SetError(lookupLeaveType, "");
            }
        }

        private void lookupEmployee_Validating(object sender, CancelEventArgs e)
        {
            if (ReportType == eReportType.LeaveDetail && lookupEmployee.EditValue == null)
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
            if (ReportType == eReportType.LeaveDetail)
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
