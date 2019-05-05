using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class SafariTransactionReportModel
    {
        [Browsable(false)]
        public int SafariApplicationID { get; set; }

        [DisplayName("Date")]
        public DateTime SafariApplicationDate { get; set; }

        [DisplayName("Ref. Prefix")]
        public string SafariApplicationNoPrefixName { get; set; }

        [DisplayName("Ref. No.")]
        public int SafariApplicationNo { get; set; }


        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }

        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        [DisplayName("Nof Days")]
        public decimal NofDays { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }
    }
}
