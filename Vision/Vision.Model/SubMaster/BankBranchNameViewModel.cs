using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.SubMaster
{
    public class BankBranchEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int BankBranchID { get; set; }

        [DisplayName("Branch Name")]
        public string BankBranchName { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("City")]
        public string City { get; set; }
    }

    public class BankBranchLookupListModel
    {
        [Browsable(false)]
        public int BankBranchID { get; set; }

        [DisplayName("Branch Name")]
        public string BankBranchName { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }
    }
}
