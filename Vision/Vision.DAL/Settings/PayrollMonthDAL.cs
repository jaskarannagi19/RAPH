using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Settings;

namespace Vision.DAL.Settings
{
    public class PayrollMonthDAL
    {

        public SavingResult SaveNewRecord(tblPayrollMonth SaveModel)
        {
            SavingResult res = new SavingResult();

            using (dbVisionEntities db = new dbVisionEntities())
            {
               
                
                SaveModel.rcuid = (Model.CommonProperties.LoginInfo.LoggedinUser != null ? (int?)Model.CommonProperties.LoginInfo.LoggedinUser.UserID : null);
                SaveModel.rcdt = DateTime.Now;
                db.tblPayrollMonths.Add(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Added;
                
                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.PayrollMonthID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                    return res;
                }                
            }
            return res;
        }

        public tblPayrollMonth GetLatestPayrollMonthByCompanyID(int CompanyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblPayrollMonths.Where(x=>x.CompanyID == CompanyID).OrderByDescending(x=>x.PayrollMonthEndDate).FirstOrDefault();
            }
        }

        public bool IsPayrollMonthEditable(int CompanyID)
        {
            
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (db.tblPayrollMonths.Count(x => x.CompanyID == CompanyID) > 1);
            }
                
        }
        public PayrollMonthViewModel GetLatestPayrollMonthViewModelByCompanyID(int CompanyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var res = db.tblPayrollMonths.Where(x => x.CompanyID == CompanyID).OrderBy(x => x.PayrollMonthEndDate).FirstOrDefault();
                if(res == null)
                {
                    return null;
                }
                return new PayrollMonthViewModel()
                {
                    PayrollMonthID = res.PayrollMonthID,
                    PayrollMonthStartDate = res.PayrollMonthStartDate,
                    PayrollMonthEndDate = res.PayrollMonthEndDate,
                    PayrollMonthName = res.PayrollMonthName,
                };
            }
        }













    }
}
