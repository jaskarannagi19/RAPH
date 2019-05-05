using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.SubMaster
{
    public class CurrencyEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int CurrencyID { get; set; }

        [DisplayName("Currency Name")]
        public string CurrencyName { get; set; }

        [DisplayName("Symbole")]
        public string CurrencySymbole { get; set; }
    }

    public class CurrencyLookupListModel
    {
        [Browsable(false)]
        public int CurrencyID { get; set; }

        [DisplayName("Currency Name")]
        public string CurrencyName { get; set; }

        [DisplayName("Symbole")]
        public string CurrencySymbole { get; set; }
    }
}
