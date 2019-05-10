using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public enum eEmployeeSalaryIncrementType
    {
        Fixed = 0,
        Percentage = 1
    }

    public class EmployeeSalaryIncrementEditListModel  : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeSalaryIncrementID { get; set; }

        [Browsable(false)]
        public int FinPerioudID { get; set; }

        [DisplayName("Salary Increment No.")]
        public int EmployeeSalaryIncrementNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Salary Increment Date")]
        public DateTime EmployeeSalaryIncrementDate { get; set; }
 
        [DisplayName("Month")]
        public int EffectiveMonth { get; set; }

        [DisplayName("Effective Month")]
        public string EffectiveMonthYear { get { return new DateTime(EffectiveYear, EffectiveMonth, 1).ToString("MM-MMM"); } }

        [DisplayName("Effective Year")]
        public int EffectiveYear { get; set; }

        [Browsable(false)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [DisplayName("Last Inc Date")]
        public DateTime? LastIncDate { get; set; }

        [Browsable(false)]
        [DisplayName("Last Inc Amount")]
        public decimal? LastIncAmount { get; set; }

        [DisplayName("Employee No")]
        public int EmployeeNo { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("Current Salary")]
        public decimal CurrentBasicSalary { get; set; }

        [DisplayName("Type")]
        public eEmployeeSalaryIncrementType IncrementType { get; set; }

        [DisplayFormat(DataFormatString = "{0:P4}")]
        [DisplayName("Percentage")]
        public decimal IncrementPercentage { get; set; }

        [DisplayName("Increment Amount")]
        public decimal IncrementAmount { get; set; }

        [DisplayName("New Salary")]
        public decimal NewBasicSalary { get; set; }

        [Browsable(false)]
        public string Remarks { get; set; }
    }
}
