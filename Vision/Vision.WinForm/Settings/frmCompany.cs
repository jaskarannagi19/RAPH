using Vision.DAL;
using Vision.DAL.City;
using Vision.DAL.Settings;
using Vision.Model;
using Vision.Model.Settings;
using Vision.WinForm.City;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Vision.Model.SubMaster;

namespace Vision.WinForm.Settings
{
    public partial class frmCompany : Template.frmCRUDTemplate
    {
        CompanyDAL DALObject;
        CityDAL CityDAL;
        //CitySelection CitySelection;
        DAL.SubMaster.CurrencyDAL CurrencyDALObj;

        object dsCity;
        List<CompanyEditListModel> dsCopySettingCompany;
        List<CurrencyLookupListModel> dsCurrency;
        public frmCompany()
        {
            InitializeComponent();

            FirstControl = txtCompanyName;

            DALObject = new CompanyDAL();
            CityDAL = new DAL.City.CityDAL();
            //CitySelection = new CitySelection(lookupCountry, lookupState, lookupCity, this.ErrorProvider);
            CurrencyDALObj = new DAL.SubMaster.CurrencyDAL();
        }

        #region Overriden Methods

        public override void InitializeDefaultValues()
        {

            CompanyLogoSelectedFileName = null;
            peLogo.Image = null;
            //if (FormCurrentUI != eFormCurrentUI.NewEntry || (lookupCopySettingFromCompany.Properties.DataSource == null || ((List<CompanyEditListModel>)lookupCopySettingFromCompany.Properties.DataSource).Count == 0))
            //{
            //    lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //}
            //if (FormCurrentUI == eFormCurrentUI.NewEntry && (lookupCopySettingFromCompany.Properties.DataSource != null && ((List<CompanyEditListModel>)lookupCopySettingFromCompany.Properties.DataSource).Count > 0))
            //{
            //    lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //}

            txtCode.Text = DALObject.GenerateNewCode().ToString();

            base.InitializeDefaultValues();
        }

        public override void AssignFormValues()
        {
            //if (FormCurrentUI == eFormCurrentUI.NewEntry && (dsCopySettingCompany != null && dsCopySettingCompany.Count > 0))
            //{
            //    lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //}
            //else
            //{
            //    lcgSettings.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //}

            base.AssignFormValues();
        }

        public override void LoadLookupDataSource()
        {
            dsCity = CityDAL.GetEditList();
            dsCopySettingCompany = DALObject.GetEditList();
            dsCurrency = CurrencyDALObj.GetLookupList();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupCity.Properties.ValueMember = "CityID";
            lookupCity.Properties.DisplayMember = "CityName";
            lookupCity.Properties.DataSource = dsCity;

            //lookupCopySettingFromCompany.Properties.ValueMember = "CompanyID";
            //lookupCopySettingFromCompany.Properties.DisplayMember = "CompanyName";
            //lookupCopySettingFromCompany.Properties.DataSource = dsCopySettingCompany;

            lookupCurrency.Properties.ValueMember = "CurrencyID";
            lookupCurrency.Properties.DisplayMember = "CurrencyName";
            lookupCurrency.Properties.DataSource = dsCurrency;

            base.AssignLookupDataSource();
        }

        public override void ClearValues()
        {
            deBusinessStartedFrom.Enabled = (FormCurrentUI != eFormCurrentUI.Edit);

            payrollMonthDateEdit.Enabled = (FormCurrentUI != eFormCurrentUI.Edit);
            payRollStartDate.Enabled = (FormCurrentUI != eFormCurrentUI.Edit);
            payRollEndDate.Enabled = (FormCurrentUI != eFormCurrentUI.Edit);

            base.ClearValues();
        }

        public override bool ValidateBeforeSave()
        {
            if(DALObject.GetCompanyCount() >= CommonProperties.LoginInfo.SoftwareSettings.License_NofCompany)
            {
                MessageBox.Show($"Can not add more companies. License was provided for {CommonProperties.LoginInfo.SoftwareSettings.License_NofCompany.ToString()} Companies", "License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return base.ValidateBeforeSave();
        }

        public override void SaveRecord(Model.SavingParemeter Paras)
        {
            DAL.tblCompany SaveModel = null;

            DAL.tblPayrollMonth PayRollMonth = null;


            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new tblCompany();
                
                PayRollMonth = new tblPayrollMonth();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((CompanyEditListModel)EditRecordDataSource).CompanyID);
                
                //DO SOMETHING HERE FOR PAYROLLMONTH
                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.CompanyCode = Model.CommonFunctions.ParseInt(txtCode.Text) + 1;
            SaveModel.CompanyName = txtCompanyName.Text;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew)
            {
                SaveModel.BusinessStartedFrom = (DateTime)deBusinessStartedFrom.EditValue;
            }
            SaveModel.CurrencyID = (int)lookupCurrency.EditValue;
            //SaveModel.CompanyLogoFileName = CompanyLogoSelectedFileName;

            SaveModel.Address1 = txtAddressLine1.Text;
            SaveModel.Address2 = txtAddressLine2.Text;
            SaveModel.Address3 = txtAddressLine3.Text;

            SaveModel.CityID = (int)lookupCity.EditValue;
            SaveModel.PIN = txtPin.Text;

            SaveModel.Phone1 = txtPhone1.Text;
            SaveModel.Phone2 = txtPhoneNo2.Text;
            SaveModel.MobileNo1 = txtMobileNo1.Text;
            SaveModel.MobileNo2 = txtMobileNo2.Text;
            SaveModel.EMailID = txtEMailID.Text;
            SaveModel.Website = txtWebsite.Text;

            SaveModel.IncorporationNo = txtIncorporationNo.Text;
            SaveModel.IncorporationDate = deIncorporationDate.DateTime;
            SaveModel.PINNo_RegNo = txtPINNo.Text;
            SaveModel.NSSFNo = txtNSSFNo.Text;
            SaveModel.NHIFNo = txtNHIFNo.Text;
            SaveModel.PFNo = txtPFNo.Text;
            SaveModel.SaccoRegNo = txtSACCORegNo.Text;

            SaveModel.Bank1_AccountNo = txtBank1_AcNo.Text;
            SaveModel.Bank1_Name = txtBank1_Name.Text;
            SaveModel.Bank1_BranchName = txtBank1_BranchName.Text;
            SaveModel.Bank1_Currency = txtBank1_Currency.Text;

            SaveModel.Bank2_AccountNo = txtBank2_AcNo.Text;
            SaveModel.Bank2_Name = txtBank2_Name.Text;
            SaveModel.Bank2_BranchName = txtBank2_BranchName.Text;
            SaveModel.Bank2_Currency = txtBank2_Currency.Text;

            SaveModel.Bank3_AccountNo = txtBank3_AcNo.Text;
            SaveModel.Bank3_Name = txtBank3_Name.Text;
            SaveModel.Bank3_BranchName = txtBank3_BranchName.Text;
            SaveModel.Bank3_Currency = txtBank3_Currency.Text;
            
            PayRollMonth.PayrollMonthStartDate = payRollStartDate.DateTime;
            PayRollMonth.PayrollMonthEndDate = payRollEndDate.DateTime;
            PayRollMonth.PayrollMonthName = payrollMonthDateEdit.DateTime.ToString("MMMM-yyyy"); //TODO FIX ME ASK WHICH FORMAT TO SAVE
            
            long? CopySettingsFromCompanyID = null;
            //if(lcgSettings.Visibility != DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
            //{
            //    CopySettingsFromCompanyID = (long?)lookupCopySettingFromCompany.EditValue;
            //}

            /// In Editing if logo image is cleared
            if (SaveModel.CompanyLogoFileName != null && CompanyLogoSelectedFileName == null)
            {
                try
                {
                    File.Delete(SaveModel.CompanyLogoFileName);
                }
                catch(Exception) { }
                SaveModel.CompanyLogoFileName = null;
            }

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel, CopySettingsFromCompanyID, PayRollMonth);


            /// CompanyLogoSelectedFileName != null -- it means user has changed logo image
            if (CompanyLogoSelectedFileName != null && 
                Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly &&
                SaveModel.CompanyLogoFileName != CompanyLogoSelectedFileName)
            {
                string LogoImageCopiedFileName = null;

                // to seperate both process file copy and saving file name in db, so that if exception occures than we can get in which part the exception occured
                bool IsFileCopied = false;

                // Copieng Image File
                if (System.IO.File.Exists(CompanyLogoSelectedFileName))
                {
                    string ImageDirectory = null;
                    if (CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_EmployeeImage != null)
                    {
                        ImageDirectory = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_EmployeeImage + @"\Logo\";
                    }
                    else
                    {
                        ImageDirectory = @"\..\IMAGES\Logo\";
                        System.IO.Directory.CreateDirectory(ImageDirectory);
                    }

                    if(!Directory.Exists(ImageDirectory))
                    {
                        Directory.CreateDirectory(ImageDirectory);
                    }

                    LogoImageCopiedFileName = ImageDirectory + "" + ((int)Paras.SavingResult.PrimeKeyValue).ToString() + System.IO.Path.GetExtension(CompanyLogoSelectedFileName);
                    IsFileCopied = false;

                    try
                    {
                        if (File.Exists(LogoImageCopiedFileName))
                        {
                            File.Delete(LogoImageCopiedFileName);
                        }
                        File.Copy(CompanyLogoSelectedFileName, LogoImageCopiedFileName);
                        IsFileCopied = true;
                    }
                    catch (Exception ex)
                    {
                        ex = DAL.CommonFunctions.GetFinalError(ex);
                        Paras.SavingResult.MessageAfterSave = "Error while trying to copy log image file. Please check following error \r\n" + ex.Message;
                    }

                    // if file successfully copied only then save file name 
                    if (IsFileCopied)
                    {
                        SavingResult res = DALObject.SaveLogoFileName((int)Paras.SavingResult.PrimeKeyValue, LogoImageCopiedFileName);
                        if (res.ExecutionResult != eExecutionResult.CommitedSucessfuly && res.ExecutionResult != eExecutionResult.NotExecutedYet)
                        {
                            if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting)
                            {
                                Paras.SavingResult.MessageAfterSave = "Error while saving logo image file name.\r\n" + (res.Exception != null ? res.Exception.Message : "");
                            }
                            else if (res.ExecutionResult == eExecutionResult.ValidationError)
                            {
                                Paras.SavingResult.MessageAfterSave = "Error while saving logo image file name \r\n" + res.ValidationError;
                            }
                        }
                    }
                }
            }

            base.SaveRecord(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            tblCompany EditingRecord = DALObject.FindSaveModelByPrimeKey(((CompanyEditListModel)RecordToFill).CompanyID);

            txtCode.Text = EditingRecord.CompanyCode.ToString();
            txtCompanyName.Text = EditingRecord.CompanyName;

            lookupCurrency.EditValue = EditingRecord.CurrencyID;

            CompanyLogoSelectedFileName = EditingRecord.CompanyLogoFileName;

            if (System.IO.File.Exists(CompanyLogoSelectedFileName))
            {
                var x = Path.GetFullPath(CompanyLogoSelectedFileName);

                Image img;
                using (var bmpTemp = new Bitmap(CompanyLogoSelectedFileName))
                {
                    img = new Bitmap(bmpTemp);
                }

                peLogo.Image = img;
            }
            //CompanyLogoSelectedFileName = null;

            txtAddressLine1.Text = EditingRecord.Address1;
            txtAddressLine2.Text = EditingRecord.Address2;
            txtAddressLine3.Text = EditingRecord.Address3;

            lookupCity.EditValue = EditingRecord.CityID;
            txtAddressLine1.Text = EditingRecord.Address1;
            lookupCity.EditValue = EditingRecord.CityID;
            txtPin.Text = EditingRecord.PIN;

            txtPhoneNo2.Text = EditingRecord.Phone2;
            txtMobileNo2.Text = EditingRecord.MobileNo2;

            txtEMailID.Text = EditingRecord.EMailID;
            txtWebsite.Text = EditingRecord.Website;
            deBusinessStartedFrom.EditValue = EditingRecord.BusinessStartedFrom;

            txtPhone1.Text = EditingRecord.Phone1;
            txtPhoneNo2.Text = EditingRecord.Phone2;
            txtMobileNo1.Text = EditingRecord.MobileNo1;
            txtMobileNo2.Text = EditingRecord.MobileNo2;
            txtEMailID.Text = EditingRecord.EMailID;
            txtWebsite.Text = EditingRecord.Website;

            txtIncorporationNo.Text = EditingRecord.IncorporationNo;
            deIncorporationDate.EditValue = EditingRecord.IncorporationDate;
            txtPINNo.Text = EditingRecord.PINNo_RegNo;
            txtNSSFNo.Text = EditingRecord.NSSFNo;
            txtNHIFNo.Text = EditingRecord.NHIFNo;
            txtPFNo.Text = EditingRecord.PFNo;
            txtSACCORegNo.Text = EditingRecord.SaccoRegNo;

            txtBank1_AcNo.Text = EditingRecord.Bank1_AccountNo;
            txtBank1_Name.Text = EditingRecord.Bank1_Name;
            txtBank1_BranchName.Text = EditingRecord.Bank1_BranchName;
            txtBank1_Currency.Text = EditingRecord.Bank1_Currency;

            txtBank2_AcNo.Text = EditingRecord.Bank2_AccountNo;
            txtBank2_Name.Text = EditingRecord.Bank2_Name;
            txtBank2_BranchName.Text = EditingRecord.Bank2_BranchName;
            txtBank2_Currency.Text = EditingRecord.Bank2_Currency;

            txtBank3_AcNo.Text = EditingRecord.Bank3_AccountNo;
            txtBank3_Name.Text = EditingRecord.Bank3_Name;
            txtBank3_BranchName.Text = EditingRecord.Bank3_BranchName;
            txtBank3_Currency.Text = EditingRecord.Bank3_Currency;
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((CompanyEditListModel)EditRecordDataSource).CompanyID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            int CompanyID = ((CompanyEditListModel)EditRecordDataSource).CompanyID;
            tblCompany SaveModel = DALObject.FindSaveModelByPrimeKey(CompanyID);
            if(SaveModel != null && SaveModel.CompanyLogoFileName != null)
            {
                try
                {
                    File.Delete(SaveModel.CompanyLogoFileName);
                }
                catch (Exception) { }
            }
            //--
            Paras.DeletingResult = DALObject.DeleteRecord(CompanyID);
            //--
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((CompanyEditListModel)EditRecordDataSource).CompanyID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((CompanyEditListModel)EditRecordDataSource).CompanyID);
        }
        #endregion

        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCompanyName.Text == "")
            {
                ErrorProvider.SetError(txtCompanyName, "Please enter city name");
            }
            else if (DALObject.IsDuplicateRecord(txtCompanyName.Text,
                (EditRecordDataSource != null ? ((CompanyEditListModel)EditRecordDataSource).CompanyID : 0)))
            {
                ErrorProvider.SetError(txtCompanyName, "Compnay name is already exists, please enter another name.");
            }
            else
            {
                ErrorProvider.SetError(txtCompanyName, "");
            }
        }

        private void lookupCity_Validating(object sender, CancelEventArgs e)
        {
            if (lookupCity.EditValue == null)
            {
                ErrorProvider.SetError(lookupCity, "Please select city.");
            }
            else
            {
                ErrorProvider.SetError(lookupCity, "");
            }
        }

        private void deBusinessStartedFrom_Validating(object sender, CancelEventArgs e)
        {
            if(deBusinessStartedFrom.EditValue == null)
            {
                ErrorProvider.SetError(deBusinessStartedFrom, "Please select date when your business started from.");
            }
            else
            {
                ErrorProvider.SetError(deBusinessStartedFrom, "");
            }
        }

        private void payRollStartDate_Validating(object sender, CancelEventArgs e)
        {
            if (payRollStartDate.DateTime == DateTime.MinValue)
            {
                ErrorProvider.SetError(payRollStartDate, "Please select date when to start payroll.");
            }
            else if(payRollStartDate.DateTime < deBusinessStartedFrom.DateTime)
            {
                ErrorProvider.SetError(payRollStartDate, "Please select date greater than business start date.");
            }
            else
            {
                ErrorProvider.SetError(payRollStartDate, "");
            }
        }

        private void payRollEndDate_Validating(object sender, CancelEventArgs e)
        {
            if (payRollStartDate.DateTime == DateTime.MinValue)
            {
                ErrorProvider.SetError(payRollEndDate, "Please select date when to end payroll.");
            }
            else if (payRollEndDate.DateTime < payRollStartDate.DateTime )
            {
                ErrorProvider.SetError(payRollEndDate, "End date should be greater then Start date.");
            }
            else
            {
                ErrorProvider.SetError(payRollEndDate, "");
            }
        }

        private void payRollMonth_Validating(object sender, CancelEventArgs e)
        {
            if (payRollStartDate.DateTime == null)
            {
                ErrorProvider.SetError(payRollStartDate, "Please select payroll month.");
            }
            else
            {
                ErrorProvider.SetError(payRollStartDate, "");
            }
        }


        string CompanyLogoSelectedFileName;
        private void btnBrowseLogoImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files|*.*;";
            if(ofd.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    CompanyLogoSelectedFileName = ofd.FileName;

                    Image img;
                    using (var bmpTemp = new Bitmap(CompanyLogoSelectedFileName))
                    {
                        img = new Bitmap(bmpTemp);
                    }
                    peLogo.Image = img;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Following error occured while trying to load image.\r\n\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClearLogoImage_Click(object sender, EventArgs e)
        {
            peLogo.Image = null;
            CompanyLogoSelectedFileName = null;
        }

        private void lookupCurrency_Validating(object sender, CancelEventArgs e)
        {
            if(lookupCurrency.EditValue == null)
            {
                ErrorProvider.SetError(lookupCurrency, "Please select currency");
            }
            else
            {
                ErrorProvider.SetError(lookupCurrency, "");
            }
        }
    }
}
