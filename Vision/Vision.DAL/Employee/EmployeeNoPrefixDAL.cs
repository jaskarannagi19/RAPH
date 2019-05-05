using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeNoPrefixDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeNoPrefix SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployeeNoPrefix SaveModel;

                if (String.IsNullOrWhiteSpace( SaveModel.EmployeeNoPrefixName))
                {
                    res.ValidationError = "Can not accept blank value. Please enter Employee No Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeNoPrefixName, SaveModel.EmployeeNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Employee No Prefix Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeNoPrefixID == 0) // New Entry
                {
                    SaveModel.rstate = (byte)eRecordState.Active;
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblEmployeeNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                //--

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeNoPrefixID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeNoPrefix FindSaveModelByPrimeKey(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeNoPrefixes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(int DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            //using (dbVisionEntities db = new dbVisionEntities())
            //{
            //    bool InState = db.tblCompanies.FirstOrDefault(r => r.EmployeeNoPrefixID == DeleteID) != null;
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
                    tblEmployeeNoPrefix RecordToDelete = db.tblEmployeeNoPrefixes.Find(DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblEmployeeNoPrefixes.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployeeNoPrefixes.Attach(RecordToDelete);
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
                var rec = db.tblEmployeeNoPrefixes.Find(ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployeeNoPrefixes.Attach(rec);
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
                var rec = db.tblEmployeeNoPrefixes.FirstOrDefault(r => r.EmployeeNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployeeNoPrefixes.Attach(rec);
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

        public List<EmployeeNoPrefixEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from EmployeeNoPrefix in db.tblEmployeeNoPrefixes

                        join joinrcu in db.tblUsers on EmployeeNoPrefix.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on EmployeeNoPrefix.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where EmployeeNoPrefix.rstate != RecordState_Deleted
                        && EmployeeNoPrefix.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeNoPrefix.EmployeeNoPrefixName

                        select new EmployeeNoPrefixEditListModel()
                        {
                            EmployeeNoPrefixID = EmployeeNoPrefix.EmployeeNoPrefixID,
                            EmployeeNoPrefixName = EmployeeNoPrefix.EmployeeNoPrefixName,

                            RecordState = (eRecordState)EmployeeNoPrefix.rstate,
                            CreatedDateTime = EmployeeNoPrefix.rcdt,
                            EditedDateTime = EmployeeNoPrefix.redt,
                            CreatedUserID = EmployeeNoPrefix.rcuid,
                            EditedUserID = EmployeeNoPrefix.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<EmployeeNoPrefixLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from EmployeeNoPrefix in db.tblEmployeeNoPrefixes

                        where EmployeeNoPrefix.rstate != RecordState_Deleted
                        && EmployeeNoPrefix.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeNoPrefix.EmployeeNoPrefixName

                        select new EmployeeNoPrefixLookupListModel()
                        {
                            EmployeeNoPrefixID = EmployeeNoPrefix.EmployeeNoPrefixID,
                            EmployeeNoPrefixName = EmployeeNoPrefix.EmployeeNoPrefixName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string EmployeeNoPrefixName, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(EmployeeNoPrefixName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string EmployeeNoPrefixName, int ID, dbVisionEntities db)
        {
            if (db.tblEmployeeNoPrefixes.Any(i => 
            i.EmployeeNoPrefixName == EmployeeNoPrefixName 
            && i.EmployeeNoPrefixID != ID
            && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID))
            {
                return true;
            }
            return false;
        }
    }
}
