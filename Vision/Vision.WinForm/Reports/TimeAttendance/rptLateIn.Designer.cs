namespace Vision.WinForm.Reports.TimeAttendance
{
    partial class rptLateIn
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bandDetail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
            this.bandHeader = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.lblEmployeeNameHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEmployeeNo = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // bandDetail
            // 
            this.bandDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1});
            this.bandDetail.HeightF = 16F;
            this.bandDetail.Name = "bandDetail";
            this.bandDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.bandDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.BorderWidth = 0.25F;
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EmployeeName]")});
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(150F, 16F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseBorderWidth = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "xrLabel2";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.BorderWidth = 0.25F;
            this.xrLabel1.CanGrow = false;
            this.xrLabel1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EmployeeNoWithPrefix]")});
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(75F, 16F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseBorderWidth = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 25F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 25F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Vision.Model.Reports.TimeAttendance.LateInReportModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // bandHeader
            // 
            this.bandHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblEmployeeNameHeader,
            this.lblEmployeeNo});
            this.bandHeader.HeightF = 23F;
            this.bandHeader.Name = "bandHeader";
            // 
            // lblEmployeeNameHeader
            // 
            this.lblEmployeeNameHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEmployeeNameHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblEmployeeNameHeader.BorderWidth = 0.25F;
            this.lblEmployeeNameHeader.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeNameHeader.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.lblEmployeeNameHeader.Name = "lblEmployeeNameHeader";
            this.lblEmployeeNameHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEmployeeNameHeader.SizeF = new System.Drawing.SizeF(150F, 23F);
            this.lblEmployeeNameHeader.StylePriority.UseBackColor = false;
            this.lblEmployeeNameHeader.StylePriority.UseBorders = false;
            this.lblEmployeeNameHeader.StylePriority.UseBorderWidth = false;
            this.lblEmployeeNameHeader.StylePriority.UseFont = false;
            this.lblEmployeeNameHeader.StylePriority.UseTextAlignment = false;
            this.lblEmployeeNameHeader.Text = "Employee Name";
            this.lblEmployeeNameHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblEmployeeNo
            // 
            this.lblEmployeeNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEmployeeNo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblEmployeeNo.BorderWidth = 0.25F;
            this.lblEmployeeNo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeNo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblEmployeeNo.Name = "lblEmployeeNo";
            this.lblEmployeeNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEmployeeNo.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.lblEmployeeNo.StylePriority.UseBackColor = false;
            this.lblEmployeeNo.StylePriority.UseBorders = false;
            this.lblEmployeeNo.StylePriority.UseBorderWidth = false;
            this.lblEmployeeNo.StylePriority.UseFont = false;
            this.lblEmployeeNo.StylePriority.UseTextAlignment = false;
            this.lblEmployeeNo.Text = "No.";
            this.lblEmployeeNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // rptLateIn
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.bandDetail,
            this.TopMargin,
            this.BottomMargin,
            this.bandHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.DisplayName = "Late In";
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 25);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        public DevExpress.XtraReports.UI.DetailBand bandDetail;
        public DevExpress.XtraReports.UI.GroupHeaderBand bandHeader;
        public DevExpress.XtraReports.UI.XRLabel lblEmployeeNameHeader;
        public DevExpress.XtraReports.UI.XRLabel lblEmployeeNo;
    }
}
