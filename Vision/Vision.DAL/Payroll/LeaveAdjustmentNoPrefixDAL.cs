using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class LeaveAdjustmentNoPrefixDAL
    {
        public SavingResult SaveNewRecord(tblLeaveAdjustmentNoPrefix SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblLeaveAdjustmentNoPrefix SaveModel;
                if (SaveModel.LeaveAdjustmentNoPrefixName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.LeaveAdjustmentNoPrefixName, SaveModel.LeaveAdjustmentNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Prefix Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.LeaveAdjustmentNoPrefixID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblLeaveAdjustmentNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblLeaveAdjustmentNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.LeaveAdjustmentNoPrefixID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblLeaveAdjustmentNoPrefix FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblLeaveAdjustmentNoPrefixes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.LeaveAdjustmentNoPrefixID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "LeaveAdjustmentNoPrefix is selected in company";
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
                    tblLeaveAdjustmentNoPrefix RecordToDelete = db.tblLeaveAdjustmentNoPrefixes.FirstOrDefault(r => r.LeaveAdjustmentNoPrefixID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblLeaveAdjustmentNoPrefixes.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblLeaveAdjustmentNoPrefixes.Attach(RecordToDelete);
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
                var rec = db.tblLeaveAdjustmentNoPrefixes.FirstOrDefault(r => r.LeaveAdjustmentNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblLeaveAdjustmentNoPrefixes.Attach(rec);
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
                var rec = db.tblLeaveAdjustmentNoPrefixes.FirstOrDefault(r => r.LeaveAdjustmentNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblLeaveAdjustmentNoPrefixes.Attach(rec);
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

        public List<LeaveAdjustmentNoPrefixEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveAdjustmentNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LeaveAdjustmentNoPrefixName

                        select new LeaveAdjustmentNoPrefixEditListModel()
                        {
                            LeaveAdjustmentNoPrefixID = r.LeaveAdjustmentNoPrefixID,
                            LeaveAdjustmentNoPrefixName = r.LeaveAdjustmentNoPrefixName,

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

        public List<LeaveAdjustmentNoPrefixLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblLeaveAdjustmentNoPrefixes

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.LeaveAdjustmentNoPrefixName

                        select new LeaveAdjustmentNoPrefixLookupListModel()
                        {
                            LeaveAdjustmentNoPrefixID = r.LeaveAdjustmentNoPrefixID,
                            LeaveAdjustmentNoPrefixName = r.LeaveAdjustmentNoPrefixName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string LeaveAdjustmentNoPrefixName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(LeaveAdjustmentNoPrefixName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string LeaveAdjustmentNoPrefixName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            return db.tblLeaveAdjustmentNoPrefixes.Any(i => i.LeaveAdjustmentNoPrefixName == LeaveAdjustmentNoPrefixName &&
                i.LeaveAdjustmentNoPrefixID != ID &&
                i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                i.rstate != RecordState_Deleted);
        }
    }
}
