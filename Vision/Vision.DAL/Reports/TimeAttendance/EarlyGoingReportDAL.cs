using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class EarlyGoingReportDAL
    {
        public List<EarlyGoingReportModel> GetReportData(DateTime? DateFrom, DateTime? DateTo)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                TimeSpan ShiftEnd = new TimeSpan(17, 0, 0);
                byte AttendanceType_IntegratedID = (byte)Model.Employee.eTAAttendanceType.Integrated;
                return (from r in db.tblEmployeeAttendances
                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()
                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                        (e == null || e.TAAttendanceType == AttendanceType_IntegratedID) &&
                        (DateFrom == null || r.AttendanceDate >= DateFrom) &&
                        (DateTo == null || r.AttendanceDate <= DateTo) &&
                        r.OutTime != null && r.OutTime < ShiftEnd
                        select new EarlyGoingReportModel()
                        {
                            EmployeeID = r.EmployeeID ?? 0,
                            AttendanceDate = r.AttendanceDate,
                            TimeOut = r.OutTime,
                        }).ToList();
            }
        }
    }
}
