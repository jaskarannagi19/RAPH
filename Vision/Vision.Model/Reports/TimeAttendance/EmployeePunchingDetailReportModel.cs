using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class EmployeePunchingDetailReportModel
    {
        [Browsable(false)]
        public int EmployeeAttendanceID { get; set; }

        [Browsable(false)]
        public int EmployeeAttendanceDetailID { get; set; }

        [DisplayName("Attendance Date")]
        public DateTime AttendanceDate { get; set; }

        [DisplayName("In Time")]
        public TimeSpan? InTime { get; set; }

        [DisplayName("Out Time")]
        public TimeSpan? OutTime { get; set; }

        [DisplayName("Log Time")]
        public DateTime LogTime { get; set; }

        [DisplayName("Type")]
        public string AttendanceStatus { get; set; }

        [DisplayName("Terminal Type")]
        public string TerminalType { get; set; }

        [DisplayName("Transaction ID")]
        public int? TransactionID { get; set; }

        [DisplayName("Device Ser. No.")]
        public string DeviceSerialNo { get; set; }
    }
}
