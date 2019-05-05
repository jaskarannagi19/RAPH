using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeWIBAClassRateDAL
    { 
        public SavingResult UpdateWIBAClassRate(DateTime? WEDate, List<EmployeeWIBAClassRateViewModel> Rate)
        {
            SavingResult res = new SavingResult();
            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var SelectedRates = Rate.Where(r => r.Selected);
                int[] SelectedWIBAClassIDs = SelectedRates.Select(r => r.EmployeeWIBClassID).ToArray();
                if (WEDate == null)
                {
                    db.tblEmployeeWIBAClassRates.RemoveRange(db.tblEmployeeWIBAClassRates.Where(r => SelectedWIBAClassIDs.Contains(r.EmployeeWIBAClassID)));
                }
                else
                {
                    db.tblEmployeeWIBAClassRates.RemoveRange(db.tblEmployeeWIBAClassRates.Where(r => SelectedWIBAClassIDs.Contains(r.EmployeeWIBAClassID) && r.WEDate >= WEDate));
                }

                foreach (var rate in SelectedRates)
                {
                    tblEmployeeWIBAClassRate SaveModel = new tblEmployeeWIBAClassRate()
                    {
                        EmployeeWIBAClassID = rate.EmployeeWIBClassID,
                        WEDate = WEDate,
                        EmployeeWIBAClassRate = rate.Rate,
                        CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                        rcdt = DateTime.Now,
                        rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                    };
                    db.tblEmployeeWIBAClassRates.Add(SaveModel);
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
            //--
            return res;
        }

        public List<EmployeeWIBAClassRateViewModel> GetEmployeeWIBAClassRate()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from ewc in db.tblEmployeeWIBAClasses
                        join jrate in (from r2 in (from r in db.tblEmployeeWIBAClassRates
                                                   where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID 

                                                   group r by r.EmployeeWIBAClassID into gr
                                                   select new
                                                   {
                                                       EmployeeWIBAClassID = gr.Key,
                                                       Rate = gr.OrderByDescending(r => r.WEDate).FirstOrDefault(),
                                                   })

                                       select new
                                       {
                                           EmployeeWIBAClassID = r2.EmployeeWIBAClassID,
                                           EmployeeWIBAClassRate = (r2.Rate != null ? r2.Rate.EmployeeWIBAClassRate : 0),
                                           WEDate = (r2.Rate != null ? r2.Rate.WEDate : null)
                                       })

                        on ewc.EmployeeWIBAClassID equals jrate.EmployeeWIBAClassID into grate
                        from rate in grate.DefaultIfEmpty()
                        where ewc.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID 

                        select new EmployeeWIBAClassRateViewModel()
                        {
                            EmployeeWIBClassID = ewc.EmployeeWIBAClassID,
                            EmployeeWIBAClassName = ewc.EmployeeWIBAClassName,
                            Rate = (rate != null ? rate.EmployeeWIBAClassRate : 0),
                            WEDate = (rate != null ? rate.WEDate : null)
                        }).ToList();
            }
        }
    }
}
