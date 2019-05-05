using Vision.Model;
using Vision.Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Vision.WinForm.Users
{
    public partial class frmUser : Template.frmCRUDTemplate
    {
        DAL.Users.UserDAL DALObject;
        DAL.Users.UserGroupDAL UserGroupDALObj;
        object dsUserGroup;
        public frmUser()
        {
            InitializeComponent();
            DALObject = new DAL.Users.UserDAL();
            UserGroupDALObj = new DAL.Users.UserGroupDAL();

            FirstControl = txtUserName;
        }

        #region Override Methods
        public override void LoadLookupDataSource()
        {
            dsUserGroup = UserGroupDALObj.GetLookupList();
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookUpUserGroup.Properties.ValueMember = "UserGroupID";
            lookUpUserGroup.Properties.DisplayMember = "UserGroupName";
            lookUpUserGroup.Properties.DataSource = dsUserGroup;

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            DAL.tblUser SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew)
            {
                SaveModel = new DAL.tblUser();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((UserEditListModel)EditRecordDataSource).UserID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.UserName = txtUserName.Text;
            SaveModel.Password = txtPassword.Text;
            SaveModel.UserGroupID = (int)lookUpUserGroup.EditValue;
            SaveModel.EMailID = txtEmailID.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblUser EditingRecord = DALObject.FindSaveModelByPrimeKey(((UserEditListModel)RecordToFill).UserID);

            txtUserName.Text = EditingRecord.UserName;
            txtPassword.Text = EditingRecord.Password;
            lookUpUserGroup.EditValue = EditingRecord.UserGroupID;
            txtEmailID.Text = EditingRecord.EMailID;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((UserEditListModel)EditRecordDataSource).UserID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((UserEditListModel)EditRecordDataSource).UserID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((UserEditListModel)EditRecordDataSource).UserID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((UserEditListModel)EditRecordDataSource).UserID);
        }
        #endregion

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtUserName.Text))
            {
                ErrorProvider.SetError(txtUserName, "Please enter user name.");
            }
            else if(DALObject.IsDuplicateRecord(txtUserName.Text, (EditRecordDataSource != null ? ((UserEditListModel)EditRecordDataSource).UserID : 0 )))
            {
                ErrorProvider.SetError(txtUserName, "Entered user name is already exists.");
            }
            else
            {
                ErrorProvider.SetError(txtUserName, "");
            }
        }

        private void lookUpUserGroup_Validating(object sender, CancelEventArgs e)
        {
            if(lookUpUserGroup.EditValue == null)
            {
                ErrorProvider.SetError(lookUpUserGroup, "Please select a user.");
            }
            else
            {
                ErrorProvider.SetError(lookUpUserGroup, "");
            }
        }

        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtEmailID.Text))
            {
                ErrorProvider.SetError(txtEmailID, "Please enter email id.");
            }
            else if(!Regex.IsMatch(txtEmailID.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                ErrorProvider.SetError(txtEmailID, "Please enter valid email id");
            }
            else
            {
                ErrorProvider.SetError(txtEmailID, "");
            }
        }
    }
}