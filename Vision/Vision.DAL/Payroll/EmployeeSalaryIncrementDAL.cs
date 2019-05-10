using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class EmployeeSalaryIncrementDAL
    {
        public SavingResult SaveNewRecord(tblEmployeeSalaryIncrement SaveModel)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (SaveModel.EmployeeSalaryIncrementID == 0)
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblEmployeeSalaryIncrements.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployeeSalaryIncrements.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                var tblService = db.tblEmployeeServiceDetails.Where(p => p.EmployeeID == SaveModel.EmployeeID).FirstOrDefault();
                if (tblService != null)
                {
                    tblService.BasicSalary = SaveModel.NewBasicSalary;
                }

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeSalaryIncrementID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeSalaryIncrement FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeSalaryIncrements.Find(ID);
            }
        }

        public EmployeeSalaryIncrementEditListModel GetEditList(long EmployeeIncrementID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                try
                {
                    var EmpList = (from r in db.tblEmployeeSalaryIncrements
                                   where r.EmployeeSalaryIncrementID == EmployeeIncrementID

                                   && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                   && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                                   select new EmployeeSalaryIncrementEditListModel
                                   {
                                       EmployeeSalaryIncrementID = r.EmployeeSalaryIncrementID,
                                       EmployeeSalaryIncrementNo = r.EmployeeSalaryIncrementNo,
                                       EffectiveMonth = r.EffectiveMonth,
                                       EffectiveYear = r.EffectiveYear,
                                       EmployeeID = r.EmployeeID,
                                       EmployeeName = (db.tblEmployees.Where(x => x.EmployeeID == r.EmployeeID).Select(x => x.EmployeeFirstName + " " + x.EmployeeLastName).FirstOrDefault()),
                                       CurrentBasicSalary = (db.tblEmployeeServiceDetails.Where(x => x.EmployeeID == r.EmployeeID).Select(x => x.BasicSalary).FirstOrDefault()),
                                       IncrementPercentage = r.IncrementPercentage,
                                       IncrementAmount = r.IncrementAmount,
                                       NewBasicSalary = r.NewBasicSalary,
                                       LastIncDate = (db.tblEmployeeSalaryIncrements.Where(x => x.EmployeeID == r.EmployeeID).OrderByDescending(x => x.EmployeeSalaryIncrementID).Select(x => x.EmployeeSalaryIncrementDate).FirstOrDefault()),
                                       EmployeeSalaryIncrementDate = r.EmployeeSalaryIncrementDate,
                                       LastIncAmount = r.LastIncAmount,
                                       Remarks = r.Remarks,
                                       IncrementType = (eEmployeeSalaryIncrementType)r.IncrementType
                                   }).FirstOrDefault();
                    return EmpList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<EmployeeSalaryIncrementEditListModel> GetEmployeeList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                var data = (from r in db.tblEmployeeSalaryIncrements

                            join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                            from e in ge.DefaultIfEmpty()

                            where r.rState != RecordState_Deleted
                            && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                            && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                            orderby r.EmployeeSalaryIncrementNo

                            select new EmployeeSalaryIncrementEditListModel()
                            {
                                EmployeeSalaryIncrementID = r.EmployeeSalaryIncrementID,
                                EmployeeSalaryIncrementNo = r.EmployeeSalaryIncrementNo,
                                EmployeeSalaryIncrementDate = r.EmployeeSalaryIncrementDate,
                                EffectiveMonth = r.EffectiveMonth,
                                EffectiveYear = r.EffectiveYear,
                                EmployeeID = r.EmployeeID,
                                EmployeeNo=e.EmployeeNo,
                                EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),
                                CurrentBasicSalary = r.CurrentBasicSalary,
                                IncrementType = (eEmployeeSalaryIncrementType)r.IncrementType,
                                IncrementPercentage = r.IncrementPercentage,
                                IncrementAmount = r.IncrementAmount,
                                NewBasicSalary = r.NewBasicSalary,
                                Remarks = r.Remarks,
                                LastIncDate = (db.tblEmployeeSalaryIncrements.Where(x => x.EmployeeID == r.EmployeeID).OrderByDescending(x => x.EmployeeSalaryIncrementID).Select(x => x.LastIncDate).FirstOrDefault()),
                                LastIncAmount = r.LastIncAmount
                            }).ToList();
                return data;
            }
        }

        public EmployeeSalaryIncrementEditListModel GetEmployeeDetail(int EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var dataList = (from r in db.tblEmployees

                                join je in db.tblEmployeeServiceDetails on r.EmployeeLastServiceDetailID equals je.EmployeeServiceDetailID into ge
                                from e in ge.DefaultIfEmpty()

                                where r.EmployeeID == EmployeeID
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                                select new EmployeeSalaryIncrementEditListModel()
                                {
                                    EmployeeID = r.EmployeeID,
                                    CurrentBasicSalary = (e != null ? e.BasicSalary : 0),
                                    LastIncAmount = (db.tblEmployeeSalaryIncrements.Where(x => x.EmployeeID == r.EmployeeID).OrderByDescending(x => x.EmployeeSalaryIncrementID).Select(x => x.IncrementAmount).FirstOrDefault()),
                                    LastIncDate = (db.tblEmployeeSalaryIncrements.Where(x => x.EmployeeID == r.EmployeeID).Count() > 0 ? db.tblEmployeeSalaryIncrements.Where(x => x.EmployeeID == r.EmployeeID).OrderByDescending(x => x.EmployeeSalaryIncrementID).Select(x => x.EmployeeSalaryIncrementDate).FirstOrDefault() : (DateTime?)null),
                                }).FirstOrDefault();
                return dataList;
            }
        }

        public SavingResult Authorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblEmployeeSalaryIncrements.FirstOrDefault(r => r.EmployeeSalaryIncrementID == ID);
                rec.rState = (byte)eRecordState.Authorized;
                db.tblEmployeeSalaryIncrements.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;
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
                var rec = db.tblEmployeeSalaryIncrements.FirstOrDefault(r => r.EmployeeSalaryIncrementID == ID);
                rec.rState = (byte)eRecordState.Active;
                db.tblEmployeeSalaryIncrements.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;
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

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
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
                    tblEmployeeSalaryIncrement RecordToDelete = db.tblEmployeeSalaryIncrements.FirstOrDefault(r => r.EmployeeSalaryIncrementID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rState = RecordState_Deleted;
                        db.tblEmployeeSalaryIncrements.Attach(RecordToDelete);
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

        public int AutoGen()
        {
            int auto = 0;
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var Count = db.tblEmployeeSalaryIncrements.OrderByDescending(p => p.EmployeeSalaryIncrementNo).Where(c => c.rState != (byte)eRecordState.Deleted).Count();
                if (Count > 0)
                {
                    auto = Count + 1;
                }
                else
                {
                    auto = 1;
                }
            }
            return auto;
        }

        public bool IsDuplicateRecord(int TransactionNo, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                if (db.tblEmployeeSalaryIncrements.FirstOrDefault(i =>
                    i.EmployeeSalaryIncrementNo == TransactionNo
                    && (ID == 0 || i.EmployeeSalaryIncrementID != ID)
                    && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                    && i.rState != RecordState_Deleted) != null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsDuplicateIncremetnRecord(DateTime IncrementDate, int EmployeeID, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                if (db.tblEmployeeSalaryIncrements.FirstOrDefault(i =>
                    i.EmployeeSalaryIncrementDate.Month == IncrementDate.Month
                    && (ID == 0 || i.EmployeeSalaryIncrementID != ID)
                    && i.EmployeeID == EmployeeID
                    && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                    && i.rState != RecordState_Deleted) != null)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
