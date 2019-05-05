using Vision.Model;
using Vision.Model.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vision.DAL;

namespace Vision.DAL.Settings
{
    public class SettingsDAL
    {
        public ApplicationSettingsViewModel GetSetting()
        {
            return GetSetting(0);
        }
        public ApplicationSettingsViewModel GetSetting(long CompanyID)
        {
            ApplicationSettingsViewModel NewSettings = new ApplicationSettingsViewModel();
            GetSetting(CompanyID, NewSettings);
            return NewSettings;
        }
        public void GetSetting(long CompanyID, ApplicationSettingsViewModel NewSettings)
        {
            if(NewSettings == null)
            {
                return;
            }
            using (dbVisionEntities db = new dbVisionEntities())
            {
                PropertyInfo[] Props = typeof(ApplicationSettingsViewModel).GetProperties();

                foreach (var SaveModel in db.tblSettingL0)
                {
                    string SettingName = SaveModel.SettingName;
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SettingName);
                    if (p == null)
                    {
                        continue;
                    }

                    eSettingValueType SettingValueType = (eSettingValueType)SaveModel.SettingValueType;
                    object SettingValue = (SettingValueType == eSettingValueType.Varchar50 ? (object)SaveModel.SettingValueVC :
                                                    (SettingValueType == eSettingValueType.Int ? (object)SaveModel.SettingValueInt :
                                                    (SettingValueType == eSettingValueType.Long ? (object)SaveModel.SettingValueLong :
                                                    (SettingValueType == eSettingValueType.DateTime ? (object)SaveModel.SettingValueDateTime :
                                                    (SettingValueType == eSettingValueType.Boolean ? (object)SaveModel.SettingValueBoolean :
                                                    (SettingValueType == eSettingValueType.Decimal ? (object)SaveModel.SettingValueDecimal : null))))));

                    SettingValue = (SettingValueType == eSettingValueType.Int && p.PropertyType == typeof(int) ? (object)((int?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.Long && p.PropertyType == typeof(long) ? (object)((long?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.DateTime && p.PropertyType == typeof(DateTime) ? (object)((DateTime?)SettingValue ?? DateTime.MinValue) :
                                (SettingValueType == eSettingValueType.Boolean && p.PropertyType == typeof(bool) ? (object)((bool?)SettingValue ?? false) :
                                (SettingValueType == eSettingValueType.Decimal && p.PropertyType == typeof(decimal) ? (object)((decimal?)SettingValue ?? 0) :
                                
                                SettingValue)))));

                    p.SetValue(NewSettings, SettingValue);
                }

                //foreach (PropertyInfo p in Props)
                foreach (var SaveModelMaster in db.tblSettingMasterL1)
                {
                    string SettingName = SaveModelMaster.SettingName;
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SettingName);
                    if (p == null)
                    {
                        continue;
                    }

                    //tblSettingMasterL1 SaveModelMaster = db.tblSettingMasterL1.FirstOrDefault(r => r.SettingName == SettingName);
                    //if (SaveModelMaster == null)
                    //{
                    //    continue;
                    //}

                    eSettingValueType SettingValueType = (eSettingValueType)SaveModelMaster.SettingValueType;
                    object SettingMasterValue = (SettingValueType == eSettingValueType.Varchar50 ? (object)SaveModelMaster.SettingValueVC :
                                                    (SettingValueType == eSettingValueType.Int ? (object)SaveModelMaster.SettingValueInt :
                                                    (SettingValueType == eSettingValueType.Long ? (object)SaveModelMaster.SettingValueLong :
                                                    (SettingValueType == eSettingValueType.DateTime ? (object)SaveModelMaster.SettingValueDateTime :
                                                    (SettingValueType == eSettingValueType.Boolean ? (object)SaveModelMaster.SettingValueBoolean :
                                                    (SettingValueType == eSettingValueType.Decimal ? (object)SaveModelMaster.SettingValueDecimal : null))))));

                    object SettingValue = null;
                    if (CompanyID != 0)
                    {
                        tblSettingsL1 SaveModel = db.tblSettingsL1.FirstOrDefault(r => r.SettingName == SettingName && r.CompanyID == CompanyID);

                        SettingValue = (SaveModel == null ? null : (SettingValueType == eSettingValueType.Varchar50 ? (object)SaveModel.SettingValueVC :
                                    (SettingValueType == eSettingValueType.Int ? (object)SaveModel.SettingValueInt :
                                    (SettingValueType == eSettingValueType.Long ? (object)SaveModel.SettingValueLong :
                                    (SettingValueType == eSettingValueType.DateTime ? (object)SaveModel.SettingValueDateTime :
                                    (SettingValueType == eSettingValueType.Boolean ? (object)SaveModel.SettingValueBoolean :
                                    (SettingValueType == eSettingValueType.Decimal ? (object)SaveModel.SettingValueDecimal : null)))))));
                    }

                    if (SettingValue == null)
                    {
                        SettingValue = SettingMasterValue;
                    }

                    /// If property type is not nullable type and setting value is null then assign default value.
                    SettingValue = (SettingValueType == eSettingValueType.Int && (p.PropertyType == typeof(int) || p.PropertyType.IsEnum) ? (object)((int?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.Long && p.PropertyType == typeof(long) ? (object)((long?)SettingValue ?? 0) :
                                (SettingValueType == eSettingValueType.DateTime && p.PropertyType == typeof(DateTime) ? (object)((DateTime?)SettingValue ?? DateTime.MinValue) :
                                (SettingValueType == eSettingValueType.Boolean && p.PropertyType == typeof(bool) ? (object)((bool?)SettingValue ?? false) :
                                (SettingValueType == eSettingValueType.Decimal && p.PropertyType == typeof(decimal) ? (object)((decimal?)SettingValue ?? 0) :
                                
                                SettingValue)))));


                    p.SetValue(NewSettings, SettingValue);
                }
            }
        }

        public SavingResult SaveSettings(ApplicationSettingsViewModel ApplicationSetting, int CompanyID, List<LicenseNofEmployeeViewModel> LicenseNofEmployees)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                PropertyInfo[] Props = typeof(ApplicationSettingsViewModel).GetProperties();

                /// Setting Level 0
                foreach (var SaveModel in db.tblSettingL0)
                {
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SaveModel.SettingName);
                    if (p == null)
                    {
                        continue;
                    }
                    SaveSettingL0(p.Name, p.GetValue(ApplicationSetting), db, res);
                }

                /// Setting Level 1
                foreach (var SaveModel in db.tblSettingMasterL1)
                {
                    PropertyInfo p = Props.FirstOrDefault(r => r.Name == SaveModel.SettingName);
                    if(p == null)
                    {
                        continue;
                    }
                    SaveSettingL1(p.Name, p.GetValue(ApplicationSetting), CompanyID, db, res);
                }

                //--
                try
                {
                    db.SaveChanges();
                    //res.PrimeKeyValue = SaveModel.SettingL1ID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }

                if (LicenseNofEmployees != null)
                {
                    // Nof Employee for all companies
                    foreach (var nofemp in LicenseNofEmployees)
                    {
                        SaveSettingL1("License_NofEmployee", nofemp.NofEmployee, nofemp.CompanyID, db, res);
                        SaveSettingL1("License_ValidUpto", nofemp.ValidUpto, nofemp.CompanyID, db, res);
                    }
                    //--
                    try
                    {
                        db.SaveChanges();
                        //res.PrimeKeyValue = SaveModel.SettingL1ID;
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    }
                    catch (Exception ex)
                    {
                        CommonFunctions.GetFinalError(res, ex);
                    }
                }
            }
            return res;
        }

        public SavingResult SaveSettingL1(string SettingName, object SettingValue, int CompanyID)
        {
            SavingResult res = new SavingResult();
            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblSettingsL1 SaveModel = SaveSettingL1(SettingName, SettingValue, CompanyID, db, res);
                if(res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.SettingL1ID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblSettingsL1 SaveSettingL1(string SettingName, object SettingValue, int CompanyID, dbVisionEntities db, SavingResult res)
        {
            tblSettingMasterL1 SaveModelMaster = db.tblSettingMasterL1.FirstOrDefault(r => r.SettingName == SettingName);
            if (SaveModelMaster == null)
            {
                res.ValidationError = "Setting not found.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return null;
            }

            tblSettingsL1 SaveModel = db.tblSettingsL1.FirstOrDefault(r => r.SettingName == SettingName && r.CompanyID == CompanyID);

            if (SaveModel == null) // New Entry
            {
                SaveModel = new tblSettingsL1()
                {
                    SettingName = SaveModelMaster.SettingName,
                    CompanyID = CompanyID
                };
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                db.tblSettingsL1.Add(SaveModel);
            }
            else
            {
                SaveModel.redt = DateTime.Now;
                db.tblSettingsL1.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
            }

            switch ((eSettingValueType)SaveModelMaster.SettingValueType)
            {
                case eSettingValueType.Varchar50:
                    SaveModel.SettingValueVC = (string)SettingValue;
                    break;
                case eSettingValueType.Int:
                    /// specially for enum type, casted to int then nullable int
                    SaveModel.SettingValueInt = (SettingValue != null ? (int?)((int)SettingValue) : null);
                    break;
                case eSettingValueType.Long:
                    SaveModel.SettingValueLong = (long?)SettingValue;
                    break;
                case eSettingValueType.DateTime:
                    SaveModel.SettingValueDateTime = (DateTime?)SettingValue;
                    break;
                case eSettingValueType.Boolean:
                    SaveModel.SettingValueBoolean = (bool?)SettingValue;
                    break;
                case eSettingValueType.Decimal:
                    SaveModel.SettingValueDecimal = (decimal?)SettingValue;
                    break;
            }
            return SaveModel;
        }

        public object GetSettingL1(string SettingName, long ComapnyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblSettingMasterL1 SaveModelMaster = db.tblSettingMasterL1.FirstOrDefault(r => r.SettingName == SettingName);
                if (SaveModelMaster == null)
                {
                    throw new Exception($"Setting name not found. Setting Name : {SettingName}");
                }

                tblSettingsL1 SaveModel = db.tblSettingsL1.FirstOrDefault(r => r.SettingName == SettingName && r.CompanyID == ComapnyID);
                //object SettingValue = null;
                if (SaveModel == null)
                {
                    if(SaveModelMaster != null)
                    {
                        switch ((eSettingValueType)SaveModelMaster.SettingValueType)
                        {
                            case eSettingValueType.Varchar50:
                                return SaveModelMaster.SettingValueVC;
                            case eSettingValueType.Int:
                                return SaveModelMaster.SettingValueInt;
                            case eSettingValueType.Long:
                                return SaveModelMaster.SettingValueLong;
                            case eSettingValueType.DateTime:
                                return SaveModelMaster.SettingValueDateTime;
                            case eSettingValueType.Boolean:
                                return SaveModelMaster.SettingValueBoolean;
                            case eSettingValueType.Decimal:
                                return SaveModelMaster.SettingValueDecimal;
                        }
                    }
                }
                else
                {
                    switch ((eSettingValueType)SaveModelMaster.SettingValueType)
                    {
                        case eSettingValueType.Varchar50:
                            return SaveModel.SettingValueVC;
                        case eSettingValueType.Int:
                            return SaveModel.SettingValueInt;
                        case eSettingValueType.Long:
                            return SaveModel.SettingValueLong;
                        case eSettingValueType.DateTime:
                            return SaveModel.SettingValueDateTime;
                        case eSettingValueType.Boolean:
                            return SaveModel.SettingValueBoolean;
                        case eSettingValueType.Decimal:
                            return SaveModel.SettingValueDecimal;
                    }
                }
            }
            return null;
        }

        public SavingResult SaveSettingL0(string SettingName, object SettingValue)
        {
            SavingResult res = new SavingResult();
            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblSettingL0 SaveModel = SaveSettingL0(SettingName, SettingValue, db, res);
                if (res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.SettingL0ID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblSettingL0 SaveSettingL0(string SettingName, object SettingValue, dbVisionEntities db, SavingResult res)
        {
            tblSettingL0 SaveModel = db.tblSettingL0.FirstOrDefault(r => r.SettingName == SettingName);

            if (SaveModel == null) // New Entry
            {
                SaveModel = new tblSettingL0()
                {
                    SettingName = SaveModel.SettingName,
                };
                SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                SaveModel.rcdt = DateTime.Now;
                db.tblSettingL0.Add(SaveModel);
            }
            else
            {
                SaveModel.redt = DateTime.Now;
                db.tblSettingL0.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
            }

            switch ((eSettingValueType)SaveModel.SettingValueType)
            {
                case eSettingValueType.Varchar50:
                    SaveModel.SettingValueVC = (string)SettingValue;
                    break;
                case eSettingValueType.Int:
                    SaveModel.SettingValueInt = (int?)SettingValue;
                    break;
                case eSettingValueType.Long:
                    SaveModel.SettingValueLong = (long?)SettingValue;
                    break;
                case eSettingValueType.DateTime:
                    SaveModel.SettingValueDateTime = (DateTime?)SettingValue;
                    break;
                case eSettingValueType.Boolean:
                    SaveModel.SettingValueBoolean = (bool?)SettingValue;
                    break;
                case eSettingValueType.Decimal:
                    SaveModel.SettingValueDecimal = (decimal?)SettingValue;
                    break;
            }
            return SaveModel;
        }

        public List<LicenseNofEmployeeViewModel> GetLicenseNofEmployee()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var MasterSetting = db.tblSettingMasterL1.FirstOrDefault(r => r.SettingName == "License_NofEmployee");
                int DefaultValue = 0;

                if (MasterSetting != null)
                {
                    DefaultValue = MasterSetting.SettingValueInt ?? 0;
                }

                int RecordState_Delete = (int)Model.eRecordState.Deleted;

                var dsComapny = (from r in db.tblCompanies
                        where r.rstate != RecordState_Delete
                        select new LicenseNofEmployeeViewModel()
                        {
                            CompanyID = r.CompanyID,
                            CompanyName = r.CompanyName,
                        }).ToList();

                foreach(var company in dsComapny)
                {
                    var setting = db.tblSettingsL1.Where(r => r.CompanyID == company.CompanyID && r.SettingName == "License_NofEmployee").FirstOrDefault();
                    if(setting != null)
                    {
                        company.NofEmployee = setting.SettingValueInt ?? 0;
                    }
                    setting = db.tblSettingsL1.Where(r => r.CompanyID == company.CompanyID && r.SettingName == "License_ValidUpto").FirstOrDefault();
                    company.ValidUpto = setting.SettingValueDateTime;
                }
                return dsComapny;
            }
        }
    }
}
