﻿namespace Vision.WinForm.Reports.TimeAttendance
{
    partial class frmRepDailyAttendanceSummary
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
            this.ucEmployeeFilter1 = new Vision.WinForm.Reports.ucEmployeeFilter();
            this.txtNofRecords = new Alit.WinformControls.TextEdit();
            this.btnExportToExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnClearData = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridViewData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnGetReport = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNofRecords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panelContent.Size = new System.Drawing.Size(1255, 593);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.ucEmployeeFilter1);
            this.myLayoutControl1.Controls.Add(this.txtNofRecords);
            this.myLayoutControl1.Controls.Add(this.btnExportToExcel);
            this.myLayoutControl1.Controls.Add(this.btnClearData);
            this.myLayoutControl1.Controls.Add(this.gridControlData);
            this.myLayoutControl1.Controls.Add(this.btnGetReport);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1251, 589);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // ucEmployeeFilter1
            // 
            this.ucEmployeeFilter1.DateFrom = new System.DateTime(((long)(0)));
            this.ucEmployeeFilter1.DateTo = new System.DateTime(((long)(0)));
            this.ucEmployeeFilter1.DepartmentID = 0;
            this.ucEmployeeFilter1.DesignationID = 0;
            this.ucEmployeeFilter1.EmploymentType = -1;
            this.ucEmployeeFilter1.Location = new System.Drawing.Point(12, 12);
            this.ucEmployeeFilter1.LocationID = 0;
            this.ucEmployeeFilter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucEmployeeFilter1.MaximumSize = new System.Drawing.Size(0, 110);
            this.ucEmployeeFilter1.MinimumSize = new System.Drawing.Size(0, 110);
            this.ucEmployeeFilter1.Name = "ucEmployeeFilter1";
            this.ucEmployeeFilter1.Size = new System.Drawing.Size(1095, 110);
            this.ucEmployeeFilter1.TabIndex = 17;
            // 
            // txtNofRecords
            // 
            this.txtNofRecords.EnterMoveNextControl = true;
            this.txtNofRecords.Location = new System.Drawing.Point(426, 126);
            this.txtNofRecords.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtNofRecords.Name = "txtNofRecords";
            this.txtNofRecords.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNofRecords.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNofRecords.Properties.ReadOnly = true;
            this.txtNofRecords.Size = new System.Drawing.Size(99, 22);
            this.txtNofRecords.StyleController = this.myLayoutControl1;
            this.txtNofRecords.TabIndex = 16;
            this.txtNofRecords.TabStop = false;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(218, 126);
            this.btnExportToExcel.MaximumSize = new System.Drawing.Size(125, 0);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(124, 23);
            this.btnExportToExcel.StyleController = this.myLayoutControl1;
            this.btnExportToExcel.TabIndex = 14;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(115, 126);
            this.btnClearData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClearData.MaximumSize = new System.Drawing.Size(100, 0);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(99, 23);
            this.btnClearData.StyleController = this.myLayoutControl1;
            this.btnClearData.TabIndex = 9;
            this.btnClearData.Text = "Clear Data";
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // gridControlData
            // 
            this.gridControlData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControlData.Location = new System.Drawing.Point(12, 153);
            this.gridControlData.MainView = this.gridViewData;
            this.gridControlData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(1227, 424);
            this.gridControlData.TabIndex = 8;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewData});
            // 
            // gridViewData
            // 
            this.gridViewData.DetailHeight = 311;
            this.gridViewData.GridControl = this.gridControlData;
            this.gridViewData.Name = "gridViewData";
            this.gridViewData.OptionsBehavior.Editable = false;
            this.gridViewData.OptionsBehavior.ReadOnly = true;
            this.gridViewData.OptionsFind.AlwaysVisible = true;
            this.gridViewData.OptionsFind.Behavior = DevExpress.XtraEditors.FindPanelBehavior.Filter;
            this.gridViewData.OptionsFind.ShowCloseButton = false;
            this.gridViewData.OptionsFind.ShowFindButton = false;
            this.gridViewData.OptionsView.ShowGroupPanel = false;
            // 
            // btnGetReport
            // 
            this.btnGetReport.Location = new System.Drawing.Point(12, 126);
            this.btnGetReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGetReport.MaximumSize = new System.Drawing.Size(100, 0);
            this.btnGetReport.Name = "btnGetReport";
            this.btnGetReport.Size = new System.Drawing.Size(99, 23);
            this.btnGetReport.StyleController = this.myLayoutControl1;
            this.btnGetReport.TabIndex = 7;
            this.btnGetReport.Text = "Refresh Data";
            this.btnGetReport.Click += new System.EventHandler(this.btnGetReport_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem11,
            this.layoutControlItem2,
            this.simpleSeparator1,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1251, 589);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControlData;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 141);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1231, 428);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnGetReport;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 114);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(103, 27);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClearData;
            this.layoutControlItem6.Location = new System.Drawing.Point(103, 114);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(103, 27);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnExportToExcel;
            this.layoutControlItem11.Location = new System.Drawing.Point(206, 114);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(128, 27);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtNofRecords;
            this.layoutControlItem2.Location = new System.Drawing.Point(336, 114);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(181, 27);
            this.layoutControlItem2.Text = "Nof. Records";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 16);
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.Location = new System.Drawing.Point(334, 114);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(2, 27);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.ucEmployeeFilter1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1099, 114);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(517, 114);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(582, 27);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(1099, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(132, 141);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmRepDailyAttendanceSummary
            // 
            this.AllowRefresh = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 620);
            this.FirstControl = this.myLayoutControl1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmRepDailyAttendanceSummary";
            this.Text = "Daily Attendance Report";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNofRecords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraEditors.SimpleButton btnGetReport;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnClearData;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnExportToExcel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private Alit.WinformControls.TextEdit txtNofRecords;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewData;
        private ucEmployeeFilter ucEmployeeFilter1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}