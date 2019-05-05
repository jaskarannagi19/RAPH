namespace Vision.WinForm.Reports.TimeAttendance
{
    partial class frmRepEmployeeAttendanceSummary
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
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.txtNofDays = new Alit.WinformControls.TextEdit();
            this.ucEmployeeFilter1 = new Vision.WinForm.Reports.ucEmployeeFilter();
            this.btnGetReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.employeeAttendanceSummaryReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeNoPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPresent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbsent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekends = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendsWorked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRestDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRestDayWorked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidaysWorked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLeave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSafari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNofDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeAttendanceSummaryReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(1224, 550);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.txtNofDays);
            this.myLayoutControl1.Controls.Add(this.ucEmployeeFilter1);
            this.myLayoutControl1.Controls.Add(this.btnGetReport);
            this.myLayoutControl1.Controls.Add(this.btnClearData);
            this.myLayoutControl1.Controls.Add(this.btnExportToExcel);
            this.myLayoutControl1.Controls.Add(this.gridControlData);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1220, 546);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // txtNofDays
            // 
            this.txtNofDays.EnterMoveNextControl = true;
            this.txtNofDays.Location = new System.Drawing.Point(427, 122);
            this.txtNofDays.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtNofDays.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtNofDays.Name = "txtNofDays";
            this.txtNofDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNofDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNofDays.Properties.ReadOnly = true;
            this.txtNofDays.Size = new System.Drawing.Size(100, 22);
            this.txtNofDays.StyleController = this.myLayoutControl1;
            this.txtNofDays.TabIndex = 16;
            this.txtNofDays.TabStop = false;
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
            this.ucEmployeeFilter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucEmployeeFilter1.MaximumSize = new System.Drawing.Size(1100, 110);
            this.ucEmployeeFilter1.Name = "ucEmployeeFilter1";
            this.ucEmployeeFilter1.Size = new System.Drawing.Size(1097, 106);
            this.ucEmployeeFilter1.TabIndex = 15;
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(12, 122);
            this.btnGetReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetReport.MaximumSize = new System.Drawing.Size(100, 0);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(100, 23);
            this.btnGetReport.StyleController = this.myLayoutControl1;
            this.btnGetReport.TabIndex = 7;
            this.btnGetReport.Text = "Refresh Data";
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(116, 122);
            this.btnClearData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClearData.MaximumSize = new System.Drawing.Size(100, 0);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(100, 23);
            this.btnClearData.StyleController = this.myLayoutControl1;
            this.btnClearData.TabIndex = 9;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(220, 122);
            this.btnExportToExcel.MaximumSize = new System.Drawing.Size(125, 0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(125, 23);
            this.btnExportToExcel.StyleController = this.myLayoutControl1;
            this.btnExportToExcel.TabIndex = 14;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // gridControlData
            // 
            this.gridControlData.DataSource = this.employeeAttendanceSummaryReportModelBindingSource;
            this.gridControlData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControlData.Location = new System.Drawing.Point(12, 149);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(1196, 385);
            this.gridControlData.TabIndex = 8;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // employeeAttendanceSummaryReportModelBindingSource
            // 
            this.employeeAttendanceSummaryReportModelBindingSource.DataSource = typeof(Vision.Model.Reports.TimeAttendance.EmployeeAttendanceSummaryReportModel);
            // 
            // gridViewData
            // 
            this.gridViewData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeNoPrefix,
            this.colEmployeeNo,
            this.colEmployeeName,
            this.colPresent,
            this.colAbsent,
            this.colWeekends,
            this.colWeekendsWorked,
            this.colRestDay,
            this.colRestDayWorked,
            this.colHolidays,
            this.colHolidaysWorked,
            this.colLeave,
            this.colSafari,
            this.colTotalDays});
            this.gridViewData.DetailHeight = 311;
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.OptionsBehavior.Editable = false;
            this.gridViewData.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewData.OptionsBehavior.ReadOnly = true;
            this.gridViewData.OptionsFind.AlwaysVisible = true;
            this.gridViewData.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.gridViewData.OptionsFind.ShowCloseButton = false;
            this.gridViewData.OptionsFind.ShowFindButton = false;
            this.gridViewData.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewData.OptionsNavigation.UseTabKey = false;
            this.gridViewData.OptionsView.ShowGroupPanel = false;
            // 
            // colEmployeeNoPrefix
            // 
            this.colEmployeeNoPrefix.FieldName = "EmployeeNoPrefix";
            this.colEmployeeNoPrefix.MaxWidth = 150;
            this.colEmployeeNoPrefix.MinWidth = 100;
            this.colEmployeeNoPrefix.Name = "colEmployeeNoPrefix";
            this.colEmployeeNoPrefix.Width = 100;
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.FieldName = "EmployeeNo";
            this.colEmployeeNo.MaxWidth = 125;
            this.colEmployeeNo.MinWidth = 100;
            this.colEmployeeNo.Name = "colEmployeeNo";
            this.colEmployeeNo.Visible = true;
            this.colEmployeeNo.VisibleIndex = 0;
            this.colEmployeeNo.Width = 100;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 319;
            // 
            // colPresent
            // 
            this.colPresent.AppearanceHeader.Options.UseTextOptions = true;
            this.colPresent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPresent.FieldName = "Present";
            this.colPresent.MaxWidth = 75;
            this.colPresent.MinWidth = 50;
            this.colPresent.Name = "colPresent";
            this.colPresent.Visible = true;
            this.colPresent.VisibleIndex = 2;
            // 
            // colAbsent
            // 
            this.colAbsent.AppearanceHeader.Options.UseTextOptions = true;
            this.colAbsent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAbsent.FieldName = "Absent";
            this.colAbsent.MaxWidth = 75;
            this.colAbsent.MinWidth = 50;
            this.colAbsent.Name = "colAbsent";
            this.colAbsent.Visible = true;
            this.colAbsent.VisibleIndex = 3;
            // 
            // colWeekends
            // 
            this.colWeekends.AppearanceHeader.Options.UseTextOptions = true;
            this.colWeekends.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWeekends.FieldName = "Weekends";
            this.colWeekends.MaxWidth = 75;
            this.colWeekends.MinWidth = 50;
            this.colWeekends.Name = "colWeekends";
            this.colWeekends.Visible = true;
            this.colWeekends.VisibleIndex = 4;
            // 
            // colWeekendsWorked
            // 
            this.colWeekendsWorked.AppearanceHeader.Options.UseTextOptions = true;
            this.colWeekendsWorked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWeekendsWorked.FieldName = "WeekendsWorked";
            this.colWeekendsWorked.MaxWidth = 75;
            this.colWeekendsWorked.MinWidth = 50;
            this.colWeekendsWorked.Name = "colWeekendsWorked";
            this.colWeekendsWorked.Visible = true;
            this.colWeekendsWorked.VisibleIndex = 5;
            // 
            // colRestDay
            // 
            this.colRestDay.AppearanceHeader.Options.UseTextOptions = true;
            this.colRestDay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRestDay.FieldName = "RestDay";
            this.colRestDay.MaxWidth = 75;
            this.colRestDay.MinWidth = 50;
            this.colRestDay.Name = "colRestDay";
            this.colRestDay.Visible = true;
            this.colRestDay.VisibleIndex = 6;
            // 
            // colRestDayWorked
            // 
            this.colRestDayWorked.AppearanceHeader.Options.UseTextOptions = true;
            this.colRestDayWorked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRestDayWorked.FieldName = "RestDayWorked";
            this.colRestDayWorked.MaxWidth = 75;
            this.colRestDayWorked.MinWidth = 50;
            this.colRestDayWorked.Name = "colRestDayWorked";
            this.colRestDayWorked.Visible = true;
            this.colRestDayWorked.VisibleIndex = 7;
            // 
            // colHolidays
            // 
            this.colHolidays.AppearanceHeader.Options.UseTextOptions = true;
            this.colHolidays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHolidays.FieldName = "Holidays";
            this.colHolidays.MaxWidth = 75;
            this.colHolidays.MinWidth = 50;
            this.colHolidays.Name = "colHolidays";
            this.colHolidays.Visible = true;
            this.colHolidays.VisibleIndex = 8;
            // 
            // colHolidaysWorked
            // 
            this.colHolidaysWorked.AppearanceHeader.Options.UseTextOptions = true;
            this.colHolidaysWorked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHolidaysWorked.FieldName = "HolidaysWorked";
            this.colHolidaysWorked.MaxWidth = 75;
            this.colHolidaysWorked.MinWidth = 50;
            this.colHolidaysWorked.Name = "colHolidaysWorked";
            this.colHolidaysWorked.Visible = true;
            this.colHolidaysWorked.VisibleIndex = 9;
            // 
            // colLeave
            // 
            this.colLeave.AppearanceHeader.Options.UseTextOptions = true;
            this.colLeave.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLeave.FieldName = "Leave";
            this.colLeave.MaxWidth = 75;
            this.colLeave.MinWidth = 50;
            this.colLeave.Name = "colLeave";
            this.colLeave.Visible = true;
            this.colLeave.VisibleIndex = 10;
            // 
            // colSafari
            // 
            this.colSafari.AppearanceHeader.Options.UseTextOptions = true;
            this.colSafari.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSafari.FieldName = "Safari";
            this.colSafari.MaxWidth = 75;
            this.colSafari.MinWidth = 50;
            this.colSafari.Name = "colSafari";
            this.colSafari.Visible = true;
            this.colSafari.VisibleIndex = 11;
            // 
            // colTotalDays
            // 
            this.colTotalDays.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalDays.FieldName = "TotalDays";
            this.colTotalDays.MaxWidth = 75;
            this.colTotalDays.MinWidth = 50;
            this.colTotalDays.Name = "colTotalDays";
            this.colTotalDays.Visible = true;
            this.colTotalDays.VisibleIndex = 12;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem11,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1220, 546);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControlData;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 137);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1200, 389);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnGetReport;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 110);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(104, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClearData;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(104, 110);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(104, 27);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnExportToExcel;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(208, 110);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(129, 27);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucEmployeeFilter1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 110);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(104, 110);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1101, 110);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(1101, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(99, 137);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(519, 110);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(582, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtNofDays;
            this.layoutControlItem2.Location = new System.Drawing.Point(337, 110);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(182, 27);
            this.layoutControlItem2.Text = "Nof. Records";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 16);
            // 
            // frmRepEmployeeAttendanceSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 577);
            this.FirstControl = this.myLayoutControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmRepEmployeeAttendanceSummary";
            this.Text = "Attendance Summary";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNofDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeAttendanceSummaryReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnGetReport;
        private DevExpress.XtraEditors.SimpleButton btnClearData;
        private DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private System.Windows.Forms.BindingSource employeeAttendanceSummaryReportModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colPresent;
        private DevExpress.XtraGrid.Columns.GridColumn colAbsent;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekends;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendsWorked;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidays;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidaysWorked;
        private DevExpress.XtraGrid.Columns.GridColumn colLeave;
        private DevExpress.XtraGrid.Columns.GridColumn colSafari;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDays;
        private ucEmployeeFilter ucEmployeeFilter1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNo;
        private Alit.WinformControls.TextEdit txtNofDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colRestDay;
        private DevExpress.XtraGrid.Columns.GridColumn colRestDayWorked;
    }
}