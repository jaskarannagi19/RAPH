namespace Vision.WinForm.Employee
{
    partial class frmEmployeeWIBAClassRate
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
            this.gridControlRate = new DevExpress.XtraGrid.GridControl();
            this.employeeWIBAClassRateViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewRate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeWIBAClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWEDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deWEDate = new Alit.WinformControls.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeWIBAClassRateViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(838, 526);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.gridControlRate);
            this.myLayoutControl1.Controls.Add(this.deWEDate);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(834, 522);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // gridControlRate
            // 
            this.gridControlRate.DataSource = this.employeeWIBAClassRateViewModelBindingSource;
            this.gridControlRate.Location = new System.Drawing.Point(12, 38);
            this.gridControlRate.MainView = this.gridViewRate;
            this.gridControlRate.Name = "gridControlRate";
            this.gridControlRate.Size = new System.Drawing.Size(810, 472);
            this.gridControlRate.TabIndex = 6;
            this.gridControlRate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRate});
            // 
            // employeeWIBAClassRateViewModelBindingSource
            // 
            this.employeeWIBAClassRateViewModelBindingSource.DataSource = typeof(Vision.Model.Employee.EmployeeWIBAClassRateViewModel);
            // 
            // gridViewRate
            // 
            this.gridViewRate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeWIBAClassName,
            this.colRate,
            this.colWEDate});
            this.gridViewRate.GridControl = this.gridControlRate;
            this.gridViewRate.Name = "gridViewRate";
            this.gridViewRate.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewRate.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewRate.OptionsNavigation.UseTabKey = false;
            this.gridViewRate.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridViewRate.OptionsSelection.CheckBoxSelectorField = "Selected";
            this.gridViewRate.OptionsSelection.MultiSelect = true;
            this.gridViewRate.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewRate.OptionsView.ShowGroupPanel = false;
            this.gridViewRate.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewRate_CellValueChanged);
            // 
            // colEmployeeWIBAClassName
            // 
            this.colEmployeeWIBAClassName.FieldName = "EmployeeWIBAClassName";
            this.colEmployeeWIBAClassName.MaxWidth = 500;
            this.colEmployeeWIBAClassName.MinWidth = 100;
            this.colEmployeeWIBAClassName.Name = "colEmployeeWIBAClassName";
            this.colEmployeeWIBAClassName.OptionsColumn.ReadOnly = true;
            this.colEmployeeWIBAClassName.OptionsColumn.TabStop = false;
            this.colEmployeeWIBAClassName.Visible = true;
            this.colEmployeeWIBAClassName.VisibleIndex = 3;
            this.colEmployeeWIBAClassName.Width = 100;
            // 
            // colRate
            // 
            this.colRate.DisplayFormat.FormatString = "n2";
            this.colRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRate.FieldName = "Rate";
            this.colRate.MaxWidth = 150;
            this.colRate.MinWidth = 100;
            this.colRate.Name = "colRate";
            this.colRate.Visible = true;
            this.colRate.VisibleIndex = 1;
            this.colRate.Width = 100;
            // 
            // colWEDate
            // 
            this.colWEDate.FieldName = "WEDate";
            this.colWEDate.MaxWidth = 150;
            this.colWEDate.MinWidth = 100;
            this.colWEDate.Name = "colWEDate";
            this.colWEDate.OptionsColumn.ReadOnly = true;
            this.colWEDate.OptionsColumn.TabStop = false;
            this.colWEDate.Visible = true;
            this.colWEDate.VisibleIndex = 2;
            this.colWEDate.Width = 100;
            // 
            // deWEDate
            // 
            this.deWEDate.EditValue = null;
            this.deWEDate.EnterMoveNextControl = true;
            this.deWEDate.Location = new System.Drawing.Point(110, 12);
            this.deWEDate.MaximumSize = new System.Drawing.Size(150, 0);
            this.deWEDate.MinimumSize = new System.Drawing.Size(75, 0);
            this.deWEDate.Name = "deWEDate";
            this.deWEDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deWEDate.Size = new System.Drawing.Size(150, 22);
            this.deWEDate.StyleController = this.myLayoutControl1;
            this.deWEDate.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(834, 522);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deWEDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(252, 26);
            this.layoutControlItem2.Text = "With Effect Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(95, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(252, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(562, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlRate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(814, 476);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmEmployeeWIBAClassRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 553);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmEmployeeWIBAClassRate";
            this.Text = "Employee WIBA Class Rate";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeWIBAClassRateViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private Alit.WinformControls.DateEdit deWEDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl gridControlRate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource employeeWIBAClassRateViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeWIBAClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colWEDate;
    }
}