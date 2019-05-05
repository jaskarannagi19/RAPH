using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.BMDevice
{
    public class BiometricDeviceEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int BMDID { get; set; }

        [DisplayName("Title")]
        public string BMDTitle { get; set; }

        [DisplayName("Machine No.")]
        public int MachineNo { get; set; }

        [DisplayName("IP Address")]
        public string IPAddress { get; set; }

        [DisplayName("Port No.")]
        public int PortNo { get; set; }

        [DisplayName("Password")]
        public int Password { get; set; }
    }

    public class BiometricDeviceLookupListModel
    {
        [Browsable(false)]
        public int BMDID { get; set; }

        [DisplayName("Title")]
        public string BMDTitle { get; set; }

        [DisplayName("Machine No.")]
        public int MachineNo { get; set; }

        [DisplayName("IP Address")]
        public string IPAddress { get; set; }

        [DisplayName("Port No.")]
        public int PortNo { get; set; }

        [DisplayName("Password")]
        public int Password { get; set; }
    }
}
