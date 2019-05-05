using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class LeaveTransactionReportDAL
    {
        public List<LeaveTransactionReportModel> GetLeaveTransactionReport(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;
                byte LeaveDayOffType_Absent = (byte)Model.Payroll.eLeaveDayOffType.Absent;
                var res = (from leave in db.tblLeaveApplications
                           join e in db.tblEmployees on leave.EmployeeID equals e.EmployeeID

                           join jleaveprefix in db.tblLeaveApplicationNoPrefixes on leave.LeaveApplicationNoPrefixID equals jleaveprefix.LeaveApplicationNoPrefixID into gleaveprefix
                           from leaveprefix in gleaveprefix.DefaultIfEmpty()

                           join jleavetype in db.tblLeaveTypes on leave.LeaveTypeID equals jleavetype.LeaveTypeID into gleavetype
                           from leavetype in gleavetype.DefaultIfEmpty()

                           join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                           from sd in gsd.DefaultIfEmpty()

                           join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                           from ep in gep.DefaultIfEmpty()

                           where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                
                                leave.ToDate >= DateFrom && leave.FromDate <= DateTo &&

                                leave.rstate != RecordStatus_Deleted && e.rstate != RecordStatus_Deleted &&
                                (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                (EmployementTypeID == null ||
                                    (sd != null &&
                                        (sd.EmploymentType == EmployementTypeID ||
                                            (EmployementTypeID == 3 && (sd.EmploymentType == 1 || sd.EmploymentType == 2)))))
                           orderby leave.FromDate, leave.LeaveApplicationNo

                           select new LeaveTransactionReportModel()
                           {
                               EmployeeID = e.EmployeeID,
                               EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                               EmployeeNo = e.EmployeeNo,
                               EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,

                               LeaveApplicationID = leave.LeaveApplicationID,
                               LeaveApplicationDate = leave.LeaveApplicationDate,
                               LeaveApplicationNoPrefixName = (leaveprefix != null ? leaveprefix.LeaveApplicationNoPrefixName : ""),
                               LeaveApplicationNo = leave.LeaveApplicationNo,
                               LeaveTypeName = (leavetype != null ? leavetype.LeaveTypeName : null),
                               FromDate = leave.FromDate,
                               ToDate = leave.ToDate,
                               NofDays = leave.NofLeaves,
                               AbsentDays = leave.tblLeaveApplicationDayDetails.Sum(r=> (decimal?)(r.LeaveType == LeaveDayOffType_Absent ? 1 : 0)) ?? 0,
                               Remarks = leave.Remarks,
                           });
                return res.ToList();
            }
        }
    }
}
