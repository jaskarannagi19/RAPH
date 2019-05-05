namespace Vision.WinForm.Employee
{
    partial class frmEmployeeDepartment
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
            this.txtEmployeeDepartmentName = new Alit.WinformControls.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.MaximumSize = new System.Drawing.Size(650, 58);
            this.panelContent.Size = new System.Drawing.Size(646, 57);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.txtEmployeeDepartmentName);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(642, 53);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // txtEmployeeDepartmentName
            // 
            this.txtEmployeeDepartmentName.EnterMoveNextControl = true;
            this.txtEmployeeDepartmentName.Location = new System.Drawing.Point(151, 12);
            this.txtEmployeeDepartmentName.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtEmployeeDepartmentName.MenuManager = this.barManager1;
            this.txtEmployeeDepartmentName.Name = "txtEmployeeDepartmentName";
            this.txtEmployeeDepartmentName.Properties.MaxLength = 50;
            this.txtEmployeeDepartmentName.Size = new System.Drawing.Size(400, 20);
            this.txtEmployeeDepartmentName.StyleController = this.myLayoutControl1;
            this.txtEmployeeDepartmentName.TabIndex = 4;
            this.txtEmployeeDepartmentName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployeeDepartmentName_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(642, 53);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtEmployeeDepartmentName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(622, 33);
            this.layoutControlItem1.Text = "Employee Department Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(136, 13);
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // frmEmployeeDepartment
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 315);
            this.FirstControl = this.myLayoutControl1;
            this.MinimumSize = new System.Drawing.Size(106, 57);
            this.Name = "frmEmployeeDepartment";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Employee Department";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.TextEdit txtEmployeeDepartmentName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}