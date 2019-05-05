using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.City
{
    public class CityEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int CityID { get; set; }

        [DisplayName("City")]
        public string CityName { get; set; }

        [Browsable(false)]
        public int StateID { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }

        [DisplayName("Country")]
        public string CountryName { get; set; }
    }

    public class CityLookupListModel
    {
        [Browsable(false)]
        public int CityID { get; set; }

        [DisplayName("City")]
        public string CityName { get; set; }

        [Browsable(false)]
        public int StateID { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }

        [DisplayName("Country")]
        public string CountryName { get; set; }
    }

    public class CityDetailViewModel
    {
        [Browsable(false)]
        public int CityID { get; set; }

        [DisplayName("City")]
        public string CityName { get; set; }

        [Browsable(false)]
        public int? StateID { get; set; }

        [DisplayName("State")]
        public string StateName { get; set; }

        [Browsable(false)]
        public int CountryID { get; set; }

        [DisplayName("Country")]
        public string CountryName { get; set; }
    }
}