using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Reports.Employee;

namespace Vision.WinForm.Reports.Employee
{
    public partial class frmRepEmployementStatusReport : Vision.WinForm.Template.frmNormalTemplate
    {
        DAL.Reports.Employee.EmployementStatusReportDAL ReportDALObj;
        DAL.Employee.EmployeeDAL EmployeeDALObj;

        public frmRepEmployementStatusReport()
        {
            InitializeComponent();

            ucEmployeeFilter1.EmploymentType = 0;
            EmployeeDALObj = new DAL.Employee.EmployeeDAL();
            ReportDALObj = new DAL.Reports.Employee.EmployementStatusReportDAL();
            DateTime DateTo = DateTime.Now.Date;
            DateTime DateFrom = (DateTo.DayOfWeek == DayOfWeek.Sunday ? DateTo : DateTo.AddDays(1 - (int)DateTo.DayOfWeek));

            var From = new DateTime(FromDate.DateTime.Year, FromDate.DateTime.Month, 1);
            var To = From.AddMonths(1).AddDays(-1);
            FromDate.DateTime = (DateTime.Now.Date < Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom ? Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom : DateTime.Now.Date);

            //--
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
        public override void AssignFormValues()
        {
            FillGrid();
            base.AssignFormValues();
        }

        void ClearGrid()
        {
            cmbReport.SelectedIndex = 0;
            txtNofRecords.EditValue = 0;
            gcEmployementStatusReport.DataSource = null;
        }

        void FillGrid()
        {
            if (!base.ProcessValidationFormControls()) { return; }

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
            int EmployementStatus = cmbReport.SelectedIndex;
            var data = ReportDALObj.GetReportData(From, To, DepartmentID, DesignationID, LocationID, EmployementTypeID, EmployementStatus);
            txtNofRecords.EditValue = data.Count();
            gcEmployementStatusReport.DataSource = data;

            if ((eReportEmployementStatus)cmbReport.SelectedIndex == eReportEmployementStatus.Active)
            {
                gbTermination.Visible = false;
                gbReInstatement.Visible = true;
            }
            else if ((eReportEmployementStatus)cmbReport.SelectedIndex == eReportEmployementStatus.Terminated)
            {
                gbTermination.Visible = true;
                gbReInstatement.Visible = false;
            }
            else if((eReportEmployementStatus)cmbReport.SelectedIndex == eReportEmployementStatus.NewEmployement)
            {
                gbTermination.Visible = false;
                gbReInstatement.Visible = true;
            }
        }

        private void btnGetReport_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbReport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel|*.xlsx";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                advBandedGridView1.ExportToXlsx(sfd.FileName);

                if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            advBandedGridView1.ShowRibbonPrintPreview();
            base.AfterSaving(Paras);
        }
    }
}
