using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeShiftAllocationViewModel : Employee.EmployeeLookupListModel
    {
        public bool Selected { get; set; }

        [DisplayName("Current Shift")]
        public string LastShiftName { get; set; }

        [DisplayName("W.E.Date")]
        public DateTime? LastShiftWED { get; set; }
    }

    public class EmployeeLatestShiftAllocationViewModel
    {
        public int EmployeeID { get; set; }

        public DateTime? WEDateFrom { get; set; }

        public int? EmployeeShiftID { get; set; }

        public string EmployeeShiftName { get; set; }
    }
}
