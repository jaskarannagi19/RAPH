using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class LeaveAdjustmentNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LeaveAdjustmentNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LeaveAdjustmentNoPrefixName { get; set; }
    }

    public class LeaveAdjustmentNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int LeaveAdjustmentNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LeaveAdjustmentNoPrefixName { get; set; }
    }
}
