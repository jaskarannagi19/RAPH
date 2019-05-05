using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeDAL
    {

        public SavingResult SaveNewRecord(tblEmployee SaveModel,
            EmployeeServiceDetailViewModel ServiceDetail,
            List<EmployeePersonalDocumentViewModel> DoucmentsList,
            List<EmployeeFamilyDetailsViewModel> FamilyDetailsList)
        {
            SavingResult res = new SavingResult();

            //-- Perform Validation
            //res.ExecutionResult = eExecutionResult.ValidationError;
            //res.ValidationError = "Validation error message";
            //return res;
            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblEmployee SaveModel;
                if (SaveModel.EmployeeFirstName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Employee Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.EmployeeFirstName, SaveModel.EmployeeLastName, SaveModel.EmployeeID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Employee Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                if (SaveModel.EmployeeID == 0) // New Entry
                {
                    //SaveModel = new tblEmployee();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblEmployees.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblEmployees.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                    db.tblEmployeeDocuments.RemoveRange(SaveModel.tblEmployeeDocuments);
                    db.tblEmployeeFamilies.RemoveRange(SaveModel.tblEmployeeFamilies);

                    if (ServiceDetail != null)
                    {
                        db.tblEmployeeLeaveOpeningBalances.RemoveRange(SaveModel.tblEmployeeServiceDetail.tblEmployeeLeaveOpeningBalances);

                        SaveModel.EmployeeLastServiceDetailID = null;
                        db.tblEmployeeServiceDetails.RemoveRange(db.tblEmployeeServiceDetails.Where(r => r.EmployeeID == SaveModel.EmployeeID && r.EmploymentEffectiveDate >= ServiceDetail.EmploymentEffectiveDate));
                    }
                }

                //--
                tblEmployeeServiceDetail EmployeeServiceDetail = null;
                if (ServiceDetail != null)
                {
                    if (SaveModel.EmployeeLastServiceDetailID == null) // first employment record
                    {
                        EmployeeServiceDetail = new tblEmployeeServiceDetail()
                        {
                            tblEmployee = SaveModel,
                            EmploymentEffectiveDate = ServiceDetail.EmploymentEffectiveDate,
                            ContractExpiryDate = ServiceDetail.ContractExpiryDate,
                            EmploymentType = ServiceDetail.EmploymentType,

                            EmployeeDesignationID = ServiceDetail.EmployeeDesignationID,
                            EmployeeDepartmentID = ServiceDetail.EmployeeDepartmentID,
                            EmployeeWIBAClassID = ServiceDetail.EmployeeWIBAClassID,
                            LocationID = ServiceDetail.LocationID,
                            MinimumWageCategoryID = ServiceDetail.MinimumWageCategoryID,

                            DailyRate = ServiceDetail.DailyRate,
                            BasicSalary = ServiceDetail.BasicSalary,
                            HousingAllowance = ServiceDetail.HousingAllowance,
                            WeekendAllowance = ServiceDetail.WeekendAllowance,

                            EmployeeShiftType = ServiceDetail.EmployeeShiftTypeID,
                            EmployeeShiftID = ServiceDetail.EmployeeShiftID,
                        };

                        db.tblEmployeeServiceDetails.Add(EmployeeServiceDetail);

                        db.tblEmployeeLeaveOpeningBalances.AddRange(ServiceDetail.EmployeeLeaveOpeningBalance.Select(lopb =>
                        new tblEmployeeLeaveOpeningBalance()
                        {
                            tblEmployee = SaveModel,
                            tblEmployeeServiceDetail = EmployeeServiceDetail,
                            LeaveTypeID = lopb.LeaveTypeID,
                            LeaveOpeningBalance = lopb.OpeningBalance,
                            CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                            FinPeriodID = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                        }));
                    }
                }
                //--

                db.tblEmployeeDocuments.AddRange(DoucmentsList.Select(r => new tblEmployeeDocument()
                {
                    tblEmployee = SaveModel,
                    DocumentName = r.DocumentName,
                    FileName = r.FileName

                }));

                if (FamilyDetailsList != null)
                {
                    db.tblEmployeeFamilies.AddRange(FamilyDetailsList.Select(r => new tblEmployeeFamily()
                    {
                        tblEmployee = SaveModel,
                        Address = r.Address,
                        Beneficiary = r.Beneficiary,
                        City = r.City,
                        Email = r.Email,
                        MobileNo = r.MobileNo,
                        Name = r.Name,
                        POBoxNo = r.POBoxNo,
                        Relationship = r.Relationship

                    }));
                }
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.EmployeeID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                    return res;
                }

                if (EmployeeServiceDetail != null)
                {
                    SaveModel.EmployeeLastServiceDetailID = EmployeeServiceDetail.EmployeeServiceDetailID;
                    try
                    {
                        db.SaveChanges();
                        res.PrimeKeyValue = SaveModel.EmployeeID;
                        res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    }
                    catch (Exception ex)
                    {
                        CommonFunctions.GetFinalError(res, ex);
                        return res;
                    }
                }

                //                // Assign Employee ID in past Attendance data 
                //                if (res.ExecutionResult == eExecutionResult.CommitedSucessfuly)
                //                {
                //                    db.Database.ExecuteSqlCommand($@"
                //Update att SET EmployeeID = e.EmployeeID, CompanyID = e.CompanyID
                //from tblEmployeeAttendance att
                //Inner Join tblEmployee e on e.TACode = att.EmployeeTACode
                //where att.EmployeeID is NULL AND att.EmployeeTACode IS NOT NULL AND e.EmployeeID = {SaveModel.EmployeeID}

                //Update ad Set ad.EmployeeID = a.EmployeeID, ad.CompanyID = a.CompanyID
                //from tblEmployeeAttendanceDetail ad
                //inner join tblEmployeeAttendance a on a.EmployeeAttendanceID = ad.EmployeeAttendanceID
                //where ad.EmployeeID IS NULL AND a.EmployeeID = {SaveModel.EmployeeID}");

                //                }
            }
            return res;
        }

        public SavingResult SaveEmployeeProfileImageFileName(int EmployeeID, string ImageFileName)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var SaveModel = db.tblEmployees.Find(EmployeeID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected record is not found.";
                    return res;
                }

                SaveModel.EmployeeImageFileName = ImageFileName;

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

        public SavingResult Termination(int EmployeeID, eTerminationType Type, DateTime TerminationDate, string Reason)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var SaveModel = db.tblEmployees.Find(EmployeeID);
                if (SaveModel == null)
                {
                    res.ValidationError = "Selected employee not found.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                tblEmployeeServiceDetail ServiceSaveModel = null;
                if (SaveModel.EmployeeLastServiceDetailID != null)
                {
                    ServiceSaveModel = db.tblEmployeeServiceDetails.Find(SaveModel.EmployeeLastServiceDetailID);
                }
                if (ServiceSaveModel == null)
                {
                    res.ValidationError = "No service detail found.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                ServiceSaveModel.EmployeementStatus = (byte)(Type == eTerminationType.Resignation ? eEmployementStatus.Resigned : eEmployementStatus.Terminated);
                ServiceSaveModel.TerminationTypeID = (byte)Type;
                ServiceSaveModel.TerminationDate = TerminationDate;
                ServiceSaveModel.TerminationReason = Reason;
                db.tblEmployeeServiceDetails.Attach(ServiceSaveModel);
                db.Entry(ServiceSaveModel).State = System.Data.Entity.EntityState.Modified;

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

        public SavingResult ReInstate(int EmployeeID, string Reason, EmployeeServiceDetailViewModel ServiceDetail)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var SaveModel = db.tblEmployees.Find(EmployeeID);
                if (SaveModel == null)
                {
                    res.ValidationError = "Selected employee not found.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                tblEmployeeServiceDetail EmployeeServiceDetail = new tblEmployeeServiceDetail()
                {
                    tblEmployee = SaveModel,
                    EmploymentEffectiveDate = ServiceDetail.EmploymentEffectiveDate,
                    ContractExpiryDate = ServiceDetail.ContractExpiryDate,
                    EmploymentType = ServiceDetail.EmploymentType,

                    EmployeeDesignationID = ServiceDetail.EmployeeDesignationID,
                    EmployeeDepartmentID = ServiceDetail.EmployeeDepartmentID,
                    EmployeeWIBAClassID = ServiceDetail.EmployeeWIBAClassID,
                    LocationID = ServiceDetail.LocationID,
                    MinimumWageCategoryID = ServiceDetail.MinimumWageCategoryID,

                    DailyRate = ServiceDetail.DailyRate,
                    BasicSalary = ServiceDetail.BasicSalary,
                    HousingAllowance = ServiceDetail.HousingAllowance,
                    WeekendAllowance = ServiceDetail.WeekendAllowance,

                    EmployeeShiftType = ServiceDetail.EmployeeShiftTypeID,
                    EmployeeShiftID = ServiceDetail.EmployeeShiftID,

                    ReinstatementReason = Reason,
                };

                db.tblEmployeeServiceDetails.Add(EmployeeServiceDetail);

                SaveModel.tblEmployeeServiceDetail = EmployeeServiceDetail;
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

        public tblEmployee FindSaveModelByPrimeKey(long ID)
        {

            using (dbVisionEntities db = new dbVisionEntities())
            {
                var r = db.tblEmployees.Find(ID);
                if (r == null)
                {
                    return null;
                }
                r.tblEmployeeDocuments = r.tblEmployeeDocuments;
                r.tblEmployeeFamilies = r.tblEmployeeFamilies;
                r.tblEmployeeServiceDetail = r.tblEmployeeServiceDetail;

                if (r.tblEmployeeServiceDetail != null)
                {
                    r.tblEmployeeServiceDetail.tblEmployeeLeaveOpeningBalances = r.tblEmployeeServiceDetail.tblEmployeeLeaveOpeningBalances;
                }
                return r;
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //bool InState = db.tblStates.FirstOrDefault(r => r.EmployeeID == DeleteID) != null;

                //if (InState)
                //{
                //    Result.ValidationMessage = "Employee exists in some states";
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
                    tblEmployee RecordToDelete = db.tblEmployees.FirstOrDefault(r => r.EmployeeID == DeleteID);

                    if (RecordToDelete == null)
                    {
                        res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                        res.ExecutionResult = eExecutionResult.ValidationError;
                        return res;
                    }
                    else
                    {
                        //db.tblEmployees.Remove(RecordToDelete);

                        byte RecordState_Deleted = (byte)eRecordState.Deleted;
                        RecordToDelete.rstate = RecordState_Deleted;
                        db.tblEmployees.Attach(RecordToDelete);
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
                var rec = db.tblEmployees.FirstOrDefault(r => r.EmployeeID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblEmployees.Attach(rec);
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
                var rec = db.tblEmployees.FirstOrDefault(r => r.EmployeeID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblEmployees.Attach(rec);
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

        public IEnumerable<EmployeeEditListModel> GetEditList()
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            using (dbVisionEntities db = new dbVisionEntities())
            {
                DateTime TodaysDate = DateTime.Now.Date;
                return (from e in db.tblEmployees

                        join jenp in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jenp.EmployeeNoPrefixID into genp
                        from enp in genp.DefaultIfEmpty()

                        join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                        from sd in gsd.DefaultIfEmpty()

                        join jdep in db.tblEmployeeDepartments on sd.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep
                        from dep in gdep.DefaultIfEmpty()
                        join jdes in db.tblEmployeeDesignations on sd.EmployeeDesignationID equals jdes.EmployeeDesignationID into gdes
                        from des in gdes.DefaultIfEmpty()
                        join jloc in db.tblLocations on sd.LocationID equals jloc.LocationID into gloc
                        from loc in gloc.DefaultIfEmpty()

                        join joinrcu in db.tblUsers on e.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on e.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where e.rstate != RecordState_Deleted
                            && e.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                        orderby e.EmployeeNo

                        select new EmployeeEditListModel()
                        {
                            EmployeeID = e.EmployeeID,
                            EmployeeNoPrefix = (enp != null ? enp.EmployeeNoPrefixName : null),
                            EmployeeNo = e.EmployeeNo,
                            TACode = e.TACode,
                            FirstName = e.EmployeeFirstName,
                            LastName = e.EmployeeLastName,

                            Gender = (eGender)e.Gender,

                            Department = (dep != null ? dep.EmployeeDepartmentName : null),
                            Designation = (des != null ? des.EmployeeDesignationName : null),
                            Location = (loc != null ? loc.LocationName : null),
                            EmployementTypeID = (eEmploymentType)(sd != null ? sd.EmploymentType : 0),
                            EmployementStatusID = (sd != null ? ((eEmployementStatus)sd.EmployeementStatus) == eEmployementStatus.Active && ((eEmploymentType)sd.EmploymentType) == eEmploymentType.Contract && sd.ContractExpiryDate != null && sd.ContractExpiryDate < TodaysDate ? eEmployementStatus.Expired : (eEmployementStatus)sd.EmployeementStatus : eEmployementStatus.Terminated),

                            RecordState = (eRecordState)e.rstate,
                            CreatedDateTime = e.rcdt,
                            EditedDateTime = e.redt,
                            CreatedUserID = e.rcuid,
                            EditedUserID = e.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }


        public List<EmployeeLookupListModel> GetLookupList()
        {
            return GetLookupList(null);
        }

        public List<EmployeeLookupListModel> GetLookupList(byte? ShiftType)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            byte EmployeementStatus_Working = (byte)eEmployementStatus.Active;
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from e in db.tblEmployees

                        join jenp in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jenp.EmployeeNoPrefixID into genp
                        from enp in genp.DefaultIfEmpty()

                        join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                        from sd in gsd.DefaultIfEmpty()

                        join jdep in db.tblEmployeeDepartments on sd.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep
                        from dep in gdep.DefaultIfEmpty()
                        join jdes in db.tblEmployeeDesignations on sd.EmployeeDesignationID equals jdes.EmployeeDesignationID into gdes
                        from des in gdes.DefaultIfEmpty()
                        join jloc in db.tblLocations on sd.LocationID equals jloc.LocationID into gloc
                        from loc in gloc.DefaultIfEmpty()

                        where e.rstate != RecordState_Deleted
                            && e.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                            && (ShiftType == null || (sd != null && sd.EmployeeShiftType == ShiftType))
                            && (sd != null && sd.EmployeementStatus == EmployeementStatus_Working)

                        orderby e.EmployeeNo

                        select new EmployeeLookupListModel()
                        {
                            EmployeeID = e.EmployeeID,
                            EmployeeNoPrefix = (enp != null ? enp.EmployeeNoPrefixName : null),
                            EmployeeNo = e.EmployeeNo,
                            FirstName = e.EmployeeFirstName,
                            LastName = e.EmployeeLastName,
                            Gender = (eGender)e.Gender,
                            Department = (dep != null ? dep.EmployeeDepartmentName : null),
                            Designation = (des != null ? des.EmployeeDesignationName : null),
                            Location = (loc != null ? loc.LocationName : null),
                            EmployementTypeID = (eEmploymentType)(sd != null ? sd.EmploymentType : 0)
                        }).ToList();
            }
        }

        public List<EmployeeLookupListModel> GetLookupList(int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            byte EmployeementStatus_Working = (byte)eEmployementStatus.Active;
            using (dbVisionEntities db = new dbVisionEntities())
            {
                DateTime TodaysDate = DateTime.Now.Date;
                return (from e in db.tblEmployees

                        join jenp in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jenp.EmployeeNoPrefixID into genp
                        from enp in genp.DefaultIfEmpty()

                        join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                        from sd in gsd.DefaultIfEmpty()

                        join jdep in db.tblEmployeeDepartments on sd.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep
                        from dep in gdep.DefaultIfEmpty()
                        join jdes in db.tblEmployeeDesignations on sd.EmployeeDesignationID equals jdes.EmployeeDesignationID into gdes
                        from des in gdes.DefaultIfEmpty()
                        join jloc in db.tblLocations on sd.LocationID equals jloc.LocationID into gloc
                        from loc in gloc.DefaultIfEmpty()

                        where e.rstate != RecordState_Deleted
                            && e.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                            && (sd != null ? ((Model.Employee.eEmployementStatus)sd.EmployeementStatus) == Model.Employee.eEmployementStatus.Active ||
                                ((Model.Employee.eEmploymentType)sd.EmploymentType) != Model.Employee.eEmploymentType.Contract ||
                                sd.ContractExpiryDate == null || sd.ContractExpiryDate >= TodaysDate : true)
                            && (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                (EmployementTypeID == null || (sd != null && sd.EmploymentType == EmployementTypeID)) &&
                                (sd != null && sd.EmployeementStatus == EmployeementStatus_Working)

                        orderby e.EmployeeNo

                        select new EmployeeLookupListModel()
                        {
                            EmployeeID = e.EmployeeID,
                            EmployeeNoPrefix = (enp != null ? enp.EmployeeNoPrefixName : null),
                            EmployeeNo = e.EmployeeNo,
                            FirstName = e.EmployeeFirstName,
                            LastName = e.EmployeeLastName,
                            Gender = (eGender)e.Gender,
                            Department = (dep != null ? dep.EmployeeDepartmentName : null),
                            Designation = (des != null ? des.EmployeeDesignationName : null),
                            Location = (loc != null ? loc.LocationName : null),
                            EmployementTypeID = (eEmploymentType)(sd != null ? sd.EmploymentType : 0)
                        }).ToList();
            }
        }

        public bool IsDuplicateRecord(string FirstName, string LastName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(FirstName, LastName, ID, db);
            }
        }
        public bool IsDuplicateRecord(string FirstName, string LastName, long ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;
            if (db.tblEmployees.FirstOrDefault(i => i.EmployeeFirstName == FirstName
                        && i.EmployeeLastName == LastName
                        && i.EmployeeID != ID
                        && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }

        public int GenerateNewTACode()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                /// Generate TA Code universally, regardless of company and deleted record checking,
                return (db.tblEmployees.Max(r => (int?)r.TACode) ?? 0) + 1;
            }
        }

        public int GenerateNewEmployeeNo(int EmployeeNoPrefixID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                int companyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                return (db.tblEmployees.Where(r => r.CompanyID == companyID
                && r.EmployeeNoPrefixID == EmployeeNoPrefixID
                && r.rstate != RecordState_Deleted).Max(r => (int?)r.EmployeeNo) ?? 0) + 1;
            }
        }

        public bool IsDuplicateEmployeeNo(int No, int PrefixID, int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateEmployeeNo(No, PrefixID, ID, db);
            }
        }
        public bool IsDuplicateEmployeeNo(int No, int PrefixID, int ID, dbVisionEntities db)
        {
            byte RecordState_Deleted = (byte)eRecordState.Deleted;

            if (db.tblEmployees.FirstOrDefault(i => i.EmployeeNo == No && i.EmployeeNoPrefixID == PrefixID
                        && i.EmployeeID != ID
                        && i.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        && i.rstate != RecordState_Deleted) != null)
            {
                return true;
            }
            return false;
        }


        public int GetEmployeeCount()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return db.tblEmployees.Count(r =>
                    r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                    r.rstate != RecordState_Deleted);
            }
        }

        public bool IsDuplicateTACode(int Code, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateTACode(Code, ID, db);
            }
        }
        public bool IsDuplicateTACode(int Code, long ID, dbVisionEntities db)
        {
            // T & A - Code duplicacy checking should be done whith checking company code. 
            // Because Time and attendance machine will save all codes regardless of companies.
            // So T & A code checking will perform regardless of company code.
            // Deleted records not filtered intentionally
            if (db.tblEmployees.FirstOrDefault(i => i.TACode == Code && i.EmployeeID != ID) != null)
            {
                return true;
            }
            return false;
        }

        public List<EmployeeServiceDetailGridViewModel> GetEmployeeServiceDetail(int EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from esd in db.tblEmployeeServiceDetails
                        join jdep in db.tblEmployeeDepartments on esd.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep
                        from dep in gdep
                        join jdes in db.tblEmployeeDesignations on esd.EmployeeDesignationID equals jdes.EmployeeDesignationID into gdes
                        from des in gdes
                        join jloc in db.tblLocations on esd.LocationID equals jloc.LocationID into gloc
                        from loc in gloc
                        join jwcn in db.tblEmployeeWIBAClasses on esd.EmployeeWIBAClassID equals jwcn.EmployeeWIBAClassID into gwcn
                        from wcn in gwcn
                        join jmwc in db.tblMinimumWageCategories on esd.MinimumWageCategoryID equals jmwc.MinimumWageCategoryID into gmwc
                        from mwc in gmwc

                        where esd.EmployeeID == EmployeeID
                        orderby esd.EmploymentEffectiveDate descending
                        select new EmployeeServiceDetailGridViewModel()
                        {
                            EmployeeServiceDetailID = esd.EmployeeServiceDetailID,
                            EmploymentTypeID = (eEmploymentType)esd.EmploymentType,
                            EmploymentEffectiveDate = esd.EmploymentEffectiveDate,
                            ContractExpiryDate = esd.ContractExpiryDate,
                            BasicSalary = esd.BasicSalary,
                            DailyRate = esd.DailyRate,
                            WeekendAllowance = esd.WeekendAllowance,
                            HousingAllowance = esd.HousingAllowance,

                            EmployeeDepartmentName = (dep != null ? dep.EmployeeDepartmentName : ""),
                            EmployeeDesignationName = (des != null ? des.EmployeeDesignationName : ""),
                            LocationName = (loc != null ? loc.LocationName : ""),
                            EmployeeWIBAClassName = (wcn != null ? wcn.EmployeeWIBAClassName : ""),
                            MinimumWageCategoryName = (mwc != null ? mwc.MinimumWageCategoryName : ""),

                        }).ToList();
            }
        }

        public List<EmployeeLeaveOpeningBalanceViewModel> GetEmployeeLeaveOpeningBalance(int EmployeeID)
        {
            using (dbVisionEntities db = new DAL.dbVisionEntities())
            {
                return (from l in db.tblLeaveTypes
                        join jopb in db.tblEmployeeLeaveOpeningBalances on
                        new { FinPeriodID = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID, EmployeeID = EmployeeID, LeaveTypeID = l.LeaveTypeID }
                        equals
                        new { jopb.FinPeriodID, jopb.EmployeeID, jopb.LeaveTypeID } into gopb
                        from opb in gopb.DefaultIfEmpty()
                        where l.CanCarryForward && l.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        select new EmployeeLeaveOpeningBalanceViewModel()
                        {
                            LeaveTypeID = l.LeaveTypeID,
                            LeaveTypeName = l.LeaveTypeName,
                            EmployeeLeaveOpeningBalanceID = (opb != null ? opb.EmployeeLeaveOpeningBalanceID : 0),
                            OpeningBalance = (opb != null ? opb.LeaveOpeningBalance : 0)
                        }).ToList();

            }
        }

        public SavingResult UpdateTACode(int EmployeeID, int TACode)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var SaveModel = db.tblEmployees.FirstOrDefault(r => r.EmployeeID == EmployeeID);
                if (SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Employee not found.";
                    return res;
                }

                SaveModel.TACode = TACode;
                db.tblEmployees.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

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
            //--
            return res;
        }

        public SavingResult UpdateTimeAttendanceData(int TACode)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                res = new SavingResult();
                string Command = $@"
DECLARE @EmployeeTACode int = {TACode.ToString()};
DECLARE @AttendanceDetailID Int = 0;
DECLARE @LogDateTime DateTime;
DECLARE @LogTime Time;
DECLARE @EmployeeID int = NULL;
DECLARE @CompanyID int = NULL;

while(1=1)
BEGIN
	SET @LogDateTime = NULL;
	Select top 1 
		@LogDateTime = LogTime, 
		@AttendanceDetailID = EmployeeAttendanceDetailID

		from tblEmployeeAttendanceDetail 
		where EmployeeAttendanceDetailID > @AttendanceDetailID 
			AND EmployeeTACode = @EmployeeTACode
			AND EmployeeAttendanceID IS NULL
			AND EmployeeID IS NULL
		Order by EmployeeAttendanceDetailID;

	IF @@ROWCOUNT = 0 
	BEGIN
		BREAK;
	END

	SET @LogTime = Cast(@LogDateTime As time);
	
	-- Validate Employee

	DECLARE @EmployeeLasServiceDetailID int;

	IF @EmployeeID IS NULL
	BEGIN
		SET @EmployeeID = NULL;
		SET @CompanyID = NULL;
		Select Top 1 @EmployeeID = EmployeeID, @CompanyID = CompanyID, @EmployeeLasServiceDetailID = EmployeeLastServiceDetailID 
		from tblEmployee where TACode = @EmployeeTACode;
	END

	IF @EmployeeID IS NULL OR @EmployeeLasServiceDetailID IS NULL
	BEGIN
		Continue;
	END
	
	DECLARE @EmployeeShiftType int = null;
	DECLARE @EmployeeShiftID int = null;

	Select top 1 @EmployeeShiftType = EmployeeShiftType, @EmployeeShiftID = EmployeeShiftID 
	from tblEmployeeServiceDetail 
	where EmployeeServiceDetailID = @EmployeeLasServiceDetailID

	-- Rotating shift
	IF @EmployeeShiftType = 1
	BEGIN
		SET @EmployeeShiftID = NULL;

		Select Top 1 @EmployeeShiftID = EmployeeShiftID
		from tblEmployeeShiftAllocation 
		where EmployeeID = @EmployeeID AND WEDateFrom <= Cast(@LogDateTime as Date) 
		Order by WEDateFrom Desc

		IF @EmployeeShiftID IS NULL
		Begin
			Continue;
		End
	END

	-- If shift was not allocated.
	IF @EmployeeShiftID IS NULL
	BEGIN
		Continue;
	End
	
	-- Last Log
	DECLARE @LastAttendanceDetailID int = NULL;
	DECLARE @LastAttendanceID int = NULL;

	Select Top 1 @LastAttendanceDetailID = EmployeeAttendanceDetailID, @LastAttendanceID = EmployeeAttendanceID 
	from tblEmployeeAttendanceDetail 
	where EmployeeID = @EmployeeID Order by LogTime desc;
	--
	DECLARE @ShiftStartTime Time = NULL;
	Declare @ShiftEndTime Time = NULL;
	
	Select Top 1 @ShiftStartTime = ShiftStartTime, @ShiftEndTime = ShiftEndTime
	from tblEmployeeShift 
	where EmployeeShiftID = @EmployeeShiftID;

	IF @ShiftStartTime IS NULL OR @ShiftEndTime IS NULL
	BEGIN
		Continue
	End
	
	DECLARE @ShiftStartFrom Time = DateAdd(Hour, -2, @ShiftStartTime);
	DECLARE @ShiftStartTo Time = DateAdd(Hour, +3, @ShiftStartTime);
	DECLARE @ShiftEndFrom Time = DateAdd(Hour, -2, @ShiftEndTime);
	DECLARE @ShiftEndTo Time = DateAdd(Hour, +9, @ShiftEndTime);

	DECLARE @LogDateTimeIsInShiftRange bit = 0;
	
	-- Cross Day shift timinigs
	DECLARE @ValidLogTime bit = 1;
	-- If shift is 12 hour long, then it covers the whole clock
	IF @ShiftStartFrom <> @ShiftEndTo BEGIN
		IF @ShiftEndTo < @ShiftStartFrom
		BEGIN
			IF NOT (@LogTime > @ShiftStartFrom OR @LogTime < @ShiftEndTo)
			Begin
				SET @ValidLogTime = 0;
			End
		END
		ELSE BEGIN
			IF NOT (@LogTime > @ShiftStartFrom AND @LogTime < @ShiftEndTo)
			Begin
				SET @ValidLogTime = 0;
			End
		END
	END
	
	-- if Invalid punch detail
	IF @ValidLogTime = 0
	BEGIN
		
		SET @LastAttendanceID = NULL;
		Select top 1 @LastAttendanceID = EmployeeAttendanceID from tblEmployeeAttendance where AttendanceDate = Cast(@LogDateTime as Date);
		IF @LastAttendanceID IS NOT NULL BEGIN
			Update tblEmployeeAttendanceDetail Set
				EmployeeID = @EmployeeID,
				EmployeeAttendanceID = @LastAttendanceID,
				LogTimeType = 0,
				PunchType = Left(Concat([PunchType],' Invalid Time.'),20)
			Where EmployeeAttendanceDetailID = @AttendanceDetailID
		END
		Continue;
	END

	DECLARE @NewAttendance bit = 0;
	
	-- If no existing log then it is new attendance
	IF @LastAttendanceID IS NULL BEGIN
		SET @NewAttendance = 1;
	END

	DECLARE @LastAttendanceDate Date = NULL;
	DECLARE @LastLogInTime Time = NULL;
	DECLARE @LastLogOutTime Time = NULL;
	
	Select Top 1 @LastAttendanceDate = AttendanceDate, @LastLogInTime = InTime, @LastLogOutTime = OutTime from tblEmployeeAttendance where EmployeeAttendanceID = @LastAttendanceID;
	
	-- Check is it new Attendance or not.
	DECLARE @LastLogInDatetime DateTime = cast(@LastAttendanceDate as datetime) + cast(@LastLogInTime as datetime);
	DECLARE @LastLogOutDateTime DateTime = cast(@LastAttendanceDate as datetime) + cast(@LastLogOutTime as datetime);

	IF @LastLogInTime IS NOT NULL
	BEGIN
		IF DATEDIFF(Hour, @LastLogInDatetime, @LogDateTime) > 18 BEGIN
			SET @NewAttendance = 1;
		END
	END
	ELSE IF @LastLogOutTime IS NOT NULL BEGIN
		IF DATEDIFF(Hour, @LastLogOutDateTime, @LogDateTime) > 9 BEGIN
			SET @NewAttendance = 1;
		END
	END
	ELSE BEGIN
		SET @NewAttendance = 1;
	END

	--Check is it 'In Time' or 'Out Time'

    DECLARE @InTime bit = 0;
                --Only check if it is new attendance

    IF @NewAttendance = 1 BEGIN
        -- If Log tiem in not in range of Shift Out Time
        -- Cross day timing Shift

        IF @ShiftEndTo < @ShiftEndFrom BEGIN
            IF NOT(@LogTime >= @ShiftEndFrom OR @LogTime <= @ShiftEndTo) BEGIN
               SET @InTime = 1;
                END
            END

        ELSE Begin

            IF NOT (@LogTime >= @ShiftEndFrom AND @LogTime <= @ShiftEndTo) BEGIN
                SET @InTime = 1;
                END
            End

    END

    DECLARE @AttendanceDate Date = Cast(@LogDateTime as Date);
                --IF Cross Day Shift Timing AND Punched Time after Midnight
               IF @ShiftEndTo < @ShiftStartFrom AND @LogTime < @ShiftStartFrom BEGIN

                   -- Then Attendance will be counted in previous day.

        SET @AttendanceDate = DateAdd(Day, -1, @AttendanceDate);
                END
                --

    IF @NewAttendance = 1 BEGIN

        INSERT INTO[dbo].[tblEmployeeAttendance]([EmployeeID],[AttendanceDate],[InTime],[OutTime], [EmployeeShiftID], [ShiftStartTime], [ShiftEndTime], [CompanyID],[rcdt])

            Values(@EmployeeID, @AttendanceDate,
            Case When @InTime = 1 THEN @LogTime ELSE NULL END,
            Case When @InTime = 0 THEN @LogTime ELSE NULL END,
            @EmployeeShiftID, @ShiftStartTime, @ShiftEndTime,
            @CompanyID, GETDATE());
		
		SET @LastAttendanceID = @@IDENTITY;
	END
    ELSE BEGIN
        IF @LastLogOutDateTime IS NULL OR @LastLogOutDateTime<@LogDateTime BEGIN

            Update tblEmployeeAttendance SET OutTime = @LogTime where EmployeeAttendanceID = @LastAttendanceID;
		END
    END


    Update[tblEmployeeAttendanceDetail] SET
        [EmployeeAttendanceID] = @LastAttendanceID,

        [EmployeeID] = @EmployeeID,

        [LogTimeType] = CASE WHen @InTime = 1 THEN 1 ELSE 2 END,
		[CompanyID] = @CompanyID,
		redt = GetDate()

    Where EmployeeAttendanceDetailID = @AttendanceDetailID;
END
";
                try
                {
                    db.Database.ExecuteSqlCommand(Command);
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }
    }
}
