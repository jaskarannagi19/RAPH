using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Loan;

namespace Vision.DAL.Loan
{
    public class LoanAdjustmentNoPrefixDAL
    {
        public SavingResult SaveNewRecord(tblLoanAdjustmentNoPrefix SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLoanAdjustmentNoPrefix SaveModel;
                if (SaveModel.LoanAdjustmentNoPrefixName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LoanAdjustmentNoPrefixName, SaveModel.LoanAdjustmentNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Prefix Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LoanAdjustmentNoPrefixID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblLoanAdjustmentNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLoanAdjustmentNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LoanAdjustmentNoPrefixID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLoanAdjustmentNoPrefix FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblLoanAdjustmentNoPrefixes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LoanAdjustmentNoPrefixID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LoanAdjustmentNoPrefix is selected in company";
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
                    tblLoanAdjustmentNoPrefix RecordToDelete = db.tblLoanAdjustmentNoPrefixes.FirstOrDefault(r => r.LoanAdjustmentNoPrefixID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLoanAdjustmentNoPrefixes.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLoanAdjustmentNoPrefixes.Attach(RecordToDelete);
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
                var rec = db.tblLoanAdjustmentNoPrefixes.FirstOrDefault(r => r.LoanAdjustmentNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLoanAdjustmentNoPrefixes.Attach(rec);
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
                var rec = db.tblLoanAdjustmentNoPrefixes.FirstOrDefault(r => r.LoanAdjustmentNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLoanAdjustmentNoPrefixes.Attach(rec);
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

        public List<LoanAdjustmentNoPrefixEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanAdjustmentNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LoanAdjustmentNoPrefixName

                        select new LoanAdjustmentNoPrefixEditListModel()
                        {
                            LoanAdjustmentNoPrefixID = r.LoanAdjustmentNoPrefixID,
                            LoanAdjustmentNoPrefixName = r.LoanAdjustmentNoPrefixName,

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

        public List<LoanAdjustmentNoPrefixLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanAdjustmentNoPrefixes

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LoanAdjustmentNoPrefixName

                        select new LoanAdjustmentNoPrefixLookupListModel()
                        {
                            LoanAdjustmentNoPrefixID = r.LoanAdjustmentNoPrefixID,
                            LoanAdjustmentNoPrefixName = r.LoanAdjustmentNoPrefixName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string LoanAdjustmentNoPrefixName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(LoanAdjustmentNoPrefixName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string LoanAdjustmentNoPrefixName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            return db.tblLoanAdjustmentNoPrefixes.Any(i => i.LoanAdjustmentNoPrefixName == LoanAdjustmentNoPrefixName &&
                i.LoanAdjustmentNoPrefixID != ID &&
                i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                i.rstate != RecordState_Deleted);
        }
    }
}
