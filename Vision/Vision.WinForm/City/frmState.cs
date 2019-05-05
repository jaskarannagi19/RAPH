using Vision.Model;
using Vision.Model.City;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.WinForm.City
{
    public partial class frmState : Template.frmCRUDTemplate
    {
        DAL.City.CountryDAL CountryDAL;
        DAL.City.StateDAL DALObject;
        object dsCountry;
        public frmState()
        {
            InitializeComponent();

            FirstControl = txtStateName;
            DALObject = new DAL.City.StateDAL();
            CountryDAL = new DAL.City.CountryDAL();

            FirstControl = txtStateName;
        }

        public override void LoadLookupDataSource()
        {
            dsCountry = CountryDAL.GetEditList();


            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookUpCountry.Properties.DataSource = dsCountry;
            lookUpCountry.Properties.ValueMember = "CountryID";
            lookUpCountry.Properties.DisplayMember = "CountryName";

            base.AssignLookupDataSource();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            DAL.tblState SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblState();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((Model.City.StateEditListModel)EditRecordDataSource).StateID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.StateName = txtStateName.Text;
            SaveModel.CountryID = (int)lookUpCountry.EditValue;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblState EditingRecord = DALObject.FindSaveModelByPrimeKey(((Model.City.StateEditListModel)RecordToFill).StateID);

            txtStateName.Text = EditingRecord.StateName;
            lookUpCountry.EditValue = EditingRecord.CountryID;

            base.FillSelectedRecordInContent(RecordToFill);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((Model.City.StateEditListModel)EditRecordDataSource).StateID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((Model.City.StateEditListModel)EditRecordDataSource).StateID);

            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((StateEditListModel)EditRecordDataSource).StateID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((StateEditListModel)EditRecordDataSource).StateID);
        }

        private void txtStateName_Validating(object sender, CancelEventArgs e)
        {
            if(txtStateName.Text == "")
            {
                ErrorProvider.SetError(txtStateName, "Please enter state name.");
            }
            else
            {
                //ErrorProvider.SetError(txtStateName, "");
                ValidateDuplicateState();
            }
        }

        private void lookUpCountry_Validating(object sender, CancelEventArgs e)
        {
            if(lookUpCountry.EditValue == null)
            {
                ErrorProvider.SetError(lookUpCountry, "Please select country");
            }
            else
            {
                ErrorProvider.SetError(lookUpCountry, "");
                ValidateDuplicateState();
            }
        }

        void ValidateDuplicateState()
        {
            if (txtStateName.Text != "" && 
                lookUpCountry.EditValue != null &&
                DALObject.IsDuplicateRecord(txtStateName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((StateEditListModel)EditRecordDataSource).StateID : 0), (int)lookUpCountry.EditValue))
            {
                ErrorProvider.SetError(txtStateName, "Can not accept duplicate State Name.");
            }
            else
            {
                ErrorProvider.SetError(txtStateName, "");
            }
        }
    }
}
