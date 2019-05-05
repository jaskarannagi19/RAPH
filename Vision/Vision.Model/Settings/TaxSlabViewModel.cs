using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Settings
{
    public enum eTaxSlab_TaxType
    {
        None = 0,
        NHIF = 1,
        NSSF = 2,
        PAYE = 3,
    }
    public class TaxSlabViewModel
    {
        [DisplayName("From")]
        public decimal TaxableSalaryFromValue { get; set; }

        [DisplayName("To")]
        public decimal TaxableSalaryToValue { get; set; }



        [DisplayName("Tax Value")]
        public decimal TaxValueEmployee { get; set; }

        [DisplayName("Tax %")]
        public decimal TaxPercEmployee { get; set; }

        [DisplayName("Maximum")]
        public decimal MaxTaxValueEmployee { get; set; }



        [DisplayName("Tax Value")]
        public decimal TaxValueEmployer { get; set; }

        [DisplayName("Tax %")]
        public decimal TaxPercEmployer { get; set; }

        [DisplayName("Maximum")]
        public decimal MaxTaxValueEmployer { get; set; }

    }

}
