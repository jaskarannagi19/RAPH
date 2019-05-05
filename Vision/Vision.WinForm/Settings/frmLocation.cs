using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL;
using Vision.DAL.Settings;
using Vision.Model;
using Vision.Model.Settings;

namespace Vision.WinForm.Settings
{
    public partial class frmLocation : Template.frmCRUDTemplate
    {
        LocationDAL DALObject;

        public frmLocation()
        {
            InitializeComponent();
            DALObject = new LocationDAL();
            FirstControl = txtLocationName;
        }

        public override void InitializeDefaultValues()
        {
            cmbLocationType.SelectedIndex = 0;
            //--
            lciWithEffectDate.Visibility = (FormCurrentUI == eFormCurrentUI.Edit ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
            //--
            cmbWeekendMonday.SelectedIndex = 0;
            cmbWeekendTuesday.SelectedIndex = 0;
            cmbWeekendWednesday.SelectedIndex = 0;
            cmbWeekendThursday.SelectedIndex = 0;
            cmbWeekendFriday.SelectedIndex = 0;
            cmbWeekendSaturday.SelectedIndex = 0;
            cmbWeekendSunday.SelectedIndex = 0;
            //--
            base.InitializeDefaultValues();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLocation SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblLocation();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LocationEditListModel)EditRecordDataSource).LocationID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LocationName = txtLocationName.Text;
            SaveModel.LocationTypeID = (byte)cmbLocationType.SelectedIndex;
            SaveModel.GracePeriod = Model.CommonFunctions.ParseInt(txtGracePeriod.Text);

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel, new LocationWeekendSettingViewModel()
            {
                WEDateFrom = (DateTime?)deWithEffectDate.EditValue,
                Monday = (eWeekDayType)cmbWeekendMonday.SelectedIndex,
                Tuesday = (eWeekDayType)cmbWeekendTuesday.SelectedIndex,
                Wednesday = (eWeekDayType)cmbWeekendWednesday.SelectedIndex,
                Thursday = (eWeekDayType)cmbWeekendThursday.SelectedIndex,
                Friday = (eWeekDayType)cmbWeekendFriday.SelectedIndex,
                Saturday = (eWeekDayType)cmbWeekendSaturday.SelectedIndex,
                Sunday = (eWeekDayType)cmbWeekendSunday.SelectedIndex,
            });
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            LocationEditListModel EditingRecord = (LocationEditListModel)RecordToFill;
            if(EditingRecord == null)
            {
                return;
            }
            tblLocation SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.LocationID);

            txtLocationName.Text = SaveModel.LocationName;
            cmbLocationType.SelectedIndex = SaveModel.LocationTypeID;
            txtGracePeriod.EditValue = SaveModel.GracePeriod;

            LocationWeekendSettingViewModel WeekEndSetting = DALObject.GetLatestWeekendSetting(SaveModel.LocationID);
            if (WeekEndSetting != null)
            {
                deWithEffectDate.EditValue = (WeekEndSetting.WEDateTo != null ? WeekEndSetting.WEDateTo.Value.AddDays(1).Date : DateTime.Now.Date);
                cmbWeekendMonday.SelectedIndex = (int)WeekEndSetting.Monday;
                cmbWeekendTuesday.SelectedIndex = (int)WeekEndSetting.Tuesday;
                cmbWeekendWednesday.SelectedIndex = (int)WeekEndSetting.Wednesday;
                cmbWeekendThursday.SelectedIndex = (int)WeekEndSetting.Thursday;
                cmbWeekendFriday.SelectedIndex = (int)WeekEndSetting.Friday;
                cmbWeekendSaturday.SelectedIndex = (int)WeekEndSetting.Saturday;
                cmbWeekendSunday.SelectedIndex = (int)WeekEndSetting.Sunday;
            }
            else
            {
                deWithEffectDate.EditValue = null;
                cmbWeekendMonday.SelectedIndex = 0;
                cmbWeekendTuesday.SelectedIndex = 0;
                cmbWeekendWednesday.SelectedIndex = 0;
                cmbWeekendThursday.SelectedIndex = 0;
                cmbWeekendFriday.SelectedIndex = 0;
                cmbWeekendSaturday.SelectedIndex = 0;
                cmbWeekendSunday.SelectedIndex = 0;
            }
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LocationEditListModel)EditRecordDataSource).LocationID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LocationEditListModel)EditRecordDataSource).LocationID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LocationEditListModel)EditRecordDataSource).LocationID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LocationEditListModel)EditRecordDataSource).LocationID);
        }

        private void txtLocationName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLocationName.Text == "")
            {
                ErrorProvider.SetError(txtLocationName, "Can not accept blank Location name.");
            }
            else if (DALObject.IsDuplicateRecord(txtLocationName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((LocationEditListModel)EditRecordDataSource).LocationID : 0)))
            {
                ErrorProvider.SetError(txtLocationName, "Can not accept duplicate Location name.");
            }
            else
            {
                ErrorProvider.SetError(txtLocationName, "");
            }
        }

        private void txtGracePeriod_Validating(object sender, CancelEventArgs e)
        {
            if(Model.CommonFunctions.ParseInt(txtGracePeriod.Text) > 1380)
            {
                ErrorProvider.SetError(txtGracePeriod, "Grace period can be more than 1380 minute (23 hours).");
            }
            else
            {
                ErrorProvider.SetError(txtGracePeriod, "");
            }
        }

        private void cmbWeekendMonday_Validating(object sender, CancelEventArgs e)
        {
            if(sender != null && sender is DevExpress.XtraEditors.ComboBoxEdit)
            {
                DevExpress.XtraEditors.ComboBoxEdit control = (DevExpress.XtraEditors.ComboBoxEdit)sender;

                if(control.SelectedIndex < 0)
                {
                    ErrorProvider.SetError(control, "Please select value.");
                }
                else
                {
                    ErrorProvider.SetError(control, string.Empty);
                }
            }
        }
    }
}
