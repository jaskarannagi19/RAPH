using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision.DAL.Employee;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.WinForm.Employee
{
    public partial class frmEmployeeShift : Template.frmCRUDTemplate
    {
        EmployeeShiftDAL DALObject;

        public frmEmployeeShift()
        {
            InitializeComponent();
            DALObject = new EmployeeShiftDAL();
            FirstControl = txtEmployeeShiftName;
        }

        #region Template
        public override void InitializeDefaultValues()
        {
            cmbShiftType.SelectedIndex = 0;
            
            //-- --
            deShiftStart.EditValue = null;
            deShiftEnd.EditValue = null;

            deBreak1Start.EditValue = null;
            deBreak1End.EditValue = null;
            deBreak2Start.EditValue = null;
            deBreak2End.EditValue = null;
            deBreak3Start.EditValue = null;
            deBreak3End.EditValue = null;

            base.InitializeDefaultValues();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployeeShift SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployeeShift();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EmployeeShiftEditListModel)EditRecordDataSource).EmployeeShiftID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeShiftName = txtEmployeeShiftName.Text;
            SaveModel.ShiftType = (byte)cmbShiftType.SelectedIndex;

            SaveModel.ShiftStartTime = deShiftStart.DateTime.TimeOfDay;
            SaveModel.ShiftEndTime = deShiftEnd.DateTime.TimeOfDay;

            SaveModel.FirstBreakStartTime = (deBreak1Start.EditValue != null ? (TimeSpan?)deBreak1Start.DateTime.TimeOfDay : null);
            SaveModel.FirstBreakEndTime = (deBreak1Start.EditValue != null ? (TimeSpan?)deBreak1End.DateTime.TimeOfDay : null);
            SaveModel.SecondBreakStartTime = (deBreak2Start.EditValue != null ? (TimeSpan?)deBreak2Start.DateTime.TimeOfDay : null);
            SaveModel.SecondBreakEndTime = (deBreak2End.EditValue != null ? (TimeSpan?)deBreak2End.DateTime.TimeOfDay : null);
            SaveModel.ThirdBreakStartTime = (deBreak3Start.EditValue != null ? (TimeSpan?)deBreak3Start.DateTime.TimeOfDay : null);
            SaveModel.ThirdBreakEndTime = (deBreak3End.EditValue != null ? (TimeSpan?)deBreak3End.DateTime.TimeOfDay : null); 

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            EmployeeShiftEditListModel EditingRecord = (EmployeeShiftEditListModel)RecordToFill;
            DAL.tblEmployeeShift SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.EmployeeShiftID);

            if (SaveModel == null) return;

            txtEmployeeShiftName.Text = SaveModel.EmployeeShiftName;

            cmbShiftType.SelectedIndex = SaveModel.ShiftType;

            deShiftStart.DateTime = DateTime.MinValue.Add(SaveModel.ShiftStartTime);
            deShiftEnd.DateTime = DateTime.MinValue.Add(SaveModel.ShiftEndTime);

            if (SaveModel.FirstBreakStartTime != null)
            {
                deBreak1Start.DateTime = DateTime.MinValue.Add(SaveModel.FirstBreakStartTime.Value);
            }
            else
            {
                deBreak1Start.EditValue = null;
            }

            if (SaveModel.FirstBreakEndTime != null)
            {
                deBreak1End.DateTime = DateTime.MinValue.Add(SaveModel.FirstBreakEndTime.Value);
            }
            else
            {
                deBreak1End.EditValue = null;
            }

            if (SaveModel.SecondBreakStartTime != null)
            {
                deBreak2Start.DateTime = DateTime.MinValue.Add(SaveModel.SecondBreakStartTime.Value);
            }
            else
            {
                deBreak2Start.EditValue = null;
            }

            if (SaveModel.SecondBreakEndTime != null)
            {
                deBreak2End.DateTime = DateTime.MinValue.Add(SaveModel.SecondBreakEndTime.Value);
            }
            else
            {
                deBreak2End.EditValue = null;
            }

            if (SaveModel.ThirdBreakStartTime != null)
            {
                deBreak3Start.DateTime = DateTime.MinValue.Add(SaveModel.ThirdBreakStartTime.Value);
            }
            else
            {
                deBreak3Start.EditValue = null;
            }

            if (SaveModel.ThirdBreakEndTime != null)
            {
                deBreak3End.DateTime = DateTime.MinValue.Add(SaveModel.ThirdBreakEndTime.Value);
            }
            else
            {
                deBreak3End.EditValue = null;
            }
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EmployeeShiftEditListModel)EditRecordDataSource).EmployeeShiftID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EmployeeShiftEditListModel)EditRecordDataSource).EmployeeShiftID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EmployeeShiftEditListModel)EditRecordDataSource).EmployeeShiftID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EmployeeShiftEditListModel)EditRecordDataSource).EmployeeShiftID);
        }
        #endregion

        #region Validating
        private void txtEmployeeShiftName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtEmployeeShiftName.Text))
            {
                ErrorProvider.SetError(txtEmployeeShiftName, "Can not accept blank Employee Shift Name.");
            }
            else if (DALObject.IsDuplicateRecord(txtEmployeeShiftName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeShiftEditListModel)EditRecordDataSource).EmployeeShiftID : 0)))
            {
                ErrorProvider.SetError(txtEmployeeShiftName, "Can not accept duplicate Employee Shift Name.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeShiftName, "");
            }
        }

        private void deShiftStart_Validating(object sender, CancelEventArgs e)
        {
            if (deShiftStart.EditValue == null)
            {
                ErrorProvider.SetError(deShiftStart, "Please enter shift start time.");
            }
            else
            {
                ErrorProvider.SetError(deShiftStart, "");
            }
        }

        private void deShiftEnd_Validating(object sender, CancelEventArgs e)
        {
            if (deShiftEnd.EditValue == null)
            {
                ErrorProvider.SetError(deShiftEnd, "Please enter shift start time.");
            }
            //else if(deShiftStart.EditValue != null && deShiftEnd.DateTime < deShiftStart.DateTime)
            //{
            //    ErrorProvider.SetError(deShiftEnd, "Shift End time must be greater than Shift Start.");
            //}
            else
            {
                ErrorProvider.SetError(deShiftEnd, "");
            }
        }

        private void deBreak1Start_Validating(object sender, CancelEventArgs e)
        {
            if (deBreak1Start.EditValue == null && deBreak1End.EditValue != null)
            {
                ErrorProvider.SetError(deBreak1Start, "Pleae enter first tea break start time.");
            }
            else
            {
                ErrorProvider.SetError(deBreak1Start, "");
            }

            //if (deBreak1Start.EditValue != null && (deShiftStart.EditValue != null && deBreak1Start.DateTime < deShiftStart.DateTime) )
            //{
            //    ErrorProvider.SetError(deBreak1Start, "First tea break start time must be greater than shift start time.");
            //}
            //else
            //{
            //    ErrorProvider.SetError(deBreak1Start, "");
            //}
        }

        private void deBreak1End_Validating(object sender, CancelEventArgs e)
        {
            if(deBreak1Start.EditValue != null && deBreak1End.EditValue == null)
            {
                ErrorProvider.SetError(deBreak1End, "Pleae enter first tea break end time.");
            }
            else
            {
                ErrorProvider.SetError(deBreak1End, "");
            }

            //if (deBreak1End.EditValue != null && (deShiftEnd.EditValue != null && deBreak1End.DateTime > deShiftEnd.DateTime))
            //{
            //    ErrorProvider.SetError(deBreak1End, "First tea break end time must be less than shift end time.");
            //}
            //else 
            //if (deBreak1Start.EditValue != null && deBreak1End.EditValue != null && deBreak1End.DateTime < deBreak1Start.DateTime)
            //{
            //    ErrorProvider.SetError(deBreak1End, "First tea break end time must be greater then break start time.");
            //}
            //else
            //{
            //    ErrorProvider.SetError(deBreak1End, "");
            //}
        }

        private void deBreak2Start_Validating(object sender, CancelEventArgs e)
        {
            if (deBreak2Start.EditValue == null && deBreak2End.EditValue != null)
            {
                ErrorProvider.SetError(deBreak2Start, "Pleae enter lunch break start time.");
            }
            else
            {
                ErrorProvider.SetError(deBreak2Start, "");
            }
            //if (deBreak2Start.EditValue != null)
            //{
            //    if (deBreak1End.EditValue != null && deBreak2Start.DateTime < deBreak1End.DateTime)
            //    {
            //        ErrorProvider.SetError(deBreak2Start, "Lunch break start time must be greater than first tea break's end time.");
            //    }
            //    else if (deBreak2Start.EditValue != null && (deShiftStart.EditValue != null && deBreak2Start.DateTime < deShiftStart.DateTime))
            //    {
            //        ErrorProvider.SetError(deBreak2Start, "Lunch break start time must be greater than shift start time.");
            //    }
            //    else
            //    {
            //        ErrorProvider.SetError(deBreak2Start, "");
            //    }
            //}
        }

        private void deBreak2End_Validating(object sender, CancelEventArgs e)
        {

            if (deBreak2Start.EditValue != null && deBreak2End.EditValue == null)
            {
                ErrorProvider.SetError(deBreak2End, "Pleae enter lunch break end time.");
            }
            else
            {
                ErrorProvider.SetError(deBreak2End, "");
            }
            //if (deBreak2End.EditValue != null && (deShiftEnd.EditValue != null && deBreak2End.DateTime > deShiftEnd.DateTime))
            //{
            //    ErrorProvider.SetError(deBreak2End, "Lunch break end time must be less than shift end time.");
            //}
            //else 
            //if (deBreak2Start.EditValue != null && deBreak2End.EditValue != null && deBreak2End.DateTime < deBreak2Start.DateTime)
            //{
            //    ErrorProvider.SetError(deBreak2End, "Lunch break end time must be greater then start time.");
            //}
            //else
            //{
            //    ErrorProvider.SetError(deBreak2End, "");
            //}
        }

        private void deBreak3Start_Validating(object sender, CancelEventArgs e)
        {
            if (deBreak3Start.EditValue == null && deBreak3End.EditValue != null)
            {
                ErrorProvider.SetError(deBreak3Start, "Pleae enter second tea break start time.");
            }
            else
            {
                ErrorProvider.SetError(deBreak3Start, "");
            }
            //if (deBreak3Start.EditValue != null)
            //{
            //    if (deBreak2End.EditValue != null && deBreak3Start.DateTime < deBreak2End.DateTime)
            //    {
            //        ErrorProvider.SetError(deBreak3Start, "Second Tea Break start time must be greater than Lunch end time.");
            //    }
            //    if (deBreak2End.EditValue == null && deBreak1End.EditValue != null && deBreak3Start.DateTime < deBreak1End.DateTime)
            //    {
            //        ErrorProvider.SetError(deBreak3Start, "Second Tea Break start time must be greater than first tea break's end time.");
            //    }
            //    else if (deBreak3Start.EditValue != null && (deShiftStart.EditValue != null && deBreak3Start.DateTime < deShiftStart.DateTime))
            //    {
            //        ErrorProvider.SetError(deBreak3Start, "Second Tea Break start time must be greater than shift start time.");
            //    }
            //    else
            //    {
            //        ErrorProvider.SetError(deBreak3Start, "");
            //    }
            //}
        }

        private void deBreak3End_Validating(object sender, CancelEventArgs e)
        {
            if (deBreak3Start.EditValue != null && deBreak3End.EditValue == null)
            {
                ErrorProvider.SetError(deBreak3End, "Pleae enter second tea break end time.");
            }
            else
            {
                ErrorProvider.SetError(deBreak3End, "");
            }
            //if (deBreak3End.EditValue != null && (deShiftEnd.EditValue != null && deBreak3End.DateTime > deShiftEnd.DateTime))
            //{
            //    ErrorProvider.SetError(deBreak3End, "Second Tea Break end time must be less than shift end time.");
            //}
            //else 
            //if (deBreak3Start.EditValue != null && deBreak3End.EditValue != null && deBreak3End.DateTime < deBreak3Start.DateTime)
            //{
            //    ErrorProvider.SetError(deBreak3End, "Second Tea Break end time must be greater then start time.");
            //}
            //else
            //{
            //    ErrorProvider.SetError(deBreak3End, "");
            //}
        }
        #endregion

        TimeSpan CalculatePositiveTimeInterval(TimeSpan From, TimeSpan To)
        {
            if(To < From)
            {
                return DateTime.Now.Date.AddDays(1).Add(To).Subtract(DateTime.Now.Date.Add(From));
            }
            else
            {
                return To.Subtract(From);
            }
        }

        private void deShiftStart_EditValueChanged(object sender, EventArgs e)
        {
            if(deShiftStart.EditValue != null && deShiftEnd.EditValue != null)
            {
                lblShiftTotalTime.Text = CalculatePositiveTimeInterval(deShiftStart.DateTime.TimeOfDay, deShiftEnd.DateTime.TimeOfDay).ToString("hh':'mm");
            }
            else
            {
                lblShiftTotalTime.Text = " ";
            }
        }

        private void deBreak1Start_EditValueChanged(object sender, EventArgs e)
        {
            if (deBreak1Start.EditValue != null && deBreak1End.EditValue != null)
            {
                lblBreak1TotalTime.Text = CalculatePositiveTimeInterval(deBreak1Start.DateTime.TimeOfDay, deBreak1End.DateTime.TimeOfDay).ToString("hh':'mm");
            }
            else
            {
                lblBreak1TotalTime.Text = " ";
            }
        }

        private void deBreak2Start_EditValueChanged(object sender, EventArgs e)
        {
            if (deBreak2Start.EditValue != null && deBreak2End.EditValue != null)
            {
                lblBreak2TotalTime.Text = CalculatePositiveTimeInterval(deBreak2Start.DateTime.TimeOfDay, deBreak2End.DateTime.TimeOfDay).ToString("hh':'mm");
            }
            else
            {
                lblBreak2TotalTime.Text = " ";
            }
        }

        private void deBreak3Start_EditValueChanged(object sender, EventArgs e)
        {
            if (deBreak3Start.EditValue != null && deBreak3End.EditValue != null)
            {
                lblBreak3TotalTime.Text = CalculatePositiveTimeInterval(deBreak3Start.DateTime.TimeOfDay, deBreak3End.DateTime.TimeOfDay).ToString("hh':'mm");
            }
            else
            {
                lblBreak3TotalTime.Text = " ";
            }
        }
    }
}
