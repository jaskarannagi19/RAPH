using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Account
{
    public class BankAccountEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int BankAccountID { get; set; }

        [DisplayName("Bank Account Name")]
        public string BankAccountName { get; set; }

        [DisplayName("Bank A/c No.")]
        public string BankAccountNo { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }
    }

    public class BankAccountLookupListModel
    {
        [Browsable(false)]
        public int BankAccountID { get; set; }

        [DisplayName("Bank Account Name")]
        public string BankAccountName { get; set; }

        [DisplayName("Bank A/c No.")]
        public string BankAccountNo { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Branch Name")]
        public string BranchName { get; set; }
    }
}
