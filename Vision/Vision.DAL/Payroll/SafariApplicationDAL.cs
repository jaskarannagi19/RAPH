using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class SafariApplicationDAL
    {
        public SavingResult SaveNewRecord(tblSafariApplication SaveModel, List<SafariApplicationDayDetail> DayDetail)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblSafariApplication SaveModel;
                if (SaveModel.SafariApplicationNo == 0)
                {
                    res.ValidationError = "Please enter Safari Application No.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.SafariApplicationNoPrefixID, SaveModel.SafariApplicationNo, SaveModel.SafariApplicationID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Safari Application No. is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.SafariApplicationID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblSafariApplications.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblSafariApplications.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    db.tblSafariApplicationDayDetails.RemoveRange(SaveModel.tblSafariApplicationDayDetails);
                }

                db.tblSafariApplicationDayDetails.AddRange(DayDetail.Select(r => new tblSafariApplicationDayDetail()
                {
                    tblSafariApplication = SaveModel,
                    SafariDate = r.SafariDate,
                    SafariType = (byte)r.SafariDayOffType,
                }));

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.SafariApplicationID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblSafariApplication FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblSafariApplications.Find(ID);
                if(r != null)
                {
                    r.tblSafariApplicationDayDetails = r.tblSafariApplicationDayDetails;
                }
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.SafariApplicationID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "SafariApplication is selected in company";
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
                    tblSafariApplication RecordToDelete = db.tblSafariApplications.FirstOrDefault(r => r.SafariApplicationID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblSafariApplications.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblSafariApplications.Attach(RecordToDelete);
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
                var rec = db.tblSafariApplications.FirstOrDefault(r => r.SafariApplicationID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblSafariApplications.Attach(rec);
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
                var rec = db.tblSafariApplications.FirstOrDefault(r => r.SafariApplicationID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblSafariApplications.Attach(rec);
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

        public List<SafariApplicationEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblSafariApplications

                        join jp in db.tblSafariApplicationNoPrefixes on r.SafariApplicationNoPrefixID equals jp.SafariApplicationNoPrefixID into gp
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

                        orderby (e != null ? e.EmployeeNo : 0), r.FromDate ascending, r.SafariApplicationNo ascending

                        select new SafariApplicationEditListModel()
                        {
                            SafariApplicationID = r.SafariApplicationID,
                            SafariApplicationNoPrefixName = (p != null ? p.SafariApplicationNoPrefixName : null),
                            SafariApplicationNo = r.SafariApplicationNo,
                            SafariApplicateDate = r.SafariApplicationDate,
                            SafariFrom = r.FromDate,
                            SafariTo = r.ToDate,

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

        public List<SafariApplicationLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblSafariApplications
                        join jp in db.tblSafariApplicationNoPrefixes on r.SafariApplicationNoPrefixID equals jp.SafariApplicationNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()
                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()
                        join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                        from ep in gep.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                        orderby (e != null ? e.EmployeeNo : 0), r.FromDate ascending, r.SafariApplicationNo ascending

                        select new SafariApplicationLookupListModel()
                        {
                            SafariApplicationID = r.SafariApplicationID,
                            SafariApplicationNoPrefixName = (p != null ? p.SafariApplicationNoPrefixName : null),
                            SafariApplicationNo = r.SafariApplicationNo,
                            SafariApplicateDate = r.SafariApplicationDate,
                            SafariFrom = r.FromDate,
                            SafariTo = r.ToDate,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int SafariApplicationNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PrefixID, SafariApplicationNo, ID, db);
            }
        }
        public bool IsDuplicateRecord(int PrefixID, int SafariApplicationNo, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblSafariApplications.FirstOrDefault(i =>
                i.SafariApplicationNo == SafariApplicationNo
                && i.SafariApplicationNoPrefixID == PrefixID
                && i.SafariApplicationID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckDuplicateSafariApplication(int EmployeeID, DateTime DateFrom, DateTime DateTo, int ExcludeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblSafariApplications.Any(r => r.EmployeeID == EmployeeID && r.SafariApplicationID != ExcludeID &&
                    (DateTo >= r.FromDate && DateFrom <= r.ToDate));
            }
        }

        public int GenerateSafariApplicationNo(int PrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (db.tblSafariApplications.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != RecordState_Deleted && r.SafariApplicationNoPrefixID == PrefixID).Max(r => (int?)r.SafariApplicationNo) ?? 0) + 1;
            }
        }
    }
}
