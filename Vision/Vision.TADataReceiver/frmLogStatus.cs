using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.TADataReceiver
{
    public partial class frmLogStatus : Form
    {

        private static frmLogStatus LogForm_;
        private static frmLogStatus LogForm
        {
            get
            {
                return LogForm_;
            }
            set
            {
                LogForm_ = value;
            }
        }

        private frmLogStatus()
        {
            InitializeComponent();
        }

        private void AddMessage(Model.BMDevice.LogViewModel Log)
        {
            this.Invoke((MethodInvoker)delegate
            {
                logViewModelBindingSource.Insert(0, Log);
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                dataGridView1.Refresh();
                dataGridView1.Invalidate();
            });
        }

        public static void LogMessage(Model.BMDevice.LogViewModel Log)
        {
            if(LogForm != null)
            {
                LogForm.AddMessage(Log);
            }
        }

        public static void ShowLogForm()
        {
            LogForm = new frmLogStatus();
            LogForm.Show();
        }
    }
}
