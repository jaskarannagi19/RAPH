using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class LeaveEncashmentNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LeaveEncashmentNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LeaveEncashmentNoPrefixName { get; set; }
    }

    public class LeaveEncashmentNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int LeaveEncashmentNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LeaveEncashmentNoPrefixName { get; set; }
    }
}
