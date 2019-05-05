using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Loan;

namespace Vision.DAL.Loan
{
    public class LoanApplicationNoPrefixDAL
    {
        public SavingResult SaveNewRecord(tblLoanApplicationNoPrefix SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLoanApplicationNoPrefix SaveModel;
                if (SaveModel.LoanApplicationNoPrefixName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LoanApplicationNoPrefixName, SaveModel.LoanApplicationNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Prefix Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LoanApplicationNoPrefixID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblLoanApplicationNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLoanApplicationNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LoanApplicationNoPrefixID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLoanApplicationNoPrefix FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblLoanApplicationNoPrefixes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LoanApplicationNoPrefixID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LoanApplicationNoPrefix is selected in company";
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
                    tblLoanApplicationNoPrefix RecordToDelete = db.tblLoanApplicationNoPrefixes.FirstOrDefault(r => r.LoanApplicationNoPrefixID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLoanApplicationNoPrefixes.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLoanApplicationNoPrefixes.Attach(RecordToDelete);
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
                var rec = db.tblLoanApplicationNoPrefixes.FirstOrDefault(r => r.LoanApplicationNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLoanApplicationNoPrefixes.Attach(rec);
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
                var rec = db.tblLoanApplicationNoPrefixes.FirstOrDefault(r => r.LoanApplicationNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLoanApplicationNoPrefixes.Attach(rec);
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

        public List<LoanApplicationNoPrefixEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanApplicationNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LoanApplicationNoPrefixName

                        select new LoanApplicationNoPrefixEditListModel()
                        {
                            LoanApplicationNoPrefixID = r.LoanApplicationNoPrefixID,
                            LoanApplicationNoPrefixName = r.LoanApplicationNoPrefixName,

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

        public List<LoanApplicationNoPrefixLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanApplicationNoPrefixes

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LoanApplicationNoPrefixName

                        select new LoanApplicationNoPrefixLookupListModel()
                        {
                            LoanApplicationNoPrefixID = r.LoanApplicationNoPrefixID,
                            LoanApplicationNoPrefixName = r.LoanApplicationNoPrefixName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string LoanApplicationNoPrefixName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(LoanApplicationNoPrefixName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string LoanApplicationNoPrefixName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            return db.tblLoanApplicationNoPrefixes.Any(i => i.LoanApplicationNoPrefixName == LoanApplicationNoPrefixName &&
                i.LoanApplicationNoPrefixID != ID &&
                i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                i.rstate != RecordState_Deleted);
        }
    }
}
