using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Settings
{

    public enum eLocationType
    {
        Urban = 0,
        Rural = 1
    }

    public enum eWeekDayType
    {
        WorkingDay = 0,
        HalfDay = 1,
        Weekend = 2,
        Holiday = 3, 
    }

    public class LocationEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int LocationID { get; set; }

        [DisplayName("Location Name")]
        public string LocationName { get; set; }

        [DisplayName("Location Type")]
        public string LocationType { get; set; }
    }

    public class LocationLookupListModel
    {
        [Browsable(false)]
        public int LocationID { get; set; }

        [DisplayName("Location Name")]
        public string LocationName { get; set; }
    }

    public class LocationWeekendSettingViewModel
    {
        public DateTime? WEDateFrom { get; set; }
        public DateTime? WEDateTo { get; set; }

        public eWeekDayType Monday { get; set; }
        public eWeekDayType Tuesday { get; set; }
        public eWeekDayType Wednesday { get; set; }
        public eWeekDayType Thursday { get; set; }
        public eWeekDayType Friday { get; set; }
        public eWeekDayType Saturday { get; set; }
        public eWeekDayType Sunday { get; set; }

    }
}
