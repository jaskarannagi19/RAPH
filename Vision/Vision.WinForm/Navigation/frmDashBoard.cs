using Vision.DAL.Settings;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.WinForm.Navigation
{
    public partial class frmDashBoard : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        SettingsDAL SettingsDAL;
        public static frmDashBoard DashBoard { get; private set; }

        public frmDashBoard()
        {
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Arial", 10, FontStyle.Bold);
            DashBoard = this;
            InitializeComponent();
            ribbonMain.Minimized = true;

            //--
            DAL.Settings.CompanyDAL CompanyDAL = new DAL.Settings.CompanyDAL();
            SettingsDAL = new SettingsDAL();

            // Loading Settings at level 0
            Model.CommonProperties.LoginInfo.SoftwareSettings = SettingsDAL.GetSetting();

            // Loading theme from settings
            SkinHelper.InitSkinGallery(rgbiSkins);
            UserLookAndFeel.Default.StyleChanged += Default_StyleChanged;
            UserLookAndFeel.Default.SkinName = Model.CommonProperties.LoginInfo.SoftwareSettings.GUIThemeSkinName;
            //Properties.Settings.Default["ApplicationSkinName"].ToString();

            this.Text = Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName + " " + Model.CommonProperties.DevelopmentCompanyInfo.ProductName;
            lblCompanyName.Caption = "";
            lblFinPeriod.Caption = "";
            lblLoginTime.Caption = "";
            lblUserName.Caption = "";
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
          
            Logout();
        }

        public void Logout()
        {
            foreach (var form in this.MdiChildren)
            {
                form.Close();
            }
            Model.CommonProperties.LoginInfo.UserPermission = null;
            Model.CommonProperties.LoginInfo.LoggedinUser = null;
            //Model.CommonProperties.LoginInfo.SoftwareSettings = null;
            Model.CommonProperties.LoginInfo.LoggedInFinPeriod = null;
            Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel = null;
            Model.CommonProperties.LoginInfo.LoggedInCompany = null;

            lblCompanyName.Caption = "";
            lblFinPeriod.Caption = "";
            lblLoginTime.Caption = "";
            lblUserName.Caption = "";

            this.Text = Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName + " " + Model.CommonProperties.DevelopmentCompanyInfo.ProductName;

            if(!Login())
            {
                this.Close();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            Login();
            base.OnShown(e);
            if (Model.CommonProperties.LoginInfo.LoggedinUser == null 
                || Model.CommonProperties.LoginInfo.LoggedInCompany == null 
                || Model.CommonProperties.LoginInfo.LoggedInFinPeriod == null)
            {
                this.Close();
            }
        }

        bool Login()
        {
            Users.frmUserLogin frmLogin = new Users.frmUserLogin();

            frmLogin.ShowDialog(this);
            if(Model.CommonProperties.LoginInfo.LoggedinUser == null)
            {
                //this.Close();
                return false;
            }

            //if (CompanyDAL.GetFirstCompany() == null)
            //{
            //    bool ContCompany = false;
            //    do
            //    {
            //        Settings.frmCompany frmComp = new Settings.frmCompany();
            //        frmComp.StartPosition = FormStartPosition.CenterScreen;
            //        frmComp.ShowDialog();

            //        if (CompanyDAL.GetFirstCompany() == null)
            //        {
            //            if (Alit.WinformControls.MessageBox.Show(this, "You don't have a company to start. Do you want to create a new company ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //            {
            //                ContCompany = true;
            //            }
            //            else
            //            {
            //                Application.Exit();
            //                return;
            //            }
            //        }
            //        else
            //        {
            //            ContCompany = false;
            //        }
            //    } while (ContCompany);
            //}

            if (DAL.Settings.CompanyDAL.CompanyCount(Model.CommonProperties.LoginInfo.LoggedinUser.UserGroupID) == 1)
            {
                Model.CommonProperties.LoginInfo.LoggedInCompany = DAL.Settings.CompanyDAL.GetFirstCompany(Model.CommonProperties.LoginInfo.LoggedinUser.UserGroupID);
                if (DAL.Settings.FinPeriodDAL.FinPeriodsCount(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID) == 1)
                {
                    Model.CommonProperties.LoginInfo.LoggedInFinPeriod = DAL.Settings.FinPeriodDAL.GetFirstFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                }
            }

            if(Model.CommonProperties.LoginInfo.LoggedInCompany == null ||
                Model.CommonProperties.LoginInfo.LoggedInFinPeriod == null)
            {
                Users.frmSelectCompany frmSelectCompany = new Users.frmSelectCompany();
                frmSelectCompany.ShowDialog(this);
            }

            if (Model.CommonProperties.LoginInfo.LoggedinUser != null && Model.CommonProperties.LoginInfo.LoggedInCompany != null && Model.CommonProperties.LoginInfo.LoggedInFinPeriod != null)
            {
                lblUserName.Caption = Model.CommonProperties.LoginInfo.LoggedinUser.UserName;
                lblCompanyName.Caption = "Company : " + Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName;
                lblFinPeriod.Caption = "(" + Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToShortDateString() + " - " + (Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.HasValue ? Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodTo.Value.ToShortDateString() : "*") + ")";
                lblLoginTime.Caption = "Login at : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

                this.Text = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyName + " " + 
                    lblFinPeriod.Caption + " - " + 
                    Model.CommonProperties.DevelopmentCompanyInfo.CompanyShortName + " " + 
                    Model.CommonProperties.DevelopmentCompanyInfo.ProductName;

                SettingsDAL.GetSetting(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, Model.CommonProperties.LoginInfo.SoftwareSettings);

                Model.CommonProperties.LoginInfo.LoggedInCompanyReportModel = DAL.Settings.CompanyDAL.GetCompanyDetailReportModel(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);

                Model.CommonProperties.LoginInfo.CurrentPayrollMonth = (new DAL.Settings.PayrollMonthDAL()).GetLatestPayrollMonthViewModelByCompanyID(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                if(Model.CommonProperties.LoginInfo.CurrentPayrollMonth != null)
                {
                    lblPayrollMonthName.Caption = Model.CommonProperties.LoginInfo.CurrentPayrollMonth.PayrollMonthName;
                }


                ApplySettingsOnMenus();

                if (!Model.CommonProperties.LoginInfo.LoggedinUser.SuperUser)
                {
                    /// Setting visibility of bar items according to permission
                    foreach (BarItem item in ribbonMain.Items)
                    {
                        if (item.Tag != null)
                        {
                            long MenuOptionID = Model.CommonFunctions.ParseLong(item.Tag.ToString());
                            var perm = Model.CommonFunctions.GetCurreUserPermission(MenuOptionID);
                            if (perm != null && perm.CanView)
                            {
                                item.Visibility = BarItemVisibility.Always;
                            }
                            else
                            {
                                item.Visibility = BarItemVisibility.Never;
                            }
                        }
                    }
                }
                else
                {
                    foreach (BarItem item in ribbonMain.Items)
                    {
                        item.Visibility = BarItemVisibility.Always;
                    }
                }
            }
            else
            {
                //this.Close();
                return false;
            }
            ribbonMain.Minimized = false;

            return true;
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);

        //    Login();
        //}

        public void ApplySettingsOnMenus()
        {

        }

        public static void ShowForm<T>(int MenuOptionID)
        {
            object frm = GetFormInstance<T>();
            if (frm != null && frm is Form)
            {
                ((Form)frm).Activate();
            }
            else
            {
                Type t = Type.GetType(typeof(T).ToString());
                Form newFrm = (Form)Activator.CreateInstance(t, false);

                if (newFrm is Template.BaseTemplate)
                {
                    ((Template.BaseTemplate)newFrm).MenuOptionID = MenuOptionID;
                }

                ShowForm(newFrm);
            }
        }

        public static void ShowForm(Form frm)
        {
            try
            {
                frm.MdiParent = DashBoard;
                frm.FormClosed += Chiled_FormClosed;
                frm.Show();
                //DashBoard.ribbonMain.Minimized = true;
            }
            catch (ObjectDisposedException)
            { }
        }

        public static object GetFormInstance<T>()
        {
            return DashBoard.MdiChildren.OfType<T>().FirstOrDefault();
        }

        static void Chiled_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (DashBoard.MdiChildren.Count() <= 1)
            //{
            //    DashBoard.ribbonMain.Minimized = false;
            //}
        }

        private void Default_StyleChanged(object sender, EventArgs e)
        {
            SettingsDAL.SaveSettingL0("GUIThemeSkinName", UserLookAndFeel.Default.SkinName);
        }


        private void btnSettingsUser_UserRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Users.frmUserGroup>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnSettingsUser_UserMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Users.frmUser>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //Properties.Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            //Properties.Settings.Default.Save();
            //--
            Application.Exit();
            base.OnClosing(e);
        }

        private void btnSettingsInstitue_InstitueMaster_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Settings.frmCompany>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnSettingsInstitue_FinancialPeriod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Settings.frmFinancialPeriod>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnSettingsApplicationSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowForm<Settings.frmApplicationSettings>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnCity_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Vision.WinForm.City.frmCity>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnState_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Vision.WinForm.City.frmState>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnCountry_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Vision.WinForm.City.frmCountry>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            Users.frmChangePassword frm = new Users.frmChangePassword();
            frm.ShowDialog(this);
        }

        private void btnCurrencyMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<SubMaster.frmCurrency>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnBankName_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<SubMaster.frmBankName>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnBankBranch_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<SubMaster.frmBankBranch>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnBankAccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Account.frmBankAccount>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveType_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmLeaveType>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnMinimumWageCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmMinimumWageCategory>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnNonCashBenefit_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmNonCashBenefit>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnSettings_BiometricDevice_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<BMDevice.frmBiometricDevice>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployee>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnAttendanceReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Employee.frmRepEmployeeAttendanceDetail>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Settings.frmLocation>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnMinimumWageCategoryRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmMinimumWageCategoryRateChange>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeDesignation_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployeeDesignation>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TimeAttendance.frmRepDailyAttendanceGridFormat>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnRepLateIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowForm<Reports.TimeAttendance.frmRepLateIn>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEarlyGoingReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowForm<Reports.TimeAttendance.frmRepEarlyGoing>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnMissedPunchReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //ShowForm<Reports.TimeAttendance.frmRepMissedPunch>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnDailyAttendanceSummaryReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TimeAttendance.frmRepDailyAttendanceSummary>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeAttendanceSummaryReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TimeAttendance.frmRepEmployeeAttendanceSummary>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEarningDeduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmEarningDeduction>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployeeDepartment>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeWIBAClass_ItemClick(object sender, ItemClickEventArgs e)
        {            
            ShowForm<Employee.frmEmployeeWIBAClass>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployeeNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeAccountingLedger_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployeeAccountingLedger>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnHolidayMaster_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmHoliday>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveApplication_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmLeaveApplication>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnSafari_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmSafariApplication>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveApplicationNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmLeaveApplicationNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnSafariApplicationNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmSafariApplicationNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveEncashmentNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmLeaveEncashmentNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveAdjustmentNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmLeaveAdjustmentNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveEncashment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmLeaveEncashment>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveAdjustment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmLeaveAdjustment>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeShift_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployeeShift>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeShiftAllocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployeeShiftAllocation>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeAttendanceDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TimeAttendance.frmRepEmployeeAttendanceDetail>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLeaveSafariTransactionReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TimeAttendance.frmRepEmployeeLeaveSafariTransactionReport>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnTimeAttendanceReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TimeAttendance.frmRepTimeAttendanceReport>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLoanApplicationNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Loan.frmLoanApplicationNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLoadApplication_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Loan.frmLoanApplication>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLoanAdjustmentNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Loan.frmLoanAdjustmentNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnLoanAdjustment_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Loan.frmLoanAdjustment>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnTAApproval_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmTAApproval>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnTAApprovalNoPrefix_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmTAApprovalNoPrefix>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnTAApprovalImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmTAApprovalImportData>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeePunchingDetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.TimeAttendance.frmRepEmployeePunchingDetail>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnRestDayAllocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmEmployeeRestDay>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeWIBAClassRate_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Employee.frmEmployeeWIBAClassRate>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeePayslip_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmEmployeePayslip>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnRepEmployeeList_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Employee. frmRepEmployeeList>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }
        
        private void btnEmployementStatusReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Employee.frmRepEmployementStatusReport>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }
        
        private void btnSettings_TaxSlab_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Settings.frmTaxSlab>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeMinimumWagesReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Employee.frmRepEmployeeMinWagesReport>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnTaxSlab_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Settings.frmTaxSlab>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Payroll.frmEmployeeSalaryIncrement>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnEmployeeSalaryIncrementReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Employee.frmRepEmployeeSalaryIncrementReport>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }

        private void btnSalary_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Reports.Payroll.frmRepSalaryReport>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));//ADD NEW FORM

        }

        private void btnSettingsInstitue_Payroll_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowForm<Settings.frmPayrollMonth>(Model.CommonFunctions.ParseInt(e.Item.Tag.ToString()));
        }
    }
}
