namespace Vision.WinForm.Payroll
{
    partial class frmEmployeeRestDay
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.gridControlEmployee = new DevExpress.XtraGrid.GridControl();
            this.employeeRestDayViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeNoPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colTuesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWednesday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThursday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFriday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaturday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSunday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRestDayViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            this.panelContent.Size = new System.Drawing.Size(906, 508);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.deDateTo);
            this.layoutControl1.Controls.Add(this.deDateFrom);
            this.layoutControl1.Controls.Add(this.gridControlEmployee);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(902, 504);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(244, 12);
            this.deDateTo.MaximumSize = new System.Drawing.Size(150, 0);
            this.deDateTo.MinimumSize = new System.Drawing.Size(100, 0);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateTo.Size = new System.Drawing.Size(100, 22);
            this.deDateTo.StyleController = this.layoutControl1;
            this.deDateTo.TabIndex = 10;
            this.deDateTo.EditValueChanged += new System.EventHandler(this.deDateTo_EditValueChanged);
            this.deDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.deDateTo_Validating);
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(76, 12);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(150, 0);
            this.deDateFrom.MinimumSize = new System.Drawing.Size(100, 0);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateFrom.Size = new System.Drawing.Size(100, 22);
            this.deDateFrom.StyleController = this.layoutControl1;
            this.deDateFrom.TabIndex = 9;
            this.deDateFrom.EditValueChanged += new System.EventHandler(this.deDateFrom_EditValueChanged);
            // 
            // gridControlEmployee
            // 
            this.gridControlEmployee.DataSource = this.employeeRestDayViewModelBindingSource;
            this.gridControlEmployee.Location = new System.Drawing.Point(12, 38);
            this.gridControlEmployee.MainView = this.gridViewEmployee;
            this.gridControlEmployee.Name = "gridControlEmployee";
            this.gridControlEmployee.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlEmployee.Size = new System.Drawing.Size(878, 454);
            this.gridControlEmployee.TabIndex = 8;
            this.gridControlEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmployee});
            // 
            // employeeRestDayViewModelBindingSource
            // 
            this.employeeRestDayViewModelBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeeRestDayViewModel);
            // 
            // gridViewEmployee
            // 
            this.gridViewEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeNoPrefix,
            this.colEmployeeNo,
            this.colEmployeeName,
            this.colMonday,
            this.colTuesday,
            this.colWednesday,
            this.colThursday,
            this.colFriday,
            this.colSaturday,
            this.colSunday});
            this.gridViewEmployee.GridControl = this.gridControlEmployee;
            this.gridViewEmployee.Name = "gridViewEmployee";
            this.gridViewEmployee.OptionsFind.AlwaysVisible = true;
            this.gridViewEmployee.OptionsView.ShowAutoFilterRow = true;
            this.gridViewEmployee.OptionsView.ShowGroupPanel = false;
            this.gridViewEmployee.RowHeight = 30;
            // 
            // colEmployeeNoPrefix
            // 
            this.colEmployeeNoPrefix.FieldName = "EmployeeNoPrefix";
            this.colEmployeeNoPrefix.Name = "colEmployeeNoPrefix";
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colEmployeeNo.AppearanceCell.Options.UseBackColor = true;
            this.colEmployeeNo.FieldName = "EmployeeNo";
            this.colEmployeeNo.MaxWidth = 100;
            this.colEmployeeNo.MinWidth = 75;
            this.colEmployeeNo.Name = "colEmployeeNo";
            this.colEmployeeNo.OptionsColumn.AllowEdit = false;
            this.colEmployeeNo.OptionsColumn.ReadOnly = true;
            this.colEmployeeNo.OptionsColumn.TabStop = false;
            this.colEmployeeNo.Visible = true;
            this.colEmployeeNo.VisibleIndex = 0;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colEmployeeName.AppearanceCell.Options.UseBackColor = true;
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.MinWidth = 100;
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.OptionsColumn.ReadOnly = true;
            this.colEmployeeName.OptionsColumn.TabStop = false;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            this.colEmployeeName.Width = 121;
            // 
            // colMonday
            // 
            this.colMonday.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonday.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colMonday.FieldName = "Monday";
            this.colMonday.MaxWidth = 100;
            this.colMonday.MinWidth = 50;
            this.colMonday.Name = "colMonday";
            this.colMonday.Visible = true;
            this.colMonday.VisibleIndex = 2;
            this.colMonday.Width = 90;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit1_EditValueChanged);
            // 
            // colTuesday
            // 
            this.colTuesday.AppearanceHeader.Options.UseTextOptions = true;
            this.colTuesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTuesday.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colTuesday.FieldName = "Tuesday";
            this.colTuesday.MaxWidth = 100;
            this.colTuesday.MinWidth = 50;
            this.colTuesday.Name = "colTuesday";
            this.colTuesday.Visible = true;
            this.colTuesday.VisibleIndex = 3;
            this.colTuesday.Width = 90;
            // 
            // colWednesday
            // 
            this.colWednesday.AppearanceHeader.Options.UseTextOptions = true;
            this.colWednesday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWednesday.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colWednesday.FieldName = "Wednesday";
            this.colWednesday.MaxWidth = 100;
            this.colWednesday.MinWidth = 50;
            this.colWednesday.Name = "colWednesday";
            this.colWednesday.Visible = true;
            this.colWednesday.VisibleIndex = 4;
            this.colWednesday.Width = 90;
            // 
            // colThursday
            // 
            this.colThursday.AppearanceHeader.Options.UseTextOptions = true;
            this.colThursday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThursday.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colThursday.FieldName = "Thursday";
            this.colThursday.MaxWidth = 100;
            this.colThursday.MinWidth = 50;
            this.colThursday.Name = "colThursday";
            this.colThursday.Visible = true;
            this.colThursday.VisibleIndex = 5;
            this.colThursday.Width = 91;
            // 
            // colFriday
            // 
            this.colFriday.AppearanceHeader.Options.UseTextOptions = true;
            this.colFriday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFriday.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colFriday.FieldName = "Friday";
            this.colFriday.MaxWidth = 100;
            this.colFriday.MinWidth = 50;
            this.colFriday.Name = "colFriday";
            this.colFriday.Visible = true;
            this.colFriday.VisibleIndex = 6;
            this.colFriday.Width = 100;
            // 
            // colSaturday
            // 
            this.colSaturday.AppearanceHeader.Options.UseTextOptions = true;
            this.colSaturday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSaturday.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSaturday.FieldName = "Saturday";
            this.colSaturday.MaxWidth = 100;
            this.colSaturday.MinWidth = 50;
            this.colSaturday.Name = "colSaturday";
            this.colSaturday.Visible = true;
            this.colSaturday.VisibleIndex = 7;
            this.colSaturday.Width = 100;
            // 
            // colSunday
            // 
            this.colSunday.AppearanceHeader.Options.UseTextOptions = true;
            this.colSunday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSunday.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colSunday.FieldName = "Sunday";
            this.colSunday.MaxWidth = 100;
            this.colSunday.MinWidth = 50;
            this.colSunday.Name = "colSunday";
            this.colSunday.Visible = true;
            this.colSunday.VisibleIndex = 8;
            this.colSunday.Width = 100;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(902, 504);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(336, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(546, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControlEmployee;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(882, 458);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.Location = new System.Drawing.Point(168, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(168, 26);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 16);
            // 
            // frmEmployeeRestDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 535);
            this.FirstControl = this.layoutControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "frmEmployeeRestDay";
            this.Text = "Employee Rest Day";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRestDayViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl gridControlEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource employeeRestDayViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colMonday;
        private DevExpress.XtraGrid.Columns.GridColumn colTuesday;
        private DevExpress.XtraGrid.Columns.GridColumn colWednesday;
        private DevExpress.XtraGrid.Columns.GridColumn colThursday;
        private DevExpress.XtraGrid.Columns.GridColumn colFriday;
        private DevExpress.XtraGrid.Columns.GridColumn colSaturday;
        private DevExpress.XtraGrid.Columns.GridColumn colSunday;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private Alit.WinformControls.DateEdit deDateTo;
        private Alit.WinformControls.DateEdit deDateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}