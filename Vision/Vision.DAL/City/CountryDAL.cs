using Vision.DAL;
using Vision.Model;
using Vision.Model.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.City
{
    public class CountryDAL
    {
        public SavingResult SaveNewRecord(tblCountry SaveModel)
        {
            SavingResult res = new SavingResult();
            
            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;
            
            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblCountry SaveModel;
                if(SaveModel.CountryName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Country Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.CountryName, SaveModel.CountryID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Country Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.CountryID == 0) // New Entry
                {
                    //SaveModel = new tblCountry();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblCountries.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblCountries.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.CountryID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblCountry FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            { 
                return db.tblCountries.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                bool InState = db.tblStates.FirstOrDefault(r => r.CountryID == DeleteID) != null;

                if(InState)
                {
                    Result.ValidationMessage = "Country exists in some states";
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
                    tblCountry RecordToDelete = db.tblCountries.FirstOrDefault(r => r.CountryID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblCountries.Remove(RecordToDelete);

                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblCountries.Attach(RecordToDelete);
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
                var rec = db.tblCountries.FirstOrDefault(r => r.CountryID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblCountries.Attach(rec);
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
                var rec = db.tblCountries.FirstOrDefault(r => r.CountryID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblCountries.Attach(rec);
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

        public IEnumerable<CountryEditListModel> GetEditList()
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from r in db.tblCountries
                       join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                       from rcu in grcu.DefaultIfEmpty()

                       join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                       from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                        orderby r.CountryName

                    select new CountryEditListModel()
                    {
                        CountryID = r.CountryID,
                        CountryName = r.CountryName,

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

        public List<CountryEditListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from Country in db.tblCountries

                        where Country.rstate != RecordState_Deleted
                        
                        orderby Country.CountryName

                        select new CountryEditListModel()
                        {
                            CountryID = Country.CountryID,
                            CountryName = Country.CountryName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string CountryName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(CountryName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string CountryName, long ID, dbVisionEntities db)
        {
            if (db.tblCountries.FirstOrDefault(i => i.CountryName == CountryName && i.CountryID != ID) != null)
            {
                return true;
            }
            return false;
        }

        //public IEnumerable<Model.City.CountryMasterCMBView> GetCountryCombBoxList()
        //{
        //    using (Model.dbModelDataContext db = new Model.dbModelDataContext())
        //    {
        //        return db.tblCountryMasters.Select(i => new CountryMasterCMBView() { CountryID = i.CountryID, CountryName = i.CountryName }).OrderBy(r => r.CountryName).ToList();
        //    }
        //}
    }
}
