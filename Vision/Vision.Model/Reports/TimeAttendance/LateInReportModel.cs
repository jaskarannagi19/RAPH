using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class LateInReportModel
    {
        public int EmployeeID { get; set; }


        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }


        public string EmployeeName { get; set; }

        public DateTime AttendanceDate { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public DateTime? DateTimeIn { get { return TimeIn != null ? (DateTime?)AttendanceDate.Add(TimeIn.Value) : null; } }

        public int GracePeriod { get; set; }
    }
}
