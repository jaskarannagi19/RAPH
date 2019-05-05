using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Vision.DAL;
using Vision.DAL.Settings;
using Vision.Model.Users;
using Vision.Model;

namespace Vision.WinForm.Users
{
    public partial class frmUserLogin : Template.frmNormalTemplate
    {
        DAL.Users.UserDAL UserDAL;
        DAL.Users.UserGroupDAL UserGroupDALObj;

        //string Password { get; set; }
        public frmUserLogin()
        {
            InitializeComponent();
            AllowRefresh = false;
            SaveButtonCaption = "Login";
            //ExitButtonCaption = "Cancel";

            UserDAL = new DAL.Users.UserDAL();
            UserGroupDALObj = new DAL.Users.UserGroupDAL();

            FirstControl = txtUserName;
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            if(FirstControl != null)
            {
                FirstControl.Focus();
            }
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            Paras.SavingResult = new SavingResult();

            UserDetailModel loginUser = UserDAL.GetUserDetailModel(txtUserName.Text, txtPassword.Text);
            if (loginUser == null)
            {
                Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                Paras.SavingResult.ValidationError = "Please check, user name or password not matched.";
                return;
                //Alit.WinformControls.MessageBox.Show(this, "Please check, user name or password not matched.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //txtUserName.Focus();
                //return;
            }
            else
            {
                Model.CommonProperties.LoginInfo.LoggedinUser = loginUser;
                Model.CommonProperties.LoginInfo.UserPermission = UserGroupDALObj.GetPermission(Model.CommonProperties.LoginInfo.LoggedinUser.UserGroupID);
            }

            Paras.SavingResult.ExecutionResult = eExecutionResult.NotExecutedYet;

            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            if (Paras.SavingResult != null && (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly || 
                Paras.SavingResult.ExecutionResult == eExecutionResult.NotExecutedYet))
            {
                this.Close();
            }
            else
            {
                txtUserName.Focus();
            }
            base.AfterSaving(Paras);
        }

        private void btnForgetPassword_Click(object sender, EventArgs e)
        {
            frmForgetPassword frmForgetPassword = new frmForgetPassword();
            frmForgetPassword.ShowDialog(Navigation.frmDashBoard.DashBoard);
            txtUserName.Focus();
        }
    }
}