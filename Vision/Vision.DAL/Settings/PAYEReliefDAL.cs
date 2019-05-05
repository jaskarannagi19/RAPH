using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Settings;

namespace Vision.DAL.Settings
{
    public class PAYEReliefDAL
    {
        public SavingResult SaveNewRecord(PAYEReliefeViewModel ViewModel, DateTime WEDate)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            tblPAYERelief SaveModel = null;
            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblPAYERelief SaveModel;
                if (String.IsNullOrWhiteSpace(ViewModel.PAYEReliefName))
                {
                    res.ValidationError = "Can not accept blank value. Please enter PAYE Relief Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(ViewModel.PAYEReliefName, ViewModel.PAYEReliefID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The PAYE Relief Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (ViewModel.PAYEReliefID != 0)
                {
                    SaveModel = db.tblPAYEReliefs.Find(ViewModel.PAYEReliefID);
                }

                tblPAYEReliefRate RateSaveModel = null;
                if (SaveModel == null) // New Entry
                {
                    SaveModel = new tblPAYERelief();
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblPAYEReliefs.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblPAYEReliefs.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                    db.tblPAYEReliefRates.RemoveRange(db.tblPAYEReliefRates.Where(r => r.PAYEReliefID == SaveModel.PAYEReliefID && (WEDate == null || r.WEDate >= WEDate)));
                }

                SaveModel.PAYEReliefName = ViewModel.PAYEReliefName;
                SaveModel.Mandatory = ViewModel.Mandatory == ePAYEReliefeMandatory.Yes;
                SaveModel.PAYEReliefType = (byte)ViewModel.PAYEReliefType;

                RateSaveModel = new tblPAYEReliefRate()
                {
                    WEDate = WEDate,
                    MonthlyLimit = ViewModel.MonthlyLimit,
                    AnnualLimit = ViewModel.AnnualLimit,

                    tblPAYERelief = SaveModel,
                    rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID,
                    rcdt = DateTime.Now,
                };
                db.tblPAYEReliefRates.Add(RateSaveModel);

                //--
                try
                {
                    db.SaveChanges();
                    //ViewModel.PAYEReliefID = SaveModel.PAYEReliefID;
                    res.PrimeKeyValue = SaveModel.PAYEReliefID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblPAYERelief FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblPAYEReliefs.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.PAYEReliefID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "PAYERelief is selected in company";
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
                    tblPAYERelief RecordToDelete = db.tblPAYEReliefs.FirstOrDefault(r => r.PAYEReliefID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblPAYEReliefs.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblPAYEReliefs.Attach(RecordToDelete);
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
                var rec = db.tblPAYEReliefs.FirstOrDefault(r => r.PAYEReliefID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblPAYEReliefs.Attach(rec);
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
                var rec = db.tblPAYEReliefs.FirstOrDefault(r => r.PAYEReliefID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblPAYEReliefs.Attach(rec);
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

        public List<PAYEReliefeViewModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblPAYEReliefs
                        join jPRR in
                        (from rate in db.tblPAYEReliefRates
                         group rate by rate.PAYEReliefID into grate
                         select new
                         {
                             PAYEReliefID = grate.Key,
                             Rate = grate.OrderByDescending(gr => gr.WEDate).FirstOrDefault(),
                         })
                         on r.PAYEReliefID equals jPRR.PAYEReliefID into gPRR
                        from PRR in gPRR.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.PAYEReliefName

                        select new PAYEReliefeViewModel()
                        {
                            PAYEReliefID = r.PAYEReliefID,
                            PAYEReliefName = r.PAYEReliefName,
                            Mandatory = r.Mandatory ? ePAYEReliefeMandatory.Yes : ePAYEReliefeMandatory.No,
                            PAYEReliefType = (ePAYEReliefType)r.PAYEReliefType,
                            WEDate = (PRR != null ? PRR.Rate.WEDate : null),
                            MonthlyLimit = (PRR != null ? PRR.Rate.MonthlyLimit : 0),
                            AnnualLimit = (PRR != null ? PRR.Rate.AnnualLimit : 0),

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

        public PAYEReliefeViewModel GetViewModelByID(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblPAYEReliefs
                        join jPRR in
                        (from rate in db.tblPAYEReliefRates
                         group rate by rate.PAYEReliefID into grate
                         select new
                         {
                             PAYEReliefID = grate.Key,
                             Rate = grate.OrderByDescending(gr => gr.WEDate).FirstOrDefault(),
                         })
                         on r.PAYEReliefID equals jPRR.PAYEReliefID into gPRR
                        from PRR in gPRR.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.PAYEReliefID == ID
                            && r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        select new PAYEReliefeViewModel()
                        {
                            PAYEReliefID = r.PAYEReliefID,
                            PAYEReliefName = r.PAYEReliefName,
                            Mandatory = r.Mandatory ? ePAYEReliefeMandatory.Yes : ePAYEReliefeMandatory.No,
                            PAYEReliefType = (ePAYEReliefType)r.PAYEReliefType,
                            WEDate = (PRR != null ? PRR.Rate.WEDate : null),
                            MonthlyLimit = (PRR != null ? PRR.Rate.MonthlyLimit : 0),
                            AnnualLimit = (PRR != null ? PRR.Rate.AnnualLimit : 0),

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).FirstOrDefault();
            }
        }


        public List<PAYEReliefLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblPAYEReliefs

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.PAYEReliefName

                        select new PAYEReliefLookupListModel()
                        {
                            PAYEReliefID = r.PAYEReliefID,
                            PAYEReliefName = r.PAYEReliefName,

                        }).ToList();
            }
        }
        public bool IsDuplicateRecord(string PAYEReliefName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PAYEReliefName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string PAYEReliefName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblPAYEReliefs.FirstOrDefault(i =>
                i.PAYEReliefName == PAYEReliefName
                && i.PAYEReliefID != ID
                && i.rstate != RecordState_Deleted
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID) != null)
            {
                return true;
            }
            return false;
        }
    }
}
