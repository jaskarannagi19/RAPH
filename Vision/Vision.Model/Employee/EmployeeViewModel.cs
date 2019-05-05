using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [DisplayName("T & A Code")]
        public int TACode { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Status")]
        public eEmployementStatus EmployementStatusID { get; set; }


        [DisplayName("Gender")]
        public eGender Gender { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public string Location { get; set; }

        [Browsable(false)]
        public eEmploymentType EmployementTypeID { get; set; }

        [DisplayName("Employement Type")]
        public string EmployementType
        {
            get
            {
                switch (EmployementTypeID)
                {
                    case eEmploymentType.Casual:
                        return "Casual";
                    case eEmploymentType.Contract:
                        return "Contract";
                    case eEmploymentType.Permanent:
                        return "Permanent";
                    default:
                        return "N/A";
                }
            }
        }
    }

    public class EmployeeLookupListModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp Code")]
        public int EmployeeNo { get; set; }

        [Browsable(false)]
        public string FirstName { get; set; }

        [Browsable(false)]
        public string LastName { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName2 { get { return FirstName + " " + LastName; } }

        [Browsable(false)]
        [DisplayName("Employee Name")]
        public string EmployeeName { get { return EmployeeNo.ToString() + " " + EmployeeName2; } }

        [DisplayName("Gender")]
        public eGender Gender { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public string Location { get; set; }

        [Browsable(false)]
        public eEmploymentType EmployementTypeID { get; set; }

        [DisplayName("Employement Type")]
        public string EmployementType
        {
            get
            {
                switch (EmployementTypeID)
                {
                    case eEmploymentType.Casual:
                        return "Casual";
                    case eEmploymentType.Contract:
                        return "Contract";
                    case eEmploymentType.Permanent:
                        return "Permanent";
                    default:
                        return "N/A";
                }
            }
        }
    }

    public enum eGender
    {
        Male = 0,
        Female = 1
    }

    public enum eEmploymentType
    {
        Casual = 0,
        Contract = 1,
        Permanent = 2
    }

    public enum ePaymentMode
    {
        Cash = 0,
        Cheque = 1,
        BankTransfer = 2,
        mPAISA = 3
    }

    public enum ePaymentCycle
    {
        Weekly = 0,
        Fortnight = 1,
        Monthly = 2,
    }

    public enum eIncomeType
    {
        Primary = 0,
        Secondary = 1,
    }

    public enum eTAAttendanceType
    {
        NotApplicable = 0,
        Integrated = 1,
        Import = 2,
    }

    public enum eTALatenessCharges
    {
        NotApplicable = 0,
        Applicable = 1
    }

    public enum eTAEarlyGoing
    {
        NotApplicable = 0,
        Applicable = 1
    }

    public enum eTAOvertime
    {
        NotApplicable = 0,
        Applicable = 1
    }

    public enum eTANegativeLeave
    {
        NotAllowed = 0,
        Allowed = 1
    }

    public enum eTAWeekEndAttendance
    {
        NA = 0,
        Overtime = 1,
        Allowance = 2,
    }

    public enum eTAMissPunch
    {
        Abscent = 0,
        Present = 1,
    }

    public enum eTAWeekendtype
    {
        Weekend = 0,
        RestDay = 1
    }

    public enum eEmployementStatus
    {
        Active = 0,
        Resigned = 1,
        Terminated = 2,
        Expired=3
    }

    public enum eTerminationType
    {
        NA = 0,
        Resignation = 1,
        Termination = 2,
        /// <summary>
        /// Contract Expired
        /// </summary>
        Expired = 3,
    }

    public enum eReportEmployementStatus
    {
        Active = 0,
        Terminated = 1,
        NewEmployement = 2
    }

    public enum eProvidentFund
    {
        NotApplicable = 0,
        Applicable = 1
    }

    public class EmployeePersonalDocumentViewModel

    {
        [Browsable(false)]
        public int DocumentID { get; set; }

        [DisplayName("Document Name")]
        public string DocumentName { get; set; }

        [DisplayName("File Name")]
        public string FileName { get; set; }
    }

    public class EmployeeFamilyDetailsViewModel
    {
        [Browsable(false)]
        public int EmployeeFamilyID { get; set; }

        [DisplayName("Relationship")]
        public int Relationship { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("PO Box No")]
        public string POBoxNo { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Beneficiary")]
        public decimal Beneficiary { get; set; }

    }

    public class EmployeeFamilyRelationshipViewModel
    {
        [Browsable(false)]
        public int EmployeeFamilyRelationshipID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }
    }

    public class EmployeeServiceDetailViewModel
    {
        [Browsable(false)]
        public int EmployeeServiceDetailID { get; set; }

        public DateTime EmploymentEffectiveDate { get; set; }

        public DateTime? ContractExpiryDate { get; set; }

        [Browsable(false)]
        public byte EmploymentType { get; set; }

        [Browsable(false)]
        public int EmployeeDesignationID { get; set; }

        [Browsable(false)]
        public int EmployeeDepartmentID { get; set; }

        [Browsable(false)]
        public int EmployeeWIBAClassID { get; set; }

        [Browsable(false)]
        public int MinimumWageCategoryID { get; set; }

        [Browsable(false)]
        public int LocationID { get; set; }

        public decimal DailyRate { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HousingAllowance { get; set; }
        public decimal WeekendAllowance { get; set; }

        public byte EmployeeShiftTypeID { get; set; }

        public int? EmployeeShiftID { get; set; }

        public List<EmployeeLeaveOpeningBalanceViewModel> EmployeeLeaveOpeningBalance { get; set; }
    }

    public class EmployeeServiceDetailGridViewModel
    {
        [Browsable(false)]
        public int EmployeeServiceDetailID { get; set; }

        [Browsable(false)]
        public eEmploymentType EmploymentTypeID { get; set; }

        [DisplayName("Employment Type")]
        public string EmploymentType { get { return (EmploymentTypeID == eEmploymentType.Casual ? "Casual" : (EmploymentTypeID == eEmploymentType.Contract ? "Contract" : (EmploymentTypeID == eEmploymentType.Permanent ? "Permanent" : ""))); } }

        [DisplayName("Effective Date")]
        public DateTime EmploymentEffectiveDate { get; set; }

        [DisplayName("Contract Expiry Date")]
        public DateTime? ContractExpiryDate { get; set; }

        [DisplayName("Department")]
        public string EmployeeDepartmentName { get; set; }

        [DisplayName("Designation")]
        public string EmployeeDesignationName { get; set; }

        [DisplayName("Location")]
        public string LocationName { get; set; }

        [DisplayName("Minimum Wages")]
        public string MinimumWageCategoryName { get; set; }

        [DisplayName("WIBA Class")]
        public string EmployeeWIBAClassName { get; set; }

        [DisplayName("Daily Rate")]
        public decimal DailyRate { get; set; }

        [DisplayName("Basic Salary")]
        public decimal BasicSalary { get; set; }

        [DisplayName("Housing Allowance")]
        public decimal HousingAllowance { get; set; }

        [DisplayName("Weekend Allowance")]
        public decimal WeekendAllowance { get; set; }
    }

    public class EmployeeLeaveOpeningBalanceViewModel
    {
        [Browsable(false)]
        public int EmployeeLeaveOpeningBalanceID { get; set; }

        [Browsable(false)]
        public int LeaveTypeID { get; set; }

        [DisplayName("Leave Type")]
        public string LeaveTypeName { get; set; }

        [DisplayName("Opening Balance")]
        public decimal OpeningBalance { get; set; }
    }
}
