using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Loan;

namespace Vision.DAL.Loan
{
    public class LoanApplicationDAL
    {
        public SavingResult SaveNewRecord(tblLoanApplication SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLoanApplication SaveModel;
                if (SaveModel.LoanApplicationNo == 0)
                {
                    res.ValidationError = "Please enter Loan Application No.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LoanApplicationNoPrefixID, SaveModel.LoanApplicationNo, SaveModel.LoanApplicationID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Loan Application No. is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LoanApplicationID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblLoanApplications.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLoanApplications.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LoanApplicationID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLoanApplication FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblLoanApplications.Find(ID);
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LoanApplicationID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LoanApplication is selected in company";
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
                    tblLoanApplication RecordToDelete = db.tblLoanApplications.FirstOrDefault(r => r.LoanApplicationID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLoanApplications.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLoanApplications.Attach(RecordToDelete);
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
                var rec = db.tblLoanApplications.FirstOrDefault(r => r.LoanApplicationID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLoanApplications.Attach(rec);
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
                var rec = db.tblLoanApplications.FirstOrDefault(r => r.LoanApplicationID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLoanApplications.Attach(rec);
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

        public List<LoanApplicationEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanApplications
                        join jp in db.tblLoanApplicationNoPrefixes on r.LoanApplicationNoPrefixID equals jp.LoanApplicationNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()
                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()
                        join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                        from ep in gep.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                        orderby (e != null ? e.EmployeeNo : 0), r.LoanApplicationDate, r.LoanApplicationNo

                        select new LoanApplicationEditListModel()
                        {
                            LoanApplicationID = r.LoanApplicationID,
                            LoanApplicationNoPrefixName = (p != null ? p.LoanApplicationNoPrefixName : null),
                            LoanApplicationNo = r.LoanApplicationNo,
                            LoanApplicateDate = r.LoanApplicationDate,

                            MonthFrom = r.MonthFrom,
                            YearFrom = r.YearFrom,
                            MonthTo = r.MonthTo,
                            YearTo = r.YearTo,

                            LoanApplicationAmount = r.LoanAmount,
                            InstallmentAmount = r.InstallmentAmount,
                            Purpose = r.LoanPurpose,
                            
                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

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

        public List<LoanApplicationLookupListModel> GetLookupList(int EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanApplications
                        join jp in db.tblLoanApplicationNoPrefixes on r.LoanApplicationNoPrefixID equals jp.LoanApplicationNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()
                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()
                        join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                        from ep in gep.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                && r.EmployeeID == EmployeeID

                        orderby (e != null ? e.EmployeeNo : 0), r.LoanApplicationDate, r.LoanApplicationNo

                        select new LoanApplicationLookupListModel()
                        {
                            LoanApplicationID = r.LoanApplicationID,
                            LoanApplicationNoPrefixName = (p != null ? p.LoanApplicationNoPrefixName : null),
                            LoanApplicationNo = r.LoanApplicationNo,
                            LoanApplicateDate = r.LoanApplicationDate,

                            MonthFrom = r.MonthFrom,
                            YearFrom = r.YearFrom,
                            MonthTo = r.MonthTo,
                            YearTo = r.YearTo,

                            InstallmentAmount = r.InstallmentAmount,
                            LoanApplicationAmount = r.LoanAmount,

                            Purpose = r.LoanPurpose,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LoanApplicationNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PrefixID, LoanApplicationNo, ID, db);
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LoanApplicationNo, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblLoanApplications.FirstOrDefault(i =>
                i.LoanApplicationNo == LoanApplicationNo
                && i.LoanApplicationNoPrefixID == PrefixID
                && i.LoanApplicationID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public int GenerateLoanApplicationNo(int PrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (db.tblLoanApplications.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != RecordState_Deleted &&
                    r.LoanApplicationNoPrefixID == PrefixID).Max(r => (int?)r.LoanApplicationNo) ?? 0) + 1;
            }
        }
    }
}
