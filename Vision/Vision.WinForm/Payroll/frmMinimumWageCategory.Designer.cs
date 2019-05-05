namespace Vision.WinForm.Payroll
{
    partial class frmMinimumWageCategory
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
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.cmbApplyOn = new Alit.WinformControls.ComboBoxEdit();
            this.txtMinimumWageCategoryName = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbApplyOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimumWageCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Location = new System.Drawing.Point(10, 13);
            this.panelContent.MaximumSize = new System.Drawing.Size(670, 100);
            this.panelContent.Size = new System.Drawing.Size(660, 100);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.cmbApplyOn);
            this.myLayoutControl1.Controls.Add(this.txtMinimumWageCategoryName);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(656, 96);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // cmbApplyOn
            // 
            this.cmbApplyOn.EnterMoveNextControl = true;
            this.cmbApplyOn.Location = new System.Drawing.Point(238, 40);
            this.cmbApplyOn.MaximumSize = new System.Drawing.Size(150, 0);
            this.cmbApplyOn.MenuManager = this.barManager1;
            this.cmbApplyOn.MinimumSize = new System.Drawing.Size(150, 0);
            this.cmbApplyOn.Name = "cmbApplyOn";
            this.cmbApplyOn.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbApplyOn.Properties.DropDownRows = 2;
            this.cmbApplyOn.Properties.Items.AddRange(new object[] {
            "Basic Pay",
            "Gross Pay"});
            this.cmbApplyOn.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbApplyOn.Size = new System.Drawing.Size(150, 24);
            this.cmbApplyOn.StyleController = this.myLayoutControl1;
            this.cmbApplyOn.TabIndex = 5;
            this.cmbApplyOn.Validating += new System.ComponentModel.CancelEventHandler(this.cmbApplyOn_Validating);
            // 
            // txtMinimumWageCategoryName
            // 
            this.txtMinimumWageCategoryName.EnterMoveNextControl = true;
            this.txtMinimumWageCategoryName.Location = new System.Drawing.Point(238, 12);
            this.txtMinimumWageCategoryName.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtMinimumWageCategoryName.MenuManager = this.barManager1;
            this.txtMinimumWageCategoryName.Name = "txtMinimumWageCategoryName";
            this.txtMinimumWageCategoryName.Properties.MaxLength = 50;
            this.txtMinimumWageCategoryName.Size = new System.Drawing.Size(400, 24);
            this.txtMinimumWageCategoryName.StyleController = this.myLayoutControl1;
            this.txtMinimumWageCategoryName.TabIndex = 4;
            this.txtMinimumWageCategoryName.Validating += new System.ComponentModel.CancelEventHandler(this.txtMinimumWageCategoryName_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(656, 96);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtMinimumWageCategoryName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(636, 28);
            this.layoutControlItem1.Text = "Minimum Wage Category Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(223, 18);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbApplyOn;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(380, 28);
            this.layoutControlItem2.Text = "Rule Apply On";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(223, 18);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(380, 28);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(256, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 56);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(636, 20);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmMinimumWageCategory
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 226);
            this.FirstControl = this.myLayoutControl1;
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "frmMinimumWageCategory";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Minimum Wage Category";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbApplyOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimumWageCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.ComboBoxEdit cmbApplyOn;
        private Alit.WinformControls.TextEdit txtMinimumWageCategoryName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}