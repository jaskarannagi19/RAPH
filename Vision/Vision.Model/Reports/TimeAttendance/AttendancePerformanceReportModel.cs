using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class AttendancePerformanceReportModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }


        [DisplayName("Absent")]
        public decimal Absent { get; set; }

        [DisplayName("Late In")]
        public decimal LateIn { get; set; }

        [DisplayName("EarlyGoing")]
        public decimal EarlyGoing { get; set; }

        [DisplayName("Missed Punch")]
        public decimal MissedPunch { get; set; }

    }
}
