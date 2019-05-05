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
using Vision.Model.Settings;

namespace Vision.WinForm.Users
{
    public partial class frmUserGroup : Template.frmCRUDTemplate
    {
        DAL.Settings.CompanyDAL CompanyDALObj;
        DAL.Users.UserGroupDAL DALObject;
        DAL.Settings.MenuOptionsDAL MenuOptionsDALObj;

        List<MenuOptionPermissionViewModel> dsPermission;
        List<CompanyMultiSelectLookupModel> dsCompany;
        List<LocationUserGroupAccessMultiSelectListModel> dsLocation;

        public frmUserGroup()
        {
            InitializeComponent();

            CompanyDALObj = new DAL.Settings.CompanyDAL();
            DALObject = new DAL.Users.UserGroupDAL();
            MenuOptionsDALObj = new DAL.Settings.MenuOptionsDAL();

            FirstControl = txtUserGroupName;
        }

        #region Override Methods

        public override void LoadFormValues()
        {
            dsPermission = DALObject.GetPermission(0);
            base.LoadFormValues();
        }

        public override void LoadLookupDataSource()
        {
            dsCompany = CompanyDALObj.GetMuliSelectLookupList();
            dsLocation = DALObject.GetLocationList(0);
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            gcCompany.DataSource = dsCompany;

            gvCompany.Columns["CompanyName"].OptionsColumn.ReadOnly = true;

            gvCompany.Columns["Selected"].MinWidth = 30;
            gvCompany.Columns["Selected"].MaxWidth = 50;

            gcLocation.DataSource = dsLocation;
            gvLocation.Columns["CompanyName"].OptionsColumn.ReadOnly = true;
            gvLocation.Columns["LocationName"].OptionsColumn.ReadOnly = true;

            gvLocation.Columns["Selected"].MinWidth = 30;
            gvLocation.Columns["Selected"].MaxWidth = 50;
            //--
            base.AssignLookupDataSource();
        }

        public override void AssignFormValues()
        {
            gridControlPermission.DataSource = dsPermission;
            base.AssignFormValues();
        }

        public override void InitializeDefaultValues()
        {
            chkbCanView.Checked = false;
            chkbCanAdd.Checked = false;
            chkbCanEdit.Checked = false;
            chkbCanDelete.Checked = false;
            chkbCanAuthorize.Checked = false;
            chkbCanUnAuthorize.Checked = false;
            dsPermission.ForEach(r => { r.CanView = false; r.CanAdd = false; r.CanEdit = false; r.CanDelete = false; r.CanAuthorize = false; r.CanUnAuthorize = false; });
            gridControlPermission.DataSource = null;
            gridControlPermission.DataSource = dsPermission;
            //gridViewPermission.Invalidate();
            gridViewPermission.ExpandAllGroups();

            //((List<Model.Settings.CompanyMultiSelectLookupModel>)gvCompany.DataSource).ForEach(r => r.Selected = false);
            dsCompany.ForEach(r => r.Selected = false);
            gcCompany.DataSource = null;
            gcCompany.DataSource = dsCompany;

            dsLocation.ForEach(r => r.Selected = false);
            gcLocation.DataSource = null;
            gcLocation.DataSource = dsLocation;

            base.InitializeDefaultValues();
        }

        public override bool ValidateBeforeSave()
        {
            gvCompany.CloseEditor();
            gvCompany.UpdateCurrentRow();

            gvLocation.CloseEditor();
            gvLocation.UpdateCurrentRow();

            gridViewPermission.CloseEditor();
            gridViewPermission.UpdateCurrentRow();

            return base.ValidateBeforeSave();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            DAL.tblUserGroup SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew)
            {
                SaveModel = new DAL.tblUserGroup();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((UserGroupEditListModel)EditRecordDataSource).UserGroupID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another UserGroup.";
                    return;
                }
            }

            SaveModel.UserGroupName = txtUserGroupName.Text;


            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel, (List<Model.Users.MenuOptionPermissionViewModel>)gridControlPermission.DataSource, (List<Model.Settings.CompanyMultiSelectLookupModel>)gvCompany.DataSource,
                dsLocation);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblUserGroup EditingRecord = DALObject.FindSaveModelByPrimeKey(((UserGroupEditListModel)RecordToFill).UserGroupID);

            txtUserGroupName.Text = EditingRecord.UserGroupName;

            gcCompany.DataSource = DALObject.GetUserGroupPermissionOnCompanies(EditingRecord.UserGroupID);

            var PermissionSource = from r in MenuOptionsDALObj.GetMenus()
                                   join jm in EditingRecord.tblUserGroupPerimissions on r.MenuOptionID equals jm.MenuOptionID into gm
                                   from rm in gm.DefaultIfEmpty()
                                   select new MenuOptionPermissionViewModel()
                                   {
                                       MenuOptionID = r.MenuOptionID,
                                       MenuOptionName = r.MenuOptionName,
                                       MenuOptionGroupName = r.MenuOptionGroupName,
                                       MenuOptionType = r.MenuType,

                                       CanView = (rm != null && rm.CanRead),
                                       CanAdd = (rm != null && rm.CanAdd),
                                       CanEdit = (rm != null && rm.CanEdit),
                                       CanDelete = (rm != null && rm.CanDelete)
                                   };

            gridControlPermission.DataSource = PermissionSource.ToList();
            gridViewPermission.ExpandAllGroups();

            dsLocation = DALObject.GetLocationList(EditingRecord.UserGroupID);
            gcLocation.DataSource = dsLocation;

        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((UserGroupEditListModel)EditRecordDataSource).UserGroupID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((UserGroupEditListModel)EditRecordDataSource).UserGroupID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((UserGroupEditListModel)EditRecordDataSource).UserGroupID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((UserGroupEditListModel)EditRecordDataSource).UserGroupID);
        }
        #endregion

        private void txtUseGroupName_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtUserGroupName.Text))
            {
                ErrorProvider.SetError(txtUserGroupName, "Please enter user group name.");
            }
            else if(DALObject.IsDuplicateRecord(txtUserGroupName.Text, (EditRecordDataSource != null ? ((UserGroupEditListModel)EditRecordDataSource).UserGroupID : 0)))
            {
                ErrorProvider.SetError(txtUserGroupName, "Entered name is already exists.");
            }
            else
            {
                ErrorProvider.SetError(txtUserGroupName, "");
            }
        }

        private void chkbCanView_CheckedChanged(object sender, EventArgs e)
        {
            gridControlPermission.BeginUpdate();
            for (int ri = 0; ri < gridViewPermission.RowCount; ri++)
            {
                var row = gridViewPermission.GetRow(ri);
                if(row != null)
                {
                    ((MenuOptionPermissionViewModel)row).CanView = chkbCanView.Checked;
                }
            }
            gridControlPermission.EndUpdate();
        }

        private void chkbCanAdd_CheckedChanged(object sender, EventArgs e)
        {
            gridControlPermission.BeginUpdate();
            for (int ri = 0; ri < gridViewPermission.RowCount; ri++)
            {
                var row = gridViewPermission.GetRow(ri);
                if (row != null)
                {
                    var obj = (MenuOptionPermissionViewModel)row;
                    if (obj.MenuOptionType == Model.Settings.eMenuOptionType.CRUD)
                    {
                        obj.CanAdd = chkbCanAdd.Checked;
                    }
                }
            }
            gridControlPermission.EndUpdate();
        }

        private void chkbCanEdit_CheckedChanged(object sender, EventArgs e)
        {
            gridControlPermission.BeginUpdate();
            for (int ri = 0; ri < gridViewPermission.RowCount; ri++)
            {
                var row = gridViewPermission.GetRow(ri);
                if (row != null)
                {
                    var obj = (MenuOptionPermissionViewModel)row;
                    if (obj.MenuOptionType == Model.Settings.eMenuOptionType.CRUD)
                    {
                        obj.CanEdit = chkbCanEdit.Checked;
                    }
                }
            }
            gridControlPermission.EndUpdate();
        }

        private void chkbCanDelete_CheckedChanged(object sender, EventArgs e)
        {
            gridControlPermission.BeginUpdate();
            for (int ri = 0; ri < gridViewPermission.RowCount; ri++)
            {
                var row = gridViewPermission.GetRow(ri);
                if (row != null)
                {
                    var obj = (MenuOptionPermissionViewModel)row;
                    if (obj.MenuOptionType == Model.Settings.eMenuOptionType.CRUD)
                    {
                        obj.CanDelete = chkbCanDelete.Checked;
                    }
                }
            }
            gridControlPermission.EndUpdate();
        }

        private void chkbCanAuthorize_CheckedChanged(object sender, EventArgs e)
        {
            gridControlPermission.BeginUpdate();
            for (int ri = 0; ri < gridViewPermission.RowCount; ri++)
            {
                var row = gridViewPermission.GetRow(ri);
                if (row != null)
                {
                    var obj = (MenuOptionPermissionViewModel)row;
                    if (obj.MenuOptionType == Model.Settings.eMenuOptionType.CRUD)
                    {
                        obj.CanAuthorize = chkbCanAuthorize.Checked;
                    }
                }
            }
            gridControlPermission.EndUpdate();
        }

        private void chkbCanUnAuthorize_CheckedChanged(object sender, EventArgs e)
        {
            gridControlPermission.BeginUpdate();
            for (int ri = 0; ri < gridViewPermission.RowCount; ri++)
            {
                var row = gridViewPermission.GetRow(ri);
                if (row != null)
                {
                    var obj = (MenuOptionPermissionViewModel)row;
                    if (obj.MenuOptionType == Model.Settings.eMenuOptionType.CRUD)
                    {
                        obj.CanUnAuthorize = chkbCanUnAuthorize.Checked;
                    }
                }
            }
            gridControlPermission.EndUpdate();
        }

        private void gridViewPermission_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if(e.Column == gridViewPermission.Columns["CanView"])
            {
                gridControlPermission.BeginUpdate();
                MenuOptionPermissionViewModel obj = (MenuOptionPermissionViewModel)gridViewPermission.GetRow(e.RowHandle);
                if(obj != null)
                {
                    if (obj.MenuOptionType == Model.Settings.eMenuOptionType.CRUD)
                    {
                        obj.CanAdd = obj.CanView;
                        obj.CanEdit = obj.CanView;
                        obj.CanDelete = obj.CanView;
                    }
                }
                gridControlPermission.EndUpdate();
            }
        }

        private void gridViewPermission_ShowingEditor(object sender, CancelEventArgs e)
        {
            var row = gridViewPermission.GetFocusedRow();
            if(row != null)
            {
                var obj = (MenuOptionPermissionViewModel)row;
                if(obj != null && obj.MenuOptionType != Model.Settings.eMenuOptionType.CRUD && gridViewPermission.FocusedColumn != gridViewPermission.Columns["CanView"])
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
