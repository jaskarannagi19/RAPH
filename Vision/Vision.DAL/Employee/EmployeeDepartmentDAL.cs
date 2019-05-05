using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeDepartmentDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeDepartment SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployeeDepartment SaveModel;

                if (String.IsNullOrWhiteSpace( SaveModel.EmployeeDepartmentName))
                {
                    res.ValidationError = "Can not accept blank value. Please enter Employee Department Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeDepartmentName, SaveModel.EmployeeDepartmentID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Employee Department Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeDepartmentID == 0) // New Entry
                {
                    SaveModel.rstate = (byte)eRecordState.Active;
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblEmployeeDepartments.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeDepartments.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                //--

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeDepartmentID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeDepartment FindSaveModelByPrimeKey(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeDepartments.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(int DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            //using (dbVisionEntities db = new dbVisionEntities())
            //{
            //    bool InState = db.tblCompanies.FirstOrDefault(r => r.EmployeeDepartmentID == DeleteID) != null;
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
                    tblEmployeeDepartment RecordToDelete = db.tblEmployeeDepartments.Find(DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblEmployeeDepartments.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployeeDepartments.Attach(RecordToDelete);
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
                var rec = db.tblEmployeeDepartments.Find(ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployeeDepartments.Attach(rec);
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
                var rec = db.tblEmployeeDepartments.FirstOrDefault(r => r.EmployeeDepartmentID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployeeDepartments.Attach(rec);
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

        public List<EmployeeDepartmentEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from EmployeeDepartment in db.tblEmployeeDepartments

                        join joinrcu in db.tblUsers on EmployeeDepartment.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on EmployeeDepartment.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where EmployeeDepartment.rstate != RecordState_Deleted
                        && EmployeeDepartment.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeDepartment.EmployeeDepartmentName

                        select new EmployeeDepartmentEditListModel()
                        {
                            EmployeeDepartmentID = EmployeeDepartment.EmployeeDepartmentID,
                            EmployeeDepartmentName = EmployeeDepartment.EmployeeDepartmentName,

                            RecordState = (eRecordState)EmployeeDepartment.rstate,
                            CreatedDateTime = EmployeeDepartment.rcdt,
                            EditedDateTime = EmployeeDepartment.redt,
                            CreatedUserID = EmployeeDepartment.rcuid,
                            EditedUserID = EmployeeDepartment.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<EmployeeDepartmentLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from EmployeeDepartment in db.tblEmployeeDepartments

                        where EmployeeDepartment.rstate != RecordState_Deleted
                        && EmployeeDepartment.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeDepartment.EmployeeDepartmentName

                        select new EmployeeDepartmentLookupListModel()
                        {
                            EmployeeDepartmentID = EmployeeDepartment.EmployeeDepartmentID,
                            EmployeeDepartmentName = EmployeeDepartment.EmployeeDepartmentName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string EmployeeDepartmentName, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(EmployeeDepartmentName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string EmployeeDepartmentName, int ID, dbVisionEntities db)
        {
            if (db.tblEmployeeDepartments.Any(i => 
            i.EmployeeDepartmentName == EmployeeDepartmentName 
            && i.EmployeeDepartmentID != ID
            && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID))
            {
                return true;
            }
            return false;
        }
    }
}
