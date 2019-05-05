using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class EmployeeAttendanceDAL
    {
        public List<EmployeeAttendanceViewModel> GetEmployeeAttendanceData(DateTime DateFrom, DateTime DateTo, int EmployeeID)
        {
            return GetEmployeeAttendanceData(DateFrom, DateTo, null, null, null, null, EmployeeID);
        }

        public List<EmployeeAttendanceViewModel> GetEmployeeAttendanceData(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            return GetEmployeeAttendanceData(DateFrom, DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID, null);
        }

        private List<EmployeeAttendanceViewModel> GetEmployeeAttendanceData(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID, int? EmployeeID)
        {
            DateFrom = DateFrom.Date;

            DateTo = DateTo.Date.Add(new TimeSpan(23, 59, 59));

            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte AttendanceType_IntegratedID = (byte)Model.Employee.eTAAttendanceType.Integrated;
                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;

                DateTime TodaysDate = DateTime.Now;
                var FilteredEmployees = from e in db.tblEmployees
                                        join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                                        from sd in gsd.DefaultIfEmpty()
                                        join jloc in db.tblLocations on sd.LocationID equals jloc.LocationID into gloc
                                        from loc in gloc.DefaultIfEmpty()

                                        where e.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                            e.TAAttendanceType == AttendanceType_IntegratedID &&
                                            e.rstate != RecordStatus_Deleted &&

                                            (sd != null
                                                && ((Model.Employee.eEmployementStatus)sd.EmployeementStatus) == Model.Employee.eEmployementStatus.Active
                                                && (((Model.Employee.eEmploymentType)sd.EmploymentType) != Model.Employee.eEmploymentType.Contract ||
                                                    (sd.ContractExpiryDate == null || sd.ContractExpiryDate >= TodaysDate))) &&

                                                (EmployeeID == null || e.EmployeeID == EmployeeID) &&
                                                (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                                (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                                (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                                (EmployementTypeID == null ||
                                                    (sd != null &&
                                                        (sd.EmploymentType == EmployementTypeID ||
                                                            (EmployementTypeID == 3 && (sd.EmploymentType == 1 || sd.EmploymentType == 2)))))
                                        select new { Employee = e, ServicdeDetail = sd, Location = loc };

                List<DateTime> Days = new List<DateTime>();
                for (DateTime date = DateFrom.Date; date <= DateTo; date = date.AddDays(1))
                {
                    Days.Add(date);
                }

                var EmployeeAttendanceDayDetails = (
                    from d in Days
                    from emp in FilteredEmployees

                    orderby emp.Employee.EmployeeID, d

                    select new EmployeeAttendanceViewModel()
                    {
                        EmployeeID = emp.Employee.EmployeeID,
                        LocationID = (emp.ServicdeDetail != null ? emp.ServicdeDetail.LocationID : 0),
                        Day = d,
                    }).ToList();

                /// Weekend
                var Weekends = (from r in db.tblLocationWeekendSettings
                                join l in db.tblLocations on r.LocationID equals l.LocationID
                                where l.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                    l.rstate != RecordStatus_Deleted &&
                                    (r.WEDateFrom == null || r.WEDateFrom >= DateFrom) && (r.WEDateTo == null || r.WEDateTo <= DateTo)
                                select r).ToList();

                // Holidays
                var Holidays = (from r in db.tblHolidays
                                where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                   r.rstate != RecordStatus_Deleted
                                select r).ToList();

                /// Leave Application
                var LeavApplications = (from r in db.tblLeaveApplicationDayDetails
                                        join lap in db.tblLeaveApplications on r.LeaveApplicationID equals lap.LeaveApplicationID
                                        join emp in FilteredEmployees on lap.EmployeeID equals emp.Employee.EmployeeID
                                        where lap.FromDate <= DateTo && lap.ToDate >= DateFrom && lap.rstate != RecordStatus_Deleted
                                        select new
                                        {
                                            EmployeeID = lap.EmployeeID,
                                            LeaveDate = r.LeaveDate,
                                            LeaveType = r.LeaveType,
                                        }).ToList();
                //--
                /// Safari Application
                var SafariApplications = (from r in db.tblSafariApplicationDayDetails
                                          join sap in db.tblSafariApplications on r.SafariApplicationID equals sap.SafariApplicationID
                                          join emp in FilteredEmployees on sap.EmployeeID equals emp.Employee.EmployeeID
                                          where sap.FromDate <= DateTo && sap.ToDate >= DateFrom && sap.rstate != RecordStatus_Deleted
                                          select new
                                          {
                                              EmployeeID = sap.EmployeeID,
                                              SafariDate = r.SafariDate,
                                              SafariType = r.SafariType,
                                          }).ToList();


                /// Rest Days
                var RestDays = (from r in db.tblEmployeeRestDays
                                join emp in FilteredEmployees on r.EmployeeID equals emp.Employee.EmployeeID
                                where r.RestDate >= DateFrom && r.RestDate <= DateTo
                                select new
                                {
                                    EmployeeID = r.EmployeeID,
                                    RestDate = r.RestDate,
                                }).ToList();


                // T & A Approval
                var TAApproval = (from r in db.tblTAApprovals
                                  join emp in FilteredEmployees on r.EmployeeID equals emp.Employee.EmployeeID
                                  where r.ApprovedDate >= DateFrom && r.ApprovedDate <= DateTo && r.rstate != RecordStatus_Deleted
                                  select new
                                  {
                                      EmployeeID = r.EmployeeID,
                                      ApprovedDate = r.ApprovedDate,
                                      ApprovedHour = r.ApprovedHours,
                                      ApprovalTypeID = (eTAApprovalType)r.ApprovalTypeID
                                  }).ToList();


                //// Employee Shift
                var EmployeeShifts = db.tblEmployeeShifts.ToList();
                //var EmployeeShiftType = (from r in FilteredEmployees
                //                         join jshift in db.tblEmployeeShifts on r.ServicdeDetail.EmployeeShiftID equals jshift.EmployeeShiftID into gshift
                //                         from shift in gshift.DefaultIfEmpty()
                //                         where r.ServicdeDetail != null
                //                         select new
                //                         {
                //                             EmployeeID = r.Employee.EmployeeID,
                //                             EmployeeShiftType = (Model.Employee.eEmployeeShiftType)r.ServicdeDetail.EmployeeShiftType,
                //                             EmployeeShiftID = (shift != null ? (int?)shift.EmployeeShiftID : null),
                //                             EmployeeShiftName = (shift != null ? shift.EmployeeShiftName : null),
                //                             ShiftStartTime = (r.ServicdeDetail != null && shift != null
                //                                              && ((Model.Employee.eEmployeeShiftType)r.ServicdeDetail.EmployeeShiftType) == Model.Employee.eEmployeeShiftType.Fixed ?
                //                                                  (TimeSpan?)shift.ShiftStartTime : null),
                //                             ShiftEndTime = (r.ServicdeDetail != null && shift != null
                //                                              && ((Model.Employee.eEmployeeShiftType)r.ServicdeDetail.EmployeeShiftType) == Model.Employee.eEmployeeShiftType.Fixed ?
                //                                                  (TimeSpan?)shift.ShiftEndTime : null),
                //                             LunchStart = (r.ServicdeDetail != null && shift != null
                //                                              && ((Model.Employee.eEmployeeShiftType)r.ServicdeDetail.EmployeeShiftType) == Model.Employee.eEmployeeShiftType.Fixed ?
                //                                                  (TimeSpan?)shift.SecondBreakStartTime : null),
                //                         }).ToList();

                //var RotatingEmployeeShiftAllocation = (from r in db.tblEmployeeShiftAllocations
                //                                       join s in db.tblEmployeeShifts on r.EmployeeShiftID equals s.EmployeeShiftID
                //                                       where r.WEDateFrom >= DateFrom && r.WEDateFrom <= DateTo
                //                                       select new
                //                                       {
                //                                           EmployeeID = r.EmployeeID,
                //                                           EmployeeShiftID = r.EmployeeShiftID,
                //                                           WEDateFrom = r.WEDateFrom,
                //                                           EmployeeShiftName = s.EmployeeShiftName,
                //                                           ShiftStartTime = s.ShiftStartTime,
                //                                           ShiftEndTime = s.ShiftEndTime,
                //                                           LunchStart = s.SecondBreakStartTime
                //                                       }).ToList();

                // Present Attedance Data
                var Attendances = (from r in db.tblEmployeeAttendances
                                   join emp in FilteredEmployees on r.EmployeeID equals emp.Employee.EmployeeID
                                   where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                    (DateFrom == null || r.AttendanceDate >= DateFrom) &&
                                    (DateTo == null || r.AttendanceDate <= DateTo)

                                   select new
                                   {
                                       EmployeeID = r.EmployeeID,
                                       AttendanceDate = r.AttendanceDate,
                                       InTime = r.InTime,
                                       OutTime = r.OutTime,
                                       EmployeeShiftID = r.EmployeeShiftID,
                                       ShiftStartTime = r.ShiftStartTime,
                                       ShiftEndTime = r.ShiftEndTime,
                                   }).ToList();



                // processing all data
                foreach (var Employee in FilteredEmployees)
                {
                    Model.Employee.eTAWeekendtype EmployeeWeekendType = (Model.Employee.eTAWeekendtype)Employee.Employee.TAWeekendType;
                    foreach (var att in EmployeeAttendanceDayDetails.Where(r => r.EmployeeID == Employee.Employee.EmployeeID))
                    {
                        #region  Get Actual data first
                        // Present
                        var present = Attendances.FirstOrDefault(r => r.EmployeeID == att.EmployeeID && r.AttendanceDate == att.Day);
                        if (present != null)
                        {

                            att.InTime = present.InTime;
                            att.OutTime = present.OutTime;
                            att.InDateTime = att.Day.Date.Add(present.InTime ?? present.ShiftStartTime ?? new TimeSpan());

                            // if night shift
                            if (present.ShiftEndTime < present.ShiftStartTime)
                            {
                                att.OutDateTime = att.Day.Date.AddDays(1).Add(present.OutTime ?? present.ShiftEndTime ?? new TimeSpan());
                            }
                            else
                            {
                                att.OutDateTime = att.Day.Date.Add(present.OutTime ?? present.ShiftEndTime ?? new TimeSpan());
                            }
                            //--
                            att.MissedPunch = (present.InTime == null || present.OutTime == null);

                            att.Present = eEmployeeAttendanceDayType.FullDay;

                            var EmployeeShift = EmployeeShifts.FirstOrDefault(r => r.EmployeeShiftID == present.EmployeeShiftID);
                            att.EmployeeShiftID = present.EmployeeShiftID;
                            att.EmployeeShiftName = (EmployeeShift != null ? EmployeeShift.EmployeeShiftName : null);
                            //--

                            // Determine is it half day or full day attendance
                            if (EmployeeShift.SecondBreakStartTime != null && ((present.InTime != null && present.InTime >= EmployeeShift.SecondBreakStartTime) || (present.OutTime != null && present.OutTime <= EmployeeShift.SecondBreakStartTime)))
                            {
                                // if in time was not missed punched and in time was after lunch start OR
                                //      Out time was not missed punched and out time was before lunch start 
                                //          then treat it as half day attendance.

                                att.Present = eEmployeeAttendanceDayType.HalfDay;
                            }
                            else
                            {
                                // if not half day
                                if (present.ShiftStartTime != null)
                                {
                                    if (att.InTime != null && att.InTime > present.ShiftStartTime.Value.Add(new TimeSpan(0, Employee.Location.GracePeriod, 0)))
                                    {
                                        att.LateIn = true;
                                    }
                                    if (att.OutTime != null && att.OutTime < present.ShiftEndTime.Value.Add(new TimeSpan(0, -Employee.Location.GracePeriod, 0)))
                                    {
                                        att.EarlyGoing = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            att.Present = eEmployeeAttendanceDayType.None;
                        }
                        att.ActualPresent = att.Present;

                        // weekend Or Restday
                        if (EmployeeWeekendType == Model.Employee.eTAWeekendtype.Weekend)
                        {
                            var rweekend = Weekends.Where(r => r.LocationID == att.LocationID && ((r.WEDateFrom == null || r.WEDateFrom <= att.Day) && (r.WEDateTo == null || r.WEDateTo >= att.Day))).OrderByDescending(r => r.WEDateFrom).FirstOrDefault();
                            if (rweekend != null)
                            {
                                var weekend = ((Model.Settings.eWeekDayType)(att.Day.DayOfWeek == DayOfWeek.Monday ? rweekend.Monday :
                                    (att.Day.DayOfWeek == DayOfWeek.Tuesday ? rweekend.Tuesday :
                                    (att.Day.DayOfWeek == DayOfWeek.Wednesday ? rweekend.Wednesday :
                                    (att.Day.DayOfWeek == DayOfWeek.Thursday ? rweekend.Thursday :
                                    (att.Day.DayOfWeek == DayOfWeek.Friday ? rweekend.Friday :
                                    (att.Day.DayOfWeek == DayOfWeek.Saturday ? rweekend.Saturday : rweekend.Sunday)))))));

                                att.ActualWeekend = (weekend == Model.Settings.eWeekDayType.Weekend ? eEmployeeWeekendDayType.Weekend : (weekend == Model.Settings.eWeekDayType.HalfDay ? eEmployeeWeekendDayType.HalfDayWeekend : eEmployeeWeekendDayType.None));
                            }
                        }
                        else
                        {
                            if (RestDays.Any(r => r.EmployeeID == Employee.Employee.EmployeeID && r.RestDate == att.Day))
                            {
                                att.ActualRestDay = eEmployeeRestDayDayType.RestDay;
                            }
                        }

                        // Holiday
                        var h = Holidays.FirstOrDefault(r => (!r.RepeatOnSameDate && att.Day >= r.FromDate && att.Day <= r.ToDate) ||
                                    (r.RepeatOnSameDate && att.Day.Month >= r.FromDate.Month && att.Day.Day >= r.FromDate.Day &&
                                                att.Day.Month <= r.ToDate.Month && att.Day.Day <= r.ToDate.Day));
                        if (h != null)
                        {
                            att.ActualHoliday = eEmployeeHolidayDayType.FullDay;
                        }

                        // Leave Application
                        var leaveapp = LeavApplications.FirstOrDefault(r => r.EmployeeID == att.EmployeeID && r.LeaveDate == att.Day);
                        if (leaveapp != null)
                        {

                            Model.Payroll.eLeaveDayOffType leavetype = ((Model.Payroll.eLeaveDayOffType)leaveapp.LeaveType);
                            switch (leavetype)
                            {
                                case eLeaveDayOffType.FullDay:
                                    att.ActualLeave = eEmployeeAttendanceDayType.FullDay;
                                    break;
                                case eLeaveDayOffType.FirstHalf:
                                case eLeaveDayOffType.SecondHalf:
                                    att.ActualLeave = eEmployeeAttendanceDayType.HalfDay;
                                    break;
                                    //case eLeaveDayOffType.Absent:
                                    //case eLeaveDayOffType.WeekEnd:
                                    //case eLeaveDayOffType.Holiday:
                                    //    DayDetail.LeaveApplication = eEmployeeAttendanceDayType.None;
                                    //    break;
                            }
                        }

                        // Safari
                        var safariapp = SafariApplications.FirstOrDefault(r => r.EmployeeID == att.EmployeeID && r.SafariDate == att.Day);
                        if (safariapp != null)
                        {
                            {
                                Model.Payroll.eSafariDayOffType safaritype = ((Model.Payroll.eSafariDayOffType)safariapp.SafariType);
                                att.ActualSafari = (safaritype == eSafariDayOffType.FullDay ? eEmployeeAttendanceDayType.FullDay :
                                    (safaritype == eSafariDayOffType.FirstHalf || safaritype == eSafariDayOffType.SecondHalf ? eEmployeeAttendanceDayType.HalfDay
                                        : eEmployeeAttendanceDayType.None));
                            }
                        }

                        att.Present = att.ActualPresent;
                        att.Weekend = att.ActualWeekend;
                        att.RestDay = att.ActualRestDay;
                        att.Holiday = att.ActualHoliday;
                        att.Leave = att.ActualLeave;
                        att.Safari = att.ActualSafari;
                        #endregion

                        #region Process attendance data according to conditions 
                        /// Safari
                        // Rule No. 31 to 34 is not gonna happen, that is invalid conditions, user have to deal with it manuall, software must have validation checkings for it
                        // Rule No. 35 to 37, If it is safari, and weekend THEN No weekend, full day safari
                        // Rule No. 38 to 40, If half day safari and weekend THEN Safari can not be half day, only full day will counted, No weekend
                        // Rule No. 41 to 48, If safari and Holidays, Presents THEN, only safari, nothing others.
                        // Safaris can not be of half day, on safari, present, leave, weekend, holiday nothing matters, it will be counted in safari only. 
                        if (att.Safari != eEmployeeAttendanceDayType.None)
                        {
                            att.Present = eEmployeeAttendanceDayType.None;
                            att.Absent = eEmployeeAttendanceDayType.None;
                            att.Weekend = eEmployeeWeekendDayType.None;
                            att.RestDay = eEmployeeRestDayDayType.None;
                            att.Leave = eEmployeeAttendanceDayType.None;
                            att.Holiday = eEmployeeHolidayDayType.None;

                            continue;
                        }


                        //Absent
                        // Rule No. 49 - No Present, No weeked, No Hliday, No Leave, No Safari THEN Full Day Absent.
                        // Rule No. 50 - Half Present, No weeked, No Hliday, No Leave, No Safari THEN Half Day Absent.
                        // Rule No. 51 - Full Day Present THEN No Absent -- Nothing to do, no explicit code required
                        // Rule No. 52 - No Present, Half Leave THEN Half Absent

                        // Absent in following scenarios
                        // Rule 51
                        if (att.Present != eEmployeeAttendanceDayType.FullDay)
                        {
                            // Rule 49 and 50
                            if (
                                (EmployeeWeekendType == Model.Employee.eTAWeekendtype.Weekend ?
                                    att.Weekend == eEmployeeWeekendDayType.None :
                                    att.RestDay == eEmployeeRestDayDayType.None) &&

                                att.Holiday == eEmployeeHolidayDayType.None &&
                                att.Leave == eEmployeeAttendanceDayType.None &&
                                att.Safari == eEmployeeAttendanceDayType.None)
                            {
                                att.Absent = (att.Present == eEmployeeAttendanceDayType.HalfDay ? eEmployeeAttendanceDayType.HalfDay : eEmployeeAttendanceDayType.FullDay);
                            }
                            // Rule 52
                            else if (att.Present == eEmployeeAttendanceDayType.None
                                && att.Leave == eEmployeeAttendanceDayType.HalfDay
                                && (EmployeeWeekendType == Model.Employee.eTAWeekendtype.Weekend ? att.Weekend == eEmployeeWeekendDayType.None : att.RestDay == eEmployeeRestDayDayType.None)
                                && att.Holiday == eEmployeeHolidayDayType.None
                                && att.Safari == eEmployeeAttendanceDayType.None)
                            {
                                att.Absent = eEmployeeAttendanceDayType.HalfDay;
                            }
                            else if (att.Present == eEmployeeAttendanceDayType.None
                                && att.Leave == eEmployeeAttendanceDayType.None
                                && (EmployeeWeekendType == Model.Employee.eTAWeekendtype.Weekend && att.Weekend == eEmployeeWeekendDayType.HalfDayWeekend)
                                && att.Holiday == eEmployeeHolidayDayType.None
                                && att.Safari == eEmployeeAttendanceDayType.None)
                            {
                                att.Absent = eEmployeeAttendanceDayType.HalfDay;
                            }
                        }

                        #region absent old procedure
                        //decimal AbsentCount = 1M - att.PresentCount;

                        //if (att.ActualWeekend == Model.Settings.eWeekDayType.Weekend)
                        //{
                        //    AbsentCount -= 1M;
                        //}
                        //else if (att.ActualWeekend == Model.Settings.eWeekDayType.HalfDay)
                        //{
                        //    AbsentCount -= 0.5M;
                        //}

                        //if (att.ActualHoliday == eEmployeeAttendanceDayType.FullDay)
                        //{
                        //    AbsentCount -= 1M;
                        //}
                        //else if (att.ActualHoliday == eEmployeeAttendanceDayType.HalfDay)
                        //{
                        //    AbsentCount -= 0.5M;
                        //}

                        //if (att.Leave == eEmployeeAttendanceDayType.FullDay)
                        //{
                        //    AbsentCount -= 1M;
                        //}
                        //else if (att.Leave == eEmployeeAttendanceDayType.HalfDay)
                        //{
                        //    AbsentCount -= 0.5M;
                        //}

                        //// Safaris are only full day. No Half day safari is possible.
                        //if (att.Safari != eEmployeeAttendanceDayType.None)
                        //{
                        //    AbsentCount -= 1M;
                        //}

                        ////
                        //if (AbsentCount == 0.5M)
                        //{
                        //    att.Absent = eEmployeeAttendanceDayType.HalfDay;
                        //}
                        //else if (AbsentCount == 1M)
                        //{
                        //    att.Absent = eEmployeeAttendanceDayType.FullDay;
                        //}
                        //else
                        //{
                        //    att.Absent = eEmployeeAttendanceDayType.None;
                        //}
                        #endregion
                        /// End Absent

                        // Present
                        // Rule No. 1, 2 and 3 -- Nothing to do

                        // Leave 
                        /// IF att.Leave is Full day or Half day, and it is weekend or holiday, it means that is included, if we are getting leave as full day or half day, then we have to process it, without any condition. all rules are automatically implemented, no need to do explicit coding here.

                        // Rule No. 15 - Leave Full Day, No Weekend THEN Leave Full Day
                        // Rule No. 16 - Leave Full Day, Weekend Half Day THEN Leave Half Day, No Weekend 
                        // Rule No. 17 - Leave Full Day, Full Day Weekend THEN No Leave, Full Day Weekend
                        // Rule No. 18 - Leave Half Day, No Weekend THEN Leave Half Day -- No need of explicit Coding
                        // Rule No. 19 - Leave Half Day, Half Day Weekend THEN No Leave, No Weekend
                        // Rule No. 20 - Leave Half Day, Full Day Weekend THEN No Leave, Full Day Weekend

                        /// Lave + Holiday 
                        // Rule No. 21 to 24 is implemented automatically, no need of explicit coding, 

                        /// Leave + Present 
                        // Rule No. 25 - Full Day Leave, No Present THEN Full Day Leave
                        // Rule No. 26 - Full Day Leave, Half Present THEN Half Leave, Half Present
                        // Rule No. 27 - Full Day Leave, Full Present THEN No Leave, Full Present
                        if (att.Leave == eEmployeeAttendanceDayType.FullDay && att.Present != eEmployeeAttendanceDayType.None)
                        {
                            att.Leave = (att.Present == eEmployeeAttendanceDayType.HalfDay ? eEmployeeAttendanceDayType.HalfDay : eEmployeeAttendanceDayType.None);
                        }

                        // Rule No. 28 - Half Leave, No Present THEN, Half Leave, No Present
                        // Rule No. 29 - Half Leave, Half Present THEN Half Leave, Half Present
                        // Rule No. 30 - Half Leave, Full Present THEN No Leave Full Present
                        // Rule No. 53 - Half Leave, Half Weekend, Half Present THEN Full Present, No Weekend, No Leave -- Auto processed no need of explicit coding.
                        if (att.Leave == eEmployeeAttendanceDayType.HalfDay && att.Present == eEmployeeAttendanceDayType.FullDay)
                        {
                            att.Leave = eEmployeeAttendanceDayType.None;
                        }

                        // Holiday
                        // Rule No. 10 - Full Day Holiday and No Present - Nothing to do
                        if (att.Holiday == eEmployeeHolidayDayType.FullDay)
                        {
                            // if it is holiday then no weekend
                            att.Weekend = eEmployeeWeekendDayType.None;

                            // Rule No. 11 - Full Day Holiday and Half Day Present - No Holiday counted and Full day Holiday Worked counted
                            // Rule No. 12 - Full Day Holiday and Full Day Present - No Holiday counted and Full day Holiday Worked counted
                            if (att.Present != eEmployeeAttendanceDayType.None)
                            {
                                att.Holiday = eEmployeeHolidayDayType.HolidayWorked;
                                att.Present = eEmployeeAttendanceDayType.None;
                            }
                        }

                        // Weekend
                        // Rule No. 4 - Full day weekend and No present - Nothing to do 
                        // Rule No. 5 - Half Day present and Full day weekend then Full day weekend worked
                        // Rule No. 6 - Full Day present and Full day weekend then Full day weekend worked
                        // Rule No. 13 and 14 -- Weekend is only applicable if there is no holiday on same day

                        // process if it is weekend half/full day 
                        if (EmployeeWeekendType == Model.Employee.eTAWeekendtype.Weekend
                            && (att.Weekend == eEmployeeWeekendDayType.Weekend || att.Weekend == eEmployeeWeekendDayType.HalfDayWeekend))
                        {
                            // If it is not a holiday then process
                            if (att.Holiday == eEmployeeHolidayDayType.None)
                            {
                                if (att.Weekend == eEmployeeWeekendDayType.Weekend && att.Present != eEmployeeAttendanceDayType.None)
                                {
                                    att.Weekend = eEmployeeWeekendDayType.WeekendWorked;
                                    att.Present = eEmployeeAttendanceDayType.None;
                                }
                                // Rule No. 7 - Half Day Weeked and Full day absent then Half day absent
                                if (att.Weekend == eEmployeeWeekendDayType.HalfDayWeekend)
                                {
                                    if (att.Present == eEmployeeAttendanceDayType.None)
                                    {
                                        att.Absent = eEmployeeAttendanceDayType.HalfDay;
                                    }
                                    // Rule No. 8 & 9 - Half day Weekend and Half/Full day Present Then present is full day and no weekend will counted
                                    else
                                    //if (att.Present != eEmployeeAttendanceDayType.None) -- if condition doesn't required explicitly 
                                    {
                                        att.Present = eEmployeeAttendanceDayType.FullDay;
                                    }

                                    // Half day weekend will not counted as weekend, elsewhere it will counted as full working day
                                    att.Weekend = eEmployeeWeekendDayType.None;
                                }
                            }

                            // Rule No. 13 and 14 - No weekend will be counted if there is any holiday.
                            else
                            {
                                att.Weekend = eEmployeeWeekendDayType.None;
                            }
                        }
                        // if it is a rest day
                        else if (EmployeeWeekendType == Model.Employee.eTAWeekendtype.RestDay && att.RestDay == eEmployeeRestDayDayType.RestDay)
                        {
                            // If it is not a holiday then process
                            if (att.Holiday == eEmployeeHolidayDayType.None)
                            {
                                if (att.Present != eEmployeeAttendanceDayType.None)
                                {
                                    att.RestDay = eEmployeeRestDayDayType.RestDayWorked;
                                    att.Present = eEmployeeAttendanceDayType.None;
                                }
                            }
                            // Rule No. 13 and 14 - No Rest day will be counted if there is any holiday.
                            else
                            {
                                att.RestDay = eEmployeeRestDayDayType.None;
                            }
                        }
                        #endregion

                        #region Check T & A Approval
                        if (att.LateIn)
                        {
                            att.LatenessApproved = TAApproval.Any(r => r.EmployeeID == att.EmployeeID && r.ApprovalTypeID == eTAApprovalType.Lateness && r.ApprovedDate == present.AttendanceDate);
                        }
                        if (att.EarlyGoing)
                        {
                            att.EarlyGoingApproved = TAApproval.Any(r => r.EmployeeID == att.EmployeeID && r.ApprovalTypeID == eTAApprovalType.EarlyGoing && r.ApprovedDate == present.AttendanceDate);
                        }
                        if (att.Weekend == eEmployeeWeekendDayType.WeekendWorked || att.Weekend == eEmployeeWeekendDayType.HalfDayWeekend)
                        {
                            att.WeekendWorkedApproved = TAApproval.Any(r => r.EmployeeID == att.EmployeeID && r.ApprovalTypeID == eTAApprovalType.WeekendWork && r.ApprovedDate == present.AttendanceDate);
                        }
                        if (att.RestDay == eEmployeeRestDayDayType.RestDayWorked)
                        {
                            att.RestDayWorkedApproved = TAApproval.Any(r => r.EmployeeID == att.EmployeeID && r.ApprovalTypeID == eTAApprovalType.WeekendWork && r.ApprovedDate == present.AttendanceDate);
                        }
                        if (att.Holiday == eEmployeeHolidayDayType.HolidayWorked)
                        {
                            att.HolidayWorkedApproved = TAApproval.Any(r => r.EmployeeID == att.EmployeeID && r.ApprovalTypeID == eTAApprovalType.WeekendWork && r.ApprovedDate == present.AttendanceDate);
                        }
                        #endregion

                        // Processing Day Status
                        att.DayStatus = (att.Present == eEmployeeAttendanceDayType.FullDay ? "P" : (att.Present == eEmployeeAttendanceDayType.HalfDay ? "/P" : null));
                        att.DayStatus += (att.Absent == eEmployeeAttendanceDayType.FullDay ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "A" : null);
                        att.DayStatus += (att.Absent == eEmployeeAttendanceDayType.HalfDay ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "/A" : null);
                        att.DayStatus += (att.Leave != eEmployeeAttendanceDayType.None ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "L" : null);
                        att.DayStatus += (att.Safari != eEmployeeAttendanceDayType.None ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "S" : null);
                        att.DayStatus += (att.Holiday == eEmployeeHolidayDayType.FullDay ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "H" : null);
                        att.DayStatus += (att.Holiday == eEmployeeHolidayDayType.HolidayWorked ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "HW" : null);
                        att.DayStatus += (att.Weekend == eEmployeeWeekendDayType.Weekend ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "W" : null);
                        att.DayStatus += (att.Weekend == eEmployeeWeekendDayType.HalfDayWeekend ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "/W" : null);
                        att.DayStatus += (att.Weekend == eEmployeeWeekendDayType.WeekendWorked ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "WW" : null);
                        att.DayStatus += (att.RestDay == eEmployeeRestDayDayType.RestDay ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "R" : null);
                        att.DayStatus += (att.RestDay == eEmployeeRestDayDayType.RestDayWorked ? (!String.IsNullOrWhiteSpace(att.DayStatus) ? "," : "") + "RW" : null);

                        #region Overtime
                        // Present
                        if (att.Present != eEmployeeAttendanceDayType.None)
                        {
                            if ((Model.Employee.eTAOvertime)Employee.Employee.TAOvertime == Model.Employee.eTAOvertime.Applicable &&
                                present.OutTime != null && present.ShiftEndTime != null)
                            {

                                DateTime ShiftEndDateTime = present.AttendanceDate.AddDays(present.ShiftEndTime < present.ShiftStartTime ? 1 : 0).Add(present.ShiftEndTime.Value);
                                decimal OvertimeHour = (decimal)att.OutDateTime.Subtract(ShiftEndDateTime).TotalHours;

                                if (OvertimeHour > 0)
                                {
                                    var OverTime = TAApproval.FirstOrDefault(r => r.EmployeeID == att.EmployeeID && r.ApprovalTypeID == eTAApprovalType.Overtime && r.ApprovedDate == present.AttendanceDate);
                                    if (OverTime != null)
                                    {
                                        OvertimeHour = Math.Min(OvertimeHour, OverTime.ApprovedHour);
                                        att.NormalOvertimeHour = OvertimeHour;
                                    }
                                }
                            }
                        }
                        else if (att.Weekend == eEmployeeWeekendDayType.WeekendWorked ||
                            att.Holiday == eEmployeeHolidayDayType.HolidayWorked ||
                            att.RestDay == eEmployeeRestDayDayType.RestDayWorked)
                        {
                            if ((Model.Employee.eTAWeekEndAttendance)Employee.Employee.TAWeekEndAttendance == Model.Employee.eTAWeekEndAttendance.Overtime && 
                                present.OutTime != null && present.InTime != null)
                            {
                                
                                decimal OvertimeHour = (decimal)att.OutDateTime.Subtract(att.InDateTime).TotalHours;

                                if (OvertimeHour > 0)
                                {
                                    var OverTime = TAApproval.FirstOrDefault(r => r.EmployeeID == att.EmployeeID && 
                                    (r.ApprovalTypeID == eTAApprovalType.WeekendWork || r.ApprovalTypeID == eTAApprovalType.Overtime) && 
                                    r.ApprovedDate == present.AttendanceDate);
                                    if (OverTime != null)
                                    {
                                        OvertimeHour = Math.Min(OvertimeHour, OverTime.ApprovedHour);
                                        att.DoubleOvertimeHour = OvertimeHour;
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                }
                return EmployeeAttendanceDayDetails;
            }
        }
    }
}