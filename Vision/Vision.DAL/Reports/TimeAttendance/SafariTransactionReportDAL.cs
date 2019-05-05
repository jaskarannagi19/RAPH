using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class SafariTransactionReportDAL
    {
        public List<SafariTransactionReportModel> GetSafariTransactionReport(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;

                var res = (from Safari in db.tblSafariApplications
                           join e in db.tblEmployees on Safari.EmployeeID equals e.EmployeeID

                           join jSafariprefix in db.tblSafariApplicationNoPrefixes on Safari.SafariApplicationNoPrefixID equals jSafariprefix.SafariApplicationNoPrefixID into gSafariprefix
                           from Safariprefix in gSafariprefix.DefaultIfEmpty()

                           join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                           from sd in gsd.DefaultIfEmpty()

                           join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                           from ep in gep.DefaultIfEmpty()

                           where Safari.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&

                                Safari.ToDate >= DateFrom && Safari.FromDate <= DateTo &&

                                Safari.rstate != RecordStatus_Deleted && e.rstate != RecordStatus_Deleted &&
                                (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                (EmployementTypeID == null ||
                                    (sd != null &&
                                        (sd.EmploymentType == EmployementTypeID ||
                                            (EmployementTypeID == 3 && (sd.EmploymentType == 1 || sd.EmploymentType == 2)))))

                           orderby Safari.FromDate, Safari.SafariApplicationNo

                           select new SafariTransactionReportModel()
                           {
                               EmployeeID = e.EmployeeID,
                               EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                               EmployeeNo = e.EmployeeNo,
                               EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,

                               SafariApplicationID = Safari.SafariApplicationID,
                               SafariApplicationDate = Safari.SafariApplicationDate,
                               SafariApplicationNoPrefixName = (Safariprefix != null ? Safariprefix.SafariApplicationNoPrefixName : null),
                               SafariApplicationNo = Safari.SafariApplicationNo,
                               FromDate = Safari.FromDate,
                               ToDate = Safari.ToDate,
                               NofDays = Safari.NofSafariDays,
                               Remarks = Safari.Remarks,
                           });
                return res.ToList();
            }
        }
    }
}
