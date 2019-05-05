namespace Vision.WinForm.Reports.Employee
{
    partial class frmRepEmployeeSalaryIncrementReport
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetReport = new DevExpress.XtraEditors.SimpleButton();
            this.ucEmployeeFilter1 = new Vision.WinForm.Reports.ucEmployeeFilter();
            this.FromDate = new Alit.WinformControls.DateEdit();
            this.gcEmployeeSalaryIncrement = new DevExpress.XtraGrid.GridControl();
            this.employeeSalaryIncrementReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeNoPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeSalaryIncrementNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrentBasicSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncrementAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIncrementPercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastIncDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemarks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriviousBasicSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewBasicSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtNofRecords = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Date = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployeeSalaryIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSalaryIncrementReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNofRecords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelContent.Size = new System.Drawing.Size(1200, 551);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.btnClearData);
            this.myLayoutControl1.Controls.Add(this.btnGetReport);
            this.myLayoutControl1.Controls.Add(this.ucEmployeeFilter1);
            this.myLayoutControl1.Controls.Add(this.FromDate);
            this.myLayoutControl1.Controls.Add(this.gcEmployeeSalaryIncrement);
            this.myLayoutControl1.Controls.Add(this.txtNofRecords);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(1196, 547);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(406, 126);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(94, 23);
            this.btnClearData.StyleController = this.myLayoutControl1;
            this.btnClearData.TabIndex = 4;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(305, 126);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(97, 23);
            this.btnGetReport.StyleController = this.myLayoutControl1;
            this.btnGetReport.TabIndex = 3;
            this.btnGetReport.Text = "Refresh Data";
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // ucEmployeeFilter1
            // 
            this.ucEmployeeFilter1.DateFrom = new System.DateTime(((long)(0)));
            this.ucEmployeeFilter1.DateTo = new System.DateTime(((long)(0)));
            this.ucEmployeeFilter1.DepartmentID = 0;
            this.ucEmployeeFilter1.DesignationID = 0;
            this.ucEmployeeFilter1.EmploymentType = -1;
            this.ucEmployeeFilter1.Location = new System.Drawing.Point(12, 12);
            this.ucEmployeeFilter1.LocationID = 0;
            this.ucEmployeeFilter1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ucEmployeeFilter1.MinimumSize = new System.Drawing.Size(75, 110);
            this.ucEmployeeFilter1.Name = "ucEmployeeFilter1";
            this.ucEmployeeFilter1.ShowDateRangeFilter = false;
            this.ucEmployeeFilter1.Size = new System.Drawing.Size(1172, 110);
            this.ucEmployeeFilter1.TabIndex = 0;
            this.ucEmployeeFilter1.Load += new System.EventHandler(this.ucEmployeeFilter1_Load);
            // 
            // FromDate
            // 
            this.FromDate.EditValue = null;
            this.FromDate.EnterMoveNextControl = true;
            this.FromDate.Location = new System.Drawing.Point(101, 126);
            this.FromDate.MaximumSize = new System.Drawing.Size(300, 0);
            this.FromDate.MinimumSize = new System.Drawing.Size(200, 0);
            this.FromDate.Name = "FromDate";
            this.FromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FromDate.Properties.DisplayFormat.FormatString = "MMM-yyyy";
            this.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.FromDate.Properties.Mask.EditMask = "MMM-yyyy";
            this.FromDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.FromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.FromDate.Properties.VistaCalendarViewStyle = ((DevExpress.XtraEditors.VistaCalendarViewStyle)((DevExpress.XtraEditors.VistaCalendarViewStyle.YearView | DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView)));
            this.FromDate.Size = new System.Drawing.Size(200, 22);
            this.FromDate.StyleController = this.myLayoutControl1;
            this.FromDate.TabIndex = 2;
            // 
            // gcEmployeeSalaryIncrement
            // 
            this.gcEmployeeSalaryIncrement.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcEmployeeSalaryIncrement.DataSource = this.employeeSalaryIncrementReportModelBindingSource;
            this.gcEmployeeSalaryIncrement.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gcEmployeeSalaryIncrement.Location = new System.Drawing.Point(12, 153);
            this.gcEmployeeSalaryIncrement.MainView = this.gvData;
            this.gcEmployeeSalaryIncrement.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gcEmployeeSalaryIncrement.Name = "gcEmployeeSalaryIncrement";
            this.gcEmployeeSalaryIncrement.Size = new System.Drawing.Size(1172, 382);
            this.gcEmployeeSalaryIncrement.TabIndex = 5;
            this.gcEmployeeSalaryIncrement.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // employeeSalaryIncrementReportModelBindingSource
            // 
            this.employeeSalaryIncrementReportModelBindingSource.DataSource = typeof(Vision.Model.Reports.Employee.EmployeeSalaryIncrementReportModel);
            // 
            // gvData
            // 
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeNoPrefix,
            this.colEmployeeSalaryIncrementNo,
            this.colEmployeeName,
            this.colCurrentBasicSalary,
            this.colIncrementAmount,
            this.colIncrementPercentage,
            this.colLastIncDate,
            this.colRemarks,
            this.colPriviousBasicSalary,
            this.colNewBasicSalary});
            this.gvData.DetailHeight = 530;
            gridFormatRule1.Enabled = false;
            gridFormatRule1.Name = "MinWagesSal";
            gridFormatRule1.Rule = null;
            gridFormatRule2.Name = "Format1";
            gridFormatRule2.Rule = null;
            this.gvData.FormatRules.Add(gridFormatRule1);
            this.gvData.FormatRules.Add(gridFormatRule2);
            this.gvData.GridControl = this.gcEmployeeSalaryIncrement;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.ReadOnly = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // colEmployeeNoPrefix
            // 
            this.colEmployeeNoPrefix.Caption = "E. Prefix";
            this.colEmployeeNoPrefix.FieldName = "EmployeeNoPrefix";
            this.colEmployeeNoPrefix.MaxWidth = 125;
            this.colEmployeeNoPrefix.Name = "colEmployeeNoPrefix";
            this.colEmployeeNoPrefix.Visible = true;
            this.colEmployeeNoPrefix.VisibleIndex = 0;
            // 
            // colEmployeeSalaryIncrementNo
            // 
            this.colEmployeeSalaryIncrementNo.Caption = "Salary Increment No.";
            this.colEmployeeSalaryIncrementNo.FieldName = "EmployeeSalaryIncrementNo";
            this.colEmployeeSalaryIncrementNo.MaxWidth = 125;
            this.colEmployeeSalaryIncrementNo.MinWidth = 75;
            this.colEmployeeSalaryIncrementNo.Name = "colEmployeeSalaryIncrementNo";
            this.colEmployeeSalaryIncrementNo.Visible = true;
            this.colEmployeeSalaryIncrementNo.VisibleIndex = 1;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "Employee Name";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.MinWidth = 75;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 2;
            // 
            // colCurrentBasicSalary
            // 
            this.colCurrentBasicSalary.Caption = "Current Basic Salary";
            this.colCurrentBasicSalary.FieldName = "CurrentBasicSalary";
            this.colCurrentBasicSalary.MinWidth = 75;
            this.colCurrentBasicSalary.Name = "colCurrentBasicSalary";
            this.colCurrentBasicSalary.Visible = true;
            this.colCurrentBasicSalary.VisibleIndex = 5;
            // 
            // colIncrementAmount
            // 
            this.colIncrementAmount.Caption = "Increment Amount";
            this.colIncrementAmount.FieldName = "IncrementAmount";
            this.colIncrementAmount.MinWidth = 75;
            this.colIncrementAmount.Name = "colIncrementAmount";
            this.colIncrementAmount.Visible = true;
            this.colIncrementAmount.VisibleIndex = 6;
            // 
            // colIncrementPercentage
            // 
            this.colIncrementPercentage.Caption = "Increment Percentage";
            this.colIncrementPercentage.FieldName = "IncrementPercentage";
            this.colIncrementPercentage.MinWidth = 75;
            this.colIncrementPercentage.Name = "colIncrementPercentage";
            this.colIncrementPercentage.Visible = true;
            this.colIncrementPercentage.VisibleIndex = 7;
            // 
            // colLastIncDate
            // 
            this.colLastIncDate.Caption = "Last Inc Date";
            this.colLastIncDate.FieldName = "LastIncDate";
            this.colLastIncDate.MinWidth = 75;
            this.colLastIncDate.Name = "colLastIncDate";
            this.colLastIncDate.Visible = true;
            this.colLastIncDate.VisibleIndex = 3;
            // 
            // colRemarks
            // 
            this.colRemarks.FieldName = "Remarks";
            this.colRemarks.MinWidth = 75;
            this.colRemarks.Name = "colRemarks";
            this.colRemarks.Visible = true;
            this.colRemarks.VisibleIndex = 9;
            // 
            // colPriviousBasicSalary
            // 
            this.colPriviousBasicSalary.FieldName = "PriviousBasicSalary";
            this.colPriviousBasicSalary.Name = "colPriviousBasicSalary";
            this.colPriviousBasicSalary.Visible = true;
            this.colPriviousBasicSalary.VisibleIndex = 4;
            // 
            // colNewBasicSalary
            // 
            this.colNewBasicSalary.FieldName = "NewBasicSalary";
            this.colNewBasicSalary.Name = "colNewBasicSalary";
            this.colNewBasicSalary.Visible = true;
            this.colNewBasicSalary.VisibleIndex = 8;
            // 
            // txtNofRecords
            // 
            this.txtNofRecords.EnterMoveNextControl = true;
            this.txtNofRecords.Location = new System.Drawing.Point(593, 126);
            this.txtNofRecords.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtNofRecords.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtNofRecords.Name = "txtNofRecords";
            this.txtNofRecords.Properties.ReadOnly = true;
            this.txtNofRecords.Size = new System.Drawing.Size(163, 22);
            this.txtNofRecords.StyleController = this.myLayoutControl1;
            this.txtNofRecords.TabIndex = 1;
            this.txtNofRecords.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.Date,
            this.emptySpaceItem4,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1196, 547);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gcEmployeeSalaryIncrement;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 141);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1176, 386);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucEmployeeFilter1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(79, 114);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1176, 114);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Date
            // 
            this.Date.Control = this.FromDate;
            this.Date.Location = new System.Drawing.Point(0, 114);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(293, 27);
            this.Date.Text = "Month";
            this.Date.TextSize = new System.Drawing.Size(86, 16);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(961, 114);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(215, 27);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnGetReport;
            this.layoutControlItem2.Location = new System.Drawing.Point(293, 114);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(88, 27);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(101, 27);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClearData;
            this.layoutControlItem3.Location = new System.Drawing.Point(394, 114);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(98, 27);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtNofRecords;
            this.layoutControlItem5.CustomizationFormText = "No. of Records";
            this.layoutControlItem5.Location = new System.Drawing.Point(492, 114);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(256, 27);
            this.layoutControlItem5.Text = "No. of Records";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(86, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(748, 114);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(213, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(1156, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(20, 114);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(1156, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(10, 114);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmRepEmployeeSalaryIncrementReport
            // 
            this.AllowSave = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 578);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmRepEmployeeSalaryIncrementReport";
            this.Text = "Employee Salary Increment Report";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployeeSalaryIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSalaryIncrementReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNofRecords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcEmployeeSalaryIncrement;
        private DevExpress.XtraGrid.Views.Grid.GridView gvData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private ucEmployeeFilter ucEmployeeFilter1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Alit.WinformControls.DateEdit FromDate;
        private DevExpress.XtraLayout.LayoutControlItem Date;
        private DevExpress.XtraEditors.SimpleButton btnGetReport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnClearData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Alit.WinformControls.TextEdit txtNofRecords;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeSalaryIncrementNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLastIncDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrentBasicSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colIncrementAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colIncrementPercentage;
        private DevExpress.XtraGrid.Columns.GridColumn colRemarks;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colPriviousBasicSalary;
        private System.Windows.Forms.BindingSource employeeSalaryIncrementReportModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNewBasicSalary;
    }
}