using System.ComponentModel;

namespace Alit.WinformControls
{
    partial class PictureSelect
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
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClearImage = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 25);
            this.pictureEdit1.MinimumSize = new System.Drawing.Size(50, 20);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit1.Size = new System.Drawing.Size(351, 295);
            this.pictureEdit1.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBrowse.Location = new System.Drawing.Point(2, 2);
            this.btnBrowse.MaximumSize = new System.Drawing.Size(0, 20);
            this.btnBrowse.MinimumSize = new System.Drawing.Size(75, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 20);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClearImage);
            this.panelControl1.Controls.Add(this.btnBrowse);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(351, 25);
            this.panelControl1.TabIndex = 3;
            // 
            // btnClearImage
            // 
            this.btnClearImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClearImage.Location = new System.Drawing.Point(77, 2);
            this.btnClearImage.MaximumSize = new System.Drawing.Size(0, 20);
            this.btnClearImage.MinimumSize = new System.Drawing.Size(75, 20);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(75, 20);
            this.btnClearImage.TabIndex = 3;
            this.btnClearImage.Text = "Clear";
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // PictureSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.panelControl1);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "PictureSelect";
            this.Size = new System.Drawing.Size(351, 320);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.SimpleButton btnClearImage;
    }
}
