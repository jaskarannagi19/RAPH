using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public enum eNonCashBenefitType
    {
        General = 0,
        Vehicle = 1,
    }

    public enum eNonCashBenefitKRAValueType
    {
        Fixed= 0,
        Percentage = 1
    }
    public enum eNonCashBenefitCostValueType
    {
        Fixed = 0,
        Variable = 1
    }

    public class NonCashBenefitEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int NonCashBenefitID { get; set; }

        [DisplayName("Non Cash Benefit")]
        public string NonCashBenefitName { get; set; }

        [DisplayName("Type")]
        public eNonCashBenefitType NonCashBenefitType { get; set; }

        [DisplayName("Cost Value Type")]
        public eNonCashBenefitCostValueType CostValueType { get; set; }

        [DisplayName("Cost Value")]
        public decimal CostValue { get; set; }

        [DisplayName("KRA Value Type")]
        public eNonCashBenefitKRAValueType KRAValueType { get; set; }

        [DisplayName("KRA Value")]
        public decimal KRAValue { get; set; }

        [DisplayName("KRA %")]
        public decimal KRAValuePercentage { get; set; }
    }

    public class NonCashBenefitLookupListModel
    {
        [Browsable(false)]
        public int NonCashBenefitID { get; set; }

        [DisplayName("Non Cash Benefit")]
        public string NonCashBenefitName { get; set; }
    }
}
