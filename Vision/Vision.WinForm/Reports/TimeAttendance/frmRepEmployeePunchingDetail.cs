using DevExpress.XtraGrid.Columns;
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
    public partial class frmRepEmployeePunchingDetail : WinForm.Template.frmNormalTemplate
    {
        DAL.Employee.EmployeeDAL EmployeeDALObj;

        public frmRepEmployeePunchingDetail()
        {
            InitializeComponent();

            FirstControl = ucEmployeeFilter1;

            EmployeeDALObj = new DAL.Employee.EmployeeDAL();
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

            LoadEmployeeLookupDataSource();

            base.AssignLookupDataSource();
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            if (!base.ProcessValidationFormControls())
            {
                return;
            }

            gridControlData.DataSource = null;
            gridViewData.Columns.Clear();

            GetPunchDetail();

            gridControlData.Focus();
        }

        void GetPunchDetail()
        {
            if(lookupEmployee.EditValue == null)
            {
                Alit.WinformControls.MessageBox.Show("Please select an Employee.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            List<EmployeePunchingDetailReportModel> res = (new EmployeePunchingDetailDAL()).GetReport(ucEmployeeFilter1.DateFrom, ucEmployeeFilter1.DateTo, (int)lookupEmployee.EditValue);

            gridControlData.DataSource = res;
            txtNofRecords.EditValue = res.Count;

            gridControlData.RefreshDataSource();

            GridColumn column = null;
            column = gridViewData.Columns["AttendanceDate"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["InTime"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["OutTime"];
            column.MaxWidth = 100;
            column.MinWidth = 75;

            column = gridViewData.Columns["LogTime"];
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            column.DisplayFormat.FormatString = "g";
            column.MaxWidth = 200;
            column.MinWidth = 125;

            column = gridViewData.Columns["AttendanceStatus"];
            column.MaxWidth = 125;
            column.MinWidth = 75;

            column = gridViewData.Columns["TerminalType"];
            column.MaxWidth = 150;
            column.MinWidth = 100;

            column = gridViewData.Columns["TransactionID"];
            column.MaxWidth = 150;
            column.MinWidth = 100;

            column = gridViewData.Columns["DeviceSerialNo"];
            column.MaxWidth = 150;
            column.MinWidth = 100;
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

        private void ucEmployeeFilter1_FilterItemIDChanged(object sender, EventArgs e)
        {
                LoadEmployeeLookupDataSource();
        }

        void LoadEmployeeLookupDataSource()
        {
            int? DepartmentID = null;
            int? DesignationID = null;
            int? LocationID = null;
            int? EmployementTypeID = null;


            DepartmentID = (int?)ucEmployeeFilter1.DepartmentID;
            if (DepartmentID == -1) { DepartmentID = null; }

            DesignationID = (int?)ucEmployeeFilter1.DesignationID;
            if (DesignationID == -1) { DesignationID = null; }

            LocationID = (int?)ucEmployeeFilter1.LocationID;
            if (LocationID == -1) { LocationID = null; }

            EmployementTypeID = ucEmployeeFilter1.EmploymentType - 1;
            if (EmployementTypeID == -1) { EmployementTypeID = null; }

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = EmployeeDALObj.GetLookupList(DepartmentID, DesignationID, LocationID, EmployementTypeID);
        }

        private void ucEmployeeFilter1_Validating(object sender, CancelEventArgs e)
        {
            if (ucEmployeeFilter1.DateFrom > ucEmployeeFilter1.DateTo)
            {
                ErrorProvider.SetError(ucEmployeeFilter1, "Date from can not less than date to");
            }
            else
            {
                ErrorProvider.SetError(ucEmployeeFilter1, "");
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Vision.DAL.BMDevice.TADataReceiverDAL DALObj = new Vision.DAL.BMDevice.TADataReceiverDAL();
            var res = DALObj.SaveEmployeeAttendanceDetail(new Vision.Model.BMDevice.ReceivedMessageViewModel()
            {
                EmployeeTACode = Model.CommonFunctions.ParseInt(txtTACode.Text),
                LogTime = dtLogDateTime.DateTime,
                PunchType = txtLogType.Text,
            });
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                btnGetReport.PerformClick();
            }
            else
            {
                MessageBox.Show(res.ExecutionResult == eExecutionResult.ValidationError ? res.ValidationError : res.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
