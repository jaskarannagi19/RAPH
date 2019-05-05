using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{
    public class SafariApplicationNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int SafariApplicationNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string SafariApplicationNoPrefixName { get; set; }
    }

    public class SafariApplicationNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int SafariApplicationNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string SafariApplicationNoPrefixName { get; set; }
    }
}
