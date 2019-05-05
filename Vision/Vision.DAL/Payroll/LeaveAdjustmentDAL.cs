using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class LeaveAdjustmentDAL
    {
        public SavingResult SaveNewRecord(tblLeaveAdjustment SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLeaveAdjustment SaveModel;
                if (SaveModel.LeaveAdjustmentNo == 0)
                {
                    res.ValidationError = "Please enter Leave Application No..";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LeaveAdjustmentNoPrefixID, SaveModel.LeaveAdjustmentNo, SaveModel.LeaveAdjustmentID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Leave Application No. is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LeaveAdjustmentID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblLeaveAdjustments.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLeaveAdjustments.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LeaveAdjustmentID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLeaveAdjustment FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblLeaveAdjustments.Find(ID);
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LeaveAdjustmentID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LeaveAdjustment is selected in company";
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
                    tblLeaveAdjustment RecordToDelete = db.tblLeaveAdjustments.FirstOrDefault(r => r.LeaveAdjustmentID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLeaveAdjustments.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLeaveAdjustments.Attach(RecordToDelete);
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
                var rec = db.tblLeaveAdjustments.FirstOrDefault(r => r.LeaveAdjustmentID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLeaveAdjustments.Attach(rec);
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
                var rec = db.tblLeaveAdjustments.FirstOrDefault(r => r.LeaveAdjustmentID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLeaveAdjustments.Attach(rec);
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

        public List<LeaveAdjustmentEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveAdjustments
                        join jp in db.tblLeaveAdjustmentNoPrefixes on r.LeaveAdjustmentNoPrefixID equals jp.LeaveAdjustmentNoPrefixID into gp
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

                        orderby (e != null ? e.EmployeeNo : 0), r.LeaveAdjustmentDate ascending, r.LeaveAdjustmentNo ascending

                        select new LeaveAdjustmentEditListModel()
                        {
                            LeaveAdjustmentID = r.LeaveAdjustmentID,
                            LeaveAdjustmentNoPrefixName = (p != null ? p.LeaveAdjustmentNoPrefixName : null),
                            LeaveAdjustmentNo = r.LeaveAdjustmentNo,
                            LeaveApplicateDate = r.LeaveAdjustmentDate,

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

        public List<LeaveAdjustmentLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveAdjustments
                        join jp in db.tblLeaveAdjustmentNoPrefixes on r.LeaveAdjustmentNoPrefixID equals jp.LeaveAdjustmentNoPrefixID into gp
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

                        orderby (e != null ? e.EmployeeNo : 0), r.LeaveAdjustmentDate ascending, r.LeaveAdjustmentNo ascending

                        select new LeaveAdjustmentLookupListModel()
                        {
                            LeaveAdjustmentID = r.LeaveAdjustmentID,
                            LeaveAdjustmentNoPrefixName = (p != null ? p.LeaveAdjustmentNoPrefixName : null),
                            LeaveAdjustmentNo = r.LeaveAdjustmentNo,
                            LeaveApplicateDate = r.LeaveAdjustmentDate,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                            LeaveType = (lt != null ? lt.LeaveTypeName : null)
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LeaveAdjustmentNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PrefixID, LeaveAdjustmentNo, ID, db);
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LeaveAdjustmentNo, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblLeaveAdjustments.FirstOrDefault(i =>
                i.LeaveAdjustmentNo == LeaveAdjustmentNo
                && i.LeaveAdjustmentNoPrefixID == PrefixID
                && i.LeaveAdjustmentID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public int GenerateLeaveAdjustmentNo(int PrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (db.tblLeaveAdjustments.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != RecordState_Deleted && r.LeaveAdjustmentNoPrefixID == PrefixID).Max(r => (int?)r.LeaveAdjustmentNo) ?? 0) + 1;
            }
        }
    }
}
