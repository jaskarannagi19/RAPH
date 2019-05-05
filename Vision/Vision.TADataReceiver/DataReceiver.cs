using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vision.TADataReceiver
{
    class DataReceiver : IDisposable
    {
        LogServer theLogServer; // Log server
        Boolean stopping;       // Is stopping?
        ManualResetEvent stoppedEvent;//stop event

        enum ThreadState { RUNNING, STOPPED };
        ThreadState watchState;

        int PortNo;
        public DataReceiver()
        {
            // Initialize objects
            watchState = ThreadState.STOPPED;
            PortNo = 5005;
        }

        // Message recieved and process it to save in database
        internal static void Terminal_MessageRecieved(MessageReceivedEventArgs MessageArgs)
        {
            DAL.BMDevice.TADataReceiverDAL DataReceiverDALObj = new DAL.BMDevice.TADataReceiverDAL();
            var res = DataReceiverDALObj.SaveEmployeeAttendanceDetail(MessageArgs.Message);
            if (res != null && res.ExecutionResult == Model.eExecutionResult.CommitedSucessfuly)
            {
                MessageArgs.ProcessAcknowledgement = true;
                frmLogStatus.LogMessage(new Model.BMDevice.LogViewModel(MessageArgs.Message)
                {
                    LogMessage = "Saved." + (!String.IsNullOrWhiteSpace(res.MessageAfterSave) ? ": " + res.MessageAfterSave : "")
                });
                if (!String.IsNullOrWhiteSpace(res.MessageAfterSave))
                {
                    DataReceiverDALObj.SaveDataReceiverErrorLog("Save with Validation Error", res.MessageAfterSave);

                    Program.NotifyApplicationIcon.ApplicationIcon.ShowBalloonTip(10000, "Saved with Validation Error", res.MessageAfterSave, System.Windows.Forms.ToolTipIcon.Warning);
                }
            }
            else
            {
                string ErrorMessage = (res != null ?
                    (res.ExecutionResult == Model.eExecutionResult.ErrorWhileExecuting ?
                        (res.Exception != null ? res.Exception.Message : "") :
                    (res.ExecutionResult == Model.eExecutionResult.ValidationError ? res.ValidationError : "")) : "");

                frmLogStatus.LogMessage(new Model.BMDevice.LogViewModel(MessageArgs.Message)
                {
                    LogMessage = "Error while saving : " + ErrorMessage,
                });

                DataReceiverDALObj.SaveDataReceiverErrorLog("Error while saving attendance data", ErrorMessage);

                if (!String.IsNullOrWhiteSpace(ErrorMessage))
                {
                    Program.NotifyApplicationIcon.ApplicationIcon.ShowBalloonTip(10000, "Vision : Error while saving attendance.", ErrorMessage, System.Windows.Forms.ToolTipIcon.Error);
                }
            }
        }

        private void WatchEventThread(object state)
        {
            theLogServer = new LogServer(PortNo);  // Create and start log server.

            // Watch stop signal.
            while (!this.stopping)
            {
                Thread.Sleep(100);  // Simulate some lengthy operations.
            }

            theLogServer.Dispose(); // Dispose log server
            this.stoppedEvent.Set();// Signal the stopped event.
        }

        public void Start()
        {
            this.stopping = false;
            this.stoppedEvent = new ManualResetEvent(false);

            if (ThreadPool.QueueUserWorkItem(new WaitCallback(WatchEventThread)))
            {
                watchState = ThreadState.RUNNING;
            }

            frmLogStatus.LogMessage(new Model.BMDevice.LogViewModel() { LogMessage = "Time & Attendance data receiver is started." });
            Program.NotifyApplicationIcon.ApplicationIcon.ShowBalloonTip(3000, "Vision:", "Time & Attendance data receiver is started.", System.Windows.Forms.ToolTipIcon.Info);
        }

        public void Stop()
        {
            this.stopping = true;
            this.stoppedEvent.WaitOne();

            watchState = ThreadState.STOPPED;
            Program.NotifyApplicationIcon.ApplicationIcon.ShowBalloonTip(3000, "Vision:", "Time & Attendance data receiver stopped.", System.Windows.Forms.ToolTipIcon.Warning);
        }

        public void Dispose()
        {
            if (watchState != ThreadState.STOPPED)
            {
                Stop();
            }
            if (theLogServer != null && !theLogServer.disposed)
            {
                theLogServer.Dispose();
                theLogServer = null;
            }
        }
    }
}
