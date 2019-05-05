using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class HolidayDAL
    {
        public SavingResult SaveNewRecord(tblHoliday SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblHoliday SaveModel;
                if (SaveModel.HolidayName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Holiday Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.HolidayName, SaveModel.HolidayID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Holiday Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.HolidayID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblHolidays.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblHolidays.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.HolidayID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblHoliday FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblHolidays.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.HolidayID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "Holiday is selected in company";
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
                    tblHoliday RecordToDelete = db.tblHolidays.FirstOrDefault(r => r.HolidayID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblHolidays.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblHolidays.Attach(RecordToDelete);
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
                var rec = db.tblHolidays.FirstOrDefault(r => r.HolidayID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblHolidays.Attach(rec);
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
                var rec = db.tblHolidays.FirstOrDefault(r => r.HolidayID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblHolidays.Attach(rec);
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

        public List<HolidayEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblHolidays

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby r.HolidayName

                        select new HolidayEditListModel()
                        {
                            HolidayID = r.HolidayID,
                            HolidayName = r.HolidayName,
                            Type = ((eHolidayType)r.HolidayType == eHolidayType.PublicHoliday ? "Public" : "Optional"),
                            DateFrom = r.FromDate,
                            DateTo = r.ToDate,

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

        public List<HolidayLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblHolidays

                        where r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.HolidayName

                        select new HolidayLookupListModel()
                        {
                            HolidayID = r.HolidayID,
                            HolidayName = r.HolidayName,
                            Type = ((eHolidayType)r.HolidayType == eHolidayType.PublicHoliday ? "Public" : "Optional"),
                            DateFrom = r.FromDate,
                            DateTo = r.ToDate,
                        }).ToList();
            }
        }

        public List<HolidayLookupListModel> GetLookupList(DateTime DateFrom, DateTime DateTo)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                var list = (from r in db.tblHolidays

                        where (DateTo >= r.FromDate && DateFrom <= r.ToDate) &&
                            r.rstate != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.HolidayName

                        select new HolidayLookupListModel()
                        {
                            HolidayID = r.HolidayID,
                            HolidayName = r.HolidayName,
                            Type = ((eHolidayType)r.HolidayType == eHolidayType.PublicHoliday ? "Public" : "Optional"),
                            DateFrom = r.FromDate,
                            DateTo = r.ToDate,
                        }).ToList();
                //--
                var listSameDateEachYear = (from r in db.tblHolidays

                            where r.RepeatOnSameDate &&
                                r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                            orderby r.HolidayName

                            select new HolidayLookupListModel()
                            {
                                HolidayID = r.HolidayID,
                                HolidayName = r.HolidayName,
                                Type = ((eHolidayType)r.HolidayType == eHolidayType.PublicHoliday ? "Public" : "Optional"),
                                DateFrom = r.FromDate,
                                DateTo = r.ToDate,
                            }).ToList();
                var listSameDateEachYearFiltered = listSameDateEachYear.Where(r => 
                    (DateTo >= new DateTime(DateFrom.Year, r.DateFrom.Month, r.DateFrom.Day) &&
                        DateFrom <= new DateTime(DateTo.Year, r.DateTo.Month, r.DateTo.Day))).ToList();
                //--
                list.AddRange(listSameDateEachYearFiltered);
                return list;
            }
        }

        public bool IsDuplicateRecord(string HolidayName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(HolidayName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string HolidayName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblHolidays.FirstOrDefault(i =>
                i.HolidayName == HolidayName
                && i.HolidayID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }
    }
}
