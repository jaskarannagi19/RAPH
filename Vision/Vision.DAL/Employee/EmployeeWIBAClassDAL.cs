using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeWIBAClassDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeWIBAClass SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployeeWIBAClass SaveModel;
                if (String.IsNullOrWhiteSpace( SaveModel.EmployeeWIBAClassName))
                {
                    res.ValidationError = "Can not accept blank value. Please enter Employee WIBAClass Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeWIBAClassName, SaveModel.EmployeeWIBAClassID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Employee WIBAClass Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeWIBAClassID == 0) // New Entry
                {
                    SaveModel.rstate = (byte)eRecordState.Active;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblEmployeeWIBAClasses.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeWIBAClasses.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                //--

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeWIBAClassID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeWIBAClass FindSaveModelByPrimeKey(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeWIBAClasses.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(int DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            //using (dbVisionEntities db = new dbVisionEntities())
            //{
            //    bool InState = db.tblCompanies.FirstOrDefault(r => r.EmployeeWIBAClassID == DeleteID) != null;
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
                    tblEmployeeWIBAClass RecordToDelete = db.tblEmployeeWIBAClasses.Find(DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblEmployeeWIBAClasss.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployeeWIBAClasses.Attach(RecordToDelete);
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
                var rec = db.tblEmployeeWIBAClasses.Find(ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployeeWIBAClasses.Attach(rec);
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
                var rec = db.tblEmployeeWIBAClasses.FirstOrDefault(r => r.EmployeeWIBAClassID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployeeWIBAClasses.Attach(rec);
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

        public List<EmployeeWIBAClassEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from EmployeeWIBAClass in db.tblEmployeeWIBAClasses

                        join joinrcu in db.tblUsers on EmployeeWIBAClass.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on EmployeeWIBAClass.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where EmployeeWIBAClass.rstate != RecordState_Deleted
                        && EmployeeWIBAClass.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeWIBAClass.EmployeeWIBAClassName

                        select new EmployeeWIBAClassEditListModel()
                        {
                            EmployeeWIBAClassID = EmployeeWIBAClass.EmployeeWIBAClassID,
                            EmployeeWIBAClassName = EmployeeWIBAClass.EmployeeWIBAClassName,

                            RecordState = (eRecordState)EmployeeWIBAClass.rstate,
                            CreatedDateTime = EmployeeWIBAClass.rcdt,
                            EditedDateTime = EmployeeWIBAClass.redt,
                            CreatedUserID = EmployeeWIBAClass.rcuid,
                            EditedUserID = EmployeeWIBAClass.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<EmployeeWIBAClassLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from EmployeeWIBAClass in db.tblEmployeeWIBAClasses

                        where EmployeeWIBAClass.rstate != RecordState_Deleted
                        && EmployeeWIBAClass.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeWIBAClass.EmployeeWIBAClassName

                        select new EmployeeWIBAClassLookupListModel()
                        {
                            EmployeeWIBAClassID = EmployeeWIBAClass.EmployeeWIBAClassID,
                            EmployeeWIBAClassName = EmployeeWIBAClass.EmployeeWIBAClassName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string EmployeeWIBAClassName, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(EmployeeWIBAClassName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string EmployeeWIBAClassName, int ID, dbVisionEntities db)
        {
            if (db.tblEmployeeWIBAClasses.Any(i => 
            i.EmployeeWIBAClassName == EmployeeWIBAClassName 
            && i.EmployeeWIBAClassID != ID
            && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID))
            {
                return true;
            }
            return false;
        }
    }
}
