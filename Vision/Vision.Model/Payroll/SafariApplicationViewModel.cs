using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class SafariApplicationEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int SafariApplicationID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("From")]
        public DateTime SafariFrom { get; set; }

        [DisplayName("To")]
        public DateTime SafariTo { get; set; }

        [DisplayName("Application Date")]
        public DateTime SafariApplicateDate { get; set; }

        [DisplayName("Prefix")]
        public string SafariApplicationNoPrefixName { get; set; }

        [DisplayName("No.")]
        public int SafariApplicationNo { get; set; }
    }

    public class SafariApplicationLookupListModel
    {

        [DisplayName("Prefix")]
        public string SafariApplicationNoPrefixName { get; set; }

        [Browsable(false)]
        public int SafariApplicationID { get; set; }

        [DisplayName("No.")]
        public int SafariApplicationNo { get; set; }

        [DisplayName("Application Date")]
        public DateTime SafariApplicateDate { get; set; }

        [Browsable(false)]
        public string EmployeeNoPrefix { get; set; }


        [Browsable(false)]
        public int EmployeeNo { get; set; }

        [DisplayName("Emp Code")]
        public string EmployeeNoWithPrefix { get { return (EmployeeNoPrefix ?? "") + EmployeeNo.ToString(); } }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("From")]
        public DateTime SafariFrom { get; set; }

        [DisplayName("To")]
        public DateTime SafariTo { get; set; }
    }

    public enum eSafariDayOffType
    {
        FirstHalf = 1,
        SecondHalf = 2,
        FullDay = 3,
    }

    public class SafariApplicationDayDetail
    {
        [DisplayName("Safari Date")]
        public DateTime SafariDate { get; set; }

        [DisplayName("Day")]
        public string DayName { get { return SafariDate.ToString("dddd"); } }

        public eSafariDayOffType SafariDayOffType { get; set; }

        [Browsable(false)]
        public bool IsHolidayOrWeekEnd { get; set; }

        [DisplayName("Descr")]
        [ReadOnly(true)]
        public string Descr { get; set; }
    }

    public class SafariApplicationDayOffTypeViewModel
    {
        [Browsable(false)]
        public eSafariDayOffType SafariDayOffType { get; set; }

        [DisplayName("Type")]
        public string SafariDayOffTypeName { get; set; }

        public static List<SafariApplicationDayOffTypeViewModel> GetList()
        {
            return new List<SafariApplicationDayOffTypeViewModel>()
            {
                 new SafariApplicationDayOffTypeViewModel()
                 {
                     SafariDayOffType = eSafariDayOffType.FirstHalf,
                     SafariDayOffTypeName = "First Half",
                 },
                 new SafariApplicationDayOffTypeViewModel()
                 {
                     SafariDayOffType = eSafariDayOffType.SecondHalf,
                     SafariDayOffTypeName = "Second Half",
                 },
                 new SafariApplicationDayOffTypeViewModel()
                 {
                     SafariDayOffType = eSafariDayOffType.FullDay,
                     SafariDayOffTypeName = "Full Day",
                 },
            };
        }
    }
}
