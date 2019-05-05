using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class LeaveDetaiReportDAL
    {
        public List<LeaveDetailReportModel> GetLeaveDetailReport(DateTime DateFrom, DateTime DateTo, int LeaveTypeID, int EmployeeID = 0)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;

                var LeaveType = db.tblLeaveTypes.Find(LeaveTypeID);
                if(LeaveType == null)
                {
                    return null;
                }

                var Employee = db.tblEmployees.Find(EmployeeID);
                if(Employee == null)
                {
                    return null;
                }

                Model.Payroll.eLeaveApplicableTo LeaveApplicableTo = (Model.Payroll.eLeaveApplicableTo)LeaveType.ApplicableTo;

                if (!(LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Both ||
                    (Employee.Gender == (byte)Model.Employee.eGender.Male && LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Male) || 
                    (Employee.Gender == (byte)Model.Employee.eGender.Female && LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Female)))
                {
                    return null;
                }

                if (DateFrom < CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
                {
                    DateFrom = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom;
                }

                var OpeningLeaveTaken = (from leave in db.tblLeaveApplications
                                              where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                leave.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                                leave.rstate != RecordStatus_Deleted &&
                                                leave.FromDate < DateFrom &&
                                                leave.EmployeeID == EmployeeID &&
                                                leave.LeaveTypeID == LeaveTypeID
                                              group leave by leave.FinPeriodID into gleave
                                              select gleave.Sum(gr => gr.NofLeaves)).FirstOrDefault();

                var res = (from leave in db.tblLeaveApplications
                           join jleaveprefix in db.tblLeaveApplicationNoPrefixes on leave.LeaveApplicationNoPrefixID equals jleaveprefix.LeaveApplicationNoPrefixID into gleaveprefix
                           from leaveprefix in gleaveprefix.DefaultIfEmpty()

                           where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                leave.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&   
                                leave.rstate != RecordStatus_Deleted &&
                                leave.FromDate >= DateFrom && leave.FromDate <= DateTo &&
                                leave.EmployeeID == EmployeeID &&
                                leave.LeaveTypeID == LeaveTypeID

                           select new LeaveDetailReportModel()
                           {
                               TransactionType = eLeaveDetailTransactionType.LeaveTaken,
                               TransactionID = leave.LeaveApplicationID,
                               TransactionDate = leave.FromDate,
                               TransactionNoPrefixName = (leaveprefix != null ? leaveprefix.LeaveApplicationNoPrefixName : null),
                               TransactionNo = leave.LeaveApplicationNo,
                               Utilized = leave.NofLeaves,
                           }).ToList();

                decimal OpeningBalanceLeaves = 0;
                DateTime OpeningBalanceDate = DateFrom;
                if(Employee.tblEmployeeServiceDetail != null && Employee.tblEmployeeServiceDetail.EmploymentEffectiveDate > DateFrom)
                {
                    OpeningBalanceDate = Employee.tblEmployeeServiceDetail.EmploymentEffectiveDate;
                }

                if (LeaveType.CanCarryForward && OpeningBalanceDate >= DateFrom && OpeningBalanceDate <= DateTo)
                {
                    OpeningBalanceLeaves = (from r in db.tblEmployeeLeaveOpeningBalances
                                            where r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                               r.LeaveTypeID == LeaveTypeID && r.EmployeeID == EmployeeID
                                            select r.LeaveOpeningBalance).FirstOrDefault();
                }

                var OpeningEncashment = (from leave in db.tblLeaveEncashments
                                         join jleaveprefix in db.tblLeaveEncashmentNoPrefixes on leave.LeaveEncashmentNoPrefixID equals jleaveprefix.LeaveEncashmentNoPrefixID into gleaveprefix
                                         from leaveprefix in gleaveprefix.DefaultIfEmpty()

                                         where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                leave.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                                leave.rstate != RecordStatus_Deleted &&
                                                leave.LeaveEncashmentDate < DateFrom &&
                                                leave.EmployeeID == EmployeeID &&
                                                leave.LeaveTypeID == LeaveTypeID

                                         group leave by leave.FinPeriodID into gleave
                                         select gleave.Sum(gr => gr.NofLeaves)).FirstOrDefault();


                res.AddRange((from leave in db.tblLeaveEncashments
                              join jleaveprefix in db.tblLeaveEncashmentNoPrefixes on leave.LeaveEncashmentNoPrefixID equals jleaveprefix.LeaveEncashmentNoPrefixID into gleaveprefix
                              from leaveprefix in gleaveprefix.DefaultIfEmpty()

                              where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                 leave.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                 leave.rstate != RecordStatus_Deleted &&
                                 leave.LeaveEncashmentDate >= DateFrom && leave.LeaveEncashmentDate <= DateTo &&
                                 leave.EmployeeID == EmployeeID &&
                                 leave.LeaveTypeID == LeaveTypeID

                              select new LeaveDetailReportModel()
                              {
                                  TransactionType = eLeaveDetailTransactionType.LeaveEncashment,
                                  TransactionID = leave.LeaveEncashmentID,
                                  TransactionDate = leave.LeaveEncashmentDate,
                                  TransactionNoPrefixName = (leaveprefix != null ? leaveprefix.LeaveEncashmentNoPrefixName : null),
                                  TransactionNo = leave.LeaveEncashmentNo,
                                  Utilized = leave.NofLeaves,
                              }).ToList());


                var OpeningAdjustment = (from leave in db.tblLeaveAdjustments
                                         join jleaveprefix in db.tblLeaveAdjustmentNoPrefixes on leave.LeaveAdjustmentNoPrefixID equals jleaveprefix.LeaveAdjustmentNoPrefixID into gleaveprefix
                                         from leaveprefix in gleaveprefix.DefaultIfEmpty()

                                         where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                               leave.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                               leave.rstate != RecordStatus_Deleted &&
                                              leave.LeaveAdjustmentDate < DateFrom &&
                                              leave.EmployeeID == EmployeeID &&
                                              leave.LeaveTypeID == LeaveTypeID
                                        group leave by leave.FinPeriodID into gleave
                                        select gleave.Sum(r=> r.NofLeaves)).FirstOrDefault();

                res.AddRange((from leave in db.tblLeaveAdjustments
                              join jleaveprefix in db.tblLeaveAdjustmentNoPrefixes on leave.LeaveAdjustmentNoPrefixID equals jleaveprefix.LeaveAdjustmentNoPrefixID into gleaveprefix
                              from leaveprefix in gleaveprefix.DefaultIfEmpty()

                              where leave.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                    leave.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                    leave.rstate != RecordStatus_Deleted &&
                                   leave.LeaveAdjustmentDate >= DateFrom && leave.LeaveAdjustmentDate <= DateTo &&
                                   leave.EmployeeID == EmployeeID &&
                                   leave.LeaveTypeID == LeaveTypeID

                              select new LeaveDetailReportModel()
                              {
                                  TransactionType = eLeaveDetailTransactionType.LeaveAdjustment,
                                  TransactionID = leave.LeaveAdjustmentID,
                                  TransactionDate = leave.LeaveAdjustmentDate,
                                  TransactionNoPrefixName = (leaveprefix != null ? leaveprefix.LeaveAdjustmentNoPrefixName : null),
                                  TransactionNo = leave.LeaveAdjustmentNo,
                                  Earned = leave.NofLeaves,
                              }).ToList());

                decimal OpeningAccured = 0;
                //int DateFrom_YearMonth = Model.CommonFunctions.ParseInt(DateFrom.Year.ToString("0000") + DateFrom.Month.ToString("00"));
                if (((Model.Payroll.eLeaveTypeDistribute)LeaveType.Distribute) == Model.Payroll.eLeaveTypeDistribute.Monthly)
                {
                    if (CommonProperties.LoginInfo.SoftwareSettings.Employee_CurrentMonthLeaveAccumulateOn == Model.Settings.eEmployee_LeaveAccumulateOn.MonthBeginning)
                    {
                        DateTime StartDate = (Employee.tblEmployeeServiceDetail != null && Employee.tblEmployeeServiceDetail.EmploymentEffectiveDate > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom ? Employee.tblEmployeeServiceDetail.EmploymentEffectiveDate : CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom);

                        for (var date = StartDate; date < DateTo; date = date.AddMonths(1))
                        {
                            //if (Model.CommonFunctions.ParseDecimal(date.Year.ToString("0000") + date.Month.ToString("00")) < DateFrom_YearMonth)
                            if(date < DateFrom)
                            {
                                OpeningAccured += Math.Round(LeaveType.AnnualEntitledDays / 12M, 2);
                            }
                            else
                            {
                                res.Add(new LeaveDetailReportModel()
                                {
                                    TransactionType = eLeaveDetailTransactionType.Accure,
                                    TransactionID = 0,
                                    TransactionDate = date,
                                    TransactionNoPrefixName = null,
                                    TransactionNo = 0,
                                    Earned = Math.Round(LeaveType.AnnualEntitledDays / 12M, 2),
                                });
                            }
                        }
                    }
                    else // Month Ending
                    {
                        for (var date = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.AddMonths(1); date < DateTo; date = date.AddMonths(1))
                        {
                            //if (Model.CommonFunctions.ParseDecimal(date.Year.ToString("0000") + date.Month.ToString("00")) < DateFrom_YearMonth)
                            if (date < DateFrom)
                            {
                                OpeningAccured += Math.Round(LeaveType.AnnualEntitledDays / 12M, 2);
                            }
                            else
                            {
                                res.Add(new LeaveDetailReportModel()
                                {
                                    TransactionType = eLeaveDetailTransactionType.Accure,
                                    TransactionID = 0,
                                    TransactionDate = date,
                                    TransactionNoPrefixName = null,
                                    TransactionNo = 0,
                                    Earned = Math.Round(LeaveType.AnnualEntitledDays / 12M, 2),
                                });
                            }
                        }
                    }
                }
                else
                {
                    res.Add(new LeaveDetailReportModel()
                    {
                        TransactionType = eLeaveDetailTransactionType.Accure,
                        TransactionID = 0,
                        TransactionDate = DateFrom,
                        TransactionNoPrefixName = null,
                        TransactionNo = 0,
                        Earned = LeaveType.AnnualEntitledDays,
                    });
                }

                decimal OpeningBalance = OpeningBalanceLeaves + OpeningAccured + OpeningAdjustment - OpeningLeaveTaken - OpeningEncashment;

                if(OpeningBalance != 0)
                {
                    res.Add(new LeaveDetailReportModel()
                    {
                        TransactionType = eLeaveDetailTransactionType.OpeningBalance,
                        TransactionID = 0,
                        TransactionDate = OpeningBalanceDate,
                        TransactionNoPrefixName = null,
                        TransactionNo = 0,
                        Earned = OpeningBalance,
                    });
                }

                res = (from r in res
                       orderby r.TransactionDate, r.TransactionType, r.TransactionNo
                       select r).ToList();

                decimal Balance = 0;
                foreach(var r in res)
                {
                    Balance += r.Earned - r.Utilized;
                    r.Balance = Balance;
                }

                return res.ToList();
            }
        }
    }
}
