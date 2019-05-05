using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Reports.TimeAttendance;

namespace Vision.DAL.Reports.TimeAttendance
{
    public class LeaveBalanceReportDAL
    {
        public List<LeaveBalanceReportModel> GetLeaveBalanceReport(DateTime DateFrom, DateTime DateTo, int LeaveTypeID, int? DepartmentID, int? DesignationID, int? LocationID, int? EmployementTypeID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordStatus_Deleted = (byte)eRecordState.Deleted;
                DateTime TodaysDate = DateTime.Now.Date;

                var LeaveType = db.tblLeaveTypes.Find(LeaveTypeID);
                if (LeaveType == null)
                {
                    return null;
                }
                Model.Payroll.eLeaveApplicableTo LeaveApplicableTo = (Model.Payroll.eLeaveApplicableTo)LeaveType.ApplicableTo;

                var employee = (from e in db.tblEmployees

                                join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                                from sd in gsd.DefaultIfEmpty()

                                where e.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                     e.rstate != RecordStatus_Deleted &&

                                            (sd != null
                                                && ((Model.Employee.eEmployementStatus)sd.EmployeementStatus) == Model.Employee.eEmployementStatus.Active
                                                && (((Model.Employee.eEmploymentType)sd.EmploymentType) != Model.Employee.eEmploymentType.Contract ||
                                                    (sd.ContractExpiryDate == null || sd.ContractExpiryDate >= TodaysDate))) &&

                                     (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                     (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                     (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                    (EmployementTypeID == null ||
                                        (sd != null &&
                                            (sd.EmploymentType == EmployementTypeID ||
                                                (EmployementTypeID == 3 && (sd.EmploymentType == 1 || sd.EmploymentType == 2)))))
                                select new
                                {
                                    Employee = e,
                                    ServiceDetail = sd
                                });

                if (LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Male)
                {
                    int genderid = (byte)Model.Employee.eGender.Male;
                    employee = (from e in employee
                                where e.Employee.Gender == genderid
                                select e);
                }
                else if (LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Female)
                {
                    int genderid = (byte)Model.Employee.eGender.Female;
                    employee = (from e in employee
                                where e.Employee.Gender == genderid
                                select e);
                }

                decimal AnnualEntitledDays = LeaveType.AnnualEntitledDays;
                int MonthFrom = Model.CommonFunctions.ParseInt(DateFrom.ToString("yyyyMM"));
                int MonthTo = Model.CommonFunctions.ParseInt(DateTo.ToString("yyyyMM"));
                int FinPerFromMonth = Model.CommonFunctions.ParseInt(CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom.ToString("yyyyMM"));

                //int NofOpeningMonths = 0;
                //int NofMonths = MonthTo - MonthFrom +
                //        (Model.CommonProperties.LoginInfo.SoftwareSettings.Employee_CurrentMonthLeaveAccumulateOn == Model.Settings.eEmployee_LeaveAccumulateOn.MonthBeginning ? 1 : 0);

                //NofMonths = Math.Max(NofMonths, 1);

                //if (FinPerFromMonth < MonthFrom)
                //{
                //    NofOpeningMonths = MonthFrom - FinPerFromMonth;
                //}

                decimal LeaveAccured = 0;
                if (((Model.Payroll.eLeaveTypeDistribute)LeaveType.Distribute) == Model.Payroll.eLeaveTypeDistribute.Monthly)
                {
                    LeaveAccured = 0;//Math.Round((LeaveType.AnnualEntitledDays / 12) * NofMonths, 2);
                }
                else
                {
                    LeaveAccured = LeaveType.AnnualEntitledDays;
                }

                //decimal OpeningLeaveAccured = 0;
                //if (((Model.Payroll.eLeaveTypeDistribute)LeaveType.Distribute) == Model.Payroll.eLeaveTypeDistribute.Monthly)
                //{
                //    OpeningLeaveAccured = Math.Round((LeaveType.AnnualEntitledDays / 12) * NofOpeningMonths, 2);
                //}

                var OpeningBalance = (from r2 in (from r in db.tblEmployeeLeaveOpeningBalances
                                                  join e in employee on r.EmployeeID equals e.Employee.EmployeeID

                                                  where r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                      r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                                      r.LeaveTypeID == LeaveTypeID
                                                  select new
                                                  {
                                                      EmployeeID = r.EmployeeID,
                                                      OpeningBalance = r.LeaveOpeningBalance,
                                                      OpeningBalanceDate = (e.ServiceDetail.EmploymentEffectiveDate > Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom ? e.ServiceDetail.EmploymentEffectiveDate :
                                                      Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom)
                                                  })
                                      where r2.OpeningBalanceDate <= DateTo
                                      select r2);


                var resOpeningAdjustment = (from r in db.tblLeaveAdjustments
                                            join e in employee on r.EmployeeID equals e.Employee.EmployeeID
                                            where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                  r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                                  r.LeaveAdjustmentDate < DateFrom &&
                                                  r.LeaveTypeID == LeaveTypeID
                                            group r by r.EmployeeID into gr
                                            select new
                                            {
                                                EmployeeID = gr.Key,
                                                OpeningLeaveAdjustment = gr.Sum(grr => grr.NofLeaves),
                                            });

                var resAdjustment = (from r in db.tblLeaveAdjustments
                                     join e in employee on r.EmployeeID equals e.Employee.EmployeeID
                                     where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                           r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                           r.LeaveAdjustmentDate >= DateFrom && r.LeaveAdjustmentDate <= DateTo &&
                                           r.LeaveTypeID == LeaveTypeID
                                     group r by r.EmployeeID into gr
                                     select new
                                     {
                                         EmployeeID = gr.Key,
                                         LeaveAdjustment = gr.Sum(grr => grr.NofLeaves),
                                     });



                var resOpeningLeaveTaken = (from r in db.tblLeaveApplications
                                            join e in employee on r.EmployeeID equals e.Employee.EmployeeID
                                            where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                  r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                                  r.ToDate < DateFrom &&
                                                  r.LeaveTypeID == LeaveTypeID
                                            group r by r.EmployeeID into gr
                                            select new
                                            {
                                                EmployeeID = gr.Key,
                                                LeaveTaken = gr.Sum(grr => grr.NofLeaves),
                                            });

                var resLeaveTaken = (from r in db.tblLeaveApplications
                                     join e in employee on r.EmployeeID equals e.Employee.EmployeeID
                                     where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                           r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                           r.ToDate >= DateFrom && r.FromDate <= DateTo &&
                                           r.LeaveTypeID == LeaveTypeID
                                     group r by r.EmployeeID into gr
                                     select new
                                     {
                                         EmployeeID = gr.Key,
                                         LeaveTaken = gr.Sum(grr => grr.NofLeaves),
                                     });




                var resOpeningLeaveEncashment = (from r in db.tblLeaveEncashments
                                                 join e in employee on r.EmployeeID equals e.Employee.EmployeeID
                                                 where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                       r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                                       r.LeaveEncashmentDate < DateFrom &&
                                                       r.LeaveTypeID == LeaveTypeID
                                                 group r by r.EmployeeID into gr
                                                 select new
                                                 {
                                                     EmployeeID = gr.Key,
                                                     LeaveEncashment = gr.Sum(grr => grr.NofLeaves),
                                                 });

                var resLeaveEncashment = (from r in db.tblLeaveEncashments
                                          join e in employee on r.EmployeeID equals e.Employee.EmployeeID
                                          where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                                r.LeaveEncashmentDate >= DateFrom && r.LeaveEncashmentDate <= DateTo &&
                                                r.LeaveTypeID == LeaveTypeID
                                          group r by r.EmployeeID into gr
                                          select new
                                          {
                                              EmployeeID = gr.Key,
                                              LeaveEncashment = gr.Sum(grr => grr.NofLeaves),
                                          });

                var res = (from e in db.tblEmployees

                           join jsd in db.tblEmployeeServiceDetails on e.EmployeeLastServiceDetailID equals jsd.EmployeeServiceDetailID into gsd
                           from sd in gsd.DefaultIfEmpty()

                           join jep in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jep.EmployeeNoPrefixID into gep
                           from ep in gep.DefaultIfEmpty()

                           join job in OpeningBalance on e.EmployeeID equals job.EmployeeID into gob
                           from ob in gob.DefaultIfEmpty()

                           join joadj in resOpeningAdjustment on e.EmployeeID equals joadj.EmployeeID into goadj
                           from oadj in goadj.DefaultIfEmpty()

                           join jadj in resAdjustment on e.EmployeeID equals jadj.EmployeeID into gadj
                           from adj in gadj.DefaultIfEmpty()

                           join jolt in resOpeningLeaveTaken on e.EmployeeID equals jolt.EmployeeID into golt
                           from olt in golt.DefaultIfEmpty()

                           join jlt in resLeaveTaken on e.EmployeeID equals jlt.EmployeeID into glt
                           from lt in glt.DefaultIfEmpty()

                           join joec in resOpeningLeaveEncashment on e.EmployeeID equals joec.EmployeeID into goec
                           from oec in goec.DefaultIfEmpty()

                           join jec in resLeaveEncashment on e.EmployeeID equals jec.EmployeeID into gec
                           from ec in gec.DefaultIfEmpty()

                           where e.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                e.rstate != RecordStatus_Deleted && e.rstate != RecordStatus_Deleted &&

                                            (sd != null
                                                && ((Model.Employee.eEmployementStatus)sd.EmployeementStatus) == Model.Employee.eEmployementStatus.Active
                                                && (((Model.Employee.eEmploymentType)sd.EmploymentType) != Model.Employee.eEmploymentType.Contract ||
                                                    (sd.ContractExpiryDate == null || sd.ContractExpiryDate >= TodaysDate))) &&

                                (DesignationID == null || (sd != null && sd.EmployeeDesignationID == DesignationID.Value)) &&
                                (DepartmentID == null || (sd != null && sd.EmployeeDepartmentID == DepartmentID.Value)) &&
                                (LocationID == null || (sd != null && sd.LocationID == LocationID)) &&
                                (EmployementTypeID == null || (sd != null && sd.EmploymentType == EmployementTypeID)) &&
                                (LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Both ||
                                    (LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Male && e.Gender == (byte)Model.Employee.eGender.Male) ||
                                    (LeaveApplicableTo == Model.Payroll.eLeaveApplicableTo.Female && e.Gender == (byte)Model.Employee.eGender.Female))

                           orderby e.EmployeeNo

                           select new LeaveBalanceReportModel()
                           {
                               EmployeeID = e.EmployeeID,
                               EmployeeNoPrefix = (ep != null ? ep.EmployeeNoPrefixName : null),
                               EmployeeNo = e.EmployeeNo,
                               EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,
                               EmploymentEffectiveDate = sd.EmploymentEffectiveDate,
                               EmployeeOpeningBalance = (ob != null ? ob.OpeningBalance : 0),
                               //OpeningLeaveAccured = OpeningLeaveAccured,
                               OpeningLeaveAdjustment = (oadj != null ? oadj.OpeningLeaveAdjustment : 0),
                               OpeningLeaveTaken = (olt != null ? olt.LeaveTaken : 0),
                               OpeningLeaveEncashment = (oec != null ? oec.LeaveEncashment : 0),

                               //OpeningBalance = (ob != null ? ob.OpeningBalance : 0) + OpeningLeaveAccured + (oadj != null ? oadj.OpeningLeaveAdjustment : 0) -
                               //                     (olt != null ? olt.LeaveTaken : 0) - (oec != null ? oec.LeaveEncashment : 0),
                               Accured = LeaveAccured,
                               Adjustment = (adj != null ? adj.LeaveAdjustment : 0),
                               LeaveTaken = (lt != null ? lt.LeaveTaken : 0),
                               LeaveEncashment = (ec != null ? ec.LeaveEncashment : 0),
                           }).ToList();

                if (((Model.Payroll.eLeaveTypeDistribute)LeaveType.Distribute) == Model.Payroll.eLeaveTypeDistribute.Monthly)
                {
                    foreach (var r in res)
                    {

                        int EmploymentEffectiveMonth = Model.CommonFunctions.ParseInt(r.EmploymentEffectiveDate.ToString("yyyyMM"));
                        DateTime LeaveAccureFromDate = (r.EmploymentEffectiveDate > CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom ? r.EmploymentEffectiveDate : CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodFrom);

                        int LeaveAccureFromMonth = Model.CommonFunctions.ParseInt(LeaveAccureFromDate.ToString("yyyyMM"));
                        int OpeningAccureMonth = (DateFrom > LeaveAccureFromDate ? MonthFrom - LeaveAccureFromMonth : 0);
                        int AccureMonth = (DateFrom > LeaveAccureFromDate ? MonthTo - MonthFrom : MonthTo - LeaveAccureFromMonth) + 
                            (Model.CommonProperties.LoginInfo.SoftwareSettings.Employee_CurrentMonthLeaveAccumulateOn == Model.Settings.eEmployee_LeaveAccumulateOn.MonthBeginning ? 1 : 0);
                        AccureMonth = Math.Max(AccureMonth, 1);

                        r.OpeningLeaveAccured = Math.Round((LeaveType.AnnualEntitledDays / 12) * OpeningAccureMonth, 2);
                        r.Accured = Math.Round((LeaveType.AnnualEntitledDays / 12) * AccureMonth, 2);
                    }
                }

                return res;
            }
        }
    }
}
