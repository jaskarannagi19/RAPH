using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Reports.Employee;

namespace Vision.WinForm.Reports.Employee
{
    public partial class frmRepEmployeeList : Vision.WinForm.Template.frmNormalTemplate
    {
        DAL.Employee.EmployeeDAL EmployeeDAL;
        DAL.Reports.Employee.EmployeeListReportDAL ReportDALObj;

        string DefaultFormat;
        List<EmployeeListReportFormatLookupListModel> dsFormat { get; set; }

        public frmRepEmployeeList()
        {
            InitializeComponent();

            EmployeeDAL = new DAL.Employee.EmployeeDAL();
            ReportDALObj = new DAL.Reports.Employee.EmployeeListReportDAL();

            using (MemoryStream stream = new MemoryStream())
            {
                advBandedGridView1.SaveLayoutToStream(stream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(stream))
                {
                    DefaultFormat = reader.ReadToEnd();
                }
            }

        }

        public override void LoadLookupDataSource()
        {
            ucEmployeeFilter1.LoadLookupDataSource();
            LoadFormatLookup();
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            ucEmployeeFilter1.AssignLookupDataSource();
            AssignFormatLookup();
            base.AssignLookupDataSource();
        }

        void LoadFormatLookup()
        {
            dsFormat = ReportDALObj.GetFormatLookupModel();
            dsFormat.Insert(0, new EmployeeListReportFormatLookupListModel()
            {
                EmployeeListFormatID = -1,
                EmployeeListFormatName = "(new)"
            });
        }

        void AssignFormatLookup()
        {
            lookupFormat.Properties.DisplayMember = "EmployeeListFormatName";
            lookupFormat.Properties.ValueMember = "EmployeeListFormatID";
            lookupFormat.Properties.DataSource = dsFormat;
        }

        public override void AssignFormValues()
        {
            FillData();
            base.AssignFormValues();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel|*.xlsx";
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                gcEmployee.ExportToXlsx(sfd.FileName);

                if (MessageBox.Show("Do you want to open it ?", "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        void FillData()
        {
            ClearGrid();

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
            
            gcEmployee.DataSource = ReportDALObj.GetReportData(DepartmentID, DesignationID, LocationID, EmployementTypeID);
        }

        void ClearGrid()
        {
            gcEmployee.DataSource = null;
        }

        private void lookupFormat_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
            var newRecord = dsFormat.FirstOrDefault(r => r.EmployeeListFormatID == -1);
            if (newRecord != null)
            {
                newRecord.EmployeeListFormatName = e.DisplayValue.ToString();
                e.Handled = true;
                lookupFormat.EditValue = -1;
            }
        }

        private void btnSaveFormat_Click(object sender, EventArgs e)
        {
            if (lookupFormat.EditValue == null)
            {
                MessageBox.Show("Please select format or type a new format name", "Format Saving", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookupFormat.Focus();
                return;
            }

            string LayoutXML = null;
            using (MemoryStream stream = new MemoryStream())
            {
                advBandedGridView1.SaveLayoutToStream(stream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(stream))
                {
                    LayoutXML = reader.ReadToEnd();
                }
            }

            SavingResult res = ReportDALObj.SaveFormat((int)lookupFormat.EditValue, lookupFormat.Text, LayoutXML);
            SavingParemeter paras = new SavingParemeter()
            {
                SavingResult = res
            };
            AfterSaving(paras);

            if(res.ExecutionResult == eExecutionResult.CommitedSucessfuly && ((int?)lookupFormat.EditValue ?? 0) == -1)
            {
                LoadFormatLookup();
                AssignFormatLookup();
            }
        }

        private void lookupFormat_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupFormat.EditValue != null && (int)lookupFormat.EditValue > 0)
            {
                var FormatSaveModel = ReportDALObj.FindFormatByID((int)lookupFormat.EditValue);
                if (FormatSaveModel != null && !String.IsNullOrWhiteSpace(FormatSaveModel.GridFromat))
                {
                    using (Stream stream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(FormatSaveModel.GridFromat)))
                    {
                        advBandedGridView1.RestoreLayoutFromStream(stream);
                    }
                }
            }
        }
        
        private void btnResetFormat_Click(object sender, EventArgs e)
        {
            lookupFormat.EditValue = -1;
            using (Stream stream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(DefaultFormat)))
            {
                advBandedGridView1.RestoreLayoutFromStream(stream);
            }
        }
    }
}
