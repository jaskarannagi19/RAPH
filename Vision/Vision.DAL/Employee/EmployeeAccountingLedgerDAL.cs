using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeAccountingLedgerDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeAccountingLedger SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployeeAccountingLedger SaveModel;

                if (String.IsNullOrWhiteSpace( SaveModel.EmployeeAccountingLedgerName))
                {
                    res.ValidationError = "Can not accept blank value. Please enter Accounting Ledger Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeAccountingLedgerName, SaveModel.EmployeeAccountingLedgerID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Accounting Ledger Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeAccountingLedgerID == 0) // New Entry
                {
                    SaveModel.rstate = (byte)eRecordState.Active;
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblEmployeeAccountingLedgers.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeAccountingLedgers.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeAccountingLedgerID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeAccountingLedger FindSaveModelByPrimeKey(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeAccountingLedgers.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(int DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            //using (dbVisionEntities db = new dbVisionEntities())
            //{
            //    bool InState = db.tblCompanies.FirstOrDefault(r => r.EmployeeAccountingLedgerID == DeleteID) != null;
            //    if (InState)
            //    {
            //        Result.ValidationMessage = "Country is selected in company";
            //    }
            //}
            //Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(int DeleteID)
        {
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (DeleteID != 0)
                {
                    tblEmployeeAccountingLedger RecordToDelete = db.tblEmployeeAccountingLedgers.Find(DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblEmployeeAccountingLedgers.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployeeAccountingLedgers.Attach(RecordToDelete);
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
                var rec = db.tblEmployeeAccountingLedgers.Find(ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployeeAccountingLedgers.Attach(rec);
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
                var rec = db.tblEmployeeAccountingLedgers.FirstOrDefault(r => r.EmployeeAccountingLedgerID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployeeAccountingLedgers.Attach(rec);
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

        public List<EmployeeAccountingLedgerEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from EmployeeAccountingLedger in db.tblEmployeeAccountingLedgers

                        join joinrcu in db.tblUsers on EmployeeAccountingLedger.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on EmployeeAccountingLedger.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where EmployeeAccountingLedger.rstate != RecordState_Deleted
                        && EmployeeAccountingLedger.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeAccountingLedger.EmployeeAccountingLedgerName

                        select new EmployeeAccountingLedgerEditListModel()
                        {
                            EmployeeAccountingLedgerID = EmployeeAccountingLedger.EmployeeAccountingLedgerID,
                            EmployeeAccountingLedgerName = EmployeeAccountingLedger.EmployeeAccountingLedgerName,

                            RecordState = (eRecordState)EmployeeAccountingLedger.rstate,
                            CreatedDateTime = EmployeeAccountingLedger.rcdt,
                            EditedDateTime = EmployeeAccountingLedger.redt,
                            CreatedUserID = EmployeeAccountingLedger.rcuid,
                            EditedUserID = EmployeeAccountingLedger.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<EmployeeAccountingLedgerLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from EmployeeAccountingLedger in db.tblEmployeeAccountingLedgers

                        where EmployeeAccountingLedger.rstate != RecordState_Deleted
                        && EmployeeAccountingLedger.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeAccountingLedger.EmployeeAccountingLedgerName

                        select new EmployeeAccountingLedgerLookupListModel()
                        {
                            EmployeeAccountingLedgerID = EmployeeAccountingLedger.EmployeeAccountingLedgerID,
                            EmployeeAccountingLedgerName = EmployeeAccountingLedger.EmployeeAccountingLedgerName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string EmployeeAccountingLedgerName, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(EmployeeAccountingLedgerName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string EmployeeAccountingLedgerName, int ID, dbVisionEntities db)
        {
            if (db.tblEmployeeAccountingLedgers.Any(i => 
            i.EmployeeAccountingLedgerName == EmployeeAccountingLedgerName 
            && i.EmployeeAccountingLedgerID != ID
            && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID))
            {
                return true;
            }
            return false;
        }
    }
}
