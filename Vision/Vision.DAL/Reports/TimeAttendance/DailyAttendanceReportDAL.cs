using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class DailyAttendanceReportDAL
    {
        public List<DailyAttendanceReportModel> GetReportData(DateTime? DateFrom, DateTime? DateTo, int? EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (DateFrom != null)
                {
                    DateFrom = DateFrom.Value.Date;
                }
                if (DateTo != null)
                {
                    DateTo = DateTo.Value.Date.Add(new TimeSpan(23, 59, 59));
                }

                return (from r in db.tblEmployeeAttendances
                        //join e in db.tblEmployees on r.EmployeeID equals e.EmployeeID
                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID && 
                        (DateFrom == null || r.AttendanceDate >= DateFrom) &&
                        (DateTo == null || r.AttendanceDate <= DateTo) &&
                        (EmployeeID == null || r.EmployeeID == EmployeeID)
                        select new DailyAttendanceReportModel()
                        {
                            EmployeeID = r.EmployeeID ?? 0,
                            AttendanceDate = r.AttendanceDate,
                            TimeIn = r.InTime,
                            TimeOut = r.OutTime, 
                            AttendanceTypeID = (r.InTime == null && r.OutTime == null ? eAttendanceType.Absent : eAttendanceType.Present),
                        }).ToList();
            }
        }

        public List<DailyAttendanceReportModel> GetReportData(DateTime? DateFrom, DateTime? DateTo
            , int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {

            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (DateFrom != null)
                {
                    DateFrom = DateFrom.Value.Date;
                }
                if (DateTo != null)
                {
                    DateTo = DateTo.Value.Date.Add(new TimeSpan(23, 59, 59));
                }

                byte AttendanceType_IntegratedID = (byte)Model.Employee.eTAAttendanceType.Integrated;
                DateTime TodaysDate = DateTime.Now.Date;

                return (from e in db.tblEmployees
                        join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                        from sd in gsd.DefaultIfEmpty()
                        join jloc in db.tblLocations on sd.LocationID equals jloc.LocationID into gloc
                        from loc in gloc.DefaultIfEmpty()
                            //join jdep in db.tblEmployeeDepartments on sd.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep 
                            //from dep in gdep.DefaultIfEmpty()
                            //join jdes in db.tblEmployeeDesignations on sd.EmployeeDesignationID equals jdes.EmployeeDesignationID into gdes
                            //from des in gdes.DefaultIfEmpty()
                            //join jloc in db.tblEmployeeDepartments on sd.LocationID equals jloc.EmployeeDepartmentID into gloc
                            //from loc in gloc.DefaultIfEmpty()

                        join jatt in db.tblEmployeeAttendances on e.EmployeeID equals jatt.EmployeeID into gatt
                        from att in gatt.DefaultIfEmpty()

                        where att.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                        e.TAAttendanceType == AttendanceType_IntegratedID &&

                                            (sd != null
                                                && ((Model.Employee.eEmployementStatus)sd.EmployeementStatus) == Model.Employee.eEmployementStatus.Active
                                                && (((Model.Employee.eEmploymentType)sd.EmploymentType) != Model.Employee.eEmploymentType.Contract ||
                                                    (sd.ContractExpiryDate == null || sd.ContractExpiryDate >= TodaysDate))) &&

                        (DateFrom == null || att != null || att.AttendanceDate >= DateFrom) &&
                        (DateTo == null || att != null || att.AttendanceDate <= DateTo) &&
                        (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                        (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                        (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                        (EmployementTypeID == null || (sd != null && sd.EmploymentType == EmployementTypeID))

                        select new DailyAttendanceReportModel()
                        {
                            EmployeeID = e.EmployeeID,
                            AttendanceDate = (att != null ? (DateTime?)att.AttendanceDate : null),
                            TimeIn = (att != null ? att.InTime : null),
                            TimeOut = (att != null ? att.OutTime : null),
                            AttendanceTypeID = (att.InTime == null && att.OutTime == null ? eAttendanceType.Absent : eAttendanceType.Present),
                            GracePeriod = (loc != null ? loc.GracePeriod : 0),
                        }).ToList();
            }
        }
    }
}
