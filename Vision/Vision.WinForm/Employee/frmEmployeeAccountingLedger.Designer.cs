namespace Vision.WinForm.Employee
{
    partial class frmEmployeeAccountingLedger
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
            this.txtEmployeeAccountingLedgerName = new Alit.WinformControls.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeAccountingLedgerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.MaximumSize = new System.Drawing.Size(790, 70);
            this.panelContent.Size = new System.Drawing.Size(790, 70);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.txtEmployeeAccountingLedgerName);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(786, 66);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // txtEmployeeAccountingLedgerName
            // 
            this.txtEmployeeAccountingLedgerName.EnterMoveNextControl = true;
            this.txtEmployeeAccountingLedgerName.Location = new System.Drawing.Point(277, 12);
            this.txtEmployeeAccountingLedgerName.MaximumSize = new System.Drawing.Size(500, 0);
            this.txtEmployeeAccountingLedgerName.MenuManager = this.barManager1;
            this.txtEmployeeAccountingLedgerName.Name = "txtEmployeeAccountingLedgerName";
            this.txtEmployeeAccountingLedgerName.Properties.MaxLength = 50;
            this.txtEmployeeAccountingLedgerName.Size = new System.Drawing.Size(497, 26);
            this.txtEmployeeAccountingLedgerName.StyleController = this.myLayoutControl1;
            this.txtEmployeeAccountingLedgerName.TabIndex = 4;
            this.txtEmployeeAccountingLedgerName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployeeAccountingLedgerName_Validating);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(786, 66);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtEmployeeAccountingLedgerName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(766, 30);
            this.layoutControlItem1.Text = "Employee Accounting Ledger Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(262, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 30);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(766, 16);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // frmEmployeeAccountingLedger
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 316);
            this.FirstControl = this.myLayoutControl1;
            this.MinimumSize = new System.Drawing.Size(108, 59);
            this.Name = "frmEmployeeAccountingLedger";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Employee Accounting Ledger";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeAccountingLedgerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.TextEdit txtEmployeeAccountingLedgerName;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}