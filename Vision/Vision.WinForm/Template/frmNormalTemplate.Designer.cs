namespace Vision.WinForm.Template
{
    partial class frmNormalTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNormalTemplate));
            this.btnSetExitFocus = new DevExpress.XtraEditors.SimpleButton();
            this.ErrorProvider = new Alit.WinformControls.ErrorProvider(this.components);
            this.backgroundWorkerLoadInitialValues = new System.ComponentModel.BackgroundWorker();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barFormFooter = new DevExpress.XtraBars.Bar();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.beiProgressbar = new DevExpress.XtraBars.BarEditItem();
            this.ProgressBarSavingProcess = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelContent = new DevExpress.XtraEditors.PanelControl();
            this.btnSetSaveFocus = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSetExitFocus
            // 
            resources.ApplyResources(this.btnSetExitFocus, "btnSetExitFocus");
            this.btnSetExitFocus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetExitFocus.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnSetExitFocus.ImageOptions.ImageIndex")));
            this.btnSetExitFocus.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSetExitFocus.ImageOptions.SvgImage")));
            this.btnSetExitFocus.Name = "btnSetExitFocus";
            this.btnSetExitFocus.Enter += new System.EventHandler(this.btnSetExitFocus_Click);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // backgroundWorkerLoadInitialValues
            // 
            this.backgroundWorkerLoadInitialValues.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadInitialValues_DoWork);
            this.backgroundWorkerLoadInitialValues.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadInitialValues_RunWorkerCompleted);
            // 
            // barDockControlLeft
            // 
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlLeft.Appearance.FontSizeDelta")));
            this.barDockControlLeft.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlLeft.Appearance.FontStyleDelta")));
            this.barDockControlLeft.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlLeft.Appearance.GradientMode")));
            this.barDockControlLeft.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlLeft.Appearance.Image")));
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Manager = this.barManager1;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barFormFooter});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnSave,
            this.btnRefresh,
            this.btnExit,
            this.beiProgressbar});
            this.barManager1.MaxItemId = 23;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.ProgressBarSavingProcess});
            this.barManager1.StatusBar = this.barFormFooter;
            // 
            // barFormFooter
            // 
            this.barFormFooter.BarName = "Tools";
            this.barFormFooter.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barFormFooter.DockCol = 0;
            this.barFormFooter.DockRow = 0;
            this.barFormFooter.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barFormFooter.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.beiProgressbar, "", false, true, true, 129)});
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.barFormFooter, "barFormFooter");
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Id = 4;
            this.btnSave.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Save_Filled_16;
            this.btnSave.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnSave.ImageOptions.ImageIndex")));
            this.btnSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSave.ImageOptions.SvgImage")));
            this.btnSave.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnSave.ItemAppearance.Normal.FontSizeDelta")));
            this.btnSave.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSave.ItemAppearance.Normal.FontStyleDelta")));
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Id = 6;
            this.btnRefresh.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Create_New_16;
            this.btnRefresh.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnRefresh.ImageOptions.ImageIndex")));
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnRefresh.ItemAppearance.Normal.FontSizeDelta")));
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnRefresh.ItemAppearance.Normal.FontStyleDelta")));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnExit.Id = 11;
            this.btnExit.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Exit_16;
            this.btnExit.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnExit.ImageOptions.ImageIndex")));
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnExit.ItemAppearance.Normal.FontSizeDelta")));
            this.btnExit.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnExit.ItemAppearance.Normal.FontStyleDelta")));
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // beiProgressbar
            // 
            resources.ApplyResources(this.beiProgressbar, "beiProgressbar");
            this.beiProgressbar.Edit = this.ProgressBarSavingProcess;
            this.beiProgressbar.Id = 22;
            this.beiProgressbar.ImageOptions.ImageIndex = ((int)(resources.GetObject("beiProgressbar.ImageOptions.ImageIndex")));
            this.beiProgressbar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("beiProgressbar.ImageOptions.SvgImage")));
            this.beiProgressbar.Name = "beiProgressbar";
            this.beiProgressbar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // ProgressBarSavingProcess
            // 
            resources.ApplyResources(this.ProgressBarSavingProcess, "ProgressBarSavingProcess");
            this.ProgressBarSavingProcess.Name = "ProgressBarSavingProcess";
            // 
            // barDockControlTop
            // 
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlTop.Appearance.FontSizeDelta")));
            this.barDockControlTop.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlTop.Appearance.FontStyleDelta")));
            this.barDockControlTop.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlTop.Appearance.GradientMode")));
            this.barDockControlTop.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlTop.Appearance.Image")));
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Manager = this.barManager1;
            // 
            // barDockControlBottom
            // 
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlBottom.Appearance.FontSizeDelta")));
            this.barDockControlBottom.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlBottom.Appearance.FontStyleDelta")));
            this.barDockControlBottom.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlBottom.Appearance.GradientMode")));
            this.barDockControlBottom.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlBottom.Appearance.Image")));
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Manager = this.barManager1;
            // 
            // barDockControlRight
            // 
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Appearance.FontSizeDelta = ((int)(resources.GetObject("barDockControlRight.Appearance.FontSizeDelta")));
            this.barDockControlRight.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("barDockControlRight.Appearance.FontStyleDelta")));
            this.barDockControlRight.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("barDockControlRight.Appearance.GradientMode")));
            this.barDockControlRight.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("barDockControlRight.Appearance.Image")));
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Manager = this.barManager1;
            // 
            // repositoryItemButtonEdit1
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit1, "repositoryItemButtonEdit1");
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemButtonEdit1.Mask.AutoComplete")));
            this.repositoryItemButtonEdit1.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.BeepOnError")));
            this.repositoryItemButtonEdit1.Mask.EditMask = resources.GetString("repositoryItemButtonEdit1.Mask.EditMask");
            this.repositoryItemButtonEdit1.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.IgnoreMaskBlank")));
            this.repositoryItemButtonEdit1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemButtonEdit1.Mask.MaskType")));
            this.repositoryItemButtonEdit1.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemButtonEdit1.Mask.PlaceHolder")));
            this.repositoryItemButtonEdit1.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.SaveLiteral")));
            this.repositoryItemButtonEdit1.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.ShowPlaceHolders")));
            this.repositoryItemButtonEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemButtonEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            resources.ApplyResources(this.repositoryItemTextEdit1, "repositoryItemTextEdit1");
            this.repositoryItemTextEdit1.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemTextEdit1.Mask.AutoComplete")));
            this.repositoryItemTextEdit1.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemTextEdit1.Mask.BeepOnError")));
            this.repositoryItemTextEdit1.Mask.EditMask = resources.GetString("repositoryItemTextEdit1.Mask.EditMask");
            this.repositoryItemTextEdit1.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemTextEdit1.Mask.IgnoreMaskBlank")));
            this.repositoryItemTextEdit1.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemTextEdit1.Mask.MaskType")));
            this.repositoryItemTextEdit1.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemTextEdit1.Mask.PlaceHolder")));
            this.repositoryItemTextEdit1.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemTextEdit1.Mask.SaveLiteral")));
            this.repositoryItemTextEdit1.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemTextEdit1.Mask.ShowPlaceHolders")));
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            resources.ApplyResources(this.repositoryItemTextEdit2, "repositoryItemTextEdit2");
            this.repositoryItemTextEdit2.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemTextEdit2.Mask.AutoComplete")));
            this.repositoryItemTextEdit2.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemTextEdit2.Mask.BeepOnError")));
            this.repositoryItemTextEdit2.Mask.EditMask = resources.GetString("repositoryItemTextEdit2.Mask.EditMask");
            this.repositoryItemTextEdit2.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemTextEdit2.Mask.IgnoreMaskBlank")));
            this.repositoryItemTextEdit2.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemTextEdit2.Mask.MaskType")));
            this.repositoryItemTextEdit2.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemTextEdit2.Mask.PlaceHolder")));
            this.repositoryItemTextEdit2.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemTextEdit2.Mask.SaveLiteral")));
            this.repositoryItemTextEdit2.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemTextEdit2.Mask.ShowPlaceHolders")));
            this.repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // panelContent
            // 
            resources.ApplyResources(this.panelContent, "panelContent");
            this.panelContent.Name = "panelContent";
            // 
            // btnSetSaveFocus
            // 
            resources.ApplyResources(this.btnSetSaveFocus, "btnSetSaveFocus");
            this.btnSetSaveFocus.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnSetSaveFocus.ImageOptions.ImageIndex")));
            this.btnSetSaveFocus.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSetSaveFocus.ImageOptions.SvgImage")));
            this.btnSetSaveFocus.Name = "btnSetSaveFocus";
            this.btnSetSaveFocus.Enter += new System.EventHandler(this.btnSetSaveFocus_Enter);
            // 
            // frmNormalTemplate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.btnSetExitFocus);
            this.Controls.Add(this.btnSetSaveFocus);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmNormalTemplate";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBarSavingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSetExitFocus;
        public Alit.WinformControls.ErrorProvider ErrorProvider;
        public DevExpress.XtraEditors.PanelControl panelContent;
        private DevExpress.XtraEditors.SimpleButton btnSetSaveFocus;
        public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        public DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        public DevExpress.XtraBars.BarDockControl barDockControlTop;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadInitialValues;
        public DevExpress.XtraBars.BarButtonItem btnExit;
        public DevExpress.XtraBars.BarButtonItem btnRefresh;
        public DevExpress.XtraBars.BarButtonItem btnSave;
        public DevExpress.XtraBars.Bar barFormFooter;
        public DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarEditItem beiProgressbar;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar ProgressBarSavingProcess;
    }
}