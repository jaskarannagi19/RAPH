namespace Vision.WinForm.Reports.Employee
{
    partial class frmRepEmployeeAttendanceDetail
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gvDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAttendanceStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAttendance = new DevExpress.XtraGrid.GridControl();
            this.employeeAttendanceHeaderReportModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvAttendance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeNoPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeTACode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAttendanceDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.dtpDateTo = new Alit.WinformControls.DateEdit();
            this.dtpDateFrom = new Alit.WinformControls.DateEdit();
            this.lookupEmployee = new Alit.WinformControls.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeAttendanceHeaderReportModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelContent.Size = new System.Drawing.Size(1202, 555);
            // 
            // gvDetail
            // 
            this.gvDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAttendanceStatus,
            this.colLogTime});
            this.gvDetail.DetailHeight = 431;
            this.gvDetail.GridControl = this.gcAttendance;
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.OptionsBehavior.ReadOnly = true;
            this.gvDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colAttendanceStatus
            // 
            this.colAttendanceStatus.FieldName = "AttendanceStatus";
            this.colAttendanceStatus.MaxWidth = 292;
            this.colAttendanceStatus.MinWidth = 23;
            this.colAttendanceStatus.Name = "colAttendanceStatus";
            this.colAttendanceStatus.Visible = true;
            this.colAttendanceStatus.VisibleIndex = 0;
            this.colAttendanceStatus.Width = 87;
            // 
            // colLogTime
            // 
            this.colLogTime.DisplayFormat.FormatString = "g";
            this.colLogTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colLogTime.FieldName = "LogTime";
            this.colLogTime.MinWidth = 23;
            this.colLogTime.Name = "colLogTime";
            this.colLogTime.Visible = true;
            this.colLogTime.VisibleIndex = 1;
            this.colLogTime.Width = 87;
            // 
            // gcAttendance
            // 
            this.gcAttendance.DataSource = this.employeeAttendanceHeaderReportModelBindingSource;
            this.gcAttendance.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridLevelNode1.LevelTemplate = this.gvDetail;
            gridLevelNode1.RelationName = "Detail";
            this.gcAttendance.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcAttendance.Location = new System.Drawing.Point(12, 111);
            this.gcAttendance.MainView = this.gvAttendance;
            this.gcAttendance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcAttendance.Name = "gcAttendance";
            this.gcAttendance.Size = new System.Drawing.Size(1172, 426);
            this.gcAttendance.TabIndex = 7;
            this.gcAttendance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAttendance,
            this.gvDetail});
            // 
            // employeeAttendanceHeaderReportModelBindingSource
            // 
            this.employeeAttendanceHeaderReportModelBindingSource.DataSource = typeof(Vision.Model.Reports.Employee.EmployeeAttendanceHeaderReportModel);
            // 
            // gvAttendance
            // 
            this.gvAttendance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeNoPrefix,
            this.colEmployeeNo,
            this.colEmployeeName,
            this.colEmployeeTACode,
            this.colAttendanceDate,
            this.colInTime,
            this.colOutTime});
            this.gvAttendance.DetailHeight = 431;
            this.gvAttendance.GridControl = this.gcAttendance;
            this.gvAttendance.Name = "gvAttendance";
            this.gvAttendance.OptionsBehavior.ReadOnly = true;
            this.gvAttendance.OptionsView.ShowGroupPanel = false;
            // 
            // colEmployeeNoPrefix
            // 
            this.colEmployeeNoPrefix.Caption = "E. Prefix";
            this.colEmployeeNoPrefix.FieldName = "EmployeeNoPrefix";
            this.colEmployeeNoPrefix.MaxWidth = 150;
            this.colEmployeeNoPrefix.MinWidth = 100;
            this.colEmployeeNoPrefix.Name = "colEmployeeNoPrefix";
            this.colEmployeeNoPrefix.Visible = true;
            this.colEmployeeNoPrefix.VisibleIndex = 0;
            this.colEmployeeNoPrefix.Width = 160;
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.Caption = "Emp Code";
            this.colEmployeeNo.FieldName = "EmployeeNo";
            this.colEmployeeNo.MaxWidth = 125;
            this.colEmployeeNo.MinWidth = 75;
            this.colEmployeeNo.Name = "colEmployeeNo";
            this.colEmployeeNo.Visible = true;
            this.colEmployeeNo.VisibleIndex = 1;
            this.colEmployeeNo.Width = 125;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.MinWidth = 23;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 2;
            this.colEmployeeName.Width = 350;
            // 
            // colEmployeeTACode
            // 
            this.colEmployeeTACode.FieldName = "EmployeeTACode";
            this.colEmployeeTACode.MaxWidth = 150;
            this.colEmployeeTACode.MinWidth = 100;
            this.colEmployeeTACode.Name = "colEmployeeTACode";
            this.colEmployeeTACode.Visible = true;
            this.colEmployeeTACode.VisibleIndex = 3;
            this.colEmployeeTACode.Width = 147;
            // 
            // colAttendanceDate
            // 
            this.colAttendanceDate.FieldName = "AttendanceDate";
            this.colAttendanceDate.MaxWidth = 125;
            this.colAttendanceDate.MinWidth = 100;
            this.colAttendanceDate.Name = "colAttendanceDate";
            this.colAttendanceDate.Visible = true;
            this.colAttendanceDate.VisibleIndex = 4;
            this.colAttendanceDate.Width = 123;
            // 
            // colInTime
            // 
            this.colInTime.Caption = "In Time";
            this.colInTime.DisplayFormat.FormatString = "T";
            this.colInTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colInTime.FieldName = "InTimeDisplay";
            this.colInTime.MaxWidth = 125;
            this.colInTime.MinWidth = 100;
            this.colInTime.Name = "colInTime";
            this.colInTime.Visible = true;
            this.colInTime.VisibleIndex = 5;
            this.colInTime.Width = 123;
            // 
            // colOutTime
            // 
            this.colOutTime.Caption = "Out Time";
            this.colOutTime.DisplayFormat.FormatString = "T";
            this.colOutTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOutTime.FieldName = "OutTimeDisplay";
            this.colOutTime.MaxWidth = 125;
            this.colOutTime.MinWidth = 100;
            this.colOutTime.Name = "colOutTime";
            this.colOutTime.Visible = true;
            this.colOutTime.VisibleIndex = 6;
            this.colOutTime.Width = 125;
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.gcAttendance);
            this.myLayoutControl1.Controls.Add(this.dtpDateTo);
            this.myLayoutControl1.Controls.Add(this.dtpDateFrom);
            this.myLayoutControl1.Controls.Add(this.lookupEmployee);
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
            // dtpDateTo
            // 
            this.dtpDateTo.EditValue = null;
            this.dtpDateTo.EnterMoveNextControl = true;
            this.dtpDateTo.Location = new System.Drawing.Point(390, 72);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDateTo.MaximumSize = new System.Drawing.Size(233, 0);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtpDateTo.Size = new System.Drawing.Size(233, 22);
            this.dtpDateTo.StyleController = this.myLayoutControl1;
            this.dtpDateTo.TabIndex = 6;
            this.dtpDateTo.EditValueChanged += new System.EventHandler(this.dtpDateTo_EditValueChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.EditValue = null;
            this.dtpDateFrom.EnterMoveNextControl = true;
            this.dtpDateFrom.Location = new System.Drawing.Point(89, 72);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDateFrom.MaximumSize = new System.Drawing.Size(233, 0);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtpDateFrom.Size = new System.Drawing.Size(233, 22);
            this.dtpDateFrom.StyleController = this.myLayoutControl1;
            this.dtpDateFrom.TabIndex = 5;
            this.dtpDateFrom.EditValueChanged += new System.EventHandler(this.dtpDateFrom_EditValueChanged);
            // 
            // lookupEmployee
            // 
            this.lookupEmployee.EnterMoveNextControl = true;
            this.lookupEmployee.Location = new System.Drawing.Point(89, 46);
            this.lookupEmployee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookupEmployee.Name = "lookupEmployee";
            this.lookupEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmployee.Properties.NullText = "Select";
            this.lookupEmployee.Size = new System.Drawing.Size(1082, 22);
            this.lookupEmployee.StyleController = this.myLayoutControl1;
            this.lookupEmployee.TabIndex = 4;
            this.lookupEmployee.EditValueChanged += new System.EventHandler(this.lookupEmployee_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1196, 549);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gcAttendance;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 99);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1176, 430);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1176, 99);
            this.layoutControlGroup2.Text = "Filter";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookupEmployee;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1150, 26);
            this.layoutControlItem1.Text = "Employee";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtpDateFrom;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(301, 26);
            this.layoutControlItem2.Text = "Date From";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtpDateTo;
            this.layoutControlItem3.Location = new System.Drawing.Point(301, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(301, 26);
            this.layoutControlItem3.Text = "Date To";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(61, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(602, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(548, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmRepEmployeeAttendanceDetail
            // 
            this.AllowSave = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 581);
            this.FirstControl = this.myLayoutControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmRepEmployeeAttendanceDetail";
            this.Text = "Employee Attendance Detail";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeAttendanceHeaderReportModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gcAttendance;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAttendance;
        private Alit.WinformControls.DateEdit dtpDateTo;
        private Alit.WinformControls.DateEdit dtpDateFrom;
        private Alit.WinformControls.LookUpEdit lookupEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource employeeAttendanceHeaderReportModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeTACode;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOutTime;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colAttendanceStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colLogTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNo;
    }
}