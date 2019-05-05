using Vision.Model;
using Vision.Model.Settings;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.WinForm.Settings
{
    public partial class frmApplicationSettings : Template.frmNormalTemplate
    {
        #region Field
        DAL.Settings.SettingsDAL DALObject;
        List<LicenseNofEmployeeViewModel> dsLicenseNofEmployee;
        #endregion

        #region Constructor
        public frmApplicationSettings()
        {
            InitializeComponent();            
            ExitButtonCaption = "Cancel";
            DALObject = new DAL.Settings.SettingsDAL();

            if(!CommonProperties.LoginInfo.LoggedinUser.SuperUser)
            {
                lcgLicense.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

        }
        #endregion

        #region Template Methods

        public override void LoadFormValues()
        {
            if (CommonProperties.LoginInfo.LoggedinUser.SuperUser)
            {
                dsLicenseNofEmployee = DALObject.GetLicenseNofEmployee();
            }
            base.LoadFormValues();
        }

        public override void AssignFormValues()
        {
            InitializeSettingValues();
            if (CommonProperties.LoginInfo.LoggedinUser.SuperUser)
            {
                gcLicenseNofEmployee.DataSource = dsLicenseNofEmployee;
            }
            base.AssignFormValues();
        }

        public override void ClearValues()
        {
            base.ClearValues();
            InitializeSettingValues();
        }

        void InitializeSettingValues()
        {
            #region Level 1
            
            #region Document Location
            txtDocumentLocation_EmployeeImages.Text = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_EmployeeImage;
            txtDocumentLocation_EmployeeDocument.Text = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_EmployeeDocument;
            txtDocumentLocation_LeaveApplicationDocument.Text = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LeaveApplicationDocument;
            txtDocumentLocation_SafariApplicationDocument.Text = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_SafariApplicationDocument;
            txtDocumentLocation_LoanApplicationDocument.Text = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LoanApplicationDocument;
            txtDocumentLocation_LoanAdjustmentDocument.Text = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_LoanAdjustmentDocument;
            txtDocumentLocation_TAApprovalDocument.Text = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_TAApprovalDocument;
            #endregion

            #region License
            //txtLicense_NofEmployee.Text = CommonProperties.LoginInfo.SoftwareSettings.License_NofEmployee.ToString();
            #endregion

            #region Employee
            cmbEmployee_CurrentMonthLeaveAccumulateOn.SelectedIndex = (int)CommonProperties.LoginInfo.SoftwareSettings.Employee_CurrentMonthLeaveAccumulateOn;
            #endregion

            #region Payroll
            txtOvertimeRate.EditValue = CommonProperties.LoginInfo.SoftwareSettings.OvertimeRate;
            txtDoubleOvertimeRate.EditValue = CommonProperties.LoginInfo.SoftwareSettings.DoubleOvertimeRate;
            txtWorkingHoursPerWeek.EditValue = CommonProperties.LoginInfo.SoftwareSettings.WorkingHoursPerWeek;
            txtWorkingHoursPerDay.EditValue = CommonProperties.LoginInfo.SoftwareSettings.WorkingHoursPerDay;
            txtWorkingDaysPerMonth.EditValue = CommonProperties.LoginInfo.SoftwareSettings.WorkingDaysPerMonth;
            txtLatenessPenaltyAmount.EditValue = CommonProperties.LoginInfo.SoftwareSettings.LatenessPenaltyAmount;

            txtPFContributionEmployer.EditValue = CommonProperties.LoginInfo.SoftwareSettings.PFContributionEmployer;
            txtPFContributionEmployee.EditValue = CommonProperties.LoginInfo.SoftwareSettings.PFContributionEmployee;

            #endregion

            #endregion

            #region Report
            #endregion

            #region Level 0
            txtLicense_NofCompany.Text = CommonProperties.LoginInfo.SoftwareSettings.License_NofCompany.ToString();

            #region No Reply Email Setup
            txtNoReply_EmailID.Text = CommonProperties.LoginInfo.SoftwareSettings.NoReply_EmailID ?? "";
            txtNoReply_Password.Text = CommonProperties.LoginInfo.SoftwareSettings.NoReply_Password ?? "";
            txtNoReply_SMTPHost.Text = CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPHost ?? "";
            txtNoReply_SMTPPort.Text = CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPPort.ToString();
            tswitchNoReply_SSL.IsOn = CommonProperties.LoginInfo.SoftwareSettings.NoReply_SSL;
            #endregion

            #endregion
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            ApplicationSettingsViewModel ApplicationSetting = CommonProperties.LoginInfo.SoftwareSettings;

            #region Level 0
            CommonProperties.LoginInfo.SoftwareSettings.License_NofCompany = Model.CommonFunctions.ParseInt(txtLicense_NofCompany.Text);
            
            #region No Reply Email Setup
            CommonProperties.LoginInfo.SoftwareSettings.NoReply_EmailID = txtNoReply_EmailID.Text;
            CommonProperties.LoginInfo.SoftwareSettings.NoReply_Password = txtNoReply_Password.Text;
            CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPHost = txtNoReply_SMTPHost.Text;
            CommonProperties.LoginInfo.SoftwareSettings.NoReply_SMTPPort = Model.CommonFunctions.ParseInt(txtNoReply_SMTPPort.Text);
            CommonProperties.LoginInfo.SoftwareSettings.NoReply_SSL = tswitchNoReply_SSL.IsOn;
            #endregion

            #endregion

            #region Level 1

            #region Document Location
            ApplicationSetting.DocumentLocation_EmployeeImage = txtDocumentLocation_EmployeeImages.Text;
            ApplicationSetting.DocumentLocation_EmployeeDocument = txtDocumentLocation_EmployeeDocument.Text;
            ApplicationSetting.DocumentLocation_LeaveApplicationDocument = txtDocumentLocation_LeaveApplicationDocument.Text;
            ApplicationSetting.DocumentLocation_SafariApplicationDocument = txtDocumentLocation_SafariApplicationDocument.Text;
            ApplicationSetting.DocumentLocation_LoanApplicationDocument = txtDocumentLocation_LoanApplicationDocument.Text;
            ApplicationSetting.DocumentLocation_LoanAdjustmentDocument = txtDocumentLocation_LoanAdjustmentDocument.Text;
            ApplicationSetting.DocumentLocation_TAApprovalDocument = txtDocumentLocation_TAApprovalDocument.Text;
            #endregion

            #region License
            //CommonProperties.LoginInfo.SoftwareSettings.License_NofEmployee = CommonFunctions.ParseInt(txtLicense_NofEmployee.Text);
            if (dsLicenseNofEmployee != null)
            {
                var rLicenseNofEmployee = dsLicenseNofEmployee.FirstOrDefault(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                if (rLicenseNofEmployee != null)
                {
                    CommonProperties.LoginInfo.SoftwareSettings.License_NofEmployee = rLicenseNofEmployee.NofEmployee;
                    CommonProperties.LoginInfo.SoftwareSettings.License_ValidUpto = rLicenseNofEmployee.ValidUpto;
                }
            }
            #endregion

            #region Employee
            CommonProperties.LoginInfo.SoftwareSettings.Employee_CurrentMonthLeaveAccumulateOn = (eEmployee_LeaveAccumulateOn) cmbEmployee_CurrentMonthLeaveAccumulateOn.SelectedIndex;
            #endregion

            #region Payroll
            ApplicationSetting.OvertimeRate = (decimal)txtOvertimeRate.EditValue;
            ApplicationSetting.DoubleOvertimeRate = (decimal)txtDoubleOvertimeRate.EditValue;
            ApplicationSetting.WorkingHoursPerWeek = (decimal)txtWorkingHoursPerWeek.EditValue;
            ApplicationSetting.WorkingHoursPerDay = (decimal)txtWorkingHoursPerDay.EditValue;
            ApplicationSetting.WorkingDaysPerMonth = (decimal)txtWorkingDaysPerMonth.EditValue;
            ApplicationSetting.LatenessPenaltyAmount = (decimal)txtLatenessPenaltyAmount.EditValue;

            ApplicationSetting.PFContributionEmployer = (decimal)txtPFContributionEmployer.EditValue;
            ApplicationSetting.PFContributionEmployee = (decimal)txtPFContributionEmployee.EditValue;

            #endregion

            #endregion

            Paras.SavingResult = DALObject.SaveSettings(ApplicationSetting
                , CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                , dsLicenseNofEmployee);
            //Model.CommonProperties.LoginInfo.SoftwareSettings = DALObject.GetSetting();
            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                Navigation.frmDashBoard.DashBoard.ApplySettingsOnMenus();
                this.Close();
            }
            base.AfterSaving(Paras);
        }
        #endregion

        private void txtDocumentLocation_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (sender is ButtonEdit)
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog(this) == DialogResult.OK)
                    {
                        ((ButtonEdit)sender).Text = fbd.SelectedPath;
                    }
                }
            }
        }

        private void txtWorkingHoursPerWeek_EditValueChanged(object sender, EventArgs e)
        {
            calculateWorkingHoursPerMonth();
        }

        private void txtWorkingDaysPerMonth_EditValueChanged(object sender, EventArgs e)
        {
            calculateWorkingHoursPerMonth();
        }

        void calculateWorkingHoursPerMonth()
        {
            txtWorkingHoursPerMonth.EditValue = ((decimal)txtWorkingHoursPerWeek.EditValue * 52M) / 12M;
        }

        private void txtPFContributionEmployer_Validating(object sender, CancelEventArgs e)
        {
            decimal EmployerPerc = ((decimal?)txtPFContributionEmployer.EditValue ?? 0);
            //--
            if (EmployerPerc == 0)
            {
                ErrorProvider.SetError(txtPFContributionEmployer, "Please enter PF Contribution Employer %");
            }
            else if(EmployerPerc < 0 || EmployerPerc > 1)
            {
                ErrorProvider.SetError(txtPFContributionEmployer, "Please enter valid PF Contribution Employer % value. Valid upto 100% only.");
            }
            else
            {
                ErrorProvider.SetError(txtPFContributionEmployer, null);
            }
        }
    }
}
