using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.Settings;

namespace Vision.Model.Payroll
{
    public class EmployeePayslip_EarningAndDeductionsViewModel
    {
        [Browsable(false)]
        public int EarningAndDeductionID { get; set; }

        [DisplayName("Earnings")]
        public string EarningAndDeductionName { get; set; }

        [DisplayName("Amount")]
        public decimal Value { get; set; }

        [Browsable(false)]
        public Payroll.eEarningDeductionType RecordType { get; set; }

        [Browsable(false)]
        public eEarningDeductionValueType ValueType { get; set; }

        [Browsable(false)]
        public bool Recurring { get; set; }

        [Browsable(false)]
        public bool Taxable { get; set; }
    }

    public class EmployeePayslip_NoncashBenefitViewModel
    {
        [DisplayName("")]
        public bool Selected { get; set; }

        [Browsable(false)]
        public int NonCashBenefitID { get; set; }

        [DisplayName("Non Cash Benefit Name")]
        public string NonCashBenefitName { get; set; }

        [Browsable(false)]
        public Model.Payroll.eNonCashBenefitType NonCashBenefitType { get; set; }

        [Browsable(false)]
        public Model.Payroll.eNonCashBenefitCostValueType NonCashBenefitCostValueType { get; set; }

        [Browsable(false)]
        public Model.Payroll.eNonCashBenefitKRAValueType NonCashBenefitKRAValueType { get; set; }

        [DisplayName("Recurring ?")]
        public bool Recurrning { get; set; }

        decimal CostValue_;
        [DisplayName("Cost Value")]
        public decimal CostValue
        {
            get
            {
                return CostValue_;
            }

            set
            {
                CostValue_ = value;
                if(NonCashBenefitKRAValueType == eNonCashBenefitKRAValueType.Percentage)
                {
                    KRAValue = Math.Round(CostValue_ * KRAValuePercentage, 2);
                }
            }
        }

        [DisplayName("KRA %")]
        public decimal KRAValuePercentage { get; set; }

        [DisplayName("KRA Value")]
        public decimal KRAValue { get; set; }
    }

    public class EmployeePayslip_PAYEReliefeViewModel
    {
        [Browsable(false)]
        public int PAYEReliefID { get; set; }

        [DisplayName(" ")]
        public bool Selected { get; set; }

        [DisplayName("PAYE Relief Name")]
        public string PAYEReliefName { get; set; }

        [Browsable(false)]
        public ePAYEReliefeMandatory Mandatory { get; set; }

        [DisplayName("Amount")]
        public decimal PAYEReliefAmt { get; set; }

        [DisplayName("Monthly Limit")]
        public decimal MonthlyLimit { get; set; }

        [Browsable(false)]
        public ePAYEReliefType PAYEReliefType { get; set; }
    }

}
