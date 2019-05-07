using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.Settings
{
    public class PayrollMonthDAL
    {
        public tblPayrollMonth GetLatestPayrollMonthByCompanyID(int? CompanyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblPayrollMonths.Where(x=>x.CompanyID == CompanyID).OrderBy(x=>x.PayrollMonthEndDate).FirstOrDefault();
            }
        }

        public bool IsPayrollMonthEditable(int? CompanyID)
        {
            
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return (db.tblPayrollMonths.Count(x => x.CompanyID == CompanyID) > 1);
            }
                
        }


    }
}
