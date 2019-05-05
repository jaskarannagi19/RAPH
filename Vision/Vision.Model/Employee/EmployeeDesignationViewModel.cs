using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeDesignationEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeDesignationID { get; set; }

        [DisplayName("Employee Designation")]
        public string EmployeeDesignationName { get; set; }
    }

    public class EmployeeDesignationLookupListModel
    {
        [Browsable(false)]
        public int EmployeeDesignationID { get; set; }

        [DisplayName("Employee Designation")]
        public string EmployeeDesignationName { get; set; }
    }
}
