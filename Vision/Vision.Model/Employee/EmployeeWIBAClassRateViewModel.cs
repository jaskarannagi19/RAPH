using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeWIBAClassRateViewModel
    {
        [DisplayName("Select")]
        public bool Selected { get; set; }

        [Browsable(false)]
        public int EmployeeWIBClassID { get; set; }

        [DisplayName("WIBA Class Name")]
        public string EmployeeWIBAClassName { get; set; }

        [DisplayName("Rate")]
        public decimal Rate { get; set; }

        [DisplayName("With Effect Date")]
        public DateTime? WEDate { get; set; }
    }
}
