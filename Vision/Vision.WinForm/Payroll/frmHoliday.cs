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
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmHoliday : Template.frmCRUDTemplate
    {
        HolidayDAL DALObject;

        public frmHoliday()
        {
            InitializeComponent();
            DALObject = new HolidayDAL();
            FirstControl = txtHolidayName;
        }

        public override void InitializeDefaultValues()
        {
            cmbHolidayType.SelectedIndex = 0;
            cmbRepeatOnSameDate.SelectedIndex = 0;
            deDateFrom.EditValue = null;
            deDateTo.EditValue = null;
            base.InitializeDefaultValues();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblHoliday SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblHoliday();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((HolidayEditListModel)EditRecordDataSource).HolidayID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.HolidayName = txtHolidayName.Text;
            SaveModel.HolidayType = (byte)cmbHolidayType.SelectedIndex;
            SaveModel.RepeatOnSameDate = cmbRepeatOnSameDate.SelectedIndex == 1;
            SaveModel.FromDate = deDateFrom.DateTime;
            SaveModel.ToDate = deDateTo.DateTime;
            SaveModel.TotalDays = Model.CommonFunctions.ParseInt(txtNofDays.Text);
            SaveModel.Remarks = txtRemarks.Text;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblHoliday SaveModel = DALObject.FindSaveModelByPrimeKey(((HolidayEditListModel)RecordToFill).HolidayID);

            if (SaveModel == null)
            {
                return;
            }

            txtHolidayName.Text = SaveModel.HolidayName;

            cmbHolidayType.SelectedIndex = SaveModel.HolidayType;
            cmbRepeatOnSameDate.SelectedIndex = SaveModel.RepeatOnSameDate ? 1 : 0;
            deDateFrom.DateTime = SaveModel.FromDate;
            deDateTo.DateTime = SaveModel.ToDate;
            txtNofDays.EditValue = SaveModel.TotalDays;
            txtRemarks.Text = SaveModel.Remarks;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((HolidayEditListModel)EditRecordDataSource).HolidayID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((HolidayEditListModel)EditRecordDataSource).HolidayID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((HolidayEditListModel)EditRecordDataSource).HolidayID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((HolidayEditListModel)EditRecordDataSource).HolidayID);
        }


        #region Validation
        private void txtHolidayName_Validating(object sender, CancelEventArgs e)
        {
            if (txtHolidayName.Text == "")
            {
                ErrorProvider.SetError(txtHolidayName, "Can not accept blank Non Cash Benefit name.");
            }
            else if (DALObject.IsDuplicateRecord(txtHolidayName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((HolidayEditListModel)EditRecordDataSource).HolidayID : 0)))
            {
                ErrorProvider.SetError(txtHolidayName, "Can not accept duplicate Non Cash Benefit name.");
            }
            else
            {
                ErrorProvider.SetError(txtHolidayName, "");
            }
        }

        private void cmbHolidayType_Validating(object sender, CancelEventArgs e)
        {
            if(cmbHolidayType.SelectedIndex < 0)
            {
                ErrorProvider.SetError(cmbHolidayType, "Please select Holiday Type.");
            }
            else
            {
                ErrorProvider.SetError(cmbHolidayType, "");
            }
        }

        private void deDateTo_Validating(object sender, CancelEventArgs e)
        {
            if (deDateTo.EditValue == null)
            {
                ErrorProvider.SetError(deDateTo, "Please select Date To.");
            }
            else if (deDateFrom.EditValue != null && deDateTo.DateTime < deDateFrom.DateTime)
            {
                ErrorProvider.SetError(deDateTo, "Date to must be greater than date from.");
            }
            else
            {
                ErrorProvider.SetError(deDateTo, "");
            }
        }

        private void deDateFrom_Validating(object sender, CancelEventArgs e)
        {
            if (deDateFrom.EditValue == null)
            {
                ErrorProvider.SetError(deDateFrom, "Please select date from");
            }
            else
            {
                ErrorProvider.SetError(deDateFrom, "");
            }
        }

        private void cmbRepeatOnSameDate_Validating(object sender, CancelEventArgs e)
        {
            if (cmbRepeatOnSameDate.SelectedIndex < 0)
            {
                ErrorProvider.SetError(cmbRepeatOnSameDate, "Please select repeat on same date.");
            }
            else
            {
                ErrorProvider.SetError(cmbRepeatOnSameDate, "");
            }
        }
        #endregion

        #region Events
        private void deDateTo_EditValueChanged(object sender, EventArgs e)
        {
            UpdateNofDays();
        }

        private void deDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            if(deDateFrom.EditValue != null && (deDateTo.EditValue == null || deDateTo.DateTime < deDateFrom.DateTime))
            {
                deDateTo.EditValue = deDateFrom.DateTime;
            }

            UpdateNofDays();
        }
        
        #endregion

        #region Methods
        void UpdateNofDays()
        {
            txtNofDays.EditValue = (deDateFrom.EditValue != null && deDateTo.EditValue != null ? deDateTo.DateTime.Subtract(deDateFrom.DateTime).Days + 1 : 0);
        }
        #endregion

    }
}
