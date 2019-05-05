using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public enum eLeaveEncashmentAdjustmentTransactionReport_RecordType
    {
        Encashment = 0,
        Adjustment = 1,
    }

    public class LeaveEncashmentAdjustmentTransactionReportModel
    {
        [Browsable(false)]
        public int TransactionID { get; set; }

        [DisplayName("Date")]
        public DateTime TransactionDate { get; set; }

        [DisplayName("Ref. Prefix")]
        public string TransactionNoPrefixName { get; set; }

        [DisplayName("Ref. No.")]
        public int TransactionNo { get; set; }

        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        public eLeaveEncashmentAdjustmentTransactionReport_RecordType RecordType { get; set; }

        public string Description { get { return RecordType == eLeaveEncashmentAdjustmentTransactionReport_RecordType.Encashment ? "Encashment" : "Adjustment"; } }

        [DisplayName("Nof Days")]
        public decimal NofDays { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

    }
}
