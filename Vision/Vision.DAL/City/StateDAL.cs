using Vision.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.City
{
    public class StateDAL
    {
        public SavingResult SaveNewRecord(tblState SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblState SaveModel;
                if (SaveModel.StateName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter state name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.StateName, SaveModel.StateID, SaveModel.CountryID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The State Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.StateID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblStates.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblStates.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.StateID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblState FindSaveModelByPrimeKey(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblStates.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(int DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            return Result;
        }

        public SavingResult DeleteRecord(int DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (DeleteID != 0)
                {
                    tblState RecordToDelete = db.tblStates.FirstOrDefault(r => r.StateID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }

                    else
                    {
                        //db.tblStates.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblStates.Attach(RecordToDelete);
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

        public SavingResult Authorize(int ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblStates.FirstOrDefault(r => r.StateID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblStates.Attach(rec);
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

        public SavingResult UnAuthorize(int ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblStates.FirstOrDefault(r => r.StateID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblStates.Attach(rec);
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

        public IEnumerable<Model.City.StateEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblStates
                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted

                        orderby r.StateName

                    select new Model.City.StateEditListModel()
                    {
                        StateID = r.StateID,
                        StateName = r.StateName,
                        CountryName = r.tblCountry.CountryName,

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

        public IEnumerable<Model.City.StateLookUpListModel> GetLookupList(int CountryID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblStates
                        where r.CountryID == CountryID && r.rstate != RecordState_Deleted
                        orderby r.StateName
                        select new Model.City.StateLookUpListModel()
                        {
                            StateID = r.StateID,
                            StateName = r.StateName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string StateName, int ID, int CountryID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(StateName, ID, CountryID, db);
            }
        }
        public bool IsDuplicateRecord(string StateName, int ID, int CountryID, dbVisionEntities db)
        {
            if (db.tblStates.FirstOrDefault(i => i.StateName == StateName && i.CountryID == CountryID && i.StateID != ID) != null)
            {
                return true;
            }
            return false;
        }

        //public IEnumerable<Model.City.CountryMasterCMBView> GetCountryCombBoxList()
        //{
        //    using (Model.dbModelDataContext db = new Model.dbModelDataContext())
        //    {
        //        return db.tblStateMasters.Select(i => new CountryMasterCMBView() { StateID = i.StateID, StateName = i.StateName }).OrderBy(r => r.StateName).ToList();
        //    }
        //}    }

    }
}
