using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Loan
{
    public enum eLoanAdjustment_PaymentMode
    {
        Bank = 0,
        Cash = 1,
        WriteOff = 2,
    }

    public class LoanAdjustmentEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LoanAdjustmentID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Adjustment Date")]
        public DateTime LoanAdjustmentDate { get; set; }

        [DisplayName("Loan Amount")]
        public decimal LoanAmount { get; set; }

        [DisplayName("Adjustment Amount")]
        public decimal LoanAdjustmentAmount { get; set; }

        [DisplayName("Reason")]
        public string Reason { get; set; }

        [DisplayName("Adj Prefix")]
        public string LoanAdjustmentNoPrefixName { get; set; }

        [DisplayName("Loan Adj No.")]
        public int LoanAdjustmentNo { get; set; }
    }

    public class LoanAdjustmentLookupListModel
    {
        [Browsable(false)]
        public int LoanAdjustmentID { get; set; }

        [DisplayName("Adj Prefix")]
        public string LoanAdjustmentNoPrefixName { get; set; }

        [DisplayName("Loan Adj No.")]
        public int LoanAdjustmentNo { get; set; }

        
        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }


        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }


        [DisplayName("Adjustment Date")]
        public DateTime LoanAdjustmentDate { get; set; }

        [DisplayName("Loan Amount")]
        public decimal LoanAmount { get; set; }

        [DisplayName("Adjustment Amount")]
        public decimal LoanAdjustmentAmount { get; set; }

        public string Reason { get; set; }
    }
}
