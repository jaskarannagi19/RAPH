using DevExpress.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.Employee;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmTAApprovalImportData : Vision.WinForm.Template.frmNormalTemplate
    {
        #region private Fields
        string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1};IMEX=0;'";
        string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1};IMEX=0;'";

        TAApprovalDAL DALObj;
        TAApprovalNoPrefixDAL TAApprovalNoPrefixDALObj;
        List<TAApprovalNoPrefixLookupListModel> dsApprovalNoPrefix;

        EmployeeDAL EmployeeDALObj;
        List<EmployeeLookupListModel> dsEmployee;

        IEnumerable<TAApprovalImportViewModel> dsImportedData;
        #endregion

        #region Constructor
        public frmTAApprovalImportData()
        {
            InitializeComponent();

            DALObj = new TAApprovalDAL();
            TAApprovalNoPrefixDALObj = new TAApprovalNoPrefixDAL();
            EmployeeDALObj = new EmployeeDAL();

            dsImportedData = tAApprovalImportViewModelBindingSource.Cast<TAApprovalImportViewModel>();
        }
        #endregion

        #region Template
        public override void LoadLookupDataSource()
        {
            dsApprovalNoPrefix = TAApprovalNoPrefixDALObj.GetLookupList();
            dsEmployee = EmployeeDALObj.GetLookupList();
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            repositoryItemLookUpEditEmployeeNoPrefix.DisplayMember = "TAApprovalNoPrefixName";
            repositoryItemLookUpEditEmployeeNoPrefix.ValueMember = "TAApprovalNoPrefixID";
            repositoryItemLookUpEditEmployeeNoPrefix.DataSource = dsApprovalNoPrefix;

            repositoryItemLookUpEditEmployee.DisplayMember = "EmployeeName";
            repositoryItemLookUpEditEmployee.ValueMember = "EmployeeID";
            repositoryItemLookUpEditEmployee.DataSource = dsEmployee;

            List<TAApprovalTypeViewModel> dsApprovalType = new List<TAApprovalTypeViewModel>()
            {
                new TAApprovalTypeViewModel() { ApprovalTypeID = eTAApprovalType.Overtime },
                new TAApprovalTypeViewModel() { ApprovalTypeID = eTAApprovalType.Lateness },
                new TAApprovalTypeViewModel() { ApprovalTypeID = eTAApprovalType.EarlyGoing },
                new TAApprovalTypeViewModel() { ApprovalTypeID = eTAApprovalType.WeekendWork },
            };

            repositoryItemLookUpEditApprovalFor.ValueMember = "ApprovalTypeID";
            repositoryItemLookUpEditApprovalFor.DisplayMember = "ApprovalTypeName";
            repositoryItemLookUpEditApprovalFor.DataSource = dsApprovalType;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            var RecordsToSave = dsImportedData.Where(r => r.CanImport && (r.SavingResult == null || r.SavingResult.ExecutionResult != eExecutionResult.CommitedSucessfuly));
            DALObj.SaveNewRecord(RecordsToSave);

            RecordsToSave = dsImportedData.Where(r => r.SavingResult != null && r.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly);
            if (!String.IsNullOrWhiteSpace(txtDocument.Text) && File.Exists(txtDocument.Text))
            {
                foreach (var ViewModel in RecordsToSave)
                {
                    DAL.tblTAApproval SaveModel = DALObj.FindSaveModelByPrimeKey(ViewModel.TAApprovalID);
                    if (SaveModel == null)
                    {
                        continue;
                    }

                    if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
                    {
                        string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_TAApprovalDocument));
                        string DocumentNewFileName = Path.Combine(DocumentNewPath,
                            "TAAD" +
                            CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") +
                            CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                            ViewModel.ApprovalNoPrefixName +
                            SaveModel.TAApprovalNo.ToString("0000000000") +
                            Path.GetExtension(txtDocument.Text));
                        try
                        {
                            if (!Directory.Exists(DocumentNewPath))
                            {
                                Directory.CreateDirectory(DocumentNewPath);
                            }
                            // Allow to overwrite the document only if in edit mode 
                            File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.TAApprovalID != 0));
                        }
                        catch (System.IO.IOException ex)
                        {
                            SavingResult res = new SavingResult();
                            DAL.CommonFunctions.GetFinalError(res, ex);
                            Paras.SavingResult = res;
                            return;
                        }
                        SaveModel.ApplicationDocumentFileName = DocumentNewFileName;
                    }

                    ViewModel.SavingResult = DALObj.SaveNewRecord(SaveModel);
                }
            }
            //--
            var SkippedRecords = dsImportedData.Where(r => !r.CanImport);
            foreach (var r in SkippedRecords)
            {
                r.SavingResult = new SavingResult()
                {
                    ExecutionResult = eExecutionResult.ValidationError,
                    ValidationError = "Skipped"
                };
            }

            gridviewImportData.RefreshData();

            base.SaveRecord(Paras);
        }
        
        #endregion

        #region Events
        private void txtFileName_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string SelectedFile = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xlsx;*.xls;|All File|*.*;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SelectedFile = ofd.FileName;
                }
            }
            if (SelectedFile != null)
            {
                txtFileName.Text = SelectedFile;
                ImportData(SelectedFile);
            }
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            ImportData(txtFileName.Text);
        }

        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            string SelectedFile = null;
            using (SaveFileDialog ofd = new SaveFileDialog())
            {
                ofd.Filter = "Excel Files|*.xls;|All File|*.*;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    SelectedFile = ofd.FileName;
                }
                else
                {
                    return;
                }
            }

            if (String.IsNullOrWhiteSpace(SelectedFile))
            {
                return;
            }

            if (System.IO.File.Exists(SelectedFile))
            {
                try
                {
                    System.IO.File.Delete(SelectedFile);
                }
                catch (Exception)
                {

                }
            }

            Workbook workbook = new Workbook();
            Worksheet worksheet = workbook.Worksheets[0];
            worksheet.Cells["A1"].Value = "Transaction Date";
            worksheet.Cells["B1"].Value = "Transaction No. Prefix";
            worksheet.Cells["C1"].Value = "Transaction No.";
            worksheet.Cells["D1"].Value = "Employee No.";
            worksheet.Cells["E1"].Value = "Approved Date";
            worksheet.Cells["F1"].Value = "Approved Hours";
            worksheet.Cells["G1"].Value = "Approved For";
            worksheet.Cells["H1"].Value = "Remarks";
            worksheet.Cells["I2"].Value = "Note: Approved For : 1-Overtime, 2-Lateness, 3-Early Going, 4-Weekend";

            try
            {
                workbook.SaveDocument(SelectedFile);
            }
            catch (Exception ex)
            {
                ex = DAL.CommonFunctions.GetFinalError(ex);
                Alit.WinformControls.MessageBox.Show("Error while trying to download excel template.\r\n" + (ex != null ? ex.Message : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //--
            //            string conStr = string.Format(Excel07ConString, SelectedFile, "Yes");

            //            try
            //            {
            //                using (OleDbConnection conn = new OleDbConnection(conStr))
            //                {
            //                    conn.Open();
            //                    OleDbCommand cmd = new OleDbCommand(@"CREATE TABLE [Sheet1] (
            //[TransactionDate] DateTime, 
            //[TransactionNoPrefix] string, 
            //[TransactionNo] int,
            //[EmployeeNo] int,
            //[ApprovedDate] DateTime,
            //[ApprovedHours] decimal(12,2),
            //[ApprovedFor] int,
            //[Remark] string,
            //[DocumandLocation] string,
            //[Note] string
            //);", conn);
            //                    cmd.ExecuteNonQuery();

            //                    cmd = new OleDbCommand(@"Insert into [Sheet1] ([Note]) Values('Approved For : 1-Overtime, 2-Lateness, 3-Early Going, 4-Weekend');", conn);
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                ex = DAL.CommonFunctions.GetFinalError(ex);
            //                Alit.WinformControls.MessageBox.Show("Error while trying to download excel template.\r\n" + (ex != null ? ex.Message : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }

            if (File.Exists(SelectedFile))
            {
                if (Alit.WinformControls.MessageBox.Show("Do you want to open template ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(SelectedFile);
                }
            }
        }

        private void gridviewImportData_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                var Row = (TAApprovalImportViewModel)tAApprovalImportViewModelBindingSource[e.ListSourceRowIndex];

                if (e.Column == colApprovalDate)
                {
                    e.DisplayText = Row.ApprovalDateError;
                }
                else if (e.Column == colApprovalNoPrefixName)
                {
                    e.DisplayText = Row.ApprovalNoPrefixNameError;
                }
                else if (e.Column == colApprovalNo)
                {
                    e.DisplayText = Row.ApprovalNoError;
                }
                else if (e.Column == colEmployeeName)
                {
                    e.DisplayText = Row.EmployeeNameError;
                }
                else if (e.Column == colApprovedDate)
                {
                    e.DisplayText = Row.ApprovedDateError;
                }
                else if (e.Column == colApprovedHours)
                {
                    e.DisplayText = Row.ApprovedHoursError;
                }
                else if (e.Column == colApprovalType)
                {
                    e.DisplayText = Row.ApprovalTypeIDError;
                }
            }
        }

        private void gridviewImportData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == colApprovalDate ||
            (e.Column == colApprovalNoPrefixName) ||
            (e.Column == colApprovalNo) ||
            (e.Column == colEmployeeName) ||
            (e.Column == colApprovedDate) ||
            (e.Column == colApprovedHours) ||
            (e.Column == colApprovalType))
            {
                if (e.CellValue != null)
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }
            else if (e.Column == colValidForImportStatus)
            {
                if (e.CellValue != null && e.CellValue.ToString() == "Yes")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }
            else if (e.Column == colSavingResultStatus)
            {
                var Row = (TAApprovalImportViewModel)gridviewImportData.GetRow(e.RowHandle);
                if (Row.SavingResult != null && Row.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else
                {
                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.FontStyleDelta = FontStyle.Bold;
                }
            }
        }

        private void gridviewImportData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            TAApprovalImportViewModel Row = (TAApprovalImportViewModel)gridviewImportData.GetRow(e.RowHandle);
            if (Row == null)
            {
                return;
            }

            gridviewImportData.PostEditor();
            if (e.Column == colApprovalNoPrefixName)
            {
                if (Row.ApprovalNoPrefixID == null || Row.ApprovalNoPrefixID == 0)
                {
                    Row.ApprovalNoPrefixNameError = "Approval No. Prefix not selected.";
                }
                else
                {
                    Row.ApprovalNoPrefixNameError = null;

                    // if duplicate found in current records, then generate new
                    if (Row.ApprovalNo == null || Row.ApprovalNo == 0 || dsImportedData.Where(r => r.RowNo != Row.RowNo).Any(r => r.ApprovalNoPrefixID == Row.ApprovalNoPrefixID && r.ApprovalNo == Row.ApprovalNo))
                    {
                        int No = DALObj.GenerateTAApprovalNo(Row.ApprovalNoPrefixID.Value);
                        No = Math.Max(No, (dsImportedData.Where(r => r.RowNo != Row.RowNo && Row.ApprovalNoPrefixID == Row.ApprovalNoPrefixID).Max(r => r.ApprovalNo) ?? 0) + 1);
                        Row.ApprovalNo = No;
                    }
                }
            }
            else if (e.Column == colApprovalNo)
            {

            }
            else if (e.Column == colEmployeeName)
            {
                var employee = dsEmployee.FirstOrDefault(r => r.EmployeeID == Row.EmployeeID);
                if(employee != null)
                {
                    Row.EmployeeNo = employee.EmployeeNo;
                    Row.EmployeeNoPrefixName = employee.EmployeeNoPrefix;
                }
            }
        }

        private void btnBrowseDocument_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDocument.Text = ofd.FileName;
                }
            }
        }

        private void btnOpenDocument_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
            {
                System.Diagnostics.Process.Start(txtDocument.Text);
            }
        }

        private void gridviewImportData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridviewImportData.FocusedColumn == colApprovalNo)
            {
                TAApprovalImportViewModel Row = (TAApprovalImportViewModel)gridviewImportData.GetFocusedRow();
                if (Row != null)
                {
                    if (Row.ApprovalNoPrefixID != null && e.Value != null)
                    {
                        int No = Model.CommonFunctions.ParseInt(e.Value.ToString());
                        if (DALObj.IsDuplicateRecord(Row.ApprovalNoPrefixID.Value, No, 0) || dsImportedData.Any(r => r.ApprovalNoPrefixID == Row.ApprovalNoPrefixID && r.ApprovalNo == No && r.RowNo != Row.RowNo))
                        {
                            Row.ApprovalNoError = e.Value.ToString() + ": Duplicate number not accepted.";
                            e.Value = null;
                        }
                    }
                }
            }
        }
        #endregion

        #region Methods
        void ImportData(string ImportFileName)
        {
            if (string.IsNullOrWhiteSpace(ImportFileName))
            {
                Alit.WinformControls.MessageBox.Show("Please select excel file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.IO.File.Exists(ImportFileName))
            {
                Alit.WinformControls.MessageBox.Show("Selected file doesn't exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string extension = System.IO.Path.GetExtension(ImportFileName).ToUpper();
            if (extension != ".XLS" && extension != ".XLSX")
            {
                if (Alit.WinformControls.MessageBox.Show(this, "Selected file is not seems to be valid excel file. Do you want to continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            //--
            tAApprovalImportViewModelBindingSource.Clear();

            if (extension.ToUpper() != ".XLS" && extension.ToUpper() != ".XLSX")
            {
                if (Alit.WinformControls.MessageBox.Show(this, "Selected file is seems to be Not valid excel file. Do you want to continue ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            string conStr = string.Empty;
            if (extension == ".xlsx")
            {
                conStr = string.Format(Excel07ConString, ImportFileName, "Yes");
            }
            else
            {
                conStr = string.Format(Excel03ConString, ImportFileName, "Yes");
            }

            ShowWaitForm();

            try
            {
                DevExpress.DataAccess.Excel.ExcelDataSource myExcelSource = new DevExpress.DataAccess.Excel.ExcelDataSource();
                myExcelSource.FileName = ImportFileName;
                DevExpress.DataAccess.Excel.ExcelWorksheetSettings worksheetSettings = new DevExpress.DataAccess.Excel.ExcelWorksheetSettings(GetWorkSheetNameByIndex(ImportFileName, 0));
                myExcelSource.SourceOptions = new DevExpress.DataAccess.Excel.ExcelSourceOptions(worksheetSettings);
                myExcelSource.SourceOptions.SkipEmptyRows = true;
                myExcelSource.SourceOptions.UseFirstRowAsHeader = true;
                myExcelSource.Fill();

                System.Collections.IList list = ((IListSource)myExcelSource).GetList();
                DevExpress.DataAccess.Native.Excel.DataView dataView = (DevExpress.DataAccess.Native.Excel.DataView)list;

                try
                {
                    #region Decoding Data
                    for (int ri = 0; ri < dataView.Count; ri++)
                    {
                        DevExpress.DataAccess.Native.Excel.ViewRow dsRow = (DevExpress.DataAccess.Native.Excel.ViewRow)dataView[ri];

                        TAApprovalImportViewModel NewRecord = new TAApprovalImportViewModel()
                        {
                            RowNo = ri + 1
                        };
                        //--
                        object importvalue = null;

                        // Transaction Date (Approval Date)

                        importvalue = dataView.Columns[ImportFileColumnIndex_TransactionDate].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            DateTime dtvalue;
                            if (DateTime.TryParse(importvalue.ToString(), out dtvalue))
                            {
                                NewRecord.ApprovalDate = dtvalue;
                            }
                            else
                            {
                                NewRecord.ApprovalDateError = importvalue.ToString() + " : invalid value";
                            }
                        }
                        else
                        {
                            NewRecord.ApprovalDateError = "No value";
                        }

                        // TransactionNoPrefix
                        importvalue = dataView.Columns[ImportFileColumnIndex_TransactionNoPrefix].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            NewRecord.ApprovalNoPrefixName = importvalue.ToString();

                            string prefixToCheck = NewRecord.ApprovalNoPrefixName.Trim().ToUpper();
                            var Prefix = dsApprovalNoPrefix.FirstOrDefault(r => r.TAApprovalNoPrefixName.ToUpper() == prefixToCheck);
                            if (Prefix != null)
                            {
                                NewRecord.ApprovalNoPrefixID = Prefix.TAApprovalNoPrefixID;
                            }
                            else
                            {
                                NewRecord.ApprovalNoPrefixNameError = importvalue.ToString() + " : not found.";
                            }
                        }
                        else
                        {
                            NewRecord.ApprovalNoPrefixNameError = "No value.";
                        }

                        // TransactionNo
                        importvalue = dataView.Columns[ImportFileColumnIndex_TransactionNo].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            int value = 0;
                            if (int.TryParse(importvalue.ToString(), out value))
                            {
                                NewRecord.ApprovalNo = value;

                                //--
                                if (NewRecord.ApprovalNoPrefixID != null)
                                {
                                    if (DALObj.IsDuplicateRecord(NewRecord.ApprovalNoPrefixID.Value, NewRecord.ApprovalNo.Value, 0))
                                    {
                                        NewRecord.ApprovalNo = null;
                                        NewRecord.ApprovalNoError = importvalue.ToString() + " : duplicate value can not accepted.";
                                    }
                                }
                            }
                            else
                            {
                                NewRecord.ApprovalNoError = importvalue.ToString() + " : invalid value";
                            }
                        }
                        else
                        {
                            NewRecord.ApprovalNoError = "No value";
                        }

                        // EmployeeNo
                        importvalue = dataView.Columns[ImportFileColumnIndex_EmployeeNo].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            int value = 0;
                            if (int.TryParse(importvalue.ToString(), out value))
                            {
                                NewRecord.EmployeeNo = value;

                                var Employee = dsEmployee.FirstOrDefault(r => r.EmployeeNo == NewRecord.EmployeeNo);

                                if (Employee != null)
                                {
                                    NewRecord.EmployeeID = Employee.EmployeeID;
                                    NewRecord.EmployeeNoPrefixName = Employee.EmployeeNoPrefix;
                                    NewRecord.EmployeeName = Employee.EmployeeName;
                                }
                                else
                                {
                                    NewRecord.EmployeeNameError = importvalue.ToString() + " : not found";
                                }
                            }
                            else
                            {
                                NewRecord.EmployeeNameError = importvalue.ToString() + " : invalid value";
                            }
                        }
                        else
                        {
                            NewRecord.EmployeeNameError = "No value";
                        }

                        // Approved Date
                        importvalue = dataView.Columns[ImportFileColumnIndex_ApprovedDate].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            DateTime value;
                            if (DateTime.TryParse(importvalue.ToString(), out value))
                            {
                                NewRecord.ApprovedDate = value;
                            }
                            else
                            {
                                NewRecord.ApprovedDateError = importvalue.ToString() + " : invalid value";
                            }
                        }
                        else
                        {
                            NewRecord.ApprovedDateError = "No value";
                        }


                        // ApprovedHours
                        importvalue = dataView.Columns[ImportFileColumnIndex_ApprovedHours].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            decimal value;
                            if (decimal.TryParse(importvalue.ToString(), out value))
                            {
                                NewRecord.ApprovedHours = value;
                            }
                            else
                            {
                                NewRecord.ApprovedHoursError = importvalue.ToString() + " : invalid value";
                            }
                        }
                        else
                        {
                            NewRecord.ApprovedHoursError = "No value";
                        }


                        // ApprovedFor
                        importvalue = dataView.Columns[ImportFileColumnIndex_ApprovedFor].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            int value;
                            if (int.TryParse(importvalue.ToString(), out value) && value >= 1 && value <= 4)
                            {

                                NewRecord.ApprovalTypeID = (eTAApprovalType)(value - 1);
                            }
                            else
                            {
                                NewRecord.ApprovalTypeIDError = importvalue.ToString() + " : invalid value";
                            }
                        }
                        else
                        {
                            NewRecord.ApprovalTypeIDError = "No value";
                        }


                        // Remark
                        importvalue = dataView.Columns[ImportFileColumnIndex_Remark].GetValue(dsRow);
                        if (importvalue != null)
                        {
                            NewRecord.Remark = importvalue.ToString();
                        }

                        //// DocumandLocation
                        //importvalue = dataView.Columns[ImportFileColumnIndex_DocumandLocation].GetValue(dsRow);
                        //if (importvalue != null)
                        //{
                        //    NewRecord.DocumentLocation = importvalue.ToString();
                        //}


                        //// Check - Valid for Import
                        //if (NewRecord.ApprovalDate != null && NewRecord.ApprovalNoPrefixID != null && NewRecord.ApprovalNo != null &&
                        //    NewRecord.ApprovalTypeID != null && NewRecord.EmployeeID != null &&
                        //    NewRecord.ApprovedDate != null && NewRecord.ApprovedHours != null)
                        //{
                        //    NewRecord.ValidForImport = true;
                        //}
                        //else
                        //{
                        //    NewRecord.ValidForImport = false;
                        //}
                        //--
                        tAApprovalImportViewModelBindingSource.Add(NewRecord);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    ex = DAL.CommonFunctions.GetFinalError(ex);
                    CloseWaitForm();
                    Alit.WinformControls.MessageBox.Show("Error while trying to decode excel file.\r\n" + (ex != null ? ex.Message : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ex = DAL.CommonFunctions.GetFinalError(ex);
                CloseWaitForm();
                Alit.WinformControls.MessageBox.Show("Error while trying to connect excel file.\r\n" + (ex != null ? ex.Message : ""), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CloseWaitForm();
        }

        private string GetWorkSheetNameByIndex(string FileName, int p)
        {
            DevExpress.Spreadsheet.Workbook workbook = new Workbook();
            using (FileStream stream = new FileStream(FileName, FileMode.Open))
            {
                workbook.LoadDocument(stream, DocumentFormat.OpenXml);
            }
            return workbook.Worksheets[p].Name;
        }

        public const int ImportFileColumnIndex_TransactionDate = 0;
        public const int ImportFileColumnIndex_TransactionNoPrefix = 1;
        public const int ImportFileColumnIndex_TransactionNo = 2;
        public const int ImportFileColumnIndex_EmployeeNo = 3;
        public const int ImportFileColumnIndex_ApprovedDate = 4;
        public const int ImportFileColumnIndex_ApprovedHours = 5;
        public const int ImportFileColumnIndex_ApprovedFor = 6;
        public const int ImportFileColumnIndex_Remark = 7;
        public const int ImportFileColumnIndex_DocumandLocation = 8;

        #endregion
    }
}
