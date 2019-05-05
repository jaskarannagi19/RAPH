using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Employee;

namespace Vision.Model.Reports.Employee
{
    public class EmployementStatusReportModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [DisplayName("Emp. Code")]
        public int EmployeeNo { get; set; }

        [Browsable(false)]
        public string FirstName { get; set; }

        [Browsable(false)]
        public string LastName { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get { return (FirstName + " " + LastName); } }

        public string Designation { get; set; }

        public string Department { get; set; }

        public string Location { get; set; }

        [DisplayName("Joining Date")]
        public DateTime JoiningDate { get; set; }

        [DisplayName("Emp. Type")]
        public eEmploymentType EmploymentTypeID { get; set; }


        [DisplayName("Basic Salary")]
        public decimal BasicSalary { get; set; }

        [DisplayName("Housing Allowance")]
        public decimal HousingAllowance { get; set; }

        [DisplayName("Gross Salary")]
        public decimal GrossSalary { get { return BasicSalary + HousingAllowance; } }


        [DisplayName("Type")]
        public eTerminationType TerminationTypeID { get; set; }

        //[DisplayName("Type")]
        //public string TerminationType { get { return (TerminationTypeID == eTerminationType.NA ? "N/A" : (TerminationTypeID == eTerminationType.Resignation ? "Resignation" : (TerminationTypeID == eTerminationType.Termination ? "Termination" : ""))); } }

        [DisplayName("Termination Date")]
        public DateTime? TerminationDate { get; set; }

        [DisplayName("Reason")]
        public string TerminationReason { get; set; }

        [Browsable(false)]
        public DateTime? ContractExpiryDate { get; set; }

        //[DisplayName("Employment Type")]
        //public string EmploymentType { get { return (EmploymentTypeID == eEmploymentType.Casual ? "Casual" : (EmploymentTypeID == eEmploymentType.Contract ? "Contract" : (EmploymentTypeID == eEmploymentType.Permanent ? "Permanent" : ""))); } }

        //[Browsable(false)]
        //public eEmployementStatus EmploymentStatusID { get; set; }

        //[DisplayName("Employment Status")]
        //public string EmploymentStatus { get { return (EmploymentStatusID == eEmployementStatus.Active ? "Active" : (EmploymentStatusID == eEmployementStatus.Expired ? "Expired" : (EmploymentStatusID == eEmployementStatus.Resigned ? "Resigned" : ""))); } }

    }
}
