using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.SubMaster
{
    public class BankNameEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int BankNameID { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Short Name")]
        public string ShortName { get; set; }
    }

    public class BankNameLookupListModel
    {
        [Browsable(false)]
        public int BankNameID { get; set; }

        [DisplayName("Bank Name")]
        public string BankName { get; set; }

        [DisplayName("Symbole")]
        public string ShortName { get; set; }
    }
}
