using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Payroll
{

    public enum eHolidayType
    {
        PublicHoliday = 0,
        OptionalHoliday = 1
    }

    public class HolidayEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int HolidayID { get; set; }

        [DisplayName("Holiday")]
        public string HolidayName { get; set; }

        public string Type { get; set; }

        [DisplayName("From")]
        public DateTime DateFrom { get; set; }

        [DisplayName("To")]
        public DateTime DateTo { get; set; }
    }

    public class HolidayLookupListModel
    {
        [Browsable(false)]
        public int HolidayID { get; set; }

        [DisplayName("Holiday")]
        public string HolidayName { get; set; }

        public string Type { get; set; }

        [DisplayName("From")]
        public DateTime DateFrom { get; set; }

        [DisplayName("To")]
        public DateTime DateTo { get; set; }
    }
}
