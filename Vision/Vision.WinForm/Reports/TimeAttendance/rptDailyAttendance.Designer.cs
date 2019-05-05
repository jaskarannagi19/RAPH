namespace Vision.WinForm.Reports.TimeAttendance
{
    partial class rptDailyAttendance
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
            this.lblEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEmployeeNo = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.bandHeader = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.bandGroupHeader = new DevExpress.XtraReports.UI.SubBand();
            this.lblEmployeeNoHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEmployeeNameHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // bandDetail
            // 
            this.bandDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblEmployeeName,
            this.lblEmployeeNo});
            this.bandDetail.HeightF = 16F;
            this.bandDetail.Name = "bandDetail";
            this.bandDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.bandDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblEmployeeName.BorderWidth = 0.25F;
            this.lblEmployeeName.CanGrow = false;
            this.lblEmployeeName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EmployeeName]")});
            this.lblEmployeeName.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEmployeeName.SizeF = new System.Drawing.SizeF(160F, 16F);
            this.lblEmployeeName.StylePriority.UseBorders = false;
            this.lblEmployeeName.StylePriority.UseBorderWidth = false;
            this.lblEmployeeName.StylePriority.UseTextAlignment = false;
            this.lblEmployeeName.Text = "lblEmployeeName";
            this.lblEmployeeName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblEmployeeNo
            // 
            this.lblEmployeeNo.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.lblEmployeeNo.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblEmployeeNo.BorderWidth = 0.25F;
            this.lblEmployeeNo.CanGrow = false;
            this.lblEmployeeNo.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EmployeeNoWithPrefix]")});
            this.lblEmployeeNo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblEmployeeNo.Name = "lblEmployeeNo";
            this.lblEmployeeNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEmployeeNo.SizeF = new System.Drawing.SizeF(75F, 16F);
            this.lblEmployeeNo.StylePriority.UseBorders = false;
            this.lblEmployeeNo.StylePriority.UseBorderWidth = false;
            this.lblEmployeeNo.Text = "lblEmployeeNo";
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
            this.BottomMargin.HeightF = 28.4167F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // bandHeader
            // 
            this.bandHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.bandHeader.HeightF = 16F;
            this.bandHeader.Name = "bandHeader";
            this.bandHeader.SubBands.AddRange(new DevExpress.XtraReports.UI.SubBand[] {
            this.bandGroupHeader});
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrLabel1.BorderWidth = 0.25F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(235F, 16F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseBorderWidth = false;
            this.xrLabel1.Text = " ";
            // 
            // bandGroupHeader
            // 
            this.bandGroupHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblEmployeeNoHeader,
            this.lblEmployeeNameHeader});
            this.bandGroupHeader.HeightF = 23F;
            this.bandGroupHeader.Name = "bandGroupHeader";
            // 
            // lblEmployeeNoHeader
            // 
            this.lblEmployeeNoHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEmployeeNoHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblEmployeeNoHeader.BorderWidth = 0.25F;
            this.lblEmployeeNoHeader.CanGrow = false;
            this.lblEmployeeNoHeader.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeNoHeader.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblEmployeeNoHeader.Name = "lblEmployeeNoHeader";
            this.lblEmployeeNoHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEmployeeNoHeader.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.lblEmployeeNoHeader.StylePriority.UseBackColor = false;
            this.lblEmployeeNoHeader.StylePriority.UseBorders = false;
            this.lblEmployeeNoHeader.StylePriority.UseBorderWidth = false;
            this.lblEmployeeNoHeader.StylePriority.UseFont = false;
            this.lblEmployeeNoHeader.StylePriority.UseTextAlignment = false;
            this.lblEmployeeNoHeader.Text = "No.";
            this.lblEmployeeNoHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblEmployeeNameHeader
            // 
            this.lblEmployeeNameHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEmployeeNameHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblEmployeeNameHeader.BorderWidth = 0.25F;
            this.lblEmployeeNameHeader.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeNameHeader.LocationFloat = new DevExpress.Utils.PointFloat(75F, 0F);
            this.lblEmployeeNameHeader.Name = "lblEmployeeNameHeader";
            this.lblEmployeeNameHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEmployeeNameHeader.SizeF = new System.Drawing.SizeF(160F, 23F);
            this.lblEmployeeNameHeader.StylePriority.UseBackColor = false;
            this.lblEmployeeNameHeader.StylePriority.UseBorders = false;
            this.lblEmployeeNameHeader.StylePriority.UseBorderWidth = false;
            this.lblEmployeeNameHeader.StylePriority.UseFont = false;
            this.lblEmployeeNameHeader.StylePriority.UseTextAlignment = false;
            this.lblEmployeeNameHeader.Text = "Employee Name";
            this.lblEmployeeNameHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(Vision.Model.Reports.TimeAttendance.DailyAttendanceReportModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // rptDailyAttendance
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.bandDetail,
            this.TopMargin,
            this.BottomMargin,
            this.bandHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DisplayName = "Daily Attendance";
            this.Font = new System.Drawing.Font("Arial", 8F);
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 28);
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
        public DevExpress.XtraReports.UI.XRLabel lblEmployeeName;
        public DevExpress.XtraReports.UI.XRLabel lblEmployeeNo;
        public DevExpress.XtraReports.UI.XRLabel lblEmployeeNameHeader;
        public DevExpress.XtraReports.UI.XRLabel lblEmployeeNoHeader;
        public DevExpress.XtraReports.UI.GroupHeaderBand bandHeader;
        public DevExpress.XtraReports.UI.SubBand bandGroupHeader;
        public DevExpress.XtraReports.UI.DetailBand bandDetail;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}
