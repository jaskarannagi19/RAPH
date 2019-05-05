namespace Vision.WinForm.Reports.Employee
{
    partial class frmRepEmployeeList
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.colWorking = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnResetFormat = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveFormat = new DevExpress.XtraEditors.SimpleButton();
            this.lookupFormat = new Alit.WinformControls.LookUpEdit();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.gcEmployee = new DevExpress.XtraGrid.GridControl();
            this.employeeListReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBandImage = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEmployeeImage = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEmployeeNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTACode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNationality = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAddress1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAddress2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAddress3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colWorkVisaExpiryDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGender = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeNoPrefix = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmailID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colShiftAllocationDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPOBoxNO = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMulticurrencyText = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEmploymentType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmploymentEffectiveDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeShiftName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colShiftStartTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colShiftEndTime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colContractExpiryDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colReinstatementReason = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTerminationTypeID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTerminationDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTerminationReason = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeShiftType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colDepartmentName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colLocationName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeDesignationName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMinimumWageCategoryName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeWIBAClassName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmployeeAccountingLedger = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colIDNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNHIFNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPFNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNSSFNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPINNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMpesaNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colIncomeType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBasicSalary = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colHousingAllowance = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colWeekendAllowance = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDailyRate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTALatenessCharges = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTAAttendanceType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTAMissPunch = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTAOvertime = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTAWeekendType = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTAWeekEndAttendance = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTANegativeLeave = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTAEarlyGoing = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colBankName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBankAcNo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBankBranch = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBankCurrency = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPayCycle = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPaymentMode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.btnRefreshData = new DevExpress.XtraEditors.SimpleButton();
            this.ucEmployeeFilter1 = new Vision.WinForm.Reports.ucEmployeeFilter();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeListReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            this.panelContent.Size = new System.Drawing.Size(1666, 725);
            // 
            // colWorking
            // 
            this.colWorking.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colWorking.AppearanceCell.Options.UseBackColor = true;
            this.colWorking.FieldName = "EmployementStatus";
            this.colWorking.MinWidth = 75;
            this.colWorking.Name = "colWorking";
            this.colWorking.OptionsColumn.ReadOnly = true;
            this.colWorking.Visible = true;
            this.colWorking.Width = 112;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnResetFormat);
            this.layoutControl1.Controls.Add(this.btnSaveFormat);
            this.layoutControl1.Controls.Add(this.lookupFormat);
            this.layoutControl1.Controls.Add(this.btnExportToExcel);
            this.layoutControl1.Controls.Add(this.btnClearData);
            this.layoutControl1.Controls.Add(this.gcEmployee);
            this.layoutControl1.Controls.Add(this.btnRefreshData);
            this.layoutControl1.Controls.Add(this.ucEmployeeFilter1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(3, 3);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1098, 224, 650, 405);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1660, 719);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnResetFormat
            // 
            this.btnResetFormat.Location = new System.Drawing.Point(818, 65);
            this.btnResetFormat.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnResetFormat.Name = "btnResetFormat";
            this.btnResetFormat.Size = new System.Drawing.Size(346, 30);
            this.btnResetFormat.StyleController = this.layoutControl1;
            this.btnResetFormat.TabIndex = 29;
            this.btnResetFormat.Text = "Reset Format to Default";
            this.btnResetFormat.Click += new System.EventHandler(this.btnResetFormat_Click);
            // 
            // btnSaveFormat
            // 
            this.btnSaveFormat.Location = new System.Drawing.Point(818, 38);
            this.btnSaveFormat.Name = "btnSaveFormat";
            this.btnSaveFormat.Size = new System.Drawing.Size(346, 23);
            this.btnSaveFormat.StyleController = this.layoutControl1;
            this.btnSaveFormat.TabIndex = 28;
            this.btnSaveFormat.Text = "Save Format";
            this.btnSaveFormat.Click += new System.EventHandler(this.btnSaveFormat_Click);
            // 
            // lookupFormat
            // 
            this.lookupFormat.EnterMoveNextControl = true;
            this.lookupFormat.Location = new System.Drawing.Point(864, 12);
            this.lookupFormat.MaximumSize = new System.Drawing.Size(300, 0);
            this.lookupFormat.Name = "lookupFormat";
            this.lookupFormat.Properties.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
            this.lookupFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupFormat.Properties.MaxLength = 50;
            this.lookupFormat.Properties.NullText = "Select";
            this.lookupFormat.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupFormat.Size = new System.Drawing.Size(300, 22);
            this.lookupFormat.StyleController = this.layoutControl1;
            this.lookupFormat.TabIndex = 27;
            this.lookupFormat.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.lookupFormat_ProcessNewValue);
            this.lookupFormat.EditValueChanged += new System.EventHandler(this.lookupFormat_EditValueChanged);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(320, 128);
            this.btnExportToExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExportToExcel.MaximumSize = new System.Drawing.Size(150, 30);
            this.btnExportToExcel.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(150, 30);
            this.btnExportToExcel.StyleController = this.layoutControl1;
            this.btnExportToExcel.TabIndex = 24;
            this.btnExportToExcel.Text = "Export To Excel`";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(166, 128);
            this.btnClearData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClearData.MaximumSize = new System.Drawing.Size(150, 30);
            this.btnClearData.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(150, 30);
            this.btnClearData.StyleController = this.layoutControl1;
            this.btnClearData.TabIndex = 22;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // gcEmployee
            // 
            this.gcEmployee.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcEmployee.DataSource = this.employeeListReportModelBindingSource;
            this.gcEmployee.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gcEmployee.Location = new System.Drawing.Point(12, 162);
            this.gcEmployee.MainView = this.advBandedGridView1;
            this.gcEmployee.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gcEmployee.Name = "gcEmployee";
            this.gcEmployee.Size = new System.Drawing.Size(1636, 545);
            this.gcEmployee.TabIndex = 20;
            this.gcEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            // 
            // employeeListReportModelBindingSource
            // 
            this.employeeListReportModelBindingSource.DataSource = typeof(Vision.Model.Reports.Employee.EmployeeListReportModel);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Appearance.BandPanel.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.advBandedGridView1.Appearance.BandPanel.Options.UseFont = true;
            this.advBandedGridView1.BandPanelRowHeight = 35;
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBandImage,
            this.gridBand1,
            this.gridBand7,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colEmployeeNoPrefix,
            this.colEmployeeNo,
            this.colTACode,
            this.colWorking,
            this.colEmployeeName,
            this.colEmployeeImage,
            this.colGender,
            this.colNationality,
            this.colWorkVisaExpiryDate,
            this.colAddress1,
            this.colAddress2,
            this.colAddress3,
            this.colPOBoxNO,
            this.colCity,
            this.colMpesaNo,
            this.colEmailID,
            this.colMulticurrencyText,
            this.colIDNo,
            this.colNSSFNo,
            this.colNHIFNo,
            this.colPINNo,
            this.colPFNo,
            this.colPaymentMode,
            this.colPayCycle,
            this.colBankAcNo,
            this.colBankName,
            this.colBankBranch,
            this.colBankCurrency,
            this.colIncomeType,
            this.colTAAttendanceType,
            this.colTALatenessCharges,
            this.colTAEarlyGoing,
            this.colTAOvertime,
            this.colTANegativeLeave,
            this.colTAWeekendType,
            this.colTAWeekEndAttendance,
            this.colTAMissPunch,
            this.colEmploymentEffectiveDate,
            this.colEmploymentType,
            this.colContractExpiryDate,
            this.colDepartmentName,
            this.colLocationName,
            this.colEmployeeDesignationName,
            this.colEmployeeWIBAClassName,
            this.colMinimumWageCategoryName,
            this.colEmployeeAccountingLedger,
            this.colDailyRate,
            this.colBasicSalary,
            this.colHousingAllowance,
            this.colWeekendAllowance,
            this.colEmployeeShiftType,
            this.colEmployeeShiftName,
            this.colShiftStartTime,
            this.colShiftEndTime,
            this.colShiftAllocationDate,
            this.colReinstatementReason,
            this.colTerminationDate,
            this.colTerminationTypeID,
            this.colTerminationReason});
            this.advBandedGridView1.CustomizationFormBounds = new System.Drawing.Rectangle(58, 94, 260, 883);
            this.advBandedGridView1.DetailHeight = 530;
            gridFormatRule1.Column = this.colWorking;
            gridFormatRule1.ColumnApplyTo = this.colWorking;
            gridFormatRule1.Name = "FormatEmployementStatus_NoWorking";
            formatConditionRuleExpression1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            formatConditionRuleExpression1.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Appearance.Options.UseForeColor = true;
            formatConditionRuleExpression1.Expression = "Lower(ToStr([EmployementStatus])) <> \'working\'";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.advBandedGridView1.FormatRules.Add(gridFormatRule1);
            this.advBandedGridView1.GridControl = this.gcEmployee;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsBehavior.Editable = false;
            this.advBandedGridView1.OptionsBehavior.ReadOnly = true;
            this.advBandedGridView1.OptionsCustomization.AllowChangeBandParent = true;
            this.advBandedGridView1.OptionsView.ColumnAutoWidth = true;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            this.advBandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEmployeeNo, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridBandImage
            // 
            this.gridBandImage.Caption = "Image";
            this.gridBandImage.Columns.Add(this.colEmployeeImage);
            this.gridBandImage.Name = "gridBandImage";
            this.gridBandImage.OptionsBand.ShowCaption = false;
            this.gridBandImage.VisibleIndex = 0;
            this.gridBandImage.Width = 150;
            // 
            // colEmployeeImage
            // 
            this.colEmployeeImage.AutoFillDown = true;
            this.colEmployeeImage.FieldName = "EmployeeImage";
            this.colEmployeeImage.MinWidth = 75;
            this.colEmployeeImage.Name = "colEmployeeImage";
            this.colEmployeeImage.Visible = true;
            this.colEmployeeImage.Width = 150;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Personal Detail";
            this.gridBand1.Columns.Add(this.colEmployeeNo);
            this.gridBand1.Columns.Add(this.colTACode);
            this.gridBand1.Columns.Add(this.colWorking);
            this.gridBand1.Columns.Add(this.colEmployeeName);
            this.gridBand1.Columns.Add(this.colCity);
            this.gridBand1.Columns.Add(this.colNationality);
            this.gridBand1.Columns.Add(this.colAddress1);
            this.gridBand1.Columns.Add(this.colAddress2);
            this.gridBand1.Columns.Add(this.colAddress3);
            this.gridBand1.Columns.Add(this.colWorkVisaExpiryDate);
            this.gridBand1.Columns.Add(this.colGender);
            this.gridBand1.Columns.Add(this.colEmployeeNoPrefix);
            this.gridBand1.Columns.Add(this.colEmailID);
            this.gridBand1.Columns.Add(this.colShiftAllocationDate);
            this.gridBand1.Columns.Add(this.colPOBoxNO);
            this.gridBand1.Columns.Add(this.colMulticurrencyText);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 1;
            this.gridBand1.Width = 384;
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colEmployeeNo.AppearanceCell.FontSizeDelta = 1;
            this.colEmployeeNo.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colEmployeeNo.AppearanceCell.Options.UseBackColor = true;
            this.colEmployeeNo.AppearanceCell.Options.UseFont = true;
            this.colEmployeeNo.FieldName = "EmployeeNo";
            this.colEmployeeNo.MinWidth = 75;
            this.colEmployeeNo.Name = "colEmployeeNo";
            this.colEmployeeNo.Visible = true;
            this.colEmployeeNo.Width = 149;
            // 
            // colTACode
            // 
            this.colTACode.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colTACode.AppearanceCell.FontSizeDelta = 1;
            this.colTACode.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colTACode.AppearanceCell.Options.UseBackColor = true;
            this.colTACode.AppearanceCell.Options.UseFont = true;
            this.colTACode.FieldName = "TACode";
            this.colTACode.MinWidth = 75;
            this.colTACode.Name = "colTACode";
            this.colTACode.Visible = true;
            this.colTACode.Width = 123;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.AppearanceCell.FontSizeDelta = 1;
            this.colEmployeeName.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colEmployeeName.AppearanceCell.Options.UseFont = true;
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.RowIndex = 1;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.Width = 384;
            // 
            // colCity
            // 
            this.colCity.FieldName = "City";
            this.colCity.MinWidth = 75;
            this.colCity.Name = "colCity";
            this.colCity.RowIndex = 2;
            this.colCity.Visible = true;
            this.colCity.Width = 197;
            // 
            // colNationality
            // 
            this.colNationality.FieldName = "Nationality";
            this.colNationality.MinWidth = 75;
            this.colNationality.Name = "colNationality";
            this.colNationality.RowIndex = 2;
            this.colNationality.Visible = true;
            this.colNationality.Width = 187;
            // 
            // colAddress1
            // 
            this.colAddress1.FieldName = "Address1";
            this.colAddress1.MinWidth = 75;
            this.colAddress1.Name = "colAddress1";
            this.colAddress1.RowIndex = 3;
            this.colAddress1.Visible = true;
            this.colAddress1.Width = 384;
            // 
            // colAddress2
            // 
            this.colAddress2.FieldName = "Address2";
            this.colAddress2.MinWidth = 75;
            this.colAddress2.Name = "colAddress2";
            this.colAddress2.RowIndex = 4;
            this.colAddress2.Visible = true;
            this.colAddress2.Width = 384;
            // 
            // colAddress3
            // 
            this.colAddress3.FieldName = "Address3";
            this.colAddress3.MinWidth = 75;
            this.colAddress3.Name = "colAddress3";
            this.colAddress3.RowIndex = 5;
            this.colAddress3.Visible = true;
            this.colAddress3.Width = 272;
            // 
            // colWorkVisaExpiryDate
            // 
            this.colWorkVisaExpiryDate.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colWorkVisaExpiryDate.AppearanceCell.Options.UseBackColor = true;
            this.colWorkVisaExpiryDate.FieldName = "WorkVisaExpiryDate";
            this.colWorkVisaExpiryDate.MinWidth = 75;
            this.colWorkVisaExpiryDate.Name = "colWorkVisaExpiryDate";
            this.colWorkVisaExpiryDate.RowIndex = 5;
            this.colWorkVisaExpiryDate.Visible = true;
            this.colWorkVisaExpiryDate.Width = 112;
            // 
            // colGender
            // 
            this.colGender.FieldName = "Gender";
            this.colGender.MinWidth = 75;
            this.colGender.Name = "colGender";
            this.colGender.RowIndex = 6;
            this.colGender.Width = 100;
            // 
            // colEmployeeNoPrefix
            // 
            this.colEmployeeNoPrefix.FieldName = "EmployeeNoPrefix";
            this.colEmployeeNoPrefix.MinWidth = 75;
            this.colEmployeeNoPrefix.Name = "colEmployeeNoPrefix";
            this.colEmployeeNoPrefix.RowIndex = 7;
            this.colEmployeeNoPrefix.Width = 100;
            // 
            // colEmailID
            // 
            this.colEmailID.FieldName = "EmailID";
            this.colEmailID.MinWidth = 75;
            this.colEmailID.Name = "colEmailID";
            this.colEmailID.RowIndex = 8;
            this.colEmailID.Width = 100;
            // 
            // colShiftAllocationDate
            // 
            this.colShiftAllocationDate.FieldName = "ShiftAllocationDate";
            this.colShiftAllocationDate.MinWidth = 75;
            this.colShiftAllocationDate.Name = "colShiftAllocationDate";
            this.colShiftAllocationDate.RowIndex = 9;
            this.colShiftAllocationDate.Width = 100;
            // 
            // colPOBoxNO
            // 
            this.colPOBoxNO.FieldName = "POBoxNO";
            this.colPOBoxNO.MinWidth = 75;
            this.colPOBoxNO.Name = "colPOBoxNO";
            this.colPOBoxNO.RowIndex = 10;
            this.colPOBoxNO.Width = 100;
            // 
            // colMulticurrencyText
            // 
            this.colMulticurrencyText.FieldName = "MulticurrencyText";
            this.colMulticurrencyText.MinWidth = 75;
            this.colMulticurrencyText.Name = "colMulticurrencyText";
            this.colMulticurrencyText.OptionsColumn.ReadOnly = true;
            this.colMulticurrencyText.RowIndex = 10;
            this.colMulticurrencyText.Width = 100;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "Employement";
            this.gridBand7.Columns.Add(this.colEmploymentType);
            this.gridBand7.Columns.Add(this.colEmploymentEffectiveDate);
            this.gridBand7.Columns.Add(this.colEmployeeShiftName);
            this.gridBand7.Columns.Add(this.colShiftStartTime);
            this.gridBand7.Columns.Add(this.colShiftEndTime);
            this.gridBand7.Columns.Add(this.colContractExpiryDate);
            this.gridBand7.Columns.Add(this.colReinstatementReason);
            this.gridBand7.Columns.Add(this.colTerminationTypeID);
            this.gridBand7.Columns.Add(this.colTerminationDate);
            this.gridBand7.Columns.Add(this.colTerminationReason);
            this.gridBand7.Columns.Add(this.colEmployeeShiftType);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 2;
            this.gridBand7.Width = 200;
            // 
            // colEmploymentType
            // 
            this.colEmploymentType.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colEmploymentType.AppearanceCell.Options.UseBackColor = true;
            this.colEmploymentType.FieldName = "EmploymentType";
            this.colEmploymentType.MinWidth = 75;
            this.colEmploymentType.Name = "colEmploymentType";
            this.colEmploymentType.Visible = true;
            this.colEmploymentType.Width = 200;
            // 
            // colEmploymentEffectiveDate
            // 
            this.colEmploymentEffectiveDate.FieldName = "EmploymentEffectiveDate";
            this.colEmploymentEffectiveDate.MinWidth = 75;
            this.colEmploymentEffectiveDate.Name = "colEmploymentEffectiveDate";
            this.colEmploymentEffectiveDate.RowIndex = 1;
            this.colEmploymentEffectiveDate.Visible = true;
            this.colEmploymentEffectiveDate.Width = 200;
            // 
            // colEmployeeShiftName
            // 
            this.colEmployeeShiftName.FieldName = "EmployeeShiftName";
            this.colEmployeeShiftName.MinWidth = 75;
            this.colEmployeeShiftName.Name = "colEmployeeShiftName";
            this.colEmployeeShiftName.RowIndex = 2;
            this.colEmployeeShiftName.Visible = true;
            this.colEmployeeShiftName.Width = 200;
            // 
            // colShiftStartTime
            // 
            this.colShiftStartTime.DisplayFormat.FormatString = "T";
            this.colShiftStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colShiftStartTime.FieldName = "ShiftStartTime";
            this.colShiftStartTime.MinWidth = 75;
            this.colShiftStartTime.Name = "colShiftStartTime";
            this.colShiftStartTime.RowIndex = 3;
            this.colShiftStartTime.Visible = true;
            this.colShiftStartTime.Width = 100;
            // 
            // colShiftEndTime
            // 
            this.colShiftEndTime.DisplayFormat.FormatString = "T";
            this.colShiftEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colShiftEndTime.FieldName = "ShiftEndTime";
            this.colShiftEndTime.MinWidth = 75;
            this.colShiftEndTime.Name = "colShiftEndTime";
            this.colShiftEndTime.RowIndex = 3;
            this.colShiftEndTime.Visible = true;
            this.colShiftEndTime.Width = 100;
            // 
            // colContractExpiryDate
            // 
            this.colContractExpiryDate.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colContractExpiryDate.AppearanceCell.Options.UseBackColor = true;
            this.colContractExpiryDate.FieldName = "ContractExpiryDate";
            this.colContractExpiryDate.MinWidth = 75;
            this.colContractExpiryDate.Name = "colContractExpiryDate";
            this.colContractExpiryDate.RowIndex = 4;
            this.colContractExpiryDate.Visible = true;
            this.colContractExpiryDate.Width = 200;
            // 
            // colReinstatementReason
            // 
            this.colReinstatementReason.FieldName = "ReinstatementReason";
            this.colReinstatementReason.MinWidth = 75;
            this.colReinstatementReason.Name = "colReinstatementReason";
            this.colReinstatementReason.RowIndex = 5;
            this.colReinstatementReason.Width = 100;
            // 
            // colTerminationTypeID
            // 
            this.colTerminationTypeID.FieldName = "TerminationTypeID";
            this.colTerminationTypeID.MinWidth = 75;
            this.colTerminationTypeID.Name = "colTerminationTypeID";
            this.colTerminationTypeID.RowIndex = 5;
            this.colTerminationTypeID.Visible = true;
            this.colTerminationTypeID.Width = 100;
            // 
            // colTerminationDate
            // 
            this.colTerminationDate.FieldName = "TerminationDate";
            this.colTerminationDate.MinWidth = 75;
            this.colTerminationDate.Name = "colTerminationDate";
            this.colTerminationDate.RowIndex = 5;
            this.colTerminationDate.Visible = true;
            this.colTerminationDate.Width = 100;
            // 
            // colTerminationReason
            // 
            this.colTerminationReason.FieldName = "TerminationReason";
            this.colTerminationReason.MinWidth = 75;
            this.colTerminationReason.Name = "colTerminationReason";
            this.colTerminationReason.RowIndex = 6;
            this.colTerminationReason.Width = 200;
            // 
            // colEmployeeShiftType
            // 
            this.colEmployeeShiftType.FieldName = "EmployeeShiftType";
            this.colEmployeeShiftType.MinWidth = 75;
            this.colEmployeeShiftType.Name = "colEmployeeShiftType";
            this.colEmployeeShiftType.RowIndex = 7;
            this.colEmployeeShiftType.Width = 100;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Service Detail";
            this.gridBand2.Columns.Add(this.colDepartmentName);
            this.gridBand2.Columns.Add(this.colLocationName);
            this.gridBand2.Columns.Add(this.colEmployeeDesignationName);
            this.gridBand2.Columns.Add(this.colMinimumWageCategoryName);
            this.gridBand2.Columns.Add(this.colEmployeeWIBAClassName);
            this.gridBand2.Columns.Add(this.colEmployeeAccountingLedger);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 3;
            this.gridBand2.Width = 200;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colDepartmentName.AppearanceCell.Options.UseBackColor = true;
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.MinWidth = 75;
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.Width = 200;
            // 
            // colLocationName
            // 
            this.colLocationName.FieldName = "LocationName";
            this.colLocationName.MinWidth = 75;
            this.colLocationName.Name = "colLocationName";
            this.colLocationName.RowIndex = 1;
            this.colLocationName.Visible = true;
            this.colLocationName.Width = 200;
            // 
            // colEmployeeDesignationName
            // 
            this.colEmployeeDesignationName.FieldName = "EmployeeDesignationName";
            this.colEmployeeDesignationName.MinWidth = 75;
            this.colEmployeeDesignationName.Name = "colEmployeeDesignationName";
            this.colEmployeeDesignationName.RowIndex = 2;
            this.colEmployeeDesignationName.Visible = true;
            this.colEmployeeDesignationName.Width = 200;
            // 
            // colMinimumWageCategoryName
            // 
            this.colMinimumWageCategoryName.FieldName = "MinimumWageCategoryName";
            this.colMinimumWageCategoryName.MinWidth = 75;
            this.colMinimumWageCategoryName.Name = "colMinimumWageCategoryName";
            this.colMinimumWageCategoryName.RowIndex = 3;
            this.colMinimumWageCategoryName.Visible = true;
            this.colMinimumWageCategoryName.Width = 200;
            // 
            // colEmployeeWIBAClassName
            // 
            this.colEmployeeWIBAClassName.FieldName = "EmployeeWIBAClassName";
            this.colEmployeeWIBAClassName.MinWidth = 75;
            this.colEmployeeWIBAClassName.Name = "colEmployeeWIBAClassName";
            this.colEmployeeWIBAClassName.RowIndex = 4;
            this.colEmployeeWIBAClassName.Visible = true;
            this.colEmployeeWIBAClassName.Width = 200;
            // 
            // colEmployeeAccountingLedger
            // 
            this.colEmployeeAccountingLedger.FieldName = "EmployeeAccountingLedger";
            this.colEmployeeAccountingLedger.Name = "colEmployeeAccountingLedger";
            this.colEmployeeAccountingLedger.RowIndex = 5;
            this.colEmployeeAccountingLedger.Visible = true;
            this.colEmployeeAccountingLedger.Width = 200;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Legal No(s)";
            this.gridBand3.Columns.Add(this.colIDNo);
            this.gridBand3.Columns.Add(this.colNHIFNo);
            this.gridBand3.Columns.Add(this.colPFNo);
            this.gridBand3.Columns.Add(this.colNSSFNo);
            this.gridBand3.Columns.Add(this.colPINNo);
            this.gridBand3.Columns.Add(this.colMpesaNo);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 4;
            this.gridBand3.Width = 150;
            // 
            // colIDNo
            // 
            this.colIDNo.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colIDNo.AppearanceCell.Options.UseBackColor = true;
            this.colIDNo.FieldName = "IDNo";
            this.colIDNo.MinWidth = 75;
            this.colIDNo.Name = "colIDNo";
            this.colIDNo.Visible = true;
            this.colIDNo.Width = 150;
            // 
            // colNHIFNo
            // 
            this.colNHIFNo.FieldName = "NHIFNo";
            this.colNHIFNo.MinWidth = 75;
            this.colNHIFNo.Name = "colNHIFNo";
            this.colNHIFNo.RowIndex = 1;
            this.colNHIFNo.Visible = true;
            this.colNHIFNo.Width = 150;
            // 
            // colPFNo
            // 
            this.colPFNo.FieldName = "PFNo";
            this.colPFNo.MinWidth = 75;
            this.colPFNo.Name = "colPFNo";
            this.colPFNo.RowIndex = 2;
            this.colPFNo.Visible = true;
            this.colPFNo.Width = 150;
            // 
            // colNSSFNo
            // 
            this.colNSSFNo.FieldName = "NSSFNo";
            this.colNSSFNo.MinWidth = 75;
            this.colNSSFNo.Name = "colNSSFNo";
            this.colNSSFNo.RowIndex = 3;
            this.colNSSFNo.Visible = true;
            this.colNSSFNo.Width = 150;
            // 
            // colPINNo
            // 
            this.colPINNo.FieldName = "PINNo";
            this.colPINNo.MinWidth = 75;
            this.colPINNo.Name = "colPINNo";
            this.colPINNo.RowIndex = 4;
            this.colPINNo.Visible = true;
            this.colPINNo.Width = 150;
            // 
            // colMpesaNo
            // 
            this.colMpesaNo.FieldName = "MpesaNo";
            this.colMpesaNo.MinWidth = 75;
            this.colMpesaNo.Name = "colMpesaNo";
            this.colMpesaNo.RowIndex = 5;
            this.colMpesaNo.Visible = true;
            this.colMpesaNo.Width = 150;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Income";
            this.gridBand4.Columns.Add(this.colIncomeType);
            this.gridBand4.Columns.Add(this.colBasicSalary);
            this.gridBand4.Columns.Add(this.colHousingAllowance);
            this.gridBand4.Columns.Add(this.colWeekendAllowance);
            this.gridBand4.Columns.Add(this.colDailyRate);
            this.gridBand4.Columns.Add(this.colTALatenessCharges);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 5;
            this.gridBand4.Width = 150;
            // 
            // colIncomeType
            // 
            this.colIncomeType.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colIncomeType.AppearanceCell.Options.UseBackColor = true;
            this.colIncomeType.FieldName = "IncomeType";
            this.colIncomeType.MinWidth = 75;
            this.colIncomeType.Name = "colIncomeType";
            this.colIncomeType.Visible = true;
            this.colIncomeType.Width = 150;
            // 
            // colBasicSalary
            // 
            this.colBasicSalary.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colBasicSalary.AppearanceCell.FontSizeDelta = 1;
            this.colBasicSalary.AppearanceCell.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.colBasicSalary.AppearanceCell.Options.UseBackColor = true;
            this.colBasicSalary.AppearanceCell.Options.UseFont = true;
            this.colBasicSalary.DisplayFormat.FormatString = "n2";
            this.colBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBasicSalary.FieldName = "BasicSalary";
            this.colBasicSalary.MinWidth = 75;
            this.colBasicSalary.Name = "colBasicSalary";
            this.colBasicSalary.RowIndex = 1;
            this.colBasicSalary.Visible = true;
            this.colBasicSalary.Width = 150;
            // 
            // colHousingAllowance
            // 
            this.colHousingAllowance.DisplayFormat.FormatString = "n2";
            this.colHousingAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHousingAllowance.FieldName = "HousingAllowance";
            this.colHousingAllowance.MinWidth = 75;
            this.colHousingAllowance.Name = "colHousingAllowance";
            this.colHousingAllowance.RowIndex = 2;
            this.colHousingAllowance.Visible = true;
            this.colHousingAllowance.Width = 150;
            // 
            // colWeekendAllowance
            // 
            this.colWeekendAllowance.DisplayFormat.FormatString = "n2";
            this.colWeekendAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWeekendAllowance.FieldName = "WeekendAllowance";
            this.colWeekendAllowance.MinWidth = 75;
            this.colWeekendAllowance.Name = "colWeekendAllowance";
            this.colWeekendAllowance.RowIndex = 3;
            this.colWeekendAllowance.Visible = true;
            this.colWeekendAllowance.Width = 150;
            // 
            // colDailyRate
            // 
            this.colDailyRate.DisplayFormat.FormatString = "n2";
            this.colDailyRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDailyRate.FieldName = "DailyRate";
            this.colDailyRate.MinWidth = 75;
            this.colDailyRate.Name = "colDailyRate";
            this.colDailyRate.RowIndex = 4;
            this.colDailyRate.Visible = true;
            this.colDailyRate.Width = 150;
            // 
            // colTALatenessCharges
            // 
            this.colTALatenessCharges.DisplayFormat.FormatString = "n2";
            this.colTALatenessCharges.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTALatenessCharges.FieldName = "TALatenessCharges";
            this.colTALatenessCharges.MinWidth = 75;
            this.colTALatenessCharges.Name = "colTALatenessCharges";
            this.colTALatenessCharges.RowIndex = 5;
            this.colTALatenessCharges.Visible = true;
            this.colTALatenessCharges.Width = 150;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "T & A Settings";
            this.gridBand5.Columns.Add(this.colTAAttendanceType);
            this.gridBand5.Columns.Add(this.colTAMissPunch);
            this.gridBand5.Columns.Add(this.colTAOvertime);
            this.gridBand5.Columns.Add(this.colTAWeekendType);
            this.gridBand5.Columns.Add(this.colTAWeekEndAttendance);
            this.gridBand5.Columns.Add(this.colTANegativeLeave);
            this.gridBand5.Columns.Add(this.colTAEarlyGoing);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 6;
            this.gridBand5.Width = 150;
            // 
            // colTAAttendanceType
            // 
            this.colTAAttendanceType.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colTAAttendanceType.AppearanceCell.Options.UseBackColor = true;
            this.colTAAttendanceType.FieldName = "TAAttendanceType";
            this.colTAAttendanceType.MinWidth = 75;
            this.colTAAttendanceType.Name = "colTAAttendanceType";
            this.colTAAttendanceType.Visible = true;
            this.colTAAttendanceType.Width = 150;
            // 
            // colTAMissPunch
            // 
            this.colTAMissPunch.FieldName = "TAMissPunch";
            this.colTAMissPunch.MinWidth = 75;
            this.colTAMissPunch.Name = "colTAMissPunch";
            this.colTAMissPunch.RowIndex = 1;
            this.colTAMissPunch.Visible = true;
            this.colTAMissPunch.Width = 150;
            // 
            // colTAOvertime
            // 
            this.colTAOvertime.FieldName = "TAOvertime";
            this.colTAOvertime.MinWidth = 75;
            this.colTAOvertime.Name = "colTAOvertime";
            this.colTAOvertime.RowIndex = 2;
            this.colTAOvertime.Visible = true;
            this.colTAOvertime.Width = 150;
            // 
            // colTAWeekendType
            // 
            this.colTAWeekendType.FieldName = "TAWeekendType";
            this.colTAWeekendType.MinWidth = 75;
            this.colTAWeekendType.Name = "colTAWeekendType";
            this.colTAWeekendType.RowIndex = 3;
            this.colTAWeekendType.Visible = true;
            this.colTAWeekendType.Width = 150;
            // 
            // colTAWeekEndAttendance
            // 
            this.colTAWeekEndAttendance.FieldName = "TAWeekEndAttendance";
            this.colTAWeekEndAttendance.MinWidth = 75;
            this.colTAWeekEndAttendance.Name = "colTAWeekEndAttendance";
            this.colTAWeekEndAttendance.RowIndex = 4;
            this.colTAWeekEndAttendance.Visible = true;
            this.colTAWeekEndAttendance.Width = 150;
            // 
            // colTANegativeLeave
            // 
            this.colTANegativeLeave.FieldName = "TANegativeLeave";
            this.colTANegativeLeave.MinWidth = 75;
            this.colTANegativeLeave.Name = "colTANegativeLeave";
            this.colTANegativeLeave.RowIndex = 5;
            this.colTANegativeLeave.Visible = true;
            this.colTANegativeLeave.Width = 150;
            // 
            // colTAEarlyGoing
            // 
            this.colTAEarlyGoing.FieldName = "TAEarlyGoing";
            this.colTAEarlyGoing.MinWidth = 75;
            this.colTAEarlyGoing.Name = "colTAEarlyGoing";
            this.colTAEarlyGoing.RowIndex = 6;
            this.colTAEarlyGoing.Width = 100;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "Bank Detail";
            this.gridBand6.Columns.Add(this.colBankName);
            this.gridBand6.Columns.Add(this.colBankAcNo);
            this.gridBand6.Columns.Add(this.colBankBranch);
            this.gridBand6.Columns.Add(this.colBankCurrency);
            this.gridBand6.Columns.Add(this.colPayCycle);
            this.gridBand6.Columns.Add(this.colPaymentMode);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 7;
            this.gridBand6.Width = 150;
            // 
            // colBankName
            // 
            this.colBankName.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colBankName.AppearanceCell.Options.UseBackColor = true;
            this.colBankName.FieldName = "BankName";
            this.colBankName.MinWidth = 75;
            this.colBankName.Name = "colBankName";
            this.colBankName.Visible = true;
            this.colBankName.Width = 150;
            // 
            // colBankAcNo
            // 
            this.colBankAcNo.FieldName = "BankAcNo";
            this.colBankAcNo.MinWidth = 75;
            this.colBankAcNo.Name = "colBankAcNo";
            this.colBankAcNo.RowIndex = 1;
            this.colBankAcNo.Visible = true;
            this.colBankAcNo.Width = 150;
            // 
            // colBankBranch
            // 
            this.colBankBranch.FieldName = "BankBranch";
            this.colBankBranch.MinWidth = 75;
            this.colBankBranch.Name = "colBankBranch";
            this.colBankBranch.RowIndex = 2;
            this.colBankBranch.Visible = true;
            this.colBankBranch.Width = 150;
            // 
            // colBankCurrency
            // 
            this.colBankCurrency.AutoFillDown = true;
            this.colBankCurrency.FieldName = "BankCurrency";
            this.colBankCurrency.MinWidth = 75;
            this.colBankCurrency.Name = "colBankCurrency";
            this.colBankCurrency.RowIndex = 3;
            this.colBankCurrency.Visible = true;
            this.colBankCurrency.Width = 150;
            // 
            // colPayCycle
            // 
            this.colPayCycle.FieldName = "PayCycle";
            this.colPayCycle.MinWidth = 75;
            this.colPayCycle.Name = "colPayCycle";
            this.colPayCycle.RowIndex = 4;
            this.colPayCycle.Visible = true;
            this.colPayCycle.Width = 100;
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.FieldName = "PaymentMode";
            this.colPaymentMode.MinWidth = 75;
            this.colPaymentMode.Name = "colPaymentMode";
            this.colPaymentMode.RowIndex = 5;
            this.colPaymentMode.Visible = true;
            this.colPaymentMode.Width = 100;
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Location = new System.Drawing.Point(12, 128);
            this.btnRefreshData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefreshData.MaximumSize = new System.Drawing.Size(150, 30);
            this.btnRefreshData.MinimumSize = new System.Drawing.Size(0, 30);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(150, 30);
            this.btnRefreshData.StyleController = this.layoutControl1;
            this.btnRefreshData.TabIndex = 19;
            this.btnRefreshData.Text = "Refresh Data";
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // ucEmployeeFilter1
            // 
            this.ucEmployeeFilter1.DateFrom = new System.DateTime(((long)(0)));
            this.ucEmployeeFilter1.DateTo = new System.DateTime(((long)(0)));
            this.ucEmployeeFilter1.DepartmentID = 0;
            this.ucEmployeeFilter1.DesignationID = 0;
            this.ucEmployeeFilter1.EmploymentType = -1;
            this.ucEmployeeFilter1.Location = new System.Drawing.Point(13, 13);
            this.ucEmployeeFilter1.LocationID = 0;
            this.ucEmployeeFilter1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucEmployeeFilter1.MinimumSize = new System.Drawing.Size(800, 110);
            this.ucEmployeeFilter1.Name = "ucEmployeeFilter1";
            this.ucEmployeeFilter1.ShowDateRangeFilter = false;
            this.ucEmployeeFilter1.Size = new System.Drawing.Size(800, 110);
            this.ucEmployeeFilter1.TabIndex = 18;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.emptySpaceItem2,
            this.emptySpaceItem5,
            this.emptySpaceItem4,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1660, 719);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucEmployeeFilter1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Size = new System.Drawing.Size(806, 116);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gcEmployee;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 150);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1640, 549);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnRefreshData;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 116);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(154, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnClearData;
            this.layoutControlItem5.Location = new System.Drawing.Point(154, 116);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(154, 34);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnExportToExcel;
            this.layoutControlItem7.Location = new System.Drawing.Point(308, 116);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(154, 34);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(462, 116);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(344, 34);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(806, 87);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(350, 63);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(1156, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(484, 150);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lookupFormat;
            this.layoutControlItem6.Location = new System.Drawing.Point(806, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(350, 26);
            this.layoutControlItem6.Text = "Format";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(41, 16);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnSaveFormat;
            this.layoutControlItem9.Location = new System.Drawing.Point(806, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(350, 27);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnResetFormat;
            this.layoutControlItem4.Location = new System.Drawing.Point(806, 53);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(350, 34);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // frmRepEmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1666, 751);
            this.FirstControl = this.layoutControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmRepEmployeeList";
            this.Text = "Employee List";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookupFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeListReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnRefreshData;
        private ucEmployeeFilter ucEmployeeFilter1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gcEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraEditors.SimpleButton btnClearData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private System.Windows.Forms.BindingSource employeeListReportModelBindingSource;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeImage;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTACode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colWorking;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colWorkVisaExpiryDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIDNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNHIFNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNSSFNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPINNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPFNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGender;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeNoPrefix;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCity;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmailID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPaymentMode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPayCycle;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBankAcNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBankName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBankBranch;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBankCurrency;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIncomeType;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTAAttendanceType;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTALatenessCharges;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTAEarlyGoing;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTAOvertime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTANegativeLeave;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTAWeekendType;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTAWeekEndAttendance;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTAMissPunch;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmploymentType;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeDesignationName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDailyRate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHousingAllowance;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colWeekendAllowance;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeShiftType;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeShiftName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMpesaNo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBasicSalary;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMinimumWageCategoryName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeWIBAClassName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colLocationName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDepartmentName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colContractExpiryDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmploymentEffectiveDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colShiftStartTime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colShiftEndTime;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colShiftAllocationDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colReinstatementReason;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTerminationDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTerminationTypeID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTerminationReason;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNationality;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAddress1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAddress2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAddress3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPOBoxNO;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMulticurrencyText;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmployeeAccountingLedger;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBandImage;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private Alit.WinformControls.LookUpEdit lookupFormat;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton btnSaveFormat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.SimpleButton btnResetFormat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}