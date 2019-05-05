using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public enum eLeaveDetailTransactionType
    {
        OpeningBalance = 0,
        Accure = 1,
        LeaveTaken = 2,
        LeaveEncashment = 3,
        LeaveAdjustment = 4,
    }

    public class LeaveDetailReportModel
    {
        [Browsable(false)]
        public int TransactionID { get; set; }

        [DisplayName("Date")]
        public DateTime TransactionDate { get; set; }

        [Browsable(false)]
        public eLeaveDetailTransactionType TransactionType { get; set; }

        [DisplayName("Transaction")]
        public string TransactionName
        {
            get
            {
                return (TransactionType == eLeaveDetailTransactionType.OpeningBalance ? "Op. Balance" :
                        (TransactionType == eLeaveDetailTransactionType.Accure ? "Accure" :
                        (TransactionType == eLeaveDetailTransactionType.LeaveTaken ? "Leave Taken" :
                        (TransactionType == eLeaveDetailTransactionType.LeaveEncashment ? "Encashment" :
                        (TransactionType == eLeaveDetailTransactionType.LeaveAdjustment ? "Adjustment" : "N/A")))));
            }
        }

        [DisplayName("Ref. Prefix")]
        public string TransactionNoPrefixName { get; set; }

        [DisplayName("Ref. No.")]
        public int TransactionNo { get; set; }

        [DisplayName("Earned")]
        public decimal Earned { get; set; }

        [DisplayName("Utilized")]
        public decimal Utilized { get; set; }

        [DisplayName("Balance")]
        public decimal Balance { get; set; }
    }
}
