using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DAL.Payroll;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class EmployeeMonthlyAttendanceSummaryDAL
    {
        public List<EmployeeMonthlyAttendanceSummaryReportModel> GetReport(DateTime DateFrom, DateTime DateTo, int EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                EmployeeAttendanceDAL EmployeeAttendanceDALObj = new EmployeeAttendanceDAL();
                var resAtt = EmployeeAttendanceDALObj.GetEmployeeAttendanceData(new DateTime(DateFrom.Year, DateFrom.Month, 1), (new DateTime(DateTo.Year, DateTo.Month + 1, 1)).AddDays(-1), EmployeeID);

                return (from r in resAtt
                        group r by new { Month = r.Day.Month, Year = r.Day.Year } into gr
                        select new EmployeeMonthlyAttendanceSummaryReportModel()
                        {
                            Month = gr.Key.Month,
                            Year = gr.Key.Year,
                            
                            Present = gr.Sum(r=> r.PresentCount),
                            Absent = gr.Sum(r=> r.AbsentCount),
                            Weekend = gr.Sum(r=> r.WeekendCount),
                            WeekendWorked = gr.Sum(r=> r.WeekendWorkedCount),
                            Leave = gr.Sum(r=> r.LeaveCount),
                            Holiday = gr.Sum(r=> r.HolidayCount),
                            HolidayWorked = gr.Sum(r=> r.HolidayWorkedCount),
                            Safari = gr.Sum(r=> r.SafariCount),
                            TotalDays = gr.Sum(r=> 1),
                            EarlyGoing = gr.Sum(r=> r.EarlyGoing ? 1 : 0),
                            LateIn = gr.Sum(r=> r.LateIn ? 1 : 0),
                            MissedPunch = gr.Sum(r=> r.MissedPunch ? 1 : 0),
                            
                        }).ToList();
            }
        }
    }
}
