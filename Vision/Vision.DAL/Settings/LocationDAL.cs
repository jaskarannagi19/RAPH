using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Settings;

namespace Vision.DAL.Settings
{
    public class LocationDAL
    {
        public SavingResult SaveNewRecord(tblLocation SaveModel, LocationWeekendSettingViewModel WeekendSetting)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLocation SaveModel;
                if (SaveModel.LocationName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Location Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LocationName, SaveModel.LocationID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Location Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LocationID == 0) // New Entry
                {
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblLocations.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLocations.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    if (WeekendSetting.WEDateFrom != null)
                    {
                        DateTime LastUptoDate = WeekendSetting.WEDateFrom.Value.Date.AddDays(-1);
                        foreach (var weekendRows in db.tblLocationWeekendSettings.Where(r => r.LocationID == SaveModel.LocationID
                                            && r.WEDateFrom < WeekendSetting.WEDateFrom && (r.WEDateTo == null || r.WEDateTo >= WeekendSetting.WEDateFrom)))
                        {
                            weekendRows.WEDateTo = LastUptoDate;
                            db.tblLocationWeekendSettings.Attach(weekendRows);
                            db.Entry(weekendRows).State = System.Data.Entity.EntityState.Modified;
                        }
                        db.tblLocationWeekendSettings.RemoveRange(db.tblLocationWeekendSettings.Where(r => r.LocationID == SaveModel.LocationID
                                           && r.WEDateFrom >= WeekendSetting.WEDateFrom));
                    }
                    else
                    {
                        db.tblLocationWeekendSettings.RemoveRange(db.tblLocationWeekendSettings.Where(r => r.LocationID == SaveModel.LocationID));
                    }
                }

                db.tblLocationWeekendSettings.Add(new tblLocationWeekendSetting()
                {
                    tblLocation = SaveModel,
                    WEDateFrom = WeekendSetting.WEDateFrom,
                    Monday = (byte)WeekendSetting.Monday,
                    Tuesday = (byte)WeekendSetting.Tuesday,
                    Wednesday = (byte)WeekendSetting.Wednesday,
                    Thursday = (byte)WeekendSetting.Thursday,
                    Friday = (byte)WeekendSetting.Friday,
                    Saturday = (byte)WeekendSetting.Saturday,
                    Sunday = (byte)WeekendSetting.Sunday
                });

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LocationID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLocation FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblLocations.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LocationID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "Location is selected in company";
                //}
            }
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (DeleteID != 0)
                {
                    tblLocation RecordToDelete = db.tblLocations.FirstOrDefault(r => r.LocationID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLocations.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLocations.Attach(RecordToDelete);
                        db.Entry(RecordToDelete).State = System.Data.Entity.EntityState.Modified;
                    }

                    try
                    {
                        db.SaveChanges();
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

        public SavingResult Authorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblLocations.FirstOrDefault(r => r.LocationID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLocations.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;

                //--
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult UnAuthorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblLocations.FirstOrDefault(r => r.LocationID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLocations.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;

                //--
                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public List<LocationEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                int LocationType_UrbanID = (int)eLocationType.Urban;
                return (from r in db.tblLocations

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LocationName

                        select new LocationEditListModel()
                        {
                            LocationID = r.LocationID,
                            LocationName = r.LocationName,
                            LocationType = (r.LocationTypeID == LocationType_UrbanID? "Urban" : "Rural"),

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<LocationLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLocations

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LocationName

                        select new LocationLookupListModel()
                        {
                            LocationID = r.LocationID,
                            LocationName = r.LocationName,
                            
                        }).ToList();
            }
        }

        public LocationWeekendSettingViewModel GetLatestWeekendSetting(int LocationID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var SaveModel = db.tblLocationWeekendSettings.Where(r=> r.LocationID == LocationID).OrderByDescending(r => r.WEDateFrom).FirstOrDefault();
                if(SaveModel != null)
                {
                    return new LocationWeekendSettingViewModel()
                    {
                        WEDateFrom = SaveModel.WEDateFrom,
                        WEDateTo = SaveModel.WEDateTo,
                        Monday = (eWeekDayType)SaveModel.Monday,
                        Tuesday = (eWeekDayType)SaveModel.Tuesday,
                        Wednesday = (eWeekDayType)SaveModel.Wednesday,
                        Thursday = (eWeekDayType)SaveModel.Thursday,
                        Friday = (eWeekDayType)SaveModel.Friday,
                        Saturday = (eWeekDayType)SaveModel.Saturday,
                        Sunday = (eWeekDayType)SaveModel.Sunday,
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsDuplicateRecord(string LocationName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(LocationName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string LocationName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblLocations.FirstOrDefault(i => 
                i.LocationName == LocationName 
                && i.LocationID != ID
                && i.rstate != RecordState_Deleted
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
