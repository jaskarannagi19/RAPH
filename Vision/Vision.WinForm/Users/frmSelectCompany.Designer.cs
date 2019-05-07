namespace Vision.WinForm.Users
{
    partial class frmSelectCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectCompany));
            this.myLayoutControl1 = new Alit.WinformControls.myLayoutControl();
            this.lookupFinPeriod = new Alit.WinformControls.LookUpEdit();
            this.lookupCompany = new Alit.WinformControls.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciFinPer = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupFinPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFinPer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Margin = new System.Windows.Forms.Padding(6);
            this.panelContent.Size = new System.Drawing.Size(762, 134);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.lookupFinPeriod);
            this.myLayoutControl1.Controls.Add(this.lookupCompany);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Margin = new System.Windows.Forms.Padding(4);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(758, 130);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // lookupFinPeriod
            // 
            this.lookupFinPeriod.EnterMoveNextControl = true;
            this.lookupFinPeriod.Location = new System.Drawing.Point(134, 42);
            this.lookupFinPeriod.Margin = new System.Windows.Forms.Padding(4);
            this.lookupFinPeriod.MaximumSize = new System.Drawing.Size(600, 0);
            this.lookupFinPeriod.Name = "lookupFinPeriod";
            this.lookupFinPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupFinPeriod.Properties.NullText = "Select";
            this.lookupFinPeriod.Size = new System.Drawing.Size(597, 26);
            this.lookupFinPeriod.StyleController = this.myLayoutControl1;
            this.lookupFinPeriod.TabIndex = 5;
            // 
            // lookupCompany
            // 
            this.lookupCompany.EnterMoveNextControl = true;
            this.lookupCompany.Location = new System.Drawing.Point(134, 12);
            this.lookupCompany.Margin = new System.Windows.Forms.Padding(4);
            this.lookupCompany.MaximumSize = new System.Drawing.Size(600, 0);
            this.lookupCompany.Name = "lookupCompany";
            this.lookupCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupCompany.Properties.NullText = "Select";
            this.lookupCompany.Size = new System.Drawing.Size(597, 26);
            this.lookupCompany.StyleController = this.myLayoutControl1;
            this.lookupCompany.TabIndex = 4;
            this.lookupCompany.EditValueChanged += new System.EventHandler(this.lookupCompany_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.lciFinPer,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(758, 130);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookupCompany;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(723, 30);
            this.layoutControlItem1.Text = "Company";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(119, 19);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 60);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(723, 50);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciFinPer
            // 
            this.lciFinPer.Control = this.lookupFinPeriod;
            this.lciFinPer.Location = new System.Drawing.Point(0, 30);
            this.lciFinPer.Name = "lciFinPer";
            this.lciFinPer.Size = new System.Drawing.Size(723, 30);
            this.lciFinPer.Text = "Financial Period";
            this.lciFinPer.TextSize = new System.Drawing.Size(119, 19);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(723, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(15, 110);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmSelectCompany
            // 
            this.AllowRefresh = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 166);
            this.ControlBox = false;
            this.FirstControl = this.myLayoutControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmSelectCompany";
            this.Text = "Select Company";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookupFinPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFinPer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Alit.WinformControls.LookUpEdit lookupFinPeriod;
        private Alit.WinformControls.LookUpEdit lookupCompany;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciFinPer;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}