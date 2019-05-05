using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class LeaveApplicationNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LeaveApplicationNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LeaveApplicationNoPrefixName { get; set; }
    }

    public class LeaveApplicationNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int LeaveApplicationNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LeaveApplicationNoPrefixName { get; set; }
    }
}
