using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.Model.BMDevice
{
    public class LogViewModel
    {
        public LogViewModel()
        {

        }

        public LogViewModel(ReceivedMessageViewModel Message)
        {
            this.EmployeeTACode = Message.EmployeeTACode;
            this.LogTime = Message.LogTime;
            this.PunchType = Message.PunchType;
            this.VerificationMode = Message.VerificationMode;
            this.TerminalType = Message.TerminalType;
            this.TerminaID = Message.TerminaID;
            this.DeviceSerialNo = Message.DeviceSerialNo;
            this.TransactionID = Message.TransactionID;
            this.EventType = Message.EventType;
            this.Action = Message.Action;
        }

        [DisplayName("Log Message")]
        public string LogMessage { get; set; }

        [DisplayName("TA Code")]
        public int? EmployeeTACode { get; set; }

        [DisplayName("Time")]
        public DateTime LogTime { get; set; }

        [DisplayName("Punch Type")]
        public string PunchType { get; set; }

        [DisplayName("Verification Mode")]
        public string VerificationMode { get; set; }

        [DisplayName("Terminal Type")]
        public string TerminalType { get; set; }

        [DisplayName("Terminal ID")]
        public int? TerminaID { get; set; }

        [DisplayName("Device Ser. No.")]
        public string DeviceSerialNo { get; set; }

        [DisplayName("Transaction ID")]
        public int? TransactionID { get; set; }

        [DisplayName("Event Type")]
        public string EventType { get; set; }

        [DisplayName("Action")]
        public string Action { get; set; }
    }
}
