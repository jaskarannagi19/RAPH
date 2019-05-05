using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Loan
{
    public class LoanApplicationEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LoanApplicationID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }


        [Browsable(false)]
        public int MonthFrom { get; set; }

        [Browsable(false)]
        public int YearFrom { get; set; }

        public string LoanFrom { get { return new DateTime(YearFrom, MonthFrom, 1).ToString("MMM yyyy"); } }


        [Browsable(false)]
        public int MonthTo { get; set; }

        [Browsable(false)]
        public int YearTo { get; set; }

        [DisplayName("To")]
        public string LoanTo { get { return new DateTime(YearTo, MonthTo, 1).ToString("MMM yyyy"); } }


        [DisplayName("Loan Amount")]
        public decimal LoanApplicationAmount { get; set; }

        [DisplayName("Installment Amt")]
        public decimal InstallmentAmount { get; set; }

        public string Purpose { get; set; }

        [DisplayName("Application Date")]
        public DateTime LoanApplicateDate { get; set; }

        [DisplayName("Loan Prefix")]
        public string LoanApplicationNoPrefixName { get; set; }

        [DisplayName("Loan No")]
        public int LoanApplicationNo { get; set; }
    }

    public class LoanApplicationLookupListModel
    {
        [Browsable(false)]
        public int LoanApplicationID { get; set; }

        [DisplayName("Prefix")]
        public string LoanApplicationNoPrefixName { get; set; }

        [DisplayName("Loan No.")]
        public int LoanApplicationNo { get; set; }

        [DisplayName("Application Date")]
        public DateTime LoanApplicateDate { get; set; }

        [Browsable(false)]
        public string EmployeeNoPrefix { get; set; }


        [Browsable(false)]
        public int EmployeeNo { get; set; }

        [DisplayName("Emp Code")]
        public string EmployeeNoWithPrefix { get { return (EmployeeNoPrefix ?? "") + EmployeeNo.ToString(); } }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }


        [Browsable(false)]
        public int MonthFrom { get; set; }

        [Browsable(false)]
        public int YearFrom { get; set; }

        public string LoanFrom { get { return new DateTime(YearFrom, MonthFrom, 1).ToString("MMM yyyy"); } }


        [Browsable(false)]
        public int MonthTo { get; set; }

        [Browsable(false)]
        public int YearTo { get; set; }

        [DisplayName("To")]
        public string LoanTo { get { return new DateTime(YearTo, MonthTo, 1).ToString("MMM yyyy"); } }


        [DisplayName("Loan Amount")]
        public decimal LoanApplicationAmount { get; set; }

        [DisplayName("Installment Amt")]
        public decimal InstallmentAmount { get; set; }

        public string Purpose { get; set; }

        [Browsable(false)]
        public string LoanFromTo { get { return $"{LoanFrom} to {LoanTo}, Amt {LoanApplicationAmount.ToString()}, For {Purpose}"; } }

    }
}
