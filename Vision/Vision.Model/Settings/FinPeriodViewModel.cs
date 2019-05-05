using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Settings
{
    public class FinPeriodDetailModel
    {
        [Browsable(false)]
        public int FinPeriodID { get; set; }

        [DisplayName("Financial Period Name")]
        public string FinPeriodName { get; set; }

        [DisplayName("From")]
        public DateTime FinPeriodFrom { get; set; }

        [DisplayName("To")]
        public DateTime? FinPeriodTo { get; set; }

        [Browsable(false)]
        public int CompanyID { get; set; }
    }

    public class FinPeriodEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int FinPeriodID { get; set; }

        [DisplayName("Financial Period Name")]
        public string FinPeriodName { get; set; }

        [DisplayName("From")]
        public DateTime FinPeriodFrom { get; set; }

        [Browsable(false)]
        public DateTime? FinPeriodTo { get; set; }

        [DisplayName("To")]
        public string FinPeriodText { get { return FinPeriodTo.HasValue ? FinPeriodTo.Value.ToShortDateString() : ""; } }
    }

    public class AccountClosingBalanceViewModel
    {
        [Browsable(false)]
        public int AccountID { get; set; }

        [DisplayName("Account#")]
        [ReadOnly(true)]
        public int AccountNo { get; set; }

        [DisplayName("Account Name")]
        [ReadOnly(true)]
        public string AccountName { get; set; }

        [DisplayName("Company Name")]
        [ReadOnly(true)]
        public string CompanyName { get; set; }

        [ReadOnly(true)]
        public string Address { get; set; }

        [ReadOnly(true)]
        public string City { get; set; }

        [ReadOnly(true)]
        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }

        [DisplayName("Op. Balance")]
        public decimal OpeningBalance { get; set; }
    }

    public class ProductOpeningStockViewModel
    {
        [Browsable(false)]
        public int ProductID { get; set; }

        [DisplayName("Code")]

        [ReadOnly(true)]
        public int ProductCode { get; set; }

        [DisplayName("Product")]
        [ReadOnly(true)]
        public string ProductName { get; set; }

        [DisplayName("Stock")]
        public decimal Stock { get; set; }

        [DisplayName("Unit")]
        [ReadOnly(true)]
        public string UnitName { get; set; }

        [Browsable(false)]
        public decimal Rate { get; set; }
    }
}
