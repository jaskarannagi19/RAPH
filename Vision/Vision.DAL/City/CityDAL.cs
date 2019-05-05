using Vision.Model;
using Vision.Model.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.City
{
    public class CityDAL
    {
        public SavingResult SaveNewRecord(tblCity SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblCity SaveModel;
                if (SaveModel.CityName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter City Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.CityName, SaveModel.CityID, SaveModel.StateID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The City Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                SaveModel.CountryID = db.tblStates.FirstOrDefault(r => r.StateID == SaveModel.StateID).CountryID;
                if (SaveModel.CityID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblCities.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblCities.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.CityID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblCity FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblCities.Find(ID);
            }
        }

        public CityDetailViewModel GetDetailViewModel(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblCity City = db.tblCities.FirstOrDefault(r=> r.CityID == ID);

                if (City == null) return null;
                else
                {
                    return ConvertToDetailViewModel(City);
                }
            }
        }

        public static CityDetailViewModel ConvertToDetailViewModel(tblCity City)
        {
            return new CityDetailViewModel()
            {
                CityID = City.CityID,
                CityName = City.CityName,
                CountryID = City.CountryID,
                CountryName = City.tblCountry.CountryName,
                StateID = City.StateID,
                StateName = City.tblState.StateName
            };
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                bool InState = db.tblCompanies.FirstOrDefault(r => r.CityID == DeleteID) != null;

                if (InState)
                {
                    Result.ValidationMessage = "City is selected in company";
                }
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
                    tblCity RecordToDelete = db.tblCities.FirstOrDefault(r => r.CityID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }

                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblCities.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblCities.Attach(RecordToDelete);
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
                var rec = db.tblCities.FirstOrDefault(r => r.CityID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblCities.Attach(rec);
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
                var rec = db.tblCities.FirstOrDefault(r => r.CityID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblCities.Attach(rec);
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

        public List<Model.City.CityEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from city in db.tblCities
                        join jstate in db.tblStates on city.StateID equals jstate.StateID into gstate
                        from state in gstate.DefaultIfEmpty()
                        join jcountry in db.tblCountries on city.CountryID equals jcountry.CountryID into gcountry
                        from country in gcountry.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on city.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on city.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where city.rstate != RecordState_Deleted

                        orderby city.CityName

                    select new Model.City.CityEditListModel()
                    {
                        CityID = city.CityID,
                        CityName = city.CityName,
                        StateID = city.StateID ?? 0,
                        StateName = (state != null ? state.StateName : ""),
                        CountryName = (country != null ? country.CountryName : ""),

                        RecordState = (eRecordState)city.rstate,
                        CreatedDateTime = city.rcdt,
                        EditedDateTime = city.redt,
                        CreatedUserID = city.rcuid,
                        EditedUserID = city.reuid,
                        CreatedUserName = (rcu != null ? rcu.UserName : ""),
                        EditedUserName = (reu != null ? reu.UserName : ""),
                    }).ToList();
            }
        }

        public List<Model.City.CityLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from city in db.tblCities
                        join jstate in db.tblStates on city.StateID equals jstate.StateID into gstate
                        from state in gstate.DefaultIfEmpty()
                        join jcountry in db.tblCountries on city.CountryID equals jcountry.CountryID into gcountry
                        from country in gcountry.DefaultIfEmpty()

                        where city.rstate != RecordState_Deleted

                        orderby city.CityName

                        select new Model.City.CityLookupListModel()
                        {
                            CityID = city.CityID,
                            CityName = city.CityName,
                            StateID = city.StateID ?? 0,
                            StateName = (state != null ? state.StateName : ""),
                            CountryName = (country != null ? country.CountryName : ""),
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string CityName, long ID, long? StateID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(CityName, ID, StateID, db);
            }
        }
        public bool IsDuplicateRecord(string CityName, long ID, long? StateID, dbVisionEntities db)
        {
            if (db.tblCities.FirstOrDefault(i => i.CityName == CityName && i.StateID == StateID && i.CityID != ID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
