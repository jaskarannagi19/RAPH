﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class TAApprovalNoPrefixDAL
    {
        public SavingResult SaveNewRecord(tblTAApprovalNoPrefix SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblTAApprovalNoPrefix SaveModel;
                if (SaveModel.TAApprovalNoPrefixName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Prefix Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.TAApprovalNoPrefixName, SaveModel.TAApprovalNoPrefixID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Prefix Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.TAApprovalNoPrefixID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblTAApprovalNoPrefixes.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblTAApprovalNoPrefixes.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.TAApprovalNoPrefixID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblTAApprovalNoPrefix FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblTAApprovalNoPrefixes.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.TAApprovalNoPrefixID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "TAApprovalNoPrefix is selected in company";
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
                    tblTAApprovalNoPrefix RecordToDelete = db.tblTAApprovalNoPrefixes.FirstOrDefault(r => r.TAApprovalNoPrefixID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblTAApprovalNoPrefixes.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblTAApprovalNoPrefixes.Attach(RecordToDelete);
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
                var rec = db.tblTAApprovalNoPrefixes.FirstOrDefault(r => r.TAApprovalNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblTAApprovalNoPrefixes.Attach(rec);
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
                var rec = db.tblTAApprovalNoPrefixes.FirstOrDefault(r => r.TAApprovalNoPrefixID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblTAApprovalNoPrefixes.Attach(rec);
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

        public List<TAApprovalNoPrefixEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblTAApprovalNoPrefixes

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.TAApprovalNoPrefixName

                        select new TAApprovalNoPrefixEditListModel()
                        {
                            TAApprovalNoPrefixID = r.TAApprovalNoPrefixID,
                            TAApprovalNoPrefixName = r.TAApprovalNoPrefixName,

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

        public List<TAApprovalNoPrefixLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblTAApprovalNoPrefixes

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.TAApprovalNoPrefixName

                        select new TAApprovalNoPrefixLookupListModel()
                        {
                            TAApprovalNoPrefixID = r.TAApprovalNoPrefixID,
                            TAApprovalNoPrefixName = r.TAApprovalNoPrefixName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string TAApprovalNoPrefixName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(TAApprovalNoPrefixName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string TAApprovalNoPrefixName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            return db.tblTAApprovalNoPrefixes.Any(i => i.TAApprovalNoPrefixName == TAApprovalNoPrefixName &&
                i.TAApprovalNoPrefixID != ID &&
                i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                i.rstate != RecordState_Deleted);
        }
    }
}