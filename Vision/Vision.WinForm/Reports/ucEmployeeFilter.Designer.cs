namespace Vision.WinForm.Reports
{
    partial class ucEmployeeFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.lookupDesignation = new Alit.WinformControls.LookUpEdit();
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.lookupLocation = new Alit.WinformControls.LookUpEdit();
            this.lookupDepartment = new Alit.WinformControls.LookUpEdit();
            this.cmbEmployementType = new Alit.WinformControls.ComboBoxEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgDateFromTo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.ErrorProvider = new Alit.WinformControls.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDesignation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployementType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDateFromTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.lookupDesignation);
            this.myLayoutControl1.Controls.Add(this.deDateFrom);
            this.myLayoutControl1.Controls.Add(this.deDateTo);
            this.myLayoutControl1.Controls.Add(this.lookupLocation);
            this.myLayoutControl1.Controls.Add(this.lookupDepartment);
            this.myLayoutControl1.Controls.Add(this.cmbEmployementType);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1153, 103);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // lookupDesignation
            // 
            this.lookupDesignation.EnterMoveNextControl = true;
            this.lookupDesignation.Location = new System.Drawing.Point(297, 32);
            this.lookupDesignation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lookupDesignation.MaximumSize = new System.Drawing.Size(300, 0);
            this.lookupDesignation.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupDesignation.Name = "lookupDesignation";
            this.lookupDesignation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupDesignation.Properties.NullText = "Select";
            this.lookupDesignation.Size = new System.Drawing.Size(300, 22);
            this.lookupDesignation.StyleController = this.myLayoutControl1;
            this.lookupDesignation.TabIndex = 11;
            this.lookupDesignation.EditValueChanged += new System.EventHandler(this.lookupDesignation_EditValueChanged);
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(75, 32);
            this.deDateFrom.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateFrom.MinimumSize = new System.Drawing.Size(100, 0);
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateFrom.Size = new System.Drawing.Size(125, 22);
            this.deDateFrom.StyleController = this.myLayoutControl1;
            this.deDateFrom.TabIndex = 4;
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(75, 58);
            this.deDateTo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.deDateTo.MaximumSize = new System.Drawing.Size(125, 0);
            this.deDateTo.MinimumSize = new System.Drawing.Size(100, 0);
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateTo.Size = new System.Drawing.Size(125, 22);
            this.deDateTo.StyleController = this.myLayoutControl1;
            this.deDateTo.TabIndex = 5;
            // 
            // lookupLocation
            // 
            this.lookupLocation.EnterMoveNextControl = true;
            this.lookupLocation.Location = new System.Drawing.Point(299, 58);
            this.lookupLocation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lookupLocation.MaximumSize = new System.Drawing.Size(300, 0);
            this.lookupLocation.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupLocation.Name = "lookupLocation";
            this.lookupLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupLocation.Properties.NullText = "Select";
            this.lookupLocation.Size = new System.Drawing.Size(298, 22);
            this.lookupLocation.StyleController = this.myLayoutControl1;
            this.lookupLocation.TabIndex = 12;
            this.lookupLocation.EditValueChanged += new System.EventHandler(this.lookupLocation_EditValueChanged);
            // 
            // lookupDepartment
            // 
            this.lookupDepartment.EnterMoveNextControl = true;
            this.lookupDepartment.Location = new System.Drawing.Point(741, 32);
            this.lookupDepartment.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lookupDepartment.MaximumSize = new System.Drawing.Size(311, 0);
            this.lookupDepartment.MinimumSize = new System.Drawing.Size(117, 0);
            this.lookupDepartment.Name = "lookupDepartment";
            this.lookupDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupDepartment.Properties.NullText = "Select";
            this.lookupDepartment.Size = new System.Drawing.Size(311, 22);
            this.lookupDepartment.StyleController = this.myLayoutControl1;
            this.lookupDepartment.TabIndex = 10;
            this.lookupDepartment.EditValueChanged += new System.EventHandler(this.lookupDepartment_EditValueChanged);
            // 
            // cmbEmployementType
            // 
            this.cmbEmployementType.EnterMoveNextControl = true;
            this.cmbEmployementType.Location = new System.Drawing.Point(741, 58);
            this.cmbEmployementType.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbEmployementType.MaximumSize = new System.Drawing.Size(311, 0);
            this.cmbEmployementType.MinimumSize = new System.Drawing.Size(117, 0);
            this.cmbEmployementType.Name = "cmbEmployementType";
            this.cmbEmployementType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEmployementType.Properties.Items.AddRange(new object[] {
            "All",
            "Casual",
            "Contract",
            "Permanet",
            "Contract & Permanent"});
            this.cmbEmployementType.Properties.NullText = "Select";
            this.cmbEmployementType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEmployementType.Size = new System.Drawing.Size(311, 22);
            this.cmbEmployementType.StyleController = this.myLayoutControl1;
            this.cmbEmployementType.TabIndex = 13;
            this.cmbEmployementType.SelectedIndexChanged += new System.EventHandler(this.cmbEmployementType_SelectedIndexChanged);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(1153, 103);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Filter";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.lcgDateFromTo,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1153, 91);
            this.layoutControlGroup2.Text = "Filter";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lookupDepartment;
            this.layoutControlItem7.CustomizationFormText = "Department";
            this.layoutControlItem7.Location = new System.Drawing.Point(590, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(545, 26);
            this.layoutControlItem7.Text = "Department";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(135, 16);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lookupDesignation;
            this.layoutControlItem8.CustomizationFormText = "Designation";
            this.layoutControlItem8.Location = new System.Drawing.Point(193, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(397, 26);
            this.layoutControlItem8.Text = "Designation";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(90, 16);
            this.layoutControlItem8.TextToControlDistance = 3;
            // 
            // lcgDateFromTo
            // 
            this.lcgDateFromTo.GroupBordersVisible = false;
            this.lcgDateFromTo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.lcgDateFromTo.Location = new System.Drawing.Point(0, 0);
            this.lcgDateFromTo.Name = "lcgDateFromTo";
            this.lcgDateFromTo.Size = new System.Drawing.Size(193, 52);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.deDateFrom;
            this.layoutControlItem1.CustomizationFormText = "Date From";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(193, 26);
            this.layoutControlItem1.Text = "Date From";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(61, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deDateTo;
            this.layoutControlItem2.CustomizationFormText = "Date To";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(193, 26);
            this.layoutControlItem2.Text = "Date To";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 16);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lookupLocation;
            this.layoutControlItem9.CustomizationFormText = "Location";
            this.layoutControlItem9.Location = new System.Drawing.Point(193, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(397, 26);
            this.layoutControlItem9.Text = "Location";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(90, 16);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.cmbEmployementType;
            this.layoutControlItem10.CustomizationFormText = "Employement Type";
            this.layoutControlItem10.Location = new System.Drawing.Point(590, 26);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(545, 26);
            this.layoutControlItem10.Text = "Employment Type";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(135, 16);
            this.layoutControlItem10.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 91);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1153, 12);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // ucEmployeeFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.myLayoutControl1);
            this.Name = "ucEmployeeFilter";
            this.Size = new System.Drawing.Size(1153, 103);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookupDesignation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployementType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDateFromTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.LookUpEdit lookupDesignation;
        private Alit.WinformControls.DateEdit deDateFrom;
        private Alit.WinformControls.DateEdit deDateTo;
        private Alit.WinformControls.LookUpEdit lookupLocation;
        private Alit.WinformControls.LookUpEdit lookupDepartment;
        private Alit.WinformControls.ComboBoxEdit cmbEmployementType;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDateFromTo;
        private Alit.WinformControls.ErrorProvider ErrorProvider;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}
