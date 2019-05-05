using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class TAApprovalNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int TAApprovalNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string TAApprovalNoPrefixName { get; set; }
    }

    public class TAApprovalNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int TAApprovalNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string TAApprovalNoPrefixName { get; set; }
    }
}
