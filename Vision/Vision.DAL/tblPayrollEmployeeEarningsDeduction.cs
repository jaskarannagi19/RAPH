//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vision.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPayrollEmployeeEarningsDeduction
    {
        public int PayrollEmployeeEarningsDeductionID { get; set; }
        public int PayrollEmployeeDetailID { get; set; }
        public int EarningsDeductionID { get; set; }
        public decimal Value { get; set; }
        public bool Taxable { get; set; }
        public byte ValueType { get; set; }
    
        public virtual tblEmployeeEarningDeduction tblEmployeeEarningDeduction { get; set; }
        public virtual tblPayrollEmployeeDetail tblPayrollEmployeeDetail { get; set; }
    }
}
