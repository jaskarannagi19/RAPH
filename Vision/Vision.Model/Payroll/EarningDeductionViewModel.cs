using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public enum eEarningDeductionType
    {
        Earning = 0,
        Deduction = 1,
    }

    public enum eEarningDeductionValueType
    {
        Fixed = 0,
        Percentage = 1,
        Variable = 2
    }

    public class EarningDeductionEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeEarningDeductionID { get; set; }

        [DisplayName("No.")]
        public int EmployeeEarningDeductionNo { get; set; }

        [DisplayName("Earning & Deduction")]
        public string EmployeeEarningDeductionName { get; set; }
    }

    public class EarningDeductionLookupListModel
    {
        [Browsable(false)]
        public int EmployeeEarningDeductionID { get; set; }

        [DisplayName("No.")]
        public int EmployeeEarningDeductionNo { get; set; }

        [DisplayName("Earning & Deduction")]
        public string EmployeeEarningDeductionName { get; set; }
    }
    public class EarningDeductionImportLookupListModel
    {
        [Browsable(false)]
        public int EmployeeEarningDeductionID { get; set; }

        [DisplayName("No.")]
        public int EmployeeEarningDeductionNo { get; set; }

        [DisplayName("Earning & Deduction")]
        public string EmployeeEarningDeductionName { get; set; }

        [Browsable(false)]
        public eEarningDeductionType EmployeeEarningDeductionTypeId { get; set; }

        public string EmployeeEarningDeductionType{ get { return (eEarningDeductionType.Deduction==EmployeeEarningDeductionTypeId? "Deduction" : "Earning"); } }
    }

   
}
