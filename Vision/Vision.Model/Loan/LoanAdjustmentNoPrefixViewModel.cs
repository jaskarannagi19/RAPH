using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Loan
{
    public class LoanAdjustmentNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LoanAdjustmentNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LoanAdjustmentNoPrefixName { get; set; }
    }

    public class LoanAdjustmentNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int LoanAdjustmentNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LoanAdjustmentNoPrefixName { get; set; }
    }
}
