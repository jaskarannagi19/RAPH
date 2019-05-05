using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class LeaveApplicationDAL
    {
        public SavingResult SaveNewRecord(tblLeaveApplication SaveModel, List<LeaveApplicationDayDetail> DayDetail)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLeaveApplication SaveModel;
                if (SaveModel.LeaveApplicationNo == 0)
                {
                    res.ValidationError = "Please enter Leave Application No..";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LeaveApplicationNoPrefixID, SaveModel.LeaveApplicationNo, SaveModel.LeaveApplicationID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Leave Application No. is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LeaveApplicationID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblLeaveApplications.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLeaveApplications.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    db.tblLeaveApplicationDayDetails.RemoveRange(SaveModel.tblLeaveApplicationDayDetails);
                }

                db.tblLeaveApplicationDayDetails.AddRange(DayDetail.Select(r => new tblLeaveApplicationDayDetail()
                {
                    tblLeaveApplication = SaveModel,
                    LeaveDate = r.LeaveDate,
                    LeaveType = (byte)r.LeaveDayOffType,
                }));

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LeaveApplicationID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLeaveApplication FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblLeaveApplications.Find(ID);
                if(r != null)
                {
                    r.tblLeaveApplicationDayDetails = r.tblLeaveApplicationDayDetails;
                }
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LeaveApplicationID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LeaveApplication is selected in company";
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
                    tblLeaveApplication RecordToDelete = db.tblLeaveApplications.FirstOrDefault(r => r.LeaveApplicationID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLeaveApplications.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLeaveApplications.Attach(RecordToDelete);
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
                var rec = db.tblLeaveApplications.FirstOrDefault(r => r.LeaveApplicationID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLeaveApplications.Attach(rec);
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
                var rec = db.tblLeaveApplications.FirstOrDefault(r => r.LeaveApplicationID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLeaveApplications.Attach(rec);
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

        public List<LeaveApplicationEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveApplications
                        join jp in db.tblLeaveApplicationNoPrefixes on r.LeaveApplicationNoPrefixID equals jp.LeaveApplicationNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()
                        join jlt in db.tblLeaveTypes on r.LeaveTypeID equals jlt.LeaveTypeID into glt
                        from lt in glt.DefaultIfEmpty()
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

                        orderby (e != null ? e.EmployeeNo : 0), r.FromDate, r.LeaveApplicationNo
                        
                        select new LeaveApplicationEditListModel()
                        {
                            LeaveApplicationID = r.LeaveApplicationID,
                            LeaveApplicationNoPrefixName = (p != null ? p.LeaveApplicationNoPrefixName : null),
                            LeaveApplicationNo = r.LeaveApplicationNo,
                            LeaveApplicateDate = r.LeaveApplicationDate,
                            LeaveFrom = r.FromDate,
                            LeaveTo = r.ToDate,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                            LeaveType = (lt != null ? lt.LeaveTypeName : null),

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

        public List<LeaveApplicationLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveApplications
                        join jp in db.tblLeaveApplicationNoPrefixes on r.LeaveApplicationNoPrefixID equals jp.LeaveApplicationNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()
                        join jlt in db.tblLeaveTypes on r.LeaveTypeID equals jlt.LeaveTypeID into glt
                        from lt in glt.DefaultIfEmpty()
                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()
                        join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                        from ep in gep.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                        orderby r.FromDate descending, r.LeaveApplicationNo descending

                        select new LeaveApplicationLookupListModel()
                        {
                            LeaveApplicationID = r.LeaveApplicationID,
                            LeaveApplicationNoPrefixName = (p != null ? p.LeaveApplicationNoPrefixName : null),
                            LeaveApplicationNo = r.LeaveApplicationNo,
                            LeaveApplicateDate = r.LeaveApplicationDate,
                            LeaveFrom = r.FromDate,
                            LeaveTo = r.ToDate,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                            LeaveType = (lt != null ? lt.LeaveTypeName : null)
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LeaveApplicationNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PrefixID, LeaveApplicationNo, ID, db);
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LeaveApplicationNo, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblLeaveApplications.FirstOrDefault(i =>
                i.LeaveApplicationNo == LeaveApplicationNo
                && i.LeaveApplicationNoPrefixID == PrefixID
                && i.LeaveApplicationID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public bool CheckDuplicateLeaveApplication(int EmployeeID, DateTime DateFrom, DateTime DateTo, int ExcludeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblLeaveApplications.Any(r => r.EmployeeID == EmployeeID && r.LeaveApplicationID != ExcludeID &&
                    (DateTo >= r.FromDate && DateFrom <= r.ToDate));
            }
        }

        public int GenerateLeaveApplicationNo(int PrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (db.tblLeaveApplications.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != RecordState_Deleted &&
                    r.LeaveApplicationNoPrefixID == PrefixID).Max(r => (int?)r.LeaveApplicationNo) ?? 0) + 1;
            }
        }
    }
}
