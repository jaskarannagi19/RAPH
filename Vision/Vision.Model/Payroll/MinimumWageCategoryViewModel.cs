using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class MinimumWageCategoryEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int MinimumWageCategoryID { get; set; }

        [DisplayName("Minimum Wage Category")]
        public string MinimumWageCategoryName { get; set; }

        [DisplayName("Rule Apply On")]
        public string RuleApplyOn { get; set; }
    }

    public class MinimumWageCategoryLookupListModel
    {
        [Browsable(false)]
        public int MinimumWageCategoryID { get; set; }

        [DisplayName("Minimum Wage Category")]
        public string MinimumWageCategoryName { get; set; }

        [DisplayName("Rule Apply On")]
        public string RuleApplyOn { get; set; }
    }

    public enum eMinimumWageCategory_ApplyTo
    {
        BasicPay = 0,
        GrossPay = 1
    }

    public class MinimumWageCategoryRateChangeListModel
    {
        [Browsable(false)]
        public int MinimumWageCategoryID { get; set; }

        [DisplayName("Minimum Wage Category Name")]
        public string MinimumWageCategoryName { get; set; }

        [DisplayName("Rule Apply On")]
        public string RuleApplyOn { get; set; }

        [DisplayName("Urban Rate")]
        public decimal UrbanRate { get; set; }

        [DisplayName("Rural Rate")]
        public decimal RuralRate { get; set; }
    }
}
