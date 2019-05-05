using Vision.DAL.Settings;
using Vision.Model;
using Vision.Model.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision.WinForm.Settings
{
    public partial class frmFinancialPeriod : Template.frmCRUDTemplate
    {
        FinPeriodDAL DALObject;
        public frmFinancialPeriod()
        {
            InitializeComponent();
            DALObject = new FinPeriodDAL();

            FirstControl = deStartDate;
        }

        FinPeriodDetailModel PrevFinPeriod = null;
        FinPeriodDetailModel NextFinPeriod = null;
        bool IsSaving = false;

        #region Overridden Methods
        public override void ClearValues()
        {
            IsSaving = false;
            base.ClearValues();
        }

        public async override void InitializeDefaultValues()
        {
            PrevFinPeriod = null;
            NextFinPeriod = null;

            deStartDate.Enabled = true;
            deEndDate.Enabled = true;

            lcgAccountBalance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcgProductStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            splitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

            FirstControl = deStartDate;
            if (FormCurrentUI == Model.eFormCurrentUI.NewEntry)
            {
                PrevFinPeriod = DALObject.GetLatestFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                if (PrevFinPeriod != null)
                {
                    lblPrevFinPeriod.Text = PrevFinPeriod.FinPeriodFrom.ToShortDateString() + " - ";
                    if (PrevFinPeriod.FinPeriodTo != null)
                    {
                        lblPrevFinPeriod.Text = lblPrevFinPeriod.Text + PrevFinPeriod.FinPeriodTo.Value.ToShortDateString();

                        deStartDate.EditValue = null;
                        deStartDate.EditValue = PrevFinPeriod.FinPeriodTo.Value.Date.AddDays(1).Date;
                        deStartDate.Enabled = false;

                        FirstControl = deEndDate;
                    }
                    else
                    {
                        lblPrevFinPeriod.Text = lblPrevFinPeriod.Text + "*";

                        FirstControl = deStartDate;
                    }
                    SetFocusOnFirstControl();


                    //-- Calculate Account's Balances
                    gridControlAccountBalance.DataSource = await DALObject.GetAccountClosingBalance(PrevFinPeriod.CompanyID, PrevFinPeriod.FinPeriodID);
                    gridviewAccountBalance.Columns["AccountNo"].Width = 100;
                    gridviewAccountBalance.Columns["AccountName"].Width = 300;
                    gridviewAccountBalance.Columns["CompanyName"].Width = 200;
                    gridviewAccountBalance.Columns["Address"].Width = 150;
                    gridviewAccountBalance.Columns["City"].Width = 100;
                    gridviewAccountBalance.Columns["MobileNo"].Width = 100;
                    gridviewAccountBalance.Columns["OpeningBalance"].Width = 100;


                    //gridcontrolProductStock.DataSource = await DALObject.GetProductOpeningBalance(PrevFinPeriod.CompanyID, PrevFinPeriod.FinPeriodID);
                    //gridviewProductStock.Columns["ProductCode"].Width = 100;
                    //gridviewProductStock.Columns["ProductName"].Width = 300;
                    //gridviewProductStock.Columns["Stock"].Width = 100;
                    //gridviewProductStock.Columns["UnitName"].Width = 100;


                    lcgAccountBalance.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcgProductStock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    splitterItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }

            base.InitializeDefaultValues();
        }

        public override bool ValidateBeforeSave()
        {
            IsSaving = true;
            return base.ValidateBeforeSave();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            DAL.tblFinPeriod SaveModel = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblFinPeriod();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((FinPeriodEditListModel)EditRecordDataSource).FinPeriodID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.FinPeriodName = txtFinPerName.Text;
            SaveModel.FinPeriodFrom = (DateTime)deStartDate.EditValue;
            
            SaveModel.FinPeriodTo = (DateTime?)deEndDate.EditValue;
            
            SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;

            List<AccountClosingBalanceViewModel> OpeningBalances = null;
            if (chkTransferAccountOpeningBalance.Checked)
            {
                OpeningBalances = (List<AccountClosingBalanceViewModel>)gridControlAccountBalance.DataSource;
            }
            List<ProductOpeningStockViewModel> OpeningStock = null;
            if (chkTransferProductStock.Checked)
            {
                OpeningStock = (List<ProductOpeningStockViewModel>)gridcontrolProductStock.DataSource;
            }

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel, PrevFinPeriod, NextFinPeriod, OpeningBalances, OpeningStock);
            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            DAL.tblFinPeriod EditingRecord = DALObject.FindSaveModelByPrimeKey(((FinPeriodEditListModel)RecordToFill).FinPeriodID);

            txtFinPerName.Text = EditingRecord.FinPeriodName;

            deStartDate.EditValue = null;
            deStartDate.EditValue = EditingRecord.FinPeriodFrom;
            deEndDate.EditValue = null;
            if(EditingRecord.FinPeriodTo.HasValue)
            {
                deEndDate.EditValue = EditingRecord.FinPeriodTo.Value;
            }

            PrevFinPeriod = DALObject.GetPreviousFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, EditingRecord.FinPeriodFrom);

            deStartDate.Enabled = (PrevFinPeriod == null);


            if (EditingRecord.FinPeriodTo == null)
            {
                NextFinPeriod = null;
            }
            else
            {
                NextFinPeriod = DALObject.GetNextFinPeriod(Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID, EditingRecord.FinPeriodTo.Value);
            }

            deEndDate.Enabled = (NextFinPeriod == null);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((FinPeriodEditListModel)EditRecordDataSource).FinPeriodID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((FinPeriodEditListModel)EditRecordDataSource).FinPeriodID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((FinPeriodEditListModel)EditRecordDataSource).FinPeriodID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((FinPeriodEditListModel)EditRecordDataSource).FinPeriodID);
        }
        #endregion

        #region Form Methods
        private void textFinPerName_Validating(object sender, CancelEventArgs e)
        {
            if(txtFinPerName.Text == "")
            {
                ErrorProvider.SetError(txtFinPerName, "Please enter financial period name.");
            }
            else
            {
                ErrorProvider.SetError(txtFinPerName, "");
            }
        }

        private void deStartDate_Validating(object sender, CancelEventArgs e)
        {
            if(deStartDate.EditValue == null)
            {
                ErrorProvider.SetError(deStartDate, "Please select date from");
            }
            else if(FormCurrentUI == Model.eFormCurrentUI.NewEntry &&
                PrevFinPeriod != null &&
                (
                    (DateTime)deStartDate.EditValue <= PrevFinPeriod.FinPeriodFrom ||
                    (PrevFinPeriod.FinPeriodTo.HasValue && (DateTime)deStartDate.EditValue <= PrevFinPeriod.FinPeriodTo.Value))
                
                )
            {
                ErrorProvider.SetError(deStartDate, "Financial period should start after previous financial period.");
            }
            else 
            {
                ErrorProvider.SetError(deStartDate, "");
                if (!IsSaving)
                {
                    txtFinPerName.Text = ((DateTime)deStartDate.EditValue).Date.Year.ToString() + " - " +
                        (deEndDate.EditValue == null ? "*" : ((DateTime)deEndDate.EditValue).Date.Year.ToString());
                }
            }
        }

        private void deEndDate_Validating(object sender, CancelEventArgs e)
        {
            if (deStartDate.EditValue != null)
            {
                if (deEndDate.EditValue != null && (DateTime)deEndDate.EditValue < (DateTime)deStartDate.EditValue)
                {
                    ErrorProvider.SetError(deEndDate, "Financial period date to should be greater than from date.");
                }
                else if(!IsSaving)
                {
                    ErrorProvider.SetError(deEndDate, "");
                    if (!IsSaving)
                    {
                        txtFinPerName.Text = ((DateTime)deStartDate.EditValue).Date.Year.ToString() + " - " +
                            (deEndDate.EditValue == null ? "*" : ((DateTime)deEndDate.EditValue).Date.Year.ToString());
                    }
                }
            }
            else
            {
                ErrorProvider.SetError(deEndDate, "Please select financial period from date.");
            }
        }
        #endregion
    }
}
