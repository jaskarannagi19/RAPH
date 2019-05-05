using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Vision.DAL;
using Vision.DAL.Payroll;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.WinForm.Payroll
{
    public partial class frmNonCashBenefit : Template.frmCRUDTemplate
    {
        NonCashBenefitDAL DALObject;

        public frmNonCashBenefit()
        {
            InitializeComponent();
            DALObject = new NonCashBenefitDAL();
            FirstControl = txtNonCashBenefitName;
        }

        public override void InitializeDefaultValues()
        {
            cmbBenifitType.SelectedIndex = 0;
            cmbKRAValueType.SelectedIndex = 0;
            cmbCostValueType.SelectedIndex = 0;

            txtCostValue.EditValue = 0M;
            txtKRAValue.EditValue = 0M;
            txtEngineCCKRAValue.EditValue = 0M;
            txtVehicleCostKRAPerc.EditValue = 0M;

            base.InitializeDefaultValues();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblNonCashBenefit SaveModel = null;

            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblNonCashBenefit();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((NonCashBenefitEditListModel)EditRecordDataSource).NonCashBenefitID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.NonCashBenefitName = txtNonCashBenefitName.Text;
            SaveModel.NonCashBenefitType = (byte)cmbBenifitType.SelectedIndex;

            SaveModel.KRAValueType = (byte)cmbKRAValueType.SelectedIndex;
            SaveModel.KRAValue = (decimal)txtKRAValue.EditValue;

            SaveModel.CostValueType = (byte)cmbCostValueType.SelectedIndex;
            SaveModel.CostValue = (decimal)txtCostValue.EditValue;

            SaveModel.VehicleType = txtVehicleType.Text;
            SaveModel.VehicleRegistrationNo = txtRegistrationNo.Text;
            SaveModel.VehicleMake = txtMake.Text;
            SaveModel.VehicleModel = txtModelNo.Text;
            SaveModel.VehicleEnginePower = txtEnginePowerCC.Text;
            SaveModel.EngineCCKRAValue = (decimal)txtEngineCCKRAValue.EditValue;
            SaveModel.VehicleCostKRAPerc = (decimal)txtVehicleCostKRAPerc.EditValue;

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FormatEditListGridView(GridView EditListGrid)
        {
            EditListGrid.Columns["NonCashBenefitType"].MaxWidth = 100;

            EditListGrid.Columns["CostValueType"].MaxWidth = 100;

            EditListGrid.Columns["CostValue"].MaxWidth = 125;
            EditListGrid.Columns["CostValue"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            EditListGrid.Columns["CostValue"].DisplayFormat.FormatString = "n2";

            EditListGrid.Columns["KRAValueType"].MaxWidth = 100;

            EditListGrid.Columns["KRAValue"].MaxWidth = 125;
            EditListGrid.Columns["KRAValue"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            EditListGrid.Columns["KRAValue"].DisplayFormat.FormatString = "n2";

            EditListGrid.Columns["KRAValuePercentage"].MaxWidth = 125;
            EditListGrid.Columns["KRAValuePercentage"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            EditListGrid.Columns["KRAValuePercentage"].DisplayFormat.FormatString = "p4";

            base.FormatEditListGridView(EditListGrid);
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblNonCashBenefit EditingRecord = DALObject.FindSaveModelByPrimeKey(((NonCashBenefitEditListModel)RecordToFill).NonCashBenefitID);

            if (EditingRecord == null)
            {
                return;
            }

            txtNonCashBenefitName.Text = EditingRecord.NonCashBenefitName;
            cmbBenifitType.SelectedIndex = (int)EditingRecord.NonCashBenefitType;

            cmbKRAValueType.SelectedIndex = (int)EditingRecord.KRAValueType;
            txtKRAValue.EditValue = EditingRecord.KRAValue;

            cmbCostValueType.SelectedIndex = (int)EditingRecord.CostValueType;
            txtCostValue.EditValue = EditingRecord.CostValue;

            txtVehicleType.Text = EditingRecord.VehicleType;
            txtRegistrationNo.Text = EditingRecord.VehicleRegistrationNo;
            txtMake.Text= EditingRecord.VehicleMake;
            txtModelNo.Text = EditingRecord.VehicleModel;
            txtEnginePowerCC.Text = EditingRecord.VehicleEnginePower;

            txtEngineCCKRAValue.EditValue = EditingRecord.EngineCCKRAValue;
            txtVehicleCostKRAPerc.EditValue = EditingRecord.VehicleCostKRAPerc;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((NonCashBenefitEditListModel)EditRecordDataSource).NonCashBenefitID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((NonCashBenefitEditListModel)EditRecordDataSource).NonCashBenefitID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((NonCashBenefitEditListModel)EditRecordDataSource).NonCashBenefitID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((NonCashBenefitEditListModel)EditRecordDataSource).NonCashBenefitID);
        }

        private void txtNonCashBenefitName_Validating(object sender, CancelEventArgs e)
        {
            if (txtNonCashBenefitName.Text == "")
            {
                ErrorProvider.SetError(txtNonCashBenefitName, "Can not accept blank Non Cash Benefit name.");
            }
            else if (DALObject.IsDuplicateRecord(txtNonCashBenefitName.Text, (FormCurrentUI == eFormCurrentUI.Edit ? ((NonCashBenefitEditListModel)EditRecordDataSource).NonCashBenefitID : 0)))
            {
                ErrorProvider.SetError(txtNonCashBenefitName, "Can not accept duplicate Non Cash Benefit name.");
            }
            else
            {
                ErrorProvider.SetError(txtNonCashBenefitName, "");
            }
        }

        private void txtKRAValue_Validating(object sender, CancelEventArgs e)
        {
            if (txtKRAValue.EditValue == null || !(txtKRAValue.EditValue is decimal))
            {
                ErrorProvider.SetError(txtKRAValue, "Please enter valid numeric value in KRA Value");
            }
            else if (((decimal)txtKRAValue.EditValue) == 0)
            {
                ErrorProvider.SetError(txtKRAValue, "Please enter KRA Value");
            }
            else
            {
                ErrorProvider.SetError(txtKRAValue, "");
            }
        }

        public override Size GetLargestControlSize()
        {
            return (txtNonCashBenefitName == null ? Size.Empty : txtNonCashBenefitName.Size);
        }

        private void cmbBenifitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((eNonCashBenefitType)cmbBenifitType.SelectedIndex) == eNonCashBenefitType.Vehicle)
            {
                lcgVehicleDetail.Enabled = true;

                cmbKRAValueType.SelectedIndex = (int)eNonCashBenefitKRAValueType.Fixed;
                cmbKRAValueType.ReadOnly = true;
                cmbKRAValueType.TabStop = false;

                cmbCostValueType.SelectedIndex = (int)eNonCashBenefitCostValueType.Fixed;
                cmbCostValueType.ReadOnly = true;
                cmbCostValueType.TabStop = false;

                txtKRAValue.ReadOnly = true;
                txtKRAValue.TabStop = false;
            }
            else
            {
                lcgVehicleDetail.Enabled = false;

                cmbKRAValueType.ReadOnly = false;
                cmbKRAValueType.TabStop = true;

                cmbCostValueType.ReadOnly = false;
                cmbCostValueType.TabStop = true;

                txtKRAValue.ReadOnly = false;
                txtKRAValue.TabStop = true;
            }
        }

        private void cmbKRAValueType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((eNonCashBenefitKRAValueType)cmbKRAValueType.SelectedIndex)== eNonCashBenefitKRAValueType.Percentage)
            {
                txtKRAValue.Properties.Mask.EditMask = "p4";
            }
            else
            {
                txtKRAValue.Properties.Mask.EditMask = "n2";
            }
        }

        void UpdateVehicleKRAValue()
        {
            if (((eNonCashBenefitType)cmbBenifitType.SelectedIndex) == eNonCashBenefitType.Vehicle)
            {
                txtKRAValue.EditValue = Math.Max((decimal?)txtEngineCCKRAValue.EditValue ?? 0, (((decimal?)txtCostValue.EditValue) ?? 0) * ((decimal?)txtVehicleCostKRAPerc.EditValue ?? 0));
            }
        }

        private void txtCostValue_EditValueChanged(object sender, EventArgs e)
        {
            UpdateVehicleKRAValue();
        }

        private void txtEngineCCKRAValue_EditValueChanged(object sender, EventArgs e)
        {
            UpdateVehicleKRAValue();
        }

        private void txtVehicleCostKRAPerc_EditValueChanged(object sender, EventArgs e)
        {
            UpdateVehicleKRAValue();
        }

        private void txtRegistrationNo_Validating(object sender, CancelEventArgs e)
        {
            if( ((eNonCashBenefitType)cmbBenifitType.SelectedIndex) == eNonCashBenefitType.Vehicle && String.IsNullOrWhiteSpace(txtRegistrationNo.Text))
            {
                ErrorProvider.SetError(txtEnginePowerCC, "Please enter registration number.");
            }
            else
            {
                ErrorProvider.SetError(txtEnginePowerCC, "");
            }
        }

        private void txtEnginePowerCC_Validating(object sender, CancelEventArgs e)
        {
            if (((eNonCashBenefitType)cmbBenifitType.SelectedIndex) == eNonCashBenefitType.Vehicle && String.IsNullOrWhiteSpace(txtEnginePowerCC.Text))
            {
                ErrorProvider.SetError(txtEnginePowerCC, "Please enter engine power.");
            }
            else
            {
                ErrorProvider.SetError(txtEnginePowerCC, "");
            }
        }
    }
}
