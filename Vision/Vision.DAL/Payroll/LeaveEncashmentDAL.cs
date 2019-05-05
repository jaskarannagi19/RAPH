using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class LeaveEncashmentDAL
    {
        public SavingResult SaveNewRecord(tblLeaveEncashment SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLeaveEncashment SaveModel;
                if (SaveModel.LeaveEncashmentNo == 0)
                {
                    res.ValidationError = "Please enter Leave Application No..";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LeaveEncashmentNoPrefixID, SaveModel.LeaveEncashmentNo, SaveModel.LeaveEncashmentID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Leave Application No. is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LeaveEncashmentID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblLeaveEncashments.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLeaveEncashments.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LeaveEncashmentID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLeaveEncashment FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblLeaveEncashments.Find(ID);
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LeaveEncashmentID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LeaveEncashment is selected in company";
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
                    tblLeaveEncashment RecordToDelete = db.tblLeaveEncashments.FirstOrDefault(r => r.LeaveEncashmentID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLeaveEncashments.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLeaveEncashments.Attach(RecordToDelete);
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
                var rec = db.tblLeaveEncashments.FirstOrDefault(r => r.LeaveEncashmentID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLeaveEncashments.Attach(rec);
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
                var rec = db.tblLeaveEncashments.FirstOrDefault(r => r.LeaveEncashmentID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLeaveEncashments.Attach(rec);
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

        public List<LeaveEncashmentEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveEncashments
                        join jp in db.tblLeaveEncashmentNoPrefixes on r.LeaveEncashmentNoPrefixID equals jp.LeaveEncashmentNoPrefixID into gp
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

                        orderby (e != null ? e.EmployeeNo : 0), r.LeaveEncashmentDate, r.LeaveEncashmentNo

                        select new LeaveEncashmentEditListModel()
                        {
                            LeaveEncashmentID = r.LeaveEncashmentID,
                            LeaveEncashmentNoPrefixName = (p != null ? p.LeaveEncashmentNoPrefixName : null),
                            LeaveEncashmentNo = r.LeaveEncashmentNo,
                            LeaveApplicateDate = r.LeaveEncashmentDate,

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

        public List<LeaveEncashmentLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveEncashments
                        join jp in db.tblLeaveEncashmentNoPrefixes on r.LeaveEncashmentNoPrefixID equals jp.LeaveEncashmentNoPrefixID into gp
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

                        orderby (e != null ? e.EmployeeNo : 0), r.LeaveEncashmentDate, r.LeaveEncashmentNo

                        select new LeaveEncashmentLookupListModel()
                        {
                            LeaveEncashmentID = r.LeaveEncashmentID,
                            LeaveEncashmentNoPrefixName = (p != null ? p.LeaveEncashmentNoPrefixName : null),
                            LeaveEncashmentNo = r.LeaveEncashmentNo,
                            LeaveApplicateDate = r.LeaveEncashmentDate,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                            LeaveType = (lt != null ? lt.LeaveTypeName : null)
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LeaveEncashmentNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PrefixID, LeaveEncashmentNo, ID, db);
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int LeaveEncashmentNo, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblLeaveEncashments.FirstOrDefault(i =>
                i.LeaveEncashmentNo == LeaveEncashmentNo
                && i.LeaveEncashmentNoPrefixID == PrefixID
                && i.LeaveEncashmentID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public int GenerateLeaveEncashmentNo(int PrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (db.tblLeaveEncashments.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != RecordState_Deleted && r.LeaveEncashmentNoPrefixID == PrefixID).Max(r => (int?)r.LeaveEncashmentNo) ?? 0) + 1;
            }
        }
    }
}
