namespace Vision.WinForm.Users
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtCurrentPassword = new Alit.WinformControls.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txtNewPassword = new Alit.WinformControls.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtConfirmPassword = new Alit.WinformControls.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(521, 112);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 112);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(521, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 112);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 112);
            this.barDockControlBottom.Size = new System.Drawing.Size(521, 28);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(521, 0);
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // barFormFooter
            // 
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.txtConfirmPassword);
            this.myLayoutControl1.Controls.Add(this.txtNewPassword);
            this.myLayoutControl1.Controls.Add(this.txtCurrentPassword);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(517, 108);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(517, 108);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.EnterMoveNextControl = true;
            this.txtCurrentPassword.Location = new System.Drawing.Point(101, 12);
            this.txtCurrentPassword.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtCurrentPassword.MenuManager = this.barManager1;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Properties.MaxLength = 50;
            this.txtCurrentPassword.Properties.UseSystemPasswordChar = true;
            this.txtCurrentPassword.Size = new System.Drawing.Size(394, 20);
            this.txtCurrentPassword.StyleController = this.myLayoutControl1;
            this.txtCurrentPassword.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCurrentPassword;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(487, 24);
            this.layoutControlItem1.Text = "Current Password";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(86, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(487, 16);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.EnterMoveNextControl = true;
            this.txtNewPassword.Location = new System.Drawing.Point(101, 36);
            this.txtNewPassword.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtNewPassword.MenuManager = this.barManager1;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Properties.MaxLength = 50;
            this.txtNewPassword.Properties.UseSystemPasswordChar = true;
            this.txtNewPassword.Size = new System.Drawing.Size(394, 20);
            this.txtNewPassword.StyleController = this.myLayoutControl1;
            this.txtNewPassword.TabIndex = 5;
            this.txtNewPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPassword_Validating);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtNewPassword;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(487, 24);
            this.layoutControlItem2.Text = "New Password";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(86, 13);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.EnterMoveNextControl = true;
            this.txtConfirmPassword.Location = new System.Drawing.Point(101, 60);
            this.txtConfirmPassword.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtConfirmPassword.MenuManager = this.barManager1;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.MaxLength = 50;
            this.txtConfirmPassword.Properties.UseSystemPasswordChar = true;
            this.txtConfirmPassword.Size = new System.Drawing.Size(394, 20);
            this.txtConfirmPassword.StyleController = this.myLayoutControl1;
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtConfirmPassword;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(487, 24);
            this.layoutControlItem3.Text = "Confirm Password";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(86, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(487, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 88);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmChangePassword
            // 
            this.AllowRefresh = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 140);
            this.FirstControl = this.myLayoutControl1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurrentPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Alit.WinformControls.TextEdit txtConfirmPassword;
        private Alit.WinformControls.TextEdit txtNewPassword;
        private Alit.WinformControls.TextEdit txtCurrentPassword;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}