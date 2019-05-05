using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Employee;

namespace Vision.Model.Reports.Employee
{
    public class EmployeeListReportModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("Employee No Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp. Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("TA Code")]
        public int TACode { get; set; }

        [Browsable(false)]
        [DisplayName("Employee First Name")]
        public string EmployeeFirstName { get; set; }

        [Browsable(false)]
        [DisplayName("Employee Last Name")]
        public string EmployeeLastName { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get { return (EmployeeFirstName ?? "") + " " + (EmployeeLastName ?? ""); } }

        [Browsable(false)]
        public string EmployeeImageFileName { get; set; }

        [DisplayName("Image")]
        public Image EmployeeImage { get; set; }

        [DisplayName("Gender")]
        public eGender Gender { get; set; }

        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        [DisplayName("Work Visa Expiry Date")]
        public DateTime? WorkVisaExpiryDate { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        [DisplayName("PO Box No")]
        public string POBoxNO { get; set; }

        public string City { get; set; }

        [DisplayName("MPesa No.")]
        public string MpesaNo { get; set; }

        [DisplayName("Email ID")]
        public string EmailID { get; set; }

        [Browsable(false)]
        public bool Multicurrency { get; set; }

        [DisplayName("Multi Currency")]
        public string MulticurrencyText { get { return Multicurrency ? "Yes" : "No"; } }

        
        [DisplayName("Emp. Status")]
        public eEmployementStatus EmployementStatus { get; set; }

        
        [DisplayName("ID No.")]
        public string IDNo { get; set; }

        [DisplayName("NSSF No.")]
        public string NSSFNo { get; set; }

        [DisplayName("NHIF No.")]
        public string NHIFNo { get; set; }

        [DisplayName("PIN No.")]
        public string PINNo { get; set; }

        [DisplayName("PF No.")]
        public string PFNo { get; set; }

        [DisplayName("Payment Mode")]
        public ePaymentMode PaymentMode { get; set; }

        [DisplayName("Pay Cycle")]
        public ePaymentCycle PayCycle { get; set; }




        [DisplayName("Bank A/c No.")]
        public string BankAcNo { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Bank Branch")]
        public string BankBranch { get; set; }

        [DisplayName("Bank Currency")]
        public string BankCurrency { get; set; }

        [DisplayName("Income Type")]
        public eIncomeType IncomeType { get; set; }

        [DisplayName("Attendance Type")]
        public eTAAttendanceType TAAttendanceType { get; set; }

        [DisplayName("Lateness")]
        public eTALatenessCharges TALatenessCharges { get; set; }

        [DisplayName("Early Going")]
        public eTAEarlyGoing TAEarlyGoing { get; set; }

        [DisplayName("Overtime")]
        public eTAOvertime TAOvertime { get; set; }

        [DisplayName("Negative Leave")]
        public eTANegativeLeave TANegativeLeave { get; set; }

        [DisplayName("Weekend Type")]
        public eTAWeekendtype TAWeekendType { get; set; }

        [DisplayName("Weekend Attendance")]
        public eTAWeekEndAttendance TAWeekEndAttendance { get; set; }

        [DisplayName("Miss Punch")]
        public eTAMissPunch TAMissPunch { get; set; }

        [DisplayName("Emplpyeement Effective Date")]
        public DateTime? EmploymentEffectiveDate { get; set; }

        [DisplayName("Employment Type")]
        public eEmploymentType EmploymentType { get; set; }

        [DisplayName("Contract Expiry")]
        public DateTime? ContractExpiryDate { get; set; }


        [DisplayName("Department")]
        public string DepartmentName { get; set; }

        [DisplayName("Location")]
        public string LocationName { get; set; }

        [DisplayName("Designation")]
        public string EmployeeDesignationName { get; set; }

        [DisplayName("Minimum Wage Category")]
        public string MinimumWageCategoryName { get; set; }

        [DisplayName("WIBA Class")]
        public string EmployeeWIBAClassName { get; set; }

        [DisplayName("Accounting Ledger")]
        public string EmployeeAccountingLedger { get; set; }

        [DisplayName("Daily Rate")]
        public decimal DailyRate { get; set; }

        [DisplayName("Basic Salary")]
        public decimal BasicSalary { get; set; }

        [DisplayName("Housing Allowance")]
        public decimal HousingAllowance { get; set; }

        [DisplayName("Weekend Allowance")]
        public decimal WeekendAllowance { get; set; }

        [DisplayName("Shift Type")]
        public eEmployeeShiftType EmployeeShiftType { get; set; }

        [DisplayName("Shift Name")]
        public string EmployeeShiftName { get; set; }

        [DisplayName("Shift Start")]
        public TimeSpan? ShiftStartTime { get; set; }

        [DisplayName("Shift End")]
        public TimeSpan? ShiftEndTime { get; set; }

        [DisplayName("Shift Allocation Date")]
        public DateTime? ShiftAllocationDate { get; set; }

        [DisplayName("Reinstatement Reason")]
        public string ReinstatementReason { get; set; }

        [DisplayName("Termination Date")]
        public DateTime? TerminationDate { get; set; }

        [DisplayName("Termination Type")]
        public eTerminationType TerminationTypeID { get; set; }

        [DisplayName("Termination Reason")]
        public string TerminationReason { get; set; }
    }

    public class EmployeeListReportFormatLookupListModel
    {
        [Browsable(false)]
        public int EmployeeListFormatID { get; set; }

        [DisplayName("Format")]
        public string EmployeeListFormatName { get; set; }
    }
}
