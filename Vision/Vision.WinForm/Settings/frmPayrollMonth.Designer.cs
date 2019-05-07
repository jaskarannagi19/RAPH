namespace Vision.WinForm.Settings
{
    partial class frmPayrollMonth
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
            this.textPayrollEndDate = new DevExpress.XtraEditors.TextEdit();
            this.textPreviousMonthName = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.textPayrollStartDate = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPayrollEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPreviousMonthName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPayrollStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.layoutControl1);
            this.panelContent.Controls.Add(this.textEdit4);
            this.panelContent.Controls.Add(this.textEdit3);
            this.panelContent.Controls.Add(this.textEdit2);
            this.panelContent.Size = new System.Drawing.Size(1241, 586);
            // 
            // textPayrollEndDate
            // 
            this.textPayrollEndDate.Location = new System.Drawing.Point(89, 42);
            this.textPayrollEndDate.Name = "textPayrollEndDate";
            this.textPayrollEndDate.Size = new System.Drawing.Size(395, 26);
            this.textPayrollEndDate.StyleController = this.layoutControl1;
            this.textPayrollEndDate.TabIndex = 1;
            // 
            // textPreviousMonthName
            // 
            this.textPreviousMonthName.Location = new System.Drawing.Point(89, 72);
            this.textPreviousMonthName.Name = "textPreviousMonthName";
            this.textPreviousMonthName.Size = new System.Drawing.Size(395, 26);
            this.textPreviousMonthName.StyleController = this.layoutControl1;
            this.textPreviousMonthName.TabIndex = 2;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(359, 323);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(150, 26);
            this.textEdit2.TabIndex = 3;
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(359, 378);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(150, 26);
            this.textEdit3.TabIndex = 10;
            // 
            // textEdit4
            // 
            this.textEdit4.Location = new System.Drawing.Point(359, 425);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Size = new System.Drawing.Size(150, 26);
            this.textEdit4.TabIndex = 11;
            // 
            // textPayrollStartDate
            // 
            this.textPayrollStartDate.Location = new System.Drawing.Point(89, 12);
            this.textPayrollStartDate.Name = "textPayrollStartDate";
            this.textPayrollStartDate.Size = new System.Drawing.Size(395, 26);
            this.textPayrollStartDate.StyleController = this.layoutControl1;
            this.textPayrollStartDate.TabIndex = 12;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textPayrollStartDate);
            this.layoutControl1.Controls.Add(this.textPayrollEndDate);
            this.layoutControl1.Controls.Add(this.textPreviousMonthName);
            this.layoutControl1.Location = new System.Drawing.Point(123, 109);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(496, 152);
            this.layoutControl1.TabIndex = 13;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(496, 152);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textPayrollStartDate;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(476, 30);
            this.layoutControlItem1.Text = "Start Date";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(73, 19);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textPayrollEndDate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(476, 30);
            this.layoutControlItem2.Text = "End Date";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(73, 19);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textPreviousMonthName;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(476, 72);
            this.layoutControlItem3.Text = "Month";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(73, 19);
            // 
            // frmPayrollMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 616);
            this.FirstControl = this.textPayrollStartDate;
            this.Name = "frmPayrollMonth";
            this.Text = "frmPayrollMonth";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textPayrollEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPreviousMonthName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPayrollStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit textPayrollEndDate;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textPreviousMonthName;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textPayrollStartDate;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}