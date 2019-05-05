using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.City
{
    public class StateEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int StateID { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }

        [DisplayName("Country")]
        public string CountryName { get; set; }
    }

    public class StateLookUpListModel
    {
        [Browsable(false)]
        public int StateID { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }
    }
}
