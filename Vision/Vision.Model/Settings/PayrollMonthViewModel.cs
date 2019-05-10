using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Settings
{
    public class PayrollMonthViewModel
    {
        public int PayrollMonthID { get; set; }

        public DateTime PayrollMonthStartDate { get; set; }

        public DateTime PayrollMonthEndDate { get; set; }

        public string PayrollMonthName { get; set; }
    }
}
