using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Reports.TimeAttendance
{
    public class LeaveBalanceReportModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [Browsable(false)]
        public DateTime EmploymentEffectiveDate { get; set; }

        [Browsable(false)]
        public decimal EmployeeOpeningBalance { get; set; }

        [Browsable(false)]
        public decimal OpeningLeaveAccured { get; set; }

        [Browsable(false)]
        public decimal OpeningLeaveAdjustment { get; set; }

        [Browsable(false)]
        public decimal OpeningLeaveTaken { get; set; }

        [Browsable(false)]
        public decimal OpeningLeaveEncashment { get; set; }


        [DisplayName("Opening Balance")]
        public decimal OpeningBalance { get { return EmployeeOpeningBalance + OpeningLeaveAccured + OpeningLeaveAdjustment - OpeningLeaveTaken - OpeningLeaveEncashment; } }


        [DisplayName("Accured")]
        public decimal Accured { get; set; }

        [DisplayName("Adjustment")]
        public decimal Adjustment { get; set; }

        [DisplayName("Taken")]
        public decimal LeaveTaken { get; set; }

        [DisplayName("Encashment")]
        public decimal LeaveEncashment { get; set; }

        [DisplayName("Balance")]
        public decimal ClosingBalance { get { return OpeningBalance + Accured + Adjustment - LeaveTaken - LeaveEncashment; } }
    }
}
