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
    
    public partial class tblPayrollEmployeeDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPayrollEmployeeDetail()
        {
            this.tblPayrollEmployeeEarningsDeductions = new HashSet<tblPayrollEmployeeEarningsDeduction>();
            this.tblPayrollEmployeeNonCashBenefits = new HashSet<tblPayrollEmployeeNonCashBenefit>();
            this.tblPayrollEmployePAYEReliefs = new HashSet<tblPayrollEmployePAYERelief>();
        }
    
        public int PayrollEmployeeDetailID { get; set; }
        public int PayrollID { get; set; }
        public int EmployeeID { get; set; }
        public decimal NormalOvertimeHours { get; set; }
        public decimal DoubleOvertimeHours { get; set; }
        public decimal AbsentDays { get; set; }
        public decimal MissedPunchDays { get; set; }
        public decimal LateDays { get; set; }
        public decimal NoticePayDays { get; set; }
        public decimal LeaveEncashmentDays { get; set; }
        public decimal WeekendWorkedDays { get; set; }
        public decimal LoanInstallmentAmount { get; set; }
        public Nullable<int> Vehicle_NoncashBenefitID { get; set; }
        public bool ApplyNHIF { get; set; }
        public bool ApplyNSSF { get; set; }
        public decimal BasicIncome { get; set; }
        public decimal HRAAllowance { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal TotalTaxableEarnings { get; set; }
        public decimal TaxableIncome { get; set; }
        public decimal NetTaxableIncome { get; set; }
        public decimal PAYEValue { get; set; }
        public decimal NHIFValue { get; set; }
        public decimal NSSFValue { get; set; }
        public decimal PFValue { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
        public virtual tblNonCashBenefit tblNonCashBenefit { get; set; }
        public virtual tblPayroll tblPayroll { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPayrollEmployeeEarningsDeduction> tblPayrollEmployeeEarningsDeductions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPayrollEmployeeNonCashBenefit> tblPayrollEmployeeNonCashBenefits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPayrollEmployePAYERelief> tblPayrollEmployePAYEReliefs { get; set; }
    }
}
