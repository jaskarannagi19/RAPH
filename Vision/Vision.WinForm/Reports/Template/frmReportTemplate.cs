using Vision.Model;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.WinForm.Reports.Template
{
    public partial class frmReportTemplate : Vision.WinForm.Template.BaseTemplate
    {
        private Control FirstControl_;
        [DefaultValue(null)]
        public Control FirstControl
        {
            get
            {
                if (FirstControl_ == null)
                {
                    FirstControl_ = this.panelContent.Controls.Cast<Control>().FirstOrDefault(r => r.Enabled && r.CanFocus);
                }
                return FirstControl_;
            }
            set
            {
                FirstControl_ = value;
            }
        }

        [Description("Use generalize header and footer for the report. if true header and footer will be designed at runtime by template form.")]
        [DefaultValue(true)]
        public bool UseGeneralizeHeader { get; set; }

        [Description("Report Title 1 will print in report header or page header in bold and big fonts.")]
        [DefaultValue(null)]
        public string ReportTitle1 { get; set; }

        [Description("Report Title 2 will print in report header or page header in bold and big fonts.")]
        [DefaultValue(null)]
        public string ReportTitle2 { get; set; }

        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManagerMain;

        public frmReportTemplate()
        {
            InitializeComponent();
            //lblFormCaption.Caption = "";
            //printPreviewBarItemParameters.Enabled = true;
            //printPreviewBarItemParameters.Down = true;
            UseGeneralizeHeader = true;
            ShowWaitForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            lblFormCaption.Caption = this.Text;
            SetFormInitialView();
            base.OnLoad(e);

            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                backgroundWorkerLoadInitialValues.RunWorkerAsync();
            }
        }

        public void SetFormInitialView()
        {
            if (FirstControl != null) FirstControl.Focus();
            InitializeDefaultValues();
        }

        private void backgroundWorkerLoadInitialValues_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadFormValues();
            LoadLookupDataSource();
            //this.Invoke((MethodInvoker)delegate { LoadFormValues(); });
        }
        private void backgroundWorkerLoadInitialValues_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { AssignFormValues(); AssignLookupDataSource(); CloseWaitForm(); });
        }

        public void ResetFormView()
        {
            ClearValues();
            this.ErrorProvider.Clear();
            SetFocusOnFirstControl();
        }

        #region Virtual Methods

        public virtual bool ValidateBeforeSave()
        {
            CallValidatingEvent(this);

            string ErrorText = ErrorProvider.GetAllErrorText();
            if (!String.IsNullOrEmpty(ErrorText))
            {

                Alit.WinformControls.MessageBox.Show(this, "Can not save. Please fix following errors:\r\n\r\n" + ErrorText,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (ErrorProvider.ErrorList != null && ErrorProvider.ErrorList.Count > 0)
                {
                    Control FirstErrorControl = ErrorProvider.ErrorList.ElementAt(0).Key;
                    if (FirstErrorControl != null && FirstErrorControl.CanFocus)
                    {
                        FirstErrorControl.Focus();
                    }
                    else
                    {
                        panelContent.Focus();
                        SendKeys.SendWait("{Tab}");
                    }
                }
                return false;
            }
            return true;
        }

        public static void CallValidatingEvent(Control ControlToValidation)
        {
            IEnumerable<Control> ControlList = ControlToValidation.Controls.OfType<Control>();
            if (ControlList != null)
            {
                Type ControlType = typeof(Control);
                foreach (Control Cont in ControlList)
                {
                    if (Cont.Enabled && Cont.Visible)
                    {
                        Delegate DelValid = WinForm.Template.frmCRUDTemplate.GetEventHandler(ControlType, Cont, "Validating");
                        if (DelValid != null)
                        {
                            DelValid.DynamicInvoke(Cont, new CancelEventArgs());
                        }
                        if (Cont.HasChildren)
                        {
                            CallValidatingEvent(Cont);
                        }
                    }
                }
            }
        }

        public virtual void GenerateReport(GenerateReportParameter Paras,ref XtraReport ReportSource)
        {
        }

        public virtual void AfterGenerateReport(GenerateReportParameter Paras)
        {
            if (Paras.GenerateReportResult != null)
            {
                switch (Paras.GenerateReportResult.ExecutionResult)
                {
                    case eExecutionResult.CommitedSucessfuly:
                        //Alit.WinformControls.ToastNotification.Show(this, "Report generated successfully");
                        if(!String.IsNullOrWhiteSpace(Paras.GenerateReportResult.MessageAfterReportGenerated))
                        {
                            Alit.WinformControls.MessageBox.Show(this, Paras.GenerateReportResult.MessageAfterReportGenerated, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case eExecutionResult.ErrorWhileExecuting:
                        Alit.WinformControls.MessageBox.Show(this,
                            (Paras.GenerateReportResult.Exception.Message.Length > 500 ? Paras.GenerateReportResult.Exception.Message.Substring(0, 500) : Paras.GenerateReportResult.Exception.Message),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case eExecutionResult.ValidationError:
                        Alit.WinformControls.MessageBox.Show(this, "Can not generate report, please check following validation issue.\r\n\r\n" + Paras.GenerateReportResult.ValidationError, 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                }
            }
        }

        /// <summary>
        /// Clear control values or set it to default values. It is for refresh form values
        /// </summary>
        public virtual void ClearValues()
        {
            WinForm.Template.frmCRUDTemplate.ClearValues(panelContent);
            InitializeDefaultValues();
        }

        public virtual void InitializeDefaultValues()
        { }

        /// <summary>
        /// After set a view like entry/edit/search. Form current view can be access by "this.CurrentView"
        /// </summary>
        public virtual void AfterSetView()
        {

        }

        //public virtual object GetViewModelFromSelectedEditingRecord(object CurrentEditingRecord)
        //{
        //    return Model.CommonFunctions.CloneObject(CurrentEditingRecord);
        //}

        public virtual void LoadFormValues()
        {
        }
        public virtual void AssignFormValues() { }
        public virtual void LoadLookupDataSource() { }
        public virtual void AssignLookupDataSource() { }


        #endregion

        #region Action Methods

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExecuteGenerateReport();
        }

        public DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        public DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        //public DevExpress.XtraReports.UI.ReportFooterBand ReportFooterBand;
        //public DevExpress.XtraReports.UI.XRLine xrlpfTopLine;
        //public DevExpress.XtraReports.UI.XRPageInfo xrpipfPrintDateTime;
        //public DevExpress.XtraReports.UI.XRPageInfo xrpipfPageNo;

        public DevExpress.XtraReports.UI.XRLabel xrlrhReportTitle1;
        public DevExpress.XtraReports.UI.XRLabel xrlrhReportTitle2;

        public DevExpress.XtraReports.UI.XRLabel xrlphReportTitle1;
        public DevExpress.XtraReports.UI.XRLabel xrlphReportTitle2;

        public void ExecuteGenerateReport()
        {
            if (!ValidateBeforeSave())
            {
                if (FirstControl != null && FirstControl.CanFocus)
                {
                    FirstControl.Focus();
                }
                return;
            }

            GenerateReportParameter ReportParas = new GenerateReportParameter();
            XtraReport ReportSource = null;
            GenerateReport(ReportParas,ref ReportSource);

            if (UseGeneralizeHeader && ReportSource != null)
            {

                float FullPageWidth = ReportSource.PageWidth - (ReportSource.Margins.Left + ReportSource.Margins.Right);//(ReportSource.PaperKind == PaperKind.A5 ? (ReportSource.Landscape ? 0f : 533f) : (ReportSource.Landscape ? 0f : 777f));
                ///-- Designing generalize header and footer
                ///

                ReportHeader = ReportSource.Bands.OfType<DevExpress.XtraReports.UI.ReportHeaderBand>().FirstOrDefault();
                if (ReportHeader == null)
                {
                    ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
                    ReportSource.Bands.Add(ReportHeader);
                }
                PageHeader = ReportSource.Bands.OfType<DevExpress.XtraReports.UI.PageHeaderBand>().FirstOrDefault();
                if (PageHeader == null)
                {
                    PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
                    ReportSource.Bands.Add(PageHeader);
                }

                var ReportFooterBand = ReportSource.Bands.OfType<DevExpress.XtraReports.UI.ReportFooterBand>().FirstOrDefault();
                if (ReportFooterBand == null)
                {
                    ReportFooterBand = new ReportFooterBand();//new DevExpress.XtraReports.UI.PageFooterBand();
                    ReportSource.Bands.Add(ReportFooterBand);
                }
                ReportFooterBand.PrintAtBottom = true;

                var xrlpfTopLine = new DevExpress.XtraReports.UI.XRLine();
                var xrpipfPrintDateTime = new DevExpress.XtraReports.UI.XRPageInfo();
                var xrpipfPageNo = new DevExpress.XtraReports.UI.XRPageInfo();

                var xrlrhCompanyName = new DevExpress.XtraReports.UI.XRLabel();
                var xrlrhCompanyAddress = new DevExpress.XtraReports.UI.XRLabel();
                var xrlrhCompanyContactDetails = new DevExpress.XtraReports.UI.XRLabel();

                xrlrhReportTitle1 = new DevExpress.XtraReports.UI.XRLabel();
                xrlrhReportTitle2 = new DevExpress.XtraReports.UI.XRLabel();

                xrlphReportTitle1 = new DevExpress.XtraReports.UI.XRLabel();
                xrlphReportTitle2 = new DevExpress.XtraReports.UI.XRLabel();

                ((System.ComponentModel.ISupportInitialize)(ReportSource)).BeginInit();


                // 
                // xrlpfTopLine
                // 
                xrlpfTopLine.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
                xrlpfTopLine.Name = "xrlpfTopLine";
                xrlpfTopLine.SizeF = new System.Drawing.SizeF(FullPageWidth, 5F);

                // 
                // pageFooterBand1
                // 

                ReportFooterBand.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                xrpipfPrintDateTime,
                xrpipfPageNo,
                xrlpfTopLine});
                ReportFooterBand.HeightF = 29F;
                ReportFooterBand.Name = "pageFooterBand1";
                // 
                // xrpipfPrintDateTime
                // 
                //xrpipfPrintDateTime.Borders = DevExpress.XtraPrinting.BorderSide.All;
                xrpipfPrintDateTime.Font = new System.Drawing.Font("Arial", 10F);
                xrpipfPrintDateTime.LocationFloat = new DevExpress.Utils.PointFloat(0F, 7F);
                xrpipfPrintDateTime.Name = "xrpipfPrintDateTime";
                xrpipfPrintDateTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                xrpipfPrintDateTime.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
                xrpipfPrintDateTime.SizeF = new System.Drawing.SizeF(200F, 20F);
                xrpipfPrintDateTime.StyleName = "PageInfo";
                // 
                // xrpipfPageNo
                // 
                //xrpipfPageNo.Borders = DevExpress.XtraPrinting.BorderSide.All;
                xrpipfPageNo.Font = new System.Drawing.Font("Arial", 10F);
                xrpipfPageNo.Format = "Page {0} of {1}";
                xrpipfPageNo.LocationFloat = new DevExpress.Utils.PointFloat(FullPageWidth - 150, 7F);
                xrpipfPageNo.Name = "xrpipfPageNo";
                xrpipfPageNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                xrpipfPageNo.SizeF = new System.Drawing.SizeF(150F, 20F);
                xrpipfPageNo.StyleName = "PageInfo";
                xrpipfPageNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;

                //
                //Page Header
                //
                PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] { xrlphReportTitle1, xrlphReportTitle2 });
                // 
                // PageHeader
                // 
                PageHeader.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                PageHeader.HeightF = 55F;
                PageHeader.Name = "PageHeader";
                PageHeader.PrintOn = DevExpress.XtraReports.UI.PrintOnPages.NotWithReportHeader;
                PageHeader.StylePriority.UseBorders = false;

                // 
                // xrlphReportTitle
                // 
                xrlphReportTitle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
                xrlphReportTitle1.CanShrink = true;
                xrlphReportTitle1.ProcessNullValues = ValueSuppressType.SuppressAndShrink;
                xrlphReportTitle1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
                xrlphReportTitle1.Name = "xrlphReportTitle1";
                xrlphReportTitle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 10, 10, 100F);
                xrlphReportTitle1.SizeF = new System.Drawing.SizeF(FullPageWidth, 30F);
                xrlphReportTitle1.StylePriority.UseFont = false;
                xrlphReportTitle1.StylePriority.UseTextAlignment = false;
                xrlphReportTitle1.Text = ReportTitle1;
                xrlphReportTitle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;


                // 
                // xrlphReportTitle
                // 
                xrlphReportTitle2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
                xrlphReportTitle2.CanShrink = true;
                xrlphReportTitle2.ProcessNullValues = ValueSuppressType.SuppressAndShrink;
                xrlphReportTitle2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30F);
                xrlphReportTitle2.Name = "xrlphReportTitle2";
                xrlphReportTitle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
                xrlphReportTitle2.SizeF = new System.Drawing.SizeF(FullPageWidth, 25F);
                xrlphReportTitle2.StylePriority.UseFont = false;
                xrlphReportTitle2.StylePriority.UseTextAlignment = false;
                xrlphReportTitle2.Text = ReportTitle2;
                xrlphReportTitle2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
                
                // 
                // ReportHeader
                // 
                ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
                xrlrhCompanyName,
                xrlrhCompanyAddress,
                xrlrhCompanyContactDetails,
                xrlrhReportTitle1, xrlrhReportTitle2});

                ReportHeader.HeightF = 120f;
                ReportHeader.Name = "ReportHeader";
                // 
                // xrlrhCompanyName
                // 
                xrlrhCompanyName.CanGrow = false;
                xrlrhCompanyName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
                xrlrhCompanyName.ForeColor = System.Drawing.Color.Black;
                xrlrhCompanyName.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
                xrlrhCompanyName.Name = "xrlrhCompanyName";
                xrlrhCompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                xrlrhCompanyName.SizeF = new System.Drawing.SizeF(FullPageWidth, 25F);
                xrlrhCompanyName.StyleName = "Title";
                xrlrhCompanyName.StylePriority.UseFont = false;
                xrlrhCompanyName.StylePriority.UseForeColor = false;
                xrlrhCompanyName.StylePriority.UseTextAlignment = false;
                xrlrhCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
                xrlrhCompanyName.Text = CommonProperties.LoginInfo.LoggedInCompanyReportModel.CompanyName;
                // 
                // xrlrhCompanyAddress
                // 
                xrlrhCompanyAddress.Font = new System.Drawing.Font("Arial", 10F);
                xrlrhCompanyAddress.LocationFloat = new DevExpress.Utils.PointFloat(0F, 25F);
                xrlrhCompanyAddress.Name = "xrlrhCompanyAddress";
                xrlrhCompanyAddress.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                xrlrhCompanyAddress.SizeF = new System.Drawing.SizeF(FullPageWidth, 20F);
                xrlrhCompanyAddress.StylePriority.UseFont = false;
                xrlrhCompanyAddress.StylePriority.UseTextAlignment = false;
                xrlrhCompanyAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                xrlrhCompanyAddress.Text = CommonProperties.LoginInfo.LoggedInCompanyReportModel.AddressWithCity;
                // 
                // xrlrhCompanyContactDetails
                // 
                //xrlrhCompanyContactDetails.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                xrlrhCompanyContactDetails.Font = new System.Drawing.Font("Arial", 10F);
                xrlrhCompanyContactDetails.LocationFloat = new DevExpress.Utils.PointFloat(0F, 45F);
                xrlrhCompanyContactDetails.Name = "xrlrhCompanyContactDetails";
                xrlrhCompanyContactDetails.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
                xrlrhCompanyContactDetails.SizeF = new System.Drawing.SizeF(FullPageWidth, 20F);
                xrlrhCompanyContactDetails.StylePriority.UseBorders = false;
                xrlrhCompanyContactDetails.StylePriority.UseFont = false;
                xrlrhCompanyContactDetails.StylePriority.UseTextAlignment = false;
                xrlrhCompanyContactDetails.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                xrlrhCompanyContactDetails.Text = CommonProperties.LoginInfo.LoggedInCompanyReportModel.ContactDetails;
                // 
                // xrlrhReportTitle
                // 
                //xrlrhReportTitle1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                xrlrhReportTitle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
                xrlrhReportTitle1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 65F);
                xrlrhReportTitle1.Name = "xrlrhReportTitle1";
                xrlrhReportTitle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
                xrlrhReportTitle1.SizeF = new System.Drawing.SizeF(FullPageWidth, 30F);
                xrlrhReportTitle1.StylePriority.UseBorders = false;
                xrlrhReportTitle1.StylePriority.UseFont = false;
                xrlrhReportTitle1.StylePriority.UseTextAlignment = false;
                xrlrhReportTitle1.Text = ReportTitle1;
                xrlrhReportTitle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;

                // 
                // xrlrhReportTitle
                // 
                xrlrhReportTitle2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
                xrlrhReportTitle2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
                xrlrhReportTitle2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 95F);
                xrlrhReportTitle2.Name = "xrlrhReportTitle2";
                xrlrhReportTitle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
                xrlrhReportTitle2.SizeF = new System.Drawing.SizeF(FullPageWidth, 25F);
                xrlrhReportTitle2.StylePriority.UseBorders = false;
                xrlrhReportTitle2.StylePriority.UseFont = false;
                xrlrhReportTitle2.StylePriority.UseTextAlignment = false;
                xrlrhReportTitle2.Text = ReportTitle2;
                xrlrhReportTitle2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;

                ((System.ComponentModel.ISupportInitialize)(ReportSource)).EndInit();
            }
            ///--
            DocViwer.DocumentSource = ReportSource;
            if (ReportSource != null)
            {
                ReportSource.CreateDocument(true);
            }
            ///-
            AfterGenerateReport(ReportParas);
            //--
            //if (ReportParas.GenerateReportResult != null && ReportParas.GenerateReportResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            //{
            //    ResetFormView();
            //}
            //FirstControl.Focus();
            DocViwer.Focus();
            //--
            Application.DoEvents();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetFormView();
        }
        
        public void SetFocusOnFirstControl()
        {
            if (FirstControl != null)
            {
                FirstControl.Focus();
            }
            else
            {
                panelContent.Focus();
                SendKeys.SendWait("{Tab}");
            }
        }

        private void btnSetSaveFocus_Enter(object sender, EventArgs e)
        {
            //barFormFooter.ItemLinks[0].Focus();
            btnGenerateReport.Links[0].Focus();
        }

        private void btnSetExitFocus_Click(object sender, EventArgs e)
        {
            btnExit.Links[0].Focus();
        }
        #endregion

        public void ShowWaitForm()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                this.splashScreenManagerMain = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Vision.WinForm.Template.frmWait), true, true, true);
                this.splashScreenManagerMain.ShowWaitForm();
            }
        }
        public void CloseWaitForm()
        {
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                if (this.splashScreenManagerMain == null) return;
                this.splashScreenManagerMain.CloseWaitForm();
                this.splashScreenManagerMain.Dispose();
                this.splashScreenManagerMain = null;
            }
        }

        public void HideParameterPanel()
        {
            barButtonItemParameterPanel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            dockPanelParameters.Hide();
            //printPreviewBarItemParameters.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void barButtonStandardA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void printPreviewRibbonPageGroup8_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e)
        {
            this.Close();
        }

        bool SuppressParameterPanelVisibilityEvents;
        private void barButtonItemParameterPanel_DownChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SuppressParameterPanelVisibilityEvents) return;
            SuppressParameterPanelVisibilityEvents = true;
            if (barButtonItemParameterPanel.Down)
            {
                dockPanelParameters.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                //dockPanelParameters.ShowSliding();
            }
            else
            {
                //dockPanelParameters.HideSliding();
                dockPanelParameters.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            }
            SuppressParameterPanelVisibilityEvents = false;
        }

        private void dockPanelParameters_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            if (SuppressParameterPanelVisibilityEvents) return;
            SuppressParameterPanelVisibilityEvents = true;
            if (e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible || e.Visibility == DevExpress.XtraBars.Docking.DockVisibility.AutoHide)
            {
                barButtonItemParameterPanel.Down = true;
            }
            else
            {
                barButtonItemParameterPanel.Down = false;
            }
            SuppressParameterPanelVisibilityEvents = false;
        }
    }
}
