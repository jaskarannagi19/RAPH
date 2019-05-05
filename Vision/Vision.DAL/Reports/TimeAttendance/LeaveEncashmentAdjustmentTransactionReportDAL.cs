using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class LeaveEncashmentAdjustmentTransactionReportDAL
    {
        public List<LeaveEncashmentAdjustmentTransactionReportModel> GetLeaveEncashmentAdjustmentTransactionReport(DateTime DateFrom, DateTime DateTo, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;

                var resEncashment = (from leave in db.tblLeaveEncashments
                           join e in db.tblEmployees on leave.EmployeeID equals e.EmployeeID

                           join jleaveprefix in db.tblLeaveEncashmentNoPrefixes on leave.LeaveEncashmentNoPrefixID equals jleaveprefix.LeaveEncashmentNoPrefixID into gleaveprefix
                           from leaveprefix in gleaveprefix.DefaultIfEmpty()

                           join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                           from sd in gsd.DefaultIfEmpty()

                           join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                           from ep in gep.DefaultIfEmpty()

                           where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                leave.LeaveEncashmentDate >= DateFrom && leave.LeaveEncashmentDate <= DateTo &&
                                leave.rstate != RecordStatus_Deleted && e.rstate != RecordStatus_Deleted &&

                                (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                (EmployementTypeID == null ||
                                    (sd != null &&
                                        (sd.EmploymentType == EmployementTypeID ||
                                            (EmployementTypeID == 3 && (sd.EmploymentType == 1 || sd.EmploymentType == 2)))))

                           select new LeaveEncashmentAdjustmentTransactionReportModel()
                           {
                               EmployeeID = e.EmployeeID,
                               EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                               EmployeeNo = e.EmployeeNo,
                               EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,

                               TransactionID = leave.LeaveEncashmentID,
                               TransactionDate = leave.LeaveEncashmentDate,
                               TransactionNoPrefixName = (leaveprefix != null ? leaveprefix.LeaveEncashmentNoPrefixName : ""),
                               TransactionNo = leave.LeaveEncashmentNo,
                               NofDays = leave.NofLeaves,
                               Remarks = leave.Remarks,

                               RecordType = eLeaveEncashmentAdjustmentTransactionReport_RecordType.Encashment
                           }).ToList();

                var resAdjustment = (from leave in db.tblLeaveAdjustments
                                     join e in db.tblEmployees on leave.EmployeeID equals e.EmployeeID

                                     join jleaveprefix in db.tblLeaveAdjustmentNoPrefixes on leave.LeaveAdjustmentNoPrefixID equals jleaveprefix.LeaveAdjustmentNoPrefixID into gleaveprefix
                                     from leaveprefix in gleaveprefix.DefaultIfEmpty()

                                     join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                                     from sd in gsd.DefaultIfEmpty()

                                     join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                                     from ep in gep.DefaultIfEmpty()

                                     where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                          leave.LeaveAdjustmentDate >= DateFrom && leave.LeaveAdjustmentDate <= DateTo &&
                                          leave.rstate != RecordStatus_Deleted && e.rstate != RecordStatus_Deleted &&

                                          (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                          (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                          (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                          (EmployementTypeID == null || (sd != null && sd.EmploymentType == EmployementTypeID))
                                     select new LeaveEncashmentAdjustmentTransactionReportModel()
                                     {
                                         EmployeeID = e.EmployeeID,
                                         EmployeeNoPrefix = ep.EmployeeNoPrefixName,
                                         EmployeeNo = e.EmployeeNo,
                                         EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,

                                         TransactionID = leave.LeaveAdjustmentID,
                                         TransactionDate = leave.LeaveAdjustmentDate,
                                         TransactionNoPrefixName = (leaveprefix != null ? leaveprefix.LeaveAdjustmentNoPrefixName : ""),
                                         TransactionNo = leave.LeaveAdjustmentNo,
                                         NofDays = leave.NofLeaves,
                                         Remarks = leave.Remarks,

                                         RecordType = eLeaveEncashmentAdjustmentTransactionReport_RecordType.Adjustment
                                     }).ToList();

                resEncashment.AddRange(resAdjustment);
                return (from r in resEncashment orderby r.TransactionDate, r.RecordType, r.TransactionNo select r).ToList();
            }
        }
    }
}
