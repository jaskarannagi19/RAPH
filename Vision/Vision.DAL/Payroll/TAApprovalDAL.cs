using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class TAApprovalDAL
    {
        public void SaveNewRecord(IEnumerable<TAApprovalImportViewModel> ImportViewModels)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                foreach (var viewModel in ImportViewModels)
                {
                    tblTAApproval SaveModel = new tblTAApproval()
                    {
                        ApprovedDate = viewModel.ApprovedDate.Value,
                        TAApprovalNoPrefixID = viewModel.ApprovalNoPrefixID.Value,
                        TAApprovalNo = viewModel.ApprovalNo.Value,
                        EmployeeID = viewModel.EmployeeID.Value,
                        TAApprovalDate = viewModel.ApprovalDate.Value,
                        ApprovalTypeID = (byte)viewModel.ApprovalTypeID.Value,
                        ApprovedHours = viewModel.ApprovedHours.Value,
                        Remarks = viewModel.Remark,
                    };

                    SavingResult res = SaveNewRecord(SaveModel, db);
                    if (res.ExecutionResult != eExecutionResult.ErrorWhileExecuting && res.ExecutionResult != eExecutionResult.ValidationError)
                    {
                        try
                        {
                            db.SaveChanges();
                            res.PrimeKeyValue = SaveModel.TAApprovalID;
                            viewModel.TAApprovalID = SaveModel.TAApprovalID;
                            res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                        }
                        catch (Exception ex)
                        {
                            CommonFunctions.GetFinalError(res, ex);
                        }
                    }
                    viewModel.SavingResult = res;
                }
            }
        }

        public SavingResult SaveNewRecord(tblTAApproval SaveModel)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {

                SaveNewRecord(SaveModel, db);
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.TAApprovalID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public SavingResult SaveNewRecord(tblTAApproval SaveModel, dbVisionEntities db)
        {
            SavingResult res = new SavingResult();

                //tblTAApproval SaveModel;
                if (SaveModel.TAApprovalNo == 0)
                {
                    res.ValidationError = "Please enter T & A Approval No.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.TAApprovalNoPrefixID, SaveModel.TAApprovalNo, SaveModel.TAApprovalID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The T & A Approval No. is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.TAApprovalID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;
                    db.tblTAApprovals.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblTAApprovals.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

            return res;
        }

        public tblTAApproval FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblTAApprovals.Find(ID);
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool IsValidForDelete = db.tblCompanies.FirstOrDefault(r => r.TAApprovalID == DeleteID) != null;

                //if (IsValidForDelete)
                //{
                //    Result.ValidationMessage = "TAApproval is selected in company";
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
                    tblTAApproval RecordToDelete = db.tblTAApprovals.FirstOrDefault(r => r.TAApprovalID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblTAApprovals.Remove(RecordToDelete);
                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblTAApprovals.Attach(RecordToDelete);
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
                var rec = db.tblTAApprovals.FirstOrDefault(r => r.TAApprovalID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblTAApprovals.Attach(rec);
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
                var rec = db.tblTAApprovals.FirstOrDefault(r => r.TAApprovalID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblTAApprovals.Attach(rec);
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

        public List<TAApprovalEditListModel> GetEditList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblTAApprovals

                        join jp in db.tblTAApprovalNoPrefixes on r.TAApprovalNoPrefixID equals jp.TAApprovalNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()

                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()

                        join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                        from ep in gep.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                        orderby (e != null ? e.EmployeeNo : 0), r.TAApprovalDate, r.TAApprovalNo

                        select new TAApprovalEditListModel()
                        {
                            TAApprovalID = r.TAApprovalID,
                            TAApprovalNoPrefixName = (p != null ? p.TAApprovalNoPrefixName : null),
                            TAApprovalNo = r.TAApprovalNo,
                            TAApprovedDate = r.TAApprovalDate,

                            ApprovalTypeID = (eTAApprovalType)r.ApprovalTypeID,
                            ApprovedDate = r.ApprovedDate,
                            ApprovedHours = r.ApprovedHours,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

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

        public List<TAApprovalLookupListModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblTAApprovals

                        join jp in db.tblTAApprovalNoPrefixes on r.TAApprovalNoPrefixID equals jp.TAApprovalNoPrefixID into gp
                        from p in gp.DefaultIfEmpty()

                        join je in db.tblEmployees on r.EmployeeID equals je.EmployeeID into ge
                        from e in ge.DefaultIfEmpty()

                        join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                        from ep in gep.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                                && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                && r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID

                        orderby (e != null ? e.EmployeeNo : 0), r.ApprovedDate, r.TAApprovalNo

                        select new TAApprovalLookupListModel()
                        {
                            TAApprovalID = r.TAApprovalID,
                            TAApprovalNoPrefixName = (p != null ? p.TAApprovalNoPrefixName : null),
                            TAApprovalNo = r.TAApprovalNo,
                            TAApprovalDate = r.TAApprovalDate,

                            ApprovalTypeID = (eTAApprovalType)r.ApprovalTypeID,
                            ApprovedDate = r.ApprovedDate,
                            ApprovedHours = r.ApprovedHours,

                            EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                            EmployeeNo = (e != null ? e.EmployeeNo : 0),
                            EmployeeName = (e != null ? e.EmployeeFirstName + " " + e.EmployeeLastName : ""),

                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int TAApprovalNo, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(PrefixID, TAApprovalNo, ID, db);
            }
        }

        public bool IsDuplicateRecord(int PrefixID, int TAApprovalNo, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblTAApprovals.FirstOrDefault(i =>
                i.TAApprovalNo == TAApprovalNo
                && i.TAApprovalNoPrefixID == PrefixID
                && i.TAApprovalID != ID
                && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public int GenerateTAApprovalNo(int PrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (db.tblTAApprovals.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != RecordState_Deleted &&
                    r.TAApprovalNoPrefixID == PrefixID).Max(r => (int?)r.TAApprovalNo) ?? 0) + 1;
            }
        }
    }

}
