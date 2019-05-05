namespace Vision.WinForm.Employee
{
    partial class frmEmployee
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
            this.cmbPFApplicable = new Alit.WinformControls.ComboBoxEdit();
            this.btnReinstateEmployee = new DevExpress.XtraEditors.SimpleButton();
            this.txtReinstatementReason = new Alit.WinformControls.TextEdit();
            this.deReinstateEmployeementDate = new Alit.WinformControls.DateEdit();
            this.btnTerminateEmployee = new DevExpress.XtraEditors.SimpleButton();
            this.txtTerminationReason = new Alit.WinformControls.TextEdit();
            this.deTerminationDate = new Alit.WinformControls.DateEdit();
            this.cmbTerminationType = new Alit.WinformControls.ComboBoxEdit();
            this.btnUpdateTimeAttendanceData = new DevExpress.XtraEditors.SimpleButton();
            this.cmbTAWeekendType = new Alit.WinformControls.ComboBoxEdit();
            this.lookupEmployeeShift = new Alit.WinformControls.LookUpEdit();
            this.cmbEmployeeShiftType = new Alit.WinformControls.ComboBoxEdit();
            this.gridControlLeaveOpeningBalance = new DevExpress.XtraGrid.GridControl();
            this.employeeLeaveOpeningBalanceViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewLeaveOpeningBalance = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLeaveTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpeningBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlServiceDetail = new DevExpress.XtraGrid.GridControl();
            this.employeeServiceDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridViewService = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmploymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmploymentEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeDesignationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMinimumWageCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeWIBAClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailyRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBasicSalary = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHousingAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekendAllowance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnNextPage = new DevExpress.XtraEditors.SimpleButton();
            this.txtBankCode = new Alit.WinformControls.TextEdit();
            this.cmbTAMissPunch = new Alit.WinformControls.ComboBoxEdit();
            this.cmbTAWeekEndAttendance = new Alit.WinformControls.ComboBoxEdit();
            this.cmbTANegativeLeave = new Alit.WinformControls.ComboBoxEdit();
            this.cmbTAOvertime = new Alit.WinformControls.ComboBoxEdit();
            this.cmbTAEarlyGoing = new Alit.WinformControls.ComboBoxEdit();
            this.cmbTALatenessCharges = new Alit.WinformControls.ComboBoxEdit();
            this.cmbTAAttendanceType = new Alit.WinformControls.ComboBoxEdit();
            this.lookupEmployeePrefix = new Alit.WinformControls.LookUpEdit();
            this.gridControlFamily = new DevExpress.XtraGrid.GridControl();
            this.gridViewFamily = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnRelationship = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditFamilyRelationship = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridControlDocument = new DevExpress.XtraGrid.GridControl();
            this.gridViewDocument = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColDocumentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonalDocumentRemoveRow = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRemovePersonalDocument = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.picEmployeeDocument = new Alit.WinformControls.PictureSelect();
            this.lookupEmployeeAccountingLedger = new Alit.WinformControls.LookUpEdit();
            this.lookBankUpCurrency = new Alit.WinformControls.LookUpEdit();
            this.lookUpBankBranch = new Alit.WinformControls.LookUpEdit();
            this.lookUpBankName = new Alit.WinformControls.LookUpEdit();
            this.txtBankAccountNo = new Alit.WinformControls.TextEdit();
            this.cmbPayCycle = new Alit.WinformControls.ComboBoxEdit();
            this.cmbPaymentMode = new Alit.WinformControls.ComboBoxEdit();
            this.lookupWIBAClass = new Alit.WinformControls.LookUpEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lookUpLocation = new Alit.WinformControls.LookUpEdit();
            this.lookUpMinimumWageCategory = new Alit.WinformControls.LookUpEdit();
            this.txtWeekendAllowance = new Alit.WinformControls.TextEdit();
            this.txtHousingAllowance = new Alit.WinformControls.TextEdit();
            this.txtBasicSalary = new Alit.WinformControls.TextEdit();
            this.cmbIncomeType = new Alit.WinformControls.ComboBoxEdit();
            this.txtDailyRate = new Alit.WinformControls.TextEdit();
            this.lookUpDepartment = new Alit.WinformControls.LookUpEdit();
            this.deContractExpiryDate = new Alit.WinformControls.DateEdit();
            this.cmbEmploymentType = new Alit.WinformControls.ComboBoxEdit();
            this.deEmploymentEffectiveDate = new Alit.WinformControls.DateEdit();
            this.txtPFNum = new Alit.WinformControls.TextEdit();
            this.txtPINNum = new Alit.WinformControls.TextEdit();
            this.txtNHIFNum = new Alit.WinformControls.TextEdit();
            this.txtNSSFNum = new Alit.WinformControls.TextEdit();
            this.txtIDNum = new Alit.WinformControls.TextEdit();
            this.picEmployeeImage = new Alit.WinformControls.PictureSelect();
            this.cmbMulticurrency = new Alit.WinformControls.ComboBoxEdit();
            this.txtEmail = new Alit.WinformControls.TextEdit();
            this.txtMpesaNo = new Alit.WinformControls.TextEdit();
            this.lookUpCity = new Alit.WinformControls.LookUpEdit();
            this.txtPOBoxNO = new Alit.WinformControls.TextEdit();
            this.txtAddress3 = new Alit.WinformControls.TextEdit();
            this.txtAddress2 = new Alit.WinformControls.TextEdit();
            this.txtAddress1 = new Alit.WinformControls.TextEdit();
            this.deWorkVisaExpiryDate = new Alit.WinformControls.DateEdit();
            this.cmbGender = new Alit.WinformControls.ComboBoxEdit();
            this.txtEmployeeOtherName = new Alit.WinformControls.TextEdit();
            this.txtEmployeeLastName = new Alit.WinformControls.TextEdit();
            this.lookupDesignation = new Alit.WinformControls.LookUpEdit();
            this.txtTACode = new Alit.WinformControls.TextEdit();
            this.txtEmployeeNo = new Alit.WinformControls.TextEdit();
            this.txtEmployeeName = new Alit.WinformControls.TextEdit();
            this.lookupCountry = new Alit.WinformControls.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroupEmployementDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lcgEmploymentType = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem70 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem56 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem60 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem61 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgTermination = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem63 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgTerminationControls = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem65 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem64 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem66 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcgReinstateEmployee = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem68 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem67 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem69 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem13 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem14 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem57 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup12 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroupPersonalDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup14 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem62 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup15 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup16 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem58 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroupPersonalDocument = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupFamilyDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroupServiceDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem59 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenuFormShortCuts = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).BeginInit();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).BeginInit();
            this.myLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPFApplicable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReinstatementReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReinstateEmployeementDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReinstateEmployeementDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerminationReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTerminationDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTerminationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerminationType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAWeekendType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployeeShift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployeeShiftType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeaveOpeningBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeLeaveOpeningBalanceViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveOpeningBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlServiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeServiceDetailViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAMissPunch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAWeekEndAttendance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTANegativeLeave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAOvertime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAEarlyGoing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTALatenessCharges.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAAttendanceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployeePrefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFamily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFamily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditFamilyRelationship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRemovePersonalDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployeeAccountingLedger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBankUpCurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBankBranch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBankName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccountNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPayCycle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaymentMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupWIBAClass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMinimumWageCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekendAllowance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHousingAllowance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIncomeType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDailyRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractExpiryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractExpiryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmploymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEmploymentEffectiveDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEmploymentEffectiveDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPFNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPINNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNHIFNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNSSFNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMulticurrency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMpesaNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOBoxNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWorkVisaExpiryDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWorkVisaExpiryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeOtherName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDesignation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTACode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCountry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEmployementDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEmploymentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgTermination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem63)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgTerminationControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem65)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem64)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgReinstateEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem68)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem67)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPersonalDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPersonalDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupFamilyDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupServiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.myLayoutControl1);
            this.panelContent.MaximumSize = new System.Drawing.Size(1500, 560);
            this.panelContent.Size = new System.Drawing.Size(1342, 560);
            // 
            // myLayoutControl1
            // 
            this.myLayoutControl1.Controls.Add(this.cmbPFApplicable);
            this.myLayoutControl1.Controls.Add(this.btnReinstateEmployee);
            this.myLayoutControl1.Controls.Add(this.txtReinstatementReason);
            this.myLayoutControl1.Controls.Add(this.deReinstateEmployeementDate);
            this.myLayoutControl1.Controls.Add(this.btnTerminateEmployee);
            this.myLayoutControl1.Controls.Add(this.txtTerminationReason);
            this.myLayoutControl1.Controls.Add(this.deTerminationDate);
            this.myLayoutControl1.Controls.Add(this.cmbTerminationType);
            this.myLayoutControl1.Controls.Add(this.btnUpdateTimeAttendanceData);
            this.myLayoutControl1.Controls.Add(this.cmbTAWeekendType);
            this.myLayoutControl1.Controls.Add(this.lookupEmployeeShift);
            this.myLayoutControl1.Controls.Add(this.cmbEmployeeShiftType);
            this.myLayoutControl1.Controls.Add(this.gridControlLeaveOpeningBalance);
            this.myLayoutControl1.Controls.Add(this.gridControlServiceDetail);
            this.myLayoutControl1.Controls.Add(this.btnNextPage);
            this.myLayoutControl1.Controls.Add(this.txtBankCode);
            this.myLayoutControl1.Controls.Add(this.cmbTAMissPunch);
            this.myLayoutControl1.Controls.Add(this.cmbTAWeekEndAttendance);
            this.myLayoutControl1.Controls.Add(this.cmbTANegativeLeave);
            this.myLayoutControl1.Controls.Add(this.cmbTAOvertime);
            this.myLayoutControl1.Controls.Add(this.cmbTAEarlyGoing);
            this.myLayoutControl1.Controls.Add(this.cmbTALatenessCharges);
            this.myLayoutControl1.Controls.Add(this.cmbTAAttendanceType);
            this.myLayoutControl1.Controls.Add(this.lookupEmployeePrefix);
            this.myLayoutControl1.Controls.Add(this.gridControlFamily);
            this.myLayoutControl1.Controls.Add(this.gridControlDocument);
            this.myLayoutControl1.Controls.Add(this.picEmployeeDocument);
            this.myLayoutControl1.Controls.Add(this.lookupEmployeeAccountingLedger);
            this.myLayoutControl1.Controls.Add(this.lookBankUpCurrency);
            this.myLayoutControl1.Controls.Add(this.lookUpBankBranch);
            this.myLayoutControl1.Controls.Add(this.lookUpBankName);
            this.myLayoutControl1.Controls.Add(this.txtBankAccountNo);
            this.myLayoutControl1.Controls.Add(this.cmbPayCycle);
            this.myLayoutControl1.Controls.Add(this.cmbPaymentMode);
            this.myLayoutControl1.Controls.Add(this.lookupWIBAClass);
            this.myLayoutControl1.Controls.Add(this.simpleButton1);
            this.myLayoutControl1.Controls.Add(this.lookUpLocation);
            this.myLayoutControl1.Controls.Add(this.lookUpMinimumWageCategory);
            this.myLayoutControl1.Controls.Add(this.txtWeekendAllowance);
            this.myLayoutControl1.Controls.Add(this.txtHousingAllowance);
            this.myLayoutControl1.Controls.Add(this.txtBasicSalary);
            this.myLayoutControl1.Controls.Add(this.cmbIncomeType);
            this.myLayoutControl1.Controls.Add(this.txtDailyRate);
            this.myLayoutControl1.Controls.Add(this.lookUpDepartment);
            this.myLayoutControl1.Controls.Add(this.deContractExpiryDate);
            this.myLayoutControl1.Controls.Add(this.cmbEmploymentType);
            this.myLayoutControl1.Controls.Add(this.deEmploymentEffectiveDate);
            this.myLayoutControl1.Controls.Add(this.txtPFNum);
            this.myLayoutControl1.Controls.Add(this.txtPINNum);
            this.myLayoutControl1.Controls.Add(this.txtNHIFNum);
            this.myLayoutControl1.Controls.Add(this.txtNSSFNum);
            this.myLayoutControl1.Controls.Add(this.txtIDNum);
            this.myLayoutControl1.Controls.Add(this.picEmployeeImage);
            this.myLayoutControl1.Controls.Add(this.cmbMulticurrency);
            this.myLayoutControl1.Controls.Add(this.txtEmail);
            this.myLayoutControl1.Controls.Add(this.txtMpesaNo);
            this.myLayoutControl1.Controls.Add(this.lookUpCity);
            this.myLayoutControl1.Controls.Add(this.txtPOBoxNO);
            this.myLayoutControl1.Controls.Add(this.txtAddress3);
            this.myLayoutControl1.Controls.Add(this.txtAddress2);
            this.myLayoutControl1.Controls.Add(this.txtAddress1);
            this.myLayoutControl1.Controls.Add(this.deWorkVisaExpiryDate);
            this.myLayoutControl1.Controls.Add(this.cmbGender);
            this.myLayoutControl1.Controls.Add(this.txtEmployeeOtherName);
            this.myLayoutControl1.Controls.Add(this.txtEmployeeLastName);
            this.myLayoutControl1.Controls.Add(this.lookupDesignation);
            this.myLayoutControl1.Controls.Add(this.txtTACode);
            this.myLayoutControl1.Controls.Add(this.txtEmployeeNo);
            this.myLayoutControl1.Controls.Add(this.txtEmployeeName);
            this.myLayoutControl1.Controls.Add(this.lookupCountry);
            this.myLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myLayoutControl1.Location = new System.Drawing.Point(3, 3);
            this.myLayoutControl1.Name = "myLayoutControl1";
            this.myLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 2, 650, 400);
            this.myLayoutControl1.OptionsView.HighlightFocusedItem = true;
            this.myLayoutControl1.Root = this.layoutControlGroup1;
            this.myLayoutControl1.Size = new System.Drawing.Size(1336, 554);
            this.myLayoutControl1.TabIndex = 0;
            this.myLayoutControl1.Text = "myLayoutControl1";
            // 
            // cmbPFApplicable
            // 
            this.cmbPFApplicable.EnterMoveNextControl = true;
            this.cmbPFApplicable.Location = new System.Drawing.Point(143, 114);
            this.cmbPFApplicable.MaximumSize = new System.Drawing.Size(125, 0);
            this.cmbPFApplicable.MenuManager = this.barManager1;
            this.cmbPFApplicable.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbPFApplicable.Name = "cmbPFApplicable";
            this.cmbPFApplicable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPFApplicable.Properties.DropDownRows = 2;
            this.cmbPFApplicable.Properties.Items.AddRange(new object[] {
            "Not Applicable",
            "Applicable"});
            this.cmbPFApplicable.Size = new System.Drawing.Size(125, 22);
            this.cmbPFApplicable.StyleController = this.myLayoutControl1;
            this.cmbPFApplicable.TabIndex = 28;
            this.cmbPFApplicable.SelectedIndexChanged += new System.EventHandler(this.cmbPFApplicable_SelectedIndexChanged);
            // 
            // btnReinstateEmployee
            // 
            this.btnReinstateEmployee.Location = new System.Drawing.Point(341, 476);
            this.btnReinstateEmployee.Name = "btnReinstateEmployee";
            this.btnReinstateEmployee.Size = new System.Drawing.Size(225, 23);
            this.btnReinstateEmployee.StyleController = this.myLayoutControl1;
            this.btnReinstateEmployee.TabIndex = 27;
            this.btnReinstateEmployee.Text = "Re-Instate Employement";
            this.btnReinstateEmployee.Click += new System.EventHandler(this.btnReinstateEmployee_Click);
            // 
            // txtReinstatementReason
            // 
            this.txtReinstatementReason.EnterMoveNextControl = true;
            this.txtReinstatementReason.Location = new System.Drawing.Point(411, 450);
            this.txtReinstatementReason.MenuManager = this.barManager1;
            this.txtReinstatementReason.Name = "txtReinstatementReason";
            this.txtReinstatementReason.Size = new System.Drawing.Size(155, 22);
            this.txtReinstatementReason.StyleController = this.myLayoutControl1;
            this.txtReinstatementReason.TabIndex = 26;
            // 
            // deReinstateEmployeementDate
            // 
            this.deReinstateEmployeementDate.EditValue = null;
            this.deReinstateEmployeementDate.EnterMoveNextControl = true;
            this.deReinstateEmployeementDate.Location = new System.Drawing.Point(411, 424);
            this.deReinstateEmployeementDate.MaximumSize = new System.Drawing.Size(125, 0);
            this.deReinstateEmployeementDate.MenuManager = this.barManager1;
            this.deReinstateEmployeementDate.MinimumSize = new System.Drawing.Size(75, 0);
            this.deReinstateEmployeementDate.Name = "deReinstateEmployeementDate";
            this.deReinstateEmployeementDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReinstateEmployeementDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deReinstateEmployeementDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deReinstateEmployeementDate.Size = new System.Drawing.Size(123, 22);
            this.deReinstateEmployeementDate.StyleController = this.myLayoutControl1;
            this.deReinstateEmployeementDate.TabIndex = 25;
            // 
            // btnTerminateEmployee
            // 
            this.btnTerminateEmployee.Location = new System.Drawing.Point(37, 502);
            this.btnTerminateEmployee.Name = "btnTerminateEmployee";
            this.btnTerminateEmployee.Size = new System.Drawing.Size(274, 23);
            this.btnTerminateEmployee.StyleController = this.myLayoutControl1;
            this.btnTerminateEmployee.TabIndex = 24;
            this.btnTerminateEmployee.Text = "Terminate Employee";
            this.btnTerminateEmployee.Click += new System.EventHandler(this.btnTerminateEmployee_Click);
            // 
            // txtTerminationReason
            // 
            this.txtTerminationReason.EnterMoveNextControl = true;
            this.txtTerminationReason.Location = new System.Drawing.Point(86, 476);
            this.txtTerminationReason.MaximumSize = new System.Drawing.Size(500, 0);
            this.txtTerminationReason.MenuManager = this.barManager1;
            this.txtTerminationReason.MinimumSize = new System.Drawing.Size(150, 0);
            this.txtTerminationReason.Name = "txtTerminationReason";
            this.txtTerminationReason.Properties.MaxLength = 50;
            this.txtTerminationReason.Size = new System.Drawing.Size(225, 22);
            this.txtTerminationReason.StyleController = this.myLayoutControl1;
            this.txtTerminationReason.TabIndex = 23;
            // 
            // deTerminationDate
            // 
            this.deTerminationDate.EditValue = null;
            this.deTerminationDate.EnterMoveNextControl = true;
            this.deTerminationDate.Location = new System.Drawing.Point(189, 450);
            this.deTerminationDate.MaximumSize = new System.Drawing.Size(125, 0);
            this.deTerminationDate.MenuManager = this.barManager1;
            this.deTerminationDate.MinimumSize = new System.Drawing.Size(75, 0);
            this.deTerminationDate.Name = "deTerminationDate";
            this.deTerminationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTerminationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTerminationDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deTerminationDate.Size = new System.Drawing.Size(122, 22);
            this.deTerminationDate.StyleController = this.myLayoutControl1;
            this.deTerminationDate.TabIndex = 22;
            // 
            // cmbTerminationType
            // 
            this.cmbTerminationType.EnterMoveNextControl = true;
            this.cmbTerminationType.Location = new System.Drawing.Point(189, 424);
            this.cmbTerminationType.MaximumSize = new System.Drawing.Size(125, 0);
            this.cmbTerminationType.MenuManager = this.barManager1;
            this.cmbTerminationType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTerminationType.Name = "cmbTerminationType";
            this.cmbTerminationType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTerminationType.Properties.Items.AddRange(new object[] {
            "N/A",
            "Resignation",
            "Termination"});
            this.cmbTerminationType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTerminationType.Size = new System.Drawing.Size(122, 22);
            this.cmbTerminationType.StyleController = this.myLayoutControl1;
            this.cmbTerminationType.TabIndex = 21;
            this.cmbTerminationType.SelectedIndexChanged += new System.EventHandler(this.cmbTerminationType_SelectedIndexChanged);
            // 
            // btnUpdateTimeAttendanceData
            // 
            this.btnUpdateTimeAttendanceData.Location = new System.Drawing.Point(294, 88);
            this.btnUpdateTimeAttendanceData.Name = "btnUpdateTimeAttendanceData";
            this.btnUpdateTimeAttendanceData.Size = new System.Drawing.Size(205, 23);
            this.btnUpdateTimeAttendanceData.StyleController = this.myLayoutControl1;
            this.btnUpdateTimeAttendanceData.TabIndex = 20;
            this.btnUpdateTimeAttendanceData.Text = "Update Time && Attendance Data";
            this.btnUpdateTimeAttendanceData.Click += new System.EventHandler(this.btnUpdateTimeAttendanceData_Click);
            // 
            // cmbTAWeekendType
            // 
            this.cmbTAWeekendType.EnterMoveNextControl = true;
            this.cmbTAWeekendType.Location = new System.Drawing.Point(761, 370);
            this.cmbTAWeekendType.MenuManager = this.barManager1;
            this.cmbTAWeekendType.Name = "cmbTAWeekendType";
            this.cmbTAWeekendType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTAWeekendType.Properties.Items.AddRange(new object[] {
            "Weekend",
            "Rest Day"});
            this.cmbTAWeekendType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTAWeekendType.Size = new System.Drawing.Size(107, 22);
            this.cmbTAWeekendType.StyleController = this.myLayoutControl1;
            this.cmbTAWeekendType.TabIndex = 19;
            // 
            // lookupEmployeeShift
            // 
            this.lookupEmployeeShift.EnterMoveNextControl = true;
            this.lookupEmployeeShift.Location = new System.Drawing.Point(761, 474);
            this.lookupEmployeeShift.MenuManager = this.barManager1;
            this.lookupEmployeeShift.Name = "lookupEmployeeShift";
            this.lookupEmployeeShift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmployeeShift.Properties.NullText = "Select";
            this.lookupEmployeeShift.Size = new System.Drawing.Size(107, 22);
            this.lookupEmployeeShift.StyleController = this.myLayoutControl1;
            this.lookupEmployeeShift.TabIndex = 18;
            // 
            // cmbEmployeeShiftType
            // 
            this.cmbEmployeeShiftType.EnterMoveNextControl = true;
            this.cmbEmployeeShiftType.Location = new System.Drawing.Point(761, 448);
            this.cmbEmployeeShiftType.MenuManager = this.barManager1;
            this.cmbEmployeeShiftType.Name = "cmbEmployeeShiftType";
            this.cmbEmployeeShiftType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEmployeeShiftType.Properties.Items.AddRange(new object[] {
            "Fixed",
            "Rotation"});
            this.cmbEmployeeShiftType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEmployeeShiftType.Size = new System.Drawing.Size(107, 22);
            this.cmbEmployeeShiftType.StyleController = this.myLayoutControl1;
            this.cmbEmployeeShiftType.TabIndex = 17;
            this.cmbEmployeeShiftType.SelectedIndexChanged += new System.EventHandler(this.cmbEmployeeShiftType_SelectedIndexChanged);
            // 
            // gridControlLeaveOpeningBalance
            // 
            this.gridControlLeaveOpeningBalance.DataSource = this.employeeLeaveOpeningBalanceViewModelBindingSource;
            this.gridControlLeaveOpeningBalance.Location = new System.Drawing.Point(912, 411);
            this.gridControlLeaveOpeningBalance.MainView = this.gridViewLeaveOpeningBalance;
            this.gridControlLeaveOpeningBalance.MenuManager = this.barManager1;
            this.gridControlLeaveOpeningBalance.Name = "gridControlLeaveOpeningBalance";
            this.gridControlLeaveOpeningBalance.Size = new System.Drawing.Size(356, 110);
            this.gridControlLeaveOpeningBalance.TabIndex = 16;
            this.gridControlLeaveOpeningBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLeaveOpeningBalance});
            // 
            // employeeLeaveOpeningBalanceViewModelBindingSource
            // 
            this.employeeLeaveOpeningBalanceViewModelBindingSource.DataSource = typeof(Vision.Model.Employee.EmployeeLeaveOpeningBalanceViewModel);
            // 
            // gridViewLeaveOpeningBalance
            // 
            this.gridViewLeaveOpeningBalance.Appearance.FocusedRow.BackColor = System.Drawing.Color.White;
            this.gridViewLeaveOpeningBalance.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewLeaveOpeningBalance.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewLeaveOpeningBalance.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewLeaveOpeningBalance.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.gridViewLeaveOpeningBalance.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.White;
            this.gridViewLeaveOpeningBalance.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewLeaveOpeningBalance.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLeaveTypeName,
            this.colOpeningBalance});
            this.gridViewLeaveOpeningBalance.GridControl = this.gridControlLeaveOpeningBalance;
            this.gridViewLeaveOpeningBalance.Name = "gridViewLeaveOpeningBalance";
            this.gridViewLeaveOpeningBalance.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewLeaveOpeningBalance.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewLeaveOpeningBalance.OptionsNavigation.UseTabKey = false;
            this.gridViewLeaveOpeningBalance.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewLeaveOpeningBalance.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridViewLeaveOpeningBalance.OptionsView.ShowColumnHeaders = false;
            this.gridViewLeaveOpeningBalance.OptionsView.ShowGroupPanel = false;
            this.gridViewLeaveOpeningBalance.OptionsView.ShowIndicator = false;
            this.gridViewLeaveOpeningBalance.RowHeight = 26;
            this.gridViewLeaveOpeningBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewLeaveOpeningBalance_KeyDown);
            this.gridViewLeaveOpeningBalance.GotFocus += new System.EventHandler(this.gridViewLeaveOpeningBalance_GotFocus);
            // 
            // colLeaveTypeName
            // 
            this.colLeaveTypeName.FieldName = "LeaveTypeName";
            this.colLeaveTypeName.MaxWidth = 150;
            this.colLeaveTypeName.MinWidth = 100;
            this.colLeaveTypeName.Name = "colLeaveTypeName";
            this.colLeaveTypeName.OptionsColumn.AllowEdit = false;
            this.colLeaveTypeName.OptionsColumn.ReadOnly = true;
            this.colLeaveTypeName.OptionsColumn.TabStop = false;
            this.colLeaveTypeName.Visible = true;
            this.colLeaveTypeName.VisibleIndex = 0;
            this.colLeaveTypeName.Width = 100;
            // 
            // colOpeningBalance
            // 
            this.colOpeningBalance.FieldName = "OpeningBalance";
            this.colOpeningBalance.Name = "colOpeningBalance";
            this.colOpeningBalance.Visible = true;
            this.colOpeningBalance.VisibleIndex = 1;
            // 
            // gridControlServiceDetail
            // 
            this.gridControlServiceDetail.DataSource = this.employeeServiceDetailViewModelBindingSource;
            this.gridControlServiceDetail.Location = new System.Drawing.Point(24, 48);
            this.gridControlServiceDetail.MainView = this.gridViewService;
            this.gridControlServiceDetail.MenuManager = this.barManager1;
            this.gridControlServiceDetail.Name = "gridControlServiceDetail";
            this.gridControlServiceDetail.Size = new System.Drawing.Size(1271, 500);
            this.gridControlServiceDetail.TabIndex = 15;
            this.gridControlServiceDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewService});
            // 
            // employeeServiceDetailViewModelBindingSource
            // 
            this.employeeServiceDetailViewModelBindingSource.DataSource = typeof(Vision.Model.Employee.EmployeeServiceDetailGridViewModel);
            // 
            // gridViewService
            // 
            this.gridViewService.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmploymentType,
            this.colEmploymentEffectiveDate,
            this.colContractExpiryDate,
            this.colEmployeeDepartmentName,
            this.colEmployeeDesignationName,
            this.colLocationName,
            this.colMinimumWageCategoryName,
            this.colEmployeeWIBAClassName,
            this.colDailyRate,
            this.colBasicSalary,
            this.colHousingAllowance,
            this.colWeekendAllowance});
            this.gridViewService.GridControl = this.gridControlServiceDetail;
            this.gridViewService.Name = "gridViewService";
            this.gridViewService.OptionsBehavior.Editable = false;
            this.gridViewService.OptionsBehavior.ReadOnly = true;
            this.gridViewService.OptionsView.ShowGroupPanel = false;
            // 
            // colEmploymentType
            // 
            this.colEmploymentType.Caption = "Emp. Type";
            this.colEmploymentType.FieldName = "EmploymentType";
            this.colEmploymentType.MinWidth = 100;
            this.colEmploymentType.Name = "colEmploymentType";
            this.colEmploymentType.Visible = true;
            this.colEmploymentType.VisibleIndex = 0;
            this.colEmploymentType.Width = 103;
            // 
            // colEmploymentEffectiveDate
            // 
            this.colEmploymentEffectiveDate.FieldName = "EmploymentEffectiveDate";
            this.colEmploymentEffectiveDate.MinWidth = 100;
            this.colEmploymentEffectiveDate.Name = "colEmploymentEffectiveDate";
            this.colEmploymentEffectiveDate.Visible = true;
            this.colEmploymentEffectiveDate.VisibleIndex = 1;
            this.colEmploymentEffectiveDate.Width = 103;
            // 
            // colContractExpiryDate
            // 
            this.colContractExpiryDate.FieldName = "ContractExpiryDate";
            this.colContractExpiryDate.MinWidth = 100;
            this.colContractExpiryDate.Name = "colContractExpiryDate";
            this.colContractExpiryDate.Visible = true;
            this.colContractExpiryDate.VisibleIndex = 2;
            this.colContractExpiryDate.Width = 103;
            // 
            // colEmployeeDepartmentName
            // 
            this.colEmployeeDepartmentName.FieldName = "EmployeeDepartmentName";
            this.colEmployeeDepartmentName.MinWidth = 100;
            this.colEmployeeDepartmentName.Name = "colEmployeeDepartmentName";
            this.colEmployeeDepartmentName.Visible = true;
            this.colEmployeeDepartmentName.VisibleIndex = 3;
            this.colEmployeeDepartmentName.Width = 124;
            // 
            // colEmployeeDesignationName
            // 
            this.colEmployeeDesignationName.FieldName = "EmployeeDesignationName";
            this.colEmployeeDesignationName.MinWidth = 100;
            this.colEmployeeDesignationName.Name = "colEmployeeDesignationName";
            this.colEmployeeDesignationName.Visible = true;
            this.colEmployeeDesignationName.VisibleIndex = 4;
            this.colEmployeeDesignationName.Width = 124;
            // 
            // colLocationName
            // 
            this.colLocationName.FieldName = "LocationName";
            this.colLocationName.MinWidth = 100;
            this.colLocationName.Name = "colLocationName";
            this.colLocationName.Visible = true;
            this.colLocationName.VisibleIndex = 5;
            this.colLocationName.Width = 124;
            // 
            // colMinimumWageCategoryName
            // 
            this.colMinimumWageCategoryName.FieldName = "MinimumWageCategoryName";
            this.colMinimumWageCategoryName.MinWidth = 100;
            this.colMinimumWageCategoryName.Name = "colMinimumWageCategoryName";
            this.colMinimumWageCategoryName.Visible = true;
            this.colMinimumWageCategoryName.VisibleIndex = 6;
            this.colMinimumWageCategoryName.Width = 124;
            // 
            // colEmployeeWIBAClassName
            // 
            this.colEmployeeWIBAClassName.FieldName = "EmployeeWIBAClassName";
            this.colEmployeeWIBAClassName.MinWidth = 100;
            this.colEmployeeWIBAClassName.Name = "colEmployeeWIBAClassName";
            this.colEmployeeWIBAClassName.Visible = true;
            this.colEmployeeWIBAClassName.VisibleIndex = 7;
            this.colEmployeeWIBAClassName.Width = 124;
            // 
            // colDailyRate
            // 
            this.colDailyRate.FieldName = "DailyRate";
            this.colDailyRate.MaxWidth = 125;
            this.colDailyRate.MinWidth = 100;
            this.colDailyRate.Name = "colDailyRate";
            this.colDailyRate.Visible = true;
            this.colDailyRate.VisibleIndex = 8;
            this.colDailyRate.Width = 125;
            // 
            // colBasicSalary
            // 
            this.colBasicSalary.FieldName = "BasicSalary";
            this.colBasicSalary.MaxWidth = 125;
            this.colBasicSalary.MinWidth = 100;
            this.colBasicSalary.Name = "colBasicSalary";
            this.colBasicSalary.Visible = true;
            this.colBasicSalary.VisibleIndex = 9;
            this.colBasicSalary.Width = 117;
            // 
            // colHousingAllowance
            // 
            this.colHousingAllowance.FieldName = "HousingAllowance";
            this.colHousingAllowance.MaxWidth = 150;
            this.colHousingAllowance.MinWidth = 100;
            this.colHousingAllowance.Name = "colHousingAllowance";
            this.colHousingAllowance.Visible = true;
            this.colHousingAllowance.VisibleIndex = 10;
            this.colHousingAllowance.Width = 150;
            // 
            // colWeekendAllowance
            // 
            this.colWeekendAllowance.FieldName = "WeekendAllowance";
            this.colWeekendAllowance.MaxWidth = 150;
            this.colWeekendAllowance.MinWidth = 100;
            this.colWeekendAllowance.Name = "colWeekendAllowance";
            this.colWeekendAllowance.Visible = true;
            this.colWeekendAllowance.VisibleIndex = 11;
            this.colWeekendAllowance.Width = 150;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(983, 247);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(258, 23);
            this.btnNextPage.StyleController = this.myLayoutControl1;
            this.btnNextPage.TabIndex = 14;
            this.btnNextPage.Text = "Next";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtBankCode
            // 
            this.txtBankCode.Enabled = false;
            this.txtBankCode.EnterMoveNextControl = true;
            this.txtBankCode.Location = new System.Drawing.Point(1054, 140);
            this.txtBankCode.MenuManager = this.barManager1;
            this.txtBankCode.Name = "txtBankCode";
            this.txtBankCode.Properties.ReadOnly = true;
            this.txtBankCode.Size = new System.Drawing.Size(227, 22);
            this.txtBankCode.StyleController = this.myLayoutControl1;
            this.txtBankCode.TabIndex = 13;
            this.txtBankCode.TabStop = false;
            // 
            // cmbTAMissPunch
            // 
            this.cmbTAMissPunch.EnterMoveNextControl = true;
            this.cmbTAMissPunch.Location = new System.Drawing.Point(761, 422);
            this.cmbTAMissPunch.MaximumSize = new System.Drawing.Size(300, 0);
            this.cmbTAMissPunch.MenuManager = this.barManager1;
            this.cmbTAMissPunch.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTAMissPunch.Name = "cmbTAMissPunch";
            this.cmbTAMissPunch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTAMissPunch.Properties.Items.AddRange(new object[] {
            "Abscent",
            "Present"});
            this.cmbTAMissPunch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTAMissPunch.Size = new System.Drawing.Size(107, 22);
            this.cmbTAMissPunch.StyleController = this.myLayoutControl1;
            this.cmbTAMissPunch.TabIndex = 12;
            // 
            // cmbTAWeekEndAttendance
            // 
            this.cmbTAWeekEndAttendance.EnterMoveNextControl = true;
            this.cmbTAWeekEndAttendance.Location = new System.Drawing.Point(761, 396);
            this.cmbTAWeekEndAttendance.MaximumSize = new System.Drawing.Size(300, 0);
            this.cmbTAWeekEndAttendance.MenuManager = this.barManager1;
            this.cmbTAWeekEndAttendance.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTAWeekEndAttendance.Name = "cmbTAWeekEndAttendance";
            this.cmbTAWeekEndAttendance.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTAWeekEndAttendance.Properties.Items.AddRange(new object[] {
            "N/A",
            "Overtime",
            "Allowance"});
            this.cmbTAWeekEndAttendance.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTAWeekEndAttendance.Size = new System.Drawing.Size(107, 22);
            this.cmbTAWeekEndAttendance.StyleController = this.myLayoutControl1;
            this.cmbTAWeekEndAttendance.TabIndex = 11;
            this.cmbTAWeekEndAttendance.SelectedIndexChanged += new System.EventHandler(this.cmbTAWeekEndAttendance_SelectedIndexChanged);
            // 
            // cmbTANegativeLeave
            // 
            this.cmbTANegativeLeave.EnterMoveNextControl = true;
            this.cmbTANegativeLeave.Location = new System.Drawing.Point(761, 344);
            this.cmbTANegativeLeave.MaximumSize = new System.Drawing.Size(300, 0);
            this.cmbTANegativeLeave.MenuManager = this.barManager1;
            this.cmbTANegativeLeave.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTANegativeLeave.Name = "cmbTANegativeLeave";
            this.cmbTANegativeLeave.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTANegativeLeave.Properties.Items.AddRange(new object[] {
            "Not Allowed",
            "Allowed"});
            this.cmbTANegativeLeave.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTANegativeLeave.Size = new System.Drawing.Size(107, 22);
            this.cmbTANegativeLeave.StyleController = this.myLayoutControl1;
            this.cmbTANegativeLeave.TabIndex = 9;
            // 
            // cmbTAOvertime
            // 
            this.cmbTAOvertime.EnterMoveNextControl = true;
            this.cmbTAOvertime.Location = new System.Drawing.Point(761, 318);
            this.cmbTAOvertime.MaximumSize = new System.Drawing.Size(300, 0);
            this.cmbTAOvertime.MenuManager = this.barManager1;
            this.cmbTAOvertime.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTAOvertime.Name = "cmbTAOvertime";
            this.cmbTAOvertime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTAOvertime.Properties.Items.AddRange(new object[] {
            "Not Applicable",
            "Applicable"});
            this.cmbTAOvertime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTAOvertime.Size = new System.Drawing.Size(107, 22);
            this.cmbTAOvertime.StyleController = this.myLayoutControl1;
            this.cmbTAOvertime.TabIndex = 8;
            // 
            // cmbTAEarlyGoing
            // 
            this.cmbTAEarlyGoing.EnterMoveNextControl = true;
            this.cmbTAEarlyGoing.Location = new System.Drawing.Point(761, 292);
            this.cmbTAEarlyGoing.MaximumSize = new System.Drawing.Size(300, 0);
            this.cmbTAEarlyGoing.MenuManager = this.barManager1;
            this.cmbTAEarlyGoing.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTAEarlyGoing.Name = "cmbTAEarlyGoing";
            this.cmbTAEarlyGoing.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTAEarlyGoing.Properties.Items.AddRange(new object[] {
            "Not Applicable",
            "Applicable"});
            this.cmbTAEarlyGoing.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTAEarlyGoing.Size = new System.Drawing.Size(107, 22);
            this.cmbTAEarlyGoing.StyleController = this.myLayoutControl1;
            this.cmbTAEarlyGoing.TabIndex = 7;
            // 
            // cmbTALatenessCharges
            // 
            this.cmbTALatenessCharges.EnterMoveNextControl = true;
            this.cmbTALatenessCharges.Location = new System.Drawing.Point(761, 266);
            this.cmbTALatenessCharges.MaximumSize = new System.Drawing.Size(300, 0);
            this.cmbTALatenessCharges.MenuManager = this.barManager1;
            this.cmbTALatenessCharges.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTALatenessCharges.Name = "cmbTALatenessCharges";
            this.cmbTALatenessCharges.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTALatenessCharges.Properties.Items.AddRange(new object[] {
            "Not Applicable",
            "Applicable"});
            this.cmbTALatenessCharges.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTALatenessCharges.Size = new System.Drawing.Size(107, 22);
            this.cmbTALatenessCharges.StyleController = this.myLayoutControl1;
            this.cmbTALatenessCharges.TabIndex = 6;
            // 
            // cmbTAAttendanceType
            // 
            this.cmbTAAttendanceType.EnterMoveNextControl = true;
            this.cmbTAAttendanceType.Location = new System.Drawing.Point(761, 240);
            this.cmbTAAttendanceType.MaximumSize = new System.Drawing.Size(300, 0);
            this.cmbTAAttendanceType.MenuManager = this.barManager1;
            this.cmbTAAttendanceType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbTAAttendanceType.Name = "cmbTAAttendanceType";
            this.cmbTAAttendanceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTAAttendanceType.Properties.Items.AddRange(new object[] {
            "Not Applicable",
            "Integrated",
            "Import"});
            this.cmbTAAttendanceType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbTAAttendanceType.Size = new System.Drawing.Size(107, 22);
            this.cmbTAAttendanceType.StyleController = this.myLayoutControl1;
            this.cmbTAAttendanceType.TabIndex = 5;
            // 
            // lookupEmployeePrefix
            // 
            this.lookupEmployeePrefix.EnterMoveNextControl = true;
            this.lookupEmployeePrefix.Location = new System.Drawing.Point(190, 62);
            this.lookupEmployeePrefix.MaximumSize = new System.Drawing.Size(200, 0);
            this.lookupEmployeePrefix.MenuManager = this.barManager1;
            this.lookupEmployeePrefix.Name = "lookupEmployeePrefix";
            this.lookupEmployeePrefix.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmployeePrefix.Properties.NullText = "Select";
            this.lookupEmployeePrefix.Size = new System.Drawing.Size(134, 22);
            this.lookupEmployeePrefix.StyleController = this.myLayoutControl1;
            this.lookupEmployeePrefix.TabIndex = 4;
            this.lookupEmployeePrefix.EditValueChanged += new System.EventHandler(this.lookupEmployeePrefix_EditValueChanged);
            this.lookupEmployeePrefix.Validating += new System.ComponentModel.CancelEventHandler(this.lookupEmployeePrefix_Validating);
            // 
            // gridControlFamily
            // 
            this.gridControlFamily.Location = new System.Drawing.Point(24, 48);
            this.gridControlFamily.MainView = this.gridViewFamily;
            this.gridControlFamily.MenuManager = this.barManager1;
            this.gridControlFamily.Name = "gridControlFamily";
            this.gridControlFamily.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemComboBox3,
            this.repositoryItemLookUpEditFamilyRelationship});
            this.gridControlFamily.Size = new System.Drawing.Size(1271, 500);
            this.gridControlFamily.TabIndex = 1;
            this.gridControlFamily.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFamily});
            // 
            // gridViewFamily
            // 
            this.gridViewFamily.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnRelationship,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridViewFamily.GridControl = this.gridControlFamily;
            this.gridViewFamily.Name = "gridViewFamily";
            this.gridViewFamily.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewFamily.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewFamily.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewFamily.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewFamily.OptionsNavigation.UseTabKey = false;
            this.gridViewFamily.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewFamily.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnRelationship
            // 
            this.gridColumnRelationship.Caption = "Relationship";
            this.gridColumnRelationship.ColumnEdit = this.repositoryItemLookUpEditFamilyRelationship;
            this.gridColumnRelationship.FieldName = "Relationship";
            this.gridColumnRelationship.Name = "gridColumnRelationship";
            this.gridColumnRelationship.Visible = true;
            this.gridColumnRelationship.VisibleIndex = 0;
            // 
            // repositoryItemLookUpEditFamilyRelationship
            // 
            this.repositoryItemLookUpEditFamilyRelationship.AutoHeight = false;
            this.repositoryItemLookUpEditFamilyRelationship.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditFamilyRelationship.Name = "repositoryItemLookUpEditFamilyRelationship";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Name";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Address";
            this.gridColumn3.FieldName = "Address";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "PO Box No";
            this.gridColumn4.FieldName = "POBoxNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "City ";
            this.gridColumn5.FieldName = "City";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Mobile No.";
            this.gridColumn6.FieldName = "MobileNo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Email Address";
            this.gridColumn7.FieldName = "Email";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Beneficiary %";
            this.gridColumn8.FieldName = "Beneficiary";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "husband",
            "wife",
            "father",
            "mother",
            "son",
            "daughter",
            "brother",
            "sister"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // gridControlDocument
            // 
            this.gridControlDocument.Location = new System.Drawing.Point(24, 48);
            this.gridControlDocument.MainView = this.gridViewDocument;
            this.gridControlDocument.MenuManager = this.barManager1;
            this.gridControlDocument.Name = "gridControlDocument";
            this.gridControlDocument.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRemovePersonalDocument});
            this.gridControlDocument.Size = new System.Drawing.Size(507, 500);
            this.gridControlDocument.TabIndex = 2;
            this.gridControlDocument.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDocument});
            // 
            // gridViewDocument
            // 
            this.gridViewDocument.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColDocumentName,
            this.colPersonalDocumentRemoveRow});
            this.gridViewDocument.GridControl = this.gridControlDocument;
            this.gridViewDocument.Name = "gridViewDocument";
            this.gridViewDocument.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDocument.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewDocument.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDocument.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDocument.OptionsNavigation.UseTabKey = false;
            this.gridViewDocument.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDocument.OptionsView.ShowGroupPanel = false;
            this.gridViewDocument.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDocument_FocusedRowChanged);
            // 
            // gridColDocumentName
            // 
            this.gridColDocumentName.Caption = "Document Name";
            this.gridColDocumentName.FieldName = "DocumentName";
            this.gridColDocumentName.Name = "gridColDocumentName";
            this.gridColDocumentName.Visible = true;
            this.gridColDocumentName.VisibleIndex = 0;
            this.gridColDocumentName.Width = 361;
            // 
            // colPersonalDocumentRemoveRow
            // 
            this.colPersonalDocumentRemoveRow.ColumnEdit = this.repositoryItemRemovePersonalDocument;
            this.colPersonalDocumentRemoveRow.MaxWidth = 20;
            this.colPersonalDocumentRemoveRow.Name = "colPersonalDocumentRemoveRow";
            this.colPersonalDocumentRemoveRow.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colPersonalDocumentRemoveRow.Visible = true;
            this.colPersonalDocumentRemoveRow.VisibleIndex = 1;
            this.colPersonalDocumentRemoveRow.Width = 20;
            // 
            // repositoryItemRemovePersonalDocument
            // 
            this.repositoryItemRemovePersonalDocument.AutoHeight = false;
            this.repositoryItemRemovePersonalDocument.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Clear)});
            this.repositoryItemRemovePersonalDocument.Name = "repositoryItemRemovePersonalDocument";
            this.repositoryItemRemovePersonalDocument.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemRemovePersonalDocument_ButtonClick);
            // 
            // picEmployeeDocument
            // 
            this.picEmployeeDocument.ImageChanged = true;
            this.picEmployeeDocument.ImageFileName = null;
            this.picEmployeeDocument.Location = new System.Drawing.Point(535, 48);
            this.picEmployeeDocument.MinimumSize = new System.Drawing.Size(50, 50);
            this.picEmployeeDocument.Name = "picEmployeeDocument";
            this.picEmployeeDocument.SelectedImage = null;
            this.picEmployeeDocument.Size = new System.Drawing.Size(760, 500);
            this.picEmployeeDocument.TabIndex = 3;
            this.picEmployeeDocument.ImageFileNameChange += new System.EventHandler(this.pictureSelect1_ImageFileNameChange);
            // 
            // lookupEmployeeAccountingLedger
            // 
            this.lookupEmployeeAccountingLedger.EnterMoveNextControl = true;
            this.lookupEmployeeAccountingLedger.Location = new System.Drawing.Point(243, 350);
            this.lookupEmployeeAccountingLedger.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookupEmployeeAccountingLedger.MenuManager = this.barManager1;
            this.lookupEmployeeAccountingLedger.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupEmployeeAccountingLedger.Name = "lookupEmployeeAccountingLedger";
            this.lookupEmployeeAccountingLedger.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmployeeAccountingLedger.Properties.NullText = "Select";
            this.lookupEmployeeAccountingLedger.Size = new System.Drawing.Size(332, 22);
            this.lookupEmployeeAccountingLedger.StyleController = this.myLayoutControl1;
            this.lookupEmployeeAccountingLedger.TabIndex = 1;
            this.lookupEmployeeAccountingLedger.Validating += new System.ComponentModel.CancelEventHandler(this.lookupEmployeeAccountingLedger_Validating);
            // 
            // lookBankUpCurrency
            // 
            this.lookBankUpCurrency.EnterMoveNextControl = true;
            this.lookBankUpCurrency.Location = new System.Drawing.Point(1054, 166);
            this.lookBankUpCurrency.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookBankUpCurrency.MenuManager = this.barManager1;
            this.lookBankUpCurrency.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookBankUpCurrency.Name = "lookBankUpCurrency";
            this.lookBankUpCurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookBankUpCurrency.Properties.NullText = "Select";
            this.lookBankUpCurrency.Size = new System.Drawing.Size(227, 22);
            this.lookBankUpCurrency.StyleController = this.myLayoutControl1;
            this.lookBankUpCurrency.TabIndex = 1;
            this.lookBankUpCurrency.Validating += new System.ComponentModel.CancelEventHandler(this.lookBankUpCurrency_Validating);
            // 
            // lookUpBankBranch
            // 
            this.lookUpBankBranch.EnterMoveNextControl = true;
            this.lookUpBankBranch.Location = new System.Drawing.Point(1054, 114);
            this.lookUpBankBranch.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookUpBankBranch.MenuManager = this.barManager1;
            this.lookUpBankBranch.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookUpBankBranch.Name = "lookUpBankBranch";
            this.lookUpBankBranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBankBranch.Properties.NullText = "Select";
            this.lookUpBankBranch.Size = new System.Drawing.Size(227, 22);
            this.lookUpBankBranch.StyleController = this.myLayoutControl1;
            this.lookUpBankBranch.TabIndex = 1;
            this.lookUpBankBranch.EditValueChanged += new System.EventHandler(this.lookUpBankBranch_EditValueChanged);
            this.lookUpBankBranch.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpBankBranch_Validating);
            // 
            // lookUpBankName
            // 
            this.lookUpBankName.EnterMoveNextControl = true;
            this.lookUpBankName.Location = new System.Drawing.Point(1054, 88);
            this.lookUpBankName.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookUpBankName.MenuManager = this.barManager1;
            this.lookUpBankName.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookUpBankName.Name = "lookUpBankName";
            this.lookUpBankName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpBankName.Properties.NullText = "Select";
            this.lookUpBankName.Size = new System.Drawing.Size(227, 22);
            this.lookUpBankName.StyleController = this.myLayoutControl1;
            this.lookUpBankName.TabIndex = 1;
            this.lookUpBankName.EditValueChanged += new System.EventHandler(this.lookUpBankName_EditValueChanged);
            this.lookUpBankName.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpBankName_Validating);
            // 
            // txtBankAccountNo
            // 
            this.txtBankAccountNo.EnterMoveNextControl = true;
            this.txtBankAccountNo.Location = new System.Drawing.Point(1054, 62);
            this.txtBankAccountNo.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtBankAccountNo.MenuManager = this.barManager1;
            this.txtBankAccountNo.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtBankAccountNo.Name = "txtBankAccountNo";
            this.txtBankAccountNo.Size = new System.Drawing.Size(227, 22);
            this.txtBankAccountNo.StyleController = this.myLayoutControl1;
            this.txtBankAccountNo.TabIndex = 1;
            this.txtBankAccountNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtBankAccountNo_Validating);
            // 
            // cmbPayCycle
            // 
            this.cmbPayCycle.EnterMoveNextControl = true;
            this.cmbPayCycle.Location = new System.Drawing.Point(667, 166);
            this.cmbPayCycle.MaximumSize = new System.Drawing.Size(400, 0);
            this.cmbPayCycle.MenuManager = this.barManager1;
            this.cmbPayCycle.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbPayCycle.Name = "cmbPayCycle";
            this.cmbPayCycle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPayCycle.Properties.DropDownRows = 3;
            this.cmbPayCycle.Properties.Items.AddRange(new object[] {
            "Weekly",
            "Fortnight",
            "Monthly"});
            this.cmbPayCycle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPayCycle.Size = new System.Drawing.Size(200, 22);
            this.cmbPayCycle.StyleController = this.myLayoutControl1;
            this.cmbPayCycle.TabIndex = 1;
            this.cmbPayCycle.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPayCycle_Validating);
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.EnterMoveNextControl = true;
            this.cmbPaymentMode.Location = new System.Drawing.Point(667, 140);
            this.cmbPaymentMode.MaximumSize = new System.Drawing.Size(400, 0);
            this.cmbPaymentMode.MenuManager = this.barManager1;
            this.cmbPaymentMode.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPaymentMode.Properties.DropDownRows = 3;
            this.cmbPaymentMode.Properties.Items.AddRange(new object[] {
            "Cash",
            "Cheque",
            "Bank Transfer",
            "mPAISA"});
            this.cmbPaymentMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPaymentMode.Size = new System.Drawing.Size(200, 22);
            this.cmbPaymentMode.StyleController = this.myLayoutControl1;
            this.cmbPaymentMode.TabIndex = 1;
            this.cmbPaymentMode.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPaymentMode_Validating);
            // 
            // lookupWIBAClass
            // 
            this.lookupWIBAClass.EnterMoveNextControl = true;
            this.lookupWIBAClass.Location = new System.Drawing.Point(243, 324);
            this.lookupWIBAClass.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookupWIBAClass.MenuManager = this.barManager1;
            this.lookupWIBAClass.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupWIBAClass.Name = "lookupWIBAClass";
            this.lookupWIBAClass.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupWIBAClass.Properties.NullText = "Select";
            this.lookupWIBAClass.Size = new System.Drawing.Size(332, 22);
            this.lookupWIBAClass.StyleController = this.myLayoutControl1;
            this.lookupWIBAClass.TabIndex = 1;
            this.lookupWIBAClass.Validating += new System.ComponentModel.CancelEventHandler(this.lookupWIBAClass_Validating);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(899, 350);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(319, 23);
            this.simpleButton1.StyleController = this.myLayoutControl1;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.TabStop = false;
            this.simpleButton1.Text = "Net Salary";
            // 
            // lookUpLocation
            // 
            this.lookUpLocation.EnterMoveNextControl = true;
            this.lookUpLocation.Location = new System.Drawing.Point(243, 246);
            this.lookUpLocation.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookUpLocation.MenuManager = this.barManager1;
            this.lookUpLocation.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookUpLocation.Name = "lookUpLocation";
            this.lookUpLocation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpLocation.Properties.NullText = "Select";
            this.lookUpLocation.Size = new System.Drawing.Size(332, 22);
            this.lookUpLocation.StyleController = this.myLayoutControl1;
            this.lookUpLocation.TabIndex = 1;
            this.lookUpLocation.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpLocation_Validating);
            // 
            // lookUpMinimumWageCategory
            // 
            this.lookUpMinimumWageCategory.EnterMoveNextControl = true;
            this.lookUpMinimumWageCategory.Location = new System.Drawing.Point(243, 298);
            this.lookUpMinimumWageCategory.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookUpMinimumWageCategory.MenuManager = this.barManager1;
            this.lookUpMinimumWageCategory.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookUpMinimumWageCategory.Name = "lookUpMinimumWageCategory";
            this.lookUpMinimumWageCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpMinimumWageCategory.Properties.NullText = "Select";
            this.lookUpMinimumWageCategory.Size = new System.Drawing.Size(332, 22);
            this.lookUpMinimumWageCategory.StyleController = this.myLayoutControl1;
            this.lookUpMinimumWageCategory.TabIndex = 1;
            this.lookUpMinimumWageCategory.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpMinimumWageCategory_Validating);
            // 
            // txtWeekendAllowance
            // 
            this.txtWeekendAllowance.EditValue = "0";
            this.txtWeekendAllowance.EnterMoveNextControl = true;
            this.txtWeekendAllowance.Location = new System.Drawing.Point(1064, 324);
            this.txtWeekendAllowance.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtWeekendAllowance.MenuManager = this.barManager1;
            this.txtWeekendAllowance.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtWeekendAllowance.Name = "txtWeekendAllowance";
            this.txtWeekendAllowance.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtWeekendAllowance.Properties.Appearance.Options.UseTextOptions = true;
            this.txtWeekendAllowance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtWeekendAllowance.Properties.Mask.EditMask = "n2";
            this.txtWeekendAllowance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtWeekendAllowance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtWeekendAllowance.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtWeekendAllowance.Size = new System.Drawing.Size(154, 22);
            this.txtWeekendAllowance.StyleController = this.myLayoutControl1;
            this.txtWeekendAllowance.TabIndex = 1;
            // 
            // txtHousingAllowance
            // 
            this.txtHousingAllowance.EditValue = "0";
            this.txtHousingAllowance.EnterMoveNextControl = true;
            this.txtHousingAllowance.Location = new System.Drawing.Point(1064, 298);
            this.txtHousingAllowance.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtHousingAllowance.MenuManager = this.barManager1;
            this.txtHousingAllowance.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtHousingAllowance.Name = "txtHousingAllowance";
            this.txtHousingAllowance.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtHousingAllowance.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHousingAllowance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtHousingAllowance.Properties.Mask.EditMask = "n2";
            this.txtHousingAllowance.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtHousingAllowance.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtHousingAllowance.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtHousingAllowance.Size = new System.Drawing.Size(154, 22);
            this.txtHousingAllowance.StyleController = this.myLayoutControl1;
            this.txtHousingAllowance.TabIndex = 1;
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.EditValue = "0";
            this.txtBasicSalary.EnterMoveNextControl = true;
            this.txtBasicSalary.Location = new System.Drawing.Point(1064, 272);
            this.txtBasicSalary.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtBasicSalary.MenuManager = this.barManager1;
            this.txtBasicSalary.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtBasicSalary.Properties.Appearance.Options.UseTextOptions = true;
            this.txtBasicSalary.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtBasicSalary.Properties.Mask.EditMask = "n2";
            this.txtBasicSalary.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBasicSalary.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtBasicSalary.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtBasicSalary.Size = new System.Drawing.Size(154, 22);
            this.txtBasicSalary.StyleController = this.myLayoutControl1;
            this.txtBasicSalary.TabIndex = 1;
            this.txtBasicSalary.EnabledChanged += new System.EventHandler(this.txtBasicSalary_EnabledChanged);
            this.txtBasicSalary.Validating += new System.ComponentModel.CancelEventHandler(this.txtBasicSalary_Validating);
            // 
            // cmbIncomeType
            // 
            this.cmbIncomeType.EnterMoveNextControl = true;
            this.cmbIncomeType.Location = new System.Drawing.Point(1064, 220);
            this.cmbIncomeType.MaximumSize = new System.Drawing.Size(200, 0);
            this.cmbIncomeType.MenuManager = this.barManager1;
            this.cmbIncomeType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbIncomeType.Name = "cmbIncomeType";
            this.cmbIncomeType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbIncomeType.Properties.DropDownRows = 3;
            this.cmbIncomeType.Properties.Items.AddRange(new object[] {
            "Primary ",
            "Secondary"});
            this.cmbIncomeType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbIncomeType.Size = new System.Drawing.Size(154, 22);
            this.cmbIncomeType.StyleController = this.myLayoutControl1;
            this.cmbIncomeType.TabIndex = 1;
            this.cmbIncomeType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbIncomeType_Validating);
            // 
            // txtDailyRate
            // 
            this.txtDailyRate.EditValue = "0";
            this.txtDailyRate.EnterMoveNextControl = true;
            this.txtDailyRate.Location = new System.Drawing.Point(1064, 246);
            this.txtDailyRate.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtDailyRate.MenuManager = this.barManager1;
            this.txtDailyRate.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtDailyRate.Name = "txtDailyRate";
            this.txtDailyRate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtDailyRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDailyRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDailyRate.Properties.Mask.EditMask = "n2";
            this.txtDailyRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDailyRate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDailyRate.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDailyRate.Size = new System.Drawing.Size(154, 22);
            this.txtDailyRate.StyleController = this.myLayoutControl1;
            this.txtDailyRate.TabIndex = 1;
            this.txtDailyRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtDailyRate_Validating);
            // 
            // lookUpDepartment
            // 
            this.lookUpDepartment.EnterMoveNextControl = true;
            this.lookUpDepartment.Location = new System.Drawing.Point(243, 220);
            this.lookUpDepartment.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookUpDepartment.MenuManager = this.barManager1;
            this.lookUpDepartment.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookUpDepartment.Name = "lookUpDepartment";
            this.lookUpDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDepartment.Properties.NullText = "Select";
            this.lookUpDepartment.Size = new System.Drawing.Size(332, 22);
            this.lookUpDepartment.StyleController = this.myLayoutControl1;
            this.lookUpDepartment.TabIndex = 1;
            this.lookUpDepartment.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpDepartment_Validating);
            // 
            // deContractExpiryDate
            // 
            this.deContractExpiryDate.EditValue = null;
            this.deContractExpiryDate.EnterMoveNextControl = true;
            this.deContractExpiryDate.Location = new System.Drawing.Point(717, 114);
            this.deContractExpiryDate.MaximumSize = new System.Drawing.Size(200, 0);
            this.deContractExpiryDate.MenuManager = this.barManager1;
            this.deContractExpiryDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.deContractExpiryDate.Name = "deContractExpiryDate";
            this.deContractExpiryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deContractExpiryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deContractExpiryDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deContractExpiryDate.Size = new System.Drawing.Size(150, 22);
            this.deContractExpiryDate.StyleController = this.myLayoutControl1;
            this.deContractExpiryDate.TabIndex = 1;
            this.deContractExpiryDate.Validating += new System.ComponentModel.CancelEventHandler(this.deContractExpiryDate_Validating);
            // 
            // cmbEmploymentType
            // 
            this.cmbEmploymentType.EnterMoveNextControl = true;
            this.cmbEmploymentType.Location = new System.Drawing.Point(717, 62);
            this.cmbEmploymentType.MaximumSize = new System.Drawing.Size(200, 0);
            this.cmbEmploymentType.MenuManager = this.barManager1;
            this.cmbEmploymentType.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbEmploymentType.Name = "cmbEmploymentType";
            this.cmbEmploymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEmploymentType.Properties.DropDownRows = 3;
            this.cmbEmploymentType.Properties.Items.AddRange(new object[] {
            "Casual",
            "Contract",
            "Permanent"});
            this.cmbEmploymentType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEmploymentType.Size = new System.Drawing.Size(150, 22);
            this.cmbEmploymentType.StyleController = this.myLayoutControl1;
            this.cmbEmploymentType.TabIndex = 1;
            this.cmbEmploymentType.SelectedIndexChanged += new System.EventHandler(this.cmbEmploymentType_SelectedIndexChanged);
            this.cmbEmploymentType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmploymentType_Validating);
            // 
            // deEmploymentEffectiveDate
            // 
            this.deEmploymentEffectiveDate.EditValue = null;
            this.deEmploymentEffectiveDate.EnterMoveNextControl = true;
            this.deEmploymentEffectiveDate.Location = new System.Drawing.Point(717, 88);
            this.deEmploymentEffectiveDate.MaximumSize = new System.Drawing.Size(200, 0);
            this.deEmploymentEffectiveDate.MenuManager = this.barManager1;
            this.deEmploymentEffectiveDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.deEmploymentEffectiveDate.Name = "deEmploymentEffectiveDate";
            this.deEmploymentEffectiveDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEmploymentEffectiveDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deEmploymentEffectiveDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deEmploymentEffectiveDate.Size = new System.Drawing.Size(150, 22);
            this.deEmploymentEffectiveDate.StyleController = this.myLayoutControl1;
            this.deEmploymentEffectiveDate.TabIndex = 1;
            this.deEmploymentEffectiveDate.Validating += new System.ComponentModel.CancelEventHandler(this.deEmploymentEffectiveDate_Validating);
            // 
            // txtPFNum
            // 
            this.txtPFNum.EnterMoveNextControl = true;
            this.txtPFNum.Location = new System.Drawing.Point(318, 114);
            this.txtPFNum.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtPFNum.MenuManager = this.barManager1;
            this.txtPFNum.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtPFNum.Name = "txtPFNum";
            this.txtPFNum.Properties.MaxLength = 50;
            this.txtPFNum.Size = new System.Drawing.Size(162, 22);
            this.txtPFNum.StyleController = this.myLayoutControl1;
            this.txtPFNum.TabIndex = 1;
            this.txtPFNum.Validating += new System.ComponentModel.CancelEventHandler(this.txtPFNum_Validating);
            // 
            // txtPINNum
            // 
            this.txtPINNum.EnterMoveNextControl = true;
            this.txtPINNum.Location = new System.Drawing.Point(143, 166);
            this.txtPINNum.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtPINNum.MenuManager = this.barManager1;
            this.txtPINNum.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtPINNum.Name = "txtPINNum";
            this.txtPINNum.Properties.MaxLength = 50;
            this.txtPINNum.Size = new System.Drawing.Size(337, 22);
            this.txtPINNum.StyleController = this.myLayoutControl1;
            this.txtPINNum.TabIndex = 1;
            this.txtPINNum.Validating += new System.ComponentModel.CancelEventHandler(this.txtPINNum_Validating);
            // 
            // txtNHIFNum
            // 
            this.txtNHIFNum.EnterMoveNextControl = true;
            this.txtNHIFNum.Location = new System.Drawing.Point(143, 88);
            this.txtNHIFNum.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtNHIFNum.MenuManager = this.barManager1;
            this.txtNHIFNum.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtNHIFNum.Name = "txtNHIFNum";
            this.txtNHIFNum.Properties.MaxLength = 50;
            this.txtNHIFNum.Size = new System.Drawing.Size(337, 22);
            this.txtNHIFNum.StyleController = this.myLayoutControl1;
            this.txtNHIFNum.TabIndex = 1;
            // 
            // txtNSSFNum
            // 
            this.txtNSSFNum.EnterMoveNextControl = true;
            this.txtNSSFNum.Location = new System.Drawing.Point(143, 140);
            this.txtNSSFNum.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtNSSFNum.MenuManager = this.barManager1;
            this.txtNSSFNum.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtNSSFNum.Name = "txtNSSFNum";
            this.txtNSSFNum.Properties.MaxLength = 50;
            this.txtNSSFNum.Size = new System.Drawing.Size(337, 22);
            this.txtNSSFNum.StyleController = this.myLayoutControl1;
            this.txtNSSFNum.TabIndex = 1;
            this.txtNSSFNum.Validating += new System.ComponentModel.CancelEventHandler(this.txtNSSFNum_Validating);
            // 
            // txtIDNum
            // 
            this.txtIDNum.EnterMoveNextControl = true;
            this.txtIDNum.Location = new System.Drawing.Point(143, 62);
            this.txtIDNum.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtIDNum.MenuManager = this.barManager1;
            this.txtIDNum.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtIDNum.Name = "txtIDNum";
            this.txtIDNum.Properties.MaxLength = 50;
            this.txtIDNum.Size = new System.Drawing.Size(337, 22);
            this.txtIDNum.StyleController = this.myLayoutControl1;
            this.txtIDNum.TabIndex = 1;
            this.txtIDNum.Validating += new System.ComponentModel.CancelEventHandler(this.txtIDNum_Validating);
            // 
            // picEmployeeImage
            // 
            this.picEmployeeImage.ImageChanged = true;
            this.picEmployeeImage.ImageFileName = null;
            this.picEmployeeImage.Location = new System.Drawing.Point(997, 62);
            this.picEmployeeImage.MaximumSize = new System.Drawing.Size(230, 200);
            this.picEmployeeImage.MinimumSize = new System.Drawing.Size(230, 50);
            this.picEmployeeImage.Name = "picEmployeeImage";
            this.picEmployeeImage.SelectedImage = null;
            this.picEmployeeImage.Size = new System.Drawing.Size(230, 167);
            this.picEmployeeImage.TabIndex = 1;
            this.picEmployeeImage.TabStop = false;
            // 
            // cmbMulticurrency
            // 
            this.cmbMulticurrency.EnterMoveNextControl = true;
            this.cmbMulticurrency.Location = new System.Drawing.Point(693, 244);
            this.cmbMulticurrency.MaximumSize = new System.Drawing.Size(400, 0);
            this.cmbMulticurrency.MenuManager = this.barManager1;
            this.cmbMulticurrency.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbMulticurrency.Name = "cmbMulticurrency";
            this.cmbMulticurrency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMulticurrency.Properties.DropDownRows = 3;
            this.cmbMulticurrency.Properties.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbMulticurrency.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbMulticurrency.Size = new System.Drawing.Size(272, 22);
            this.cmbMulticurrency.StyleController = this.myLayoutControl1;
            this.cmbMulticurrency.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.EnterMoveNextControl = true;
            this.txtEmail.Location = new System.Drawing.Point(693, 218);
            this.txtEmail.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtEmail.MenuManager = this.barManager1;
            this.txtEmail.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(272, 22);
            this.txtEmail.StyleController = this.myLayoutControl1;
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtMpesaNo
            // 
            this.txtMpesaNo.EnterMoveNextControl = true;
            this.txtMpesaNo.Location = new System.Drawing.Point(693, 192);
            this.txtMpesaNo.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtMpesaNo.MenuManager = this.barManager1;
            this.txtMpesaNo.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtMpesaNo.Name = "txtMpesaNo";
            this.txtMpesaNo.Size = new System.Drawing.Size(272, 22);
            this.txtMpesaNo.StyleController = this.myLayoutControl1;
            this.txtMpesaNo.TabIndex = 1;
            this.txtMpesaNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMpesaNo_Validating);
            // 
            // lookUpCity
            // 
            this.lookUpCity.EnterMoveNextControl = true;
            this.lookUpCity.Location = new System.Drawing.Point(693, 166);
            this.lookUpCity.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookUpCity.MenuManager = this.barManager1;
            this.lookUpCity.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookUpCity.Name = "lookUpCity";
            this.lookUpCity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpCity.Properties.NullText = "Select";
            this.lookUpCity.Size = new System.Drawing.Size(272, 22);
            this.lookUpCity.StyleController = this.myLayoutControl1;
            this.lookUpCity.TabIndex = 1;
            this.lookUpCity.Validating += new System.ComponentModel.CancelEventHandler(this.lookUpCity_Validating);
            // 
            // txtPOBoxNO
            // 
            this.txtPOBoxNO.EnterMoveNextControl = true;
            this.txtPOBoxNO.Location = new System.Drawing.Point(693, 140);
            this.txtPOBoxNO.MaximumSize = new System.Drawing.Size(200, 0);
            this.txtPOBoxNO.MenuManager = this.barManager1;
            this.txtPOBoxNO.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtPOBoxNO.Name = "txtPOBoxNO";
            this.txtPOBoxNO.Size = new System.Drawing.Size(105, 22);
            this.txtPOBoxNO.StyleController = this.myLayoutControl1;
            this.txtPOBoxNO.TabIndex = 1;
            // 
            // txtAddress3
            // 
            this.txtAddress3.EnterMoveNextControl = true;
            this.txtAddress3.Location = new System.Drawing.Point(693, 114);
            this.txtAddress3.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtAddress3.MenuManager = this.barManager1;
            this.txtAddress3.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(272, 22);
            this.txtAddress3.StyleController = this.myLayoutControl1;
            this.txtAddress3.TabIndex = 1;
            // 
            // txtAddress2
            // 
            this.txtAddress2.EnterMoveNextControl = true;
            this.txtAddress2.Location = new System.Drawing.Point(693, 88);
            this.txtAddress2.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtAddress2.MenuManager = this.barManager1;
            this.txtAddress2.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(272, 22);
            this.txtAddress2.StyleController = this.myLayoutControl1;
            this.txtAddress2.TabIndex = 1;
            // 
            // txtAddress1
            // 
            this.txtAddress1.EnterMoveNextControl = true;
            this.txtAddress1.Location = new System.Drawing.Point(693, 62);
            this.txtAddress1.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtAddress1.MenuManager = this.barManager1;
            this.txtAddress1.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(272, 22);
            this.txtAddress1.StyleController = this.myLayoutControl1;
            this.txtAddress1.TabIndex = 1;
            // 
            // deWorkVisaExpiryDate
            // 
            this.deWorkVisaExpiryDate.EditValue = null;
            this.deWorkVisaExpiryDate.EnterMoveNextControl = true;
            this.deWorkVisaExpiryDate.Location = new System.Drawing.Point(190, 245);
            this.deWorkVisaExpiryDate.MaximumSize = new System.Drawing.Size(200, 0);
            this.deWorkVisaExpiryDate.MenuManager = this.barManager1;
            this.deWorkVisaExpiryDate.MinimumSize = new System.Drawing.Size(100, 0);
            this.deWorkVisaExpiryDate.Name = "deWorkVisaExpiryDate";
            this.deWorkVisaExpiryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWorkVisaExpiryDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deWorkVisaExpiryDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.deWorkVisaExpiryDate.Size = new System.Drawing.Size(134, 22);
            this.deWorkVisaExpiryDate.StyleController = this.myLayoutControl1;
            this.deWorkVisaExpiryDate.TabIndex = 1;
            this.deWorkVisaExpiryDate.Validating += new System.ComponentModel.CancelEventHandler(this.deWorkVisaExpiryDate_Validating);
            // 
            // cmbGender
            // 
            this.cmbGender.EnterMoveNextControl = true;
            this.cmbGender.Location = new System.Drawing.Point(190, 193);
            this.cmbGender.MaximumSize = new System.Drawing.Size(150, 0);
            this.cmbGender.MenuManager = this.barManager1;
            this.cmbGender.MinimumSize = new System.Drawing.Size(100, 0);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbGender.Properties.DropDownRows = 3;
            this.cmbGender.Properties.Items.AddRange(new object[] {
            "Male ",
            "Female"});
            this.cmbGender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbGender.Size = new System.Drawing.Size(100, 22);
            this.cmbGender.StyleController = this.myLayoutControl1;
            this.cmbGender.TabIndex = 1;
            this.cmbGender.Validating += new System.ComponentModel.CancelEventHandler(this.cmbGender_Validating);
            // 
            // txtEmployeeOtherName
            // 
            this.txtEmployeeOtherName.EnterMoveNextControl = true;
            this.txtEmployeeOtherName.Location = new System.Drawing.Point(190, 167);
            this.txtEmployeeOtherName.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtEmployeeOtherName.MenuManager = this.barManager1;
            this.txtEmployeeOtherName.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtEmployeeOtherName.Name = "txtEmployeeOtherName";
            this.txtEmployeeOtherName.Properties.MaxLength = 50;
            this.txtEmployeeOtherName.Size = new System.Drawing.Size(319, 22);
            this.txtEmployeeOtherName.StyleController = this.myLayoutControl1;
            this.txtEmployeeOtherName.TabIndex = 1;
            // 
            // txtEmployeeLastName
            // 
            this.txtEmployeeLastName.EnterMoveNextControl = true;
            this.txtEmployeeLastName.Location = new System.Drawing.Point(190, 141);
            this.txtEmployeeLastName.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtEmployeeLastName.MenuManager = this.barManager1;
            this.txtEmployeeLastName.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtEmployeeLastName.Name = "txtEmployeeLastName";
            this.txtEmployeeLastName.Properties.MaxLength = 50;
            this.txtEmployeeLastName.Size = new System.Drawing.Size(319, 22);
            this.txtEmployeeLastName.StyleController = this.myLayoutControl1;
            this.txtEmployeeLastName.TabIndex = 1;
            this.txtEmployeeLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployeeLastName_Validating);
            // 
            // lookupDesignation
            // 
            this.lookupDesignation.EnterMoveNextControl = true;
            this.lookupDesignation.Location = new System.Drawing.Point(243, 272);
            this.lookupDesignation.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookupDesignation.MenuManager = this.barManager1;
            this.lookupDesignation.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupDesignation.Name = "lookupDesignation";
            this.lookupDesignation.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupDesignation.Properties.NullText = "Select";
            this.lookupDesignation.Size = new System.Drawing.Size(332, 22);
            this.lookupDesignation.StyleController = this.myLayoutControl1;
            this.lookupDesignation.TabIndex = 1;
            this.lookupDesignation.Validating += new System.ComponentModel.CancelEventHandler(this.lookupDesignation_Validating);
            // 
            // txtTACode
            // 
            this.txtTACode.EnterMoveNextControl = true;
            this.txtTACode.Location = new System.Drawing.Point(190, 88);
            this.txtTACode.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtTACode.MenuManager = this.barManager1;
            this.txtTACode.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtTACode.Name = "txtTACode";
            this.txtTACode.Properties.Mask.EditMask = "n0";
            this.txtTACode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTACode.Properties.MaxLength = 50;
            this.txtTACode.Size = new System.Drawing.Size(100, 22);
            this.txtTACode.StyleController = this.myLayoutControl1;
            this.txtTACode.TabIndex = 1;
            this.txtTACode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBMDeviceCode_Validating);
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.EnterMoveNextControl = true;
            this.txtEmployeeNo.Location = new System.Drawing.Point(328, 62);
            this.txtEmployeeNo.MaximumSize = new System.Drawing.Size(150, 0);
            this.txtEmployeeNo.MenuManager = this.barManager1;
            this.txtEmployeeNo.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Properties.Mask.EditMask = "n0";
            this.txtEmployeeNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtEmployeeNo.Properties.MaxLength = 10;
            this.txtEmployeeNo.Size = new System.Drawing.Size(138, 22);
            this.txtEmployeeNo.StyleController = this.myLayoutControl1;
            this.txtEmployeeNo.TabIndex = 1;
            this.txtEmployeeNo.TabStop = false;
            this.txtEmployeeNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployeeNo_Validating);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.EnterMoveNextControl = true;
            this.txtEmployeeName.Location = new System.Drawing.Point(190, 115);
            this.txtEmployeeName.MaximumSize = new System.Drawing.Size(400, 0);
            this.txtEmployeeName.MenuManager = this.barManager1;
            this.txtEmployeeName.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Properties.MaxLength = 50;
            this.txtEmployeeName.Size = new System.Drawing.Size(319, 22);
            this.txtEmployeeName.StyleController = this.myLayoutControl1;
            this.txtEmployeeName.TabIndex = 1;
            this.txtEmployeeName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployeeName_Validating);
            // 
            // lookupCountry
            // 
            this.lookupCountry.EnterMoveNextControl = true;
            this.lookupCountry.Location = new System.Drawing.Point(190, 219);
            this.lookupCountry.MaximumSize = new System.Drawing.Size(400, 0);
            this.lookupCountry.MenuManager = this.barManager1;
            this.lookupCountry.MinimumSize = new System.Drawing.Size(100, 0);
            this.lookupCountry.Name = "lookupCountry";
            this.lookupCountry.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupCountry.Properties.NullText = "";
            this.lookupCountry.Properties.PopupSizeable = false;
            this.lookupCountry.Size = new System.Drawing.Size(319, 22);
            this.lookupCountry.StyleController = this.myLayoutControl1;
            this.lookupCountry.TabIndex = 1;
            this.lookupCountry.Validating += new System.ComponentModel.CancelEventHandler(this.lookupCountry_Validating);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1319, 572);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroupEmployementDetail;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1299, 552);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroupPersonalDetail,
            this.layoutControlGroupEmployementDetail,
            this.layoutControlGroupPersonalDocument,
            this.layoutControlGroupFamilyDetail,
            this.layoutControlGroupServiceDetail});
            this.tabbedControlGroup1.Text = "Service Detail";
            // 
            // layoutControlGroupEmployementDetail
            // 
            this.layoutControlGroupEmployementDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4,
            this.layoutControlGroup5});
            this.layoutControlGroupEmployementDetail.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupEmployementDetail.Name = "layoutControlGroupEmployementDetail";
            this.layoutControlGroupEmployementDetail.Size = new System.Drawing.Size(1275, 504);
            this.layoutControlGroupEmployementDetail.Text = "Employement Detail";
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup7,
            this.layoutControlGroup6});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(861, 504);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.GroupBordersVisible = false;
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcgEmploymentType,
            this.layoutControlGroup13});
            this.layoutControlGroup7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup7.Name = "layoutControlGroup7";
            this.layoutControlGroup7.Size = new System.Drawing.Size(861, 158);
            this.layoutControlGroup7.TextVisible = false;
            // 
            // lcgEmploymentType
            // 
            this.lcgEmploymentType.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem25,
            this.layoutControlItem24,
            this.layoutControlItem26,
            this.layoutControlItem39,
            this.layoutControlItem40});
            this.lcgEmploymentType.Location = new System.Drawing.Point(474, 0);
            this.lcgEmploymentType.Name = "lcgEmploymentType";
            this.lcgEmploymentType.Size = new System.Drawing.Size(387, 158);
            this.lcgEmploymentType.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.cmbEmploymentType;
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(359, 26);
            this.layoutControlItem25.Text = "Employment Type";
            this.layoutControlItem25.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem25.TextToControlDistance = 5;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.deEmploymentEffectiveDate;
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(359, 26);
            this.layoutControlItem24.Text = "Employment Effective Date";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.deContractExpiryDate;
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(359, 26);
            this.layoutControlItem26.Text = "Contract Expiry Date";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem26.TextToControlDistance = 5;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.cmbPaymentMode;
            this.layoutControlItem39.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem39.Name = "layoutControlItem39";
            this.layoutControlItem39.Size = new System.Drawing.Size(359, 26);
            this.layoutControlItem39.Text = "Payment Mode";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.Control = this.cmbPayCycle;
            this.layoutControlItem40.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(359, 26);
            this.layoutControlItem40.Text = "Payment Cycle";
            this.layoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem40.TextToControlDistance = 5;
            // 
            // layoutControlGroup13
            // 
            this.layoutControlGroup13.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem21,
            this.layoutControlItem23,
            this.layoutControlItem20,
            this.layoutControlItem22,
            this.layoutControlItem70});
            this.layoutControlGroup13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup13.Name = "layoutControlGroup13";
            this.layoutControlGroup13.Size = new System.Drawing.Size(474, 158);
            this.layoutControlGroup13.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtIDNum;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(446, 26);
            this.layoutControlItem18.Text = "ID No.";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(100, 18);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtNHIFNum;
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(446, 26);
            this.layoutControlItem21.Text = "NHIF No.";
            this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(100, 18);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.txtPFNum;
            this.layoutControlItem23.Location = new System.Drawing.Point(234, 52);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(212, 26);
            this.layoutControlItem23.Text = "PF No.";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(41, 16);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.txtNSSFNum;
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(446, 26);
            this.layoutControlItem20.Text = "NSSF No.";
            this.layoutControlItem20.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(100, 18);
            this.layoutControlItem20.TextToControlDistance = 5;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txtPINNum;
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(446, 26);
            this.layoutControlItem22.Text = "PIN No.";
            this.layoutControlItem22.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(100, 18);
            this.layoutControlItem22.TextToControlDistance = 5;
            // 
            // layoutControlItem70
            // 
            this.layoutControlItem70.Control = this.cmbPFApplicable;
            this.layoutControlItem70.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem70.Name = "layoutControlItem70";
            this.layoutControlItem70.Size = new System.Drawing.Size(234, 26);
            this.layoutControlItem70.Text = "Provident Fund";
            this.layoutControlItem70.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem70.TextSize = new System.Drawing.Size(100, 20);
            this.layoutControlItem70.TextToControlDistance = 5;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.GroupBordersVisible = false;
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup10,
            this.emptySpaceItem5,
            this.lcgTermination,
            this.emptySpaceItem12,
            this.lcgReinstateEmployee,
            this.emptySpaceItem14});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 158);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(861, 346);
            this.layoutControlGroup6.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(569, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(292, 346);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem47,
            this.layoutControlItem48,
            this.layoutControlItem51,
            this.layoutControlItem52,
            this.layoutControlItem53,
            this.layoutControlItem55,
            this.layoutControlItem56,
            this.layoutControlItem60,
            this.layoutControlItem61,
            this.layoutControlItem54});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(292, 307);
            this.layoutControlGroup2.Text = "T && A Settings";
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.Control = this.cmbTAAttendanceType;
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem47.Text = "Attendance Type";
            this.layoutControlItem47.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem47.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem47.TextToControlDistance = 5;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.cmbTALatenessCharges;
            this.layoutControlItem48.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem48.Text = "Lateness Charges";
            this.layoutControlItem48.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem48.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem48.TextToControlDistance = 5;
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.cmbTAEarlyGoing;
            this.layoutControlItem51.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem51.Name = "layoutControlItem51";
            this.layoutControlItem51.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem51.Text = "Early Going";
            this.layoutControlItem51.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem51.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem51.TextToControlDistance = 5;
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.Control = this.cmbTAOvertime;
            this.layoutControlItem52.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem52.Text = "Overtime";
            this.layoutControlItem52.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem52.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem52.TextToControlDistance = 5;
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.Control = this.cmbTANegativeLeave;
            this.layoutControlItem53.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem53.Name = "layoutControlItem53";
            this.layoutControlItem53.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem53.Text = "Negative Leave";
            this.layoutControlItem53.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem53.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem53.TextToControlDistance = 5;
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.Control = this.cmbTAWeekEndAttendance;
            this.layoutControlItem55.Location = new System.Drawing.Point(0, 156);
            this.layoutControlItem55.Name = "layoutControlItem55";
            this.layoutControlItem55.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem55.Text = "Week End Attendance";
            this.layoutControlItem55.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem55.TextSize = new System.Drawing.Size(150, 16);
            this.layoutControlItem55.TextToControlDistance = 5;
            // 
            // layoutControlItem56
            // 
            this.layoutControlItem56.Control = this.cmbTAMissPunch;
            this.layoutControlItem56.Location = new System.Drawing.Point(0, 182);
            this.layoutControlItem56.Name = "layoutControlItem56";
            this.layoutControlItem56.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem56.Text = "Miss Punch";
            this.layoutControlItem56.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem56.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem56.TextToControlDistance = 5;
            // 
            // layoutControlItem60
            // 
            this.layoutControlItem60.Control = this.cmbEmployeeShiftType;
            this.layoutControlItem60.Location = new System.Drawing.Point(0, 208);
            this.layoutControlItem60.Name = "layoutControlItem60";
            this.layoutControlItem60.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem60.Text = "Shift Type";
            this.layoutControlItem60.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem60.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem60.TextToControlDistance = 5;
            // 
            // layoutControlItem61
            // 
            this.layoutControlItem61.Control = this.lookupEmployeeShift;
            this.layoutControlItem61.Location = new System.Drawing.Point(0, 234);
            this.layoutControlItem61.Name = "layoutControlItem61";
            this.layoutControlItem61.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem61.Text = "Shift";
            this.layoutControlItem61.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem61.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem61.TextToControlDistance = 5;
            // 
            // layoutControlItem54
            // 
            this.layoutControlItem54.Control = this.cmbTAWeekendType;
            this.layoutControlItem54.Location = new System.Drawing.Point(0, 130);
            this.layoutControlItem54.Name = "layoutControlItem54";
            this.layoutControlItem54.Size = new System.Drawing.Size(266, 26);
            this.layoutControlItem54.Text = "Weekend Type";
            this.layoutControlItem54.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem54.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem54.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 307);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(292, 39);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup10
            // 
            this.layoutControlGroup10.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem27,
            this.layoutControlItem36,
            this.layoutControlItem4,
            this.layoutControlItem33,
            this.layoutControlItem38,
            this.layoutControlItem45});
            this.layoutControlGroup10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup10.Name = "layoutControlGroup10";
            this.layoutControlGroup10.Size = new System.Drawing.Size(569, 184);
            this.layoutControlGroup10.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.lookUpDepartment;
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(541, 26);
            this.layoutControlItem27.Text = "Department";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.lookUpLocation;
            this.layoutControlItem36.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(541, 26);
            this.layoutControlItem36.Text = "Location";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem36.TextToControlDistance = 5;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lookupDesignation;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(541, 26);
            this.layoutControlItem4.Text = "Designation";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.Control = this.lookUpMinimumWageCategory;
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(541, 26);
            this.layoutControlItem33.Text = "Minimum Wages Category";
            this.layoutControlItem33.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem33.TextToControlDistance = 5;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.lookupWIBAClass;
            this.layoutControlItem38.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(541, 26);
            this.layoutControlItem38.Text = "WIBA Class";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem38.TextToControlDistance = 5;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.Control = this.lookupEmployeeAccountingLedger;
            this.layoutControlItem45.Location = new System.Drawing.Point(0, 130);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(541, 26);
            this.layoutControlItem45.Text = "Accounting Ledger";
            this.layoutControlItem45.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem45.TextSize = new System.Drawing.Size(200, 18);
            this.layoutControlItem45.TextToControlDistance = 5;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(304, 310);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(255, 26);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgTermination
            // 
            this.lcgTermination.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem63,
            this.lcgTerminationControls});
            this.lcgTermination.Location = new System.Drawing.Point(0, 184);
            this.lcgTermination.Name = "lcgTermination";
            this.lcgTermination.Size = new System.Drawing.Size(304, 152);
            this.lcgTermination.Text = "Termination/Resignation";
            this.lcgTermination.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem63
            // 
            this.layoutControlItem63.Control = this.cmbTerminationType;
            this.layoutControlItem63.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem63.Name = "layoutControlItem63";
            this.layoutControlItem63.Size = new System.Drawing.Size(278, 26);
            this.layoutControlItem63.Text = "Termination/Resig";
            this.layoutControlItem63.TextSize = new System.Drawing.Size(149, 16);
            // 
            // lcgTerminationControls
            // 
            this.lcgTerminationControls.Enabled = false;
            this.lcgTerminationControls.GroupBordersVisible = false;
            this.lcgTerminationControls.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem65,
            this.layoutControlItem64,
            this.layoutControlItem66});
            this.lcgTerminationControls.Location = new System.Drawing.Point(0, 26);
            this.lcgTerminationControls.Name = "lcgTerminationControls";
            this.lcgTerminationControls.Size = new System.Drawing.Size(278, 79);
            // 
            // layoutControlItem65
            // 
            this.layoutControlItem65.Control = this.txtTerminationReason;
            this.layoutControlItem65.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem65.Name = "layoutControlItem65";
            this.layoutControlItem65.Size = new System.Drawing.Size(278, 26);
            this.layoutControlItem65.Text = "Reason";
            this.layoutControlItem65.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem65.TextSize = new System.Drawing.Size(44, 16);
            this.layoutControlItem65.TextToControlDistance = 5;
            // 
            // layoutControlItem64
            // 
            this.layoutControlItem64.Control = this.deTerminationDate;
            this.layoutControlItem64.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem64.Name = "layoutControlItem64";
            this.layoutControlItem64.Size = new System.Drawing.Size(278, 26);
            this.layoutControlItem64.Text = "Date of Termination/Resig";
            this.layoutControlItem64.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem66
            // 
            this.layoutControlItem66.Control = this.btnTerminateEmployee;
            this.layoutControlItem66.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem66.Name = "layoutControlItem66";
            this.layoutControlItem66.Size = new System.Drawing.Size(278, 27);
            this.layoutControlItem66.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem66.TextVisible = false;
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.Location = new System.Drawing.Point(0, 336);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(559, 10);
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcgReinstateEmployee
            // 
            this.lcgReinstateEmployee.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem68,
            this.layoutControlItem67,
            this.layoutControlItem69,
            this.emptySpaceItem13});
            this.lcgReinstateEmployee.Location = new System.Drawing.Point(304, 184);
            this.lcgReinstateEmployee.Name = "lcgReinstateEmployee";
            this.lcgReinstateEmployee.Size = new System.Drawing.Size(255, 126);
            this.lcgReinstateEmployee.Text = "Re-Instate Employement";
            this.lcgReinstateEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem68
            // 
            this.layoutControlItem68.Control = this.txtReinstatementReason;
            this.layoutControlItem68.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem68.Name = "layoutControlItem68";
            this.layoutControlItem68.Size = new System.Drawing.Size(229, 26);
            this.layoutControlItem68.Text = "Reason";
            this.layoutControlItem68.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem68.TextSize = new System.Drawing.Size(65, 20);
            this.layoutControlItem68.TextToControlDistance = 5;
            // 
            // layoutControlItem67
            // 
            this.layoutControlItem67.Control = this.deReinstateEmployeementDate;
            this.layoutControlItem67.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem67.Name = "layoutControlItem67";
            this.layoutControlItem67.Size = new System.Drawing.Size(197, 26);
            this.layoutControlItem67.Text = "Date";
            this.layoutControlItem67.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem67.TextSize = new System.Drawing.Size(65, 20);
            this.layoutControlItem67.TextToControlDistance = 5;
            // 
            // layoutControlItem69
            // 
            this.layoutControlItem69.Control = this.btnReinstateEmployee;
            this.layoutControlItem69.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem69.Name = "layoutControlItem69";
            this.layoutControlItem69.Size = new System.Drawing.Size(229, 27);
            this.layoutControlItem69.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem69.TextVisible = false;
            // 
            // emptySpaceItem13
            // 
            this.emptySpaceItem13.AllowHotTrack = false;
            this.emptySpaceItem13.Location = new System.Drawing.Point(197, 0);
            this.emptySpaceItem13.Name = "emptySpaceItem13";
            this.emptySpaceItem13.Size = new System.Drawing.Size(32, 26);
            this.emptySpaceItem13.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem14
            // 
            this.emptySpaceItem14.AllowHotTrack = false;
            this.emptySpaceItem14.Location = new System.Drawing.Point(559, 184);
            this.emptySpaceItem14.Name = "emptySpaceItem14";
            this.emptySpaceItem14.Size = new System.Drawing.Size(10, 162);
            this.emptySpaceItem14.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.GroupBordersVisible = false;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup8,
            this.layoutControlGroup12});
            this.layoutControlGroup5.Location = new System.Drawing.Point(861, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(414, 504);
            this.layoutControlGroup5.TextVisible = false;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem44,
            this.layoutControlItem43,
            this.layoutControlItem42,
            this.layoutControlItem41,
            this.layoutControlItem57});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Size = new System.Drawing.Size(414, 158);
            this.layoutControlGroup8.TextVisible = false;
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.Control = this.lookBankUpCurrency;
            this.layoutControlItem44.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(386, 26);
            this.layoutControlItem44.Text = "Currency";
            this.layoutControlItem44.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem44.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem44.TextToControlDistance = 5;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.lookUpBankBranch;
            this.layoutControlItem43.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(386, 26);
            this.layoutControlItem43.Text = "Branch Name";
            this.layoutControlItem43.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem43.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem43.TextToControlDistance = 5;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.lookUpBankName;
            this.layoutControlItem42.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(386, 26);
            this.layoutControlItem42.Text = "Bank Name";
            this.layoutControlItem42.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem42.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem42.TextToControlDistance = 5;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.txtBankAccountNo;
            this.layoutControlItem41.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem41.Name = "layoutControlItem41";
            this.layoutControlItem41.Size = new System.Drawing.Size(386, 26);
            this.layoutControlItem41.Text = "Bank Account No.";
            this.layoutControlItem41.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem41.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem41.TextToControlDistance = 5;
            // 
            // layoutControlItem57
            // 
            this.layoutControlItem57.Control = this.txtBankCode;
            this.layoutControlItem57.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem57.Name = "layoutControlItem57";
            this.layoutControlItem57.Size = new System.Drawing.Size(386, 26);
            this.layoutControlItem57.Text = "Bank Code";
            this.layoutControlItem57.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem57.TextSize = new System.Drawing.Size(150, 18);
            this.layoutControlItem57.TextToControlDistance = 5;
            // 
            // layoutControlGroup12
            // 
            this.layoutControlGroup12.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem29,
            this.layoutControlItem28,
            this.layoutControlItem30,
            this.layoutControlItem31,
            this.layoutControlItem32,
            this.layoutControlItem37,
            this.layoutControlGroup9,
            this.emptySpaceItem4});
            this.layoutControlGroup12.Location = new System.Drawing.Point(0, 158);
            this.layoutControlGroup12.Name = "layoutControlGroup12";
            this.layoutControlGroup12.Size = new System.Drawing.Size(414, 346);
            this.layoutControlGroup12.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.cmbIncomeType;
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(323, 26);
            this.layoutControlItem29.Text = "Income Type";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(160, 18);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.txtDailyRate;
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(323, 26);
            this.layoutControlItem28.Text = "Daily Rate";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(160, 18);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.txtBasicSalary;
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(323, 26);
            this.layoutControlItem30.Text = "Basic Salary";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(160, 18);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.Control = this.txtHousingAllowance;
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(323, 26);
            this.layoutControlItem31.Text = "Housing Allowance";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(160, 18);
            this.layoutControlItem31.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.txtWeekendAllowance;
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(323, 26);
            this.layoutControlItem32.Text = "Weekend Allowance";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(160, 18);
            this.layoutControlItem32.TextToControlDistance = 5;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.Control = this.simpleButton1;
            this.layoutControlItem37.Location = new System.Drawing.Point(0, 130);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(323, 27);
            this.layoutControlItem37.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem37.TextVisible = false;
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem34});
            this.layoutControlGroup9.Location = new System.Drawing.Point(0, 157);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.Size = new System.Drawing.Size(386, 161);
            this.layoutControlGroup9.Text = "Leave Opening Balance";
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.gridControlLeaveOpeningBalance;
            this.layoutControlItem34.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(360, 114);
            this.layoutControlItem34.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem34.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(323, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(63, 157);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroupPersonalDetail
            // 
            this.layoutControlGroupPersonalDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup14,
            this.layoutControlGroup15,
            this.layoutControlGroup16,
            this.emptySpaceItem2,
            this.layoutControlItem58,
            this.emptySpaceItem11,
            this.emptySpaceItem9});
            this.layoutControlGroupPersonalDetail.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupPersonalDetail.Name = "layoutControlGroupPersonalDetail";
            this.layoutControlGroupPersonalDetail.Size = new System.Drawing.Size(1275, 504);
            this.layoutControlGroupPersonalDetail.Text = "Personal Detail";
            // 
            // layoutControlGroup14
            // 
            this.layoutControlGroup14.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem8,
            this.layoutControlItem35,
            this.layoutControlItem3,
            this.emptySpaceItem10,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem3,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem6,
            this.layoutControlItem62});
            this.layoutControlGroup14.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup14.Name = "layoutControlGroup14";
            this.layoutControlGroup14.Size = new System.Drawing.Size(503, 237);
            this.layoutControlGroup14.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEmployeeNo;
            this.layoutControlItem2.Location = new System.Drawing.Point(290, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(142, 26);
            this.layoutControlItem2.Text = "Emp Code";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.Location = new System.Drawing.Point(432, 0);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(43, 26);
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.lookupEmployeePrefix;
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(290, 26);
            this.layoutControlItem35.Text = "Emp Code";
            this.layoutControlItem35.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTACode;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(256, 27);
            this.layoutControlItem3.Text = "T && A No";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(149, 16);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.Location = new System.Drawing.Point(465, 26);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(10, 27);
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtEmployeeName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 53);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(475, 26);
            this.layoutControlItem1.Text = "First Name";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtEmployeeLastName;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 79);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(475, 26);
            this.layoutControlItem5.Text = "Last Name";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtEmployeeOtherName;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 105);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(475, 26);
            this.layoutControlItem6.Text = "Other Name";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cmbGender;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 131);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(256, 26);
            this.layoutControlItem7.Text = "Gender";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(149, 16);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(256, 131);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(219, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lookupCountry;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 157);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(475, 26);
            this.layoutControlItem8.Text = "Nationality";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.deWorkVisaExpiryDate;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 183);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(290, 26);
            this.layoutControlItem9.Text = "Work Visa Expiry Date";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(149, 16);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(290, 183);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(185, 26);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem62
            // 
            this.layoutControlItem62.Control = this.btnUpdateTimeAttendanceData;
            this.layoutControlItem62.Location = new System.Drawing.Point(256, 26);
            this.layoutControlItem62.Name = "layoutControlItem62";
            this.layoutControlItem62.Size = new System.Drawing.Size(209, 27);
            this.layoutControlItem62.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem62.TextVisible = false;
            // 
            // layoutControlGroup15
            // 
            this.layoutControlGroup15.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem19});
            this.layoutControlGroup15.Location = new System.Drawing.Point(959, 0);
            this.layoutControlGroup15.Name = "layoutControlGroup15";
            this.layoutControlGroup15.Size = new System.Drawing.Size(262, 199);
            this.layoutControlGroup15.TextVisible = false;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.picEmployeeImage;
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(234, 171);
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlGroup16
            // 
            this.layoutControlGroup16.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem16,
            this.emptySpaceItem7,
            this.layoutControlItem17});
            this.layoutControlGroup16.Location = new System.Drawing.Point(503, 0);
            this.layoutControlGroup16.Name = "layoutControlGroup16";
            this.layoutControlGroup16.Size = new System.Drawing.Size(456, 237);
            this.layoutControlGroup16.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtAddress1;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(428, 26);
            this.layoutControlItem10.Text = "Address 1";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtAddress2;
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(428, 26);
            this.layoutControlItem11.Text = "Address 2";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtAddress3;
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(428, 26);
            this.layoutControlItem12.Text = "Address 3";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtPOBoxNO;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 78);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(261, 26);
            this.layoutControlItem13.Text = "P.O.Box No";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.lookUpCity;
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 104);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(428, 26);
            this.layoutControlItem14.Text = "City";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.txtMpesaNo;
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 130);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(428, 26);
            this.layoutControlItem15.Text = "Mpesa No.";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(149, 16);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtEmail;
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 156);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(428, 26);
            this.layoutControlItem16.Text = "Email ID";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(149, 16);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.Location = new System.Drawing.Point(261, 78);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(167, 26);
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.cmbMulticurrency;
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 182);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(428, 27);
            this.layoutControlItem17.Text = "Multi Currency";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(149, 16);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 237);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(1275, 267);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem58
            // 
            this.layoutControlItem58.Control = this.btnNextPage;
            this.layoutControlItem58.Location = new System.Drawing.Point(959, 199);
            this.layoutControlItem58.Name = "layoutControlItem58";
            this.layoutControlItem58.Size = new System.Drawing.Size(262, 27);
            this.layoutControlItem58.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem58.TextVisible = false;
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.Location = new System.Drawing.Point(959, 226);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(262, 11);
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.Location = new System.Drawing.Point(1221, 0);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(54, 237);
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroupPersonalDocument
            // 
            this.layoutControlGroupPersonalDocument.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem49,
            this.layoutControlItem50});
            this.layoutControlGroupPersonalDocument.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupPersonalDocument.Name = "layoutControlGroupPersonalDocument";
            this.layoutControlGroupPersonalDocument.Size = new System.Drawing.Size(1275, 504);
            this.layoutControlGroupPersonalDocument.Text = "Personal Documents";
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.Control = this.picEmployeeDocument;
            this.layoutControlItem49.Location = new System.Drawing.Point(511, 0);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(764, 504);
            this.layoutControlItem49.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem49.TextVisible = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.gridControlDocument;
            this.layoutControlItem50.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(511, 504);
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextVisible = false;
            // 
            // layoutControlGroupFamilyDetail
            // 
            this.layoutControlGroupFamilyDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem46});
            this.layoutControlGroupFamilyDetail.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupFamilyDetail.Name = "layoutControlGroupFamilyDetail";
            this.layoutControlGroupFamilyDetail.Size = new System.Drawing.Size(1275, 504);
            this.layoutControlGroupFamilyDetail.Text = "Family Details";
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.gridControlFamily;
            this.layoutControlItem46.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(1275, 504);
            this.layoutControlItem46.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem46.TextVisible = false;
            // 
            // layoutControlGroupServiceDetail
            // 
            this.layoutControlGroupServiceDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem59});
            this.layoutControlGroupServiceDetail.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroupServiceDetail.Name = "layoutControlGroupServiceDetail";
            this.layoutControlGroupServiceDetail.Size = new System.Drawing.Size(1275, 504);
            this.layoutControlGroupServiceDetail.Text = "Service Detail";
            // 
            // layoutControlItem59
            // 
            this.layoutControlItem59.Control = this.gridControlServiceDetail;
            this.layoutControlItem59.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem59.Name = "layoutControlItem59";
            this.layoutControlItem59.Size = new System.Drawing.Size(1275, 504);
            this.layoutControlItem59.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem59.TextVisible = false;
            // 
            // popupMenuFormShortCuts
            // 
            this.popupMenuFormShortCuts.Manager = this.barManager1;
            this.popupMenuFormShortCuts.Name = "popupMenuFormShortCuts";
            // 
            // frmEmployee
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 712);
            this.FirstControl = this.myLayoutControl1;
            this.Name = "frmEmployee";
            this.barManager1.SetPopupContextMenu(this, this.popupMenuFormShortCuts);
            this.Text = "Employee";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelContent)).EndInit();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myLayoutControl1)).EndInit();
            this.myLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPFApplicable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReinstatementReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReinstateEmployeementDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deReinstateEmployeementDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerminationReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTerminationDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTerminationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTerminationType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAWeekendType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployeeShift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmployeeShiftType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlLeaveOpeningBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeLeaveOpeningBalanceViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLeaveOpeningBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlServiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeServiceDetailViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAMissPunch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAWeekEndAttendance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTANegativeLeave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAOvertime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAEarlyGoing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTALatenessCharges.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTAAttendanceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployeePrefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFamily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFamily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditFamilyRelationship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRemovePersonalDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmployeeAccountingLedger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookBankUpCurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBankBranch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpBankName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBankAccountNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPayCycle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPaymentMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupWIBAClass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpMinimumWageCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeekendAllowance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHousingAllowance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBasicSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIncomeType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDailyRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractExpiryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deContractExpiryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEmploymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEmploymentEffectiveDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deEmploymentEffectiveDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPFNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPINNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNHIFNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNSSFNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIDNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMulticurrency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMpesaNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpCity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPOBoxNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWorkVisaExpiryDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deWorkVisaExpiryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeOtherName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupDesignation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTACode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCountry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupEmployementDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgEmploymentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgTermination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem63)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgTerminationControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem65)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem64)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgReinstateEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem68)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem67)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPersonalDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupPersonalDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupFamilyDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroupServiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuFormShortCuts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenuFormShortCuts;
        private Alit.WinformControls.myLayoutControl myLayoutControl1;
        private Alit.WinformControls.TextEdit txtTACode;
        private Alit.WinformControls.TextEdit txtEmployeeNo;
        private Alit.WinformControls.TextEdit txtEmployeeName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Alit.WinformControls.LookUpEdit lookupDesignation;
        private Alit.WinformControls.ComboBoxEdit cmbGender;
        private Alit.WinformControls.TextEdit txtEmployeeOtherName;
        private Alit.WinformControls.TextEdit txtEmployeeLastName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private Alit.WinformControls.ComboBoxEdit cmbMulticurrency;
        private Alit.WinformControls.TextEdit txtEmail;
        private Alit.WinformControls.TextEdit txtMpesaNo;
        private Alit.WinformControls.LookUpEdit lookUpCity;
        private Alit.WinformControls.TextEdit txtPOBoxNO;
        private Alit.WinformControls.TextEdit txtAddress3;
        private Alit.WinformControls.TextEdit txtAddress2;
        private Alit.WinformControls.TextEdit txtAddress1;
        private Alit.WinformControls.DateEdit deWorkVisaExpiryDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private Alit.WinformControls.PictureSelect picEmployeeImage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private Alit.WinformControls.DateEdit deEmploymentEffectiveDate;
        private Alit.WinformControls.TextEdit txtPFNum;
        private Alit.WinformControls.TextEdit txtPINNum;
        private Alit.WinformControls.TextEdit txtNHIFNum;
        private Alit.WinformControls.TextEdit txtNSSFNum;
        private Alit.WinformControls.TextEdit txtIDNum;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupEmployementDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPersonalDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Alit.WinformControls.LookUpEdit lookupEmployeeAccountingLedger;
        private Alit.WinformControls.LookUpEdit lookBankUpCurrency;
        private Alit.WinformControls.LookUpEdit lookUpBankBranch;
        private Alit.WinformControls.LookUpEdit lookUpBankName;
        private Alit.WinformControls.TextEdit txtBankAccountNo;
        private Alit.WinformControls.ComboBoxEdit cmbPayCycle;
        private Alit.WinformControls.ComboBoxEdit cmbPaymentMode;
        private Alit.WinformControls.LookUpEdit lookupWIBAClass;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private Alit.WinformControls.LookUpEdit lookUpLocation;
        private Alit.WinformControls.LookUpEdit lookUpMinimumWageCategory;
        private Alit.WinformControls.TextEdit txtWeekendAllowance;
        private Alit.WinformControls.TextEdit txtHousingAllowance;
        private Alit.WinformControls.TextEdit txtBasicSalary;
        private Alit.WinformControls.ComboBoxEdit cmbIncomeType;
        private Alit.WinformControls.TextEdit txtDailyRate;
        private Alit.WinformControls.LookUpEdit lookUpDepartment;
        private Alit.WinformControls.DateEdit deContractExpiryDate;
        private Alit.WinformControls.ComboBoxEdit cmbEmploymentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private Alit.WinformControls.LookUpEdit lookupCountry;
        private DevExpress.XtraGrid.GridControl gridControlDocument;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDocument;
        private Alit.WinformControls.PictureSelect picEmployeeDocument;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupPersonalDocument;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColDocumentName;
        private DevExpress.XtraGrid.GridControl gridControlFamily;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFamily;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupFamilyDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnRelationship;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditFamilyRelationship;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonalDocumentRemoveRow;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemRemovePersonalDocument;
        private Alit.WinformControls.LookUpEdit lookupEmployeePrefix;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private Alit.WinformControls.ComboBoxEdit cmbTAMissPunch;
        private Alit.WinformControls.ComboBoxEdit cmbTAWeekEndAttendance;
        private Alit.WinformControls.ComboBoxEdit cmbTANegativeLeave;
        private Alit.WinformControls.ComboBoxEdit cmbTAOvertime;
        private Alit.WinformControls.ComboBoxEdit cmbTAEarlyGoing;
        private Alit.WinformControls.ComboBoxEdit cmbTALatenessCharges;
        private Alit.WinformControls.ComboBoxEdit cmbTAAttendanceType;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem52;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem56;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroupServiceDetail;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private Alit.WinformControls.TextEdit txtBankCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem57;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup10;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup lcgEmploymentType;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup13;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup15;
        private DevExpress.XtraEditors.SimpleButton btnNextPage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem58;
        private DevExpress.XtraGrid.GridControl gridControlServiceDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewService;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem59;
        private System.Windows.Forms.BindingSource employeeServiceDetailViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmploymentType;
        private DevExpress.XtraGrid.Columns.GridColumn colEmploymentEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn colContractExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeDesignationName;
        private DevExpress.XtraGrid.Columns.GridColumn colLocationName;
        private DevExpress.XtraGrid.Columns.GridColumn colMinimumWageCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeWIBAClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyRate;
        private DevExpress.XtraGrid.Columns.GridColumn colBasicSalary;
        private DevExpress.XtraGrid.Columns.GridColumn colHousingAllowance;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekendAllowance;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl gridControlLeaveOpeningBalance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLeaveOpeningBalance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private System.Windows.Forms.BindingSource employeeLeaveOpeningBalanceViewModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLeaveTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colOpeningBalance;
        private Alit.WinformControls.ComboBoxEdit cmbEmployeeShiftType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem60;
        private Alit.WinformControls.LookUpEdit lookupEmployeeShift;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem61;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private Alit.WinformControls.ComboBoxEdit cmbTAWeekendType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem54;
        private DevExpress.XtraEditors.SimpleButton btnUpdateTimeAttendanceData;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem62;
        private Alit.WinformControls.TextEdit txtTerminationReason;
        private Alit.WinformControls.DateEdit deTerminationDate;
        private Alit.WinformControls.ComboBoxEdit cmbTerminationType;
        private DevExpress.XtraLayout.LayoutControlGroup lcgTermination;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem63;
        private DevExpress.XtraLayout.LayoutControlGroup lcgTerminationControls;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem65;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem64;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraEditors.SimpleButton btnTerminateEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem66;
        private DevExpress.XtraEditors.SimpleButton btnReinstateEmployee;
        private Alit.WinformControls.TextEdit txtReinstatementReason;
        private Alit.WinformControls.DateEdit deReinstateEmployeementDate;
        private DevExpress.XtraLayout.LayoutControlGroup lcgReinstateEmployee;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem68;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem67;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem69;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem14;
        private Alit.WinformControls.ComboBoxEdit cmbPFApplicable;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem70;
    }
}