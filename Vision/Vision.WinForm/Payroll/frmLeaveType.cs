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
    public partial class frmLeaveType : Template.frmCRUDTemplate
    {
        LeaveTypeDAL DALObject;

        public frmLeaveType()
        {
            InitializeComponent();
            DALObject = new LeaveTypeDAL();
            FirstControl = txtLeaveTypeName;
        }

        public override void InitializeDefaultValues()
        {
            cmbEncashable.SelectedIndex = 0;
            cmbCarryForwardable.SelectedIndex = 0;
            cmbIncludeWeekend.SelectedIndex = 0;
            cmbIncludePublicHoliday.SelectedIndex = 0;
            cmbLeaveDistribution.SelectedIndex = 0;

            base.InitializeDefaultValues();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblLeaveType SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblLeaveType();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((LeaveTypeEditListModel)EditRecordDataSource).LeaveTypeID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.LeaveTypeName = txtLeaveTypeName.Text;
            SaveModel.AnnualEntitledDays = Model.CommonFunctions.ParseDecimal(txtAnnualEntitledDays.Text);
            SaveModel.ApplicableTo = (byte)cmbApplicableTo.SelectedIndex;
            SaveModel.Notes = txtNotes.Text;
            SaveModel.IsEncashable = cmbEncashable.SelectedIndex == 0;
            SaveModel.CanCarryForward = cmbCarryForwardable.SelectedIndex == 0;
            SaveModel.IncludeWeekend = cmbIncludeWeekend.SelectedIndex == 0;
            SaveModel.IncludePublicHoliday = cmbIncludePublicHoliday.SelectedIndex == 0;
            SaveModel.Distribute = (byte)cmbLeaveDistribution.SelectedIndex;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblLeaveType EditingRecord = DALObject.FindSaveModelByPrimeKey(((LeaveTypeEditListModel)RecordToFill).LeaveTypeID);

            if(EditingRecord == null)
            {
                return;
            }

            txtLeaveTypeName.Text = EditingRecord.LeaveTypeName;
            txtAnnualEntitledDays.EditValue = EditingRecord.AnnualEntitledDays;
            cmbApplicableTo.SelectedIndex = EditingRecord.ApplicableTo;
            txtNotes.Text = EditingRecord.Notes;
            cmbEncashable.SelectedIndex = (EditingRecord.IsEncashable ? 0 : 1);
            cmbCarryForwardable.SelectedIndex = (EditingRecord.CanCarryForward ? 0 : 1);
            cmbIncludeWeekend.SelectedIndex = (EditingRecord.IncludeWeekend ? 0 : 1);
            cmbIncludePublicHoliday.SelectedIndex = (EditingRecord.IncludePublicHoliday ? 0 : 1);
            cmbLeaveDistribution.SelectedIndex = EditingRecord.Distribute;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((LeaveTypeEditListModel)EditRecordDataSource).LeaveTypeID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((LeaveTypeEditListModel)EditRecordDataSource).LeaveTypeID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((LeaveTypeEditListModel)EditRecordDataSource).LeaveTypeID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((LeaveTypeEditListModel)EditRecordDataSource).LeaveTypeID);
        }

        private void txtLeaveTypeName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLeaveTypeName.Text == "")
            {
                ErrorProvider.SetError(txtLeaveTypeName, "Can not accept blank Leave Type name.");
            }
            else if (DALObject.IsDuplicateRecord(txtLeaveTypeName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((LeaveTypeEditListModel)EditRecordDataSource).LeaveTypeID : 0)))
            {
                ErrorProvider.SetError(txtLeaveTypeName, "Can not accept duplicate Leave Type name.");
            }
            else
            {
                ErrorProvider.SetError(txtLeaveTypeName, "");
            }
        }

        private void txtAnnualEntitledDays_Validating(object sender, CancelEventArgs e)
        {
            if(!Model.CommonFunctions.CheckParseDecimal(txtAnnualEntitledDays.Text))
            {
                ErrorProvider.SetError(txtAnnualEntitledDays, "Please enter valid numeric value");
            }
            else if(Model.CommonFunctions.ParseDecimal(txtAnnualEntitledDays.Text) == 0)
            {
                ErrorProvider.SetError(txtAnnualEntitledDays, "Please enter Annual Entitled Days");
            }
            else
            {
                ErrorProvider.SetError(txtAnnualEntitledDays, "");
            }
        }

        private void cmbApplicableTo_Validating(object sender, CancelEventArgs e)
        {
            if(cmbApplicableTo.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbApplicableTo, "Please select Applicate to");
            }
            else
            {
                ErrorProvider.SetError(cmbApplicableTo, "");
            }
        }
    }
}
