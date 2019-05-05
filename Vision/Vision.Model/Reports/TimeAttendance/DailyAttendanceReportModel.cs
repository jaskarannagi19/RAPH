using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class DailyAttendanceReportModel
    {
        public int EmployeeID { get; set; }

        public eAttendanceType AttendanceTypeID { get; set; }

        public string AttendanceType
        {
            get
            {
                return (AttendanceTypeID == eAttendanceType.Present ? "Present" :
                    (AttendanceTypeID == eAttendanceType.Absent ? "Absent" :
                    (AttendanceTypeID == eAttendanceType.Safari ? "Safari" :
                    (AttendanceTypeID == eAttendanceType.EarlyGoing ? "Early Going" :
                    (AttendanceTypeID == eAttendanceType.LateIn ? "Late In" :
                    (AttendanceTypeID == eAttendanceType.MissedPunch ? "Missed Punch" :
                    (AttendanceTypeID == eAttendanceType.WeekEnd ? "Week End" :
                    (AttendanceTypeID == eAttendanceType.Leave ? "Leave" :
                    (AttendanceTypeID == eAttendanceType.Holiday ? "Holiday" : "N/A")))))))));
            }
        }

        public DateTime? AttendanceDate { get; set; }

        public TimeSpan? TimeIn { get; set; }

        public DateTime? DateTimeIn { get { return AttendanceDate != null && TimeIn != null ? (DateTime?)AttendanceDate.Value.Add(TimeIn.Value) : null; } }

        public TimeSpan? TimeOut { get; set; }

        public DateTime? DateTimeOut { get { return TimeOut != null ? (DateTime?)AttendanceDate.Value.Add(TimeOut.Value) : null; } }

        public int GracePeriod { get; set; }
    }

    public enum eAttendanceType
    {
        None = 0,
        Present = 1,
        Absent = 2,
        Safari = 3,
        Leave = 4,
        EarlyGoing = 5,
        LateIn = 6,
        LateInEarlyGoing = 7,
        MissedPunch = 8,
        WeekEnd = 8,
        Holiday = 10
    }
}
