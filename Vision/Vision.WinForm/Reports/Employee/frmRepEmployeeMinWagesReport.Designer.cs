namespace Vision.WinForm.Reports.Employee
{
    partial class frmRepEmployeeMinWagesReport
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            this.employeeAttendanceHeaderReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.btnGetReport = new DevExpress.XtraEditors.SimpleButton();
            this.ucEmployeeFilter1 = new Vision.WinForm.Reports.ucEmployeeFilter();
            this.FromDate = new Alit.WinformControls.DateEdit();
            this.gcEmployee = new DevExpress.XtraGrid.GridControl();
            this.employeeMinimumWagesReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeNoPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBasicSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinWagesSal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVariance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployementType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationType1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.employeeAttendanceHeaderReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeMinimumWagesReportBindingSource)).BeginInit();
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
            this.panelContent.Size = new System.Drawing.Size(1202, 555);
            // 
            // employeeAttendanceHeaderReportModelBindingSource
            // 
            this.employeeAttendanceHeaderReportModelBindingSource.DataSource = typeof(Vision.Model.Reports.Employee.EmployeeMinimumWagesReport);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.btnClearData);
            this.myLayoutControl1.Controls.Add(this.btnGetReport);
            this.myLayoutControl1.Controls.Add(this.ucEmployeeFilter1);
            this.myLayoutControl1.Controls.Add(this.FromDate);
            this.myLayoutControl1.Controls.Add(this.gcEmployee);
            this.myLayoutControl1.Controls.Add(this.txtNofRecords);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.myLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(1196, 549);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(393, 126);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(70, 23);
            this.btnClearData.StyleController = this.myLayoutControl1;
            this.btnClearData.TabIndex = 26;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(305, 126);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(84, 23);
            this.btnGetReport.StyleController = this.myLayoutControl1;
            this.btnGetReport.TabIndex = 25;
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
            this.ucEmployeeFilter1.TabIndex = 24;
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
            this.FromDate.TabIndex = 23;
            // 
            // gcEmployee
            // 
            this.gcEmployee.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.gcEmployee.DataSource = this.employeeMinimumWagesReportBindingSource;
            this.gcEmployee.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.gcEmployee.Location = new System.Drawing.Point(12, 153);
            this.gcEmployee.MainView = this.gvData;
            this.gcEmployee.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gcEmployee.Name = "gcEmployee";
            this.gcEmployee.Size = new System.Drawing.Size(1172, 384);
            this.gcEmployee.TabIndex = 21;
            this.gcEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // employeeMinimumWagesReportBindingSource
            // 
            this.employeeMinimumWagesReportBindingSource.DataSource = typeof(Vision.Model.Reports.Employee.EmployeeMinimumWagesReport);
            // 
            // gvData
            // 
            this.gvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeNoPrefix,
            this.colEmployeeNo,
            this.colEmployeeName,
            this.colDesignation,
            this.colLocation,
            this.colCategory,
            this.colBasicSalary,
            this.colMinWagesSal,
            this.colVariance,
            this.colLocationType,
            this.colEmployementType,
            this.colLocationType1});
            this.gvData.DetailHeight = 530;
            gridFormatRule3.Enabled = false;
            gridFormatRule3.Name = "MinWagesSal";
            gridFormatRule3.Rule = null;
            gridFormatRule4.Name = "Format1";
            gridFormatRule4.Rule = null;
            this.gvData.FormatRules.Add(gridFormatRule3);
            this.gvData.FormatRules.Add(gridFormatRule4);
            this.gvData.GridControl = this.gcEmployee;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.ReadOnly = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            // 
            // colEmployeeNoPrefix
            // 
            this.colEmployeeNoPrefix.FieldName = "EmployeeNoPrefix";
            this.colEmployeeNoPrefix.MaxWidth = 125;
            this.colEmployeeNoPrefix.MinWidth = 75;
            this.colEmployeeNoPrefix.Name = "colEmployeeNoPrefix";
            this.colEmployeeNoPrefix.Visible = true;
            this.colEmployeeNoPrefix.VisibleIndex = 0;
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.FieldName = "EmployeeNo";
            this.colEmployeeNo.MaxWidth = 125;
            this.colEmployeeNo.MinWidth = 75;
            this.colEmployeeNo.Name = "colEmployeeNo";
            this.colEmployeeNo.Visible = true;
            this.colEmployeeNo.VisibleIndex = 1;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.MaxWidth = 125;
            this.colEmployeeName.MinWidth = 75;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 2;
            // 
            // colDesignation
            // 
            this.colDesignation.FieldName = "Designation";
            this.colDesignation.MaxWidth = 125;
            this.colDesignation.MinWidth = 75;
            this.colDesignation.Name = "colDesignation";
            this.colDesignation.Visible = true;
            this.colDesignation.VisibleIndex = 3;
            // 
            // colLocation
            // 
            this.colLocation.FieldName = "Location";
            this.colLocation.MaxWidth = 125;
            this.colLocation.MinWidth = 75;
            this.colLocation.Name = "colLocation";
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 4;
            // 
            // colCategory
            // 
            this.colCategory.FieldName = "Category";
            this.colCategory.MaxWidth = 125;
            this.colCategory.MinWidth = 75;
            this.colCategory.Name = "colCategory";
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 5;
            // 
            // colBasicSalary
            // 
            this.colBasicSalary.FieldName = "BasicSalary";
            this.colBasicSalary.MaxWidth = 125;
            this.colBasicSalary.MinWidth = 75;
            this.colBasicSalary.Name = "colBasicSalary";
            this.colBasicSalary.Visible = true;
            this.colBasicSalary.VisibleIndex = 6;
            // 
            // colMinWagesSal
            // 
            this.colMinWagesSal.FieldName = "MinWagesSal";
            this.colMinWagesSal.MaxWidth = 125;
            this.colMinWagesSal.MinWidth = 75;
            this.colMinWagesSal.Name = "colMinWagesSal";
            this.colMinWagesSal.Visible = true;
            this.colMinWagesSal.VisibleIndex = 7;
            // 
            // colVariance
            // 
            this.colVariance.FieldName = "Variance";
            this.colVariance.MaxWidth = 125;
            this.colVariance.MinWidth = 75;
            this.colVariance.Name = "colVariance";
            this.colVariance.OptionsColumn.ReadOnly = true;
            this.colVariance.Visible = true;
            this.colVariance.VisibleIndex = 8;
            // 
            // colLocationType
            // 
            this.colLocationType.FieldName = "LocationType";
            this.colLocationType.MaxWidth = 125;
            this.colLocationType.MinWidth = 75;
            this.colLocationType.Name = "colLocationType";
            this.colLocationType.OptionsColumn.ReadOnly = true;
            this.colLocationType.Visible = true;
            this.colLocationType.VisibleIndex = 9;
            // 
            // colEmployementType
            // 
            this.colEmployementType.FieldName = "EmployementType";
            this.colEmployementType.MaxWidth = 125;
            this.colEmployementType.MinWidth = 75;
            this.colEmployementType.Name = "colEmployementType";
            this.colEmployementType.OptionsColumn.ReadOnly = true;
            this.colEmployementType.Visible = true;
            this.colEmployementType.VisibleIndex = 10;
            // 
            // colLocationType1
            // 
            this.colLocationType1.FieldName = "LocationType";
            this.colLocationType1.MaxWidth = 125;
            this.colLocationType1.MinWidth = 75;
            this.colLocationType1.Name = "colLocationType1";
            this.colLocationType1.Visible = true;
            this.colLocationType1.VisibleIndex = 11;
            // 
            // txtNofRecords
            // 
            this.txtNofRecords.EnterMoveNextControl = true;
            this.txtNofRecords.Location = new System.Drawing.Point(556, 126);
            this.txtNofRecords.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtNofRecords.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtNofRecords.Name = "txtNofRecords";
            this.txtNofRecords.Properties.ReadOnly = true;
            this.txtNofRecords.Size = new System.Drawing.Size(199, 22);
            this.txtNofRecords.StyleController = this.myLayoutControl1;
            this.txtNofRecords.TabIndex = 19;
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(1196, 549);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gcEmployee;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 141);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1176, 388);
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
            this.layoutControlItem2.Size = new System.Drawing.Size(88, 27);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnClearData;
            this.layoutControlItem3.Location = new System.Drawing.Point(381, 114);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(74, 27);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtNofRecords;
            this.layoutControlItem5.CustomizationFormText = "No. of Records";
            this.layoutControlItem5.Location = new System.Drawing.Point(455, 114);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(292, 27);
            this.layoutControlItem5.Text = "No. of Records";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(86, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(747, 114);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(214, 27);
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
            // frmRepEmployeeMinWagesReport
            // 
            this.AllowSave = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 581);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmRepEmployeeMinWagesReport";
            this.Text = "Employee Minimum Wages Variance Report";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeAttendanceHeaderReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeMinimumWagesReportBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource employeeAttendanceHeaderReportModelBindingSource;
        private DevExpress.XtraGrid.GridControl gcEmployee;
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
        private System.Windows.Forms.BindingSource employeeMinimumWagesReportBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignation;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colBasicSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colMinWagesSal;
        private DevExpress.XtraGrid.Columns.GridColumn colVariance;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationType;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployementType;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationType1;
    }
}