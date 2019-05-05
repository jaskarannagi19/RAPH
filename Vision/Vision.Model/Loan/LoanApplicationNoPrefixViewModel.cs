using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Loan
{
    public class LoanApplicationNoPrefixEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LoanApplicationNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LoanApplicationNoPrefixName { get; set; }
    }

    public class LoanApplicationNoPrefixLookupListModel
    {
        [Browsable(false)]
        public int LoanApplicationNoPrefixID { get; set; }

        [DisplayName("Prefix Name")]
        public string LoanApplicationNoPrefixName { get; set; }
    }
}
