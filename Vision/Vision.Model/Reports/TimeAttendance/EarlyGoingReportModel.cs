using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class EarlyGoingReportModel
    {
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        public string EmployeeName { get; set; }

        public DateTime AttendanceDate { get; set; }

        public TimeSpan? TimeOut { get; set; }

        public DateTime? DateTimeOut { get { return TimeOut != null ? (DateTime?)AttendanceDate.Add(TimeOut.Value) : null; } }

    }
}
