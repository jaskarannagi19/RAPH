using Vision.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.Settings
{
    public class GridLayoutDAL
    {
        public enum eGridControlIDs
        {
            AccountBalanceReport = 1
        }

        public SavingResult SaveLayout(eGridControlIDs GridID, string Layout, string PrintOptions, string PageSettings)
        {
            return SaveLayout(GridID, Layout, PrintOptions, PageSettings,
                CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
        }
        public SavingResult SaveLayout(eGridControlIDs GridID, string Layout, string PrintOptions, string PageSettings, long CompanyID, long FinPerID)
        {
            SavingResult res = new SavingResult();
            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                int intGrid = (int)GridID;
                tblGridLayout SaveModel = db.tblGridLayouts.FirstOrDefault(r => r.GridID == intGrid && r.CompanyID == CompanyID && r.FinPerID == FinPerID);

                if (SaveModel == null) // New Entry
                {
                    SaveModel = new tblGridLayout();
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    db.tblGridLayouts.Add(SaveModel);
                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblGridLayouts.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                SaveModel.GridID = (int)GridID;
                SaveModel.Descr = GridID.ToString();
                SaveModel.Layout = Layout;
                SaveModel.PrintOptions = PrintOptions;
                SaveModel.PageSettings = PageSettings;
                SaveModel.CompanyID = Model.CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                SaveModel.FinPerID = Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID;

                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.GridLayoutID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
            }
            return res;
        }


        public string GetLayout(eGridControlIDs GridID)
        {
            return GetLayout(GridID,
                CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
        }
        public string GetLayout(eGridControlIDs GridID, long CompanyID, long FinPerID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblGridLayout SaveModel = db.tblGridLayouts.FirstOrDefault(r => r.GridID == (int)GridID && r.CompanyID == CompanyID && r.FinPerID == FinPerID);
                if(SaveModel == null)
                {
                    SaveModel = db.tblGridLayouts.Where(r => r.GridID == (int)GridID && r.CompanyID == CompanyID).OrderByDescending(r => r.FinPerID).FirstOrDefault();
                }

                if (SaveModel != null)
                {
                    return SaveModel.Layout;
                }
                else
                {
                    return null;
                }
            }
        }

        public string GetPrintOptions(eGridControlIDs GridID)
        {
            return GetPrintOptions(GridID,
                CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
        }

        public string GetPrintOptions(eGridControlIDs GridID, long CompanyID, long FinPerID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblGridLayout SaveModel = db.tblGridLayouts.FirstOrDefault(r => r.GridID == (int)GridID && r.CompanyID == CompanyID && r.FinPerID == FinPerID);
                if (SaveModel == null)
                {
                    SaveModel = db.tblGridLayouts.Where(r => r.GridID == (int)GridID && r.CompanyID == CompanyID).OrderByDescending(r => r.FinPerID).FirstOrDefault();
                }

                if (SaveModel != null)
                {
                    return SaveModel.PrintOptions;
                }
                else
                {
                    return null;
                }
            }
        }

        public string GetPageSettings(eGridControlIDs GridID)
        {
            return GetPageSettings(GridID,
                CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID);
        }

        public string GetPageSettings(eGridControlIDs GridID, long CompanyID, long FinPerID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblGridLayout SaveModel = db.tblGridLayouts.FirstOrDefault(r => r.GridID == (int)GridID && r.CompanyID == CompanyID && r.FinPerID == FinPerID);
                if (SaveModel == null)
                {
                    SaveModel = db.tblGridLayouts.Where(r => r.GridID == (int)GridID && r.CompanyID == CompanyID).OrderByDescending(r => r.FinPerID).FirstOrDefault();
                }

                if (SaveModel != null)
                {
                    return SaveModel.PageSettings;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
