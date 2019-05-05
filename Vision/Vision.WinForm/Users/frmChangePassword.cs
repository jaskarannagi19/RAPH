using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.Model;

namespace Vision.WinForm.Users
{
    public partial class frmChangePassword : Template.frmNormalTemplate
    {
        DAL.Users.UserDAL UserDALObj;
        public frmChangePassword()
        {
            InitializeComponent();

            UserDALObj = new DAL.Users.UserDAL();

            btnSave.Caption = "Change Password";
            FirstControl = txtCurrentPassword;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            txtCurrentPassword.Focus();
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtNewPassword.Text.Length < 6)
            {
                ErrorProvider.SetError(txtNewPassword, "Please enter password of atleast 6 characters.");
            }
            else if(txtNewPassword.Text == txtCurrentPassword.Text)
            {
                ErrorProvider.SetError(txtNewPassword, "New password can not be same as old password.");
            }
            else
            {
                ErrorProvider.SetError(txtNewPassword, "");
            }
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            var User = UserDALObj.GetUserDetailModel(CommonProperties.LoginInfo.LoggedinUser.UserName, txtCurrentPassword.Text);
            if(User == null)
            {
                Paras.SavingResult = new SavingResult()
                {
                    ExecutionResult = eExecutionResult.ValidationError,
                    ValidationError = "Password is not correct."
                };
                return;
            }

            Paras.SavingResult = UserDALObj.ChangePassworD(CommonProperties.LoginInfo.LoggedinUser.UserID, txtNewPassword.Text);

            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if(Paras.SavingResult != null && Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                this.Close();
            }

            base.AfterSaving(Paras);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ErrorProvider.SetError(txtConfirmPassword, "New password did not matched with confirm password.");
            }
            else
            {
                ErrorProvider.SetError(txtConfirmPassword, "");
            }
        }
    }
}
