namespace Vision.WinForm.Settings
{
    partial class frmTaxSlab
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
            this.gcPAYERelief = new DevExpress.XtraGrid.GridControl();
            this.PAYEReliefeViewModelBindingSource = new System.Windows.Forms.BindingSource();
            this.gvPAYERelief = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPAYEReliefName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYEReliefType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCmbMandatory = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colMonthlyLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtPAYEReliefAmt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colAnnualLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWEDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemovePAYERelief = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditRemovePAYERelief = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dePAYEReliefWED = new Alit.WinformControls.DateEdit();
            this.gcPAYESecondry = new DevExpress.XtraGrid.GridControl();
            this.taxSlabPAYESecondViewModelBindingSource = new System.Windows.Forms.BindingSource();
            this.gvPAYESecondry = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxableSalaryFromValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtPayeeSecond = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTaxableSalaryToValue3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPerc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtPercPAYESecond = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colRemoveRowPAYESecond = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditRemoveRowPAYESecond = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.btnUpdatePAYE = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdatePAYE2 = new DevExpress.XtraEditors.SimpleButton();
            this.gcPAYEPrimary = new DevExpress.XtraGrid.GridControl();
            this.taxSlabPAYEPrimeViewModelBindingSource = new System.Windows.Forms.BindingSource();
            this.gvPAYEPrimary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxableSalaryFromValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtPAYEAmt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTaxableSalaryToValue2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxPerc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtPAYEPerc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colRemoveRowPayeePrime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditRemovePayeePrime = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.deWEDatePAYE = new Alit.WinformControls.DateEdit();
            this.btnNSSFUpdate2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnNSSFUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.gcNSSF = new DevExpress.XtraGrid.GridControl();
            this.taxSlabNSSFViewModelBindingSource = new System.Windows.Forms.BindingSource();
            this.gvNSSF = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTaxableSalaryFromValue1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemtxtNSSFAmt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTaxableSalaryToValue1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTaxPerc = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemTxtNSSF_Perc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMaxTaxValue = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTaxPercEmployer = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMaxTaxValueEmployer = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colRemoveRowNSSF = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemButtonEditRemoveNSSF = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.deWEDateNSSF = new Alit.WinformControls.DateEdit();
            this.btnUpdateNHIF1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdateNHIF = new DevExpress.XtraEditors.SimpleButton();
            this.gcNHIFTaxSlab = new DevExpress.XtraGrid.GridControl();
            this.taxSlabNHIFViewModelBindingSource = new System.Windows.Forms.BindingSource();
            this.gvNHIFTaxSlab = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTaxableSalaryFromValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtNHIF_Amt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTaxableSalaryToValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemoveNHIF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEditRemoveNHIF = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.deWED_NHIF = new Alit.WinformControls.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.repositoryItemLookupReliefType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYERelief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYEReliefeViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYERelief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCmbMandatory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPAYEReliefAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemovePAYERelief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePAYEReliefWED.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePAYEReliefWED.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYESecondry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabPAYESecondViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYESecondry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPayeeSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPercPAYESecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveRowPAYESecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYEPrimary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabPAYEPrimeViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYEPrimary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPAYEAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPAYEPerc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemovePayeePrime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDatePAYE.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDatePAYE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNSSF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabNSSFViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNSSF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtNSSFAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtNSSF_Perc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveNSSF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateNSSF.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateNSSF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNHIFTaxSlab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabNHIFViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNHIFTaxSlab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtNHIF_Amt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveNHIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWED_NHIF.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWED_NHIF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookupReliefType)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(1379, 520);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.gcPAYERelief);
            this.myLayoutControl1.Controls.Add(this.dePAYEReliefWED);
            this.myLayoutControl1.Controls.Add(this.gcPAYESecondry);
            this.myLayoutControl1.Controls.Add(this.btnUpdatePAYE);
            this.myLayoutControl1.Controls.Add(this.btnUpdatePAYE2);
            this.myLayoutControl1.Controls.Add(this.gcPAYEPrimary);
            this.myLayoutControl1.Controls.Add(this.deWEDatePAYE);
            this.myLayoutControl1.Controls.Add(this.btnNSSFUpdate2);
            this.myLayoutControl1.Controls.Add(this.btnNSSFUpdate);
            this.myLayoutControl1.Controls.Add(this.gcNSSF);
            this.myLayoutControl1.Controls.Add(this.deWEDateNSSF);
            this.myLayoutControl1.Controls.Add(this.btnUpdateNHIF1);
            this.myLayoutControl1.Controls.Add(this.btnUpdateNHIF);
            this.myLayoutControl1.Controls.Add(this.gcNHIFTaxSlab);
            this.myLayoutControl1.Controls.Add(this.deWED_NHIF);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1373, 514);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // gcPAYERelief
            // 
            this.gcPAYERelief.DataSource = this.PAYEReliefeViewModelBindingSource;
            this.gcPAYERelief.Location = new System.Drawing.Point(24, 74);
            this.gcPAYERelief.MainView = this.gvPAYERelief;
            this.gcPAYERelief.MaximumSize = new System.Drawing.Size(950, 0);
            this.gcPAYERelief.MinimumSize = new System.Drawing.Size(300, 0);
            this.gcPAYERelief.Name = "gcPAYERelief";
            this.gcPAYERelief.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditRemovePAYERelief,
            this.repositoryItemTxtPAYEReliefAmt,
            this.repositoryItemCmbMandatory,
            this.repositoryItemLookupReliefType});
            this.gcPAYERelief.Size = new System.Drawing.Size(950, 403);
            this.gcPAYERelief.TabIndex = 20;
            this.gcPAYERelief.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPAYERelief});
            // 
            // PAYEReliefeViewModelBindingSource
            // 
            this.PAYEReliefeViewModelBindingSource.DataSource = typeof(Vision.Model.Settings.PAYEReliefeViewModel);
            // 
            // gvPAYERelief
            // 
            this.gvPAYERelief.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPAYEReliefName,
            this.colPAYEReliefType,
            this.colMandatory,
            this.colMonthlyLimit,
            this.colAnnualLimit,
            this.colWEDate,
            this.colRemovePAYERelief});
            this.gvPAYERelief.GridControl = this.gcPAYERelief;
            this.gvPAYERelief.Name = "gvPAYERelief";
            this.gvPAYERelief.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gvPAYERelief.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gvPAYERelief.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvPAYERelief.OptionsEditForm.PopupEditFormWidth = 700;
            this.gvPAYERelief.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvPAYERelief.OptionsNavigation.UseTabKey = false;
            this.gvPAYERelief.OptionsView.AutoCalcPreviewLineCount = true;
            this.gvPAYERelief.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvPAYERelief.OptionsView.ShowGroupPanel = false;
            this.gvPAYERelief.OptionsView.ShowPreview = true;
            this.gvPAYERelief.PreviewFieldName = "RowPreview";
            this.gvPAYERelief.ViewCaption = "PAYE Relief";
            this.gvPAYERelief.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvPAYERelief_RowCellClick);
            this.gvPAYERelief.CustomDrawRowPreview += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvPAYERelief_CustomDrawRowPreview);
            this.gvPAYERelief.MeasurePreviewHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gvPAYERelief_MeasurePreviewHeight);
            this.gvPAYERelief.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPAYERelief_FocusedRowChanged);
            this.gvPAYERelief.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvPAYERelief_ValidateRow);
            this.gvPAYERelief.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gvPAYERelief_RowUpdated);
            // 
            // colPAYEReliefName
            // 
            this.colPAYEReliefName.FieldName = "PAYEReliefName";
            this.colPAYEReliefName.MaxWidth = 500;
            this.colPAYEReliefName.MinWidth = 100;
            this.colPAYEReliefName.Name = "colPAYEReliefName";
            this.colPAYEReliefName.OptionsEditForm.ColumnSpan = 2;
            this.colPAYEReliefName.OptionsEditForm.StartNewRow = true;
            this.colPAYEReliefName.OptionsEditForm.UseEditorColRowSpan = false;
            this.colPAYEReliefName.Visible = true;
            this.colPAYEReliefName.VisibleIndex = 0;
            this.colPAYEReliefName.Width = 500;
            // 
            // colPAYEReliefType
            // 
            this.colPAYEReliefType.ColumnEdit = this.repositoryItemLookupReliefType;
            this.colPAYEReliefType.FieldName = "PAYEReliefType";
            this.colPAYEReliefType.MaxWidth = 150;
            this.colPAYEReliefType.MinWidth = 100;
            this.colPAYEReliefType.Name = "colPAYEReliefType";
            this.colPAYEReliefType.Visible = true;
            this.colPAYEReliefType.VisibleIndex = 1;
            this.colPAYEReliefType.Width = 100;
            // 
            // colMandatory
            // 
            this.colMandatory.ColumnEdit = this.repositoryItemCmbMandatory;
            this.colMandatory.FieldName = "Mandatory";
            this.colMandatory.MaxWidth = 100;
            this.colMandatory.MinWidth = 75;
            this.colMandatory.Name = "colMandatory";
            this.colMandatory.Visible = true;
            this.colMandatory.VisibleIndex = 2;
            this.colMandatory.Width = 86;
            // 
            // repositoryItemCmbMandatory
            // 
            this.repositoryItemCmbMandatory.AutoHeight = false;
            this.repositoryItemCmbMandatory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCmbMandatory.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.repositoryItemCmbMandatory.Name = "repositoryItemCmbMandatory";
            // 
            // colMonthlyLimit
            // 
            this.colMonthlyLimit.ColumnEdit = this.repositoryItemTxtPAYEReliefAmt;
            this.colMonthlyLimit.DisplayFormat.FormatString = "n2";
            this.colMonthlyLimit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonthlyLimit.FieldName = "MonthlyLimit";
            this.colMonthlyLimit.MaxWidth = 150;
            this.colMonthlyLimit.MinWidth = 75;
            this.colMonthlyLimit.Name = "colMonthlyLimit";
            this.colMonthlyLimit.OptionsEditForm.StartNewRow = true;
            this.colMonthlyLimit.Visible = true;
            this.colMonthlyLimit.VisibleIndex = 3;
            this.colMonthlyLimit.Width = 111;
            // 
            // repositoryItemTxtPAYEReliefAmt
            // 
            this.repositoryItemTxtPAYEReliefAmt.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtPAYEReliefAmt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtPAYEReliefAmt.AutoHeight = false;
            this.repositoryItemTxtPAYEReliefAmt.Mask.EditMask = "n2";
            this.repositoryItemTxtPAYEReliefAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtPAYEReliefAmt.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtPAYEReliefAmt.Name = "repositoryItemTxtPAYEReliefAmt";
            // 
            // colAnnualLimit
            // 
            this.colAnnualLimit.ColumnEdit = this.repositoryItemTxtPAYEReliefAmt;
            this.colAnnualLimit.DisplayFormat.FormatString = "n2";
            this.colAnnualLimit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAnnualLimit.FieldName = "AnnualLimit";
            this.colAnnualLimit.MaxWidth = 150;
            this.colAnnualLimit.MinWidth = 75;
            this.colAnnualLimit.Name = "colAnnualLimit";
            this.colAnnualLimit.Visible = true;
            this.colAnnualLimit.VisibleIndex = 4;
            this.colAnnualLimit.Width = 108;
            // 
            // colWEDate
            // 
            this.colWEDate.FieldName = "WEDate";
            this.colWEDate.MaxWidth = 150;
            this.colWEDate.MinWidth = 75;
            this.colWEDate.Name = "colWEDate";
            this.colWEDate.OptionsColumn.AllowEdit = false;
            this.colWEDate.OptionsColumn.ReadOnly = true;
            this.colWEDate.OptionsColumn.ShowInCustomizationForm = false;
            this.colWEDate.OptionsColumn.TabStop = false;
            this.colWEDate.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            this.colWEDate.Visible = true;
            this.colWEDate.VisibleIndex = 5;
            this.colWEDate.Width = 120;
            // 
            // colRemovePAYERelief
            // 
            this.colRemovePAYERelief.ColumnEdit = this.repositoryItemButtonEditRemovePAYERelief;
            this.colRemovePAYERelief.MaxWidth = 20;
            this.colRemovePAYERelief.Name = "colRemovePAYERelief";
            this.colRemovePAYERelief.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.colRemovePAYERelief.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRemovePAYERelief.Visible = true;
            this.colRemovePAYERelief.VisibleIndex = 6;
            this.colRemovePAYERelief.Width = 20;
            // 
            // repositoryItemButtonEditRemovePAYERelief
            // 
            this.repositoryItemButtonEditRemovePAYERelief.AutoHeight = false;
            this.repositoryItemButtonEditRemovePAYERelief.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditRemovePAYERelief.Name = "repositoryItemButtonEditRemovePAYERelief";
            this.repositoryItemButtonEditRemovePAYERelief.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditRemovePAYERelief_ButtonClick);
            // 
            // dePAYEReliefWED
            // 
            this.dePAYEReliefWED.EditValue = null;
            this.dePAYEReliefWED.EnterMoveNextControl = true;
            this.dePAYEReliefWED.Location = new System.Drawing.Point(122, 48);
            this.dePAYEReliefWED.MaximumSize = new System.Drawing.Size(150, 0);
            this.dePAYEReliefWED.Name = "dePAYEReliefWED";
            this.dePAYEReliefWED.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePAYEReliefWED.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePAYEReliefWED.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dePAYEReliefWED.Size = new System.Drawing.Size(150, 22);
            this.dePAYEReliefWED.StyleController = this.myLayoutControl1;
            this.dePAYEReliefWED.TabIndex = 19;
            // 
            // gcPAYESecondry
            // 
            this.gcPAYESecondry.DataSource = this.taxSlabPAYESecondViewModelBindingSource;
            this.gcPAYESecondry.Location = new System.Drawing.Point(517, 118);
            this.gcPAYESecondry.MainView = this.gvPAYESecondry;
            this.gcPAYESecondry.MaximumSize = new System.Drawing.Size(450, 0);
            this.gcPAYESecondry.MinimumSize = new System.Drawing.Size(450, 200);
            this.gcPAYESecondry.Name = "gcPAYESecondry";
            this.gcPAYESecondry.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTxtPayeeSecond,
            this.repositoryItemTxtPercPAYESecond,
            this.repositoryItemButtonEditRemoveRowPAYESecond});
            this.gcPAYESecondry.Size = new System.Drawing.Size(450, 312);
            this.gcPAYESecondry.TabIndex = 18;
            this.gcPAYESecondry.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPAYESecondry});
            // 
            // taxSlabPAYESecondViewModelBindingSource
            // 
            this.taxSlabPAYESecondViewModelBindingSource.DataSource = typeof(Vision.Model.Settings.TaxSlabViewModel);
            // 
            // gvPAYESecondry
            // 
            this.gvPAYESecondry.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxableSalaryFromValue3,
            this.colTaxableSalaryToValue3,
            this.colTaxPerc2,
            this.colRemoveRowPAYESecond});
            this.gvPAYESecondry.GridControl = this.gcPAYESecondry;
            this.gvPAYESecondry.Name = "gvPAYESecondry";
            this.gvPAYESecondry.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvPAYESecondry.OptionsNavigation.UseTabKey = false;
            this.gvPAYESecondry.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvPAYESecondry.OptionsView.ShowGroupPanel = false;
            // 
            // colTaxableSalaryFromValue3
            // 
            this.colTaxableSalaryFromValue3.ColumnEdit = this.repositoryItemTxtPayeeSecond;
            this.colTaxableSalaryFromValue3.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryFromValue3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryFromValue3.FieldName = "TaxableSalaryFromValue";
            this.colTaxableSalaryFromValue3.MaxWidth = 125;
            this.colTaxableSalaryFromValue3.MinWidth = 75;
            this.colTaxableSalaryFromValue3.Name = "colTaxableSalaryFromValue3";
            this.colTaxableSalaryFromValue3.Visible = true;
            this.colTaxableSalaryFromValue3.VisibleIndex = 0;
            // 
            // repositoryItemTxtPayeeSecond
            // 
            this.repositoryItemTxtPayeeSecond.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtPayeeSecond.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtPayeeSecond.AutoHeight = false;
            this.repositoryItemTxtPayeeSecond.Mask.EditMask = "n2";
            this.repositoryItemTxtPayeeSecond.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtPayeeSecond.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtPayeeSecond.Name = "repositoryItemTxtPayeeSecond";
            // 
            // colTaxableSalaryToValue3
            // 
            this.colTaxableSalaryToValue3.ColumnEdit = this.repositoryItemTxtPayeeSecond;
            this.colTaxableSalaryToValue3.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryToValue3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryToValue3.FieldName = "TaxableSalaryToValue";
            this.colTaxableSalaryToValue3.MaxWidth = 125;
            this.colTaxableSalaryToValue3.MinWidth = 75;
            this.colTaxableSalaryToValue3.Name = "colTaxableSalaryToValue3";
            this.colTaxableSalaryToValue3.Visible = true;
            this.colTaxableSalaryToValue3.VisibleIndex = 1;
            // 
            // colTaxPerc2
            // 
            this.colTaxPerc2.ColumnEdit = this.repositoryItemTxtPercPAYESecond;
            this.colTaxPerc2.DisplayFormat.FormatString = "p4";
            this.colTaxPerc2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPerc2.FieldName = "TaxPercEmployee";
            this.colTaxPerc2.MaxWidth = 125;
            this.colTaxPerc2.MinWidth = 75;
            this.colTaxPerc2.Name = "colTaxPerc2";
            this.colTaxPerc2.Visible = true;
            this.colTaxPerc2.VisibleIndex = 2;
            // 
            // repositoryItemTxtPercPAYESecond
            // 
            this.repositoryItemTxtPercPAYESecond.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtPercPAYESecond.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtPercPAYESecond.AutoHeight = false;
            this.repositoryItemTxtPercPAYESecond.Mask.EditMask = "p4";
            this.repositoryItemTxtPercPAYESecond.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtPercPAYESecond.Name = "repositoryItemTxtPercPAYESecond";
            // 
            // colRemoveRowPAYESecond
            // 
            this.colRemoveRowPAYESecond.Caption = " ";
            this.colRemoveRowPAYESecond.ColumnEdit = this.repositoryItemButtonEditRemoveRowPAYESecond;
            this.colRemoveRowPAYESecond.MaxWidth = 20;
            this.colRemoveRowPAYESecond.Name = "colRemoveRowPAYESecond";
            this.colRemoveRowPAYESecond.OptionsColumn.TabStop = false;
            this.colRemoveRowPAYESecond.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRemoveRowPAYESecond.Visible = true;
            this.colRemoveRowPAYESecond.VisibleIndex = 3;
            this.colRemoveRowPAYESecond.Width = 20;
            // 
            // repositoryItemButtonEditRemoveRowPAYESecond
            // 
            this.repositoryItemButtonEditRemoveRowPAYESecond.AutoHeight = false;
            this.repositoryItemButtonEditRemoveRowPAYESecond.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditRemoveRowPAYESecond.Name = "repositoryItemButtonEditRemoveRowPAYESecond";
            this.repositoryItemButtonEditRemoveRowPAYESecond.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditRemoveRowPAYESecond_ButtonClick);
            // 
            // btnUpdatePAYE
            // 
            this.btnUpdatePAYE.Location = new System.Drawing.Point(251, 48);
            this.btnUpdatePAYE.MaximumSize = new System.Drawing.Size(150, 0);
            this.btnUpdatePAYE.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnUpdatePAYE.Name = "btnUpdatePAYE";
            this.btnUpdatePAYE.Size = new System.Drawing.Size(150, 30);
            this.btnUpdatePAYE.StyleController = this.myLayoutControl1;
            this.btnUpdatePAYE.TabIndex = 17;
            this.btnUpdatePAYE.Text = "Update PAYE";
            this.btnUpdatePAYE.Click += new System.EventHandler(this.btnUpdatePAYE_Click);
            // 
            // btnUpdatePAYE2
            // 
            this.btnUpdatePAYE2.Location = new System.Drawing.Point(24, 447);
            this.btnUpdatePAYE2.MaximumSize = new System.Drawing.Size(150, 0);
            this.btnUpdatePAYE2.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnUpdatePAYE2.Name = "btnUpdatePAYE2";
            this.btnUpdatePAYE2.Size = new System.Drawing.Size(150, 30);
            this.btnUpdatePAYE2.StyleController = this.myLayoutControl1;
            this.btnUpdatePAYE2.TabIndex = 16;
            this.btnUpdatePAYE2.Text = "Update PAYE";
            this.btnUpdatePAYE2.Click += new System.EventHandler(this.btnUpdatePAYE_Click);
            // 
            // gcPAYEPrimary
            // 
            this.gcPAYEPrimary.DataSource = this.taxSlabPAYEPrimeViewModelBindingSource;
            this.gcPAYEPrimary.Location = new System.Drawing.Point(37, 118);
            this.gcPAYEPrimary.MainView = this.gvPAYEPrimary;
            this.gcPAYEPrimary.MaximumSize = new System.Drawing.Size(450, 0);
            this.gcPAYEPrimary.MinimumSize = new System.Drawing.Size(450, 200);
            this.gcPAYEPrimary.Name = "gcPAYEPrimary";
            this.gcPAYEPrimary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTxtPAYEAmt,
            this.repositoryItemTxtPAYEPerc,
            this.repositoryItemButtonEditRemovePayeePrime});
            this.gcPAYEPrimary.Size = new System.Drawing.Size(450, 312);
            this.gcPAYEPrimary.TabIndex = 15;
            this.gcPAYEPrimary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPAYEPrimary});
            // 
            // taxSlabPAYEPrimeViewModelBindingSource
            // 
            this.taxSlabPAYEPrimeViewModelBindingSource.DataSource = typeof(Vision.Model.Settings.TaxSlabViewModel);
            // 
            // gvPAYEPrimary
            // 
            this.gvPAYEPrimary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxableSalaryFromValue2,
            this.colTaxableSalaryToValue2,
            this.colTaxPerc1,
            this.colRemoveRowPayeePrime});
            this.gvPAYEPrimary.GridControl = this.gcPAYEPrimary;
            this.gvPAYEPrimary.Name = "gvPAYEPrimary";
            this.gvPAYEPrimary.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvPAYEPrimary.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvPAYEPrimary.OptionsNavigation.UseTabKey = false;
            this.gvPAYEPrimary.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvPAYEPrimary.OptionsView.ShowGroupPanel = false;
            // 
            // colTaxableSalaryFromValue2
            // 
            this.colTaxableSalaryFromValue2.ColumnEdit = this.repositoryItemTxtPAYEAmt;
            this.colTaxableSalaryFromValue2.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryFromValue2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryFromValue2.FieldName = "TaxableSalaryFromValue";
            this.colTaxableSalaryFromValue2.MaxWidth = 125;
            this.colTaxableSalaryFromValue2.MinWidth = 75;
            this.colTaxableSalaryFromValue2.Name = "colTaxableSalaryFromValue2";
            this.colTaxableSalaryFromValue2.Visible = true;
            this.colTaxableSalaryFromValue2.VisibleIndex = 0;
            // 
            // repositoryItemTxtPAYEAmt
            // 
            this.repositoryItemTxtPAYEAmt.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtPAYEAmt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtPAYEAmt.AutoHeight = false;
            this.repositoryItemTxtPAYEAmt.Mask.EditMask = "n2";
            this.repositoryItemTxtPAYEAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtPAYEAmt.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtPAYEAmt.Name = "repositoryItemTxtPAYEAmt";
            // 
            // colTaxableSalaryToValue2
            // 
            this.colTaxableSalaryToValue2.ColumnEdit = this.repositoryItemTxtPAYEAmt;
            this.colTaxableSalaryToValue2.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryToValue2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryToValue2.FieldName = "TaxableSalaryToValue";
            this.colTaxableSalaryToValue2.MaxWidth = 125;
            this.colTaxableSalaryToValue2.MinWidth = 75;
            this.colTaxableSalaryToValue2.Name = "colTaxableSalaryToValue2";
            this.colTaxableSalaryToValue2.Visible = true;
            this.colTaxableSalaryToValue2.VisibleIndex = 1;
            // 
            // colTaxPerc1
            // 
            this.colTaxPerc1.ColumnEdit = this.repositoryItemTxtPAYEPerc;
            this.colTaxPerc1.DisplayFormat.FormatString = "p4";
            this.colTaxPerc1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPerc1.FieldName = "TaxPercEmployee";
            this.colTaxPerc1.MaxWidth = 125;
            this.colTaxPerc1.MinWidth = 75;
            this.colTaxPerc1.Name = "colTaxPerc1";
            this.colTaxPerc1.Visible = true;
            this.colTaxPerc1.VisibleIndex = 2;
            // 
            // repositoryItemTxtPAYEPerc
            // 
            this.repositoryItemTxtPAYEPerc.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtPAYEPerc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtPAYEPerc.AutoHeight = false;
            this.repositoryItemTxtPAYEPerc.Mask.EditMask = "p4";
            this.repositoryItemTxtPAYEPerc.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtPAYEPerc.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtPAYEPerc.Name = "repositoryItemTxtPAYEPerc";
            // 
            // colRemoveRowPayeePrime
            // 
            this.colRemoveRowPayeePrime.Caption = " ";
            this.colRemoveRowPayeePrime.ColumnEdit = this.repositoryItemButtonEditRemovePayeePrime;
            this.colRemoveRowPayeePrime.MaxWidth = 20;
            this.colRemoveRowPayeePrime.Name = "colRemoveRowPayeePrime";
            this.colRemoveRowPayeePrime.OptionsColumn.TabStop = false;
            this.colRemoveRowPayeePrime.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRemoveRowPayeePrime.Visible = true;
            this.colRemoveRowPayeePrime.VisibleIndex = 3;
            this.colRemoveRowPayeePrime.Width = 20;
            // 
            // repositoryItemButtonEditRemovePayeePrime
            // 
            this.repositoryItemButtonEditRemovePayeePrime.AutoHeight = false;
            this.repositoryItemButtonEditRemovePayeePrime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditRemovePayeePrime.Name = "repositoryItemButtonEditRemovePayeePrime";
            this.repositoryItemButtonEditRemovePayeePrime.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditRemovePayeePrime_ButtonClick);
            // 
            // deWEDatePAYE
            // 
            this.deWEDatePAYE.EditValue = null;
            this.deWEDatePAYE.EnterMoveNextControl = true;
            this.deWEDatePAYE.Location = new System.Drawing.Point(122, 48);
            this.deWEDatePAYE.MaximumSize = new System.Drawing.Size(125, 0);
            this.deWEDatePAYE.Name = "deWEDatePAYE";
            this.deWEDatePAYE.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDatePAYE.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDatePAYE.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deWEDatePAYE.Size = new System.Drawing.Size(125, 22);
            this.deWEDatePAYE.StyleController = this.myLayoutControl1;
            this.deWEDatePAYE.TabIndex = 14;
            // 
            // btnNSSFUpdate2
            // 
            this.btnNSSFUpdate2.Location = new System.Drawing.Point(24, 447);
            this.btnNSSFUpdate2.MaximumSize = new System.Drawing.Size(125, 0);
            this.btnNSSFUpdate2.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnNSSFUpdate2.Name = "btnNSSFUpdate2";
            this.btnNSSFUpdate2.Size = new System.Drawing.Size(125, 30);
            this.btnNSSFUpdate2.StyleController = this.myLayoutControl1;
            this.btnNSSFUpdate2.TabIndex = 11;
            this.btnNSSFUpdate2.Text = "Update NSSF";
            this.btnNSSFUpdate2.Click += new System.EventHandler(this.btnNSSFUpdate_Click);
            // 
            // btnNSSFUpdate
            // 
            this.btnNSSFUpdate.Location = new System.Drawing.Point(251, 48);
            this.btnNSSFUpdate.MaximumSize = new System.Drawing.Size(125, 0);
            this.btnNSSFUpdate.MinimumSize = new System.Drawing.Size(100, 30);
            this.btnNSSFUpdate.Name = "btnNSSFUpdate";
            this.btnNSSFUpdate.Size = new System.Drawing.Size(125, 30);
            this.btnNSSFUpdate.StyleController = this.myLayoutControl1;
            this.btnNSSFUpdate.TabIndex = 10;
            this.btnNSSFUpdate.TabStop = false;
            this.btnNSSFUpdate.Text = "Update NSSF";
            this.btnNSSFUpdate.Click += new System.EventHandler(this.btnNSSFUpdate_Click);
            // 
            // gcNSSF
            // 
            this.gcNSSF.DataSource = this.taxSlabNSSFViewModelBindingSource;
            this.gcNSSF.Location = new System.Drawing.Point(24, 84);
            this.gcNSSF.MainView = this.gvNSSF;
            this.gcNSSF.MaximumSize = new System.Drawing.Size(800, 0);
            this.gcNSSF.Name = "gcNSSF";
            this.gcNSSF.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1,
            this.repositoryItemButtonEditRemoveNSSF,
            this.repositoryItemtxtNSSFAmt,
            this.repositoryItemTxtNSSF_Perc});
            this.gcNSSF.Size = new System.Drawing.Size(800, 359);
            this.gcNSSF.TabIndex = 9;
            this.gcNSSF.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNSSF});
            // 
            // taxSlabNSSFViewModelBindingSource
            // 
            this.taxSlabNSSFViewModelBindingSource.DataSource = typeof(Vision.Model.Settings.TaxSlabViewModel);
            // 
            // gvNSSF
            // 
            this.gvNSSF.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.gvNSSF.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colTaxableSalaryFromValue1,
            this.colTaxableSalaryToValue1,
            this.colTaxPerc,
            this.colMaxTaxValue,
            this.colTaxPercEmployer,
            this.colMaxTaxValueEmployer,
            this.colRemoveRowNSSF});
            this.gvNSSF.GridControl = this.gcNSSF;
            this.gvNSSF.Name = "gvNSSF";
            this.gvNSSF.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvNSSF.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvNSSF.OptionsNavigation.UseTabKey = false;
            this.gvNSSF.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvNSSF.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Columns.Add(this.colTaxableSalaryFromValue1);
            this.gridBand1.Columns.Add(this.colTaxableSalaryToValue1);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.OptionsBand.ShowCaption = false;
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 258;
            // 
            // colTaxableSalaryFromValue1
            // 
            this.colTaxableSalaryFromValue1.ColumnEdit = this.repositoryItemtxtNSSFAmt;
            this.colTaxableSalaryFromValue1.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryFromValue1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryFromValue1.FieldName = "TaxableSalaryFromValue";
            this.colTaxableSalaryFromValue1.MinWidth = 75;
            this.colTaxableSalaryFromValue1.Name = "colTaxableSalaryFromValue1";
            this.colTaxableSalaryFromValue1.Visible = true;
            this.colTaxableSalaryFromValue1.Width = 127;
            // 
            // repositoryItemtxtNSSFAmt
            // 
            this.repositoryItemtxtNSSFAmt.Appearance.Options.UseTextOptions = true;
            this.repositoryItemtxtNSSFAmt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemtxtNSSFAmt.AutoHeight = false;
            this.repositoryItemtxtNSSFAmt.Mask.EditMask = "n2";
            this.repositoryItemtxtNSSFAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemtxtNSSFAmt.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemtxtNSSFAmt.Name = "repositoryItemtxtNSSFAmt";
            // 
            // colTaxableSalaryToValue1
            // 
            this.colTaxableSalaryToValue1.ColumnEdit = this.repositoryItemtxtNSSFAmt;
            this.colTaxableSalaryToValue1.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryToValue1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryToValue1.FieldName = "TaxableSalaryToValue";
            this.colTaxableSalaryToValue1.MinWidth = 75;
            this.colTaxableSalaryToValue1.Name = "colTaxableSalaryToValue1";
            this.colTaxableSalaryToValue1.Visible = true;
            this.colTaxableSalaryToValue1.Width = 131;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.Caption = "Employee";
            this.gridBand2.Columns.Add(this.colTaxPerc);
            this.gridBand2.Columns.Add(this.colMaxTaxValue);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 244;
            // 
            // colTaxPerc
            // 
            this.colTaxPerc.ColumnEdit = this.repositoryItemTxtNSSF_Perc;
            this.colTaxPerc.DisplayFormat.FormatString = "p4";
            this.colTaxPerc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxPerc.FieldName = "TaxPercEmployee";
            this.colTaxPerc.MinWidth = 75;
            this.colTaxPerc.Name = "colTaxPerc";
            this.colTaxPerc.Visible = true;
            this.colTaxPerc.Width = 122;
            // 
            // repositoryItemTxtNSSF_Perc
            // 
            this.repositoryItemTxtNSSF_Perc.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtNSSF_Perc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtNSSF_Perc.AutoHeight = false;
            this.repositoryItemTxtNSSF_Perc.Mask.EditMask = "p4";
            this.repositoryItemTxtNSSF_Perc.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtNSSF_Perc.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtNSSF_Perc.Name = "repositoryItemTxtNSSF_Perc";
            // 
            // colMaxTaxValue
            // 
            this.colMaxTaxValue.ColumnEdit = this.repositoryItemtxtNSSFAmt;
            this.colMaxTaxValue.DisplayFormat.FormatString = "n2";
            this.colMaxTaxValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaxTaxValue.FieldName = "MaxTaxValueEmployee";
            this.colMaxTaxValue.MinWidth = 75;
            this.colMaxTaxValue.Name = "colMaxTaxValue";
            this.colMaxTaxValue.Visible = true;
            this.colMaxTaxValue.Width = 122;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.Caption = "Employer";
            this.gridBand3.Columns.Add(this.colTaxPercEmployer);
            this.gridBand3.Columns.Add(this.colMaxTaxValueEmployer);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 246;
            // 
            // colTaxPercEmployer
            // 
            this.colTaxPercEmployer.ColumnEdit = this.repositoryItemTxtNSSF_Perc;
            this.colTaxPercEmployer.FieldName = "TaxPercEmployer";
            this.colTaxPercEmployer.MinWidth = 75;
            this.colTaxPercEmployer.Name = "colTaxPercEmployer";
            this.colTaxPercEmployer.Visible = true;
            this.colTaxPercEmployer.Width = 123;
            // 
            // colMaxTaxValueEmployer
            // 
            this.colMaxTaxValueEmployer.ColumnEdit = this.repositoryItemtxtNSSFAmt;
            this.colMaxTaxValueEmployer.FieldName = "MaxTaxValueEmployer";
            this.colMaxTaxValueEmployer.MinWidth = 75;
            this.colMaxTaxValueEmployer.Name = "colMaxTaxValueEmployer";
            this.colMaxTaxValueEmployer.Visible = true;
            this.colMaxTaxValueEmployer.Width = 123;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "gridBand4";
            this.gridBand4.Columns.Add(this.colRemoveRowNSSF);
            this.gridBand4.MinWidth = 20;
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.OptionsBand.ShowCaption = false;
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 20;
            // 
            // colRemoveRowNSSF
            // 
            this.colRemoveRowNSSF.Caption = " ";
            this.colRemoveRowNSSF.ColumnEdit = this.repositoryItemButtonEditRemoveNSSF;
            this.colRemoveRowNSSF.Name = "colRemoveRowNSSF";
            this.colRemoveRowNSSF.OptionsColumn.TabStop = false;
            this.colRemoveRowNSSF.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRemoveRowNSSF.Visible = true;
            this.colRemoveRowNSSF.Width = 20;
            // 
            // repositoryItemButtonEditRemoveNSSF
            // 
            this.repositoryItemButtonEditRemoveNSSF.AutoHeight = false;
            this.repositoryItemButtonEditRemoveNSSF.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditRemoveNSSF.Name = "repositoryItemButtonEditRemoveNSSF";
            this.repositoryItemButtonEditRemoveNSSF.Click += new System.EventHandler(this.repositoryItemButtonEditRemoveNSSF_Click);
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // deWEDateNSSF
            // 
            this.deWEDateNSSF.EditValue = null;
            this.deWEDateNSSF.EnterMoveNextControl = true;
            this.deWEDateNSSF.Location = new System.Drawing.Point(122, 48);
            this.deWEDateNSSF.MaximumSize = new System.Drawing.Size(125, 0);
            this.deWEDateNSSF.MinimumSize = new System.Drawing.Size(75, 0);
            this.deWEDateNSSF.Name = "deWEDateNSSF";
            this.deWEDateNSSF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDateNSSF.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDateNSSF.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deWEDateNSSF.Size = new System.Drawing.Size(125, 22);
            this.deWEDateNSSF.StyleController = this.myLayoutControl1;
            this.deWEDateNSSF.TabIndex = 8;
            // 
            // btnUpdateNHIF1
            // 
            this.btnUpdateNHIF1.Location = new System.Drawing.Point(24, 447);
            this.btnUpdateNHIF1.MaximumSize = new System.Drawing.Size(125, 0);
            this.btnUpdateNHIF1.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnUpdateNHIF1.Name = "btnUpdateNHIF1";
            this.btnUpdateNHIF1.Size = new System.Drawing.Size(125, 30);
            this.btnUpdateNHIF1.StyleController = this.myLayoutControl1;
            this.btnUpdateNHIF1.TabIndex = 7;
            this.btnUpdateNHIF1.Text = "Update NHIF";
            this.btnUpdateNHIF1.Click += new System.EventHandler(this.btnUpdateNHIF_Click);
            // 
            // btnUpdateNHIF
            // 
            this.btnUpdateNHIF.Location = new System.Drawing.Point(251, 48);
            this.btnUpdateNHIF.MaximumSize = new System.Drawing.Size(125, 0);
            this.btnUpdateNHIF.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnUpdateNHIF.Name = "btnUpdateNHIF";
            this.btnUpdateNHIF.Size = new System.Drawing.Size(125, 30);
            this.btnUpdateNHIF.StyleController = this.myLayoutControl1;
            this.btnUpdateNHIF.TabIndex = 6;
            this.btnUpdateNHIF.TabStop = false;
            this.btnUpdateNHIF.Text = "Update NHIF";
            this.btnUpdateNHIF.Click += new System.EventHandler(this.btnUpdateNHIF_Click);
            // 
            // gcNHIFTaxSlab
            // 
            this.gcNHIFTaxSlab.DataSource = this.taxSlabNHIFViewModelBindingSource;
            this.gcNHIFTaxSlab.Location = new System.Drawing.Point(24, 84);
            this.gcNHIFTaxSlab.MainView = this.gvNHIFTaxSlab;
            this.gcNHIFTaxSlab.MaximumSize = new System.Drawing.Size(450, 0);
            this.gcNHIFTaxSlab.Name = "gcNHIFTaxSlab";
            this.gcNHIFTaxSlab.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTxtNHIF_Amt,
            this.repositoryItemButtonEditRemoveNHIF});
            this.gcNHIFTaxSlab.Size = new System.Drawing.Size(450, 359);
            this.gcNHIFTaxSlab.TabIndex = 5;
            this.gcNHIFTaxSlab.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNHIFTaxSlab});
            // 
            // taxSlabNHIFViewModelBindingSource
            // 
            this.taxSlabNHIFViewModelBindingSource.DataSource = typeof(Vision.Model.Settings.TaxSlabViewModel);
            // 
            // gvNHIFTaxSlab
            // 
            this.gvNHIFTaxSlab.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTaxableSalaryFromValue,
            this.colTaxableSalaryToValue,
            this.colTaxValue,
            this.colRemoveNHIF});
            this.gvNHIFTaxSlab.CustomizationFormBounds = new System.Drawing.Rectangle(539, 287, 260, 263);
            this.gvNHIFTaxSlab.GridControl = this.gcNHIFTaxSlab;
            this.gvNHIFTaxSlab.Name = "gvNHIFTaxSlab";
            this.gvNHIFTaxSlab.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvNHIFTaxSlab.OptionsCustomization.AllowGroup = false;
            this.gvNHIFTaxSlab.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvNHIFTaxSlab.OptionsNavigation.UseTabKey = false;
            this.gvNHIFTaxSlab.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gvNHIFTaxSlab.OptionsView.ShowGroupPanel = false;
            // 
            // colTaxableSalaryFromValue
            // 
            this.colTaxableSalaryFromValue.ColumnEdit = this.repositoryItemTxtNHIF_Amt;
            this.colTaxableSalaryFromValue.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryFromValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryFromValue.FieldName = "TaxableSalaryFromValue";
            this.colTaxableSalaryFromValue.MaxWidth = 125;
            this.colTaxableSalaryFromValue.Name = "colTaxableSalaryFromValue";
            this.colTaxableSalaryFromValue.Visible = true;
            this.colTaxableSalaryFromValue.VisibleIndex = 0;
            this.colTaxableSalaryFromValue.Width = 125;
            // 
            // repositoryItemTxtNHIF_Amt
            // 
            this.repositoryItemTxtNHIF_Amt.AutoHeight = false;
            this.repositoryItemTxtNHIF_Amt.Mask.EditMask = "n2";
            this.repositoryItemTxtNHIF_Amt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtNHIF_Amt.Name = "repositoryItemTxtNHIF_Amt";
            // 
            // colTaxableSalaryToValue
            // 
            this.colTaxableSalaryToValue.ColumnEdit = this.repositoryItemTxtNHIF_Amt;
            this.colTaxableSalaryToValue.DisplayFormat.FormatString = "n2";
            this.colTaxableSalaryToValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxableSalaryToValue.FieldName = "TaxableSalaryToValue";
            this.colTaxableSalaryToValue.MaxWidth = 125;
            this.colTaxableSalaryToValue.Name = "colTaxableSalaryToValue";
            this.colTaxableSalaryToValue.Visible = true;
            this.colTaxableSalaryToValue.VisibleIndex = 1;
            this.colTaxableSalaryToValue.Width = 125;
            // 
            // colTaxValue
            // 
            this.colTaxValue.ColumnEdit = this.repositoryItemTxtNHIF_Amt;
            this.colTaxValue.DisplayFormat.FormatString = "n2";
            this.colTaxValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxValue.FieldName = "TaxValueEmployee";
            this.colTaxValue.MaxWidth = 125;
            this.colTaxValue.Name = "colTaxValue";
            this.colTaxValue.Visible = true;
            this.colTaxValue.VisibleIndex = 2;
            this.colTaxValue.Width = 125;
            // 
            // colRemoveNHIF
            // 
            this.colRemoveNHIF.Caption = " ";
            this.colRemoveNHIF.ColumnEdit = this.repositoryItemButtonEditRemoveNHIF;
            this.colRemoveNHIF.FieldName = "colRemoveNHIF";
            this.colRemoveNHIF.MaxWidth = 20;
            this.colRemoveNHIF.Name = "colRemoveNHIF";
            this.colRemoveNHIF.OptionsColumn.TabStop = false;
            this.colRemoveNHIF.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRemoveNHIF.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colRemoveNHIF.Visible = true;
            this.colRemoveNHIF.VisibleIndex = 3;
            this.colRemoveNHIF.Width = 20;
            // 
            // repositoryItemButtonEditRemoveNHIF
            // 
            this.repositoryItemButtonEditRemoveNHIF.AutoHeight = false;
            this.repositoryItemButtonEditRemoveNHIF.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemButtonEditRemoveNHIF.Name = "repositoryItemButtonEditRemoveNHIF";
            this.repositoryItemButtonEditRemoveNHIF.Click += new System.EventHandler(this.repositoryItemButtonEditRemoveNHIF_Click);
            // 
            // deWED_NHIF
            // 
            this.deWED_NHIF.EditValue = null;
            this.deWED_NHIF.EnterMoveNextControl = true;
            this.deWED_NHIF.Location = new System.Drawing.Point(122, 48);
            this.deWED_NHIF.MaximumSize = new System.Drawing.Size(125, 0);
            this.deWED_NHIF.Name = "deWED_NHIF";
            this.deWED_NHIF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWED_NHIF.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWED_NHIF.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deWED_NHIF.Size = new System.Drawing.Size(125, 22);
            this.deWED_NHIF.StyleController = this.myLayoutControl1;
            this.deWED_NHIF.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.tabbedControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1373, 514);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 481);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1353, 13);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup6;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1353, 481);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup6});
            this.tabbedControlGroup1.Text = "PAYE Releif";
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem14});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(1329, 433);
            this.layoutControlGroup6.Text = "PAYE Releif";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.dePAYEReliefWED;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(1329, 26);
            this.layoutControlItem9.Text = "With Effect Date";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(95, 16);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.gcPAYERelief;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(954, 407);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.AllowHotTrack = false;
            this.emptySpaceItem14.Location = new System.Drawing.Point(954, 26);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Size = new System.Drawing.Size(375, 407);
            this.emptySpaceItem14.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.layoutControlItem3,
            this.emptySpaceItem4,
            this.layoutControlItem4,
            this.emptySpaceItem12});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1329, 433);
            this.layoutControlGroup1.Text = "NHIF";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deWED_NHIF;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(227, 26);
            this.layoutControlItem1.Text = "With Effect Date";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(95, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gcNHIFTaxSlab;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(454, 363);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(356, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(973, 36);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(129, 399);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(1200, 34);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnUpdateNHIF;
            this.layoutControlItem3.Location = new System.Drawing.Point(227, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(129, 36);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(227, 10);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnUpdateNHIF1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 399);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(129, 34);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.Location = new System.Drawing.Point(454, 36);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(875, 363);
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.emptySpaceItem6,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem5,
            this.emptySpaceItem7,
            this.emptySpaceItem13});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1329, 433);
            this.layoutControlGroup2.Text = "NSSF";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.deWEDateNSSF;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(227, 26);
            this.layoutControlItem5.Text = "With Effect Date";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(95, 16);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(356, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(973, 36);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gcNSSF;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(804, 363);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnNSSFUpdate;
            this.layoutControlItem7.Location = new System.Drawing.Point(227, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(129, 36);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnNSSFUpdate2;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 399);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(129, 34);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(129, 399);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(1200, 34);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(227, 10);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.Location = new System.Drawing.Point(804, 36);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(525, 363);
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem11,
            this.emptySpaceItem8,
            this.layoutControlItem13,
            this.emptySpaceItem9,
            this.layoutControlItem14,
            this.emptySpaceItem10,
            this.emptySpaceItem11,
            this.layoutControlGroup4,
            this.layoutControlGroup5});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1329, 433);
            this.layoutControlGroup3.Text = "PAYE";
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.deWEDatePAYE;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(227, 26);
            this.layoutControlItem11.Text = "With Effect Date";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(95, 16);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(154, 399);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(1175, 34);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.btnUpdatePAYE2;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 399);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(154, 34);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(381, 0);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(948, 36);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.btnUpdatePAYE;
            this.layoutControlItem14.Location = new System.Drawing.Point(227, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(154, 36);
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextVisible = false;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(227, 10);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(960, 36);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(369, 363);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 36);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(480, 363);
            this.layoutControlGroup4.Text = "Primary Income";
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.gcPAYEPrimary;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(454, 316);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem15});
            this.layoutControlGroup5.Location = new System.Drawing.Point(480, 36);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(480, 363);
            this.layoutControlGroup5.Text = "Secondry Income";
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.gcPAYESecondry;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(454, 316);
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextVisible = false;
            // 
            // repositoryItemLookupReliefType
            // 
            this.repositoryItemLookupReliefType.AutoHeight = false;
            this.repositoryItemLookupReliefType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookupReliefType.Name = "repositoryItemLookupReliefType";
            this.repositoryItemLookupReliefType.NullText = "[Relief Type]";
            // 
            // frmTaxSlab
            // 
            this.AllowRefresh = false;
            this.AllowSave = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 546);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmTaxSlab";
            this.Text = "Tax Slabs";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYERelief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYEReliefeViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYERelief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCmbMandatory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPAYEReliefAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemovePAYERelief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePAYEReliefWED.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePAYEReliefWED.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYESecondry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabPAYESecondViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYESecondry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPayeeSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPercPAYESecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveRowPAYESecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYEPrimary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabPAYEPrimeViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYEPrimary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPAYEAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPAYEPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemovePayeePrime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDatePAYE.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDatePAYE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNSSF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabNSSFViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNSSF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemtxtNSSFAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtNSSF_Perc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveNSSF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateNSSF.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateNSSF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNHIFTaxSlab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxSlabNHIFViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNHIFTaxSlab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtNHIF_Amt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditRemoveNHIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWED_NHIF.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWED_NHIF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookupReliefType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraGrid.GridControl gcNHIFTaxSlab;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNHIFTaxSlab;
        private Alit.WinformControls.DateEdit deWED_NHIF;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnUpdateNHIF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.BindingSource taxSlabNHIFViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxableSalaryFromValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtNHIF_Amt;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxableSalaryToValue;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxValue;
        private DevExpress.XtraGrid.Columns.GridColumn colRemoveNHIF;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditRemoveNHIF;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.SimpleButton btnUpdateNHIF1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private Alit.WinformControls.DateEdit deWEDateNSSF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraGrid.GridControl gcNSSF;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnNSSFUpdate2;
        private DevExpress.XtraEditors.SimpleButton btnNSSFUpdate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private System.Windows.Forms.BindingSource taxSlabNSSFViewModelBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditRemoveNSSF;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemtxtNSSFAmt;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtNSSF_Perc;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private Alit.WinformControls.DateEdit deWEDatePAYE;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraGrid.GridControl gcPAYEPrimary;
        private System.Windows.Forms.BindingSource taxSlabPAYEPrimeViewModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPAYEPrimary;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxableSalaryFromValue2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtPAYEAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxableSalaryToValue2;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPerc1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtPAYEPerc;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.SimpleButton btnUpdatePAYE;
        private DevExpress.XtraEditors.SimpleButton btnUpdatePAYE2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraGrid.GridControl gcPAYESecondry;
        private System.Windows.Forms.BindingSource taxSlabPAYESecondViewModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPAYESecondry;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxableSalaryFromValue3;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxableSalaryToValue3;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxPerc2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraGrid.Columns.GridColumn colRemoveRowPayeePrime;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditRemovePayeePrime;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtPayeeSecond;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtPercPAYESecond;
        private DevExpress.XtraGrid.Columns.GridColumn colRemoveRowPAYESecond;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditRemoveRowPAYESecond;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gvNSSF;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTaxableSalaryFromValue1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTaxableSalaryToValue1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTaxPerc;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMaxTaxValue;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTaxPercEmployer;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMaxTaxValueEmployer;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRemoveRowNSSF;
        private DevExpress.XtraGrid.GridControl gcPAYERelief;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPAYERelief;
        private Alit.WinformControls.DateEdit dePAYEReliefWED;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private System.Windows.Forms.BindingSource PAYEReliefeViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYEReliefName;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthlyLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnualLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colWEDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRemovePAYERelief;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditRemovePAYERelief;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtPAYEReliefAmt;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem14;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatory;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemCmbMandatory;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYEReliefType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookupReliefType;
    }
}