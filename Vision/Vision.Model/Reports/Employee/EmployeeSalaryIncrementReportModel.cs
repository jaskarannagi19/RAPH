using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Employee;

namespace Vision.Model.Reports.Employee
{
    public enum eEmployeeSalaryIncrementType
    {
        Fixed = 0,
        Percentage = 1
    }

    public class EmployeeSalaryIncrementReportModel
    {
        [Browsable(false)]
        public int EmployeeSalaryIncrementID { get; set; }

        [DisplayName("Salary Increment No.")]
        public int EmployeeSalaryIncrementNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Last Inc Date")]
        public DateTime? LastIncDate { get; set; }

        [DisplayName("Current Salary")]
        public decimal CurrentBasicSalary { get; set; }

        [DisplayName("Privious Salary")]
        public decimal PriviousBasicSalary { get; set; }

        [DisplayName("New Basic")]
        public decimal NewBasicSalary { get; set; }

        [DisplayName("Increment Amount")]
        public decimal IncrementAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:P4}")]
        [DisplayName("Percentage")]
        public decimal IncrementPercentage { get; set; }

        [DisplayName("Remarks")]
        public string Remarks { get; set; }

        [DisplayName("E. Prefix")]
        public string EmployeeNoPrefix { get; set; }

        [Browsable(false)]
        public eEmploymentType EmployementTypeID { get; set; }

        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public string LocationType { get; set; }
    }
}
