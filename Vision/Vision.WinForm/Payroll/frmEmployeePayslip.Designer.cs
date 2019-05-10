namespace Vision.WinForm.Payroll
{
    partial class frmEmployeePayslip
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
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtNetSalary = new Alit.WinformControls.TextEdit();
            this.txtTotalDeduction = new Alit.WinformControls.TextEdit();
            this.txtGrossSalary = new Alit.WinformControls.TextEdit();
            this.gridControlPayslipDeduction = new DevExpress.XtraGrid.GridControl();
            this.PayslipTabDeductionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewPayeSlipDeduction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlPayslipTabEarning = new DevExpress.XtraGrid.GridControl();
            this.PayslipTabEarningBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewPayeSlipTabEarning = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPersonalRelief = new Alit.WinformControls.TextEdit();
            this.txtGrossPAYE = new Alit.WinformControls.TextEdit();
            this.txtTotalBasicHRA = new Alit.WinformControls.TextEdit();
            this.cmbNSSF = new Alit.WinformControls.ComboBoxEdit();
            this.cmbNHIFApplicable = new Alit.WinformControls.ComboBoxEdit();
            this.txtIncomeType = new Alit.WinformControls.TextEdit();
            this.txtPFValue = new Alit.WinformControls.TextEdit();
            this.txtNSSFValue = new Alit.WinformControls.TextEdit();
            this.txtNHIFValue = new Alit.WinformControls.TextEdit();
            this.txtPAYEValue = new Alit.WinformControls.TextEdit();
            this.txtNetTaxableIncome = new Alit.WinformControls.TextEdit();
            this.gcPAYE_PAYERelief = new DevExpress.XtraGrid.GridControl();
            this.PAYEReliefeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPAYE_PAYERelief = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYEReliefName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYEReliefAmt1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonthlyLimit1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTaxableIncome = new Alit.WinformControls.TextEdit();
            this.gcPAYE_NonCashBenefit = new DevExpress.XtraGrid.GridControl();
            this.PAYENoncashBenefitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPAYE_NonCashBenefit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNonCashBenefitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecurrning = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKRAValuePercentage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKRAValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTaxableGrossIncome = new Alit.WinformControls.TextEdit();
            this.gcTaxableEarnings = new DevExpress.XtraGrid.GridControl();
            this.PAYETaxableEarningBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvTaxableEarnings = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEarningAndDeductionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtHRAAmount = new Alit.WinformControls.TextEdit();
            this.txtBasicSalary = new Alit.WinformControls.TextEdit();
            this.gcPAYERelief = new DevExpress.XtraGrid.GridControl();
            this.employeePayslipPAYEReliefeViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPAYERelief = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelectedPAYERelief = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYEReliefName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandatory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPAYEReliefAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtReleifAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMonthlyLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnnualLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNonCashBenefit = new DevExpress.XtraGrid.GridControl();
            this.employeePayslipNoncashBenefitViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvNonCashBenefit = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelectedNonCashBenefit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNonCashBenefitName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecurrning1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtAmtNCB = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colKRAValuePercentage1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtPercNCB = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colKRAValue1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookUpVehicle_NonCashBenefit = new Alit.WinformControls.LookUpEdit();
            this.txtMissedPunchDays = new Alit.WinformControls.TextEdit();
            this.txtDateTitle = new Alit.WinformControls.TextEdit();
            this.gcDeductions = new DevExpress.XtraGrid.GridControl();
            this.employeePayslipDeductionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvDeductions = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtAmt_Deduction = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtLoanInstAmt = new Alit.WinformControls.TextEdit();
            this.txtLateDays = new Alit.WinformControls.TextEdit();
            this.gcEarnings = new DevExpress.XtraGrid.GridControl();
            this.employeePayslipEarningsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvEarnings = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTxtAmt = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.txtWeekendWorkedDays = new Alit.WinformControls.TextEdit();
            this.txtLeaveEncashmentDays = new Alit.WinformControls.TextEdit();
            this.txtNoticePayDays = new Alit.WinformControls.TextEdit();
            this.txtAbsemtDays = new Alit.WinformControls.TextEdit();
            this.txtDoubleOvertimeHours = new Alit.WinformControls.TextEdit();
            this.txtNormalOvertimeHours = new Alit.WinformControls.TextEdit();
            this.lookupEmployee = new Alit.WinformControls.LookUpEdit();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcgEarnings = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgDeductions = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgNonCashBenefit = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgPAYE = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgPayslip = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDeduction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayslipDeduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayslipTabDeductionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayeSlipDeduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayslipTabEarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayslipTabEarningBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayeSlipTabEarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonalRelief.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossPAYE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBasicHRA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNSSF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNHIFApplicable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncomeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPFValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNSSFValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNHIFValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPAYEValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetTaxableIncome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYE_PAYERelief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYEReliefeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYE_PAYERelief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxableIncome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYE_NonCashBenefit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYENoncashBenefitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYE_NonCashBenefit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxableGrossIncome.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaxableEarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYETaxableEarningBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaxableEarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRAAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYERelief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipPAYEReliefeViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYERelief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtReleifAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNonCashBenefit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipNoncashBenefitViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNonCashBenefit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmtNCB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPercNCB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpVehicle_NonCashBenefit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissedPunchDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipDeductionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmt_Deduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanInstAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLateDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipEarningsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekendWorkedDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveEncashmentDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticePayDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbsemtDays.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoubleOvertimeHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNormalOvertimeHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDeductions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgNonCashBenefit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPAYE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPayslip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panelContent.MaximumSize = new System.Drawing.Size(1250, 0);
            this.panelContent.Size = new System.Drawing.Size(1250, 465);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.gridControl2);
            this.myLayoutControl1.Controls.Add(this.txtNetSalary);
            this.myLayoutControl1.Controls.Add(this.txtTotalDeduction);
            this.myLayoutControl1.Controls.Add(this.txtGrossSalary);
            this.myLayoutControl1.Controls.Add(this.gridControlPayslipDeduction);
            this.myLayoutControl1.Controls.Add(this.gridControlPayslipTabEarning);
            this.myLayoutControl1.Controls.Add(this.txtPersonalRelief);
            this.myLayoutControl1.Controls.Add(this.txtGrossPAYE);
            this.myLayoutControl1.Controls.Add(this.txtTotalBasicHRA);
            this.myLayoutControl1.Controls.Add(this.cmbNSSF);
            this.myLayoutControl1.Controls.Add(this.cmbNHIFApplicable);
            this.myLayoutControl1.Controls.Add(this.txtIncomeType);
            this.myLayoutControl1.Controls.Add(this.txtPFValue);
            this.myLayoutControl1.Controls.Add(this.txtNSSFValue);
            this.myLayoutControl1.Controls.Add(this.txtNHIFValue);
            this.myLayoutControl1.Controls.Add(this.txtPAYEValue);
            this.myLayoutControl1.Controls.Add(this.txtNetTaxableIncome);
            this.myLayoutControl1.Controls.Add(this.gcPAYE_PAYERelief);
            this.myLayoutControl1.Controls.Add(this.txtTaxableIncome);
            this.myLayoutControl1.Controls.Add(this.gcPAYE_NonCashBenefit);
            this.myLayoutControl1.Controls.Add(this.txtTaxableGrossIncome);
            this.myLayoutControl1.Controls.Add(this.gcTaxableEarnings);
            this.myLayoutControl1.Controls.Add(this.txtHRAAmount);
            this.myLayoutControl1.Controls.Add(this.txtBasicSalary);
            this.myLayoutControl1.Controls.Add(this.gcPAYERelief);
            this.myLayoutControl1.Controls.Add(this.gcNonCashBenefit);
            this.myLayoutControl1.Controls.Add(this.lookUpVehicle_NonCashBenefit);
            this.myLayoutControl1.Controls.Add(this.txtMissedPunchDays);
            this.myLayoutControl1.Controls.Add(this.txtDateTitle);
            this.myLayoutControl1.Controls.Add(this.gcDeductions);
            this.myLayoutControl1.Controls.Add(this.txtLoanInstAmt);
            this.myLayoutControl1.Controls.Add(this.txtLateDays);
            this.myLayoutControl1.Controls.Add(this.gcEarnings);
            this.myLayoutControl1.Controls.Add(this.txtWeekendWorkedDays);
            this.myLayoutControl1.Controls.Add(this.txtLeaveEncashmentDays);
            this.myLayoutControl1.Controls.Add(this.txtNoticePayDays);
            this.myLayoutControl1.Controls.Add(this.txtAbsemtDays);
            this.myLayoutControl1.Controls.Add(this.txtDoubleOvertimeHours);
            this.myLayoutControl1.Controls.Add(this.txtNormalOvertimeHours);
            this.myLayoutControl1.Controls.Add(this.lookupEmployee);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem37});
            this.myLayoutControl1.Location = new System.Drawing.Point(2, 2);
            this.myLayoutControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.Root;
            this.myLayoutControl1.Size = new System.Drawing.Size(1246, 461);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(623, 67);
            this.gridControl2.MainView = this.gridView3;
            this.gridControl2.MenuManager = this.barManager1;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(604, 615);
            this.gridControl2.TabIndex = 53;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl2;
            this.gridView3.Name = "gridView3";
            // 
            // txtNetSalary
            // 
            this.txtNetSalary.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNetSalary.EnterMoveNextControl = true;
            this.txtNetSalary.Location = new System.Drawing.Point(770, 398);
            this.txtNetSalary.MenuManager = this.barManager1;
            this.txtNetSalary.Name = "txtNetSalary";
            this.txtNetSalary.Properties.Appearance.FontSizeDelta = 1;
            this.txtNetSalary.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtNetSalary.Properties.Appearance.Options.UseFont = true;
            this.txtNetSalary.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNetSalary.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNetSalary.Properties.DisplayFormat.FormatString = "n2";
            this.txtNetSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNetSalary.Properties.ReadOnly = true;
            this.txtNetSalary.Size = new System.Drawing.Size(447, 24);
            this.txtNetSalary.StyleController = this.myLayoutControl1;
            this.txtNetSalary.TabIndex = 57;
            this.txtNetSalary.TabStop = false;
            // 
            // txtTotalDeduction
            // 
            this.txtTotalDeduction.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalDeduction.EnterMoveNextControl = true;
            this.txtTotalDeduction.Location = new System.Drawing.Point(770, 370);
            this.txtTotalDeduction.MenuManager = this.barManager1;
            this.txtTotalDeduction.Name = "txtTotalDeduction";
            this.txtTotalDeduction.Properties.Appearance.FontSizeDelta = 1;
            this.txtTotalDeduction.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtTotalDeduction.Properties.Appearance.Options.UseFont = true;
            this.txtTotalDeduction.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalDeduction.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalDeduction.Properties.DisplayFormat.FormatString = "n2";
            this.txtTotalDeduction.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalDeduction.Properties.ReadOnly = true;
            this.txtTotalDeduction.Size = new System.Drawing.Size(447, 24);
            this.txtTotalDeduction.StyleController = this.myLayoutControl1;
            this.txtTotalDeduction.TabIndex = 56;
            this.txtTotalDeduction.TabStop = false;
            // 
            // txtGrossSalary
            // 
            this.txtGrossSalary.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGrossSalary.EnterMoveNextControl = true;
            this.txtGrossSalary.Location = new System.Drawing.Point(114, 370);
            this.txtGrossSalary.MenuManager = this.barManager1;
            this.txtGrossSalary.Name = "txtGrossSalary";
            this.txtGrossSalary.Properties.Appearance.FontSizeDelta = 1;
            this.txtGrossSalary.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtGrossSalary.Properties.Appearance.Options.UseFont = true;
            this.txtGrossSalary.Properties.Appearance.Options.UseTextOptions = true;
            this.txtGrossSalary.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtGrossSalary.Properties.DisplayFormat.FormatString = "n2";
            this.txtGrossSalary.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtGrossSalary.Properties.ReadOnly = true;
            this.txtGrossSalary.Size = new System.Drawing.Size(523, 24);
            this.txtGrossSalary.StyleController = this.myLayoutControl1;
            this.txtGrossSalary.TabIndex = 55;
            this.txtGrossSalary.TabStop = false;
            // 
            // gridControlPayslipDeduction
            // 
            this.gridControlPayslipDeduction.DataSource = this.PayslipTabDeductionBindingSource;
            this.gridControlPayslipDeduction.Location = new System.Drawing.Point(665, 101);
            this.gridControlPayslipDeduction.MainView = this.gridViewPayeSlipDeduction;
            this.gridControlPayslipDeduction.MenuManager = this.barManager1;
            this.gridControlPayslipDeduction.Name = "gridControlPayslipDeduction";
            this.gridControlPayslipDeduction.Size = new System.Drawing.Size(552, 265);
            this.gridControlPayslipDeduction.TabIndex = 54;
            this.gridControlPayslipDeduction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPayeSlipDeduction});
            // 
            // PayslipTabDeductionBindingSource
            // 
            this.PayslipTabDeductionBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_PayslipTabViewModel);
            // 
            // gridViewPayeSlipDeduction
            // 
            this.gridViewPayeSlipDeduction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName2,
            this.colQty1,
            this.colUnitName1,
            this.colAmount1});
            this.gridViewPayeSlipDeduction.GridControl = this.gridControlPayslipDeduction;
            this.gridViewPayeSlipDeduction.Name = "gridViewPayeSlipDeduction";
            this.gridViewPayeSlipDeduction.OptionsBehavior.Editable = false;
            this.gridViewPayeSlipDeduction.OptionsBehavior.ReadOnly = true;
            this.gridViewPayeSlipDeduction.OptionsView.ShowGroupPanel = false;
            // 
            // colItemName2
            // 
            this.colItemName2.FieldName = "Descr";
            this.colItemName2.Name = "colItemName2";
            this.colItemName2.Visible = true;
            this.colItemName2.VisibleIndex = 0;
            this.colItemName2.Width = 220;
            // 
            // colQty1
            // 
            this.colQty1.DisplayFormat.FormatString = "n2";
            this.colQty1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty1.FieldName = "Qty";
            this.colQty1.MaxWidth = 125;
            this.colQty1.MinWidth = 75;
            this.colQty1.Name = "colQty1";
            this.colQty1.Visible = true;
            this.colQty1.VisibleIndex = 1;
            this.colQty1.Width = 100;
            // 
            // colUnitName1
            // 
            this.colUnitName1.FieldName = "UnitName";
            this.colUnitName1.MaxWidth = 125;
            this.colUnitName1.MinWidth = 75;
            this.colUnitName1.Name = "colUnitName1";
            this.colUnitName1.Visible = true;
            this.colUnitName1.VisibleIndex = 2;
            this.colUnitName1.Width = 100;
            // 
            // colAmount1
            // 
            this.colAmount1.DisplayFormat.FormatString = "n2";
            this.colAmount1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount1.FieldName = "Amount";
            this.colAmount1.MaxWidth = 125;
            this.colAmount1.MinWidth = 75;
            this.colAmount1.Name = "colAmount1";
            this.colAmount1.Visible = true;
            this.colAmount1.VisibleIndex = 3;
            this.colAmount1.Width = 100;
            // 
            // gridControlPayslipTabEarning
            // 
            this.gridControlPayslipTabEarning.DataSource = this.PayslipTabEarningBindingSource;
            this.gridControlPayslipTabEarning.Location = new System.Drawing.Point(29, 101);
            this.gridControlPayslipTabEarning.MainView = this.gridViewPayeSlipTabEarning;
            this.gridControlPayslipTabEarning.MenuManager = this.barManager1;
            this.gridControlPayslipTabEarning.Name = "gridControlPayslipTabEarning";
            this.gridControlPayslipTabEarning.Size = new System.Drawing.Size(608, 265);
            this.gridControlPayslipTabEarning.TabIndex = 52;
            this.gridControlPayslipTabEarning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPayeSlipTabEarning});
            // 
            // PayslipTabEarningBindingSource
            // 
            this.PayslipTabEarningBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_PayslipTabViewModel);
            // 
            // gridViewPayeSlipTabEarning
            // 
            this.gridViewPayeSlipTabEarning.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName1,
            this.colQty,
            this.colUnitName,
            this.colAmount});
            this.gridViewPayeSlipTabEarning.GridControl = this.gridControlPayslipTabEarning;
            this.gridViewPayeSlipTabEarning.Name = "gridViewPayeSlipTabEarning";
            this.gridViewPayeSlipTabEarning.OptionsBehavior.Editable = false;
            this.gridViewPayeSlipTabEarning.OptionsBehavior.ReadOnly = true;
            this.gridViewPayeSlipTabEarning.OptionsView.ShowGroupPanel = false;
            // 
            // colItemName1
            // 
            this.colItemName1.FieldName = "Descr";
            this.colItemName1.Name = "colItemName1";
            this.colItemName1.Visible = true;
            this.colItemName1.VisibleIndex = 0;
            this.colItemName1.Width = 275;
            // 
            // colQty
            // 
            this.colQty.DisplayFormat.FormatString = "n2";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.MaxWidth = 125;
            this.colQty.MinWidth = 75;
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 1;
            this.colQty.Width = 100;
            // 
            // colUnitName
            // 
            this.colUnitName.FieldName = "UnitName";
            this.colUnitName.MaxWidth = 125;
            this.colUnitName.MinWidth = 75;
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.Visible = true;
            this.colUnitName.VisibleIndex = 2;
            this.colUnitName.Width = 100;
            // 
            // colAmount
            // 
            this.colAmount.DisplayFormat.FormatString = "n2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.MaxWidth = 125;
            this.colAmount.MinWidth = 75;
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 3;
            this.colAmount.Width = 100;
            // 
            // txtPersonalRelief
            // 
            this.txtPersonalRelief.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPersonalRelief.EnterMoveNextControl = true;
            this.txtPersonalRelief.Location = new System.Drawing.Point(835, 386);
            this.txtPersonalRelief.MaximumSize = new System.Drawing.Size(125, 0);
            this.txtPersonalRelief.MenuManager = this.barManager1;
            this.txtPersonalRelief.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtPersonalRelief.Name = "txtPersonalRelief";
            this.txtPersonalRelief.Properties.Mask.EditMask = "n2";
            this.txtPersonalRelief.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPersonalRelief.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPersonalRelief.Properties.ReadOnly = true;
            this.txtPersonalRelief.Size = new System.Drawing.Size(119, 22);
            this.txtPersonalRelief.StyleController = this.myLayoutControl1;
            this.txtPersonalRelief.TabIndex = 51;
            this.txtPersonalRelief.TabStop = false;
            // 
            // txtGrossPAYE
            // 
            this.txtGrossPAYE.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtGrossPAYE.EnterMoveNextControl = true;
            this.txtGrossPAYE.Location = new System.Drawing.Point(601, 386);
            this.txtGrossPAYE.MaximumSize = new System.Drawing.Size(125, 0);
            this.txtGrossPAYE.MenuManager = this.barManager1;
            this.txtGrossPAYE.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtGrossPAYE.Name = "txtGrossPAYE";
            this.txtGrossPAYE.Properties.Mask.EditMask = "n2";
            this.txtGrossPAYE.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtGrossPAYE.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtGrossPAYE.Properties.ReadOnly = true;
            this.txtGrossPAYE.Size = new System.Drawing.Size(125, 22);
            this.txtGrossPAYE.StyleController = this.myLayoutControl1;
            this.txtGrossPAYE.TabIndex = 50;
            this.txtGrossPAYE.TabStop = false;
            // 
            // txtTotalBasicHRA
            // 
            this.txtTotalBasicHRA.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotalBasicHRA.EnterMoveNextControl = true;
            this.txtTotalBasicHRA.Location = new System.Drawing.Point(367, 96);
            this.txtTotalBasicHRA.MenuManager = this.barManager1;
            this.txtTotalBasicHRA.Name = "txtTotalBasicHRA";
            this.txtTotalBasicHRA.Properties.Appearance.FontSizeDelta = 1;
            this.txtTotalBasicHRA.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtTotalBasicHRA.Properties.Appearance.Options.UseFont = true;
            this.txtTotalBasicHRA.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalBasicHRA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalBasicHRA.Properties.Mask.EditMask = "n2";
            this.txtTotalBasicHRA.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalBasicHRA.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalBasicHRA.Properties.ReadOnly = true;
            this.txtTotalBasicHRA.Size = new System.Drawing.Size(150, 24);
            this.txtTotalBasicHRA.StyleController = this.myLayoutControl1;
            this.txtTotalBasicHRA.TabIndex = 49;
            this.txtTotalBasicHRA.TabStop = false;
            // 
            // cmbNSSF
            // 
            this.cmbNSSF.EnterMoveNextControl = true;
            this.cmbNSSF.Location = new System.Drawing.Point(538, 68);
            this.cmbNSSF.MaximumSize = new System.Drawing.Size(150, 0);
            this.cmbNSSF.MinimumSize = new System.Drawing.Size(75, 0);
            this.cmbNSSF.Name = "cmbNSSF";
            this.cmbNSSF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNSSF.Properties.Items.AddRange(new object[] {
            "Not Applicable",
            "Applicable"});
            this.cmbNSSF.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbNSSF.Size = new System.Drawing.Size(138, 22);
            this.cmbNSSF.StyleController = this.myLayoutControl1;
            this.cmbNSSF.TabIndex = 48;
            // 
            // cmbNHIFApplicable
            // 
            this.cmbNHIFApplicable.EnterMoveNextControl = true;
            this.cmbNHIFApplicable.Location = new System.Drawing.Point(344, 68);
            this.cmbNHIFApplicable.MaximumSize = new System.Drawing.Size(150, 0);
            this.cmbNHIFApplicable.MinimumSize = new System.Drawing.Size(75, 0);
            this.cmbNHIFApplicable.Name = "cmbNHIFApplicable";
            this.cmbNHIFApplicable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNHIFApplicable.Properties.Items.AddRange(new object[] {
            "Not Applicable",
            "Applicable"});
            this.cmbNHIFApplicable.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbNHIFApplicable.Size = new System.Drawing.Size(150, 22);
            this.cmbNHIFApplicable.StyleController = this.myLayoutControl1;
            this.cmbNHIFApplicable.TabIndex = 47;
            // 
            // txtIncomeType
            // 
            this.txtIncomeType.EnterMoveNextControl = true;
            this.txtIncomeType.Location = new System.Drawing.Point(96, 68);
            this.txtIncomeType.Name = "txtIncomeType";
            this.txtIncomeType.Properties.ReadOnly = true;
            this.txtIncomeType.Size = new System.Drawing.Size(162, 22);
            this.txtIncomeType.StyleController = this.myLayoutControl1;
            this.txtIncomeType.TabIndex = 46;
            // 
            // txtPFValue
            // 
            this.txtPFValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPFValue.EnterMoveNextControl = true;
            this.txtPFValue.Location = new System.Drawing.Point(1013, 412);
            this.txtPFValue.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtPFValue.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtPFValue.Name = "txtPFValue";
            this.txtPFValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPFValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPFValue.Properties.Mask.EditMask = "n2";
            this.txtPFValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPFValue.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPFValue.Properties.ReadOnly = true;
            this.txtPFValue.Size = new System.Drawing.Size(150, 22);
            this.txtPFValue.StyleController = this.myLayoutControl1;
            this.txtPFValue.TabIndex = 45;
            // 
            // txtNSSFValue
            // 
            this.txtNSSFValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNSSFValue.EnterMoveNextControl = true;
            this.txtNSSFValue.Location = new System.Drawing.Point(601, 412);
            this.txtNSSFValue.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtNSSFValue.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtNSSFValue.Name = "txtNSSFValue";
            this.txtNSSFValue.Properties.Mask.EditMask = "n2";
            this.txtNSSFValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNSSFValue.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNSSFValue.Properties.ReadOnly = true;
            this.txtNSSFValue.Size = new System.Drawing.Size(125, 22);
            this.txtNSSFValue.StyleController = this.myLayoutControl1;
            this.txtNSSFValue.TabIndex = 44;
            // 
            // txtNHIFValue
            // 
            this.txtNHIFValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNHIFValue.EnterMoveNextControl = true;
            this.txtNHIFValue.Location = new System.Drawing.Point(835, 412);
            this.txtNHIFValue.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtNHIFValue.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtNHIFValue.Name = "txtNHIFValue";
            this.txtNHIFValue.Properties.Mask.EditMask = "n2";
            this.txtNHIFValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNHIFValue.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNHIFValue.Properties.ReadOnly = true;
            this.txtNHIFValue.Size = new System.Drawing.Size(119, 22);
            this.txtNHIFValue.StyleController = this.myLayoutControl1;
            this.txtNHIFValue.TabIndex = 43;
            // 
            // txtPAYEValue
            // 
            this.txtPAYEValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPAYEValue.EnterMoveNextControl = true;
            this.txtPAYEValue.Location = new System.Drawing.Point(1013, 386);
            this.txtPAYEValue.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtPAYEValue.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtPAYEValue.Name = "txtPAYEValue";
            this.txtPAYEValue.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPAYEValue.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPAYEValue.Properties.Mask.EditMask = "n2";
            this.txtPAYEValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPAYEValue.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPAYEValue.Properties.ReadOnly = true;
            this.txtPAYEValue.Size = new System.Drawing.Size(150, 22);
            this.txtPAYEValue.StyleController = this.myLayoutControl1;
            this.txtPAYEValue.TabIndex = 42;
            // 
            // txtNetTaxableIncome
            // 
            this.txtNetTaxableIncome.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNetTaxableIncome.EnterMoveNextControl = true;
            this.txtNetTaxableIncome.Location = new System.Drawing.Point(1013, 358);
            this.txtNetTaxableIncome.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtNetTaxableIncome.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtNetTaxableIncome.Name = "txtNetTaxableIncome";
            this.txtNetTaxableIncome.Properties.Appearance.FontSizeDelta = 1;
            this.txtNetTaxableIncome.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtNetTaxableIncome.Properties.Appearance.Options.UseFont = true;
            this.txtNetTaxableIncome.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNetTaxableIncome.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNetTaxableIncome.Properties.Mask.EditMask = "n2";
            this.txtNetTaxableIncome.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNetTaxableIncome.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNetTaxableIncome.Properties.ReadOnly = true;
            this.txtNetTaxableIncome.Size = new System.Drawing.Size(150, 24);
            this.txtNetTaxableIncome.StyleController = this.myLayoutControl1;
            this.txtNetTaxableIncome.TabIndex = 41;
            this.txtNetTaxableIncome.TabStop = false;
            // 
            // gcPAYE_PAYERelief
            // 
            this.gcPAYE_PAYERelief.DataSource = this.PAYEReliefeBindingSource;
            this.gcPAYE_PAYERelief.Location = new System.Drawing.Point(521, 225);
            this.gcPAYE_PAYERelief.MainView = this.gvPAYE_PAYERelief;
            this.gcPAYE_PAYERelief.MinimumSize = new System.Drawing.Size(300, 125);
            this.gcPAYE_PAYERelief.Name = "gcPAYE_PAYERelief";
            this.gcPAYE_PAYERelief.Size = new System.Drawing.Size(642, 129);
            this.gcPAYE_PAYERelief.TabIndex = 40;
            this.gcPAYE_PAYERelief.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPAYE_PAYERelief});
            // 
            // PAYEReliefeBindingSource
            // 
            this.PAYEReliefeBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_PAYEReliefeViewModel);
            // 
            // gvPAYE_PAYERelief
            // 
            this.gvPAYE_PAYERelief.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected1,
            this.colPAYEReliefName1,
            this.colPAYEReliefAmt1,
            this.colMonthlyLimit1});
            this.gvPAYE_PAYERelief.GridControl = this.gcPAYE_PAYERelief;
            this.gvPAYE_PAYERelief.Name = "gvPAYE_PAYERelief";
            this.gvPAYE_PAYERelief.OptionsBehavior.Editable = false;
            this.gvPAYE_PAYERelief.OptionsBehavior.ReadOnly = true;
            this.gvPAYE_PAYERelief.OptionsView.ShowGroupPanel = false;
            this.gvPAYE_PAYERelief.OptionsView.ShowViewCaption = true;
            this.gvPAYE_PAYERelief.ViewCaption = "PAYE Relief";
            // 
            // colSelected1
            // 
            this.colSelected1.FieldName = "Selected";
            this.colSelected1.Name = "colSelected1";
            // 
            // colPAYEReliefName1
            // 
            this.colPAYEReliefName1.FieldName = "PAYEReliefName";
            this.colPAYEReliefName1.Name = "colPAYEReliefName1";
            this.colPAYEReliefName1.Visible = true;
            this.colPAYEReliefName1.VisibleIndex = 0;
            // 
            // colPAYEReliefAmt1
            // 
            this.colPAYEReliefAmt1.DisplayFormat.FormatString = "n2";
            this.colPAYEReliefAmt1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPAYEReliefAmt1.FieldName = "PAYEReliefAmt";
            this.colPAYEReliefAmt1.MaxWidth = 150;
            this.colPAYEReliefAmt1.MinWidth = 75;
            this.colPAYEReliefAmt1.Name = "colPAYEReliefAmt1";
            this.colPAYEReliefAmt1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PAYEReliefAmt", "{0:n2}")});
            this.colPAYEReliefAmt1.Visible = true;
            this.colPAYEReliefAmt1.VisibleIndex = 1;
            // 
            // colMonthlyLimit1
            // 
            this.colMonthlyLimit1.FieldName = "MonthlyLimit";
            this.colMonthlyLimit1.Name = "colMonthlyLimit1";
            // 
            // txtTaxableIncome
            // 
            this.txtTaxableIncome.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTaxableIncome.EnterMoveNextControl = true;
            this.txtTaxableIncome.Location = new System.Drawing.Point(1013, 199);
            this.txtTaxableIncome.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtTaxableIncome.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtTaxableIncome.Name = "txtTaxableIncome";
            this.txtTaxableIncome.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtTaxableIncome.Properties.Appearance.Options.UseFont = true;
            this.txtTaxableIncome.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTaxableIncome.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTaxableIncome.Properties.Mask.EditMask = "n2";
            this.txtTaxableIncome.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTaxableIncome.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTaxableIncome.Properties.ReadOnly = true;
            this.txtTaxableIncome.Size = new System.Drawing.Size(150, 22);
            this.txtTaxableIncome.StyleController = this.myLayoutControl1;
            this.txtTaxableIncome.TabIndex = 39;
            this.txtTaxableIncome.TabStop = false;
            // 
            // gcPAYE_NonCashBenefit
            // 
            this.gcPAYE_NonCashBenefit.DataSource = this.PAYENoncashBenefitBindingSource;
            this.gcPAYE_NonCashBenefit.Location = new System.Drawing.Point(521, 68);
            this.gcPAYE_NonCashBenefit.MainView = this.gvPAYE_NonCashBenefit;
            this.gcPAYE_NonCashBenefit.MinimumSize = new System.Drawing.Size(300, 125);
            this.gcPAYE_NonCashBenefit.Name = "gcPAYE_NonCashBenefit";
            this.gcPAYE_NonCashBenefit.Size = new System.Drawing.Size(642, 127);
            this.gcPAYE_NonCashBenefit.TabIndex = 38;
            this.gcPAYE_NonCashBenefit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPAYE_NonCashBenefit});
            // 
            // PAYENoncashBenefitBindingSource
            // 
            this.PAYENoncashBenefitBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_NoncashBenefitViewModel);
            // 
            // gvPAYE_NonCashBenefit
            // 
            this.gvPAYE_NonCashBenefit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelected,
            this.colNonCashBenefitName,
            this.colRecurrning,
            this.colCostValue,
            this.colKRAValuePercentage,
            this.colKRAValue});
            this.gvPAYE_NonCashBenefit.GridControl = this.gcPAYE_NonCashBenefit;
            this.gvPAYE_NonCashBenefit.Name = "gvPAYE_NonCashBenefit";
            this.gvPAYE_NonCashBenefit.OptionsBehavior.Editable = false;
            this.gvPAYE_NonCashBenefit.OptionsBehavior.ReadOnly = true;
            this.gvPAYE_NonCashBenefit.OptionsView.ShowGroupPanel = false;
            this.gvPAYE_NonCashBenefit.OptionsView.ShowViewCaption = true;
            this.gvPAYE_NonCashBenefit.ViewCaption = "Non Cash Benefits";
            // 
            // colSelected
            // 
            this.colSelected.FieldName = "Selected";
            this.colSelected.Name = "colSelected";
            // 
            // colNonCashBenefitName
            // 
            this.colNonCashBenefitName.FieldName = "NonCashBenefitName";
            this.colNonCashBenefitName.Name = "colNonCashBenefitName";
            this.colNonCashBenefitName.Visible = true;
            this.colNonCashBenefitName.VisibleIndex = 0;
            this.colNonCashBenefitName.Width = 183;
            // 
            // colRecurrning
            // 
            this.colRecurrning.FieldName = "Recurrning";
            this.colRecurrning.Name = "colRecurrning";
            // 
            // colCostValue
            // 
            this.colCostValue.DisplayFormat.FormatString = "n2";
            this.colCostValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostValue.FieldName = "CostValue";
            this.colCostValue.MaxWidth = 150;
            this.colCostValue.MinWidth = 75;
            this.colCostValue.Name = "colCostValue";
            this.colCostValue.Visible = true;
            this.colCostValue.VisibleIndex = 1;
            this.colCostValue.Width = 99;
            // 
            // colKRAValuePercentage
            // 
            this.colKRAValuePercentage.DisplayFormat.FormatString = "p4";
            this.colKRAValuePercentage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKRAValuePercentage.FieldName = "KRAValuePercentage";
            this.colKRAValuePercentage.MaxWidth = 150;
            this.colKRAValuePercentage.MinWidth = 75;
            this.colKRAValuePercentage.Name = "colKRAValuePercentage";
            this.colKRAValuePercentage.Visible = true;
            this.colKRAValuePercentage.VisibleIndex = 2;
            this.colKRAValuePercentage.Width = 99;
            // 
            // colKRAValue
            // 
            this.colKRAValue.DisplayFormat.FormatString = "n2";
            this.colKRAValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKRAValue.FieldName = "KRAValue";
            this.colKRAValue.MaxWidth = 150;
            this.colKRAValue.MinWidth = 75;
            this.colKRAValue.Name = "colKRAValue";
            this.colKRAValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KRAValue", "{0:n2}")});
            this.colKRAValue.Visible = true;
            this.colKRAValue.VisibleIndex = 3;
            this.colKRAValue.Width = 100;
            // 
            // txtTaxableGrossIncome
            // 
            this.txtTaxableGrossIncome.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTaxableGrossIncome.EnterMoveNextControl = true;
            this.txtTaxableGrossIncome.Location = new System.Drawing.Point(367, 410);
            this.txtTaxableGrossIncome.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtTaxableGrossIncome.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtTaxableGrossIncome.Name = "txtTaxableGrossIncome";
            this.txtTaxableGrossIncome.Properties.Appearance.FontSizeDelta = 1;
            this.txtTaxableGrossIncome.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtTaxableGrossIncome.Properties.Appearance.Options.UseFont = true;
            this.txtTaxableGrossIncome.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTaxableGrossIncome.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTaxableGrossIncome.Properties.Mask.EditMask = "n2";
            this.txtTaxableGrossIncome.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTaxableGrossIncome.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTaxableGrossIncome.Properties.ReadOnly = true;
            this.txtTaxableGrossIncome.Size = new System.Drawing.Size(150, 24);
            this.txtTaxableGrossIncome.StyleController = this.myLayoutControl1;
            this.txtTaxableGrossIncome.TabIndex = 37;
            this.txtTaxableGrossIncome.TabStop = false;
            // 
            // gcTaxableEarnings
            // 
            this.gcTaxableEarnings.DataSource = this.PAYETaxableEarningBindingSource;
            this.gcTaxableEarnings.Location = new System.Drawing.Point(17, 124);
            this.gcTaxableEarnings.MainView = this.gvTaxableEarnings;
            this.gcTaxableEarnings.MaximumSize = new System.Drawing.Size(500, 0);
            this.gcTaxableEarnings.MinimumSize = new System.Drawing.Size(300, 100);
            this.gcTaxableEarnings.Name = "gcTaxableEarnings";
            this.gcTaxableEarnings.Size = new System.Drawing.Size(500, 282);
            this.gcTaxableEarnings.TabIndex = 36;
            this.gcTaxableEarnings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTaxableEarnings});
            // 
            // PAYETaxableEarningBindingSource
            // 
            this.PAYETaxableEarningBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_EarningAndDeductionsViewModel);
            // 
            // gvTaxableEarnings
            // 
            this.gvTaxableEarnings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEarningAndDeductionName,
            this.colValue});
            this.gvTaxableEarnings.GridControl = this.gcTaxableEarnings;
            this.gvTaxableEarnings.Name = "gvTaxableEarnings";
            this.gvTaxableEarnings.OptionsBehavior.Editable = false;
            this.gvTaxableEarnings.OptionsBehavior.ReadOnly = true;
            this.gvTaxableEarnings.OptionsView.ShowFooter = true;
            this.gvTaxableEarnings.OptionsView.ShowGroupPanel = false;
            this.gvTaxableEarnings.OptionsView.ShowViewCaption = true;
            this.gvTaxableEarnings.ViewCaption = "Taxable Earnings";
            // 
            // colEarningAndDeductionName
            // 
            this.colEarningAndDeductionName.FieldName = "EarningAndDeductionName";
            this.colEarningAndDeductionName.Name = "colEarningAndDeductionName";
            this.colEarningAndDeductionName.Visible = true;
            this.colEarningAndDeductionName.VisibleIndex = 0;
            // 
            // colValue
            // 
            this.colValue.DisplayFormat.FormatString = "n2";
            this.colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValue.FieldName = "Value";
            this.colValue.MaxWidth = 125;
            this.colValue.MinWidth = 75;
            this.colValue.Name = "colValue";
            this.colValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Value", "{0:n2}")});
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            // 
            // txtHRAAmount
            // 
            this.txtHRAAmount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHRAAmount.EnterMoveNextControl = true;
            this.txtHRAAmount.Location = new System.Drawing.Point(122, 96);
            this.txtHRAAmount.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtHRAAmount.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtHRAAmount.Name = "txtHRAAmount";
            this.txtHRAAmount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHRAAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtHRAAmount.Properties.Mask.EditMask = "n2";
            this.txtHRAAmount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHRAAmount.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHRAAmount.Properties.ReadOnly = true;
            this.txtHRAAmount.Size = new System.Drawing.Size(136, 22);
            this.txtHRAAmount.StyleController = this.myLayoutControl1;
            this.txtHRAAmount.TabIndex = 35;
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBasicSalary.EnterMoveNextControl = true;
            this.txtBasicSalary.Location = new System.Drawing.Point(367, 68);
            this.txtBasicSalary.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtBasicSalary.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Properties.Appearance.FontSizeDelta = 1;
            this.txtBasicSalary.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.txtBasicSalary.Properties.Appearance.Options.UseFont = true;
            this.txtBasicSalary.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBasicSalary.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBasicSalary.Properties.Mask.EditMask = "n2";
            this.txtBasicSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBasicSalary.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBasicSalary.Properties.ReadOnly = true;
            this.txtBasicSalary.Size = new System.Drawing.Size(150, 24);
            this.txtBasicSalary.StyleController = this.myLayoutControl1;
            this.txtBasicSalary.TabIndex = 34;
            // 
            // gcPAYERelief
            // 
            this.gcPAYERelief.DataSource = this.employeePayslipPAYEReliefeViewModelBindingSource;
            this.gcPAYERelief.Location = new System.Drawing.Point(721, 94);
            this.gcPAYERelief.MainView = this.gvPAYERelief;
            this.gcPAYERelief.MaximumSize = new System.Drawing.Size(500, 0);
            this.gcPAYERelief.MinimumSize = new System.Drawing.Size(300, 0);
            this.gcPAYERelief.Name = "gcPAYERelief";
            this.gcPAYERelief.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTxtReleifAmount});
            this.gcPAYERelief.Size = new System.Drawing.Size(500, 340);
            this.gcPAYERelief.TabIndex = 33;
            this.gcPAYERelief.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPAYERelief});
            // 
            // employeePayslipPAYEReliefeViewModelBindingSource
            // 
            this.employeePayslipPAYEReliefeViewModelBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_PAYEReliefeViewModel);
            // 
            // gvPAYERelief
            // 
            this.gvPAYERelief.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelectedPAYERelief,
            this.colPAYEReliefName,
            this.colMandatory,
            this.colPAYEReliefAmt,
            this.colMonthlyLimit,
            this.colAnnualLimit});
            this.gvPAYERelief.GridControl = this.gcPAYERelief;
            this.gvPAYERelief.Name = "gvPAYERelief";
            this.gvPAYERelief.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvPAYERelief.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvPAYERelief.OptionsNavigation.UseTabKey = false;
            this.gvPAYERelief.OptionsView.ShowGroupPanel = false;
            this.gvPAYERelief.OptionsView.ShowViewCaption = true;
            this.gvPAYERelief.ViewCaption = "PAYE Relief";
            this.gvPAYERelief.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvPAYERelief_ShowingEditor);
            this.gvPAYERelief.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvPAYERelief_ValidatingEditor);
            // 
            // colSelectedPAYERelief
            // 
            this.colSelectedPAYERelief.FieldName = "Selected";
            this.colSelectedPAYERelief.MaxWidth = 20;
            this.colSelectedPAYERelief.Name = "colSelectedPAYERelief";
            this.colSelectedPAYERelief.Visible = true;
            this.colSelectedPAYERelief.VisibleIndex = 0;
            this.colSelectedPAYERelief.Width = 20;
            // 
            // colPAYEReliefName
            // 
            this.colPAYEReliefName.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colPAYEReliefName.AppearanceCell.Options.UseBackColor = true;
            this.colPAYEReliefName.FieldName = "PAYEReliefName";
            this.colPAYEReliefName.MaxWidth = 500;
            this.colPAYEReliefName.MinWidth = 100;
            this.colPAYEReliefName.Name = "colPAYEReliefName";
            this.colPAYEReliefName.OptionsColumn.AllowEdit = false;
            this.colPAYEReliefName.OptionsColumn.ReadOnly = true;
            this.colPAYEReliefName.OptionsColumn.TabStop = false;
            this.colPAYEReliefName.Visible = true;
            this.colPAYEReliefName.VisibleIndex = 1;
            this.colPAYEReliefName.Width = 100;
            // 
            // colMandatory
            // 
            this.colMandatory.FieldName = "Mandatory";
            this.colMandatory.Name = "colMandatory";
            // 
            // colPAYEReliefAmt
            // 
            this.colPAYEReliefAmt.ColumnEdit = this.repositoryItemTxtReleifAmount;
            this.colPAYEReliefAmt.DisplayFormat.FormatString = "n2";
            this.colPAYEReliefAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPAYEReliefAmt.FieldName = "PAYEReliefAmt";
            this.colPAYEReliefAmt.MaxWidth = 125;
            this.colPAYEReliefAmt.MinWidth = 75;
            this.colPAYEReliefAmt.Name = "colPAYEReliefAmt";
            this.colPAYEReliefAmt.Visible = true;
            this.colPAYEReliefAmt.VisibleIndex = 3;
            // 
            // repositoryItemTxtReleifAmount
            // 
            this.repositoryItemTxtReleifAmount.AutoHeight = false;
            this.repositoryItemTxtReleifAmount.Mask.EditMask = "n2";
            this.repositoryItemTxtReleifAmount.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtReleifAmount.Name = "repositoryItemTxtReleifAmount";
            // 
            // colMonthlyLimit
            // 
            this.colMonthlyLimit.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colMonthlyLimit.AppearanceCell.Options.UseBackColor = true;
            this.colMonthlyLimit.DisplayFormat.FormatString = "n2";
            this.colMonthlyLimit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonthlyLimit.FieldName = "MonthlyLimit";
            this.colMonthlyLimit.MaxWidth = 125;
            this.colMonthlyLimit.MinWidth = 75;
            this.colMonthlyLimit.Name = "colMonthlyLimit";
            this.colMonthlyLimit.OptionsColumn.AllowEdit = false;
            this.colMonthlyLimit.OptionsColumn.ReadOnly = true;
            this.colMonthlyLimit.OptionsColumn.TabStop = false;
            this.colMonthlyLimit.Visible = true;
            this.colMonthlyLimit.VisibleIndex = 2;
            // 
            // colAnnualLimit
            // 
            this.colAnnualLimit.FieldName = "AnnualLimit";
            this.colAnnualLimit.Name = "colAnnualLimit";
            // 
            // gcNonCashBenefit
            // 
            this.gcNonCashBenefit.DataSource = this.employeePayslipNoncashBenefitViewModelBindingSource;
            this.gcNonCashBenefit.Location = new System.Drawing.Point(17, 94);
            this.gcNonCashBenefit.MainView = this.gvNonCashBenefit;
            this.gcNonCashBenefit.MaximumSize = new System.Drawing.Size(700, 0);
            this.gcNonCashBenefit.MinimumSize = new System.Drawing.Size(500, 0);
            this.gcNonCashBenefit.Name = "gcNonCashBenefit";
            this.gcNonCashBenefit.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTxtAmtNCB,
            this.repositoryItemTxtPercNCB});
            this.gcNonCashBenefit.Size = new System.Drawing.Size(700, 340);
            this.gcNonCashBenefit.TabIndex = 32;
            this.gcNonCashBenefit.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvNonCashBenefit});
            // 
            // employeePayslipNoncashBenefitViewModelBindingSource
            // 
            this.employeePayslipNoncashBenefitViewModelBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_NoncashBenefitViewModel);
            // 
            // gvNonCashBenefit
            // 
            this.gvNonCashBenefit.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelectedNonCashBenefit,
            this.colNonCashBenefitName1,
            this.colRecurrning1,
            this.colCostValue1,
            this.colKRAValuePercentage1,
            this.colKRAValue1});
            this.gvNonCashBenefit.CustomizationFormBounds = new System.Drawing.Rectangle(677, 207, 258, 261);
            this.gvNonCashBenefit.GridControl = this.gcNonCashBenefit;
            this.gvNonCashBenefit.Name = "gvNonCashBenefit";
            this.gvNonCashBenefit.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvNonCashBenefit.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvNonCashBenefit.OptionsNavigation.UseTabKey = false;
            this.gvNonCashBenefit.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gvNonCashBenefit.OptionsSelection.CheckBoxSelectorField = "Selected";
            this.gvNonCashBenefit.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gvNonCashBenefit.OptionsView.ShowGroupPanel = false;
            this.gvNonCashBenefit.OptionsView.ShowViewCaption = true;
            this.gvNonCashBenefit.ViewCaption = "Non Cash Benefits";
            this.gvNonCashBenefit.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvNonCashBenefit_RowCellStyle);
            this.gvNonCashBenefit.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvNonCashBenefit_ShowingEditor);
            // 
            // colSelectedNonCashBenefit
            // 
            this.colSelectedNonCashBenefit.Caption = " ";
            this.colSelectedNonCashBenefit.FieldName = "Selected";
            this.colSelectedNonCashBenefit.MaxWidth = 50;
            this.colSelectedNonCashBenefit.MinWidth = 30;
            this.colSelectedNonCashBenefit.Name = "colSelectedNonCashBenefit";
            this.colSelectedNonCashBenefit.Visible = true;
            this.colSelectedNonCashBenefit.VisibleIndex = 0;
            this.colSelectedNonCashBenefit.Width = 31;
            // 
            // colNonCashBenefitName1
            // 
            this.colNonCashBenefitName1.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colNonCashBenefitName1.AppearanceCell.Options.UseBackColor = true;
            this.colNonCashBenefitName1.FieldName = "NonCashBenefitName";
            this.colNonCashBenefitName1.Name = "colNonCashBenefitName1";
            this.colNonCashBenefitName1.OptionsColumn.TabStop = false;
            this.colNonCashBenefitName1.Visible = true;
            this.colNonCashBenefitName1.VisibleIndex = 1;
            this.colNonCashBenefitName1.Width = 134;
            // 
            // colRecurrning1
            // 
            this.colRecurrning1.FieldName = "Recurrning";
            this.colRecurrning1.MaxWidth = 100;
            this.colRecurrning1.MinWidth = 75;
            this.colRecurrning1.Name = "colRecurrning1";
            this.colRecurrning1.Visible = true;
            this.colRecurrning1.VisibleIndex = 2;
            this.colRecurrning1.Width = 90;
            // 
            // colCostValue1
            // 
            this.colCostValue1.ColumnEdit = this.repositoryItemTxtAmtNCB;
            this.colCostValue1.DisplayFormat.FormatString = "N2";
            this.colCostValue1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostValue1.FieldName = "CostValue";
            this.colCostValue1.MaxWidth = 125;
            this.colCostValue1.MinWidth = 75;
            this.colCostValue1.Name = "colCostValue1";
            this.colCostValue1.Visible = true;
            this.colCostValue1.VisibleIndex = 3;
            this.colCostValue1.Width = 125;
            // 
            // repositoryItemTxtAmtNCB
            // 
            this.repositoryItemTxtAmtNCB.AutoHeight = false;
            this.repositoryItemTxtAmtNCB.Mask.EditMask = "n2";
            this.repositoryItemTxtAmtNCB.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtAmtNCB.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtAmtNCB.Name = "repositoryItemTxtAmtNCB";
            // 
            // colKRAValuePercentage1
            // 
            this.colKRAValuePercentage1.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colKRAValuePercentage1.AppearanceCell.Options.UseBackColor = true;
            this.colKRAValuePercentage1.ColumnEdit = this.repositoryItemTxtPercNCB;
            this.colKRAValuePercentage1.DisplayFormat.FormatString = "p4";
            this.colKRAValuePercentage1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKRAValuePercentage1.FieldName = "KRAValuePercentage";
            this.colKRAValuePercentage1.MaxWidth = 125;
            this.colKRAValuePercentage1.MinWidth = 75;
            this.colKRAValuePercentage1.Name = "colKRAValuePercentage1";
            this.colKRAValuePercentage1.OptionsColumn.ReadOnly = true;
            this.colKRAValuePercentage1.OptionsColumn.TabStop = false;
            this.colKRAValuePercentage1.Visible = true;
            this.colKRAValuePercentage1.VisibleIndex = 4;
            this.colKRAValuePercentage1.Width = 125;
            // 
            // repositoryItemTxtPercNCB
            // 
            this.repositoryItemTxtPercNCB.AutoHeight = false;
            this.repositoryItemTxtPercNCB.Mask.EditMask = "p4";
            this.repositoryItemTxtPercNCB.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtPercNCB.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtPercNCB.Name = "repositoryItemTxtPercNCB";
            // 
            // colKRAValue1
            // 
            this.colKRAValue1.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colKRAValue1.AppearanceCell.Options.UseBackColor = true;
            this.colKRAValue1.ColumnEdit = this.repositoryItemTxtAmtNCB;
            this.colKRAValue1.DisplayFormat.FormatString = "N2";
            this.colKRAValue1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKRAValue1.FieldName = "KRAValue";
            this.colKRAValue1.MaxWidth = 125;
            this.colKRAValue1.MinWidth = 75;
            this.colKRAValue1.Name = "colKRAValue1";
            this.colKRAValue1.OptionsColumn.ReadOnly = true;
            this.colKRAValue1.OptionsColumn.TabStop = false;
            this.colKRAValue1.Visible = true;
            this.colKRAValue1.VisibleIndex = 5;
            this.colKRAValue1.Width = 125;
            // 
            // lookUpVehicle_NonCashBenefit
            // 
            this.lookUpVehicle_NonCashBenefit.EnterMoveNextControl = true;
            this.lookUpVehicle_NonCashBenefit.Location = new System.Drawing.Point(65, 68);
            this.lookUpVehicle_NonCashBenefit.MaximumSize = new System.Drawing.Size(500, 0);
            this.lookUpVehicle_NonCashBenefit.Name = "lookUpVehicle_NonCashBenefit";
            this.lookUpVehicle_NonCashBenefit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpVehicle_NonCashBenefit.Properties.NullText = "Select";
            this.lookUpVehicle_NonCashBenefit.Properties.PopupWidth = 500;
            this.lookUpVehicle_NonCashBenefit.Size = new System.Drawing.Size(241, 22);
            this.lookUpVehicle_NonCashBenefit.StyleController = this.myLayoutControl1;
            this.lookUpVehicle_NonCashBenefit.TabIndex = 30;
            this.lookUpVehicle_NonCashBenefit.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpVehicle_NonCashBenefit_Validating);
            // 
            // txtMissedPunchDays
            // 
            this.txtMissedPunchDays.EnterMoveNextControl = true;
            this.txtMissedPunchDays.Location = new System.Drawing.Point(481, 94);
            this.txtMissedPunchDays.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtMissedPunchDays.Name = "txtMissedPunchDays";
            this.txtMissedPunchDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMissedPunchDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtMissedPunchDays.Properties.Mask.EditMask = "n2";
            this.txtMissedPunchDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMissedPunchDays.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMissedPunchDays.Properties.NullText = "[Add in Absent]";
            this.txtMissedPunchDays.Properties.ReadOnly = true;
            this.txtMissedPunchDays.Size = new System.Drawing.Size(150, 22);
            this.txtMissedPunchDays.StyleController = this.myLayoutControl1;
            this.txtMissedPunchDays.TabIndex = 29;
            this.txtMissedPunchDays.TabStop = false;
            // 
            // txtDateTitle
            // 
            this.txtDateTitle.EnterMoveNextControl = true;
            this.txtDateTitle.Location = new System.Drawing.Point(69, 5);
            this.txtDateTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDateTitle.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtDateTitle.MinimumSize = new System.Drawing.Size(75, 0);
            this.txtDateTitle.Name = "txtDateTitle";
            this.txtDateTitle.Properties.ReadOnly = true;
            this.txtDateTitle.Size = new System.Drawing.Size(150, 22);
            this.txtDateTitle.StyleController = this.myLayoutControl1;
            this.txtDateTitle.TabIndex = 27;
            this.txtDateTitle.TabStop = false;
            // 
            // gcDeductions
            // 
            this.gcDeductions.DataSource = this.employeePayslipDeductionsBindingSource;
            this.gcDeductions.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeductions.Location = new System.Drawing.Point(17, 120);
            this.gcDeductions.MainView = this.gvDeductions;
            this.gcDeductions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcDeductions.MaximumSize = new System.Drawing.Size(500, 0);
            this.gcDeductions.Name = "gcDeductions";
            this.gcDeductions.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTxtAmt_Deduction});
            this.gcDeductions.Size = new System.Drawing.Size(388, 314);
            this.gcDeductions.TabIndex = 22;
            this.gcDeductions.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDeductions});
            // 
            // employeePayslipDeductionsBindingSource
            // 
            this.employeePayslipDeductionsBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_EarningAndDeductionsViewModel);
            // 
            // gvDeductions
            // 
            this.gvDeductions.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.gvDeductions.Appearance.Empty.Options.UseBackColor = true;
            this.gvDeductions.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvDeductions.DetailHeight = 295;
            this.gvDeductions.GridControl = this.gcDeductions;
            this.gvDeductions.Name = "gvDeductions";
            this.gvDeductions.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvDeductions.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvDeductions.OptionsSelection.UseIndicatorForSelection = false;
            this.gvDeductions.OptionsView.ShowFooter = true;
            this.gvDeductions.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.gridColumn1.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn1.FieldName = "EarningAndDeductionName";
            this.gridColumn1.MinWidth = 16;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsColumn.TabStop = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 58;
            // 
            // gridColumn2
            // 
            this.gridColumn2.ColumnEdit = this.repositoryItemTxtAmt_Deduction;
            this.gridColumn2.DisplayFormat.FormatString = "n2";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "Value";
            this.gridColumn2.MaxWidth = 150;
            this.gridColumn2.MinWidth = 16;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Value", "{0:n2}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 150;
            // 
            // repositoryItemTxtAmt_Deduction
            // 
            this.repositoryItemTxtAmt_Deduction.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtAmt_Deduction.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtAmt_Deduction.AutoHeight = false;
            this.repositoryItemTxtAmt_Deduction.Mask.EditMask = "n2";
            this.repositoryItemTxtAmt_Deduction.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtAmt_Deduction.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtAmt_Deduction.Name = "repositoryItemTxtAmt_Deduction";
            // 
            // txtLoanInstAmt
            // 
            this.txtLoanInstAmt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLoanInstAmt.EnterMoveNextControl = true;
            this.txtLoanInstAmt.Location = new System.Drawing.Point(172, 94);
            this.txtLoanInstAmt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLoanInstAmt.MaximumSize = new System.Drawing.Size(233, 0);
            this.txtLoanInstAmt.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtLoanInstAmt.Name = "txtLoanInstAmt";
            this.txtLoanInstAmt.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLoanInstAmt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtLoanInstAmt.Properties.Mask.EditMask = "n2";
            this.txtLoanInstAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLoanInstAmt.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtLoanInstAmt.Size = new System.Drawing.Size(233, 22);
            this.txtLoanInstAmt.StyleController = this.myLayoutControl1;
            this.txtLoanInstAmt.TabIndex = 21;
            // 
            // txtLateDays
            // 
            this.txtLateDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLateDays.EnterMoveNextControl = true;
            this.txtLateDays.Location = new System.Drawing.Point(172, 68);
            this.txtLateDays.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLateDays.MaximumSize = new System.Drawing.Size(233, 0);
            this.txtLateDays.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtLateDays.Name = "txtLateDays";
            this.txtLateDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLateDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtLateDays.Properties.Mask.EditMask = "n2";
            this.txtLateDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLateDays.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtLateDays.Size = new System.Drawing.Size(233, 22);
            this.txtLateDays.StyleController = this.myLayoutControl1;
            this.txtLateDays.TabIndex = 20;
            // 
            // gcEarnings
            // 
            this.gcEarnings.DataSource = this.employeePayslipEarningsBindingSource;
            this.gcEarnings.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcEarnings.Location = new System.Drawing.Point(17, 172);
            this.gcEarnings.MainView = this.gvEarnings;
            this.gcEarnings.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcEarnings.MaximumSize = new System.Drawing.Size(500, 0);
            this.gcEarnings.Name = "gcEarnings";
            this.gcEarnings.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTxtAmt});
            this.gcEarnings.Size = new System.Drawing.Size(500, 262);
            this.gcEarnings.TabIndex = 18;
            this.gcEarnings.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEarnings});
            this.gcEarnings.Click += new System.EventHandler(this.gcEarnings_Click);
            // 
            // employeePayslipEarningsBindingSource
            // 
            this.employeePayslipEarningsBindingSource.DataSource = typeof(Vision.Model.Payroll.EmployeePayslip_EarningAndDeductionsViewModel);
            // 
            // gvEarnings
            // 
            this.gvEarnings.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName,
            this.colItemValue});
            this.gvEarnings.DetailHeight = 295;
            this.gvEarnings.GridControl = this.gcEarnings;
            this.gvEarnings.Name = "gvEarnings";
            this.gvEarnings.OptionsBehavior.FocusLeaveOnTab = true;
            this.gvEarnings.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvEarnings.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvEarnings.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvEarnings.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvEarnings.OptionsSelection.UseIndicatorForSelection = false;
            this.gvEarnings.OptionsView.ShowFooter = true;
            this.gvEarnings.OptionsView.ShowGroupPanel = false;
            // 
            // colItemName
            // 
            this.colItemName.AppearanceCell.BackColor = System.Drawing.Color.Cornsilk;
            this.colItemName.AppearanceCell.Options.UseBackColor = true;
            this.colItemName.FieldName = "EarningAndDeductionName";
            this.colItemName.MinWidth = 16;
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowFocus = false;
            this.colItemName.OptionsColumn.ReadOnly = true;
            this.colItemName.OptionsColumn.TabStop = false;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 58;
            // 
            // colItemValue
            // 
            this.colItemValue.ColumnEdit = this.repositoryItemTxtAmt;
            this.colItemValue.DisplayFormat.FormatString = "n2";
            this.colItemValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colItemValue.FieldName = "Value";
            this.colItemValue.MaxWidth = 150;
            this.colItemValue.MinWidth = 16;
            this.colItemValue.Name = "colItemValue";
            this.colItemValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Value", "{0:n2}")});
            this.colItemValue.Visible = true;
            this.colItemValue.VisibleIndex = 1;
            this.colItemValue.Width = 58;
            // 
            // repositoryItemTxtAmt
            // 
            this.repositoryItemTxtAmt.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTxtAmt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.repositoryItemTxtAmt.AutoHeight = false;
            this.repositoryItemTxtAmt.Mask.EditMask = "n2";
            this.repositoryItemTxtAmt.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTxtAmt.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTxtAmt.Name = "repositoryItemTxtAmt";
            // 
            // txtWeekendWorkedDays
            // 
            this.txtWeekendWorkedDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWeekendWorkedDays.EnterMoveNextControl = true;
            this.txtWeekendWorkedDays.Location = new System.Drawing.Point(172, 146);
            this.txtWeekendWorkedDays.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtWeekendWorkedDays.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtWeekendWorkedDays.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtWeekendWorkedDays.Name = "txtWeekendWorkedDays";
            this.txtWeekendWorkedDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWeekendWorkedDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWeekendWorkedDays.Properties.Mask.EditMask = "n2";
            this.txtWeekendWorkedDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtWeekendWorkedDays.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtWeekendWorkedDays.Size = new System.Drawing.Size(150, 22);
            this.txtWeekendWorkedDays.StyleController = this.myLayoutControl1;
            this.txtWeekendWorkedDays.TabIndex = 17;
            // 
            // txtLeaveEncashmentDays
            // 
            this.txtLeaveEncashmentDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtLeaveEncashmentDays.EnterMoveNextControl = true;
            this.txtLeaveEncashmentDays.Location = new System.Drawing.Point(481, 120);
            this.txtLeaveEncashmentDays.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtLeaveEncashmentDays.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtLeaveEncashmentDays.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtLeaveEncashmentDays.Name = "txtLeaveEncashmentDays";
            this.txtLeaveEncashmentDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLeaveEncashmentDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtLeaveEncashmentDays.Properties.Mask.EditMask = "n2";
            this.txtLeaveEncashmentDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLeaveEncashmentDays.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtLeaveEncashmentDays.Size = new System.Drawing.Size(150, 22);
            this.txtLeaveEncashmentDays.StyleController = this.myLayoutControl1;
            this.txtLeaveEncashmentDays.TabIndex = 13;
            // 
            // txtNoticePayDays
            // 
            this.txtNoticePayDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNoticePayDays.EnterMoveNextControl = true;
            this.txtNoticePayDays.Location = new System.Drawing.Point(172, 120);
            this.txtNoticePayDays.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNoticePayDays.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtNoticePayDays.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtNoticePayDays.Name = "txtNoticePayDays";
            this.txtNoticePayDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNoticePayDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNoticePayDays.Properties.Mask.EditMask = "n2";
            this.txtNoticePayDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNoticePayDays.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNoticePayDays.Size = new System.Drawing.Size(150, 22);
            this.txtNoticePayDays.StyleController = this.myLayoutControl1;
            this.txtNoticePayDays.TabIndex = 12;
            // 
            // txtAbsemtDays
            // 
            this.txtAbsemtDays.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAbsemtDays.EnterMoveNextControl = true;
            this.txtAbsemtDays.Location = new System.Drawing.Point(172, 94);
            this.txtAbsemtDays.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtAbsemtDays.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtAbsemtDays.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtAbsemtDays.Name = "txtAbsemtDays";
            this.txtAbsemtDays.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAbsemtDays.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAbsemtDays.Properties.Mask.EditMask = "n2";
            this.txtAbsemtDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAbsemtDays.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAbsemtDays.Size = new System.Drawing.Size(150, 22);
            this.txtAbsemtDays.StyleController = this.myLayoutControl1;
            this.txtAbsemtDays.TabIndex = 11;
            // 
            // txtDoubleOvertimeHours
            // 
            this.txtDoubleOvertimeHours.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDoubleOvertimeHours.EnterMoveNextControl = true;
            this.txtDoubleOvertimeHours.Location = new System.Drawing.Point(481, 68);
            this.txtDoubleOvertimeHours.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDoubleOvertimeHours.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtDoubleOvertimeHours.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtDoubleOvertimeHours.Name = "txtDoubleOvertimeHours";
            this.txtDoubleOvertimeHours.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDoubleOvertimeHours.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDoubleOvertimeHours.Properties.Mask.EditMask = "n2";
            this.txtDoubleOvertimeHours.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDoubleOvertimeHours.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDoubleOvertimeHours.Size = new System.Drawing.Size(150, 22);
            this.txtDoubleOvertimeHours.StyleController = this.myLayoutControl1;
            this.txtDoubleOvertimeHours.TabIndex = 10;
            // 
            // txtNormalOvertimeHours
            // 
            this.txtNormalOvertimeHours.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNormalOvertimeHours.EnterMoveNextControl = true;
            this.txtNormalOvertimeHours.Location = new System.Drawing.Point(172, 68);
            this.txtNormalOvertimeHours.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNormalOvertimeHours.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtNormalOvertimeHours.MinimumSize = new System.Drawing.Size(78, 0);
            this.txtNormalOvertimeHours.Name = "txtNormalOvertimeHours";
            this.txtNormalOvertimeHours.Properties.Appearance.Options.UseTextOptions = true;
            this.txtNormalOvertimeHours.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtNormalOvertimeHours.Properties.Mask.EditMask = "n2";
            this.txtNormalOvertimeHours.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNormalOvertimeHours.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtNormalOvertimeHours.Size = new System.Drawing.Size(150, 22);
            this.txtNormalOvertimeHours.StyleController = this.myLayoutControl1;
            this.txtNormalOvertimeHours.TabIndex = 9;
            // 
            // lookupEmployee
            // 
            this.lookupEmployee.EnterMoveNextControl = true;
            this.lookupEmployee.Location = new System.Drawing.Point(290, 5);
            this.lookupEmployee.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lookupEmployee.MaximumSize = new System.Drawing.Size(389, 0);
            this.lookupEmployee.MinimumSize = new System.Drawing.Size(78, 0);
            this.lookupEmployee.Name = "lookupEmployee";
            this.lookupEmployee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmployee.Properties.NullText = "Select";
            this.lookupEmployee.Properties.PopupWidth = 1000;
            this.lookupEmployee.Size = new System.Drawing.Size(389, 22);
            this.lookupEmployee.StyleController = this.myLayoutControl1;
            this.lookupEmployee.TabIndex = 4;
            this.lookupEmployee.EditValueChanged += new System.EventHandler(this.lookupEmployee_EditValueChanged);
            this.lookupEmployee.Validating += new System.ComponentModel.CancelEventHandler(this.lookupEmployee_Validating);
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.gridControl2;
            this.layoutControlItem37.Location = new System.Drawing.Point(606, 0);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(608, 619);
            this.layoutControlItem37.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem37.TextVisible = false;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1,
            this.emptySpaceItem3,
            this.layoutControlItem21,
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.Root.Size = new System.Drawing.Size(1246, 461);
            this.Root.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 26);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcgEarnings;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1240, 419);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgEarnings,
            this.lcgDeductions,
            this.lcgNonCashBenefit,
            this.lcgPAYE,
            this.lcgPayslip});
            this.tabbedControlGroup1.Text = "Payslip";
            this.tabbedControlGroup1.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabbedControlGroup1_SelectedPageChanged);
            // 
            // lcgEarnings
            // 
            this.lcgEarnings.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem9,
            this.layoutControlItem14,
            this.emptySpaceItem4,
            this.layoutControlItem8,
            this.layoutControlItem3,
            this.emptySpaceItem7,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.lcgEarnings.Location = new System.Drawing.Point(0, 0);
            this.lcgEarnings.Name = "lcgEarnings";
            this.lcgEarnings.Size = new System.Drawing.Size(1216, 370);
            this.lcgEarnings.Text = "Earnings";
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtLeaveEncashmentDays;
            this.layoutControlItem10.Location = new System.Drawing.Point(309, 52);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem10.Text = "Leave Encashment (Days)";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(152, 16);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.gcEarnings;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(504, 266);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtNoticePayDays;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem9.Text = "Notice Pay (Days)";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(152, 16);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtWeekendWorkedDays;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem14.Text = "Weekend Worked (Days)";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(152, 16);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(504, 104);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(712, 266);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtAbsemtDays;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem8.Text = "Absent (Nof Days)";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(152, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtMissedPunchDays;
            this.layoutControlItem3.Location = new System.Drawing.Point(309, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem3.Text = "Missed Punch (Days)";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(152, 16);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(309, 78);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(309, 26);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(618, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(598, 104);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtNormalOvertimeHours;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem6.Text = "Normal Overtime (Hours)";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(152, 16);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtDoubleOvertimeHours;
            this.layoutControlItem7.Location = new System.Drawing.Point(309, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem7.Text = "Double Overtime (Hours)";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(152, 16);
            // 
            // lcgDeductions
            // 
            this.lcgDeductions.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem13,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.emptySpaceItem8});
            this.lcgDeductions.Location = new System.Drawing.Point(0, 0);
            this.lcgDeductions.Name = "lcgDeductions";
            this.lcgDeductions.Size = new System.Drawing.Size(1216, 370);
            this.lcgDeductions.Text = "Deductions";
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtLateDays;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(392, 26);
            this.layoutControlItem13.Text = "Latness (Days)";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(152, 16);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtLoanInstAmt;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(392, 26);
            this.layoutControlItem15.Text = "Loan Installment Amount";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(152, 16);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.gcDeductions;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(392, 318);
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextVisible = false;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(392, 0);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(824, 370);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgNonCashBenefit
            // 
            this.lcgNonCashBenefit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12,
            this.layoutControlItem5,
            this.emptySpaceItem5,
            this.layoutControlItem4,
            this.layoutControlItem32,
            this.layoutControlItem33});
            this.lcgNonCashBenefit.Location = new System.Drawing.Point(0, 0);
            this.lcgNonCashBenefit.Name = "lcgNonCashBenefit";
            this.lcgNonCashBenefit.Size = new System.Drawing.Size(1216, 370);
            this.lcgNonCashBenefit.Text = "Non Cash Benefits";
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.gcNonCashBenefit;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(704, 344);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gcPAYERelief;
            this.layoutControlItem5.Location = new System.Drawing.Point(704, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(512, 344);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(663, 0);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(553, 26);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lookUpVehicle_NonCashBenefit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(293, 26);
            this.layoutControlItem4.Text = "Vehicle";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(43, 16);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.cmbNHIFApplicable;
            this.layoutControlItem32.Location = new System.Drawing.Point(293, 0);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(188, 26);
            this.layoutControlItem32.Text = "NHIF";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(29, 16);
            this.layoutControlItem32.TextToControlDistance = 5;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.cmbNSSF;
            this.layoutControlItem33.Location = new System.Drawing.Point(481, 0);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(182, 26);
            this.layoutControlItem33.Text = "NSSF";
            this.layoutControlItem33.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(35, 16);
            this.layoutControlItem33.TextToControlDistance = 5;
            // 
            // lcgPAYE
            // 
            this.lcgPAYE.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem17,
            this.layoutControlItem19,
            this.layoutControlItem20,
            this.emptySpaceItem14,
            this.layoutControlItem31,
            this.emptySpaceItem10,
            this.layoutControlGroup1,
            this.layoutControlItem2,
            this.layoutControlItem18});
            this.lcgPAYE.Location = new System.Drawing.Point(0, 0);
            this.lcgPAYE.Name = "lcgPAYE";
            this.lcgPAYE.Size = new System.Drawing.Size(1216, 370);
            this.lcgPAYE.Text = "PAYE";
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem17.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem17.Control = this.txtBasicSalary;
            this.layoutControlItem17.Location = new System.Drawing.Point(245, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(259, 28);
            this.layoutControlItem17.Text = "Basic Salary";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.gcTaxableEarnings;
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 56);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(504, 286);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem20.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem20.Control = this.txtTaxableGrossIncome;
            this.layoutControlItem20.Location = new System.Drawing.Point(203, 342);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(301, 28);
            this.layoutControlItem20.Text = "Gross Taxable Income";
            this.layoutControlItem20.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(142, 16);
            this.layoutControlItem20.TextToControlDistance = 5;
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.AllowHotTrack = false;
            this.emptySpaceItem14.Location = new System.Drawing.Point(1150, 0);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Size = new System.Drawing.Size(66, 370);
            this.emptySpaceItem14.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.txtIncomeType;
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(245, 28);
            this.layoutControlItem31.Text = "Income Type";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(74, 16);
            this.layoutControlItem31.TextToControlDistance = 5;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(0, 342);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(203, 28);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem25,
            this.layoutControlItem26,
            this.layoutControlGroup5,
            this.layoutControlItem23,
            this.emptySpaceItem12,
            this.layoutControlItem24,
            this.layoutControlItem34,
            this.layoutControlItem35,
            this.emptySpaceItem13,
            this.layoutControlItem29,
            this.layoutControlItem28});
            this.layoutControlGroup1.Location = new System.Drawing.Point(504, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(646, 370);
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.gcPAYE_PAYERelief;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 157);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(646, 133);
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.AppearanceItemCaption.FontSizeDelta = 1;
            this.layoutControlItem26.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem26.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem26.Control = this.txtNetTaxableIncome;
            this.layoutControlItem26.Location = new System.Drawing.Point(347, 290);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(299, 28);
            this.layoutControlItem26.Text = "Net Taxable Income";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(140, 18);
            this.layoutControlItem26.TextToControlDistance = 5;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.GroupBordersVisible = false;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem27,
            this.layoutControlItem30});
            this.layoutControlGroup5.Location = new System.Drawing.Point(437, 318);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup5.Size = new System.Drawing.Size(209, 52);
            this.layoutControlGroup5.Text = "Tax Values";
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem27.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem27.Control = this.txtPAYEValue;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(209, 26);
            this.layoutControlItem27.Text = "PAYE";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(50, 16);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem30.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem30.Control = this.txtPFValue;
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(209, 26);
            this.layoutControlItem30.Text = "P.F.";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(50, 16);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.gcPAYE_NonCashBenefit;
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(646, 131);
            this.layoutControlItem23.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem23.TextVisible = false;
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.Location = new System.Drawing.Point(0, 131);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(337, 26);
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem24.Control = this.txtTaxableIncome;
            this.layoutControlItem24.Location = new System.Drawing.Point(337, 131);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(309, 26);
            this.layoutControlItem24.Text = "Gross Taxable Earnings";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(150, 16);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.txtGrossPAYE;
            this.layoutControlItem34.Location = new System.Drawing.Point(0, 318);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(209, 26);
            this.layoutControlItem34.Text = "Gross PAYE";
            this.layoutControlItem34.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(75, 16);
            this.layoutControlItem34.TextToControlDistance = 5;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.txtPersonalRelief;
            this.layoutControlItem35.Location = new System.Drawing.Point(209, 318);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(228, 26);
            this.layoutControlItem35.Text = "Personal Relief";
            this.layoutControlItem35.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem35.TextToControlDistance = 5;
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.Location = new System.Drawing.Point(0, 290);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(347, 28);
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem29.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem29.Control = this.txtNSSFValue;
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 344);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(209, 26);
            this.layoutControlItem29.Text = "NSSF";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(75, 16);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem28.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.layoutControlItem28.Control = this.txtNHIFValue;
            this.layoutControlItem28.Location = new System.Drawing.Point(209, 344);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(228, 26);
            this.layoutControlItem28.Text = "NHIF";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtTotalBasicHRA;
            this.layoutControlItem2.Location = new System.Drawing.Point(245, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(259, 28);
            this.layoutControlItem2.Text = "Total";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(100, 20);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtHRAAmount;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(245, 28);
            this.layoutControlItem18.Text = "HRA";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // lcgPayslip
            // 
            this.lcgPayslip.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.lcgPayslip.Location = new System.Drawing.Point(0, 0);
            this.lcgPayslip.Name = "lcgPayslip";
            this.lcgPayslip.Size = new System.Drawing.Size(1216, 370);
            this.lcgPayslip.Text = "Payslip";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem36,
            this.layoutControlItem39,
            this.emptySpaceItem2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(636, 370);
            this.layoutControlGroup3.Text = "Earnings";
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.gridControlPayslipTabEarning;
            this.layoutControlItem36.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(612, 269);
            this.layoutControlItem36.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem36.TextVisible = false;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem39.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem39.Control = this.txtGrossSalary;
            this.layoutControlItem39.Location = new System.Drawing.Point(0, 269);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(612, 28);
            this.layoutControlItem39.Text = "Gross Salary";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(80, 16);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 297);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(612, 28);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem38,
            this.layoutControlItem40,
            this.layoutControlItem41});
            this.layoutControlGroup4.Location = new System.Drawing.Point(636, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(580, 370);
            this.layoutControlGroup4.Text = "Deductions";
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.gridControlPayslipDeduction;
            this.layoutControlItem38.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(556, 269);
            this.layoutControlItem38.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem38.TextVisible = false;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem40.Control = this.txtTotalDeduction;
            this.layoutControlItem40.Location = new System.Drawing.Point(0, 269);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(556, 28);
            this.layoutControlItem40.Text = "Total Deduction";
            this.layoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(100, 16);
            this.layoutControlItem40.TextToControlDistance = 5;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.AppearanceItemCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlItem41.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem41.Control = this.txtNetSalary;
            this.layoutControlItem41.Location = new System.Drawing.Point(0, 297);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(556, 28);
            this.layoutControlItem41.Text = "Net Salary";
            this.layoutControlItem41.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem41.TextSize = new System.Drawing.Size(100, 20);
            this.layoutControlItem41.TextToControlDistance = 5;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 445);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(1240, 10);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtDateTitle;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(218, 26);
            this.layoutControlItem21.Text = "For Month";
            this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(59, 16);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lookupEmployee;
            this.layoutControlItem1.Location = new System.Drawing.Point(218, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1022, 26);
            this.layoutControlItem1.Text = "Employee";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(62, 11);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // frmEmployeePayslip
            // 
            this.AllowAddNew = true;
            this.AllowDeleteUI = false;
            this.AllowEditUI = false;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 551);
            this.FirstControl = this.myLayoutControl1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmEmployeePayslip";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Employee Payslip";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDeduction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayslipDeduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayslipTabDeductionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayeSlipDeduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPayslipTabEarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PayslipTabEarningBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPayeSlipTabEarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonalRelief.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrossPAYE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBasicHRA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNSSF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNHIFApplicable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncomeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPFValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNSSFValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNHIFValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPAYEValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNetTaxableIncome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYE_PAYERelief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYEReliefeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYE_PAYERelief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxableIncome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYE_NonCashBenefit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYENoncashBenefitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYE_NonCashBenefit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxableGrossIncome.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaxableEarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAYETaxableEarningBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTaxableEarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRAAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPAYERelief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipPAYEReliefeViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPAYERelief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtReleifAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcNonCashBenefit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipNoncashBenefitViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvNonCashBenefit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmtNCB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtPercNCB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpVehicle_NonCashBenefit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMissedPunchDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipDeductionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmt_Deduction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoanInstAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLateDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeePayslipEarningsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTxtAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekendWorkedDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeaveEncashmentDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoticePayDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbsemtDays.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoubleOvertimeHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNormalOvertimeHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDeductions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgNonCashBenefit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPAYE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPayslip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private Alit.WinformControls.LookUpEdit lookupEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Alit.WinformControls.TextEdit txtWeekendWorkedDays;
        private Alit.WinformControls.TextEdit txtLeaveEncashmentDays;
        private Alit.WinformControls.TextEdit txtNoticePayDays;
        private Alit.WinformControls.TextEdit txtAbsemtDays;
        private Alit.WinformControls.TextEdit txtDoubleOvertimeHours;
        private Alit.WinformControls.TextEdit txtNormalOvertimeHours;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup lcgEarnings;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraGrid.GridControl gcEarnings;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEarnings;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colItemValue;
        private DevExpress.XtraGrid.GridControl gcDeductions;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDeductions;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private Alit.WinformControls.TextEdit txtLoanInstAmt;
        private Alit.WinformControls.TextEdit txtLateDays;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDeductions;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlGroup lcgNonCashBenefit;
        private System.Windows.Forms.BindingSource employeePayslipNoncashBenefitViewModelBindingSource;
        private System.Windows.Forms.BindingSource employeePayslipDeductionsBindingSource;
        private System.Windows.Forms.BindingSource employeePayslipEarningsBindingSource;
        private Alit.WinformControls.TextEdit txtDateTitle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Alit.WinformControls.TextEdit txtMissedPunchDays;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private Alit.WinformControls.LookUpEdit lookUpVehicle_NonCashBenefit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtAmt;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtAmt_Deduction;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraGrid.GridControl gcNonCashBenefit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvNonCashBenefit;
        private DevExpress.XtraGrid.Columns.GridColumn colSelectedNonCashBenefit;
        private DevExpress.XtraGrid.Columns.GridColumn colNonCashBenefitName1;
        private DevExpress.XtraGrid.Columns.GridColumn colRecurrning1;
        private DevExpress.XtraGrid.Columns.GridColumn colCostValue1;
        private DevExpress.XtraGrid.Columns.GridColumn colKRAValuePercentage1;
        private DevExpress.XtraGrid.Columns.GridColumn colKRAValue1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtAmtNCB;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtPercNCB;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPAYE;
        private DevExpress.XtraGrid.GridControl gcPAYERelief;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPAYERelief;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource employeePayslipPAYEReliefeViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSelectedPAYERelief;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYEReliefName;
        private DevExpress.XtraGrid.Columns.GridColumn colMandatory;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthlyLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnualLimit;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYEReliefAmt;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTxtReleifAmount;
        private Alit.WinformControls.TextEdit txtNetTaxableIncome;
        private DevExpress.XtraGrid.GridControl gcPAYE_PAYERelief;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPAYE_PAYERelief;
        private Alit.WinformControls.TextEdit txtTaxableIncome;
        private DevExpress.XtraGrid.GridControl gcPAYE_NonCashBenefit;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPAYE_NonCashBenefit;
        private Alit.WinformControls.TextEdit txtTaxableGrossIncome;
        private DevExpress.XtraGrid.GridControl gcTaxableEarnings;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTaxableEarnings;
        private Alit.WinformControls.TextEdit txtHRAAmount;
        private Alit.WinformControls.TextEdit txtBasicSalary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private Alit.WinformControls.TextEdit txtPFValue;
        private Alit.WinformControls.TextEdit txtNSSFValue;
        private Alit.WinformControls.TextEdit txtNHIFValue;
        private Alit.WinformControls.TextEdit txtPAYEValue;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem14;
        private System.Windows.Forms.BindingSource PAYETaxableEarningBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEarningAndDeductionName;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private System.Windows.Forms.BindingSource PAYEReliefeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected1;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYEReliefName1;
        private DevExpress.XtraGrid.Columns.GridColumn colPAYEReliefAmt1;
        private DevExpress.XtraGrid.Columns.GridColumn colMonthlyLimit1;
        private System.Windows.Forms.BindingSource PAYENoncashBenefitBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSelected;
        private DevExpress.XtraGrid.Columns.GridColumn colNonCashBenefitName;
        private DevExpress.XtraGrid.Columns.GridColumn colRecurrning;
        private DevExpress.XtraGrid.Columns.GridColumn colCostValue;
        private DevExpress.XtraGrid.Columns.GridColumn colKRAValuePercentage;
        private DevExpress.XtraGrid.Columns.GridColumn colKRAValue;
        private Alit.WinformControls.TextEdit txtIncomeType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private Alit.WinformControls.ComboBoxEdit cmbNSSF;
        private Alit.WinformControls.ComboBoxEdit cmbNHIFApplicable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private Alit.WinformControls.TextEdit txtTotalBasicHRA;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Alit.WinformControls.TextEdit txtPersonalRelief;
        private Alit.WinformControls.TextEdit txtGrossPAYE;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPayslip;
        private DevExpress.XtraGrid.GridControl gridControlPayslipDeduction;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPayeSlipDeduction;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.GridControl gridControlPayslipTabEarning;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPayeSlipTabEarning;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.BindingSource PayslipTabEarningBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName1;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private System.Windows.Forms.BindingSource PayslipTabDeductionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName2;
        private DevExpress.XtraGrid.Columns.GridColumn colQty1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitName1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount1;
        private Alit.WinformControls.TextEdit txtNetSalary;
        private Alit.WinformControls.TextEdit txtTotalDeduction;
        private Alit.WinformControls.TextEdit txtGrossSalary;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
    }
}