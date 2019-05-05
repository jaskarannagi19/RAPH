namespace Vision.WinForm.Employee
{
    partial class frmEmployeeShiftAllocation
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
            this.gridControlEmployee = new DevExpress.XtraGrid.GridControl();
            this.employeeShiftAllocationViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewEmployee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeNoPrefix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesignation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployementType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastShiftName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastShiftWED = new DevExpress.XtraGrid.Columns.GridColumn();
            this.deWEDateFrom = new Alit.WinformControls.DateEdit();
            this.lookupShift = new Alit.WinformControls.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeShiftAllocationViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Size = new System.Drawing.Size(1388, 498);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.gridControlEmployee);
            this.myLayoutControl1.Controls.Add(this.deWEDateFrom);
            this.myLayoutControl1.Controls.Add(this.lookupShift);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1382, 492);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // gridControlEmployee
            // 
            this.gridControlEmployee.DataSource = this.employeeShiftAllocationViewModelBindingSource;
            this.gridControlEmployee.Location = new System.Drawing.Point(12, 64);
            this.gridControlEmployee.MainView = this.gridViewEmployee;
            this.gridControlEmployee.Name = "gridControlEmployee";
            this.gridControlEmployee.Size = new System.Drawing.Size(1358, 416);
            this.gridControlEmployee.TabIndex = 7;
            this.gridControlEmployee.TabStop = false;
            this.gridControlEmployee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewEmployee});
            // 
            // employeeShiftAllocationViewModelBindingSource
            // 
            this.employeeShiftAllocationViewModelBindingSource.DataSource = typeof(Vision.Model.Employee.EmployeeShiftAllocationViewModel);
            // 
            // gridViewEmployee
            // 
            this.gridViewEmployee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeNoPrefix,
            this.colEmployeeNo,
            this.colEmployeeName,
            this.colGender,
            this.colDepartment,
            this.colDesignation,
            this.colLocation,
            this.colEmployementType,
            this.colLastShiftName,
            this.colLastShiftWED});
            this.gridViewEmployee.GridControl = this.gridControlEmployee;
            this.gridViewEmployee.Name = "gridViewEmployee";
            this.gridViewEmployee.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridViewEmployee.OptionsSelection.CheckBoxSelectorField = "Selected";
            this.gridViewEmployee.OptionsSelection.MultiSelect = true;
            this.gridViewEmployee.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewEmployee.OptionsView.ShowGroupPanel = false;
            this.gridViewEmployee.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewShiftAllocationHistory_CellValueChanged);
            // 
            // colEmployeeNoPrefix
            // 
            this.colEmployeeNoPrefix.FieldName = "EmployeeNoPrefix";
            this.colEmployeeNoPrefix.MaxWidth = 100;
            this.colEmployeeNoPrefix.MinWidth = 75;
            this.colEmployeeNoPrefix.Name = "colEmployeeNoPrefix";
            this.colEmployeeNoPrefix.OptionsColumn.AllowEdit = false;
            this.colEmployeeNoPrefix.OptionsColumn.ReadOnly = true;
            this.colEmployeeNoPrefix.Visible = true;
            this.colEmployeeNoPrefix.VisibleIndex = 1;
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.FieldName = "EmployeeNo";
            this.colEmployeeNo.MaxWidth = 100;
            this.colEmployeeNo.MinWidth = 75;
            this.colEmployeeNo.Name = "colEmployeeNo";
            this.colEmployeeNo.OptionsColumn.AllowEdit = false;
            this.colEmployeeNo.OptionsColumn.ReadOnly = true;
            this.colEmployeeNo.Visible = true;
            this.colEmployeeNo.VisibleIndex = 2;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.OptionsColumn.ReadOnly = true;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 3;
            this.colEmployeeName.Width = 559;
            // 
            // colGender
            // 
            this.colGender.FieldName = "Gender";
            this.colGender.MaxWidth = 100;
            this.colGender.MinWidth = 75;
            this.colGender.Name = "colGender";
            this.colGender.OptionsColumn.AllowEdit = false;
            this.colGender.OptionsColumn.ReadOnly = true;
            this.colGender.Visible = true;
            this.colGender.VisibleIndex = 4;
            // 
            // colDepartment
            // 
            this.colDepartment.FieldName = "Department";
            this.colDepartment.MaxWidth = 200;
            this.colDepartment.MinWidth = 100;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsColumn.AllowEdit = false;
            this.colDepartment.OptionsColumn.ReadOnly = true;
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 5;
            this.colDepartment.Width = 100;
            // 
            // colDesignation
            // 
            this.colDesignation.FieldName = "Designation";
            this.colDesignation.MaxWidth = 200;
            this.colDesignation.MinWidth = 100;
            this.colDesignation.Name = "colDesignation";
            this.colDesignation.OptionsColumn.AllowEdit = false;
            this.colDesignation.OptionsColumn.ReadOnly = true;
            this.colDesignation.Visible = true;
            this.colDesignation.VisibleIndex = 6;
            this.colDesignation.Width = 100;
            // 
            // colLocation
            // 
            this.colLocation.FieldName = "Location";
            this.colLocation.MaxWidth = 200;
            this.colLocation.MinWidth = 100;
            this.colLocation.Name = "colLocation";
            this.colLocation.OptionsColumn.AllowEdit = false;
            this.colLocation.OptionsColumn.ReadOnly = true;
            this.colLocation.Visible = true;
            this.colLocation.VisibleIndex = 7;
            this.colLocation.Width = 100;
            // 
            // colEmployementType
            // 
            this.colEmployementType.FieldName = "EmployementType";
            this.colEmployementType.MaxWidth = 200;
            this.colEmployementType.MinWidth = 75;
            this.colEmployementType.Name = "colEmployementType";
            this.colEmployementType.OptionsColumn.AllowEdit = false;
            this.colEmployementType.OptionsColumn.ReadOnly = true;
            this.colEmployementType.Visible = true;
            this.colEmployementType.VisibleIndex = 8;
            // 
            // colLastShiftName
            // 
            this.colLastShiftName.FieldName = "LastShiftName";
            this.colLastShiftName.MaxWidth = 300;
            this.colLastShiftName.MinWidth = 75;
            this.colLastShiftName.Name = "colLastShiftName";
            this.colLastShiftName.OptionsColumn.AllowEdit = false;
            this.colLastShiftName.OptionsColumn.ReadOnly = true;
            this.colLastShiftName.Visible = true;
            this.colLastShiftName.VisibleIndex = 9;
            this.colLastShiftName.Width = 175;
            // 
            // colLastShiftWED
            // 
            this.colLastShiftWED.FieldName = "LastShiftWED";
            this.colLastShiftWED.MaxWidth = 100;
            this.colLastShiftWED.MinWidth = 75;
            this.colLastShiftWED.Name = "colLastShiftWED";
            this.colLastShiftWED.OptionsColumn.AllowEdit = false;
            this.colLastShiftWED.OptionsColumn.ReadOnly = true;
            this.colLastShiftWED.Visible = true;
            this.colLastShiftWED.VisibleIndex = 10;
            this.colLastShiftWED.Width = 100;
            // 
            // deWEDateFrom
            // 
            this.deWEDateFrom.EditValue = null;
            this.deWEDateFrom.EnterMoveNextControl = true;
            this.deWEDateFrom.Location = new System.Drawing.Point(127, 12);
            this.deWEDateFrom.MaximumSize = new System.Drawing.Size(125, 0);
            this.deWEDateFrom.MinimumSize = new System.Drawing.Size(100, 0);
            this.deWEDateFrom.Name = "deWEDateFrom";
            this.deWEDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWEDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deWEDateFrom.Size = new System.Drawing.Size(100, 22);
            this.deWEDateFrom.StyleController = this.myLayoutControl1;
            this.deWEDateFrom.TabIndex = 6;
            // 
            // lookupShift
            // 
            this.lookupShift.EnterMoveNextControl = true;
            this.lookupShift.Location = new System.Drawing.Point(127, 38);
            this.lookupShift.MaximumSize = new System.Drawing.Size(500, 0);
            this.lookupShift.Name = "lookupShift";
            this.lookupShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupShift.Properties.NullText = "Select";
            this.lookupShift.Size = new System.Drawing.Size(500, 22);
            this.lookupShift.StyleController = this.myLayoutControl1;
            this.lookupShift.TabIndex = 5;
            this.lookupShift.Validating += new System.ComponentModel.CancelEventHandler(this.lookupShift_Validating);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.emptySpaceItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1382, 492);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lookupShift;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(619, 26);
            this.layoutControlItem2.Text = "Shift";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(112, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.deWEDateFrom;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(219, 26);
            this.layoutControlItem3.Text = "Shift Effective From";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(112, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControlEmployee;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1362, 420);
            this.layoutControlItem4.Text = " ";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(219, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(400, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(619, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(743, 52);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmEmployeeShiftAllocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 524);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmEmployeeShiftAllocation";
            this.Text = "Employee Shift Allocation";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeShiftAllocationViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWEDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.DateEdit deWEDateFrom;
        private Alit.WinformControls.LookUpEdit lookupShift;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gridControlEmployee;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private System.Windows.Forms.BindingSource employeeShiftAllocationViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colGender;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colDesignation;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployementType;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNoPrefix;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNo;
        private DevExpress.XtraGrid.Columns.GridColumn colLastShiftName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastShiftWED;
    }
}