using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;


namespace Vision.DAL.Reports.TimeAttendance
{
    public class AttendancePerformanceDAL
    {
        public List<AttendancePerformanceReportModel> GetReport(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                EmployeeAttendanceDAL EmployeeAttendanceDALObj = new EmployeeAttendanceDAL();
                var resAtt = EmployeeAttendanceDALObj.GetEmployeeAttendanceData(DateFrom, DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID);

                var resSumm = (from r in resAtt
                           group r by r.EmployeeID into gr
                           select new AttendancePerformanceReportModel()
                           {
                               EmployeeID = gr.Key,
                               Absent = gr.Count(grr => grr.Absent != Model.Payroll.eEmployeeAttendanceDayType.None),
                               LateIn = gr.Count(grr => grr.LateIn),
                               EarlyGoing = gr.Count(grr => grr.EarlyGoing),
                               MissedPunch = gr.Count(grr => grr.MissedPunch),
                           }).ToList();

                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;
                byte AttendanceType_IntegratedID = (byte)Model.Employee.eTAAttendanceType.Integrated;
                DateTime TodaysDate = DateTime.Now.Date;

                var resEmployee = (from e in db.tblEmployees
                                             join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                                             from sd in gsd.DefaultIfEmpty()
                                             join jloc in db.tblLocations on sd.LocationID equals jloc.LocationID into gloc
                                             from loc in gloc.DefaultIfEmpty()
                                             join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                                             from ep in gep.DefaultIfEmpty()

                                             where e.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                 e.TAAttendanceType == AttendanceType_IntegratedID &&
                                                 e.rstate != RecordStatus_Deleted &&

                                            (sd != null
                                                && ((Model.Employee.eEmployementStatus)sd.EmployeementStatus) == Model.Employee.eEmployementStatus.Active
                                                && (((Model.Employee.eEmploymentType)sd.EmploymentType) != Model.Employee.eEmploymentType.Contract ||
                                                    (sd.ContractExpiryDate == null || sd.ContractExpiryDate >= TodaysDate))) &&

                                                 (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                                     (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                                     (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                                    (EmployementTypeID == null ||
                                                        (sd != null &&
                                                            (sd.EmploymentType == EmployementTypeID ||
                                                                (EmployementTypeID == 3 && (sd.EmploymentType == 1 || sd.EmploymentType == 2)))))
                                   orderby e.EmployeeNo
                                             select new EmployeeAttendanceSummaryReportModel()
                                             {
                                                 EmployeeID = e.EmployeeID,
                                                 EmployeeNoPrefix = ep.EmployeeNoPrefixName,
                                                 EmployeeNo = e.EmployeeNo,
                                                 EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,
                                             }).ToList();

                var DistinctEmployeeIDs = (from r in resSumm
                                           group r by r.EmployeeID into gr
                                           select gr.Key);

                foreach(var EmployeeID in DistinctEmployeeIDs)
                {
                    var Employee = resEmployee.FirstOrDefault(r => r.EmployeeID == EmployeeID);
                    if(Employee == null)
                    {
                        continue;
                    }

                    foreach(var rat in resSumm.Where(r=> r.EmployeeID == EmployeeID))
                    {
                        rat.EmployeeName = Employee.EmployeeName;
                        rat.EmployeeNo = Employee.EmployeeNo;
                        rat.EmployeeNoPrefix = Employee.EmployeeNoPrefix;
                    }
                }

                return resSumm.OrderBy(r=> r.EmployeeNo).ToList();
            }
        }
    }
}
