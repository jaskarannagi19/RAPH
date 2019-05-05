using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Reports.Employee;

namespace Vision.DAL.Reports.Employee
{
    public class EmployeeAttendanceDetailReportDAL 
    {
        public List<EmployeeAttendanceHeaderReportModel> GetReportData(int? EmployeeID, DateTime? DateFrom, DateTime? DateTo)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var res = (from r in db.tblEmployeeAttendances

                           join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                           from e in ge.DefaultIfEmpty()

                           join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                           from ep in gep.DefaultIfEmpty()

                           where (EmployeeID == null || r.EmployeeID == EmployeeID)
                             && ((DateFrom == null || r.AttendanceDate >= DateFrom) && (DateTo == null || r.AttendanceDate <= DateTo))
                             && r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                           select new EmployeeAttendanceHeaderReportModel()
                           {
                               EmployeeID = r.EmployeeID,

                               EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                               EmployeeNo = e.EmployeeNo,

                               EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName: null),
                               EmployeeTACode = (e != null ? e.TACode : 0),
                               AttendanceDate = r.AttendanceDate,
                               InTime = r.InTime,
                               OutTime = r.OutTime,
                               Detail = (from d in db.tblEmployeeAttendanceDetails
                                         where d.EmployeeAttendanceID == r.EmployeeAttendanceID
                                         orderby d.EmployeeAttendanceDetailID
                                         select new EmployeeAttendanceDetailReportModel()
                                         {
                                             AttendanceStatus = ((Model.BMDevice.eLogTimeType)d.LogTimeType == Model.BMDevice.eLogTimeType.In ? "In" :
                                (Model.BMDevice.eLogTimeType)d.LogTimeType == Model.BMDevice.eLogTimeType.Out ? "Out" : "Unknown"),
                                             LogTime = d.LogTime
                                         }).ToList()
                           }).ToList();
                return res;
            }
        }
    }
}
