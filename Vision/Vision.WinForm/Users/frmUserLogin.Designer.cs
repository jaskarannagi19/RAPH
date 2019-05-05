namespace Vision.WinForm.Users
{
    partial class frmUserLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserLogin));
            this.layoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.btnForgetPassword = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new Alit.WinformControls.TextEdit();
            this.txtUserName = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            resources.ApplyResources(this.panelContent, "panelContent");
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnExit.ItemAppearance.Normal.FontStyleDelta")));
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnRefresh.ItemAppearance.Normal.FontStyleDelta")));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSave.ItemAppearance.Normal.FontStyleDelta")));
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // barFormFooter
            // 
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnForgetPassword);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Controls.Add(this.txtUserName);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // btnForgetPassword
            // 
            resources.ApplyResources(this.btnForgetPassword, "btnForgetPassword");
            this.btnForgetPassword.Name = "btnForgetPassword";
            this.btnForgetPassword.StyleController = this.layoutControl1;
            this.btnForgetPassword.TabStop = false;
            this.btnForgetPassword.Click += new System.EventHandler(this.btnForgetPassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.EnterMoveNextControl = true;
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.StyleController = this.layoutControl1;
            // 
            // txtUserName
            // 
            this.txtUserName.EnterMoveNextControl = true;
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.StyleController = this.layoutControl1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciUserName,
            this.lciPassword,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(433, 112);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.txtUserName;
            this.lciUserName.Location = new System.Drawing.Point(0, 0);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(402, 24);
            resources.ApplyResources(this.lciUserName, "lciUserName");
            this.lciUserName.TextSize = new System.Drawing.Size(52, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.txtPassword;
            this.lciPassword.Location = new System.Drawing.Point(0, 24);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(402, 24);
            resources.ApplyResources(this.lciPassword, "lciPassword");
            this.lciPassword.TextSize = new System.Drawing.Size(52, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(210, 44);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(402, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(11, 92);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnForgetPassword;
            this.layoutControlItem1.Location = new System.Drawing.Point(210, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(192, 34);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(210, 82);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(192, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmUserLogin
            // 
            this.AllowRefresh = false;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FirstControl = this.layoutControl1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserLogin";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Alit.WinformControls.TextEdit txtPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private Alit.WinformControls.TextEdit txtUserName;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SimpleButton btnForgetPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}