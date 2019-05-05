using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class DailyAttendanceSummaryDAL
    {
        public List<DailyAttendanceSummaryReportModel> GenerateReportData(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var res = (new DAL.Payroll.EmployeeAttendanceDAL()).GetEmployeeAttendanceData(DateFrom, DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID);

                var res1 = (from r in res
                            group r by r.Day into gr
                            select new DailyAttendanceSummaryReportModel()
                            {
                                AttendanceDate = gr.Key,
                                Present = gr.Sum(grr => (grr.Present == Model.Payroll.eEmployeeAttendanceDayType.FullDay ? 1M : (grr.Present == Model.Payroll.eEmployeeAttendanceDayType.HalfDay ? 0.5M : (grr.Weekend == Model.Payroll.eEmployeeWeekendDayType.WeekendWorked ? 1M : (grr.Holiday == Model.Payroll.eEmployeeHolidayDayType.HolidayWorked ? 1M : 0))))),
                                Absent = gr.Sum(grr => (grr.Absent == Model.Payroll.eEmployeeAttendanceDayType.FullDay ? 1M : (grr.Absent == Model.Payroll.eEmployeeAttendanceDayType.HalfDay ? 0.5M : 0))),
                                Leave = gr.Sum(grr => (grr.Leave == Model.Payroll.eEmployeeAttendanceDayType.FullDay ? 1M : (grr.Leave == Model.Payroll.eEmployeeAttendanceDayType.HalfDay ? 0.5M : 0))),
                                Safari = gr.Sum(grr => (grr.Safari != Model.Payroll.eEmployeeAttendanceDayType.None ? 1 : 0)),
                                LateIn = gr.Sum(grr => (grr.LateIn ? 1 : 0)),
                                EarlyGoing = gr.Sum(grr => (grr.EarlyGoing ? 1 : 0)),
                                MissedPunch = gr.Sum(grr => (grr.MissedPunch ? 1 : 0)),
                            });

                return res1.ToList();
            }
        }
    }
}
