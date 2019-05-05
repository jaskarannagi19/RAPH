using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Vision.DAL.City;
using Vision.DAL.Employee;
using Vision.DAL.Payroll;
using Vision.DAL.Settings;
using Vision.DAL.SubMaster;
using Vision.Model;
using Vision.Model.City;
using Vision.Model.Employee;
using Vision.Model.Payroll;
using Vision.Model.Settings;
using Vision.Model.SubMaster;

namespace Vision.WinForm.Employee
{
    public partial class frmEmployee : Template.frmCRUDTemplate
    {
        #region Fields
        EmployeeDAL DALObject;
        EmployeeNoPrefixDAL EmployeeNoPrefixNoDALObj;
        DAL.BMDevice.BiometricDeviceDAL BMDeviceDALObj;
        EmployeeDesignationDAL EmployeeDesignationDALObj;
        EmployeeDepartmentDAL EmployeeDepartmentDALObj;
        EmployeeWIBAClassDAL EmployeeWIBAClassDALObj;
        LocationDAL LocationDALObj;
        MinimumWageCategoryDAL MinimumWageCategoryDALObj;
        EmployeeAccountingLedgerDAL EmployeeAccountingLedgerDALObj;
        LeaveTypeDAL LeaveTypeDALObj;
        EmployeeShiftDAL EmployeeShiftDALObj;

        CountryDAL CountryDALObj;
        CityDAL CityDALObj;
        BankNameDAL BankNameDALObj;
        BankBranchDAL BankBranchDALObj;
        CurrencyDAL CurrencyDALObj;

        List<EmployeeNoPrefixLookupListModel> dsEmployeeNoPrefix;
        List<MSD150SDK.MSD150> BMDevices;
        List<EmployeeDesignationLookupListModel> dsEmployeeDesignation;
        List<EmployeeDepartmentLookupListModel> dsEmployeeDepartment;
        List<EmployeeWIBAClassLookupListModel> dsEmployeeWibaClass;
        List<LocationLookupListModel> dsLocation;
        List<MinimumWageCategoryLookupListModel> dsMinimumWageCategory;
        List<MinimumWageCategoryRateChangeListModel> dsMinimumWageCategoryRate;
        List<CountryEditListModel> dsCountry;
        List<CityLookupListModel> dsCity;
        List<BankNameLookupListModel> dsBankName;
        List<BankBranchLookupListModel> dsBankBranch;
        List<CurrencyLookupListModel> dsCurrency;
        List<EmployeeAccountingLedgerLookupListModel> dsEmployeeAccountingLedger;
        List<EmployeeShiftLookupListModel> dsEmployeeShift;
        string EmployeeImageFilePath;
        string EmployeeDocumentFilePath;

        List<EmployeeLeaveOpeningBalanceViewModel> dsEmployeeLeaveOpeningBalance;
        BindingList<EmployeePersonalDocumentViewModel> blEmpoyeeDocument;
        BindingList<EmployeeFamilyDetailsViewModel> blEmpoyeeFamilyDetails;
        BindingList<EmployeeFamilyRelationshipViewModel> blEmployeeFamilyRelationship;

        #endregion

        #region Constructor
        public frmEmployee()
        {
            InitializeComponent();

            FirstControl = lookupEmployeePrefix;
            EmployeeImageFilePath = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_EmployeeImage;
            EmployeeDocumentFilePath = CommonProperties.LoginInfo.SoftwareSettings.DocumentLocation_EmployeeDocument;

            DALObject = new EmployeeDAL();
            EmployeeNoPrefixNoDALObj = new EmployeeNoPrefixDAL();
            BMDeviceDALObj = new DAL.BMDevice.BiometricDeviceDAL();
            EmployeeDesignationDALObj = new EmployeeDesignationDAL();
            EmployeeDepartmentDALObj = new EmployeeDepartmentDAL();
            EmployeeWIBAClassDALObj = new EmployeeWIBAClassDAL();
            LocationDALObj = new LocationDAL();
            MinimumWageCategoryDALObj = new MinimumWageCategoryDAL();
            CountryDALObj = new CountryDAL();
            CityDALObj = new CityDAL();
            BankNameDALObj = new BankNameDAL();
            BankBranchDALObj = new BankBranchDAL();
            CurrencyDALObj = new CurrencyDAL();
            EmployeeAccountingLedgerDALObj = new EmployeeAccountingLedgerDAL();
            LeaveTypeDALObj = new LeaveTypeDAL();
            EmployeeShiftDALObj = new EmployeeShiftDAL();
        }

        #endregion

        #region Template Methods
        public override void LoadFormValues()
        {
            base.LoadFormValues();
        }

        public override void InitializeDefaultValues()
        {
            txtTACode.Text = DALObject.GenerateNewTACode().ToString();

            deEmploymentEffectiveDate.EditValue = DateTime.Now.Date;

            cmbGender.SelectedIndex = 0;

            if (cmbEmploymentType.SelectedIndex != 0)
            {
                cmbEmploymentType.SelectedIndex = 0;
            }
            else
            {
                cmbEmploymentType_SelectedIndexChanged(null, null);
            }
            cmbIncomeType.SelectedIndex = 0;

            cmbMulticurrency.SelectedIndex = 0;
            cmbPayCycle.SelectedIndex = 0;
            cmbPaymentMode.SelectedIndex = 0;

            cmbPFApplicable.SelectedIndex = 0;

            txtDailyRate.EditValue = 0;
            txtBasicSalary.EditValue = 0;
            txtHousingAllowance.EditValue = 0;
            txtWeekendAllowance.EditValue = 0;

            if (dsEmployeeLeaveOpeningBalance != null)
            {
                dsEmployeeLeaveOpeningBalance.ForEach(r => { r.OpeningBalance = 0; r.EmployeeLeaveOpeningBalanceID = 0; });
            }

            cmbTAAttendanceType.SelectedIndex = 0;
            cmbTALatenessCharges.SelectedIndex = 0;
            cmbTAEarlyGoing.SelectedIndex = 0;
            cmbTAOvertime.SelectedIndex = 0;
            cmbTANegativeLeave.SelectedIndex = 0;
            cmbTAWeekendType.SelectedIndex = 0;
            cmbTAWeekEndAttendance.SelectedIndex = 0;
            cmbTAMissPunch.SelectedIndex = 0;
            cmbEmployeeShiftType.SelectedIndex = 0;

            if (dsEmployeeNoPrefix.Count > 0)
            {
                lookupEmployeePrefix.EditValue = dsEmployeeNoPrefix.First().EmployeeNoPrefixID;
            }

            if (blEmpoyeeDocument != null)
            {
                blEmpoyeeDocument.Clear();
            }
            if (blEmpoyeeFamilyDetails != null)
            {
                blEmpoyeeFamilyDetails.Clear();
            }

            picEmployeeImage.SelectedImage = null;
            picEmployeeImage.ImageChanged = false;

            tabbedControlGroup1.SelectedTabPageIndex = 0;

            employeeServiceDetailViewModelBindingSource.Clear();

            lcgTermination.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcgReinstateEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lcgEmploymentType.Enabled = true;

            base.InitializeDefaultValues();
        }

        public override void LoadLookupDataSource()
        {
            dsEmployeeNoPrefix = EmployeeNoPrefixNoDALObj.GetLookupList();

            BMDevices = BMDeviceDALObj.GetLookupList().Select(r => new MSD150SDK.MSD150(r.MachineNo, r.IPAddress, r.PortNo, r.Password, false)).ToList();

            dsEmployeeDesignation = EmployeeDesignationDALObj.GetLookupList();
            dsEmployeeDepartment = EmployeeDepartmentDALObj.GetLookupList();
            dsEmployeeWibaClass = EmployeeWIBAClassDALObj.GetLookupList();
            dsLocation = LocationDALObj.GetLookupList();
            dsMinimumWageCategory = MinimumWageCategoryDALObj.GetLookupList();
            dsMinimumWageCategoryRate = MinimumWageCategoryDALObj.GetMinimumWageCategoryRate();
            dsCountry = CountryDALObj.GetLookupList();
            dsCity = CityDALObj.GetLookupList();
            dsBankName = BankNameDALObj.GetLookupList();
            dsBankBranch = BankBranchDALObj.GetLookupList(dsBankName[0].BankNameID);
            dsCurrency = CurrencyDALObj.GetLookupList();
            dsEmployeeAccountingLedger = EmployeeAccountingLedgerDALObj.GetLookupList();
            dsEmployeeShift = EmployeeShiftDALObj.GetLookupList(eEmployeeShiftType.Fixed);

            dsEmployeeLeaveOpeningBalance = DALObject.GetEmployeeLeaveOpeningBalance(0);

            blEmpoyeeDocument = new BindingList<EmployeePersonalDocumentViewModel>();

            blEmpoyeeDocument.Add(new EmployeePersonalDocumentViewModel { DocumentName = "ID", FileName = "" });
            blEmpoyeeDocument.Add(new EmployeePersonalDocumentViewModel { DocumentName = "PIN", FileName = "" });
            blEmpoyeeDocument.Add(new EmployeePersonalDocumentViewModel { DocumentName = "NSSF", FileName = "" });
            blEmpoyeeDocument.Add(new EmployeePersonalDocumentViewModel { DocumentName = "NHIF", FileName = "" });
            blEmpoyeeDocument.Add(new EmployeePersonalDocumentViewModel { DocumentName = "Police Clear", FileName = "" });
            blEmpoyeeDocument.Add(new EmployeePersonalDocumentViewModel { DocumentName = "Employee Profile", FileName = "" });

            blEmployeeFamilyRelationship = new BindingList<EmployeeFamilyRelationshipViewModel>();
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 0, Name = "Husband" });
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 1, Name = "Wife" });
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 2, Name = "Father" });
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 3, Name = "Mother" });
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 4, Name = "Son" });
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 5, Name = "Daughter" });
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 6, Name = "Brother" });
            blEmployeeFamilyRelationship.Add(new EmployeeFamilyRelationshipViewModel { EmployeeFamilyRelationshipID = 7, Name = "Sister" });

            blEmpoyeeFamilyDetails = new BindingList<EmployeeFamilyDetailsViewModel>();

            base.LoadLookupDataSource();
        }

        public override void AssignLookupDataSource()
        {
            lookupEmployeePrefix.Properties.ValueMember = "EmployeeNoPrefixID";
            lookupEmployeePrefix.Properties.DisplayMember = "EmployeeNoPrefixName";
            lookupEmployeePrefix.Properties.DataSource = dsEmployeeNoPrefix;

            lookupEmployeeAccountingLedger.Properties.ValueMember = "EmployeeAccountingLedgerID";
            lookupEmployeeAccountingLedger.Properties.DisplayMember = "EmployeeAccountingLedgerName";
            lookupEmployeeAccountingLedger.Properties.DataSource = dsEmployeeAccountingLedger;

            lookupDesignation.Properties.ValueMember = "EmployeeDesignationID";
            lookupDesignation.Properties.DisplayMember = "EmployeeDesignationName";
            lookupDesignation.Properties.DataSource = dsEmployeeDesignation;

            lookUpDepartment.Properties.ValueMember = "EmployeeDepartmentID";
            lookUpDepartment.Properties.DisplayMember = "EmployeeDepartmentName";
            lookUpDepartment.Properties.DataSource = dsEmployeeDepartment;

            lookupWIBAClass.Properties.ValueMember = "EmployeeWIBAClassID";
            lookupWIBAClass.Properties.DisplayMember = "EmployeeWIBAClassName";
            lookupWIBAClass.Properties.DataSource = dsEmployeeWibaClass;

            lookUpLocation.Properties.ValueMember = "LocationID";
            lookUpLocation.Properties.DisplayMember = "LocationName";
            lookUpLocation.Properties.DataSource = dsLocation;


            lookUpMinimumWageCategory.Properties.ValueMember = "MinimumWageCategoryID";
            lookUpMinimumWageCategory.Properties.DisplayMember = "MinimumWageCategoryName";
            lookUpMinimumWageCategory.Properties.DataSource = dsMinimumWageCategory;

            lookupCountry.Properties.ValueMember = "CountryID";
            lookupCountry.Properties.DisplayMember = "CountryName";
            lookupCountry.Properties.DataSource = dsCountry;

            lookUpCity.Properties.ValueMember = "CityID";
            lookUpCity.Properties.DisplayMember = "CityName";
            lookUpCity.Properties.DataSource = dsCity;

            lookUpBankName.Properties.ValueMember = "BankNameID";
            lookUpBankName.Properties.DisplayMember = "BankName";
            lookUpBankName.Properties.DataSource = dsBankName;

            lookBankUpCurrency.Properties.ValueMember = "CurrencyID";
            lookBankUpCurrency.Properties.DisplayMember = "CurrencyName";
            lookBankUpCurrency.Properties.DataSource = dsCurrency;

            lookUpBankBranch.Properties.ValueMember = "BankBranchID";
            lookUpBankBranch.Properties.DisplayMember = "BankBranchName";
            lookUpBankBranch.Properties.DataSource = dsBankBranch;

            employeeLeaveOpeningBalanceViewModelBindingSource.DataSource = dsEmployeeLeaveOpeningBalance;

            gridControlDocument.DataSource = blEmpoyeeDocument;
            gridControlFamily.DataSource = blEmpoyeeFamilyDetails;

            repositoryItemLookUpEditFamilyRelationship.ValueMember = "EmployeeFamilyRelationshipID";
            repositoryItemLookUpEditFamilyRelationship.DisplayMember = "Name";
            repositoryItemLookUpEditFamilyRelationship.DataSource = blEmployeeFamilyRelationship;

            lookupEmployeeShift.Properties.ValueMember = "EmployeeShiftID";
            lookupEmployeeShift.Properties.DisplayMember = "EmployeeShiftName";
            lookupEmployeeShift.Properties.DataSource = dsEmployeeShift;

            base.AssignLookupDataSource();
        }

        public override bool ValidateBeforeSave()
        {

            txtEmployeeNo_Validating(null, null);
            txtBMDeviceCode_Validating(null, null);
            txtEmployeeName_Validating(null, null);
            txtEmployeeLastName_Validating(null, null);
            txtMpesaNo_Validating(null, null);
            txtEmail_Validating(null, null);
            txtIDNum_Validating(null, null);
            txtNSSFNum_Validating(null, null);
            txtPINNum_Validating(null, null);
            txtDailyRate_Validating(null, null);
            txtBasicSalary_Validating(null, null);
            deWorkVisaExpiryDate_Validating(null, null);
            deEmploymentEffectiveDate_Validating(null, null);
            lookUpBankName_EditValueChanged(null, null);
            cmbGender_Validating(null, null);
            lookUpCity_Validating(null, null);
            cmbEmploymentType_Validating(null, null);
            lookUpDepartment_Validating(null, null);
            lookUpLocation_Validating(null, null);
            lookupDesignation_Validating(null, null);
            cmbIncomeType_Validating(null, null);
            lookUpMinimumWageCategory_Validating(null, null);
            lookupWIBAClass_Validating(null, null);
            cmbPaymentMode_Validating(null, null);
            cmbPayCycle_Validating(null, null);
            lookUpBankName_Validating(null, null);
            lookUpBankBranch_Validating(null, null);
            lookBankUpCurrency_Validating(null, null);
            lookupCountry_Validating(null, null);
            deContractExpiryDate_Validating(null, null);
            txtBankAccountNo_Validating(null, null);
            lookupEmployeePrefix_Validating(null, null);

            if (!ProcessValidationFormControls())
            {
                return false;
            }

            if (DALObject.GetEmployeeCount() >= CommonProperties.LoginInfo.SoftwareSettings.License_NofEmployee)
            {
                MessageBox.Show($"Can not add more employees. License was provided for {CommonProperties.LoginInfo.SoftwareSettings.License_NofEmployee.ToString()} employees",
                    "License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            gridViewDocument.UpdateCurrentRow();


            return base.ValidateBeforeSave();
        }

        public override void SaveRecord(SavingParemeter Paras)
        {
            DAL.tblEmployee SaveModel = null;
            EmployeeServiceDetailViewModel ServiceDetail = null;
            if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EditRecordDataSource == null)
            {
                SaveModel = new DAL.tblEmployee();
            }
            else
            {
                SaveModel = DALObject.FindSaveModelByPrimeKey(((EmployeeEditListModel)EditRecordDataSource).EmployeeID);

                if (SaveModel == null)
                {
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ValidationError;
                    Paras.SavingResult.ValidationError = "Can not edit. Selected record not found, it may be deleted by another user.";
                    return;
                }
            }

            SaveModel.EmployeeNoPrefixID = (int)lookupEmployeePrefix.EditValue;
            SaveModel.EmployeeNo = Model.CommonFunctions.ParseInt(txtEmployeeNo.Text);
            SaveModel.TACode = Model.CommonFunctions.ParseInt(txtTACode.Text);
            SaveModel.EmployeeFirstName = txtEmployeeName.Text;
            SaveModel.EmployeeLastName = txtEmployeeLastName.Text;
            SaveModel.EmployeeOtherName = txtEmployeeOtherName.Text;
            SaveModel.Gender = (byte)cmbGender.SelectedIndex;

            SaveModel.NationalityID = (int)lookupCountry.EditValue;
            SaveModel.CityID = (int)lookUpCity.EditValue;

            SaveModel.Address1 = txtAddress1.Text;
            SaveModel.Address2 = txtAddress2.Text;
            SaveModel.Address3 = txtAddress3.Text;
            SaveModel.POBoxNO = txtPOBoxNO.Text;
            SaveModel.EmailID = txtEmail.Text;
            SaveModel.MpesaNo = txtMpesaNo.Text;
            SaveModel.Multicurrency = cmbMulticurrency.SelectedIndex == 1;
            SaveModel.WorkVisaExpiryDate = (DateTime?)deWorkVisaExpiryDate.EditValue;
            SaveModel.EmployeeAccountingLedgerID = (int)lookupEmployeeAccountingLedger.EditValue;

            SaveModel.IDNo = txtIDNum.Text;
            SaveModel.NSSFNo = txtNSSFNum.Text;
            SaveModel.NHIFNo = txtNHIFNum.Text;
            SaveModel.PINNo = txtPINNum.Text;
            SaveModel.ProvidentFund = (byte)cmbPFApplicable.SelectedIndex;
            SaveModel.PFNo = txtPFNum.Text;

            SaveModel.BankAcNo = txtBankAccountNo.Text;
            SaveModel.BankNameID = (int?)lookUpBankName.EditValue;
            SaveModel.BankBranchID = (int?)lookUpBankBranch.EditValue;
            SaveModel.BankCurrencyID = (int?)lookBankUpCurrency.EditValue;

            SaveModel.IncomeType = cmbIncomeType.SelectedIndex == 0;

            SaveModel.PaymentMode = (byte)cmbPaymentMode.SelectedIndex;
            SaveModel.PayCycle = (byte)cmbPayCycle.SelectedIndex;

            SaveModel.TAAttendanceType = (byte)cmbTAAttendanceType.SelectedIndex;
            SaveModel.TALatenessCharges = (byte)cmbTALatenessCharges.SelectedIndex;
            SaveModel.TAEarlyGoing = (byte)cmbTAEarlyGoing.SelectedIndex;
            SaveModel.TAOvertime = (byte)cmbTAOvertime.SelectedIndex;
            SaveModel.TANegativeLeave = (byte)cmbTANegativeLeave.SelectedIndex;

            SaveModel.TAWeekendType = (byte)cmbTAWeekendType.SelectedIndex;
            SaveModel.TAWeekEndAttendance = (byte)cmbTAWeekEndAttendance.SelectedIndex;
            SaveModel.TAMissPunch = (byte)cmbTAMissPunch.SelectedIndex;

            ServiceDetail = new EmployeeServiceDetailViewModel()
            {
                EmployeeServiceDetailID = SaveModel.EmployeeLastServiceDetailID ?? 0,
                DailyRate = Model.CommonFunctions.ParseDecimal(txtDailyRate.Text),
                BasicSalary = Model.CommonFunctions.ParseDecimal(txtBasicSalary.Text),
                HousingAllowance = Model.CommonFunctions.ParseDecimal(txtHousingAllowance.Text),
                WeekendAllowance = Model.CommonFunctions.ParseDecimal(txtWeekendAllowance.Text),
                EmployeeDesignationID = (int)lookupDesignation.EditValue,
                EmployeeDepartmentID = (int)lookUpDepartment.EditValue,
                EmployeeWIBAClassID = (int)lookupWIBAClass.EditValue,
                LocationID = (int)lookUpLocation.EditValue,
                MinimumWageCategoryID = (int)lookUpMinimumWageCategory.EditValue,
                EmploymentEffectiveDate = (DateTime)deEmploymentEffectiveDate.EditValue,
                ContractExpiryDate = (DateTime?)deContractExpiryDate.EditValue,
                EmploymentType = (byte)cmbEmploymentType.SelectedIndex,

                EmployeeShiftTypeID = (byte)cmbEmployeeShiftType.SelectedIndex,
                EmployeeShiftID = (int?)lookupEmployeeShift.EditValue,

                EmployeeLeaveOpeningBalance = dsEmployeeLeaveOpeningBalance
            };

            string EmployeeNoWithPrefix = lookupEmployeePrefix.Text.Trim().Replace("\\", "").Replace("/", "") + txtEmployeeNo.Text;
            string OldEployeeImageFilePath = SaveModel.EmployeeImageFileName;

            if (picEmployeeImage.ImageChanged)
            {
                if (picEmployeeImage.SelectedImage != null)
                {
                    try
                    {
                        if (!Directory.Exists(EmployeeImageFilePath))
                        {
                            Directory.CreateDirectory(EmployeeImageFilePath);
                        }

                        string extension = Path.GetExtension(picEmployeeImage.ImageFileName);
                        string saveImagePath = Path.Combine(EmployeeImageFilePath, EmployeeNoWithPrefix + extension);

                        System.IO.File.Copy(picEmployeeImage.ImageFileName, saveImagePath, true);

                        //picEmployeeImage.SelectedImage.Save(saveImagePath);
                        SaveModel.EmployeeImageFileName = saveImagePath;
                    }
                    catch (Exception ex)
                    {
                        ex = DAL.CommonFunctions.GetFinalError(ex);
                        Paras.SavingResult = new SavingResult();
                        Paras.SavingResult.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                        Paras.SavingResult.Exception = new Exception("Error while trying to save image file. Please check following error \r\n" + ex.Message);
                        return;
                    }
                }
                else
                {
                    SaveModel.EmployeeImageFileName = null;
                }
            }

            List<DAL.tblEmployeeDocument> DeletedDocuments = null;
            if (SaveModel.tblEmployeeDocuments != null && SaveModel.tblEmployeeDocuments.Count > 0)
            {
                // if existing document is deleted or image was removed
                DeletedDocuments = SaveModel.tblEmployeeDocuments.Where(r => !String.IsNullOrWhiteSpace(r.FileName) &&
                            (!blEmpoyeeDocument.Any(rr => rr.DocumentID == r.EmployeeDocumentID) ||
                                String.IsNullOrWhiteSpace(blEmpoyeeDocument.First(rr => rr.DocumentID == r.EmployeeDocumentID).FileName))
                            ).ToList();
            }

            foreach (EmployeePersonalDocumentViewModel documentViewModel in blEmpoyeeDocument.ToList())
            {
                try
                {
                    if (!Directory.Exists(EmployeeDocumentFilePath))
                    {
                        Directory.CreateDirectory(EmployeeDocumentFilePath);
                    }
                    if (!string.IsNullOrEmpty(documentViewModel.FileName))
                    {
                        string extension = Path.GetExtension(documentViewModel.FileName);

                        string docFilePath = EmployeeNoWithPrefix +
                            documentViewModel.DocumentName.Trim().Substring(0, Math.Min(documentViewModel.DocumentName.Trim().Length, 50)) +
                            extension;

                        string saveImagePath = Path.Combine(EmployeeDocumentFilePath, docFilePath);

                        if (File.Exists(documentViewModel.FileName) && saveImagePath != documentViewModel.FileName)
                        {
                            File.Copy(documentViewModel.FileName, saveImagePath, true);
                            documentViewModel.FileName = saveImagePath;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex = DAL.CommonFunctions.GetFinalError(ex);
                    Paras.SavingResult = new SavingResult();
                    Paras.SavingResult.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    Paras.SavingResult.MessageAfterSave = "Error while trying to save image file. Please check following error \r\n" + ex.Message;
                    return;
                }
            }

            Paras.SavingResult = DALObject.SaveNewRecord(SaveModel,
                        ServiceDetail,
                        blEmpoyeeDocument.ToList(),
                        (blEmpoyeeFamilyDetails != null ? blEmpoyeeFamilyDetails.ToList() : null));

            if (Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                //Cleaning 
                // remove deleted employee image
                if (!String.IsNullOrWhiteSpace(OldEployeeImageFilePath) && String.IsNullOrWhiteSpace(SaveModel.EmployeeImageFileName))
                {
                    try
                    {
                        File.Delete(OldEployeeImageFilePath);
                    }
                    catch (Exception) { }
                }

                //Remove deleted  document files 
                if (DeletedDocuments != null && DeletedDocuments.Count > 0)
                {
                    foreach (var document in DeletedDocuments)
                    {
                        if (!String.IsNullOrWhiteSpace(document.FileName) && File.Exists(document.FileName))
                        {
                            try
                            {
                                File.Delete(document.FileName);
                            }
                            catch (Exception) { }
                        }
                    }
                }
            }

            base.SaveRecord(Paras);
        }

        public override void AfterSaving(SavingParemeter Paras)
        {
            //if(Paras.SavingResult.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            //{
            //    DAL.tblEmployee SaveRecord = DALObject.FindSaveModelByPrimeKey((long)Paras.SavingResult.PrimeKeyValue);
            //    foreach (var bmd in BMDevices)
            //    {
            //        if(!bmd.DeviceConnected)
            //        {
            //            bmd.Connect();
            //        }

            //        string EmployeeName = null;
            //        if(Paras.SavingInterface == SavingParemeter.eSavingInterface.Update)
            //        {
            //            EmployeeName = (string)bmd.GetEmployeeName(SaveRecord.TACode).ResultValue;
            //        }

            //        if (Paras.SavingInterface == SavingParemeter.eSavingInterface.AddNew || EmployeeName == null)
            //        {
            //            bmd.EnrollNewEmployee(SaveRecord.TACode, SaveRecord.EmployeeName);
            //        }
            //        else if(EmployeeName != SaveRecord.EmployeeName)
            //        {
            //            bmd.SetEmployeeName(SaveRecord.TACode, SaveRecord.EmployeeName);
            //        }
            //        bmd.Disconnect();
            //    }
            //}

            base.AfterSaving(Paras);
        }

        public override object GetEditListDataSource()
        {
            return DALObject.GetEditList();
        }

        public override void FormatEditListGridView(GridView EditListGrid)
        {
            base.FormatEditListGridView(EditListGrid);
        }

        public override void FillSelectedRecordInContent(object RecordToFill)
        {
            EmployeeEditListModel EditingRecord = (EmployeeEditListModel)RecordToFill;

            DAL.tblEmployee SaveModel = DALObject.FindSaveModelByPrimeKey(EditingRecord.EmployeeID);
            if (SaveModel == null)
            {
                return;
            }

            lookupEmployeePrefix.EditValue = SaveModel.EmployeeNoPrefixID;
            txtEmployeeNo.Text = SaveModel.EmployeeNo.ToString();
            txtTACode.Text = SaveModel.TACode.ToString();
            txtEmployeeName.Text = SaveModel.EmployeeFirstName;
            txtEmployeeLastName.Text = SaveModel.EmployeeLastName;
            txtEmployeeOtherName.Text = SaveModel.EmployeeOtherName;
            cmbGender.SelectedIndex = SaveModel.Gender;

            deWorkVisaExpiryDate.EditValue = SaveModel.WorkVisaExpiryDate;

            txtAddress1.Text = SaveModel.Address1;
            txtAddress2.Text = SaveModel.Address2;
            txtAddress3.Text = SaveModel.Address3;
            txtPOBoxNO.Text = SaveModel.POBoxNO;
            txtEmail.Text = SaveModel.EmailID;
            txtMpesaNo.Text = SaveModel.MpesaNo;
            lookupCountry.EditValue = SaveModel.NationalityID;
            lookUpCity.EditValue = SaveModel.CityID;

            lookupEmployeeAccountingLedger.EditValue = SaveModel.EmployeeAccountingLedgerID;

            txtIDNum.Text = SaveModel.IDNo;
            txtNSSFNum.Text = SaveModel.NSSFNo;
            txtNHIFNum.Text = SaveModel.NHIFNo;
            txtPINNum.Text = SaveModel.PINNo;
            cmbPFApplicable.SelectedIndex = SaveModel.ProvidentFund;
            txtPFNum.Text = SaveModel.PFNo;

            cmbTAAttendanceType.SelectedIndex = SaveModel.TAAttendanceType;
            cmbTALatenessCharges.SelectedIndex = SaveModel.TALatenessCharges;
            cmbTAEarlyGoing.SelectedIndex = SaveModel.TAEarlyGoing;
            cmbTAOvertime.SelectedIndex = SaveModel.TAOvertime;
            cmbTANegativeLeave.SelectedIndex = SaveModel.TANegativeLeave;
            cmbTAWeekendType.SelectedIndex = SaveModel.TAWeekendType;
            cmbTAWeekEndAttendance.SelectedIndex = SaveModel.TAWeekEndAttendance;
            cmbTAMissPunch.SelectedIndex = SaveModel.TAMissPunch;

            txtBankAccountNo.Text = SaveModel.BankAcNo;
            lookBankUpCurrency.EditValue = SaveModel.BankCurrencyID;
            lookUpBankName.EditValue = SaveModel.BankNameID;
            lookUpBankBranch.EditValue = SaveModel.BankBranchID;
            cmbMulticurrency.SelectedIndex = (SaveModel.Multicurrency ? 1 : 0);

            cmbPayCycle.SelectedIndex = SaveModel.PayCycle;
            cmbPaymentMode.SelectedIndex = SaveModel.PaymentMode;
            cmbIncomeType.SelectedIndex = SaveModel.IncomeType ? 0 : 1;

            if (SaveModel.EmployeeLastServiceDetailID != null && SaveModel.tblEmployeeServiceDetail != null)
            {
                txtHousingAllowance.Text = SaveModel.tblEmployeeServiceDetail.HousingAllowance.ToString();
                txtWeekendAllowance.Text = SaveModel.tblEmployeeServiceDetail.WeekendAllowance.ToString();
                deEmploymentEffectiveDate.EditValue = SaveModel.tblEmployeeServiceDetail.EmploymentEffectiveDate;
                deContractExpiryDate.EditValue = SaveModel.tblEmployeeServiceDetail.ContractExpiryDate;
                txtDailyRate.Text = SaveModel.tblEmployeeServiceDetail.DailyRate.ToString();
                txtBasicSalary.Text = SaveModel.tblEmployeeServiceDetail.BasicSalary.ToString();
                lookupDesignation.EditValue = SaveModel.tblEmployeeServiceDetail.EmployeeDesignationID;
                lookUpDepartment.EditValue = SaveModel.tblEmployeeServiceDetail.EmployeeDepartmentID;
                lookupWIBAClass.EditValue = SaveModel.tblEmployeeServiceDetail.EmployeeWIBAClassID;
                lookUpLocation.EditValue = SaveModel.tblEmployeeServiceDetail.LocationID;
                lookUpMinimumWageCategory.EditValue = SaveModel.tblEmployeeServiceDetail.MinimumWageCategoryID;
                cmbEmploymentType.SelectedIndex = SaveModel.tblEmployeeServiceDetail.EmploymentType;

                cmbEmployeeShiftType.SelectedIndex = SaveModel.tblEmployeeServiceDetail.EmployeeShiftType;
                lookupEmployeeShift.EditValue = SaveModel.tblEmployeeServiceDetail.EmployeeShiftID;

                foreach (var lt in dsEmployeeLeaveOpeningBalance)
                {
                    var elob = SaveModel.tblEmployeeServiceDetail.tblEmployeeLeaveOpeningBalances.FirstOrDefault(r => r.LeaveTypeID == lt.LeaveTypeID);
                    if (elob != null)
                    {
                        lt.OpeningBalance = elob.LeaveOpeningBalance;
                    }
                }

                eEmployementStatus EmployementStatus = (eEmployementStatus)SaveModel.tblEmployeeServiceDetail.EmployeementStatus;
                if (EmployementStatus == eEmployementStatus.Active && (((eEmploymentType)SaveModel.tblEmployeeServiceDetail.EmploymentType) != eEmploymentType.Contract || SaveModel.tblEmployeeServiceDetail.ContractExpiryDate >= DateTime.Now.Date ))
                {
                    cmbTerminationType.SelectedIndex = (int)(eTerminationType.NA);
                    lcgTermination.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    lcgReinstateEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lcgEmploymentType.Enabled = false;
                }
            }

            if (SaveModel.EmployeeImageFileName != null)
            {
                string imagePath = SaveModel.EmployeeImageFileName;
                if (File.Exists(imagePath))
                {
                    using (var img = new Bitmap(imagePath))
                    {
                        //try
                        //{
                            picEmployeeImage.SelectedImage = new Bitmap(img);
                        //}
                        //catch(Exception)
                        //{

                        //}
                    }
                    picEmployeeImage.ImageChanged = false;

                }
            }

            blEmpoyeeDocument = new BindingList<EmployeePersonalDocumentViewModel>(SaveModel.tblEmployeeDocuments.Select(r => new EmployeePersonalDocumentViewModel()
            {
                DocumentName = r.DocumentName,
                FileName = r.FileName,
                DocumentID = r.EmployeeDocumentID
            }).ToList());

            gridControlDocument.DataSource = blEmpoyeeDocument;

            blEmpoyeeFamilyDetails = new BindingList<EmployeeFamilyDetailsViewModel>(SaveModel.tblEmployeeFamilies.Select(r => new EmployeeFamilyDetailsViewModel()
            {
                Address = r.Address,
                Beneficiary = Convert.ToDecimal(r.Beneficiary),
                City = r.City,
                Email = r.Email,
                MobileNo = r.MobileNo,
                Name = r.Name,
                POBoxNo = r.POBoxNo,
                Relationship = r.Relationship,
                EmployeeFamilyID = r.EmployeeFamilyID
            }).ToList());

            gridControlFamily.DataSource = blEmpoyeeFamilyDetails;

            employeeServiceDetailViewModelBindingSource.DataSource = DALObject.GetEmployeeServiceDetail(SaveModel.EmployeeID);
        }

        public override BeforeDeleteValidationResult ValidateBeforeDelete()
        {
            return DALObject.ValidateBeforeDelete(((EmployeeEditListModel)EditRecordDataSource).EmployeeID);
        }

        public override void DeleteRecord(DeletingParameter Paras)
        {
            Paras.DeletingResult = DALObject.DeleteRecord(((EmployeeEditListModel)EditRecordDataSource).EmployeeID);
            base.DeleteRecord(Paras);
        }

        public override void Authorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.Authorize(((EmployeeEditListModel)EditRecordDataSource).EmployeeID);
        }

        public override void UnAuthorize(SavingParemeter Paras)
        {
            Paras.SavingResult = DALObject.UnAuthorize(((EmployeeEditListModel)EditRecordDataSource).EmployeeID);
        }

        #endregion

        #region Validation
        private void txtEmployeeNo_Validating(object sender, CancelEventArgs e)
        {
            if (!Model.CommonFunctions.CheckParseInt(txtEmployeeNo.EditValue.ToString()))
            {
                ErrorProvider.SetError(txtEmployeeNo, "Can not accept invalid value in Emp Code");
            }
            else if (Model.CommonFunctions.ParseInt(txtEmployeeNo.EditValue.ToString()) == 0)
            {
                ErrorProvider.SetError(txtEmployeeNo, "zero is not accepted in Emp Code");
            }
            else if (DALObject.IsDuplicateEmployeeNo(Model.CommonFunctions.ParseInt(txtEmployeeNo.EditValue.ToString()), (int?)lookupEmployeePrefix.EditValue ?? 0,
                (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeEditListModel)EditRecordDataSource).EmployeeID : 0)))
            {
                ErrorProvider.SetError(txtEmployeeNo, "Can not accept duplicate Emp Code");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeNo, string.Empty);
            }
        }

        private void txtBMDeviceCode_Validating(object sender, CancelEventArgs e)
        {
            if (!Model.CommonFunctions.CheckParseInt(txtTACode.EditValue.ToString()))
            {
                ErrorProvider.SetError(txtTACode, "Please enter valid T & A  code.");
            }
            else if (DALObject.IsDuplicateTACode(Model.CommonFunctions.ParseInt(txtTACode.EditValue.ToString()),
                (FormCurrentUI == eFormCurrentUI.Edit ? ((EmployeeEditListModel)EditRecordDataSource).EmployeeID : 0)))
            {
                ErrorProvider.SetError(txtTACode, "Can not accept duplicate T & A Code.");
            }
            else
            {
                ErrorProvider.SetError(txtTACode, string.Empty);
            }
        }

        private void txtEmployeeName_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmployeeName.Text == string.Empty)
            {
                ErrorProvider.SetError(txtEmployeeName, "Can not accept blank Employee name.");
            }
            else
            {
                ErrorProvider.SetError(txtEmployeeName, string.Empty);
            }
        }

        private void txtEmployeeLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeLastName.Text))
            {
                ErrorProvider.SetError(txtEmployeeLastName, "Can not accept blank Last name.");
            }

            else
            {
                ErrorProvider.SetError(txtEmployeeLastName, string.Empty);
            }
        }

        private void txtMpesaNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMpesaNo.Text))
            {
                ErrorProvider.SetError(txtMpesaNo, "Can not accept blank Mpesa No.");
            }

            else
            {
                ErrorProvider.SetError(txtMpesaNo, string.Empty);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) &&
                !Regex.IsMatch(txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                ErrorProvider.SetError(txtEmail, "Can not accept invalid Email.");
            }
            else
            {
                ErrorProvider.SetError(txtEmail, string.Empty);
            }

        }

        private void txtIDNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDNum.Text))
            {
                ErrorProvider.SetError(txtIDNum, "Can not accept blank ID No.");
            }

            else
            {
                ErrorProvider.SetError(txtIDNum, string.Empty);
            }
        }

        private void txtNSSFNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNSSFNum.Text))
            {
                ErrorProvider.SetError(txtNSSFNum, "Can not accept blank NSSF NO.");
            }

            else
            {
                ErrorProvider.SetError(txtNSSFNum, string.Empty);
            }

        }

        private void txtPINNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPINNum.Text))
            {
                ErrorProvider.SetError(txtPINNum, "Can not accept blank PIN NO.");
            }

            else
            {
                ErrorProvider.SetError(txtPINNum, string.Empty);
            }
        }

        private void txtDailyRate_Validating(object sender, CancelEventArgs e)
        {
            if (((Model.Employee.eEmploymentType)cmbEmploymentType.SelectedIndex) == eEmploymentType.Casual && Model.CommonFunctions.ParseDecimal(txtDailyRate.Text) == 0)
            {
                ErrorProvider.SetError(txtDailyRate, "Can not accept blank Daily Rate.");
            }
            else
            {
                ErrorProvider.SetError(txtDailyRate, string.Empty);
            }

        }

        private void txtBasicSalary_Validating(object sender, CancelEventArgs e)
        {
            if (((Model.Employee.eEmploymentType)cmbEmploymentType.SelectedIndex) != eEmploymentType.Casual && Model.CommonFunctions.ParseDecimal(txtBasicSalary.Text) == 0)
            {
                ErrorProvider.SetError(txtBasicSalary, "Can not accept blank Basic Salary.");
            }

            else
            {
                ErrorProvider.SetError(txtBasicSalary, string.Empty);
            }

        }

        private void deWorkVisaExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            //if (deWorkVisaExpiryDate.EditValue == null)
            //{
            //    ErrorProvider.SetError(deWorkVisaExpiryDate, "Please select Work Visa Expiry Date");
            //}

            //else
            //{
            //    ErrorProvider.SetError(deWorkVisaExpiryDate, string.Empty);

            //}
        }

        private void deEmploymentEffectiveDate_Validating(object sender, CancelEventArgs e)
        {
            if (deEmploymentEffectiveDate.EditValue == null)
            {
                ErrorProvider.SetError(deEmploymentEffectiveDate, "Please select Employment Effective Date");
            }

            else
            {
                ErrorProvider.SetError(deEmploymentEffectiveDate, string.Empty);
            }
        }

        private void lookUpBankName_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpBankName.EditValue != null)
            {
                dsBankBranch = BankBranchDALObj.GetLookupList((int)lookUpBankName.EditValue);

                lookUpBankBranch.Properties.ValueMember = "BankBranchID";
                lookUpBankBranch.Properties.DisplayMember = "BankBranchName";
                lookUpBankBranch.Properties.DataSource = dsBankBranch;
            }
        }

        private void cmbGender_Validating(object sender, CancelEventArgs e)
        {
            if (cmbGender.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbGender, "Please select Gender");
            }
            else
            {
                ErrorProvider.SetError(cmbGender, string.Empty);
            }
        }

        private void lookUpCity_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpCity.EditValue == null)
            {
                ErrorProvider.SetError(lookUpCity, "Please select City");
            }
            else
            {
                ErrorProvider.SetError(lookUpCity, string.Empty);
            }

        }

        private void cmbEmploymentType_Validating(object sender, CancelEventArgs e)
        {
            if (cmbEmploymentType.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbEmploymentType, "Please select Employment Type");
            }
            else
            {
                ErrorProvider.SetError(cmbEmploymentType, string.Empty);
            }

        }

        private void lookUpDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpDepartment.EditValue == null)
            {
                ErrorProvider.SetError(lookUpDepartment, "Please select Department");
            }
            else
            {
                ErrorProvider.SetError(lookUpDepartment, string.Empty);
            }
        }

        private void lookUpLocation_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpLocation.EditValue == null)
            {
                ErrorProvider.SetError(lookUpLocation, "Please select Location");
            }
            else
            {
                ErrorProvider.SetError(lookUpLocation, string.Empty);
            }

        }

        private void lookupDesignation_Validating(object sender, CancelEventArgs e)
        {
            if (lookupDesignation.EditValue == null)
            {
                ErrorProvider.SetError(lookupDesignation, "Please select Designation");
            }
            else
            {
                ErrorProvider.SetError(lookupDesignation, string.Empty);
            }
        }

        private void cmbIncomeType_Validating(object sender, CancelEventArgs e)
        {
            if (cmbIncomeType.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbIncomeType, "Please select Income Type");
            }
            else
            {
                ErrorProvider.SetError(cmbIncomeType, string.Empty);
            }
        }

        private void lookUpMinimumWageCategory_Validating(object sender, CancelEventArgs e)
        {
            if (lookUpMinimumWageCategory.EditValue == null)
            {
                ErrorProvider.SetError(lookUpMinimumWageCategory, "Please select Minimum Wage Category");
            }
            else
            {
                ErrorProvider.SetError(lookUpMinimumWageCategory, string.Empty);
            }
        }

        private void lookupWIBAClass_Validating(object sender, CancelEventArgs e)
        {
            if (lookupWIBAClass.EditValue == null)
            {
                ErrorProvider.SetError(lookupWIBAClass, "Please select WIBA Class");
            }
            else
            {
                ErrorProvider.SetError(lookupWIBAClass, string.Empty);
            }

        }

        private void cmbPaymentMode_Validating(object sender, CancelEventArgs e)
        {
            if (cmbPaymentMode.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbPaymentMode, "Please select Payment Mode");
            }
            else
            {
                ErrorProvider.SetError(cmbPaymentMode, string.Empty);
            }
        }

        private void cmbPayCycle_Validating(object sender, CancelEventArgs e)
        {
            if (cmbPayCycle.SelectedIndex == -1)
            {
                ErrorProvider.SetError(cmbPayCycle, "Please select Pay Cycle");
            }
            else
            {
                ErrorProvider.SetError(cmbPayCycle, string.Empty);
            }
        }

        private void lookUpBankName_Validating(object sender, CancelEventArgs e)
        {
            if ((Model.Employee.ePaymentMode)cmbPaymentMode.SelectedIndex == ePaymentMode.BankTransfer &&
                lookUpBankName.EditValue == null)
            {
                ErrorProvider.SetError(lookUpBankName, "Please select Bank Name");
            }
            else
            {
                ErrorProvider.SetError(lookUpBankName, string.Empty);
            }
        }

        private void lookUpBankBranch_Validating(object sender, CancelEventArgs e)
        {
            if ((Model.Employee.ePaymentMode)cmbPaymentMode.SelectedIndex == ePaymentMode.BankTransfer &&
                lookUpBankBranch.EditValue == null)
            {
                ErrorProvider.SetError(lookUpBankBranch, "Please select Bank Branch");
            }
            else
            {
                ErrorProvider.SetError(lookUpBankBranch, string.Empty);
            }

        }

        private void lookBankUpCurrency_Validating(object sender, CancelEventArgs e)
        {
            if ((Model.Employee.ePaymentMode)cmbPaymentMode.SelectedIndex == ePaymentMode.BankTransfer &&
                lookBankUpCurrency.EditValue == null)
            {
                ErrorProvider.SetError(lookBankUpCurrency, "Please select Currency");
            }
            else
            {
                ErrorProvider.SetError(lookBankUpCurrency, string.Empty);
            }

        }

        private void lookupCountry_Validating(object sender, CancelEventArgs e)
        {
            if (lookupCountry.EditValue == null)
            {
                ErrorProvider.SetError(lookupCountry, "Please select Nationality");
            }
            else
            {
                ErrorProvider.SetError(lookupCountry, string.Empty);
            }
        }

        private void deContractExpiryDate_Validating(object sender, CancelEventArgs e)
        {
            if (cmbEmploymentType.SelectedIndex == (int)Model.Employee.eEmploymentType.Contract
                && deContractExpiryDate.EditValue == null)
            {
                ErrorProvider.SetError(deContractExpiryDate, "Please select Contract Expiry Date");
            }
            else
            {
                ErrorProvider.SetError(deContractExpiryDate, string.Empty);
            }
        }

        private void txtBankAccountNo_Validating(object sender, CancelEventArgs e)
        {
            if ((Model.Employee.ePaymentMode)cmbPaymentMode.SelectedIndex == ePaymentMode.BankTransfer &&
                string.IsNullOrEmpty(txtBankAccountNo.Text))
            {
                ErrorProvider.SetError(txtBankAccountNo, "Can not accept blank Account No.");
            }
            else
            {
                ErrorProvider.SetError(txtBankAccountNo, string.Empty);
            }

        }

        private void lookupEmployeePrefix_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEmployeePrefix.EditValue == null)
            {
                ErrorProvider.SetError(lookupEmployeePrefix, "Please select Employee Number Prefix.");
            }
            else
            {
                ErrorProvider.SetError(lookupEmployeePrefix, "");
            }
        }

        private void lookupEmployeeAccountingLedger_Validating(object sender, CancelEventArgs e)
        {
            if (lookupEmployeeAccountingLedger.EditValue == null)
            {
                ErrorProvider.SetError(lookupEmployeeAccountingLedger, "Please select employee accounting ledger.");
            }
            else
            {
                ErrorProvider.SetError(lookupEmployeeAccountingLedger, "");
            }
        }
        #endregion

        private void gridViewDocument_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EmployeePersonalDocumentViewModel currentRow = (EmployeePersonalDocumentViewModel)gridViewDocument.GetRow(e.FocusedRowHandle);
            if (currentRow != null)
            {
                if (!string.IsNullOrEmpty(currentRow.FileName))
                {
                    string imagePath = currentRow.FileName;//Path.Combine(employeeImageFilePath, currentRow.FileName);
                    if (File.Exists(imagePath))
                    {
                        using (Image img = new Bitmap(imagePath))
                        {
                            picEmployeeDocument.SelectedImage = new Bitmap(img);
                        }
                    }
                    else
                    {
                        picEmployeeDocument.SelectedImage = null;
                    }
                }
                else
                {
                    picEmployeeDocument.SelectedImage = null;
                }
            }
            else
            {
                picEmployeeDocument.SelectedImage = null;
            }
        }

        private void pictureSelect1_ImageFileNameChange(object sender, EventArgs e)
        {
            EmployeePersonalDocumentViewModel currentRow = (EmployeePersonalDocumentViewModel)gridViewDocument.GetFocusedRow();

            if (currentRow != null)
            {
                currentRow.FileName = picEmployeeDocument.ImageFileName;
            }
        }

        private void repositoryItemRemovePersonalDocument_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var row = gridViewDocument.GetFocusedRow();
            if (row != null)
            {
                blEmpoyeeDocument.Remove((EmployeePersonalDocumentViewModel)row);
            }
        }

        private void lookupEmployeePrefix_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEmployeePrefix.EditValue != null)
            {
                txtEmployeeNo.EditValue = DALObject.GenerateNewEmployeeNo((int)lookupEmployeePrefix.EditValue);
            }
            else
            {
                txtEmployeeNo.EditValue = 0;
            }
        }

        private void lookUpBankBranch_EditValueChanged(object sender, EventArgs e)
        {
            txtBankCode.Text = "";
            if (lookUpBankBranch.EditValue != null)
            {
                var bankBranch = BankBranchDALObj.FindSaveModelByPrimeKey((int)lookUpBankBranch.EditValue);
                if (bankBranch != null)
                {
                    txtBankCode.Text = bankBranch.BankCode;
                }
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            tabbedControlGroup1.SelectedTabPageIndex = 1;
            txtIDNum.Focus();
        }

        private void cmbEmploymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Employee.eEmploymentType empType = (eEmploymentType)cmbEmploymentType.SelectedIndex;

            if (empType == eEmploymentType.Casual)
            {
                txtDailyRate.Enabled = true;

                txtBasicSalary.Enabled = false;
                txtBasicSalary.EditValue = 0;
                ErrorProvider.SetError(txtBasicSalary, "");

                txtHousingAllowance.Enabled = false;
                txtHousingAllowance.EditValue = 0;
                txtWeekendAllowance.Enabled = false;
                txtWeekendAllowance.EditValue = 0;

                dsEmployeeLeaveOpeningBalance.ForEach(r => r.OpeningBalance = 0);
                gridControlLeaveOpeningBalance.Enabled = false;

            }
            else
            {
                txtBasicSalary.Enabled = true;
                txtHousingAllowance.Enabled = true;
                txtWeekendAllowance.Enabled = (((eTAWeekEndAttendance)cmbTAWeekEndAttendance.SelectedIndex) == eTAWeekEndAttendance.Allowance);

                txtDailyRate.Enabled = false;
                txtDailyRate.EditValue = 0;
                ErrorProvider.SetError(txtDailyRate, "");

                gridControlLeaveOpeningBalance.Enabled = true;
            }

            if (empType == eEmploymentType.Casual)
            {
                cmbPayCycle.Enabled = true;
            }
            else
            {
                cmbPayCycle.Enabled = false;
                cmbPayCycle.SelectedIndex = (int)Model.Employee.ePaymentCycle.Monthly;
            }

            if (empType == eEmploymentType.Contract)
            {
                deContractExpiryDate.Enabled = true;
            }
            else
            {
                deContractExpiryDate.Enabled = false;
                deContractExpiryDate.EditValue = null;
                ErrorProvider.SetError(deContractExpiryDate, "");
            }
        }

        private void txtBasicSalary_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void gridViewLeaveOpeningBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter
                && gridViewLeaveOpeningBalance.IsLastRow
                && gridViewLeaveOpeningBalance.Columns.Last() == gridViewLeaveOpeningBalance.FocusedColumn)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void gridViewLeaveOpeningBalance_GotFocus(object sender, EventArgs e)
        {
            gridViewLeaveOpeningBalance.MoveFirst();
            gridViewLeaveOpeningBalance.FocusedColumn = colOpeningBalance;
            gridViewLeaveOpeningBalance.ShowEditor();
            //gridViewLeaveOpeningBalance.ShowEditorByKey(new KeyEventArgs(Keys.Enter));
        }

        private void cmbEmployeeShiftType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((eEmployeeShiftType)cmbEmployeeShiftType.SelectedIndex) == eEmployeeShiftType.Fixed)
            {
                lookupEmployeeShift.Enabled = true;
                lookupEmployeeShift.EditValue = null;
            }
            else
            {
                lookupEmployeeShift.Enabled = false;
            }
        }

        private void cmbTAWeekEndAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtWeekendAllowance.Enabled = (((eTAWeekEndAttendance)cmbTAWeekEndAttendance.SelectedIndex) == eTAWeekEndAttendance.Allowance);
        }

        private void btnUpdateTimeAttendanceData_Click(object sender, EventArgs e)
        {
            if (EditRecordDataSource == null)
            {
                MessageBox.Show("Please save employee first.", "Vision", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (String.IsNullOrWhiteSpace(txtTACode.Text) || !Model.CommonFunctions.CheckParseInt(txtTACode.Text))
            {
                MessageBox.Show("Please enter valid numeric value in TA Code.", "Vision", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int EmployeeID = ((EmployeeEditListModel)EditRecordDataSource).EmployeeID;
            int TACode = Model.CommonFunctions.ParseInt(txtTACode.EditValue.ToString());

            SavingResult res = DALObject.UpdateTACode(EmployeeID, TACode);
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                res = DALObject.UpdateTimeAttendanceData(TACode);
            }
            AfterSaving(new SavingParemeter() { SavingInterface = SavingParemeter.eSavingInterface.Update, SavingResult = res });
        }

        private void btnTerminateEmployee_Click(object sender, EventArgs e)
        {
            if (EditRecordDataSource == null)
            {
                MessageBox.Show("Please select employee.", "Termination", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbTerminationType.Focus();
                return;
            }
            if (cmbTerminationType.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select termination type.", "Termination", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbTerminationType.Focus();
                return;
            }
            if (deTerminationDate.EditValue == null)
            {
                MessageBox.Show("Please enter termination date.", "Termination", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                deTerminationDate.Focus();
                return;
            }
            SavingResult res =
            DALObject.Termination(((EmployeeEditListModel)EditRecordDataSource).EmployeeID,
                (eTerminationType)(cmbTerminationType.SelectedIndex ),
                deTerminationDate.DateTime,
                txtTerminationReason.Text);
            AfterSaving(new SavingParemeter() { SavingResult = res, SavingInterface = SavingParemeter.eSavingInterface.Update });
            if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                ResetFormView(FormDefaultUI);
            }
        }

        private void btnReinstateEmployee_Click(object sender, EventArgs e)
        {
            if (EditRecordDataSource == null)
            {
                MessageBox.Show("Please select employee.", "Termination", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                cmbTerminationType.Focus();
                return;
            }
            if (deReinstateEmployeementDate.EditValue == null)
            {
                MessageBox.Show("Please enter reinstatement date.", "Termination", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                deReinstateEmployeementDate.Focus();
                return;
            }
            SavingResult res =
            DALObject.ReInstate(((EmployeeEditListModel)EditRecordDataSource).EmployeeID,
                txtReinstatementReason.Text,
                            new EmployeeServiceDetailViewModel()
                            {
                                EmploymentEffectiveDate = deReinstateEmployeementDate.DateTime,

                                DailyRate = Model.CommonFunctions.ParseDecimal(txtDailyRate.Text),
                                BasicSalary = Model.CommonFunctions.ParseDecimal(txtBasicSalary.Text),
                                HousingAllowance = Model.CommonFunctions.ParseDecimal(txtHousingAllowance.Text),
                                WeekendAllowance = Model.CommonFunctions.ParseDecimal(txtWeekendAllowance.Text),
                                EmployeeDesignationID = (int)lookupDesignation.EditValue,
                                EmployeeDepartmentID = (int)lookUpDepartment.EditValue,
                                EmployeeWIBAClassID = (int)lookupWIBAClass.EditValue,
                                LocationID = (int)lookUpLocation.EditValue,
                                MinimumWageCategoryID = (int)lookUpMinimumWageCategory.EditValue,
                                ContractExpiryDate = (DateTime?)deContractExpiryDate.EditValue,
                                EmploymentType = (byte)cmbEmploymentType.SelectedIndex,

                                EmployeeShiftTypeID = (byte)cmbEmployeeShiftType.SelectedIndex,
                                EmployeeShiftID = (int?)lookupEmployeeShift.EditValue,

                                EmployeeLeaveOpeningBalance = dsEmployeeLeaveOpeningBalance
                            });

            AfterSaving(new SavingParemeter() { SavingResult = res, SavingInterface = SavingParemeter.eSavingInterface.Update });
            if(res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
            {
                ResetFormView(FormDefaultUI);
            }
        }

        private void cmbTerminationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lcgTerminationControls.Enabled = (((eTerminationType)cmbTerminationType.SelectedIndex) != eTerminationType.NA);
        }

        private void cmbPFApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPFNum.Enabled = ((eProvidentFund)cmbPFApplicable.SelectedIndex == eProvidentFund.Applicable);
            if(!txtPFNum.Enabled)
            {
                ErrorProvider.SetError(txtPFNum, null);
            }
        }

        private void txtPFNum_Validating(object sender, CancelEventArgs e)
        {
            if(((eProvidentFund)cmbPFApplicable.SelectedIndex) == eProvidentFund.Applicable && String.IsNullOrWhiteSpace(txtPFNum.Text))
            {
                ErrorProvider.SetError(txtPFNum, "Please enter P.F. No.");
            }
            else
            {
                ErrorProvider.SetError(txtPFNum, null);
            }
        }
    }
}

