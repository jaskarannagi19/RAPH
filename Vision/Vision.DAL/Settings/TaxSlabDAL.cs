using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision.Model;
using Vision.Model.Settings;

namespace Vision.DAL.Settings
{
    public class TaxSlabDAL
    {
        public SavingResult SaveTaxSlab(tblTaxSlabHeader SaveModel, List<TaxSlabViewModel> TaxSlabPrime, List<TaxSlabViewModel> TaxSlabSecond, eTaxSlab_TaxType TaxType)
        {
            byte TaxTypeID = (byte)TaxType;
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var oldSlabHeader = db.tblTaxSlabHeaders.Where(r => r.TaxTypeID == TaxTypeID && 
                            (SaveModel.WEDate == null || r.WEDate >= SaveModel.WEDate) &&
                            r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID);
                var detailes = (from r in db.tblTaxSlabDetails
                                join h in oldSlabHeader on r.TaxSlabHeaderID equals h.TaxSlabHeaderID
                                select r).ToList();
                db.tblTaxSlabDetails.RemoveRange(detailes);
                db.tblTaxSlabHeaders.RemoveRange(oldSlabHeader);


                SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                SaveModel.TaxTypeID = TaxTypeID;
                SaveModel.rcdt = DateTime.Now;
                SaveModel.rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID;
                db.tblTaxSlabHeaders.Add(SaveModel);
                //--
                byte IncomeTypeID = (byte)Model.Employee.eIncomeType.Primary;
                db.tblTaxSlabDetails.AddRange(TaxSlabPrime.Select(r => new tblTaxSlabDetail()
                {
                    tblTaxSlabHeader = SaveModel,

                    IncomeType = IncomeTypeID,

                    TaxableValueFrom = r.TaxableSalaryFromValue,
                    TaxableValueTo = r.TaxableSalaryToValue,

                    TaxValueEmployee = r.TaxValueEmployee,
                    TaxPercEmployee = r.TaxPercEmployee,
                    MaxTaxValueEmployee = r.MaxTaxValueEmployee,

                    TaxValueEmployer = r.TaxValueEmployer,
                    TaxPercEmployer = r.TaxPercEmployer,
                    MaxTaxValueEmployer = r.MaxTaxValueEmployer,

                }));

                if (TaxSlabSecond != null)
                {
                    IncomeTypeID = (byte)Model.Employee.eIncomeType.Secondary;
                    db.tblTaxSlabDetails.AddRange(TaxSlabSecond.Select(r => new tblTaxSlabDetail()
                    {
                        tblTaxSlabHeader = SaveModel,
                        TaxableValueFrom = r.TaxableSalaryFromValue,
                        TaxableValueTo = r.TaxableSalaryToValue,

                        IncomeType = IncomeTypeID,

                        TaxValueEmployee = r.TaxValueEmployee,
                        TaxPercEmployee = r.TaxPercEmployee,
                        MaxTaxValueEmployee = r.MaxTaxValueEmployee,

                        TaxValueEmployer = r.TaxValueEmployer,
                        TaxPercEmployer = r.TaxPercEmployer,
                        MaxTaxValueEmployer = r.MaxTaxValueEmployer,
                    }));
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

        public tblTaxSlabHeader GetLatestTaxSlabHeader(eTaxSlab_TaxType TaxType)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte TaxTypeID = (byte)TaxType;
                return db.tblTaxSlabHeaders.Where(rr => rr.TaxTypeID == TaxTypeID && rr.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID).OrderByDescending(rr => rr.WEDate).FirstOrDefault();
            }
        }

        public List<TaxSlabViewModel> GetLatestTaxSlab(eTaxSlab_TaxType TaxType, Model.Employee.eIncomeType IncomeType)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte TaxTypeID = (byte)TaxType;
                byte IncomeTypeID = (byte)IncomeType;

                var r = db.tblTaxSlabHeaders.Where(rr => rr.TaxTypeID == TaxTypeID && rr.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID).OrderByDescending(rr => rr.WEDate).FirstOrDefault();
                if (r != null)
                {
                    return db.tblTaxSlabDetails.Where(rr => rr.TaxSlabHeaderID == r.TaxSlabHeaderID && rr.IncomeType == IncomeTypeID).Select(rr => new TaxSlabViewModel()
                    {
                        TaxableSalaryFromValue = rr.TaxableValueFrom ?? 0,
                        TaxableSalaryToValue = rr.TaxableValueTo ?? 0,

                        TaxValueEmployee = rr.TaxValueEmployee ?? 0,
                        TaxPercEmployee = rr.TaxPercEmployee ?? 0,
                        MaxTaxValueEmployee = rr.MaxTaxValueEmployee ?? 0,

                        TaxValueEmployer = rr.TaxValueEmployer ?? 0,
                        TaxPercEmployer = rr.TaxPercEmployer ?? 0,
                        MaxTaxValueEmployer = rr.MaxTaxValueEmployer ?? 0,

                    }).ToList();
                }
                else
                {
                    return new List<TaxSlabViewModel>();
                }
            }
        }

        public List<TaxSlabViewModel> GetTaxSlab(eTaxSlab_TaxType TaxType, DateTime? WEDate)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte TaxTypeID = (byte)TaxType;
                var r = db.tblTaxSlabHeaders.Where(rr => rr.TaxTypeID == TaxTypeID && rr.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID &&
                            (rr.WEDate <= WEDate || (rr.WEDate == null && WEDate == null))).OrderByDescending(rr => rr.WEDate).FirstOrDefault();
                if (r != null)
                {
                    return db.tblTaxSlabDetails.Where(rr => rr.TaxSlabHeaderID == r.TaxSlabHeaderID).Select(rr => new TaxSlabViewModel()
                    {
                        TaxableSalaryFromValue = rr.TaxableValueFrom ?? 0,
                        TaxableSalaryToValue = rr.TaxableValueTo ?? 0,


                        TaxValueEmployee = rr.TaxValueEmployee ?? 0,
                        TaxPercEmployee = rr.TaxPercEmployee ?? 0,
                        MaxTaxValueEmployee = rr.MaxTaxValueEmployee ?? 0,

                        TaxValueEmployer = rr.TaxValueEmployer ?? 0,
                        TaxPercEmployer = rr.TaxPercEmployer ?? 0,
                        MaxTaxValueEmployer = rr.MaxTaxValueEmployer ?? 0,

                    }).ToList();
                }
                else
                {
                    return new List<TaxSlabViewModel>();
                }
            }
        }
    }
}
