using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class LeaveTypeDAL
    {
        public SavingResult SaveNewRecord(tblLeaveType SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLeaveType SaveModel;
                if (SaveModel.LeaveTypeName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Leave Type Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LeaveTypeName, SaveModel.LeaveTypeID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Leave Type Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LeaveTypeID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblLeaveTypes.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLeaveTypes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LeaveTypeID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLeaveType FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblLeaveTypes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LeaveTypeID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LeaveType is selected in company";
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
                    tblLeaveType RecordToDelete = db.tblLeaveTypes.FirstOrDefault(r => r.LeaveTypeID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLeaveTypes.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLeaveTypes.Attach(RecordToDelete);
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
                var rec = db.tblLeaveTypes.FirstOrDefault(r => r.LeaveTypeID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLeaveTypes.Attach(rec);
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
                var rec = db.tblLeaveTypes.FirstOrDefault(r => r.LeaveTypeID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLeaveTypes.Attach(rec);
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

        public List<LeaveTypeEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveTypes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LeaveTypeName

                        select new LeaveTypeEditListModel()
                        {
                            LeaveTypeID = r.LeaveTypeID,
                            LeaveTypeName = r.LeaveTypeName,

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

        public List<LeaveTypeLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveTypes

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LeaveTypeName

                        select new LeaveTypeLookupListModel()
                        {
                            LeaveTypeID = r.LeaveTypeID,
                            LeaveTypeName = r.LeaveTypeName,
                            ApplicableTo = r.ApplicableTo,
                            Encashable = r.IsEncashable,

                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string LeaveTypeName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(LeaveTypeName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string LeaveTypeName, long ID, dbVisionEntities db)
        {
            if (db.tblLeaveTypes.FirstOrDefault(i => i.LeaveTypeName == LeaveTypeName && i.LeaveTypeID != ID
                        && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID) != null)
            {
                return true;
            }
            return false;
        }

        public decimal GetLeaveBalance(int EmployeeID, int LeaveTypeID, DateTime UptoDate)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {

                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                var LeaveType = db.tblLeaveTypes.Find(LeaveTypeID);
                if (LeaveType == null)
                {
                    return 0;
                }

                var OpBal = db.tblEmployeeLeaveOpeningBalances.Where(r => r.EmployeeID == EmployeeID && r.LeaveTypeID == LeaveTypeID
                    && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID).FirstOrDefault();
                decimal opbalLeaves = 0;
                if (OpBal != null)
                {
                    opbalLeaves = OpBal.LeaveOpeningBalance;
                }

                decimal CurrentLeaves = 0;
                decimal LeavesTaken = 0;
                decimal LeaveEncashed = 0;
                decimal LeaveAdjusted = 0;

                DateTime DateFrom = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom; //new DateTime(UptoDate.Year, UptoDate.Month, 1);
                DateTime DateTo = UptoDate.Date.Add(new TimeSpan(23, 59, 59));

                if ((eLeaveTypeDistribute)LeaveType.Distribute == eLeaveTypeDistribute.Monthly)
                {
                    int NofMonths = Model.CommonFunctions.ParseInt(DateTo.ToString("yyyyMM")) -
                        Model.CommonFunctions.ParseInt(DateFrom.ToString("yyyyMM")) + (CommonProperties.LoginInfo.SoftwareSettings.Employee_CurrentMonthLeaveAccumulateOn == Model.Settings.eEmployee_LeaveAccumulateOn.MonthBeginning ? 1 : 0);

                    CurrentLeaves = (Math.Round(LeaveType.AnnualEntitledDays / 12, 2)) * NofMonths;
                }
                else
                {
                    CurrentLeaves = LeaveType.AnnualEntitledDays;
                }

                // Leave transaction must be gathered for the whole financial period, not for a perticular date.
                // This matter was discussed with Mr. Rao and we both agreed on this. 22-Feb-2019

                var resLeaveTaken = db.tblLeaveApplications.Where(r => r.EmployeeID == EmployeeID
                    && r.LeaveTypeID == LeaveTypeID
                    //&& r.LeaveApplicationDate >= DateFrom && r.LeaveApplicationDate <= DateTo
                    && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                    && r.rstate != RecordState_Deleted);

                LeavesTaken = db.tblLeaveApplications.Where(r => r.EmployeeID == EmployeeID 
                    && r.LeaveTypeID == LeaveTypeID
                    //&& r.LeaveApplicationDate >= DateFrom && r.LeaveApplicationDate <= DateTo
                    && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                    && r.rstate != RecordState_Deleted).Sum(r => (decimal?)r.NofLeaves) ?? 0;

                LeaveEncashed = db.tblLeaveEncashments.Where(r => r.EmployeeID == EmployeeID &&
                    r.LeaveTypeID == LeaveTypeID &&
                    //r.LeaveEncashmentDate >= DateFrom && r.LeaveEncashmentDate <= DateTo &&
                    r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                    r.rstate != RecordState_Deleted).Sum(r => (decimal?)r.NofLeaves) ?? 0;

                LeaveAdjusted = db.tblLeaveAdjustments.Where(r => r.EmployeeID == EmployeeID &&
                    r.LeaveTypeID == LeaveTypeID &&
                    //r.LeaveAdjustmentDate >= DateFrom && r.LeaveAdjustmentDate <= DateTo &&
                    r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                    r.rstate != RecordState_Deleted).Sum(r => (decimal?)r.NofLeaves) ?? 0;

                return opbalLeaves + CurrentLeaves - LeavesTaken - LeaveEncashed + LeaveAdjusted;
            }
        }
    }
}
