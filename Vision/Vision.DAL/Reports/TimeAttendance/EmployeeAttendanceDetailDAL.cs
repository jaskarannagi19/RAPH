using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Payroll;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class EmployeeAttendanceDetailDAL
    {
        public List<EmployeeAttendanceDetailReportModel> GetReportData(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            DateFrom = DateFrom.Date;

            DateTo = DateTo.Date.Add(new TimeSpan(23, 59, 59));

            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte AttendanceType_IntegratedID = (byte)Model.Employee.eTAAttendanceType.Integrated;
                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;
                DateTime TodaysDate = DateTime.Now.Date;

                DAL.Payroll.EmployeeAttendanceDAL EmployeeAttendanceDALObj = new EmployeeAttendanceDAL();
                var EmployeeAttendanceDayDetails = EmployeeAttendanceDALObj.GetEmployeeAttendanceData(DateFrom, DateTo, DepartmentID, DesignationID, LocationID, EmployementTypeID);

                var res = (from e in db.tblEmployees
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
                           select new EmployeeAttendanceDetailReportModel()
                           {
                               EmployeeID = e.EmployeeID,
                               EmployeeNoPrefix = ep.EmployeeNoPrefixName,
                               EmployeeNo = e.EmployeeNo,
                               EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,
                           }).ToList();

                int NofDays = DateTo.Subtract(DateFrom).Days + 1;

                foreach (var r in res)
                {
                    r.AttendanceDetail = EmployeeAttendanceDayDetails.Where(ar => ar.EmployeeID == r.EmployeeID).ToList();
                    r.Present = r.AttendanceDetail.Sum(ar => ar.PresentCount);
                    r.Absent = r.AttendanceDetail.Sum(ar => ar.AbsentCount);
                    r.Weekend = r.AttendanceDetail.Sum(ar => ar.WeekendCount);
                    r.WeekendWorked = r.AttendanceDetail.Sum(ar => ar.WeekendWorkedCount);
                    r.RestDay = r.AttendanceDetail.Sum(ar => ar.RestDayCount);
                    r.RestDayWorked = r.AttendanceDetail.Sum(ar => ar.RestDayWorkedCount);
                    r.Holiday = r.AttendanceDetail.Sum(ar => ar.HolidayCount);
                    r.HolidayWorked = r.AttendanceDetail.Sum(ar => ar.HolidayWorkedCount);
                    r.Leave = r.AttendanceDetail.Sum(ar => ar.LeaveCount);
                    r.Safari = r.AttendanceDetail.Sum(ar => ar.SafariCount);
                }
                return res;
            }
        }
    }
}
