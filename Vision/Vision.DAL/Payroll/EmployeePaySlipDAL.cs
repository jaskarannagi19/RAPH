using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    //public class PayrollSaveModel
    //{
    //    public int Month { get; set; }

    //    public int Year { get; set; }

    //    public int EmployeeID { get; set; }

    //    #region Earnings
    //    public decimal NormalOvertimeHours { get; set; }

    //    public decimal DoubleOvertimeHours { get; set; }

    //    public decimal AbsentDays { get; set; }

    //    public decimal MissedPunchDays { get; set; }

    //    public decimal NoticePayDay { get; set; }

    //    public decimal LeaveEncashmentDays { get; set; }

    //    public decimal WeekendWorkedDays { get; set; }
    //    #endregion

    //    #region Deduction
    //    public decimal LatenessDays { get; set; }

    //    public decimal LoanInstallmentAmt { get; set; }
    //    #endregion
    //}
    public class EmployeePaySlipDAL
    {
        public List<EmployeePayslip_NoncashBenefitViewModel> GetNonCashBenefitList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte DeletedID = (byte)eRecordState.Deleted;
                return (from r in db.tblNonCashBenefits
                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID && r.rstate != DeletedID
                        select new EmployeePayslip_NoncashBenefitViewModel()
                        {
                            NonCashBenefitID = r.NonCashBenefitID,
                            NonCashBenefitName = r.NonCashBenefitName,
                            CostValue = r.CostValue,
                            KRAValue = ((eNonCashBenefitKRAValueType)r.KRAValueType == eNonCashBenefitKRAValueType.Fixed ? r.KRAValue : 0),
                            KRAValuePercentage = ((eNonCashBenefitType)r.NonCashBenefitType == eNonCashBenefitType.Vehicle ? r.VehicleCostKRAPerc : ((eNonCashBenefitKRAValueType)r.KRAValueType == eNonCashBenefitKRAValueType.Percentage ? r.KRAValue : 0)),
                            NonCashBenefitCostValueType = (eNonCashBenefitCostValueType)r.CostValueType,
                            NonCashBenefitKRAValueType = (eNonCashBenefitKRAValueType)r.KRAValueType,
                            NonCashBenefitType = (eNonCashBenefitType)r.NonCashBenefitType,
                        }).ToList();
            }
        }

        public List<EmployeePayslip_EarningAndDeductionsViewModel> GetEarningsAndDeductions()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte DeletedID = (byte)eRecordState.Deleted;
                return (from r in db.tblEmployeeEarningDeductions
                        where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                        r.rstate != DeletedID
                        select new EmployeePayslip_EarningAndDeductionsViewModel()
                        {
                            EarningAndDeductionID = r.EmployeeEarningDeductionID,
                            EarningAndDeductionName = r.EmployeeEarningDeductionName,
                            Value = 0,
                            RecordType = (Model.Payroll.eEarningDeductionType)r.EarningDeductionType,
                            ValueType = (eEarningDeductionValueType)r.ValueType,
                            Recurring = r.Recurring,
                            Taxable = r.Taxable,
                        }).ToList();
            }
        }

        public decimal CountLeaveEncashmentDays(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblLeaveEncashments.Where(r => r.EmployeeID == EmployeeID && r.LeaveEncashmentDate >= DateFrom && r.LeaveEncashmentDate <= DateTo).Sum(r => (decimal?)r.NofLeaves) ?? 0;
            }
        }

        public decimal GetLoanInstallmentAmt(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                decimal MonthFrom = DateFrom.Year + (DateFrom.Month / 100M);
                // valueTo >= dateTom && valueFrom =< DateTo
                //

                return db.tblLoanApplications.Where(r => r.EmployeeID == EmployeeID &&
                    (r.YearFrom + (r.MonthFrom / 100M)) <= MonthFrom &&
                    (r.YearTo + (r.MonthTo / 100M)) >= MonthFrom).Sum(r => (decimal?)r.InstallmentAmount) ?? 0;
            }
        }

        public SavingResult SavePayroll(int Month, int Year, tblPayrollEmployeeDetail EmployeeDetailSaveModel, List<EmployeePayslip_EarningAndDeductionsViewModel> EarningDeductions, List<EmployeePayslip_NoncashBenefitViewModel> NonCashBenefits, List<EmployeePayslip_PAYEReliefeViewModel> PAYERelief)
        {
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblPayroll SaveModel = db.tblPayrolls.FirstOrDefault(r => r.Month == Month && r.Year == Year);
                if (SaveModel == null)
                {
                    SaveModel = new tblPayroll()
                    {
                        Month = Month,
                        Year = Year,
                    };

                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    SaveModel.FinPeriodID = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                    db.tblPayrolls.Add(SaveModel);
                }
                //else
                //{
                //    SaveModel.redt = DateTime.Now;
                //    SaveModel.reuid = CommonProperties.LoginInfo.LoggedinUser.UserID;

                //    db.tblPayrolls.Attach(SaveModel);
                //    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                //    db.tblPayrollEmployeeDetails.RemoveRange(db.tblPayrollEmployeeDetails.Where(r => r.PayrollID == SaveModel.PayrollID));
                //    db.tblPayrollEmployeeEarningsDeductions.RemoveRange(db.tblPayrollEmployeeEarningsDeductions.Where(r => r.PayrollID == SaveModel.PayrollID));
                //    db.tblPayrollEmployeeNonCashBenefits.RemoveRange(db.tblPayrollEmployeeNonCashBenefits.Where(r => r.PayrollID == SaveModel.PayrollID));
                //}

                if (EmployeeDetailSaveModel.PayrollEmployeeDetailID == 0)
                {
                    EmployeeDetailSaveModel.tblPayroll = SaveModel;
                    db.tblPayrollEmployeeDetails.Add(EmployeeDetailSaveModel);
                }
                else
                {
                    db.tblPayrollEmployeeDetails.Attach(EmployeeDetailSaveModel);
                    db.Entry(EmployeeDetailSaveModel).State = System.Data.Entity.EntityState.Modified;

                    db.tblPayrollEmployeeEarningsDeductions.RemoveRange(db.tblPayrollEmployeeEarningsDeductions.Where(r => r.PayrollEmployeeDetailID == EmployeeDetailSaveModel.PayrollEmployeeDetailID));
                    db.tblPayrollEmployeeNonCashBenefits.RemoveRange(db.tblPayrollEmployeeNonCashBenefits.Where(r => r.PayrollEmployeeDetailID == EmployeeDetailSaveModel.PayrollEmployeeDetailID));
                    db.tblPayrollEmployePAYEReliefs.RemoveRange(db.tblPayrollEmployePAYEReliefs.Where(r => r.PayrollEmployeeDetailID == EmployeeDetailSaveModel.PayrollEmployeeDetailID));
                }

                db.tblPayrollEmployeeEarningsDeductions.AddRange(EarningDeductions.Where(r => r.Value != 0).Select(r => new tblPayrollEmployeeEarningsDeduction()
                {
                    tblPayrollEmployeeDetail = EmployeeDetailSaveModel,
                    EarningsDeductionID = r.EarningAndDeductionID,
                    Value = r.Value,
                    Taxable = r.Taxable,
                    ValueType = (byte)r.ValueType,
                }));

                db.tblPayrollEmployeeNonCashBenefits.AddRange(NonCashBenefits.Where(r => r.Selected).Select(r => new tblPayrollEmployeeNonCashBenefit()
                {
                    tblPayrollEmployeeDetail = EmployeeDetailSaveModel,
                    NonCashBenefitID = r.NonCashBenefitID,
                    CostValue = r.CostValue,
                    KRAPerc = r.KRAValuePercentage,
                    KRAValue = r.KRAValue,
                    KRAValueCalculatedOnAmt = 0,
                    Recurring = r.Recurrning,
                }));


                db.tblPayrollEmployePAYEReliefs.AddRange(PAYERelief.Where(r => r.Selected && r.PAYEReliefAmt != 0).Select(r=> new tblPayrollEmployePAYERelief()
                {
                    PayrollEmployeeDetailID = EmployeeDetailSaveModel.PayrollEmployeeDetailID,
                    PAYEReliefID = r.PAYEReliefID,
                    PAYEReliefAmt = r.PAYEReliefAmt,
                }));

                try
                {
                    db.SaveChanges();
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }

                return res;
            }
        }

        public tblPayrollEmployeeDetail FindPayrollEmployeeDetailByID(int ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblPayrollEmployeeDetails.Find(ID);
            }
        }

        public tblPayrollEmployeeDetail FindPayrollEmployeeDetail(int Month, int Year, int EmployeeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var res = (from r in db.tblPayrollEmployeeDetails
                           join p in db.tblPayrolls on r.PayrollID equals p.PayrollID
                           where p.Month == Month && p.Year == Year && r.EmployeeID == EmployeeID
                           select r).FirstOrDefault();
                if (res == null)
                {
                    return res;
                }

                res.tblPayroll = res.tblPayroll;
                res.tblPayrollEmployeeEarningsDeductions = res.tblPayrollEmployeeEarningsDeductions;
                res.tblPayrollEmployeeNonCashBenefits = res.tblPayrollEmployeeNonCashBenefits;
                res.tblPayrollEmployePAYEReliefs = res.tblPayrollEmployePAYEReliefs;
                return res;
            }
        }

        public bool IsVehicleAssignedToOtherEmployee(int VehicleID, int EmployeeID, int Month, int Year)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from pe in db.tblPayrollEmployeeDetails
                        join p in db.tblPayrolls on pe.PayrollID equals p.PayrollID
                        where pe.Vehicle_NoncashBenefitID == VehicleID &&
                        pe.EmployeeID != EmployeeID &&
                        p.Month == Month &&
                        p.Year == Year
                        select true).Any();
            }
        }

        public List<EmployeePayslip_PAYEReliefeViewModel> GetPAYERelief(DateTime WEDate)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblPAYEReliefs
                        join rate in (from rr in db.tblPAYEReliefRates
                                      where rr.WEDate == null || rr.WEDate < WEDate
                                      group rr by rr.PAYEReliefID into gr
                                      select new
                                      {
                                          PAYEReliefID = gr.Key,
                                          Rate = gr.OrderByDescending(grr => grr.WEDate).FirstOrDefault(),
                                      }) on r.PAYEReliefID equals rate.PAYEReliefID
                        where r.rstate != RecordState_Deleted &&
                            r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        orderby r.PAYEReliefName
                        select new EmployeePayslip_PAYEReliefeViewModel()
                        {
                            PAYEReliefID = r.PAYEReliefID,
                            PAYEReliefName = r.PAYEReliefName,
                            Mandatory = r.Mandatory ? Model.Settings.ePAYEReliefeMandatory.Yes : Model.Settings.ePAYEReliefeMandatory.No,
                            PAYEReliefType = (Model.Settings.ePAYEReliefType)r.PAYEReliefType,
                            Selected = r.Mandatory,
                            MonthlyLimit = (rate != null && rate.Rate != null ? rate.Rate.MonthlyLimit : 0),
                            PAYEReliefAmt = (r.Mandatory ? (rate != null && rate.Rate != null ? rate.Rate.MonthlyLimit : 0) : 0),
                        }).ToList();
            }
        }
    }
}
