using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Payroll;

namespace Vision.DAL.Payroll
{
    public class EmployeeRestDayDAL
    {
        public SavingResult SaveNewRecord(DateTime DateFrom, DateTime DateTo, List<EmployeeRestDayViewModel> dsEmployee)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                db.tblEmployeeRestDays.RemoveRange(db.tblEmployeeRestDays.Where(r => 
                    r.CompanyID == Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID 
                    && r.FinPeriodID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                        && r.RestDate >= DateFrom && r.RestDate < DateTo));

                foreach (var Employee in dsEmployee)
                {
                    for (int ri = 0; ri < Employee.RestDayDetailDataSource.Count(); ri++)
                    {
                        if (Employee.RestDayDetailDataSource[ri].RestDay)
                        {
                            DateTime date = DateFrom;//.AddDays(ri);
                            while (date.DayOfWeek != Employee.RestDayDetailDataSource[ri].Day)
                            {
                                date = date.AddDays(1);
                            }

                            do
                            {
                                tblEmployeeRestDay SaveModel = new tblEmployeeRestDay()
                                {
                                    EmployeeID = Employee.EmployeeID,
                                    RestDate = date,

                                    CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                                    FinPeriodID = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                                    rcdt = DateTime.Now,
                                    rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                                };
                                db.tblEmployeeRestDays.Add(SaveModel);

                                date = date.AddDays(7);

                            } while (date <= DateTo);
                        }
                    }
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
            return res;
        }

        public List<EmployeeRestDayViewModel> GetEmployeeList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                byte WeekendType_RestDay = (byte)Model.Employee.eTAWeekendtype.RestDay;
                var res = (from e in db.tblEmployees
                           join jenp in db.tblEmployeeNoPrefixes on e.EmployeeNoPrefixID equals jenp.EmployeeNoPrefixID into genp
                           from enp in genp.DefaultIfEmpty()
                           where e.rstate != RecordState_Deleted
                                && e.TAWeekendType == WeekendType_RestDay
                               && e.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID

                           orderby e.EmployeeNo
                           select new EmployeeRestDayViewModel()
                           {
                               EmployeeID = e.EmployeeID,
                               EmployeeNoPrefix = (enp != null ? enp.EmployeeNoPrefixName : null),
                               EmployeeNo = e.EmployeeNo,
                               EmployeeName = e.EmployeeFirstName + " " + e.EmployeeLastName,
                           }).ToList();
                return res;
            }
        }

        public List<EmployeeRestDayEditDetailModel> GetRestDayDetails(DateTime DateFrom, DateTime DateTo)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from r2 in (from r in db.tblEmployeeRestDays
                                    where r.RestDate >= DateFrom && r.RestDate <= DateTo &&
                                    r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                                    r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                                    select new
                                    {
                                        EmployeeID = r.EmployeeID,
                                        RestDate = r.RestDate,
                                    }).ToList()
                        group r2 by new { r2.EmployeeID, r2.RestDate.DayOfWeek } into gr2
                        select new EmployeeRestDayEditDetailModel()
                        {
                            EmployeeID = gr2.Key.EmployeeID,
                            RestDay = gr2.Key.DayOfWeek
                        }).ToList();
            }
        }

        public List<DateTime> GetRestDates(int EmployeeID, DateTime DateFrom, DateTime DateTo)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from r in db.tblEmployeeRestDays
                        where r.EmployeeID == EmployeeID &&
                        r.RestDate >= DateFrom && r.RestDate <= DateTo &&
                        r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID &&
                        r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID
                        select r.RestDate).ToList();
            }
        }
    }
}
