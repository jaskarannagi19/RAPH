using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;
using Vision.Model.Reports.Employee;

namespace Vision.DAL.Reports.Employee
{
    public class EmployeeListReportDAL
    {
        public List<EmployeeListReportModel> GetReportData(int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            DataTable dt = new DataTable();
            List<EmployeeListReportModel> list = new List<EmployeeListReportModel>();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                  
                var res = (from e in db.tblEmployees

                           join ep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals ep.EmployeeNoPrefixID into epx
                           from ep in epx.DefaultIfEmpty()

                           join c in db.tblCities on e.CityID equals c.CityID into ct
                           from c in ct.DefaultIfEmpty()

                           join jnationality in db.tblCountries on e.NationalityID equals jnationality.CountryID into gnationality
                           from nationality in gnationality.DefaultIfEmpty()

                           join b in db.tblBankNames on e.BankNameID equals b.BankNameID into bn
                           from b in bn.DefaultIfEmpty()

                           join br in db.tblBankBranches on e.BankBranchID equals br.BankBranchID into brn
                           from br in brn.DefaultIfEmpty()

                           join bc in db.tblCurrencies on e.BankCurrencyID equals bc.CurrencyID into bcr
                           from bc in bcr.DefaultIfEmpty()

                           join ls in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals ls.EmployeeServiceDetailID into esd
                           from ls in esd.DefaultIfEmpty()

                           join jdep in db.tblEmployeeDepartments on ls.EmployeeDepartmentID equals jdep.EmployeeDepartmentID into gdep
                           from dep in gdep.DefaultIfEmpty()

                           join jdes in db.tblEmployeeDesignations on ls.EmployeeDepartmentID equals jdes.EmployeeDesignationID into gdes
                           from des in gdes.DefaultIfEmpty()

                           join jloc in db.tblLocations on ls.LocationID equals jloc.LocationID into gloc
                           from loc in gloc.DefaultIfEmpty()

                           join jwiba in db.tblEmployeeWIBAClasses on ls.EmployeeWIBAClassID equals jwiba.EmployeeWIBAClassID into gwiba
                           from wiba in gwiba.DefaultIfEmpty()

                           join jmwc in db.tblMinimumWageCategories on ls.MinimumWageCategoryID equals jmwc.MinimumWageCategoryID into gmwc
                           from mwc in gmwc.DefaultIfEmpty()

                           join el in db.tblEmployeeAccountingLedgers on e.EmployeeAccountingLedgerID equals el.EmployeeAccountingLedgerID into els
                           from el in els.DefaultIfEmpty()

                           join jfshift in db.tblEmployeeShifts on ls.EmployeeShiftID equals jfshift.EmployeeShiftID into gfshift
                           from fshift in gfshift.DefaultIfEmpty()

                           join jrshall in (from esall3 in (from esall2 in (from esall1 in db.tblEmployeeShiftAllocations
                                                                            where esall1.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                                                            group esall1 by esall1.EmployeeID into gr
                                                                            select new
                                                                            {
                                                                                EmployeeID = gr.Key,
                                                                                Shift = gr.OrderByDescending(grr => grr.WEDateFrom).FirstOrDefault(),
                                                                            })
                                                            select new
                                                            {
                                                                EmployeeID = esall2.EmployeeID,
                                                                WEDateFrom = (esall2.Shift != null ? esall2.Shift.WEDateFrom : null),
                                                                EmployeeShiftID = (esall2.Shift != null ? (int?)esall2.Shift.EmployeeShiftID : null)
                                                            })
                                            join js in db.tblEmployeeShifts on esall3.EmployeeShiftID equals js.EmployeeShiftID into gs
                                            from s in gs.DefaultIfEmpty()
                                            select new
                                            {
                                                EmployeeID = esall3.EmployeeID,
                                                WEDateFrom = esall3.WEDateFrom,
                                                EmployeeShiftID = esall3.EmployeeShiftID,
                                                EmployeeShiftName = (s != null ? s.EmployeeShiftName : null),
                                                Start = (s != null ? (TimeSpan?)s.ShiftStartTime : null),
                                                End = (s != null ? (TimeSpan?)s.ShiftStartTime : null),
                                            }) on e.EmployeeID equals jrshall.EmployeeID into grsall

                           from rshall in grsall.DefaultIfEmpty()


                           where e.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID && (
                               ls == null || ((DepartmentID == null || ls.EmployeeDepartmentID == DepartmentID.Value) &&
                               (DesignationID == null || ls.EmployeeDesignationID == DesignationID.Value) &&
                               (LocationID == null || ls.LocationID == LocationID.Value)))
                               
                           select new EmployeeListReportModel()
                           {
                               EmployeeID = e.EmployeeID,
                               EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                               EmployeeNo = e.EmployeeNo,
                               TACode = e.TACode,
                               EmployeeFirstName = e.EmployeeFirstName,
                               EmployeeLastName = e.EmployeeLastName,
                               EmployeeImageFileName = e.EmployeeImageFileName,
                               Gender = (eGender)e.Gender,
                               Nationality = (nationality != null ? nationality.CountryName : null),
                               WorkVisaExpiryDate = e.WorkVisaExpiryDate,

                               Address1 = e.Address1,
                               Address2 = e.Address2,
                               Address3 = e.Address3,
                               POBoxNO = e.POBoxNO,
                               City = (c != null ? c.CityName : null),
                               MpesaNo = e.MpesaNo,
                               EmailID = e.EmailID,
                               Multicurrency = e.Multicurrency,

                               IDNo = e.IDNo,
                               NSSFNo = e.NSSFNo,
                               NHIFNo = e.NHIFNo,
                               PINNo = e.PINNo,
                               PFNo = e.PFNo,
                               PaymentMode = (ePaymentMode)e.PaymentMode,
                               PayCycle = (ePaymentCycle)e.PayCycle,

                               BankAcNo = e.BankAcNo,
                               BankName = (b != null ? b.BankName : null),
                               BankBranch = (br != null ? br.BankBranchName : null),
                               BankCurrency = (bc != null ? bc.CurrencyName : null),

                               IncomeType = (e.IncomeType ? eIncomeType.Primary : eIncomeType.Secondary),
                               TAAttendanceType = (eTAAttendanceType)e.TAAttendanceType,
                               TALatenessCharges = (eTALatenessCharges)e.TALatenessCharges,
                               TAEarlyGoing = (eTAEarlyGoing)e.TAEarlyGoing,
                               TAOvertime = (eTAOvertime)e.TAOvertime,
                               TANegativeLeave = (eTANegativeLeave)e.TANegativeLeave,
                               TAWeekendType = (eTAWeekendtype)e.TAWeekendType,
                               TAWeekEndAttendance = (eTAWeekEndAttendance)e.TAWeekEndAttendance,
                               TAMissPunch = (eTAMissPunch)e.TAMissPunch,

                               EmploymentEffectiveDate = (ls != null ? (DateTime?)ls.EmploymentEffectiveDate : null),
                               EmploymentType = (eEmploymentType)(ls != null ? ls.EmploymentType : -1),
                               ContractExpiryDate = (ls != null ? ls.ContractExpiryDate : null),

                               DepartmentName = (dep != null ? dep.EmployeeDepartmentName : null),
                               LocationName = (loc != null ? loc.LocationName : null),
                               EmployeeDesignationName = (des != null ? des.EmployeeDesignationName : null),
                               EmployeeWIBAClassName = (wiba != null ? wiba.EmployeeWIBAClassName : null),
                               MinimumWageCategoryName = (mwc != null ? mwc.MinimumWageCategoryName : null),
                               EmployeeAccountingLedger = (el != null ? el.EmployeeAccountingLedgerName : null),

                               EmployementStatus = (eEmployementStatus)(ls != null ? ls.EmployeementStatus : -1),

                               DailyRate = (ls != null ? ls.DailyRate : 0),
                               BasicSalary = (ls != null ? ls.BasicSalary : 0),
                               HousingAllowance = (ls != null ? ls.HousingAllowance : 0),
                               WeekendAllowance = (ls != null ? ls.WeekendAllowance : 0),
                               EmployeeShiftType = (eEmployeeShiftType)(ls != null ? ls.EmployeeShiftType : -1),

                               EmployeeShiftName = (ls != null ? (eEmployeeShiftType)ls.EmployeeShiftType == eEmployeeShiftType.Fixed
                               ? (fshift != null ? fshift.EmployeeShiftName : null)
                               : (rshall != null ? rshall.EmployeeShiftName : null) : null),

                               ShiftStartTime = (ls != null ? (eEmployeeShiftType)ls.EmployeeShiftType == eEmployeeShiftType.Fixed
                               ? (fshift != null ? (TimeSpan?)fshift.ShiftStartTime : null)
                               : (rshall != null ? (TimeSpan?)rshall.Start : null) : null),

                               ShiftEndTime = (ls != null ? (eEmployeeShiftType)ls.EmployeeShiftType == eEmployeeShiftType.Fixed
                               ? (fshift != null ? (TimeSpan?)fshift.ShiftEndTime : null)
                               : (rshall != null ? (TimeSpan?)rshall.End : null) : null),

                               ShiftAllocationDate = (ls != null ? (eEmployeeShiftType)ls.EmployeeShiftType == eEmployeeShiftType.Fixed
                               ? null : (rshall != null ? rshall.WEDateFrom : null) : null),

                               ReinstatementReason = (ls != null ? ls.ReinstatementReason : null),
                               TerminationDate = (ls != null ? ls.TerminationDate : null),
                               TerminationTypeID = (eTerminationType)(ls != null ? ls.TerminationTypeID : -1),
                               TerminationReason = (ls != null ? ls.TerminationReason : null)
                           }).ToList();


                foreach (var r in res)
                {
                    if (!String.IsNullOrWhiteSpace(r.EmployeeImageFileName) && System.IO.File.Exists(r.EmployeeImageFileName))
                    {
                        using (var img = new Bitmap(r.EmployeeImageFileName))
                        {
                            try
                            {
                                r.EmployeeImage = img.GetThumbnailImage(100, 100, () => false, IntPtr.Zero);
                            }
                            catch (OutOfMemoryException)
                            {

                            }
                        }
                    }
                }
                return res;
            }
        }

        public List<EmployeeListReportFormatLookupListModel> GetFormatLookupModel()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from r in db.tblEmployeeListFormats
                        select new EmployeeListReportFormatLookupListModel()
                        {
                            EmployeeListFormatID = r.EmployeeListFormatID,
                            EmployeeListFormatName = r.EmployeeListFormatName,
                        }).ToList();
            }
        }

        public SavingResult SaveFormat(int FormatID, string FormatName, string GridFormat)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblEmployeeListFormat SaveModel = null;
                if (FormatID > 0)
                {
                    SaveModel = db.tblEmployeeListFormats.Find(FormatID);
                }

                if (SaveModel == null)
                {
                    SaveModel = new tblEmployeeListFormat()
                    {
                        rcdt = DateTime.Now,
                        rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID,
                    };
                    db.tblEmployeeListFormats.Add(SaveModel);
                }
                else
                {
                    SaveModel.redt = DateTime.Now;
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;

                    db.tblEmployeeListFormats.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                SaveModel.EmployeeListFormatName = FormatName;
                SaveModel.GridFromat = GridFormat;

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                    res.PrimeKeyValue = SaveModel.EmployeeListFormatID;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }

        public tblEmployeeListFormat FindFormatByID(int FormatID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblEmployeeListFormats.Find(FormatID);
            }
        }
    }
}
