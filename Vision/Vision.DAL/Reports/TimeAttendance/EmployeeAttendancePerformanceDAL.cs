using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DAL.Payroll;
using Vision.DAL.Reports.TimeAttendance;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class EmployeeAttendancePerformanceDAL
    {
        public List<EmployeeAttendancePerformanceReportModel> GetReport(DateTime DateFrom, DateTime DateTo, int EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                EmployeeAttendanceDAL EmployeeAttendanceDALObj = new EmployeeAttendanceDAL();
                var resAtt = EmployeeAttendanceDALObj.GetEmployeeAttendanceData(DateFrom, DateTo, EmployeeID);

                return (from r in resAtt
                               orderby r.Day
                               select new EmployeeAttendancePerformanceReportModel()
                               {
                                   Day = r.Day,
                                   Absent = (r.Absent == Model.Payroll.eEmployeeAttendanceDayType.FullDay ? "Full Day" : (r.Absent == Model.Payroll.eEmployeeAttendanceDayType.HalfDay ? "Half Day" : null)),
                                   LateIn = (r.LateIn ? r.InTime : null),
                                   EarlyGoing = (r.EarlyGoing ? r.OutTime : null),
                                   MissedPunch = (r.MissedPunch ? "Yes" : null),
                               }).ToList();
            }
        }
    }
}
