using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.City
{
    public class CountryEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int CountryID { get; set; }

        [DisplayName("Country Name")]
        public string CountryName { get; set; }

        //[DisplayName("ISD Code")]
        //public string ISDCode { get; set; }
    }
}
