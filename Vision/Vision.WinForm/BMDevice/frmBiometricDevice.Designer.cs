namespace Vision.WinForm.BMDevice
{
    partial class frmBiometricDevice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBiometricDevice));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.btnConnectDevice = new DevExpress.XtraEditors.SimpleButton();
            this.gcEmployeeAttendance = new DevExpress.XtraGrid.GridControl();
            this.gvEmployeeAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnGetEmployeeAttendance = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new Alit.WinformControls.TextEdit();
            this.txtPortNo = new Alit.WinformControls.TextEdit();
            this.txtIPAddress = new Alit.WinformControls.TextEdit();
            this.txtMachineNo = new Alit.WinformControls.TextEdit();
            this.txtBMDTitle = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployeeAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployeeAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBMDTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            this.SuspendLayout();
            // 
            // barFormHeader
            // 
            this.barFormHeader.OptionsBar.AllowQuickCustomization = false;
            this.barFormHeader.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barFormHeader.OptionsBar.DisableClose = true;
            this.barFormHeader.OptionsBar.DisableCustomization = true;
            this.barFormHeader.OptionsBar.DrawDragBorder = false;
            this.barFormHeader.OptionsBar.UseWholeRow = true;
            // 
            // barFormFooter
            // 
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Size = new System.Drawing.Size(594, 28);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 485);
            this.barDockControlBottom.Size = new System.Drawing.Size(594, 28);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 28);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 457);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Location = new System.Drawing.Point(594, 28);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 457);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSearch.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblCreatedBy.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // lblEditedBy
            // 
            this.lblEditedBy.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.lblEditedBy.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.MaximumSize = new System.Drawing.Size(565, 0);
            this.panelContent.Size = new System.Drawing.Size(565, 431);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.btnConnectDevice);
            this.myLayoutControl1.Controls.Add(this.gcEmployeeAttendance);
            this.myLayoutControl1.Controls.Add(this.btnGetEmployeeAttendance);
            this.myLayoutControl1.Controls.Add(this.txtPassword);
            this.myLayoutControl1.Controls.Add(this.txtPortNo);
            this.myLayoutControl1.Controls.Add(this.txtIPAddress);
            this.myLayoutControl1.Controls.Add(this.txtMachineNo);
            this.myLayoutControl1.Controls.Add(this.txtBMDTitle);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(561, 427);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // btnConnectDevice
            // 
            this.btnConnectDevice.Location = new System.Drawing.Point(248, 84);
            this.btnConnectDevice.MinimumSize = new System.Drawing.Size(0, 40);
            this.btnConnectDevice.Name = "btnConnectDevice";
            this.btnConnectDevice.Size = new System.Drawing.Size(301, 40);
            this.btnConnectDevice.StyleController = this.myLayoutControl1;
            this.btnConnectDevice.TabIndex = 11;
            this.btnConnectDevice.Text = "Connect Device ";
            this.btnConnectDevice.Click += new System.EventHandler(this.btnConnectDevice_Click);
            // 
            // gcEmployeeAttendance
            // 
            this.gcEmployeeAttendance.Location = new System.Drawing.Point(12, 186);
            this.gcEmployeeAttendance.MainView = this.gvEmployeeAttendance;
            this.gcEmployeeAttendance.MenuManager = this.barManager1;
            this.gcEmployeeAttendance.Name = "gcEmployeeAttendance";
            this.gcEmployeeAttendance.Size = new System.Drawing.Size(537, 229);
            this.gcEmployeeAttendance.TabIndex = 10;
            this.gcEmployeeAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEmployeeAttendance});
            // 
            // gvEmployeeAttendance
            // 
            this.gvEmployeeAttendance.GridControl = this.gcEmployeeAttendance;
            this.gvEmployeeAttendance.Name = "gvEmployeeAttendance";
            // 
            // btnGetEmployeeAttendance
            // 
            this.btnGetEmployeeAttendance.Location = new System.Drawing.Point(12, 132);
            this.btnGetEmployeeAttendance.MinimumSize = new System.Drawing.Size(0, 50);
            this.btnGetEmployeeAttendance.Name = "btnGetEmployeeAttendance";
            this.btnGetEmployeeAttendance.Size = new System.Drawing.Size(537, 50);
            this.btnGetEmployeeAttendance.StyleController = this.myLayoutControl1;
            this.btnGetEmployeeAttendance.TabIndex = 9;
            this.btnGetEmployeeAttendance.Text = "Get Employee Attendance ";
            this.btnGetEmployeeAttendance.Click += new System.EventHandler(this.btnGetEmployeeAttendance_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.EnterMoveNextControl = true;
            this.txtPassword.Location = new System.Drawing.Point(94, 108);
            this.txtPassword.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtPassword.MenuManager = this.barManager1;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Mask.EditMask = "n0";
            this.txtPassword.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPassword.Size = new System.Drawing.Size(150, 20);
            this.txtPassword.StyleController = this.myLayoutControl1;
            this.txtPassword.TabIndex = 8;
            // 
            // txtPortNo
            // 
            this.txtPortNo.EnterMoveNextControl = true;
            this.txtPortNo.Location = new System.Drawing.Point(94, 84);
            this.txtPortNo.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtPortNo.MenuManager = this.barManager1;
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Properties.Mask.EditMask = "n0";
            this.txtPortNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPortNo.Size = new System.Drawing.Size(150, 20);
            this.txtPortNo.StyleController = this.myLayoutControl1;
            this.txtPortNo.TabIndex = 7;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.EnterMoveNextControl = true;
            this.txtIPAddress.Location = new System.Drawing.Point(94, 60);
            this.txtIPAddress.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtIPAddress.MenuManager = this.barManager1;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Properties.Mask.EditMask = "000.000.000.000";
            this.txtIPAddress.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtIPAddress.Size = new System.Drawing.Size(200, 20);
            this.txtIPAddress.StyleController = this.myLayoutControl1;
            this.txtIPAddress.TabIndex = 6;
            this.txtIPAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtIPAddress_Validating);
            // 
            // txtMachineNo
            // 
            this.txtMachineNo.EnterMoveNextControl = true;
            this.txtMachineNo.Location = new System.Drawing.Point(94, 36);
            this.txtMachineNo.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtMachineNo.MenuManager = this.barManager1;
            this.txtMachineNo.Name = "txtMachineNo";
            this.txtMachineNo.Properties.Mask.EditMask = "n0";
            this.txtMachineNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMachineNo.Size = new System.Drawing.Size(150, 20);
            this.txtMachineNo.StyleController = this.myLayoutControl1;
            this.txtMachineNo.TabIndex = 5;
            // 
            // txtBMDTitle
            // 
            this.txtBMDTitle.EnterMoveNextControl = true;
            this.txtBMDTitle.Location = new System.Drawing.Point(94, 12);
            this.txtBMDTitle.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtBMDTitle.MenuManager = this.barManager1;
            this.txtBMDTitle.Name = "txtBMDTitle";
            this.txtBMDTitle.Properties.MaxLength = 50;
            this.txtBMDTitle.Size = new System.Drawing.Size(400, 20);
            this.txtBMDTitle.StyleController = this.myLayoutControl1;
            this.txtBMDTitle.TabIndex = 4;
            this.txtBMDTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtBMDTitle_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem7,
            this.layoutControlItem6,
            this.layoutControlItem8});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(561, 427);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtBMDTitle;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(541, 24);
            this.layoutControlItem1.Text = "Device Title";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMachineNo;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(236, 24);
            this.layoutControlItem2.Text = "Machine Number";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtIPAddress;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(286, 24);
            this.layoutControlItem3.Text = "IP Address";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtPortNo;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(236, 24);
            this.layoutControlItem4.Text = "Port No";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(79, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtPassword;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(236, 24);
            this.layoutControlItem5.Text = "Password";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(79, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(236, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(305, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(286, 48);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(255, 24);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gcEmployeeAttendance;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 174);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(541, 233);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnGetEmployeeAttendance;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(541, 54);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnConnectDevice;
            this.layoutControlItem8.Location = new System.Drawing.Point(236, 72);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(305, 48);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // frmBiometricDevice
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 513);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmBiometricDevice";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Biometric Device";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployeeAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployeeAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIPAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMachineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBMDTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.TextEdit txtPassword;
        private Alit.WinformControls.TextEdit txtPortNo;
        private Alit.WinformControls.TextEdit txtIPAddress;
        private Alit.WinformControls.TextEdit txtMachineNo;
        private Alit.WinformControls.TextEdit txtBMDTitle;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.GridControl gcEmployeeAttendance;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEmployeeAttendance;
        private DevExpress.XtraEditors.SimpleButton btnGetEmployeeAttendance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnConnectDevice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}