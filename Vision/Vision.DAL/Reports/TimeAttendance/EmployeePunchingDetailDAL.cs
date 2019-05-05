using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class EmployeePunchingDetailDAL
    {
        public List<EmployeePunchingDetailReportModel> GetReport(DateTime DateFrom, DateTime DateTo, int EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from ad in db.tblEmployeeAttendanceDetails
                        join a in db.tblEmployeeAttendances on ad.EmployeeAttendanceID equals a.EmployeeAttendanceID
                        where a.EmployeeID == EmployeeID &&
                        a.AttendanceDate >= DateFrom && a.AttendanceDate <= DateTo
                        orderby ad.LogTime
                        select new EmployeePunchingDetailReportModel()
                        {
                            EmployeeAttendanceID = a.EmployeeAttendanceID,
                            AttendanceDate = a.AttendanceDate,
                            InTime = a.InTime,
                            OutTime = a.OutTime,

                            EmployeeAttendanceDetailID = ad.EmployeeAttendanceDetailID,
                            AttendanceStatus = ((Model.BMDevice.eLogTimeType)ad.LogTimeType == Model.BMDevice.eLogTimeType.In ? "In" : 
                                (Model.BMDevice.eLogTimeType)ad.LogTimeType == Model.BMDevice.eLogTimeType.Out ? "Out" : "Unknown") ,
                            DeviceSerialNo = ad.DeviceSerialNo,
                            LogTime = ad.LogTime,
                            TerminalType = ad.TerminalType,
                            TransactionID = ad.TransactionID,

                        }).ToList();
            }
        }
    }
}
