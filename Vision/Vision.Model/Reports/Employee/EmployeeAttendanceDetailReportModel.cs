using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.Employee
{
    public class EmployeeAttendanceHeaderReportModel
    {
        [Browsable(false)]
        public int? EmployeeID { get; set; }


        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }


        public string EmployeeName { get; set; }

        public int EmployeeTACode { get; set; }

        public DateTime AttendanceDate { get; set; }

        TimeSpan? InTime_;
        [Browsable(false)]
        public TimeSpan? InTime
        {
            get
            {
                return InTime_;
            }

            set
            {
                InTime_ = value;
                InTimeDisplay = (InTime_ == null ? null : (DateTime?)AttendanceDate.Add(InTime_.Value));
            }
        }

        public DateTime? InTimeDisplay { get; private set; }

        TimeSpan? OutTime_;
        [Browsable(false)]
        public TimeSpan? OutTime
        {
            get
            {
                return OutTime_;
            }

            set
            {
                OutTime_ = value;
                OutTimeDisplay = (OutTime_ == null ? null : (DateTime?)AttendanceDate.Add(OutTime_.Value));
            }
        }

        public DateTime? OutTimeDisplay { get; private set; }

        public List<EmployeeAttendanceDetailReportModel> Detail { get; set; }
    }

    public class EmployeeAttendanceDetailReportModel
    {
        public DateTime LogTime { get; set; }

        public string AttendanceStatus { get; set; }
    }
}
