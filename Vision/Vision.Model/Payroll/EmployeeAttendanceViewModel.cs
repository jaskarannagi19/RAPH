using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public enum eEmployeeAttendanceDayType
    {
        None = 0,
        FullDay = 1,
        HalfDay = 2
    }

    public enum eEmployeeHolidayDayType
    {
        None = 0,
        FullDay = 1,
        HolidayWorked = 2,
    }

    public enum eEmployeeWeekendDayType
    {
        None = 0,
        Weekend = 1,
        HalfDayWeekend = 2,
        WeekendWorked = 3,
    }

    public enum eEmployeeRestDayDayType
    {
        None = 0,
        RestDay = 1,
        RestDayWorked = 2,
    }

    public class EmployeeAttendanceViewModel
    {
        [Browsable(true)]
        public int EmployeeID { get; set; }

        [Browsable(true)]
        public int LocationID { get; set; }

        [DisplayName("Day")]
        public DateTime Day { get; set; }

        [Browsable(false)]
        public DateTime InDateTime { get; set; }

        [Browsable(false)]
        public DateTime OutDateTime { get; set; }


        [DisplayName("In Time")]
        public TimeSpan? InTime { get; set; }

        [DisplayName("Out Time")]
        public TimeSpan? OutTime { get; set; }

        public decimal WorkingHours
        {
            get
            {
                return (decimal)OutDateTime.Subtract(InDateTime).TotalHours;
            }
        }

        public bool LateIn { get; set; }

        public bool LatenessApproved { get; set; }

        public bool EarlyGoing { get; set; }

        public bool EarlyGoingApproved { get; set; }

        public bool MissedPunch { get; set; }


        public eEmployeeAttendanceDayType ActualPresent { get; set; }

        public eEmployeeAttendanceDayType Present { get; set; }

        public decimal PresentCount { get { return Present == eEmployeeAttendanceDayType.FullDay ? 1M : Present == eEmployeeAttendanceDayType.HalfDay ? 0.5M : 0M; } }

        public eEmployeeAttendanceDayType Absent { get; set; }

        public decimal AbsentCount { get { return Absent == eEmployeeAttendanceDayType.FullDay ? 1M : Absent == eEmployeeAttendanceDayType.HalfDay ? 0.5M : 0M; } }


        /// <summary>
        /// Actual Weekend means, on this date, was it acutally weekend or not. Weekend propert will denotes, whether to count this weekend or not as per payroll rules. 
        /// like if employee works or has taken leaves which does not include weekends then this day will not counted as weekend.
        /// </summary>
        public eEmployeeWeekendDayType ActualWeekend { get; set; }
        /// <summary>
        /// Weekend shows this day should teated as weeked and how full/hald day or none.
        /// </summary>
        public eEmployeeWeekendDayType Weekend { get; set; }
        public decimal WeekendCount { get { return Weekend == eEmployeeWeekendDayType.Weekend ? 1M : 0M; } }

        public decimal WeekendWorkedCount { get { return Weekend == eEmployeeWeekendDayType.WeekendWorked ? 1M : 0M; } }

        public bool WeekendWorkedApproved { get; set; }

        /// <summary>
        /// Actual holiday means, on this date, was it acutally holiday or not. holiday propert will denotes, whether to count this holiday or not as per payroll rules. 
        /// like if employee works or has taken leaves which does not include holidays then this day will not counted as holiday.
        /// </summary>
        public eEmployeeHolidayDayType ActualHoliday { get; set; }
        /// <summary>
        /// Holiday shows this day should teated as holiday and how full/hald day or none.
        /// </summary>
        public eEmployeeHolidayDayType Holiday { get; set; }
        public decimal HolidayCount { get { return Holiday == eEmployeeHolidayDayType.FullDay ? 1M : 0M; } }

        public decimal HolidayWorkedCount { get { return Holiday == eEmployeeHolidayDayType.HolidayWorked ? 1M : 0M; } }

        public bool HolidayWorkedApproved { get; set; }

        /// <summary>
        /// Actual RestDay means, on this date, was it acutally RestDay or not. RestDay property will denotes, whether to count this RestDay or not as per payroll rules. 
        /// like if employee works or has taken leaves which does not include RestDays then this day will not counted as RestDay.
        /// </summary>
        public eEmployeeRestDayDayType ActualRestDay { get; set; }
        
        /// <summary>
        /// RestDay shows this day should teated as weeked and how full/hald day or none.
        /// </summary>
        public eEmployeeRestDayDayType RestDay { get; set; }

        public decimal RestDayCount { get { return RestDay == eEmployeeRestDayDayType.RestDay ? 1M : 0M; } }

        public decimal RestDayWorkedCount { get { return RestDay == eEmployeeRestDayDayType.RestDayWorked ? 1M : 0M; } }

        public bool RestDayWorkedApproved { get; set; }

        [Browsable(false)]
        public eEmployeeAttendanceDayType ActualLeave { get; set; }

        /// <summary>
        /// If Leave added and the same day is weekend or holiday, it means holidays or weekend are included, otherwise we will not get leave.
        /// </summary>
        [DisplayName("Leave")]
        public eEmployeeAttendanceDayType Leave { get; set; }

        public decimal LeaveCount { get { return Leave == eEmployeeAttendanceDayType.FullDay ? 1M : Leave == eEmployeeAttendanceDayType.HalfDay ? 0.5M : 0M; } }

        public eEmployeeAttendanceDayType ActualSafari { get; set; }

        [DisplayName("Safari")]
        public eEmployeeAttendanceDayType Safari { get; set; }

        [Browsable(false)]
        public decimal SafariCount { get { return Safari == eEmployeeAttendanceDayType.FullDay ? 1M : Safari == eEmployeeAttendanceDayType.HalfDay ? 0.5M : 0M; } }

        [Browsable(false)]
        public decimal NormalOvertimeHour { get; set; }

        [Browsable(false)]
        public decimal DoubleOvertimeHour { get; set; }


        public string DayStatus { get; set; }

        public int? EmployeeShiftID { get; set; }

        public string EmployeeShiftName { get; set; }
    }
}
