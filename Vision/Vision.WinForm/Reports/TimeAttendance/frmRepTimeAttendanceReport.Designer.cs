namespace Vision.WinForm.Reports.TimeAttendance
{
    partial class frmRepTimeAttendanceReport
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
            this.txtNofRecords = new Alit.WinformControls.TextEdit();
            this.lookupEmployee = new Alit.WinformControls.LookUpEdit();
            this.lookupLeaveType = new Alit.WinformControls.LookUpEdit();
            this.cmbReportType = new Alit.WinformControls.ComboBoxEdit();
            this.ucEmployeeFilter1 = new Vision.WinForm.Reports.ucEmployeeFilter();
            this.btnGetReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLeaveType = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmployee = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNofRecords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLeaveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLeaveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(1474, 551);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.txtNofRecords);
            this.myLayoutControl1.Controls.Add(this.lookupEmployee);
            this.myLayoutControl1.Controls.Add(this.lookupLeaveType);
            this.myLayoutControl1.Controls.Add(this.cmbReportType);
            this.myLayoutControl1.Controls.Add(this.ucEmployeeFilter1);
            this.myLayoutControl1.Controls.Add(this.btnGetReport);
            this.myLayoutControl1.Controls.Add(this.btnClearData);
            this.myLayoutControl1.Controls.Add(this.btnExportToExcel);
            this.myLayoutControl1.Controls.Add(this.gridControlData);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1468, 545);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // txtNofRecords
            // 
            this.txtNofRecords.EnterMoveNextControl = true;
            this.txtNofRecords.Location = new System.Drawing.Point(427, 168);
            this.txtNofRecords.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtNofRecords.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtNofRecords.Name = "txtNofRecords";
            this.txtNofRecords.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNofRecords.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNofRecords.Properties.ReadOnly = true;
            this.txtNofRecords.Size = new System.Drawing.Size(100, 22);
            this.txtNofRecords.StyleController = this.myLayoutControl1;
            this.txtNofRecords.TabIndex = 19;
            this.txtNofRecords.TabStop = false;
            // 
            // lookupEmployee
            // 
            this.lookupEmployee.EnterMoveNextControl = true;
            this.lookupEmployee.Location = new System.Drawing.Point(951, 122);
            this.lookupEmployee.MaximumSize = new System.Drawing.Size(300, 0);
            this.lookupEmployee.Name = "lookupEmployee";
            this.lookupEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmployee.Properties.DropDownRows = 30;
            this.lookupEmployee.Properties.NullText = "Select";
            this.lookupEmployee.Properties.PopupWidth = 1000;
            this.lookupEmployee.Properties.PopupWidthMode = DevExpress.XtraEditors.PopupWidthMode.ContentWidth;
            this.lookupEmployee.Size = new System.Drawing.Size(291, 22);
            this.lookupEmployee.StyleController = this.myLayoutControl1;
            this.lookupEmployee.TabIndex = 18;
            this.lookupEmployee.Validating += new System.ComponentModel.CancelEventHandler(this.lookupEmployee_Validating);
            // 
            // lookupLeaveType
            // 
            this.lookupLeaveType.EnterMoveNextControl = true;
            this.lookupLeaveType.Location = new System.Drawing.Point(571, 122);
            this.lookupLeaveType.MaximumSize = new System.Drawing.Size(300, 0);
            this.lookupLeaveType.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupLeaveType.Name = "lookupLeaveType";
            this.lookupLeaveType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupLeaveType.Properties.NullText = "Select";
            this.lookupLeaveType.Size = new System.Drawing.Size(298, 22);
            this.lookupLeaveType.StyleController = this.myLayoutControl1;
            this.lookupLeaveType.TabIndex = 17;
            this.lookupLeaveType.Validating += new System.ComponentModel.CancelEventHandler(this.lookupLeaveType_Validating);
            // 
            // cmbReportType
            // 
            this.cmbReportType.EnterMoveNextControl = true;
            this.cmbReportType.Location = new System.Drawing.Point(90, 122);
            this.cmbReportType.MaximumSize = new System.Drawing.Size(400, 0);
            this.cmbReportType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbReportType.Properties.Items.AddRange(new object[] {
            "Attendance Performance",
            "Employee Attendance Performance",
            "Employee Attendance Monthly Summary",
            "Weekend/Holiday/Rest Day Attendance"});
            this.cmbReportType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbReportType.Size = new System.Drawing.Size(399, 22);
            this.cmbReportType.StyleController = this.myLayoutControl1;
            this.cmbReportType.TabIndex = 16;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
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
            this.ucEmployeeFilter1.MaximumSize = new System.Drawing.Size(0, 110);
            this.ucEmployeeFilter1.Name = "ucEmployeeFilter1";
            this.ucEmployeeFilter1.Size = new System.Drawing.Size(1240, 106);
            this.ucEmployeeFilter1.TabIndex = 15;
            this.ucEmployeeFilter1.DesignationIDChanged += new System.EventHandler(this.ucEmployeeFilter1_FilterItemIDChanged);
            this.ucEmployeeFilter1.Validating += new System.ComponentModel.CancelEventHandler(this.ucEmployeeFilter1_Validating);
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(12, 168);
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
            this.btnClearData.Location = new System.Drawing.Point(116, 168);
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
            this.btnExportToExcel.Location = new System.Drawing.Point(220, 168);
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
            this.gridControlData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControlData.Location = new System.Drawing.Point(12, 195);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(1444, 338);
            this.gridControlData.TabIndex = 8;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // gridViewData
            // 
            this.gridViewData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewData.ColumnPanelRowHeight = 50;
            this.gridViewData.DetailHeight = 311;
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.OptionsBehavior.Editable = false;
            this.gridViewData.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewData.OptionsBehavior.ReadOnly = true;
            this.gridViewData.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewData.OptionsFind.AlwaysVisible = true;
            this.gridViewData.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.gridViewData.OptionsFind.ShowCloseButton = false;
            this.gridViewData.OptionsFind.ShowFindButton = false;
            this.gridViewData.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewData.OptionsNavigation.UseTabKey = false;
            this.gridViewData.OptionsPrint.AllowMultilineHeaders = true;
            this.gridViewData.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridViewData.OptionsView.ShowGroupPanel = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem11,
            this.emptySpaceItem1,
            this.layoutControlItem7,
            this.emptySpaceItem3,
            this.layoutControlGroup1,
            this.simpleLabelItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1468, 545);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControlData;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 183);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1448, 342);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.ucEmployeeFilter1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 110);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(1, 1);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1244, 110);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnGetReport;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 156);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(104, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClearData;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(104, 156);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(104, 27);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnExportToExcel;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(208, 156);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(129, 27);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(519, 156);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(725, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtNofRecords;
            this.layoutControlItem7.Location = new System.Drawing.Point(337, 156);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(182, 27);
            this.layoutControlItem7.Text = "Nof. Records";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(75, 16);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(1244, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(204, 183);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.lciLeaveType,
            this.lciEmployee,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 110);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1244, 26);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cmbReportType;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(481, 26);
            this.layoutControlItem1.Text = "Report Type";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 16);
            // 
            // lciLeaveType
            // 
            this.lciLeaveType.Control = this.lookupLeaveType;
            this.lciLeaveType.Location = new System.Drawing.Point(481, 0);
            this.lciLeaveType.Name = "lciLeaveType";
            this.lciLeaveType.Size = new System.Drawing.Size(380, 26);
            this.lciLeaveType.Text = "Leave Type";
            this.lciLeaveType.TextSize = new System.Drawing.Size(75, 16);
            this.lciLeaveType.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lciEmployee
            // 
            this.lciEmployee.Control = this.lookupEmployee;
            this.lciEmployee.Location = new System.Drawing.Point(861, 0);
            this.lciEmployee.Name = "lciEmployee";
            this.lciEmployee.Size = new System.Drawing.Size(373, 26);
            this.lciEmployee.Text = "Employee";
            this.lciEmployee.TextSize = new System.Drawing.Size(75, 16);
            this.lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1234, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 136);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(1244, 20);
            this.simpleLabelItem1.Text = "For Employee Monthly Attendance summary, Date from and To will be treated as Mont" +
    "h from and To.";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(584, 16);
            // 
            // frmRepTimeAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 577);
            this.FirstControl = this.myLayoutControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmRepTimeAttendanceReport";
            this.Text = "Time & Attendance Report";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNofRecords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLeaveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLeaveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
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
        private ucEmployeeFilter ucEmployeeFilter1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Alit.WinformControls.ComboBoxEdit cmbReportType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private Alit.WinformControls.LookUpEdit lookupLeaveType;
        private DevExpress.XtraLayout.LayoutControlItem lciLeaveType;
        private Alit.WinformControls.LookUpEdit lookupEmployee;
        private DevExpress.XtraLayout.LayoutControlItem lciEmployee;
        private Alit.WinformControls.TextEdit txtNofRecords;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
    }
}