using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeNoPrefixID { get; set; }

        [DisplayName("Name")]
        public string EmployeeNoPrefixName { get; set; }
    }

    public class EmployeeNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int EmployeeNoPrefixID { get; set; }

        [DisplayName("Name")]
        public string EmployeeNoPrefixName { get; set; }
    }
}
