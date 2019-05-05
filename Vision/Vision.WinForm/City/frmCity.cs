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
using Vision.Model.City;
using Vision.Model;
using Vision.DAL.City;

namespace Vision.WinForm.City
{
    public partial class frmCity : Template.frmCRUDTemplate
    {
        DAL.City.CityDAL DALObject;
        StateDAL StateDAL;
        object dsState;

        public frmCity()
        {
            InitializeComponent();
            DALObject = new DAL.City.CityDAL();
            StateDAL = new StateDAL();

            FirstControl = txtCityName;
        }

        #region Overriden Methods
        
        public override void LoadLookupDataSource()
        {
            dsState = StateDAL.GetEditList();
            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupState.Properties.ValueMember = "StateID";
            lookupState.Properties.DisplayMember = "StateName";
            lookupState.Properties.DataSource = dsState;

            base.AssignLookupDataSource();
        }

        public override bool ValidateBeforeSave()
        {
            return base.ValidateBeforeSave();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            DAL.tblCity SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblCity();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((Model.City.CityEditListModel)EditRecordDataSource).CityID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.CityName = txtCityName.Text;
            //eCityType CityType = (eCityType)lookupCityType.EditValue;
            //SaveModel.CityType = (int)lookupCityType.EditValue;

            //SaveModel.TehsilID = (CityType == eCityType.Town ? (int?)lookupTehsil.EditValue : null);
            //SaveModel.DistrictID = (CityType == eCityType.Town || CityType == eCityType.Tehsil ? (int?)lookupDistrict.EditValue : null);

            if (lookupState.EditValue != null)
            {
                SaveModel.StateID = (int)lookupState.EditValue;
            }
            else
            {
                SaveModel.StateID = null;
            }
            //SaveModel.PIN = txtPIN.Text;
            //SaveModel.STDCode = txtSTDCode.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblCity EditingRecord = DALObject.FindSaveModelByPrimeKey(((Model.City.CityEditListModel)RecordToFill).CityID);



            txtCityName.Text = EditingRecord.CityName;
            //lookupCityType.EditValue = EditingRecord.CityType;

            //lookupTehsil.EditValue = EditingRecord.TehsilID;
            //lookupDistrict.EditValue = EditingRecord.DistrictID;
            lookupState.EditValue = EditingRecord.StateID;

            //txtPIN.Text = EditingRecord.PIN;
            //txtSTDCode.Text = EditingRecord.STDCode;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((Model.City.CityEditListModel)EditRecordDataSource).CityID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((Model.City.CityEditListModel)EditRecordDataSource).CityID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((CityEditListModel)EditRecordDataSource).CityID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((CityEditListModel)EditRecordDataSource).CityID);
        }
        #endregion

        #region Form Methods
        //private void lookupCityType_EditValueChanged(object sender, EventArgs e)
        //{
        //    eCityType CityType = (eCityType)lookupCityType.EditValue;

        //    switch(CityType)
        //    {
        //        case eCityType.Town:
        //            lciTehsil.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        //            lciDisctrict.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        //            break;
        //        case eCityType.Tehsil:
        //            lciTehsil.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        //            ErrorProvider.SetError(lookupTehsil, "");

        //            lciDisctrict.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        //            break;
        //        case eCityType.District:
        //            lciTehsil.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        //            ErrorProvider.SetError(lookupTehsil, "");

        //            lciDisctrict.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        //            ErrorProvider.SetError(lookupDistrict, "");
        //            break;
        //    }
        //}

        private void txtCityName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCityName.Text == "")
            {
                ErrorProvider.SetError(txtCityName, "Please enter city name");
            }
            else if (DALObject.IsDuplicateRecord(txtCityName.Text,
                (EditRecordDataSource != null ? ((Model.City.CityEditListModel)EditRecordDataSource).CityID : 0),
                (lookupState.EditValue != null? (int?)lookupState.EditValue : 0)))
            {
                ErrorProvider.SetError(txtCityName, "City name is already exists, please enter another name.");
            }
            else
            {
                ErrorProvider.SetError(txtCityName, "");
            }
        }

        //private void lookupTehsil_Validating(object sender, CancelEventArgs e)
        //{
        //    if (lookupTehsil.EditValue == null)
        //    {
        //        ErrorProvider.SetError(lookupTehsil, "Please select Tehsil.");
        //    }
        //    else
        //    {
        //        ErrorProvider.SetError(lookupTehsil, "");
        //    }
        //}

        //private void lookupDistrict_Validating(object sender, CancelEventArgs e)
        //{
        //    if (lookupDistrict.EditValue == null)
        //    {
        //        ErrorProvider.SetError(lookupDistrict, "Please select District.");
        //    }
        //    else
        //    {
        //        ErrorProvider.SetError(lookupDistrict, "");
        //    }
        //}
        #endregion
    }
}