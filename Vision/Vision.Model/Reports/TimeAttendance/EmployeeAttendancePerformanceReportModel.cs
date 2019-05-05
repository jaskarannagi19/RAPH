using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class EmployeeAttendancePerformanceReportModel
    {
        [DisplayName("Date")]
        public DateTime Day { get; set; }

        [DisplayName("Absent")]
        public string Absent { get; set; }

        [DisplayName("Late In")]
        public TimeSpan? LateIn { get; set; }

        [DisplayName("Early Going")]
        public TimeSpan? EarlyGoing { get; set; }

        [DisplayName("Missed Punch")]
        public string MissedPunch { get; set; }
    }
}
