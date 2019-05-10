using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class EarningDeductionDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeEarningDeduction SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployeeEarningDeduction SaveModel;
                if (SaveModel.EmployeeEarningDeductionName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Earning & Deduction Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeEarningDeductionName, SaveModel.EmployeeEarningDeductionID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Earning & Deduction Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeEarningDeductionID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblEmployeeEarningDeductions.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeEarningDeductions.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeEarningDeductionID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeEarningDeduction FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeEarningDeductions.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.EmployeeEarningDeductionID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "EarningDeduction is selected in company";
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
                    tblEmployeeEarningDeduction RecordToDelete = db.tblEmployeeEarningDeductions.FirstOrDefault(r => r.EmployeeEarningDeductionID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblEmployeeEarningDeductions.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployeeEarningDeductions.Attach(RecordToDelete);
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
                var rec = db.tblEmployeeEarningDeductions.FirstOrDefault(r => r.EmployeeEarningDeductionID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployeeEarningDeductions.Attach(rec);
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
                var rec = db.tblEmployeeEarningDeductions.FirstOrDefault(r => r.EmployeeEarningDeductionID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployeeEarningDeductions.Attach(rec);
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

        public List<EarningDeductionEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblEmployeeEarningDeductions

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.EmployeeEarningDeductionName

                        select new EarningDeductionEditListModel()
                        {
                            EmployeeEarningDeductionID = r.EmployeeEarningDeductionID,
                            EmployeeEarningDeductionNo = r.EmployeeEarningDeductionNo,
                            EmployeeEarningDeductionName = r.EmployeeEarningDeductionName,

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

        public List<EarningDeductionLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblEmployeeEarningDeductions

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.EmployeeEarningDeductionName

                        select new EarningDeductionLookupListModel()
                        {
                            EmployeeEarningDeductionID = r.EmployeeEarningDeductionID,
                            EmployeeEarningDeductionNo = r.EmployeeEarningDeductionNo,
                            EmployeeEarningDeductionName = r.EmployeeEarningDeductionName,
                        }).ToList();
            }
        }
        public List<EarningDeductionImportLookupListModel> GetImportLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblEmployeeEarningDeductions

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.EmployeeEarningDeductionName

                        select new EarningDeductionImportLookupListModel()
                        {
                            EmployeeEarningDeductionID = r.EmployeeEarningDeductionID,
                            EmployeeEarningDeductionNo=r.EmployeeEarningDeductionNo,
                            EmployeeEarningDeductionName = r.EmployeeEarningDeductionName,
                            EmployeeEarningDeductionTypeId=(eEarningDeductionType)r.EarningDeductionType
                        }).ToList();

            }
        }


        public bool IsDuplicateRecord(string EmployeeEarningDeductionName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(EmployeeEarningDeductionName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string EmployeeEarningDeductionName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblEmployeeEarningDeductions.FirstOrDefault(i => 
                    i.EmployeeEarningDeductionName == EmployeeEarningDeductionName 
                    && i.EmployeeEarningDeductionID != ID    
                    && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                    && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public bool IsDuplicateNo(int No, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateNo(No, ID, db);
            }
        }
        public bool IsDuplicateNo(int No, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblEmployeeEarningDeductions.FirstOrDefault(i =>
                                i.EmployeeEarningDeductionNo == No
                            && i.EmployeeEarningDeductionID != ID
                            && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                            && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public int GenerateNo(eEarningDeductionType Type)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte EarningDeductionTypeID = (byte)Type;
                return (db.tblEmployeeEarningDeductions.Where(r=> r.EarningDeductionType == EarningDeductionTypeID).Max(r => (int?)r.EmployeeEarningDeductionNo) ?? 0) + 1;
            }
        }
    }
}
