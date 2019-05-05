using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class MinimumWageCategoryDAL
    {
        public SavingResult SaveNewRecord(tblMinimumWageCategory SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblMinimumWageCategory SaveModel;
                if (SaveModel.MinimumWageCategoryName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Minimum Wage Category Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.MinimumWageCategoryName, SaveModel.MinimumWageCategoryID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Minimum Wage Category Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.MinimumWageCategoryID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblMinimumWageCategories.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblMinimumWageCategories.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.MinimumWageCategoryID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblMinimumWageCategory FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblMinimumWageCategories.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.MinimumWageCategoryID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "MinimumWageCategory is selected in company";
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
                    tblMinimumWageCategory RecordToDelete = db.tblMinimumWageCategories.FirstOrDefault(r => r.MinimumWageCategoryID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblMinimumWageCategories.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblMinimumWageCategories.Attach(RecordToDelete);
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
                var rec = db.tblMinimumWageCategories.FirstOrDefault(r => r.MinimumWageCategoryID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblMinimumWageCategories.Attach(rec);
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
                var rec = db.tblMinimumWageCategories.FirstOrDefault(r => r.MinimumWageCategoryID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblMinimumWageCategories.Attach(rec);
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

        public List<MinimumWageCategoryEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                int RuleApplyOn_GrossSalaryID = (int)Model.Payroll.eMinimumWageCategory_ApplyTo.GrossPay;
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblMinimumWageCategories

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.MinimumWageCategoryName

                        select new MinimumWageCategoryEditListModel()
                        {
                            MinimumWageCategoryID = r.MinimumWageCategoryID,
                            MinimumWageCategoryName = r.MinimumWageCategoryName,
                            RuleApplyOn = (r.ApplyOn == RuleApplyOn_GrossSalaryID ? "Gross Pay" : "Basic Pay"),

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

        public List<MinimumWageCategoryLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblMinimumWageCategories

                        where r.rstate != RecordState_Deleted && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.MinimumWageCategoryName

                        select new MinimumWageCategoryLookupListModel()
                        {
                            MinimumWageCategoryID = r.MinimumWageCategoryID,
                            MinimumWageCategoryName = r.MinimumWageCategoryName,
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string MinimumWageCategoryName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(MinimumWageCategoryName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string MinimumWageCategoryName, long ID, dbVisionEntities db)
        {
            if (db.tblMinimumWageCategories.FirstOrDefault(i => 
                    i.MinimumWageCategoryName == MinimumWageCategoryName 
                    && i.MinimumWageCategoryID != ID
                    && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID) != null)
            {
                return true;
            }
            return false;
        }

        public tblMinimumWageRate GetLatestRateSaveModel(int MinimumWageCategoryID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from r in db.tblMinimumWageRates
                        join mwc in db.tblMinimumWageCategories on r.MinimumWageCategoryID equals mwc.MinimumWageCategoryID
                        where r.MinimumWageCategoryID == MinimumWageCategoryID
                                    && mwc.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.WEDateFrom descending
                        select r
                        ).FirstOrDefault();
            }
        }

        public List<MinimumWageCategoryRateChangeListModel> GetMinimumWageCategoryRate()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RuleApplyTo_GrossSalary = (byte)Model.Payroll.eMinimumWageCategory_ApplyTo.GrossPay;
                var categories = (from r in db.tblMinimumWageCategories
                                  where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                  orderby r.MinimumWageCategoryName
                                  select new MinimumWageCategoryRateChangeListModel()
                                  {
                                      MinimumWageCategoryID = r.MinimumWageCategoryID,
                                      MinimumWageCategoryName = r.MinimumWageCategoryName,
                                      RuleApplyOn = (r.ApplyOn == RuleApplyTo_GrossSalary ? "Gross Pay" : "Basic Pay"),
                                      RuralRate = 0,
                                      UrbanRate = 0,

                                  }).ToList();

                foreach (var r in categories)
                {
                    var rate = db.tblMinimumWageRates
                        .Where(r1 => r1.MinimumWageCategoryID == r.MinimumWageCategoryID)
                        .OrderByDescending(r1 => r1.WEDateFrom)
                        .FirstOrDefault();

                    if (rate != null)
                    {
                        r.RuralRate = rate.MinimumWageCategoryRuralRate;
                        r.UrbanRate = rate.MinimumWageCategoryUrbanRate;
                    }
                }
                return categories;
            }
        }

        public SavingResult SaveMinimumWageCategoryRate(List<MinimumWageCategoryRateChangeListModel> Rates, DateTime? WEFDate)
        {
            DateTime? PreviousDate = null;
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (WEFDate == null)
                {
                    db.tblMinimumWageRates.RemoveRange(
                        from r in db.tblMinimumWageRates
                        join mc in db.tblMinimumWageCategories on r.MinimumWageCategoryID equals mc.MinimumWageCategoryID
                        where mc.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        select r);
                }
                else
                {

                    PreviousDate = WEFDate.Value.AddDays(-1);

                    foreach (var rate in Rates)
                    {
                        var PreviousRates = db.tblMinimumWageRates.Where(r => 
                            r.MinimumWageCategoryID == rate.MinimumWageCategoryID 
                            && (r.WEDateTo == null || r.WEDateTo >= WEFDate) );

                        foreach (var prate in PreviousRates)
                        {
                            prate.WEDateTo = PreviousDate;
                            db.tblMinimumWageRates.Attach(prate);
                            db.Entry(prate).State = System.Data.Entity.EntityState.Modified;
                        }

                        db.tblMinimumWageRates.RemoveRange(db.tblMinimumWageRates.Where(r =>
                            r.MinimumWageCategoryID == rate.MinimumWageCategoryID
                            && r.WEDateFrom >= WEFDate));
                    }
                }
                db.tblMinimumWageRates.AddRange(Rates.Where(r => r.RuralRate != 0 || r.UrbanRate != 0).Select(r =>
                        new tblMinimumWageRate()
                        {
                            MinimumWageCategoryID = r.MinimumWageCategoryID,
                            MinimumWageCategoryRuralRate = r.RuralRate,
                            MinimumWageCategoryUrbanRate = r.UrbanRate,
                            WEDateFrom = WEFDate,
                            rcdt = DateTime.Now,
                            rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                        }));

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch(Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }
    }
}
