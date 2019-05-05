using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.BMDevice;

namespace Vision.TADataReceiver
{
    public class MessageReceivedEventArgs
    {
        public ReceivedMessageViewModel Message { get; set; }

        /// <summary>
        /// true : process return/upload read mark for this message. It will be set true only when this message was saved in database.
        /// </summary>
        [IODescription("true : process return/upload read mark for this message. It will be set true only when this message was saved in database.")]
        public bool ProcessAcknowledgement { get; set; }
    }
}
