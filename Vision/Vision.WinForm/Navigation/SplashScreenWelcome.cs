using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace Vision.WinForm.Navigation
{
    public partial class SplashScreenWelcome : SplashScreen
    {
        public SplashScreenWelcome()
        {
            InitializeComponent();
            this.lblProductName.Text = Model.CommonProperties.DevelopmentCompanyInfo.ProductName;
            this.labelControl1.Text = "Copyright © 2018-" + DateTime.Now.Year.ToString();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }
    }
}