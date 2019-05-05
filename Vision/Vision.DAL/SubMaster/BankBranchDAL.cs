using Vision.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model.SubMaster;

namespace Vision.DAL.SubMaster
{
    public class BankBranchDAL
    {
        public SavingResult SaveNewRecord(tblBankBranch SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblBankBranch SaveModel;
                if (SaveModel.BankBranchName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Branch Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.BankBranchName, SaveModel.BankBranchID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Branch Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.BankBranchID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblBankBranches.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblBankBranches.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.BankBranchID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblBankBranch FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblBankBranches.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.BankBranchID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "BankBranch is selected in company";
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
                    tblBankBranch RecordToDelete = db.tblBankBranches.FirstOrDefault(r => r.BankBranchID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblBankBranches.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblBankBranches.Attach(RecordToDelete);
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
                var rec = db.tblBankBranches.FirstOrDefault(r => r.BankBranchID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblBankBranches.Attach(rec);
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
                var rec = db.tblBankBranches.FirstOrDefault(r => r.BankBranchID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblBankBranches.Attach(rec);
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

        public List<BankBranchEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblBankBranches
                        join b in db.tblBankNames on r.BankNameID equals b.BankNameID
                        join c in db.tblCities on r.CityID equals c.CityID

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted

                        orderby r.BankBranchName

                    select new BankBranchEditListModel()
                    {
                        BankBranchID = r.BankBranchID,
                        BankBranchName = r.BankBranchName,
                        BankName = b.BankName,
                        City = c.CityName,

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

        public List<BankBranchLookupListModel> GetLookupList(long BankNameID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblBankBranches
                        join b in db.tblBankNames on r.BankNameID equals b.BankNameID

                        where r.rstate != RecordState_Deleted && r.BankNameID == BankNameID

                        orderby r.BankBranchName

                        select new BankBranchLookupListModel()
                        {
                            BankBranchID = r.BankBranchID,
                            BankBranchName = r.BankBranchName,
                            BankName = b.BankName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string BankBranchName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(BankBranchName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string BankBranchName, long ID, dbVisionEntities db)
        {
            if (db.tblBankBranches.FirstOrDefault(i => i.BankBranchName == BankBranchName && i.BankBranchID != ID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
