using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.Settings;
using Vision.DAL.Users;
using Vision.Model;

namespace Vision.WinForm.Users
{
    public partial class frmSelectCompany : Template.frmNormalTemplate
    {
        UserGroupDAL UserGroupDALObj;
        CompanyDAL CompanyDAL;
        FinPeriodDAL FinPeriodDAL;
        List<Model.Settings.CompanyLookupModel> CompanyList;

        public frmSelectCompany()
        {
            InitializeComponent();

            btnSave.Caption = "Select";

            FirstControl = lookupCompany;

            UserGroupDALObj = new UserGroupDAL();
            CompanyDAL = new CompanyDAL();
            FinPeriodDAL = new FinPeriodDAL();

            FirstControl = lookupCompany;
        }

        public override void LoadLookupDataSource()
        {
            if (CommonProperties.LoginInfo.LoggedinUser != null)
            {
                if (CommonProperties.LoginInfo.LoggedinUser.SuperUser)
                {
                    CompanyList = CompanyDAL.GetLookupList();
                }
                else
                {
                    CompanyList = CompanyDAL.GetLookupList(CommonProperties.LoginInfo.LoggedinUser.UserGroupID);
                }
            }
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupCompany.Properties.ValueMember = "CompanyID";
            lookupCompany.Properties.DisplayMember = "CompanyName";
            lookupCompany.Properties.DataSource = CompanyList;

            if (CompanyList != null)
            {
                var FirstCompany = CompanyList.FirstOrDefault();

                if (FirstCompany != null)
                {
                    lookupCompany.EditValue = FirstCompany.CompanyID;
                }
            }
            base.AssignLookupDataSource();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Application.DoEvents();
            if (FirstControl != null)
            {
                FirstControl.Focus();
            }
        }

        public override bool ValidateBeforeSave()
        {
            if (lookupCompany.EditValue == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Please select company.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lookupCompany.Focus();
                return false;
                
            }
            if (lookupFinPeriod.EditValue == null)
            {
                Alit.WinformControls.MessageBox.Show(this, "Please select financial period.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lookupFinPeriod.Focus();
                return false;
            }
            return true;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            Model.CommonProperties.LoginInfo.LoggedInCompany = CompanyDAL.GetCompanyDetail((int)lookupCompany.EditValue);
            Model.CommonProperties.LoginInfo.LoggedInFinPeriod = FinPeriodDAL.GetDetailModel((int)lookupFinPeriod.EditValue);

            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            //if (Paras.SavingResult != null && (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly ||
            //    Paras.SavingResult.ExecutionResult == eExecutionResult.NotExecutedYet))
            //{
                this.Close();
            //}
            //else
            //{
            //    lookupCompany.Focus();
            //}
            base.AfterSaving(Paras);
        }

        private void lookupCompany_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupCompany.EditValue == null)
            {
                lookupFinPeriod.Properties.DataSource = null;
            }
            else
            {
                lookupFinPeriod.Properties.ValueMember = "FinPeriodID";
                lookupFinPeriod.Properties.DisplayMember = "FinPeriodName";

                List<Model.Settings.FinPeriodEditListModel> FinPerList = FinPeriodDAL.GetEditList((int)lookupCompany.EditValue);
                lookupFinPeriod.Properties.DataSource = FinPerList;
                if(FinPerList != null && FinPerList.Count > 0)
                {
                    lookupFinPeriod.EditValue = FinPerList.First().FinPeriodID;
                }
            }
        }
    }
}
