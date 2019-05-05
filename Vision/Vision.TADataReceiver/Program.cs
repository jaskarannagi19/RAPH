using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.TADataReceiver
{
    static class Program
    {
        public static ProcessIcon NotifyApplicationIcon { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (ProcessIcon pi = new ProcessIcon())
            {
                NotifyApplicationIcon = pi;
                pi.Display();
                using (DataReceiver Receiver = new DataReceiver())
                {
                    Receiver.Start();
                    // Make sure the application runs!
                    Application.Run();
                    //
                    if (Receiver != null)
                    {
                        Receiver.Stop();
                    }
                }
            }
        }
    }
}
