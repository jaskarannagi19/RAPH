namespace Vision.WinForm.Payroll
{
    partial class frmHoliday
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
            this.cmbRepeatOnSameDate = new Alit.WinformControls.ComboBoxEdit();
            this.txtRemarks = new Alit.WinformControls.TextEdit();
            this.txtNofDays = new Alit.WinformControls.TextEdit();
            this.deDateTo = new Alit.WinformControls.DateEdit();
            this.deDateFrom = new Alit.WinformControls.DateEdit();
            this.cmbHolidayType = new Alit.WinformControls.ComboBoxEdit();
            this.txtHolidayName = new Alit.WinformControls.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRepeatOnSameDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNofDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHolidayType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHolidayName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Location = new System.Drawing.Point(11, 13);
            this.panelContent.MaximumSize = new System.Drawing.Size(775, 150);
            this.panelContent.Size = new System.Drawing.Size(756, 150);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.cmbRepeatOnSameDate);
            this.myLayoutControl1.Controls.Add(this.txtRemarks);
            this.myLayoutControl1.Controls.Add(this.txtNofDays);
            this.myLayoutControl1.Controls.Add(this.deDateTo);
            this.myLayoutControl1.Controls.Add(this.deDateFrom);
            this.myLayoutControl1.Controls.Add(this.cmbHolidayType);
            this.myLayoutControl1.Controls.Add(this.txtHolidayName);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(750, 144);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // cmbRepeatOnSameDate
            // 
            this.cmbRepeatOnSameDate.EnterMoveNextControl = true;
            this.cmbRepeatOnSameDate.Location = new System.Drawing.Point(442, 38);
            this.cmbRepeatOnSameDate.MaximumSize = new System.Drawing.Size(150, 0);
            this.cmbRepeatOnSameDate.MenuManager = this.barManager1;
            this.cmbRepeatOnSameDate.Name = "cmbRepeatOnSameDate";
            this.cmbRepeatOnSameDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRepeatOnSameDate.Properties.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbRepeatOnSameDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbRepeatOnSameDate.Size = new System.Drawing.Size(150, 22);
            this.cmbRepeatOnSameDate.StyleController = this.myLayoutControl1;
            this.cmbRepeatOnSameDate.TabIndex = 10;
            this.cmbRepeatOnSameDate.Validating += new System.ComponentModel.CancelEventHandler(this.cmbRepeatOnSameDate_Validating);
            // 
            // txtRemarks
            // 
            this.txtRemarks.EnterMoveNextControl = true;
            this.txtRemarks.Location = new System.Drawing.Point(150, 90);
            this.txtRemarks.MaximumSize = new System.Drawing.Size(1000, 0);
            this.txtRemarks.MenuManager = this.barManager1;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Properties.MaxLength = 100;
            this.txtRemarks.Size = new System.Drawing.Size(588, 22);
            this.txtRemarks.StyleController = this.myLayoutControl1;
            this.txtRemarks.TabIndex = 9;
            // 
            // txtNofDays
            // 
            this.txtNofDays.Enabled = false;
            this.txtNofDays.EnterMoveNextControl = true;
            this.txtNofDays.Location = new System.Drawing.Point(566, 64);
            this.txtNofDays.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtNofDays.MenuManager = this.barManager1;
            this.txtNofDays.Name = "txtNofDays";
            this.txtNofDays.Size = new System.Drawing.Size(150, 22);
            this.txtNofDays.StyleController = this.myLayoutControl1;
            this.txtNofDays.TabIndex = 8;
            // 
            // deDateTo
            // 
            this.deDateTo.EditValue = null;
            this.deDateTo.EnterMoveNextControl = true;
            this.deDateTo.Location = new System.Drawing.Point(354, 64);
            this.deDateTo.MaximumSize = new System.Drawing.Size(150, 0);
            this.deDateTo.MenuManager = this.barManager1;
            this.deDateTo.Name = "deDateTo";
            this.deDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateTo.Size = new System.Drawing.Size(150, 22);
            this.deDateTo.StyleController = this.myLayoutControl1;
            this.deDateTo.TabIndex = 7;
            this.deDateTo.EditValueChanged += new System.EventHandler(this.deDateTo_EditValueChanged);
            this.deDateTo.Validating += new System.ComponentModel.CancelEventHandler(this.deDateTo_Validating);
            // 
            // deDateFrom
            // 
            this.deDateFrom.EditValue = null;
            this.deDateFrom.EnterMoveNextControl = true;
            this.deDateFrom.Location = new System.Drawing.Point(150, 64);
            this.deDateFrom.MaximumSize = new System.Drawing.Size(150, 0);
            this.deDateFrom.MenuManager = this.barManager1;
            this.deDateFrom.Name = "deDateFrom";
            this.deDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deDateFrom.Size = new System.Drawing.Size(150, 22);
            this.deDateFrom.StyleController = this.myLayoutControl1;
            this.deDateFrom.TabIndex = 6;
            this.deDateFrom.EditValueChanged += new System.EventHandler(this.deDateFrom_EditValueChanged);
            this.deDateFrom.Validating += new System.ComponentModel.CancelEventHandler(this.deDateFrom_Validating);
            // 
            // cmbHolidayType
            // 
            this.cmbHolidayType.EnterMoveNextControl = true;
            this.cmbHolidayType.Location = new System.Drawing.Point(150, 38);
            this.cmbHolidayType.MaximumSize = new System.Drawing.Size(150, 0);
            this.cmbHolidayType.MenuManager = this.barManager1;
            this.cmbHolidayType.Name = "cmbHolidayType";
            this.cmbHolidayType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbHolidayType.Properties.Items.AddRange(new object[] {
            "Public Holiday",
            "Optional Holiday"});
            this.cmbHolidayType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbHolidayType.Size = new System.Drawing.Size(150, 22);
            this.cmbHolidayType.StyleController = this.myLayoutControl1;
            this.cmbHolidayType.TabIndex = 5;
            this.cmbHolidayType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbHolidayType_Validating);
            // 
            // txtHolidayName
            // 
            this.txtHolidayName.EnterMoveNextControl = true;
            this.txtHolidayName.Location = new System.Drawing.Point(150, 12);
            this.txtHolidayName.MaximumSize = new System.Drawing.Size(500, 0);
            this.txtHolidayName.MenuManager = this.barManager1;
            this.txtHolidayName.Name = "txtHolidayName";
            this.txtHolidayName.Properties.MaxLength = 50;
            this.txtHolidayName.Size = new System.Drawing.Size(446, 22);
            this.txtHolidayName.StyleController = this.myLayoutControl1;
            this.txtHolidayName.TabIndex = 4;
            this.txtHolidayName.Validating += new System.ComponentModel.CancelEventHandler(this.txtHolidayName_Validating);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.emptySpaceItem3,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem5,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(750, 144);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtHolidayName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(588, 26);
            this.layoutControlItem1.Text = "Holiday Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(135, 16);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 104);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(730, 20);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbHolidayType;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(292, 26);
            this.layoutControlItem2.Text = "Type";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(135, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtRemarks;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(730, 26);
            this.layoutControlItem6.Text = "Remarks";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(135, 16);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.deDateTo;
            this.layoutControlItem4.Location = new System.Drawing.Point(292, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(204, 26);
            this.layoutControlItem4.Text = "Date To";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(45, 16);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(588, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(142, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.deDateFrom;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(292, 26);
            this.layoutControlItem3.Text = "Date From";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(135, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(584, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(146, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtNofDays;
            this.layoutControlItem5.Location = new System.Drawing.Point(496, 52);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(234, 26);
            this.layoutControlItem5.Text = "Nof Days";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(53, 16);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cmbRepeatOnSameDate;
            this.layoutControlItem7.Location = new System.Drawing.Point(292, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(292, 26);
            this.layoutControlItem7.Text = "Repeats on same date ";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(135, 16);
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // frmHoliday
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 240);
            this.FirstControl = this.myLayoutControl1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHoliday";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Holiday";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbRepeatOnSameDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNofDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbHolidayType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHolidayName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.TextEdit txtRemarks;
        private Alit.WinformControls.TextEdit txtNofDays;
        private Alit.WinformControls.DateEdit deDateTo;
        private Alit.WinformControls.DateEdit deDateFrom;
        private Alit.WinformControls.ComboBoxEdit cmbHolidayType;
        private Alit.WinformControls.TextEdit txtHolidayName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private Alit.WinformControls.ComboBoxEdit cmbRepeatOnSameDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}