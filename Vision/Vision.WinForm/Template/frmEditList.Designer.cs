namespace Vision.WinForm.Template
{
    partial class frmEditList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditList));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridEditList = new DevExpress.XtraGrid.GridControl();
            this.gridViewEditList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barFormFooter = new DevExpress.XtraBars.Bar();
            this.btnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lblFormCaption = new DevExpress.XtraBars.BarStaticItem();
            this.batBtnSelect = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnEscapeSetFocus = new System.Windows.Forms.Button();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEditList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEditList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Controls.Add(this.gridEditList);
            this.panelControl2.Controls.Add(this.btnEscapeSetFocus);
            this.panelControl2.Name = "panelControl2";
            // 
            // gridEditList
            // 
            resources.ApplyResources(this.gridEditList, "gridEditList");
            this.gridEditList.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridEditList.EmbeddedNavigator.AccessibleDescription = resources.GetString("gridEditList.EmbeddedNavigator.AccessibleDescription");
            this.gridEditList.EmbeddedNavigator.AccessibleName = resources.GetString("gridEditList.EmbeddedNavigator.AccessibleName");
            this.gridEditList.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridEditList.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridEditList.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridEditList.EmbeddedNavigator.Anchor")));
            this.gridEditList.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridEditList.EmbeddedNavigator.BackgroundImage")));
            this.gridEditList.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridEditList.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridEditList.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridEditList.EmbeddedNavigator.ImeMode")));
            this.gridEditList.EmbeddedNavigator.Margin = ((System.Windows.Forms.Padding)(resources.GetObject("gridEditList.EmbeddedNavigator.Margin")));
            this.gridEditList.EmbeddedNavigator.MaximumSize = ((System.Drawing.Size)(resources.GetObject("gridEditList.EmbeddedNavigator.MaximumSize")));
            this.gridEditList.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridEditList.EmbeddedNavigator.TextLocation")));
            this.gridEditList.EmbeddedNavigator.ToolTip = resources.GetString("gridEditList.EmbeddedNavigator.ToolTip");
            this.gridEditList.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridEditList.EmbeddedNavigator.ToolTipIconType")));
            this.gridEditList.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridEditList.EmbeddedNavigator.ToolTipTitle");
            this.gridEditList.MainView = this.gridViewEditList;
            this.gridEditList.MenuManager = this.barManager1;
            this.gridEditList.Name = "gridEditList";
            this.gridEditList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEditList});
            this.gridEditList.DoubleClick += new System.EventHandler(this.gridEditList_DoubleClick);
            // 
            // gridViewEditList
            // 
            this.gridViewEditList.Appearance.HeaderPanel.FontSizeDelta = ((int)(resources.GetObject("gridViewEditList.Appearance.HeaderPanel.FontSizeDelta")));
            this.gridViewEditList.Appearance.HeaderPanel.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("gridViewEditList.Appearance.HeaderPanel.FontStyleDelta")));
            this.gridViewEditList.Appearance.HeaderPanel.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("gridViewEditList.Appearance.HeaderPanel.GradientMode")));
            this.gridViewEditList.Appearance.HeaderPanel.Image = ((System.Drawing.Image)(resources.GetObject("gridViewEditList.Appearance.HeaderPanel.Image")));
            this.gridViewEditList.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewEditList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewEditList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewEditList.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            resources.ApplyResources(this.gridViewEditList, "gridViewEditList");
            this.gridViewEditList.ColumnPanelRowHeight = 50;
            this.gridViewEditList.DetailHeight = 431;
            this.gridViewEditList.GridControl = this.gridEditList;
            this.gridViewEditList.Name = "gridViewEditList";
            this.gridViewEditList.OptionsPrint.AllowMultilineHeaders = true;
            this.gridViewEditList.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridViewEditList.OptionsView.ShowAutoFilterRow = true;
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
            this.lblFormCaption,
            this.btnSelect,
            this.btnRefresh,
            this.btnCancel,
            this.barStaticItem1,
            this.btnPrintPreview,
            this.btnPrint,
            this.batBtnSelect,
            this.barBtnRefresh,
            this.barBtnPrintPreview,
            this.barBtnPrint,
            this.barBtnExit});
            this.barManager1.MaxItemId = 29;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrintPreview, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barFormFooter.OptionsBar.AllowQuickCustomization = false;
            this.barFormFooter.OptionsBar.DrawDragBorder = false;
            this.barFormFooter.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.barFormFooter, "barFormFooter");
            // 
            // btnSelect
            // 
            resources.ApplyResources(this.btnSelect, "btnSelect");
            this.btnSelect.Id = 4;
            this.btnSelect.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Checked_Checkbox_16;
            this.btnSelect.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnSelect.ImageOptions.ImageIndex")));
            this.btnSelect.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btnSelect.ImageOptions.LargeImageIndex")));
            this.btnSelect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSelect.ImageOptions.SvgImage")));
            this.btnSelect.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnSelect.ItemAppearance.Normal.FontSizeDelta")));
            this.btnSelect.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnSelect.ItemAppearance.Normal.FontStyleDelta")));
            this.btnSelect.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSelect.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Enter));
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelect_ItemClick);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Id = 6;
            this.btnRefresh.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Refresh_16;
            this.btnRefresh.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnRefresh.ImageOptions.ImageIndex")));
            this.btnRefresh.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btnRefresh.ImageOptions.LargeImageIndex")));
            this.btnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnRefresh.ImageOptions.SvgImage")));
            this.btnRefresh.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnRefresh.ItemAppearance.Normal.FontSizeDelta")));
            this.btnRefresh.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnRefresh.ItemAppearance.Normal.FontStyleDelta")));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R));
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnPrintPreview
            // 
            resources.ApplyResources(this.btnPrintPreview, "btnPrintPreview");
            this.btnPrintPreview.Id = 17;
            this.btnPrintPreview.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Print_Preview_Filled__16;
            this.btnPrintPreview.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnPrintPreview.ImageOptions.ImageIndex")));
            this.btnPrintPreview.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btnPrintPreview.ImageOptions.LargeImageIndex")));
            this.btnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrintPreview.ImageOptions.SvgImage")));
            this.btnPrintPreview.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnPrintPreview.ItemAppearance.Normal.FontSizeDelta")));
            this.btnPrintPreview.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnPrintPreview.ItemAppearance.Normal.FontStyleDelta")));
            this.btnPrintPreview.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.P));
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Id = 23;
            this.btnPrint.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Print_16;
            this.btnPrint.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnPrint.ImageOptions.ImageIndex")));
            this.btnPrint.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btnPrint.ImageOptions.LargeImageIndex")));
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnPrint.ItemAppearance.Normal.FontSizeDelta")));
            this.btnPrint.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnPrint.ItemAppearance.Normal.FontStyleDelta")));
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // barStaticItem1
            // 
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Id = 16;
            this.barStaticItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barStaticItem1.ImageOptions.ImageIndex")));
            this.barStaticItem1.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barStaticItem1.ImageOptions.LargeImageIndex")));
            this.barStaticItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barStaticItem1.ImageOptions.SvgImage")));
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnCancel.Id = 11;
            this.btnCancel.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Close_Window_16;
            this.btnCancel.ImageOptions.ImageIndex = ((int)(resources.GetObject("btnCancel.ImageOptions.ImageIndex")));
            this.btnCancel.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("btnCancel.ImageOptions.LargeImageIndex")));
            this.btnCancel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCancel.ImageOptions.SvgImage")));
            this.btnCancel.ItemAppearance.Normal.FontSizeDelta = ((int)(resources.GetObject("btnCancel.ItemAppearance.Normal.FontSizeDelta")));
            this.btnCancel.ItemAppearance.Normal.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("btnCancel.ItemAppearance.Normal.FontStyleDelta")));
            this.btnCancel.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
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
            // lblFormCaption
            // 
            resources.ApplyResources(this.lblFormCaption, "lblFormCaption");
            this.lblFormCaption.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblFormCaption.Id = 3;
            this.lblFormCaption.ImageOptions.ImageIndex = ((int)(resources.GetObject("lblFormCaption.ImageOptions.ImageIndex")));
            this.lblFormCaption.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("lblFormCaption.ImageOptions.LargeImageIndex")));
            this.lblFormCaption.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lblFormCaption.ImageOptions.SvgImage")));
            this.lblFormCaption.Name = "lblFormCaption";
            // 
            // batBtnSelect
            // 
            resources.ApplyResources(this.batBtnSelect, "batBtnSelect");
            this.batBtnSelect.Id = 24;
            this.batBtnSelect.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Checked_Checkbox_16;
            this.batBtnSelect.ImageOptions.ImageIndex = ((int)(resources.GetObject("batBtnSelect.ImageOptions.ImageIndex")));
            this.batBtnSelect.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("batBtnSelect.ImageOptions.LargeImageIndex")));
            this.batBtnSelect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("batBtnSelect.ImageOptions.SvgImage")));
            this.batBtnSelect.Name = "batBtnSelect";
            this.batBtnSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSelect_ItemClick);
            // 
            // barBtnRefresh
            // 
            resources.ApplyResources(this.barBtnRefresh, "barBtnRefresh");
            this.barBtnRefresh.Id = 25;
            this.barBtnRefresh.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Refresh_16;
            this.barBtnRefresh.ImageOptions.ImageIndex = ((int)(resources.GetObject("barBtnRefresh.ImageOptions.ImageIndex")));
            this.barBtnRefresh.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barBtnRefresh.ImageOptions.LargeImageIndex")));
            this.barBtnRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnRefresh.ImageOptions.SvgImage")));
            this.barBtnRefresh.Name = "barBtnRefresh";
            this.barBtnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // barBtnPrintPreview
            // 
            resources.ApplyResources(this.barBtnPrintPreview, "barBtnPrintPreview");
            this.barBtnPrintPreview.Id = 26;
            this.barBtnPrintPreview.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Print_Preview_Filled__16;
            this.barBtnPrintPreview.ImageOptions.ImageIndex = ((int)(resources.GetObject("barBtnPrintPreview.ImageOptions.ImageIndex")));
            this.barBtnPrintPreview.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barBtnPrintPreview.ImageOptions.LargeImageIndex")));
            this.barBtnPrintPreview.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnPrintPreview.ImageOptions.SvgImage")));
            this.barBtnPrintPreview.Name = "barBtnPrintPreview";
            // 
            // barBtnPrint
            // 
            resources.ApplyResources(this.barBtnPrint, "barBtnPrint");
            this.barBtnPrint.Id = 27;
            this.barBtnPrint.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Print_16;
            this.barBtnPrint.ImageOptions.ImageIndex = ((int)(resources.GetObject("barBtnPrint.ImageOptions.ImageIndex")));
            this.barBtnPrint.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barBtnPrint.ImageOptions.LargeImageIndex")));
            this.barBtnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnPrint.ImageOptions.SvgImage")));
            this.barBtnPrint.Name = "barBtnPrint";
            // 
            // barBtnExit
            // 
            resources.ApplyResources(this.barBtnExit, "barBtnExit");
            this.barBtnExit.Id = 28;
            this.barBtnExit.ImageOptions.Image = global::Vision.WinForm.Properties.Resources.Exit_16;
            this.barBtnExit.ImageOptions.ImageIndex = ((int)(resources.GetObject("barBtnExit.ImageOptions.ImageIndex")));
            this.barBtnExit.ImageOptions.LargeImageIndex = ((int)(resources.GetObject("barBtnExit.ImageOptions.LargeImageIndex")));
            this.barBtnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barBtnExit.ImageOptions.SvgImage")));
            this.barBtnExit.Name = "barBtnExit";
            this.barBtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnEscapeSetFocus
            // 
            resources.ApplyResources(this.btnEscapeSetFocus, "btnEscapeSetFocus");
            this.btnEscapeSetFocus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEscapeSetFocus.Name = "btnEscapeSetFocus";
            this.btnEscapeSetFocus.UseVisualStyleBackColor = true;
            this.btnEscapeSetFocus.Enter += new System.EventHandler(this.btnEscapeSetFocus_Enter);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.batBtnSelect),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrintPreview),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnExit)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.MenuAppearance.HeaderItemAppearance.FontSizeDelta = ((int)(resources.GetObject("popupMenu1.MenuAppearance.HeaderItemAppearance.FontSizeDelta")));
            this.popupMenu1.MenuAppearance.HeaderItemAppearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("popupMenu1.MenuAppearance.HeaderItemAppearance.FontStyleDelta")));
            this.popupMenu1.MenuAppearance.HeaderItemAppearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("popupMenu1.MenuAppearance.HeaderItemAppearance.GradientMode")));
            this.popupMenu1.MenuAppearance.HeaderItemAppearance.Image = ((System.Drawing.Image)(resources.GetObject("popupMenu1.MenuAppearance.HeaderItemAppearance.Image")));
            this.popupMenu1.Name = "popupMenu1";
            // 
            // frmEditList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnEscapeSetFocus;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimizeBox = false;
            this.Name = "frmEditList";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEditList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEditList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraBars.BarManager barManager1;
        public DevExpress.XtraBars.BarStaticItem lblFormCaption;
        public DevExpress.XtraBars.Bar barFormFooter;
        public DevExpress.XtraBars.BarButtonItem btnSelect;
        public DevExpress.XtraBars.BarButtonItem btnRefresh;
        public DevExpress.XtraBars.BarButtonItem btnCancel;
        public DevExpress.XtraBars.BarDockControl barDockControlTop;
        public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        public DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraGrid.GridControl gridEditList;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private System.Windows.Forms.Button btnEscapeSetFocus;
        private DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem batBtnSelect;
        private DevExpress.XtraBars.BarButtonItem barBtnRefresh;
        private DevExpress.XtraBars.BarButtonItem barBtnPrintPreview;
        private DevExpress.XtraBars.BarButtonItem barBtnPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnExit;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewEditList;
    }
}