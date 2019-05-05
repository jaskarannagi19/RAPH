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
using Vision.Model;
using Vision.Model.City;

namespace Vision.WinForm.City
{
    public partial class frmCountry : Template.frmCRUDTemplate
    {
        DAL.City.CountryDAL DALObject;

        public frmCountry()
        {
            InitializeComponent();
            DALObject = new DAL.City.CountryDAL();

            FirstControl = txtCountryName;
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblCountry SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblCountry();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((Model.City.CountryEditListModel)EditRecordDataSource).CountryID);

                if(SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.CountryName = txtCountryName.Text;
            //SaveModel.ISDCode = txtISDCode.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            Model.City.CountryEditListModel EditingRecord = (Model.City.CountryEditListModel)RecordToFill;

            txtCountryName.Text = EditingRecord.CountryName;
            //txtISDCode.Text = EditingRecord.ISDCode;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete( ((Model.City.CountryEditListModel) EditRecordDataSource).CountryID );
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((Model.City.CountryEditListModel)EditRecordDataSource).CountryID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((CountryEditListModel)EditRecordDataSource).CountryID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((CountryEditListModel)EditRecordDataSource).CountryID);
        }

        private void txtCountryName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCountryName.Text == "")
            {
                ErrorProvider.SetError(txtCountryName, "Can not accept blank country name.");
            }
            else if (DALObject.IsDuplicateRecord(txtCountryName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((CountryEditListModel)EditRecordDataSource).CountryID : 0)))
            {
                ErrorProvider.SetError(txtCountryName, "Can not accept duplicate country name.");
            }
            else
            {
                ErrorProvider.SetError(txtCountryName, "");
            }
        }
    }
}