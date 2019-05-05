using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Employee;

namespace Vision.DAL.Employee
{
    public class EmployeeShiftAllocationDAL
    {

        public SavingResult Save(int ShiftID, DateTime? WEFDateFrom, int[] SelectedEmployeeIDs)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                if (SelectedEmployeeIDs.Count() == 0)
                {
                    res.ExecutionResult = eExecutionResult.ErrorWhileExecuting;
                    res.ValidationError = "No employee was selected.";
                    return res;
                }

                if (WEFDateFrom != null)
                {
                    db.tblEmployeeShiftAllocations.RemoveRange(db.tblEmployeeShiftAllocations.Where(r => SelectedEmployeeIDs.Contains(r.EmployeeID) 
                        && r.WEDateFrom >= WEFDateFrom.Value && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID));
                }
                else
                {
                    db.tblEmployeeShiftAllocations.RemoveRange(db.tblEmployeeShiftAllocations.Where(r => SelectedEmployeeIDs.Contains(r.EmployeeID) 
                        && r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID));
                }


                db.tblEmployeeShiftAllocations.AddRange(
                    from e in SelectedEmployeeIDs
                    select new tblEmployeeShiftAllocation()
                    {
                        EmployeeID = e,
                        EmployeeShiftID = ShiftID,
                        WEDateFrom = WEFDateFrom,
                        CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                        FinPeriodID = CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID,
                        rcdt = DateTime.Now,
                        rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                    });

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

        public List<EmployeeLatestShiftAllocationViewModel> GetLatestShiftAllocation()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (from r3 in (from r2 in (from r in db.tblEmployeeShiftAllocations
                                                where r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                                                    r.FinPeriodID == CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID
                                                group r by r.EmployeeID into gr
                                                select new
                                                {
                                                    EmployeeID = gr.Key,
                                                    Shift = gr.OrderByDescending(grr => grr.WEDateFrom).FirstOrDefault(),
                                                })

                                    select new
                                    {
                                        EmployeeID = r2.EmployeeID,
                                        WEDateFrom = (r2.Shift != null ? r2.Shift.WEDateFrom : null),
                                        EmployeeShiftID = (r2.Shift != null ? (int?)r2.Shift.EmployeeShiftID : null)
                                    })
                        join js in db.tblEmployeeShifts on r3.EmployeeShiftID equals js.EmployeeShiftID into gs
                        from s in gs.DefaultIfEmpty()
                        select new EmployeeLatestShiftAllocationViewModel()
                        {
                            EmployeeID = r3.EmployeeID,
                            WEDateFrom = r3.WEDateFrom,
                            EmployeeShiftID = r3.EmployeeShiftID,
                            EmployeeShiftName = (s != null ? s.EmployeeShiftName : null),
                        }).ToList();
            }
        }
    }
}
