using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL;
using Vision.DAL.Employee;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmSafariApplication : Template.frmCRUDTemplate
    {
        #region Fields
        SafariApplicationDAL DALObject;
        LeaveApplicationDAL LeaveApplicationDALObj;
        EmployeeDAL EmployeeDALObj;
        HolidayDAL HolidayDALObj;
        DAL.Settings.LocationDAL LocationDALObj;
        SafariApplicationNoPrefixDAL SafariApplicationNoPrefixDALObj;

        List<EmployeeLookupListModel> dsEmployee;
        List<SafariApplicationDayOffTypeViewModel> dsDayOffType;
        List<SafariApplicationNoPrefixLookupListModel> dsSafariApplicationNoPrefix;


        tblEmployee SelectedEmployee;
        #endregion

        #region Properties
        decimal SafariDays_;
        public decimal SafariDays
        {
            get
            {
                return SafariDays_;
            }
            set
            {
                SafariDays_ = value;
                txtNofDays.EditValue = SafariDays_;
            }
        }

        #endregion

        #region Constructor
        public frmSafariApplication()
        {
            InitializeComponent();
            DALObject = new SafariApplicationDAL();
            EmployeeDALObj = new EmployeeDAL();
            HolidayDALObj = new HolidayDAL();
            LocationDALObj = new DAL.Settings.LocationDAL();
            SafariApplicationNoPrefixDALObj = new SafariApplicationNoPrefixDAL();
            LeaveApplicationDALObj = new LeaveApplicationDAL();

            FirstControl = lookupEmployee;
        }
        #endregion

        #region Template
        public override void InitializeDefaultValues()
        {
            deSafariApplicationDate.EditValue = DateTime.Now.Date;

            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                if(dsSafariApplicationNoPrefix.Count >0 )
                {
                    lookupSafariApplicationNoPrefix.EditValue = dsSafariApplicationNoPrefix.FirstOrDefault().SafariApplicationNoPrefixID;
                }
            }

            SafariApplicationDayDetailBindingSource.Clear();
            deDateFrom.EditValue = null;
            deDateTo.EditValue = null;
            lookupEmployee.EditValue = null;
            SelectedEmployee = null;
        }

        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsSafariApplicationNoPrefix = SafariApplicationNoPrefixDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupSafariApplicationNoPrefix.Properties.ValueMember = "SafariApplicationNoPrefixID";
            lookupSafariApplicationNoPrefix.Properties.DisplayMember = "SafariApplicationNoPrefixName";
            lookupSafariApplicationNoPrefix.Properties.DataSource = dsSafariApplicationNoPrefix;

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            repositoryItemLookUpEdit_DayOffType.ValueMember = "SafariDayOffType";
            repositoryItemLookUpEdit_DayOffType.DisplayMember = "SafariDayOffTypeName";
            //repositoryItemLookUpEdit_DayOffType.DataSource = SafariApplicationDayOffTypeViewModel.GetList();
            dsDayOffType = SafariApplicationDayOffTypeViewModel.GetList().Where(r => r.SafariDayOffType == eSafariDayOffType.FullDay).ToList();
            repositoryItemLookUpEdit_DayOffType.DataSource = dsDayOffType;
            //dsDayOffType = SafariApplicationDayOffTypeViewModel.GetList().Where(r => r.SafariDayOffType == eSafariDayOffType.FirstHalf || r.SafariDayOffType == eSafariDayOffType.SecondHalf || r.SafariDayOffType == eSafariDayOffType.FullDay).ToList();

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblSafariApplication SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblSafariApplication();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((SafariApplicationEditListModel)EditRecordDataSource).SafariApplicationID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.SafariApplicationDate = deSafariApplicationDate.DateTime.Date;
            SaveModel.SafariApplicationNoPrefixID = (int)lookupSafariApplicationNoPrefix.EditValue;
            SaveModel.SafariApplicationNo = Model.CommonFunctions.ParseInt(txtSafariApplicationNo.Text);
            SaveModel.EmployeeID = (int)lookupEmployee.EditValue;
            SaveModel.FromDate = deDateFrom.DateTime.Date;
            SaveModel.ToDate = deDateTo.DateTime.Date;
            SaveModel.NofSafariDays = Model.CommonFunctions.ParseDecimal(txtNofDays.Text);
            SaveModel.Remarks = txtRemarks.Text;

            // if new record or document has been changed then update it.
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || SaveModel.ApplicationDocumentFileName != txtDocument.Text)
            {
                SaveModel.ApplicationDocumentFileName = null;
                if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
                {
                    string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_SafariApplicationDocument));
                    string DocumentNewFileName = Path.Combine(DocumentNewPath,
                        "SAD" + CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                        SaveModel.SafariApplicationNo.ToString("0000000000") + Path.GetExtension(txtDocument.Text));
                    try
                    {
                        if (!Directory.Exists(DocumentNewPath))
                        {
                            Directory.CreateDirectory(DocumentNewPath);
                        }
                        // Allow to overwrite the document only if in edit mode 
                        File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.SafariApplicationID != 0));
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
            }

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel,
                ((IEnumerable<SafariApplicationDayDetail>)SafariApplicationDayDetailBindingSource.List)
                .Where(r => r.SafariDayOffType == eSafariDayOffType.FirstHalf ||
                            r.SafariDayOffType == eSafariDayOffType.SecondHalf ||
                            r.SafariDayOffType == eSafariDayOffType.FullDay).ToList());

            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            SafariApplicationEditListModel EditingRecord = (SafariApplicationEditListModel)RecordToFill;
            tblSafariApplication SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.SafariApplicationID);

            if (SaveModel == null)
            {
                return;
            }

            deSafariApplicationDate.DateTime = SaveModel.SafariApplicationDate;
            lookupSafariApplicationNoPrefix.EditValue = SaveModel.SafariApplicationNoPrefixID;
            txtSafariApplicationNo.EditValue = SaveModel.SafariApplicationNo;
            lookupEmployee.EditValue = SaveModel.EmployeeID;
            deDateFrom.EditValue = SaveModel.FromDate;
            deDateTo.EditValue = SaveModel.ToDate;

            SafariDays = SaveModel.NofSafariDays;

            txtRemarks.Text = SaveModel.Remarks;
            txtDocument.Text = SaveModel.ApplicationDocumentFileName;


            LoadDayDetail();
            var ListDayDetail = (IEnumerable<SafariApplicationDayDetail>)SafariApplicationDayDetailBindingSource.List;
            foreach (var date in SaveModel.tblSafariApplicationDayDetails)
            {
                var SafariDate = ListDayDetail.FirstOrDefault(r => r.SafariDate == date.SafariDate);
                if (SafariDate != null)
                {
                    SafariDate.SafariDayOffType = (eSafariDayOffType)date.SafariType;
                }
            }
            base.FillSelectedRecordInContent(RecordToFill);
        }
        #endregion

        #region Validation
        private void lookupSafariApplicationNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            if (lookupSafariApplicationNoPrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupSafariApplicationNoPrefix, "Please select Prefix");
            }
            else
            {
                ErrorProvider.SetError(lookupSafariApplicationNoPrefix, "");
            }
        }

        private void deSafariApplicationDate_Validating(object sender, CancelEventArgs e)
        {
            if (deSafariApplicationDate.EditValue == null)
            {
                ErrorProvider.SetError(deSafariApplicationDate, "Please select Safari application date.");
            }
            else
            {
                ErrorProvider.SetError(deSafariApplicationDate, "");
            }
        }

        private void txtSafariApplicationNo_Validating(object sender, CancelEventArgs e)
        {
            if (Model.CommonFunctions.ParseInt(txtSafariApplicationNo.Text) == 0)
            {
                ErrorProvider.SetError(txtSafariApplicationNo, "Please enter Safari application number.");
            }
            else
            {
                ErrorProvider.SetError(txtSafariApplicationNo, "");
            }
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if (deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please select date from.");
            }
            //else if (deDateTo.DateTime < deDateFrom.DateTime)
            //{
            //    ErrorProvider.SetError(deDateFrom, "Date from can not be greater than date to");
            //}
            else if (deDateFrom.EditValue == null && DALObject.CheckDuplicateSafariApplication((int)lookupEmployee.EditValue, deDateFrom.DateTime, deDateTo.DateTime,
                (FormCurrentUI == eFormCurrentUI.Edit ? ((SafariApplicationEditListModel)EditRecordDataSource).SafariApplicationID : 0)))
            {
                ErrorProvider.SetError(deDateTo, "Safari application already entered for the selected or similar date range.");
            }
            else if (deDateFrom.EditValue == null && LeaveApplicationDALObj.CheckDuplicateLeaveApplication((int)lookupEmployee.EditValue, deDateFrom.DateTime, deDateTo.DateTime, 0))
            {
                ErrorProvider.SetError(deDateTo, "Safari application already entered for the selected or similar date range.");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, "");
            }
        }

        private void deDateTo_Validating(object sender, CancelEventArgs e)
        {
            if (deDateTo.EditValue == null)
            {
                ErrorProvider.SetError(deDateTo, "Please select date to");
            }
            else if (deDateTo.DateTime < deDateFrom.DateTime)
            {
                ErrorProvider.SetError(deDateTo, "Date to can not be less than date from");
            }
            else if (DALObject.CheckDuplicateSafariApplication((int)lookupEmployee.EditValue, deDateFrom.DateTime, deDateTo.DateTime,
                (FormCurrentUI == eFormCurrentUI.Edit ? ((SafariApplicationEditListModel)EditRecordDataSource).SafariApplicationID : 0)))
            {
                ErrorProvider.SetError(deDateTo, "Safari application already entered for the selected or similar date range.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, "");
            }
        }

        #endregion

        #region Other Events 
        private void lookupSafariApplicationNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupSafariApplicationNoPrefix.EditValue != null)
            {
                txtSafariApplicationNo.EditValue = DALObject.GenerateSafariApplicationNo((int)lookupSafariApplicationNoPrefix.EditValue);
            }
            else
            {
                txtSafariApplicationNo.EditValue = 0;
            }
        }

        private void deDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if (deDateFrom.EditValue == null || deDateTo.EditValue == null || deDateTo.DateTime < deDateFrom.DateTime)
            {
                return;
            }
            LoadDayDetail();
        }

        private void deDateTo_EditValueChanged(object sender, EventArgs e)
        {
            if (deDateFrom.EditValue == null || deDateTo.EditValue == null || deDateTo.DateTime < deDateFrom.DateTime)
            {
                return;
            }
            LoadDayDetail();
        }

        private void lookupEmployee_EditValueChanged(object sender, EventArgs e)
        {
            if(lookupEmployee.EditValue == null)
            {
                SelectedEmployee = null;
            }
            else
            {
                SelectedEmployee = EmployeeDALObj.FindSaveModelByPrimeKey((int)lookupEmployee.EditValue);
            }
        }

        private void gridViewSafariDayDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colDayOffType)
            {
                CalculateSafariDays();
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

        #endregion

        #region Helping Method 
        void LoadDayDetail()
        {
            SafariApplicationDayDetailBindingSource.Clear();
            if (lookupEmployee.EditValue == null || deDateFrom.EditValue == null || deDateTo.EditValue == null || deDateTo.DateTime < deDateFrom.DateTime)
            {
                return;
            }
            if (SelectedEmployee == null)
            {
                return;
            }

            var Location = (SelectedEmployee.tblEmployeeServiceDetail != null ? LocationDALObj.GetLatestWeekendSetting(SelectedEmployee.tblEmployeeServiceDetail.LocationID) : null);

            List<HolidayLookupListModel> holidays = HolidayDALObj.GetLookupList(deDateFrom.DateTime, deDateTo.DateTime);
            

            for (DateTime date = deDateFrom.DateTime; date <= deDateTo.DateTime; date = date.AddDays(1))
            {
                HolidayLookupListModel holiday = holidays.FirstOrDefault(r => r.DateFrom >= date && r.DateTo <= date);
                
                SafariApplicationDayDetail newDay = new SafariApplicationDayDetail()
                {
                    SafariDate = date,
                    SafariDayOffType = eSafariDayOffType.FullDay,
                    IsHolidayOrWeekEnd = (holiday != null),
                    Descr = (holiday != null ? holiday.HolidayName : ""),
                };

                if (Location != null)
                {
                    Model.Settings.eWeekDayType WeekendType =
                        (date.Date.DayOfWeek == DayOfWeek.Monday ? Location.Monday :
                        (date.Date.DayOfWeek == DayOfWeek.Tuesday ? Location.Tuesday :
                        (date.Date.DayOfWeek == DayOfWeek.Wednesday ? Location.Wednesday :
                        (date.Date.DayOfWeek == DayOfWeek.Thursday ? Location.Thursday :
                        (date.Date.DayOfWeek == DayOfWeek.Friday ? Location.Friday :
                        (date.Date.DayOfWeek == DayOfWeek.Saturday ? Location.Saturday :
                        (date.Date.DayOfWeek == DayOfWeek.Sunday ? Location.Sunday : Model.Settings.eWeekDayType.WorkingDay)))))));


                    if (WeekendType == Model.Settings.eWeekDayType.Weekend || WeekendType == Model.Settings.eWeekDayType.HalfDay)
                    {
                        newDay.IsHolidayOrWeekEnd = true;
                        newDay.Descr = (!String.IsNullOrWhiteSpace(newDay.Descr) ? newDay.Descr + ", " : "") + "Weekend";
                    }
                }

                SafariApplicationDayDetailBindingSource.Add(newDay);

                CalculateSafariDays();
            }
        }

        void CalculateSafariDays()
        {
            SafariDays = ((IEnumerable<SafariApplicationDayDetail>)SafariApplicationDayDetailBindingSource.List).Sum(r => r.SafariDayOffType == eSafariDayOffType.FullDay ? 1M : (r.SafariDayOffType == eSafariDayOffType.FirstHalf || r.SafariDayOffType == eSafariDayOffType.SecondHalf ? 0.5M : 0));
        }
        #endregion

    }
}
