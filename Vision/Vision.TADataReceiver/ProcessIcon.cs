using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.TADataReceiver
{
    public class ProcessIcon : IDisposable
    {
        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        public NotifyIcon ApplicationIcon;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessIcon"/> class.
        /// </summary>
        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            ApplicationIcon = new NotifyIcon();
        }

        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ApplicationIcon.MouseDoubleClick += new MouseEventHandler(ni_MouseClick);
            ApplicationIcon.Icon = Properties.Resources.icons8_iris_scan_100;
            ApplicationIcon.Text = "Vision Data Reciever";
            ApplicationIcon.Visible = true;

            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();

            //// View Sync Log
            ToolStripMenuItem item_ViewSyncLog;
            item_ViewSyncLog = new ToolStripMenuItem();
            item_ViewSyncLog.Text = "View Sync Log";
            item_ViewSyncLog.Click += Item_ViewSyncLog_Click; ;
            item_ViewSyncLog.Image = Properties.Resources.Search_16;
            menu.Items.Add(item_ViewSyncLog);

            //// Separator.
            //ToolStripSeparator sep;
            //sep = new ToolStripSeparator();
            //menu.Items.Add(sep);

            // Exit.
            ToolStripMenuItem item_Exit;
            item_Exit = new ToolStripMenuItem();
            item_Exit.Text = "Exit";
            item_Exit.Click += Item_Exit_Click;
            item_Exit.Image = Properties.Resources.Close_Window_16;
            menu.Items.Add(item_Exit);

            // Attach a context menu.
            ApplicationIcon.ContextMenuStrip = menu;
        }

        private void Item_ViewSyncLog_Click(object sender, EventArgs e)
        {
            frmLogStatus.ShowLogForm();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ApplicationIcon.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            //frmSyncLogView.ShowSyncLogView();
            frmLogStatus.ShowLogForm();
        }

        private void Item_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
