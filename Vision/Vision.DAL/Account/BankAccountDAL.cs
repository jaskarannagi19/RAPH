using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;

namespace Vision.DAL.Account
{
    public class BankAccountDAL
    {
        public SavingResult SaveNewRecord(tblAccount SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblAccount SaveModel;
                if (SaveModel.AccountName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter BankAccount Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateBankAcNo(SaveModel.AccountName, SaveModel.AccountID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The BankAccount Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.AccountID == 0) // New Entry
                {
                    SaveModel.AccountType = (int)Model.Account.eAccountType.BankAccount;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblAccounts.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblAccounts.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.AccountID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblAccount FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblAccounts.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool InState = db.tblCompanies.FirstOrDefault(r => r.AccountID == DeleteID) != null;

                //if (InState)
                //{
                //    Result.ValidationMessage = "Country is selected in company";
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
                    tblAccount RecordToDelete = db.tblAccounts.FirstOrDefault(r => r.AccountID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }

                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblAccount.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblAccounts.Attach(RecordToDelete);
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
                var rec = db.tblAccounts.FirstOrDefault(r => r.AccountID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblAccounts.Attach(rec);
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
                var rec = db.tblAccounts.FirstOrDefault(r => r.AccountID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblAccounts.Attach(rec);
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

        public List<Model.Account.BankAccountEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                byte AccountType_BankAccount = (byte)Model.Account.eAccountType.BankAccount;

                return (from ac in db.tblAccounts
                        join bank in db.tblBankNames on ac.BankNameID equals bank.BankNameID
                        join branch in db.tblBankBranches on ac.BranchID equals branch.BankBranchID

                        join joinrcu in db.tblUsers on ac.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on ac.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where ac.rstate != RecordState_Deleted && ac.AccountType == AccountType_BankAccount
                        && ac.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby ac.AccountName

                        select new Model.Account.BankAccountEditListModel()
                        {
                            BankAccountID = ac.AccountID,
                            BankAccountName = ac.AccountName,
                            BankAccountNo = ac.BankAccountNo,
                            BankName = bank.BankName,
                            BranchName = branch.BankBranchName,

                            RecordState = (eRecordState)ac.rstate,
                            CreatedDateTime = ac.rcdt,
                            EditedDateTime = ac.redt,
                            CreatedUserID = ac.rcuid,
                            EditedUserID = ac.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<Model.Account.BankAccountLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                byte AccountType_BankAccount = (byte)Model.Account.eAccountType.BankAccount;

                return (from ac in db.tblAccounts
                        join bank in db.tblBankNames on ac.BankNameID equals bank.BankNameID
                        join branch in db.tblBankBranches on ac.BranchID equals branch.BankBranchID

                        where ac.rstate != RecordState_Deleted && ac.AccountType == AccountType_BankAccount
                        && ac.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby ac.AccountName

                        select new Model.Account.BankAccountLookupListModel()
                        {
                            BankAccountID = ac.AccountID,
                            BankAccountName = ac.AccountName,
                            BankAccountNo = ac.BankAccountNo,
                            BankName = bank.BankName,
                            BranchName = branch.BankBranchName,
                        }).ToList();
            }
        }

        public bool IsDuplicateBankAcNo(string BankAccountNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateBankAcNo(BankAccountNo, ID, db);
            }
        }
        public bool IsDuplicateBankAcNo(string BankAccountNo, long ID, dbVisionEntities db)
        {
            byte AccountType_BankAccount = (byte)Model.Account.eAccountType.BankAccount;
            if (db.tblAccounts.FirstOrDefault(i => i.BankAccountNo == BankAccountNo && i.AccountID != ID && i.AccountType == AccountType_BankAccount
                        && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
