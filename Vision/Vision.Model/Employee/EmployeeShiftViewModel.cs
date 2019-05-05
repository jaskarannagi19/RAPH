using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.Employee
{
    public enum eEmployeeShiftType
    {
        Fixed = 0,
        Rotation = 1,
    }

    public class EmployeeShiftEditListModel : EditUserInfo
    {
        [Browsable(false)]
        public int EmployeeShiftID { get; set; }

        [DisplayName("Shift Name")]
        public string EmployeeShiftName { get; set; }

        [DisplayName("Start Time")]
        public TimeSpan ShiftStart { get; set; }

        [DisplayName("End Time")]
        public TimeSpan ShiftEnd { get; set; }
    }

    public class EmployeeShiftLookupListModel
    {
        [Browsable(false)]
        public int EmployeeShiftID { get; set; }

        [DisplayName("Shift Name")]
        public string EmployeeShiftName { get; set; }


        [DisplayName("Start Time")]
        public TimeSpan ShiftStart { get; set; }

        [DisplayName("End Time")]
        public TimeSpan ShiftEnd { get; set; }
    }
}
