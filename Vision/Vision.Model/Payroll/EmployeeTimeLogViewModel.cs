using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class EmployeeTimeLogViewModel
    {
        [Browsable(false)]
        public int EmployeeID { get; set; }

        [DisplayName("Device Code")]
        public int BMDCode { get; set; }

        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [DisplayName("Log Date Time")]
        public DateTime LogTime { get; set; }
    }
}
