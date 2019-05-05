using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeDepartmentEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeDepartmentID { get; set; }

        [DisplayName("Employee Department")]
        public string EmployeeDepartmentName { get; set; }
    }

    public class EmployeeDepartmentLookupListModel
    {
        [Browsable(false)]
        public int EmployeeDepartmentID { get; set; }

        [DisplayName("Employee Department")]
        public string EmployeeDepartmentName { get; set; }
    }
}
