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
using Vision.Model;
using Vision.Model.Settings;

namespace Vision.WinForm.Settings
{
    public partial class frmTaxSlab : Template.frmNormalTemplate
    {
        TaxSlabDAL DALObj;
        PAYEReliefDAL PAYEReliefDALObj;
        List<Model.Settings.TaxSlabViewModel> dsNHIF;
        List<Model.Settings.TaxSlabViewModel> dsNSSF;
        List<Model.Settings.TaxSlabViewModel> dsPAYEPrime;
        List<Model.Settings.TaxSlabViewModel> dsPAYESecond;
        List<Model.Settings.PAYEReliefeViewModel> dsPAYERelief;

        List<PAYEReliefTypeLookupModel> dsPAYEReliefTypeLookup;
        public frmTaxSlab()
        {
            InitializeComponent();

            DALObj = new DAL.Settings.TaxSlabDAL();
            PAYEReliefDALObj = new PAYEReliefDAL();
        }

        DateTime? NHIFWEDate;
        DAL.tblTaxSlabHeader NSSFHeaderSaveMdoel;
        DAL.tblTaxSlabHeader PAYEHeaderSaveMdoel;
        public override void LoadFormValues()
        {
            var NHIFHeaderSaveModel = DALObj.GetLatestTaxSlabHeader(Model.Settings.eTaxSlab_TaxType.NHIF);
            if (NHIFHeaderSaveModel != null)
            {
                NHIFWEDate = NHIFHeaderSaveModel.WEDate;
            }
            dsNHIF = DALObj.GetLatestTaxSlab(Model.Settings.eTaxSlab_TaxType.NHIF, Model.Employee.eIncomeType.Primary);


            NSSFHeaderSaveMdoel = DALObj.GetLatestTaxSlabHeader(Model.Settings.eTaxSlab_TaxType.NSSF);
            dsNSSF = DALObj.GetLatestTaxSlab(Model.Settings.eTaxSlab_TaxType.NSSF, Model.Employee.eIncomeType.Primary);

            PAYEHeaderSaveMdoel = DALObj.GetLatestTaxSlabHeader(Model.Settings.eTaxSlab_TaxType.PAYE);
            dsPAYEPrime = DALObj.GetLatestTaxSlab(Model.Settings.eTaxSlab_TaxType.PAYE, Model.Employee.eIncomeType.Primary);
            dsPAYESecond = DALObj.GetLatestTaxSlab(Model.Settings.eTaxSlab_TaxType.PAYE, Model.Employee.eIncomeType.Secondary);

            dsPAYERelief = PAYEReliefDALObj.GetEditList();

            base.LoadFormValues();
        }

        public override void AssignFormValues()
        {
            deWED_NHIF.EditValue = NHIFWEDate;
            taxSlabNHIFViewModelBindingSource.DataSource = dsNHIF;

            if (NSSFHeaderSaveMdoel != null)
            {
                deWEDateNSSF.EditValue = NSSFHeaderSaveMdoel.WEDate;
            }

            taxSlabNSSFViewModelBindingSource.DataSource = dsNSSF;

            if (PAYEHeaderSaveMdoel != null)
            {
                deWEDatePAYE.EditValue = PAYEHeaderSaveMdoel.WEDate;
            }
            taxSlabPAYEPrimeViewModelBindingSource.DataSource = dsPAYEPrime;
            taxSlabPAYESecondViewModelBindingSource.DataSource = dsPAYESecond;

            PAYEReliefeViewModelBindingSource.DataSource = dsPAYERelief;

            dsPAYEReliefTypeLookup = new List<PAYEReliefTypeLookupModel>()
            {
                new PAYEReliefTypeLookupModel() { PAYEReliefType = ePAYEReliefType.General },
                new PAYEReliefTypeLookupModel() { PAYEReliefType = ePAYEReliefType.PersonalRelief },
            };

            repositoryItemLookupReliefType.DisplayMember = "PAYEReliefType";
            repositoryItemLookupReliefType.ValueMember = "PAYEReliefType";
            repositoryItemLookupReliefType.DataSource = dsPAYEReliefTypeLookup;

            base.AssignFormValues();
        }

        private void btnUpdateNHIF_Click(object sender, EventArgs e)
        {
            DAL.tblTaxSlabHeader HeaderSaveModel = new DAL.tblTaxSlabHeader()
            {
                WEDate = (DateTime?)deWED_NHIF.EditValue,
            };
            SavingResult res = DALObj.SaveTaxSlab(HeaderSaveModel, dsNHIF, null, Model.Settings.eTaxSlab_TaxType.NHIF);
            AfterSaving(new SavingParemeter() { SavingResult = res });
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if (MessageBox.Show("Do you want to exit ?", "Saved.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void repositoryItemButtonEditRemoveNHIF_Click(object sender, EventArgs e)
        {
            taxSlabNHIFViewModelBindingSource.RemoveAt(gvNHIFTaxSlab.GetFocusedDataSourceRowIndex());
        }


        private void btnNSSFUpdate_Click(object sender, EventArgs e)
        {

            DAL.tblTaxSlabHeader HeaderSaveModel = new DAL.tblTaxSlabHeader()
            {
                WEDate = (DateTime?)deWEDateNSSF.EditValue,
            };

            SavingResult res = DALObj.SaveTaxSlab(HeaderSaveModel, dsNSSF, null, Model.Settings.eTaxSlab_TaxType.NSSF);
            AfterSaving(new SavingParemeter() { SavingResult = res });
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if (MessageBox.Show("Do you want to exit ?", "Saved.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void repositoryItemButtonEditRemoveNSSF_Click(object sender, EventArgs e)
        {
            taxSlabNSSFViewModelBindingSource.RemoveAt(gvNSSF.GetFocusedDataSourceRowIndex());
        }

        private void btnUpdatePAYE_Click(object sender, EventArgs e)
        {
            DAL.tblTaxSlabHeader HeaderSaveModel = new DAL.tblTaxSlabHeader()
            {
                WEDate = (DateTime?)deWEDatePAYE.EditValue,
            };

            SavingResult res = DALObj.SaveTaxSlab(HeaderSaveModel, dsPAYEPrime, dsPAYESecond, Model.Settings.eTaxSlab_TaxType.PAYE);
            AfterSaving(new SavingParemeter() { SavingResult = res });
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                if (MessageBox.Show("Do you want to exit ?", "Saved.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void repositoryItemButtonEditRemovePayeePrime_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            taxSlabPAYEPrimeViewModelBindingSource.RemoveAt(gvPAYEPrimary.GetFocusedDataSourceRowIndex());
        }

        private void repositoryItemButtonEditRemoveRowPAYESecond_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            taxSlabPAYESecondViewModelBindingSource.RemoveAt(gvPAYESecondry.GetFocusedDataSourceRowIndex());
        }


        private void repositoryItemButtonEditRemovePAYERelief_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PAYEReliefeViewModel Row = (PAYEReliefeViewModel)gvPAYERelief.GetFocusedRow();
            if (Row == null)
            {
                return;
            }

            var resValidation = PAYEReliefDALObj.ValidateBeforeDelete(Row.PAYEReliefID);
            if (!resValidation.IsValidForDelete)
            {
                Row.SavingError = resValidation.ValidationMessage;
                return;
            }

            var res = PAYEReliefDALObj.DeleteRecord(Row.PAYEReliefID);
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                PAYEReliefeViewModelBindingSource.RemoveAt(gvPAYERelief.GetFocusedDataSourceRowIndex());
                gvPAYERelief.RefreshData();
            }
            if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting)
            {
                Row.SavingError = "Error while saving.\r\n" + res.Exception.Message;
            }
            else if (res.ExecutionResult == eExecutionResult.ValidationError)
            {
                Row.SavingError = "Validation Errors.\r\n" + res.ValidationError;
            }
            else if (!String.IsNullOrWhiteSpace(res.MessageAfterSave))
            {
                Row.SavingError = "Please note:\r\n" + res.MessageAfterSave;
            }
        }

        private void gvPAYERelief_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (e.Row == null)
            {
                return;
            }
            SavingResult res = null;
            PAYEReliefeViewModel Row = (PAYEReliefeViewModel)e.Row;

            if (dePAYEReliefWED.EditValue == null)
            {
                res = new SavingResult();
                res.ExecutionResult = eExecutionResult.ValidationError;
                res.ValidationError = "Please enter Effective date.";
            }
            else
            {
                res = PAYEReliefDALObj.SaveNewRecord(Row, (DateTime)dePAYEReliefWED.EditValue);
            }

            Row.SavingError = null;
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                var newRow = PAYEReliefDALObj.GetViewModelByID((int)res.PrimeKeyValue);
                if (newRow != null)
                {

                    int newRowIndex = PAYEReliefeViewModelBindingSource.IndexOf(Row);
                    //Row = newRow;
                    PAYEReliefeViewModelBindingSource[newRowIndex] = newRow;
                }
                else
                {
                    PAYEReliefeViewModelBindingSource.RemoveAt(gvPAYERelief.GetFocusedDataSourceRowIndex());
                }
            }
            else if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting)
            {
                Row.SavingError = "Error while saving.\r\n" + res.Exception.Message;
            }
            else if (res.ExecutionResult == eExecutionResult.ValidationError)
            {
                Row.SavingError = "Validation Errors.\r\n" + res.ValidationError;
            }
            else if (!String.IsNullOrWhiteSpace(res.MessageAfterSave))
            {
                Row.SavingError = "Please note:\r\n" + res.MessageAfterSave;
            }
        }

        private void gvPAYERelief_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //if (e.Row == null)
            //{
            //    return;
            //}

            //PAYEReliefeViewModel Row = (PAYEReliefeViewModel)e.Row;
            //if(String.IsNullOrWhiteSpace(Row.PAYEReliefName))
            //{
            //    e.Valid = false;
            //    e.ErrorText = "Please enter relief name";
            //}
            //else if(PAYEReliefDALObj.IsDuplicateRecord(Row.PAYEReliefName, Row.PAYEReliefID))
            //{
            //    e.Valid = false;
            //    e.ErrorText = "Can not accept duplicate. Entered relief name is already exists.";
            //}
        }

        private void gvPAYERelief_MeasurePreviewHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            var Row = (PAYEReliefeViewModel)gvPAYERelief.GetRow(e.RowHandle);
            //if (gvPAYERelief.FocusedRowHandle != e.RowHandle && (Row == null || String.IsNullOrWhiteSpace(Row.SavingError)))
            if (gvPAYERelief.FocusedRowHandle != e.RowHandle && (Row == null || String.IsNullOrWhiteSpace(Row.SavingError)))
            {
                e.RowHeight = 0;
            }
        }

        private void gvPAYERelief_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gvPAYERelief.LayoutChanged();
        }

        private void gvPAYERelief_CustomDrawRowPreview(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            var Row = (PAYEReliefeViewModel)gvPAYERelief.GetRow(e.RowHandle);
            if (Row != null && !String.IsNullOrWhiteSpace(Row.SavingError))
            {
                e.Appearance.ForeColor = Color.Red;
            }
            else
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            }
        }

        private void gvPAYERelief_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column == colRemovePAYERelief)
            {
                repositoryItemButtonEditRemovePAYERelief_ButtonClick(null, null);
                //gvPAYERelief.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Default;
            }
        }
    }
}
