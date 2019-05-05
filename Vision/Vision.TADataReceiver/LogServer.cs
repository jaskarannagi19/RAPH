using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Vision.TADataReceiver
{
    class LogServer : IDisposable
    {
        public Boolean disposed;
        public Int32 portNum;
        public TcpListener theListener;
        static LinkedList<Terminal> listTerms = new LinkedList<Terminal>();

        private void CleanUp(bool disposing)
        {
            if (this.disposed)
                return;

            this.disposed = true;

            if (disposing)
            {
                // Dispose the listener and terminals.
                try
                {
                    theListener.Stop();
                    foreach (Terminal e in listTerms)
                    {
                        if (e != null)
                        {
                            //e.MessageRecieved -= DataReceiver.Terminal_MessageRecieved;
                            e.Dispose();
                        }
                    }
                }
                catch { }
            }
        }

        public void Dispose()
        {
            CleanUp(true);
        }

        public LogServer(Int32 portNum_)
        {
            // Initialize objects.
            disposed = false;
            portNum = portNum_;

            // Start listener.
            theListener = new TcpListener(IPAddress.Any, portNum);
            theListener.Server.SetSocketOption(SocketOptionLevel.Socket,
                SocketOptionName.ReuseAddress, true);
            theListener.Start();

            // Begin accept.
            theListener.BeginAcceptTcpClient(
                new AsyncCallback(LogServer.OnAccept), this);
        }

        ~LogServer()
        {
            CleanUp(false);
        }

        public static void OnAccept(IAsyncResult iar)
        {
            frmLogStatus.LogMessage(new Model.BMDevice.LogViewModel() { LogMessage = "Message Received." });
            //--
            LogServer server = (LogServer)iar.AsyncState;
            Terminal term = new Terminal();
            //term.MessageRecieved += DataReceiver.Terminal_MessageRecieved;
            try
            {
                // Establish connection and add a terminal into the list.
                term.EstablishConnect(
                    server.theListener.EndAcceptTcpClient(iar));
                listTerms.AddLast(term);
            }
            catch
            {
                //term.MessageRecieved -= DataReceiver.Terminal_MessageRecieved;
                term.Dispose();
            }

            try
            {
                // For disposed listener.
                server.theListener.BeginAcceptTcpClient(
                    new AsyncCallback(LogServer.OnAccept), server);
            }
            catch { }
        }
    }
}
