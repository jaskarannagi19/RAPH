using Vision.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.SubMaster;

namespace Vision.DAL.SubMaster
{
    public class CurrencyDAL
    {
        public SavingResult SaveNewRecord(tblCurrency SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblCurrency SaveModel;
                if (SaveModel.CurrencyName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Currency Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.CurrencyName, SaveModel.CurrencyID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Currency Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.CurrencyID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblCurrencies.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblCurrencies.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.CurrencyID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblCurrency FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblCurrencies.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.CurrencyID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "Currency is selected in company";
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
                    tblCurrency RecordToDelete = db.tblCurrencies.FirstOrDefault(r => r.CurrencyID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblCurrencies.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblCurrencies.Attach(RecordToDelete);
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
                var rec = db.tblCurrencies.FirstOrDefault(r => r.CurrencyID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblCurrencies.Attach(rec);
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
                var rec = db.tblCurrencies.FirstOrDefault(r => r.CurrencyID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblCurrencies.Attach(rec);
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

        public List<CurrencyEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblCurrencies

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted

                        orderby r.CurrencyName

                    select new CurrencyEditListModel()
                    {
                        CurrencyID = r.CurrencyID,
                        CurrencyName = r.CurrencyName,
                        CurrencySymbole = r.CurrencySymbole,

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

        public List<CurrencyLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblCurrencies

                        where r.rstate != RecordState_Deleted

                        orderby r.CurrencyName

                        select new CurrencyLookupListModel()
                        {
                            CurrencyID = r.CurrencyID,
                            CurrencyName = r.CurrencyName,
                            CurrencySymbole = r.CurrencySymbole
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string CurrencyName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(CurrencyName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string CurrencyName, long ID, dbVisionEntities db)
        {
            if (db.tblCurrencies.FirstOrDefault(i => i.CurrencyName == CurrencyName && i.CurrencyID != ID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
