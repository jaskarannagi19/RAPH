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
    public partial class frmForgetPassword : Template.frmNormalTemplate
    {
        DAL.Users.UserDAL UserDALObj;
        public frmForgetPassword()
        {
            InitializeComponent();
            FirstControl = txtUserName;
            UserDALObj = new DAL.Users.UserDAL();
            btnSave.Caption = "Reset Password";

            FirstControl = txtUserName;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            txtUserName.Focus();
        }

        Model.Users.UserDetailModel SelectedUser;
        public override void SaveRecord(SavingParemeter Paras)
        {
            SelectedUser = UserDALObj.GetUserDetailModelByEmailID(txtUserName.Text, txtEMailID.Text);
            if (SelectedUser == null)
            {
                Paras.SavingResult = new SavingResult()
                {
                    ExecutionResult = eExecutionResult.ValidationError,
                    ValidationError = "Entered user name or email id is not found."
                };
                return;
            }
            else
            {
                string NewPassword = Guid.NewGuid().ToString().Substring(0, 6);

                Paras.SavingResult = UserDALObj.ChangePassworD(SelectedUser.UserID, NewPassword);

                if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                {
                    Model.CommonFunctions.SendEmailFromNoReply(SelectedUser.EMailID,
                        "Password reset for Vision",
                        $@"Your password has been reset to login in Vision :

User Name : {SelectedUser.UserName}
Password : { NewPassword}

Please login into Vision and change your password.");
                }

                Paras.SavingResult.MessageAfterSave = "Your new password has been sent to email id " + SelectedUser.EMailID + ".";
                Paras.SavingResult.ExecutionResult = eExecutionResult.NotExecutedYet;
            }
            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if(SelectedUser != null)
            {
                this.Close();
            }

            base.AfterSaving(Paras);
        }
    }
}
