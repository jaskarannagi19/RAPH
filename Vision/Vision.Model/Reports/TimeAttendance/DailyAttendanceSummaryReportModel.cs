using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class DailyAttendanceSummaryReportModel
    {
        public DateTime AttendanceDate { get; set; }

        public decimal Present { get; set; }

        public decimal Leave { get; set; }

        public decimal Absent { get; set; }

        public int LateIn { get; set; }

        public int EarlyGoing { get; set; }

        public int MissedPunch { get; set; }

        public int Safari { get; set; }
    }
}
