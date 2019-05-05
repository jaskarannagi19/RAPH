using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeDesignationDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeDesignation SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployeeDesignation SaveModel;
                if (String.IsNullOrWhiteSpace( SaveModel.EmployeeDesignationName))
                {
                    res.ValidationError = "Can not accept blank value. Please enter Employee Designation Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeDesignationName, SaveModel.EmployeeDesignationID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Employee Designation Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeDesignationID == 0) // New Entry
                {
                    SaveModel.rstate = (byte)eRecordState.Active;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblEmployeeDesignations.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeDesignations.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                //--

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeDesignationID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeDesignation FindSaveModelByPrimeKey(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeDesignations.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(int DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            Result.IsValidForDelete = true;
            //using (dbVisionEntities db = new dbVisionEntities())
            //{
            //    bool InState = db.tblCompanies.FirstOrDefault(r => r.EmployeeDesignationID == DeleteID) != null;
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
                    tblEmployeeDesignation RecordToDelete = db.tblEmployeeDesignations.Find(DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;

                        //db.tblEmployeeDesignations.Remove(RecordToDelete);
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployeeDesignations.Attach(RecordToDelete);
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
                var rec = db.tblEmployeeDesignations.Find(ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployeeDesignations.Attach(rec);
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
                var rec = db.tblEmployeeDesignations.FirstOrDefault(r => r.EmployeeDesignationID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployeeDesignations.Attach(rec);
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

        public List<EmployeeDesignationEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from EmployeeDesignation in db.tblEmployeeDesignations

                        join joinrcu in db.tblUsers on EmployeeDesignation.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on EmployeeDesignation.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where EmployeeDesignation.rstate != RecordState_Deleted
                        && EmployeeDesignation.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeDesignation.EmployeeDesignationName

                        select new EmployeeDesignationEditListModel()
                        {
                            EmployeeDesignationID = EmployeeDesignation.EmployeeDesignationID,
                            EmployeeDesignationName = EmployeeDesignation.EmployeeDesignationName,

                            RecordState = (eRecordState)EmployeeDesignation.rstate,
                            CreatedDateTime = EmployeeDesignation.rcdt,
                            EditedDateTime = EmployeeDesignation.redt,
                            CreatedUserID = EmployeeDesignation.rcuid,
                            EditedUserID = EmployeeDesignation.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public List<EmployeeDesignationLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from EmployeeDesignation in db.tblEmployeeDesignations

                        where EmployeeDesignation.rstate != RecordState_Deleted
                        && EmployeeDesignation.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby EmployeeDesignation.EmployeeDesignationName

                        select new EmployeeDesignationLookupListModel()
                        {
                            EmployeeDesignationID = EmployeeDesignation.EmployeeDesignationID,
                            EmployeeDesignationName = EmployeeDesignation.EmployeeDesignationName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string EmployeeDesignationName, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(EmployeeDesignationName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string EmployeeDesignationName, int ID, dbVisionEntities db)
        {
            if (db.tblEmployeeDesignations.Any(i => 
            i.EmployeeDesignationName == EmployeeDesignationName 
            && i.EmployeeDesignationID != ID
            && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID))
            {
                return true;
            }
            return false;
        }
    }
}
