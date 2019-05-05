namespace Vision.WinForm.Users
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.layoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.txtEmailID = new Alit.WinformControls.TextEdit();
            this.lookUpUserGroup = new Alit.WinformControls.LookUpEdit();
            this.txtPassword = new Alit.WinformControls.TextEdit();
            this.txtUserName = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUserGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
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
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSave.ItemAppearance.Normal.FontStyleDelta")));
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnDelete.ItemAppearance.Normal.FontStyleDelta")));
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnRefresh.ItemAppearance.Normal.FontStyleDelta")));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnExit
            // 
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnExit.ItemAppearance.Normal.FontStyleDelta")));
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // btnSearch
            // 
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSearch.ItemAppearance.Normal.FontStyleDelta")));
            this.btnSearch.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblCreatedBy.ItemAppearance.Normal.FontStyleDelta")));
            this.lblCreatedBy.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // lblEditedBy
            // 
            this.lblEditedBy.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("lblEditedBy.ItemAppearance.Normal.FontStyleDelta")));
            this.lblEditedBy.ItemAppearance.Normal.Options.UseFont = true;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            resources.ApplyResources(this.panelContent, "panelContent");
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtEmailID);
            this.layoutControl1.Controls.Add(this.lookUpUserGroup);
            this.layoutControl1.Controls.Add(this.txtPassword);
            this.layoutControl1.Controls.Add(this.txtUserName);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // txtEmailID
            // 
            this.txtEmailID.EnterMoveNextControl = true;
            resources.ApplyResources(this.txtEmailID, "txtEmailID");
            this.txtEmailID.MenuManager = this.barManager1;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Properties.MaxLength = 50;
            this.txtEmailID.StyleController = this.layoutControl1;
            this.txtEmailID.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailID_Validating);
            // 
            // lookUpUserGroup
            // 
            this.lookUpUserGroup.EnterMoveNextControl = true;
            resources.ApplyResources(this.lookUpUserGroup, "lookUpUserGroup");
            this.lookUpUserGroup.MenuManager = this.barManager1;
            this.lookUpUserGroup.Name = "lookUpUserGroup";
            this.lookUpUserGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("lookUpUserGroup.Properties.Buttons"))))});
            this.lookUpUserGroup.Properties.NullText = resources.GetString("lookUpUserGroup.Properties.NullText");
            this.lookUpUserGroup.StyleController = this.layoutControl1;
            this.lookUpUserGroup.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpUserGroup_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.EnterMoveNextControl = true;
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.MenuManager = this.barManager1;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.MaxLength = 50;
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.StyleController = this.layoutControl1;
            // 
            // txtUserName
            // 
            this.txtUserName.EnterMoveNextControl = true;
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.MenuManager = this.barManager1;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.MaxLength = 50;
            this.txtUserName.StyleController = this.layoutControl1;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(696, 146);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtUserName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(676, 24);
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPassword;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(676, 24);
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lookUpUserGroup;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(676, 54);
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtEmailID;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(676, 24);
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.TextSize = new System.Drawing.Size(54, 13);
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // frmUser
            // 
            this.AllowDeleteUI = false;
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FirstControl = this.layoutControl1;
            this.Name = "frmUser";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpUserGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Alit.WinformControls.myLayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Alit.WinformControls.TextEdit txtPassword;
        private Alit.WinformControls.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private Alit.WinformControls.LookUpEdit lookUpUserGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Alit.WinformControls.TextEdit txtEmailID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}