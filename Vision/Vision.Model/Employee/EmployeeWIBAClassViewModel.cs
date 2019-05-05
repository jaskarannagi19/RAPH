using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public class EmployeeWIBAClassEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeWIBAClassID { get; set; }

        [DisplayName("Employee WIBAClass")]
        public string EmployeeWIBAClassName { get; set; }
    }

    public class EmployeeWIBAClassLookupListModel
    {
        [Browsable(false)]
        public int EmployeeWIBAClassID { get; set; }

        [DisplayName("Employee WIBAClass")]
        public string EmployeeWIBAClassName { get; set; }
    }
}
