using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeShiftDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeShift SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployeeShift SaveModel;

                if (String.IsNullOrWhiteSpace( SaveModel.EmployeeShiftName))
                {
                    res.ValidationError = "Can not accept blank value. Please enter Employee Shift Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeShiftName, SaveModel.EmployeeShiftID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Employee Shift Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeShiftID == 0) // New Entry
                {
                    SaveModel.rstate = (byte)eRecordState.Active;
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblEmployeeShifts.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeShifts.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                //--

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeShiftID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeShift FindSaveModelByPrimeKey(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeShifts.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(int DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            //using (dbVisionEntities db = new dbVisionEntities())
            //{
            //    bool InState = db.tblCompanies.FirstOrDefault(r => r.EmployeeShiftID == DeleteID) != null;
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
                    tblEmployeeShift RecordToDelete = db.tblEmployeeShifts.Find(DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblEmployeeShifts.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployeeShifts.Attach(RecordToDelete);
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
                var rec = db.tblEmployeeShifts.Find(ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployeeShifts.Attach(rec);
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
                var rec = db.tblEmployeeShifts.FirstOrDefault(r => r.EmployeeShiftID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployeeShifts.Attach(rec);
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

        public List<EmployeeShiftEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from EmployeeShift in db.tblEmployeeShifts

                        join joinrcu in db.tblUsers on EmployeeShift.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on EmployeeShift.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where EmployeeShift.rstate != RecordState_Deleted
                        && EmployeeShift.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeShift.EmployeeShiftName

                        select new EmployeeShiftEditListModel()
                        {
                            EmployeeShiftID = EmployeeShift.EmployeeShiftID,
                            EmployeeShiftName = EmployeeShift.EmployeeShiftName,

                            ShiftStart = EmployeeShift.ShiftStartTime,
                            ShiftEnd = EmployeeShift.ShiftEndTime,

                            RecordState = (eRecordState)EmployeeShift.rstate,
                            CreatedDateTime = EmployeeShift.rcdt,
                            EditedDateTime = EmployeeShift.redt,
                            CreatedUserID = EmployeeShift.rcuid,
                            EditedUserID = EmployeeShift.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<EmployeeShiftLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from EmployeeShift in db.tblEmployeeShifts

                        where EmployeeShift.rstate != RecordState_Deleted
                        && EmployeeShift.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeShift.EmployeeShiftName

                        select new EmployeeShiftLookupListModel()
                        {
                            EmployeeShiftID = EmployeeShift.EmployeeShiftID,
                            EmployeeShiftName = EmployeeShift.EmployeeShiftName,
                        }).ToList();
            }
        }

        public List<EmployeeShiftLookupListModel> GetLookupList(eEmployeeShiftType ShiftTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                byte EmployeeShiftType = (byte)ShiftTypeID;

                return (from EmployeeShift in db.tblEmployeeShifts

                        where EmployeeShift.rstate != RecordState_Deleted
                        && EmployeeShift.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        && EmployeeShift.ShiftType == EmployeeShiftType
                        && EmployeeShift.rstate != RecordState_Deleted

                        orderby EmployeeShift.EmployeeShiftName

                        select new EmployeeShiftLookupListModel()
                        {
                            EmployeeShiftID = EmployeeShift.EmployeeShiftID,
                            EmployeeShiftName = EmployeeShift.EmployeeShiftName,
                            ShiftStart = EmployeeShift.ShiftStartTime,
                            ShiftEnd = EmployeeShift.ShiftEndTime,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string EmployeeShiftName, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(EmployeeShiftName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string EmployeeShiftName, int ID, dbVisionEntities db)
        {
            if (db.tblEmployeeShifts.Any(i => 
            i.EmployeeShiftName == EmployeeShiftName 
            && i.EmployeeShiftID != ID
            && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID))
            {
                return true;
            }
            return false;
        }
    }
}
