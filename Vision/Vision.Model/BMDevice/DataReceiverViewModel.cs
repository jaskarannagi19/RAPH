using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.BMDevice
{
    public static class DataReceiverViewModel
    {
        public const string PunchType_DutyOn = "Duty On";
        public const string PunchType_In = "In";
        public const string PunchType_OverTimeOn = "Overtime On";
        public const string PunchType_DutyOff = "Duty Off";
        public const string PunchType_Out = "Out";
        public const string PunchType_OverTimeOff = "Overtime Off";
    }

    public enum eLogTimeType
    {
        Unknown = 0,
        In = 1,
        Out = 2,
    }
}
