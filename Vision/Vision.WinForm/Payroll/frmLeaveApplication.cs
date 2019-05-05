using DevExpress.XtraGrid.Views.Base;
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
    public partial class frmLeaveApplication : Template.frmCRUDTemplate
    {
        #region Fields
        LeaveApplicationDAL DALObject;
        SafariApplicationDAL SafariApplicationDALObj;
        EmployeeDAL EmployeeDALObj;
        LeaveTypeDAL LeaveTypeDALObj;
        HolidayDAL HolidayDALObj;
        DAL.Settings.LocationDAL LocationDALObj;
        LeaveApplicationNoPrefixDAL LeaveApplicationNoPrefixDALObj;

        List<EmployeeLookupListModel> dsEmployee;
        List<LeaveTypeLookupListModel> dsLeaveType;
        List<LeaveApplicationDayOffTypeViewModel> dsDayOffType;
        List<LeaveApplicationNoPrefixLookupListModel> dsLeaveApplicationNoPrefix;

        tblEmployee SelectedEmployee;
        tblLeaveType SelectedLeaveType;
        #endregion

        #region Properties
        decimal LeaveBalance_;
        public decimal LeaveBalance
        {
            get
            {
                return LeaveBalance_;
            }
            set
            {
                LeaveBalance_ = value;
                txtLeaveBalance.EditValue = LeaveBalance_;
            }
        }

        decimal LeaveDays_;
        public decimal LeaveDays
        {
            get
            {
                return LeaveDays_;
            }
            set
            {
                LeaveDays_ = value;
                txtNofDays.EditValue = LeaveDays_;
            }
        }

        decimal AbsentDays_;
        public decimal AbsentDays
        {
            get
            {
                return AbsentDays_;
            }
            set
            {
                AbsentDays_ = value;
                txtNofAbsents.EditValue = AbsentDays_;
            }
        }

        #endregion

        #region Constructor
        public frmLeaveApplication()
        {
            InitializeComponent();
            DALObject = new LeaveApplicationDAL();
            EmployeeDALObj = new EmployeeDAL();
            LeaveTypeDALObj = new LeaveTypeDAL();
            HolidayDALObj = new HolidayDAL();
            LocationDALObj = new DAL.Settings.LocationDAL();
            LeaveApplicationNoPrefixDALObj = new LeaveApplicationNoPrefixDAL();
            SafariApplicationDALObj = new SafariApplicationDAL();

            FirstControl = lookupLeaveApplicationNoPrefix;
        }
        #endregion

        #region Template
        public override void InitializeDefaultValues()
        {
            deLeaveApplicationDate.EditValue = DateTime.Now.Date;

            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                //txtLeaveApplicationNo.EditValue = DALObject.GenerateLeaveApplicationNo();
                if (dsLeaveApplicationNoPrefix.Count > 0)
                {
                    lookupLeaveApplicationNoPrefix.EditValue = dsLeaveApplicationNoPrefix.First().LeaveApplicationNoPrefixID;
                }
            }

            leaveApplicationDayDetailBindingSource.Clear();
            deDateFrom.EditValue = null;
            deDateTo.EditValue = null;
            lookupEmployee.EditValue = null;
            lookupLeaveType.EditValue = null;

            grpLeaveDaysDetail.Expanded = false;
        }

        public override void LoadLookupDataSource()
        {
            dsEmployee = EmployeeDALObj.GetLookupList();
            dsLeaveType = LeaveTypeDALObj.GetLookupList();
            dsLeaveApplicationNoPrefix = LeaveApplicationNoPrefixDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupLeaveApplicationNoPrefix.Properties.DisplayMember = "LeaveApplicationNoPrefixName";
            lookupLeaveApplicationNoPrefix.Properties.ValueMember = "LeaveApplicationNoPrefixID";
            lookupLeaveApplicationNoPrefix.Properties.DataSource = dsLeaveApplicationNoPrefix;

            lookupEmployee.Properties.ValueMember = "EmployeeID";
            lookupEmployee.Properties.DisplayMember = "EmployeeName";
            lookupEmployee.Properties.DataSource = dsEmployee;

            lookupLeaveType.Properties.ValueMember = "LeaveTypeID";
            lookupLeaveType.Properties.DisplayMember = "LeaveTypeName";
            //lookupLeaveType.Properties.DataSource = dsLeaveType;

            repositoryItemLookUpEdit_DayOffType.ValueMember = "LeaveDayOffType";
            repositoryItemLookUpEdit_DayOffType.DisplayMember = "LeaveDayOffTypeName";
            repositoryItemLookUpEdit_DayOffType.DataSource = LeaveApplicationDayOffTypeViewModel.GetList();
            dsDayOffType = LeaveApplicationDayOffTypeViewModel.GetList().Where(r => r.LeaveDayOffType == eLeaveDayOffType.FirstHalf || r.LeaveDayOffType == eLeaveDayOffType.SecondHalf || r.LeaveDayOffType == eLeaveDayOffType.FullDay).ToList();

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLeaveApplication SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblLeaveApplication();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LeaveApplicationEditListModel)EditRecordDataSource).LeaveApplicationID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LeaveApplicationDate = deLeaveApplicationDate.DateTime.Date;
            SaveModel.LeaveApplicationNoPrefixID = (int)lookupLeaveApplicationNoPrefix.EditValue;
            SaveModel.LeaveApplicationNo = Model.CommonFunctions.ParseInt(txtLeaveApplicationNo.Text);
            SaveModel.EmployeeID = (int)lookupEmployee.EditValue;
            SaveModel.LeaveTypeID = (int)lookupLeaveType.EditValue;
            SaveModel.FromDate = deDateFrom.DateTime.Date;
            SaveModel.ToDate = deDateTo.DateTime.Date;
            SaveModel.NofLeaves = Model.CommonFunctions.ParseDecimal(txtNofDays.Text);
            SaveModel.Remarks = txtRemarks.Text;

            // if new record or document has been changed then update it.
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || SaveModel.ApplicationDocumentFileName != txtDocument.Text)
            {
                SaveModel.ApplicationDocumentFileName = null;
                if (!String.IsNullOrWhiteSpace(txtDocument.Text) && System.IO.File.Exists(txtDocument.Text))
                {
                    string DocumentNewPath = Path.GetFullPath(Path.Combine(CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LeaveApplicationDocument));
                    string DocumentNewFileName = Path.Combine(DocumentNewPath,
                        "LAD" + CommonProperties.LoginInfo.LoggedInCompany.CompanyID.ToString("000") + CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID.ToString("000") +
                        SaveModel.LeaveApplicationNo.ToString("0000000000") + Path.GetExtension(txtDocument.Text));
                    try
                    {
                        if (!Directory.Exists(DocumentNewPath))
                        {
                            Directory.CreateDirectory(DocumentNewPath);
                        }
                        // Allow to overwrite the document only if in edit mode 
                        File.Copy(txtDocument.Text, DocumentNewFileName, (SaveModel.LeaveApplicationID != 0));
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
                ((IEnumerable<LeaveApplicationDayDetail>)leaveApplicationDayDetailBindingSource.List)
                .Where(r => r.LeaveDayOffType == eLeaveDayOffType.FirstHalf || 
                            r.LeaveDayOffType == eLeaveDayOffType.SecondHalf || 
                            r.LeaveDayOffType == eLeaveDayOffType.FullDay || 
                            r.LeaveDayOffType == eLeaveDayOffType.Absent).ToList());

            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            LeaveApplicationEditListModel EditingRecord = (LeaveApplicationEditListModel)RecordToFill;
            tblLeaveApplication SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.LeaveApplicationID);

            if(SaveModel == null)
            {
                return;
            }

            deLeaveApplicationDate.DateTime = SaveModel.LeaveApplicationDate;
            lookupLeaveApplicationNoPrefix.EditValue = SaveModel.LeaveApplicationNoPrefixID;
            txtLeaveApplicationNo.EditValue = SaveModel.LeaveApplicationNo;
            lookupEmployee.EditValue = SaveModel.EmployeeID;
            lookupLeaveType.EditValue = SaveModel.LeaveTypeID;
            deDateFrom.EditValue = SaveModel.FromDate;
            deDateTo.EditValue = SaveModel.ToDate;

            LeaveDays = SaveModel.NofLeaves;
            LeaveBalance = SaveModel.NofLeaves + LeaveTypeDALObj.GetLeaveBalance(SaveModel.EmployeeID, SaveModel.LeaveTypeID, deDateFrom.DateTime);

            txtRemarks.Text = SaveModel.Remarks;
            txtDocument.Text = SaveModel.ApplicationDocumentFileName;


            LoadDayDetail();
            var ListDayDetail = (IEnumerable<LeaveApplicationDayDetail>)leaveApplicationDayDetailBindingSource.List;
            foreach (var date in SaveModel.tblLeaveApplicationDayDetails)
            {
                var LeaveDate = ListDayDetail.FirstOrDefault(r => r.LeaveDate == date.LeaveDate);
                if (LeaveDate != null)
                {
                    LeaveDate.LeaveDayOffType = (eLeaveDayOffType)date.LeaveType;
                }
            }

            AbsentDays = ((IEnumerable<LeaveApplicationDayDetail>)leaveApplicationDayDetailBindingSource.List).Sum(r => r.LeaveDayOffType == eLeaveDayOffType.Absent ? 1M : 0);

            base.FillSelectedRecordInContent(RecordToFill);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LeaveApplicationEditListModel)EditRecordDataSource).LeaveApplicationID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LeaveApplicationEditListModel)EditRecordDataSource).LeaveApplicationID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LeaveApplicationEditListModel)EditRecordDataSource).LeaveApplicationID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LeaveApplicationEditListModel)EditRecordDataSource).LeaveApplicationID);
        }
        #endregion

        #region Validation

        private void deLeaveApplicationDate_Validating(object sender, CancelEventArgs e)
        {
            if(deLeaveApplicationDate.EditValue == null)
            {
                ErrorProvider.SetError(deLeaveApplicationDate, "Please select leave application date.");
            }
            else
            {
                ErrorProvider.SetError(deLeaveApplicationDate, "");
            }
        }

        private void lookupLeaveApplicationNoPrefix_Validating(object sender, CancelEventArgs e)
        {
            if(lookupLeaveApplicationNoPrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupLeaveApplicationNoPrefix, "Please select prefix");
            }
            else
            {
                ErrorProvider.SetError(lookupLeaveApplicationNoPrefix, "");
            }
        }

        private void txtLeaveApplicationNo_Validating(object sender, CancelEventArgs e)
        {
            if(Model.CommonFunctions.ParseInt (txtLeaveApplicationNo.Text) == 0)
            {
                ErrorProvider.SetError(txtLeaveApplicationNo, "Please enter leave application number.");
            }
            else
            {
                ErrorProvider.SetError(txtLeaveApplicationNo, "");
            }
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if(deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please select date from.");
            }
            //else if (deDateTo.DateTime < deDateFrom.DateTime)
            //{
            //    ErrorProvider.SetError(deDateFrom, "Date from can not be greater than date to");
            //}
            else if (deDateFrom.EditValue == null && DALObject.CheckDuplicateLeaveApplication((int)lookupEmployee.EditValue, deDateFrom.DateTime, deDateTo.DateTime, 
                (FormCurrentUI == eFormCurrentUI.Edit ? ((LeaveApplicationEditListModel)EditRecordDataSource).LeaveApplicationID : 0)))
            {
                ErrorProvider.SetError(deDateTo, "Leave application already entered for the selected or similar date range.");
            }
            else if (deDateFrom.EditValue == null && SafariApplicationDALObj.CheckDuplicateSafariApplication((int)lookupEmployee.EditValue, deDateFrom.DateTime, deDateTo.DateTime, 0))
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
            if(deDateTo.EditValue == null)
            {
                ErrorProvider.SetError(deDateTo, "Please select date to");
            }
            else if(deDateTo.DateTime < deDateFrom.DateTime)
            {
                ErrorProvider.SetError(deDateTo, "Date to can not be less than date from");
            }
            else if(DALObject.CheckDuplicateLeaveApplication((int)lookupEmployee.EditValue, deDateFrom.DateTime, deDateTo.DateTime,
                (FormCurrentUI == eFormCurrentUI.Edit ? ((LeaveApplicationEditListModel)EditRecordDataSource).LeaveApplicationID : 0)))
            {
                ErrorProvider.SetError(deDateTo, "Leave application already entered for the selected or similar date range.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, "");
            }
        }

        private void txtNofDays_Validating(object sender, CancelEventArgs e)
        {
            ErrorProvider.SetError(txtNofDays, "");
            if (LeaveBalance < LeaveDays && SelectedEmployee != null)
            {
                if (SelectedEmployee.TANegativeLeave == 0)
                {
                    ErrorProvider.SetError(txtNofDays, "Number of leaves can not be greater than balance leaves. ");
                }
            }
        }
        #endregion

        #region Other Events 
        private void lookupLeaveApplicationNoPrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupLeaveApplicationNoPrefix.EditValue != null)
            {
                txtLeaveApplicationNo.EditValue = DALObject.GenerateLeaveApplicationNo((int)lookupLeaveApplicationNoPrefix.EditValue);
            }
            else
            {
                txtLeaveApplicationNo.EditValue = 0;
            }
        }

        private void deDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            UpdateBalance();
            if(deDateFrom.EditValue == null || deDateTo.EditValue == null || deDateTo.DateTime < deDateFrom.DateTime)
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
            if (lookupEmployee.EditValue == null)
            {
                lookupLeaveType.Properties.DataSource = null;
                LeaveBalance = 0;
                SelectedEmployee = null;
            }
            else
            {
                UpdateBalance();
                    
                byte LeaveApplicableTo_Male = (byte)eLeaveApplicableTo.Male;
                byte LeaveApplicableTo_Female = (byte)eLeaveApplicableTo.Female;
                byte LeaveApplicableTo_Both = (byte)eLeaveApplicableTo.Both;

                byte Gender_Male = (byte)eGender.Male;
                byte Gender_Female = (byte)eGender.Female;

                SelectedEmployee = EmployeeDALObj.FindSaveModelByPrimeKey((int)lookupEmployee.EditValue);
                lookupLeaveType.Properties.DataSource = dsLeaveType.Where(r => r.ApplicableTo == LeaveApplicableTo_Both ||
                        (r.ApplicableTo == LeaveApplicableTo_Male && SelectedEmployee.Gender == Gender_Male) ||
                        (r.ApplicableTo == LeaveApplicableTo_Female && SelectedEmployee.Gender == Gender_Female));
            }
            LoadDayDetail();
        }

        private void lookupLeaveType_EditValueChanged(object sender, EventArgs e)
        {
            UpdateBalance();
            if (lookupLeaveType.EditValue != null)
            {
                SelectedLeaveType = LeaveTypeDALObj.FindSaveModelByPrimeKey((int)lookupLeaveType.EditValue);
            }
            else
            {
                SelectedLeaveType = null;
            }
            LoadDayDetail();
        }

        private void gridViewLeaveDayDetail_ShowingEditor(object sender, CancelEventArgs e)
        {
            LeaveApplicationDayDetail dsRow = (LeaveApplicationDayDetail)gridViewLeaveDayDetail.GetFocusedRow();
            if (dsRow == null)
            {
                return;
            }
            if (dsRow.LeaveDayOffType == eLeaveDayOffType.WeekEnd || dsRow.LeaveDayOffType == eLeaveDayOffType.Holiday || dsRow.LeaveDayOffType == eLeaveDayOffType.Absent)
            {
                e.Cancel = true;
            }
        }

        private void gridViewLeaveDayDetail_ShownEditor(object sender, EventArgs e)
        {
            ColumnView view = (ColumnView)sender;
            if (view.FocusedColumn == colDayOffType)
            {
                DevExpress.XtraEditors.LookUpEdit edit = (DevExpress.XtraEditors.LookUpEdit)view.ActiveEditor;
                edit.Properties.DataSource = dsDayOffType;
            }
            //repositoryItemLookUpEdit_DayOffType.ValueMember = "LeaveDayOffType";
            //repositoryItemLookUpEdit_DayOffType.DisplayMember = "LeaveDayOffTypeName";
            //repositoryItemLookUpEdit_DayOffType.DataSource = LeaveApplicationDayOffTypeViewModel.GetList();
        }

        private void gridViewLeaveDayDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colDayOffType)
            {
                CalculateLeaveDays();
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
        void UpdateBalance()
        {
            if (lookupEmployee.EditValue != null && lookupLeaveType.EditValue != null && deDateFrom.EditValue != null)
            {
                LeaveBalance = LeaveTypeDALObj.GetLeaveBalance((int)lookupEmployee.EditValue, (int)lookupLeaveType.EditValue, deDateFrom.DateTime);
            }
            else
            {
                LeaveBalance = 0;
            }
        }

        void LoadDayDetail()
        {
            leaveApplicationDayDetailBindingSource.Clear();
            if (lookupEmployee.EditValue == null || lookupLeaveType.EditValue == null || deDateFrom.EditValue == null || deDateTo.EditValue == null || deDateTo.DateTime < deDateFrom.DateTime)
            {
                return;
            }
            if(SelectedEmployee == null || SelectedLeaveType == null)
            {
                return;
            }
            
            var Location = (SelectedEmployee.tblEmployeeServiceDetail != null ? LocationDALObj.GetLatestWeekendSetting(SelectedEmployee.tblEmployeeServiceDetail.LocationID) : null);

            List<HolidayLookupListModel> holidays = null;
            if (!SelectedLeaveType.IncludePublicHoliday)
            {
                holidays = HolidayDALObj.GetLookupList(deDateFrom.DateTime, deDateTo.DateTime);
            }

            List<DateTime> RestDays = null;
            if ((Model.Employee.eTAWeekendtype)SelectedEmployee.TAWeekendType == eTAWeekendtype.RestDay)
            {
                RestDays = (new EmployeeRestDayDAL()).GetRestDates(SelectedEmployee.EmployeeID, deDateFrom.DateTime, deDateTo.DateTime);
            }

            decimal remainingLeaves = LeaveBalance;
            for (DateTime date = deDateFrom.DateTime; date <= deDateTo.DateTime; date = date.AddDays(1))
            {
                HolidayLookupListModel holiday = null;
                if (holidays != null)
                {
                    holiday = holidays.FirstOrDefault(r => r.DateFrom >= date && r.DateTo <= date);
                }

                LeaveApplicationDayDetail newDay = new LeaveApplicationDayDetail()
                {
                    LeaveDate = date,
                    LeaveDayOffType = (holiday != null ? eLeaveDayOffType.Holiday : eLeaveDayOffType.FullDay),
                    IsHolidayOrWeekEnd = (holiday != null),
                    Descr = (holiday != null ? holiday.HolidayName : ""),
                };

                if (Location != null && !SelectedLeaveType.IncludeWeekend)
                {
                    if ((Model.Employee.eTAWeekendtype)SelectedEmployee.TAWeekendType == eTAWeekendtype.Weekend)
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
                            newDay.LeaveDayOffType = (WeekendType == Model.Settings.eWeekDayType.HalfDay ? eLeaveDayOffType.SecondHalf : eLeaveDayOffType.WeekEnd);
                        }
                    }
                    else // Rest Day
                    {
                        if (RestDays.Any(r=> r == date.Date))
                        {
                            newDay.IsHolidayOrWeekEnd = true;
                            newDay.Descr = (!String.IsNullOrWhiteSpace(newDay.Descr) ? newDay.Descr + ", " : "") + "Rest day";
                            newDay.LeaveDayOffType = eLeaveDayOffType.WeekEnd;
                        }
                    }
                }

                decimal leavedays = (newDay.LeaveDayOffType == eLeaveDayOffType.FullDay ? 1 : (newDay.LeaveDayOffType == eLeaveDayOffType.FirstHalf || newDay.LeaveDayOffType == eLeaveDayOffType.SecondHalf ? 0.5M : 0));

                if (remainingLeaves < leavedays && SelectedEmployee.TANegativeLeave == (byte)eTANegativeLeave.NotAllowed
                        && newDay.LeaveDayOffType == eLeaveDayOffType.FullDay
                        && remainingLeaves >= leavedays - 0.5M)
                {
                    newDay.LeaveDayOffType = eLeaveDayOffType.FirstHalf;
                    leavedays = 0.5M;
                }

                if (remainingLeaves < leavedays && SelectedEmployee.TANegativeLeave == (byte)eTANegativeLeave.NotAllowed)
                {
                    newDay.LeaveDayOffType = eLeaveDayOffType.Absent;
                }
                else
                {
                    remainingLeaves -= leavedays;
                }

                leaveApplicationDayDetailBindingSource.Add(newDay);

                CalculateLeaveDays();
            }
        }

        void CalculateLeaveDays()
        {
            LeaveDays = ((IEnumerable<LeaveApplicationDayDetail>)leaveApplicationDayDetailBindingSource.List).Sum(r => r.LeaveDayOffType == eLeaveDayOffType.FullDay ? 1M : (r.LeaveDayOffType == eLeaveDayOffType.FirstHalf || r.LeaveDayOffType == eLeaveDayOffType.SecondHalf ? 0.5M : 0));

            AbsentDays = ((IEnumerable<LeaveApplicationDayDetail>)leaveApplicationDayDetailBindingSource.List).Sum(r => r.LeaveDayOffType == eLeaveDayOffType.Absent ? 1M : 0); 

            txtNofDays_Validating(null, null);
        }
        #endregion
    }
}
