using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.BMDevice
{
    public class ReceivedMessageViewModel
    {
        public string TerminalType { get; set; }

        public int TerminaID { get; set; }

        public string DeviceSerialNo { get; set; }

        public int TransactionID { get; set; }

        public string EventType { get; set; }

        public DateTime LogTime { get; set; }

        public int EmployeeTACode { get; set; }

        public string PunchType { get; set; }

        public string VerificationMode { get; set; }

        public string Action { get; set; }
    }
}
