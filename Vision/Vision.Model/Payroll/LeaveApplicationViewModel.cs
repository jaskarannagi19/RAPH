using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class LeaveApplicationEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LeaveApplicationID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("From")]
        public DateTime LeaveFrom { get; set; }

        [DisplayName("To")]
        public DateTime LeaveTo { get; set; }

        [DisplayName("Type")]
        public string LeaveType { get; set; }

        [DisplayName("Application Date")]
        public DateTime LeaveApplicateDate { get; set; }

        [DisplayName("Prefix")]
        public string LeaveApplicationNoPrefixName { get; set; }

        [DisplayName("No")]
        public int LeaveApplicationNo { get; set; }
    }

    public class LeaveApplicationLookupListModel
    {
        [Browsable(false)]
        public int LeaveApplicationID { get; set; }

        [Browsable(false)]
        public string LeaveApplicationNoPrefixName { get; set; }

        [Browsable(false)]
        public int LeaveApplicationNo { get; set; }

        [DisplayName("No")]
        public string LeaveApplicationNostr { get { return (LeaveApplicationNoPrefixName ?? "") + LeaveApplicationNo.ToString(); } }

        [DisplayName("Application Date")]
        public DateTime LeaveApplicateDate { get; set; }

        [Browsable(false)]
        public string EmployeeNoPrefix { get; set; }


        [Browsable(false)]
        public int EmployeeNo { get; set; }

        [DisplayName("Emp Code")]
        public string EmployeeNoWithPrefix { get { return (EmployeeNoPrefix ?? "") + EmployeeNo.ToString(); } }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("From")]
        public DateTime LeaveFrom { get; set; }

        [DisplayName("To")]
        public DateTime LeaveTo { get; set; }

        [DisplayName("Type")]
        public string LeaveType { get; set; }
    }

    public enum eLeaveDayOffType
    {
        FirstHalf = 1,
        SecondHalf = 2,
        FullDay = 3,
        WeekEnd = 4,
        Holiday = 5,
        Absent = 6,
    }

    public class LeaveApplicationDayDetail
    {
        [DisplayName("Leave Date")]
        public DateTime LeaveDate { get; set; }

        [DisplayName("Day")]
        public string DayName { get { return LeaveDate.ToString("dddd"); } }

        public eLeaveDayOffType LeaveDayOffType { get; set; }

        //[Browsable(false)]
        //public eLeaveDayOffType LeaveDayOffType { get { return (eLeaveDayOffType)LeaveDayOffTypeID; } }

        //public int LeaveDayOffTypeID { get; set; }

        [Browsable(false)]
        public bool IsHolidayOrWeekEnd { get; set; }

        [DisplayName("Descr")]
        [ReadOnly(true)]
        public string Descr { get; set; }
    }

    public class LeaveApplicationDayOffTypeViewModel
    {
        [Browsable(false)]
        public eLeaveDayOffType LeaveDayOffType { get; set; }

        //[Browsable(false)]
        //public eLeaveDayOffType LeaveDayOffType { get { return (eLeaveDayOffType)LeaveDayOffTypeID; } }

        //[Browsable(false)]
        //public int LeaveDayOffTypeID { get; set; }

        [DisplayName("Type")]
        public string LeaveDayOffTypeName { get; set; }

        public static List<LeaveApplicationDayOffTypeViewModel> GetList()
        {
            return new List<LeaveApplicationDayOffTypeViewModel>()
            {
                 new LeaveApplicationDayOffTypeViewModel()
                 {
                     LeaveDayOffType = eLeaveDayOffType.FirstHalf,
                     LeaveDayOffTypeName = "First Half",
                 },
                 new LeaveApplicationDayOffTypeViewModel()
                 {
                     LeaveDayOffType = eLeaveDayOffType.SecondHalf,
                     LeaveDayOffTypeName = "Second Half",
                 },
                 new LeaveApplicationDayOffTypeViewModel()
                 {
                     LeaveDayOffType = eLeaveDayOffType.FullDay,
                     LeaveDayOffTypeName = "Full Day",
                 },
                 new LeaveApplicationDayOffTypeViewModel()
                 {
                     LeaveDayOffType = eLeaveDayOffType.WeekEnd,
                     LeaveDayOffTypeName = "WeekEnd",
                 },
                 new LeaveApplicationDayOffTypeViewModel()
                 {
                     LeaveDayOffType = eLeaveDayOffType.Holiday,
                     LeaveDayOffTypeName = "Holiday",
                 },
                 new LeaveApplicationDayOffTypeViewModel()
                 {
                     LeaveDayOffType = eLeaveDayOffType.Absent,
                     LeaveDayOffTypeName = "Absent",
                 }
            };
        }
    }
}
