using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Loan;

namespace Vision.DAL.Loan
{
    public class LoanAdjustmentDAL
    {
        public SavingResult SaveNewRecord(tblLoanAdjustment SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLoanAdjustment SaveModel;
                if (SaveModel.LoanAdjustmentNo == 0)
                {
                    res.ValidationError = "Please enter Loan Adjustment No.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LoanAdjustmentNoPrefixID, SaveModel.LoanAdjustmentNo, SaveModel.LoanAdjustmentID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Loan Adjustment No. is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LoanAdjustmentID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblLoanAdjustments.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLoanAdjustments.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LoanAdjustmentID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLoanAdjustment FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblLoanAdjustments.Find(ID);
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LoanAdjustmentID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LoanAdjustment is selected in company";
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
                    tblLoanAdjustment RecordToDelete = db.tblLoanAdjustments.FirstOrDefault(r => r.LoanAdjustmentID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLoanAdjustments.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLoanAdjustments.Attach(RecordToDelete);
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
                var rec = db.tblLoanAdjustments.FirstOrDefault(r => r.LoanAdjustmentID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLoanAdjustments.Attach(rec);
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
                var rec = db.tblLoanAdjustments.FirstOrDefault(r => r.LoanAdjustmentID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLoanAdjustments.Attach(rec);
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

        public List<LoanAdjustmentEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanAdjustments

                        join jp in db.tblLoanAdjustmentNoPrefixes on r.LoanAdjustmentNoPrefixID equals jp.LoanAdjustmentNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()

                        join jla in db.tblLoanApplications on r.LoanApplicationID equals jla.LoanApplicationID into gla
                        from la in gla.DefaultIfEmpty()

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

                        orderby (e != null ? e.EmployeeNo : 0), r.LoanAdjustmentDate, r.LoanAdjustmentNo

                        select new LoanAdjustmentEditListModel()
                        {
                            LoanAdjustmentID = r.LoanAdjustmentID,
                            LoanAdjustmentNoPrefixName = (p != null ? p.LoanAdjustmentNoPrefixName : null),
                            LoanAdjustmentNo = r.LoanAdjustmentNo,
                            LoanAdjustmentDate = r.LoanAdjustmentDate,

                            LoanAmount = (la != null ? la.LoanAmount : 0),
                            LoanAdjustmentAmount = r.LoanAdjustmentAmount,
                            Reason = r.ReasonForLoanAdjustment,


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

        public List<LoanAdjustmentLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLoanAdjustments

                        join jp in db.tblLoanAdjustmentNoPrefixes on r.LoanAdjustmentNoPrefixID equals jp.LoanAdjustmentNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()

                        join jla in db.tblLoanApplications on r.LoanApplicationID equals jla.LoanApplicationID into gla
                        from la in gla.DefaultIfEmpty()

                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()

                        join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                        from ep in gep.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                        orderby (e != null ? e.EmployeeNo : 0), r.LoanAdjustmentDate, r.LoanAdjustmentNo

                        select new LoanAdjustmentLookupListModel()
                        {
                            LoanAdjustmentID = r.LoanAdjustmentID,
                            LoanAdjustmentNoPrefixName = (p != null ? p.LoanAdjustmentNoPrefixName : null),
                            LoanAdjustmentNo = r.LoanAdjustmentNo,
                            LoanAdjustmentDate = r.LoanAdjustmentDate,

                            LoanAmount = (la != null ? la.LoanAmount : 0),
                            LoanAdjustmentAmount =r.LoanAdjustmentAmount,
                            Reason = r.ReasonForLoanAdjustment,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LoanAdjustmentNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PrefixID, LoanAdjustmentNo, ID, db);
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LoanAdjustmentNo, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblLoanAdjustments.FirstOrDefault(i =>
                i.LoanAdjustmentNo == LoanAdjustmentNo
                && i.LoanAdjustmentNoPrefixID == PrefixID
                && i.LoanAdjustmentID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public int GenerateLoanAdjustmentNo(int PrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (db.tblLoanAdjustments.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != RecordState_Deleted &&
                    r.LoanAdjustmentNoPrefixID == PrefixID).Max(r => (int?)r.LoanAdjustmentNo) ?? 0) + 1;
            }
        }
    }
}
