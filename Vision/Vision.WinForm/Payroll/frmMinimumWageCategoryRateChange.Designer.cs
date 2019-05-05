namespace Vision.WinForm.Payroll
{
    partial class frmMinimumWageCategoryRateChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMinimumWageCategoryRateChange));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.gcRate = new DevExpress.XtraGrid.GridControl();
            this.gvRate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dtpWithEffectDate = new Alit.WinformControls.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWithEffectDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWithEffectDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(642, 322);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 322);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Size = new System.Drawing.Size(0, 322);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 322);
            this.barDockControlBottom.Size = new System.Drawing.Size(642, 28);
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
            this.myLayoutControl1.Controls.Add(this.gcRate);
            this.myLayoutControl1.Controls.Add(this.dtpWithEffectDate);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(638, 318);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // gcRate
            // 
            this.gcRate.Location = new System.Drawing.Point(12, 36);
            this.gcRate.MainView = this.gvRate;
            this.gcRate.MenuManager = this.barManager1;
            this.gcRate.Name = "gcRate";
            this.gcRate.Size = new System.Drawing.Size(614, 270);
            this.gcRate.TabIndex = 6;
            this.gcRate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRate});
            // 
            // gvRate
            // 
            this.gvRate.GridControl = this.gcRate;
            this.gvRate.Name = "gvRate";
            this.gvRate.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvRate.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvRate.OptionsNavigation.UseTabKey = false;
            this.gvRate.OptionsView.ShowGroupPanel = false;
            // 
            // dtpWithEffectDate
            // 
            this.dtpWithEffectDate.EditValue = null;
            this.dtpWithEffectDate.EnterMoveNextControl = true;
            this.dtpWithEffectDate.Location = new System.Drawing.Point(95, 12);
            this.dtpWithEffectDate.MaximumSize = new System.Drawing.Size(200, 0);
            this.dtpWithEffectDate.MenuManager = this.barManager1;
            this.dtpWithEffectDate.Name = "dtpWithEffectDate";
            this.dtpWithEffectDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpWithEffectDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpWithEffectDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtpWithEffectDate.Size = new System.Drawing.Size(200, 20);
            this.dtpWithEffectDate.StyleController = this.myLayoutControl1;
            this.dtpWithEffectDate.TabIndex = 5;
            this.dtpWithEffectDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpWithEffectDate_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(638, 318);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtpWithEffectDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(287, 24);
            this.layoutControlItem2.Text = "With Effect Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcRate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(618, 274);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(287, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(331, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmMinimumWageCategoryRateChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 350);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmMinimumWageCategoryRateChange";
            this.Text = "Minimum Wage Category Rate Change";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWithEffectDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWithEffectDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcRate;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRate;
        private Alit.WinformControls.DateEdit dtpWithEffectDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}