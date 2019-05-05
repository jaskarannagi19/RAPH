using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class EmployeeMonthlyAttendanceSummaryReportModel
    {
        [Browsable(false)]
        public int Month { get; set; }

        [Browsable(false)]
        public int Year { get; set; }

        [DisplayName("Month")]
        public string MonthYear { get { return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month) + " " + Year.ToString(); } }

        [DisplayName("Present")]
        public decimal Present { get; set; }

        [DisplayName("Absent")]
        public decimal Absent { get; set; }

        [DisplayName("Weekend")]
        public decimal Weekend { get; set; }

        [DisplayName("Weekend Worked")]
        public decimal WeekendWorked { get; set; }

        [DisplayName("Holiday")]
        public decimal Holiday { get; set; }

        [DisplayName("Holiday Worked")]
        public decimal HolidayWorked { get; set; }

        [DisplayName("Leave")]
        public decimal Leave { get; set; }

        [DisplayName("Safari")]
        public decimal Safari { get; set; }

        [DisplayName("Total Days")]
        public decimal TotalDays { get; set; }

        [DisplayName("Late In")]
        public decimal LateIn { get; set; }

        [DisplayName("Early Going")]
        public decimal EarlyGoing { get; set; }

        [DisplayName("MissedPunch")]
        public decimal MissedPunch { get; set; }
    }
}
