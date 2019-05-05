using Vision.DAL.City;
using Vision.Model;
using Vision.Model.City;
using Vision.Model.Reports;
using Vision.Model.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.Settings
{
	public class CompanyDAL
	{
		public SavingResult SaveNewRecord(tblCompany SaveModel, long? CopySettingsFromCompanyID, tblPayrollMonth PayRollMonth)
		{
			SavingResult res = new SavingResult();

			//-- Perform Validation
			//res.ExecutionResult = eExecutionResult.ValidationError;
			//res.ValidationError = "Validation error message";
			//return res;

			//--
			using (dbVisionEntities db = new dbVisionEntities())
			{
				//tblCompany SaveModel;
				if (SaveModel.CompanyName == "")
				{
					res.ValidationError = "Can not accept blank value. Please enter Country Name.";
					res.ExecutionResult = eExecutionResult.ValidationError;
					return res;
				}
				else if (IsDuplicateRecord(SaveModel.CompanyName, SaveModel.CompanyID, db))
				{
					res.ValidationError = "Can not accept duplicate value. The Company Name is already exists.";
					res.ExecutionResult = eExecutionResult.ValidationError;
					return res;
				}

                bool IsNewCompany = (SaveModel.CompanyID == 0);
                //tblAdditionalItemMaster RoundOffItem = null;
                //tblPriceList DefaultPriceList = null;
                //tblAccount CashAccount = null;

                if (SaveModel.CompanyID == 0) // New Entry
				{
                    SaveModel.rcuid = (Model.CommonProperties.LoginInfo.LoggedinUser != null ?
                        (int?)Model.CommonProperties.LoginInfo.LoggedinUser.UserID : null);
					SaveModel.rcdt = DateTime.Now;
					db.tblCompanies.Add(SaveModel);

					db.tblFinPeriods.Add(new tblFinPeriod()
						{
							FinPeriodName = SaveModel.BusinessStartedFrom.Date.Year.ToString() + "-*",
							FinPeriodFrom = SaveModel.BusinessStartedFrom.Date,
							tblCompany = SaveModel,
							rcdt = DateTime.Now
						});
                    db.tblPayrollMonths.Add(new tblPayrollMonth()
                    {
                        PayrollMonthName = PayRollMonth.PayrollMonthName,
                        PayrollMonthStartDate = PayRollMonth.PayrollMonthStartDate,
                        PayrollMonthEndDate = PayRollMonth.PayrollMonthEndDate,
                        tblCompany = SaveModel,
                        rcdt = DateTime.Now
                    });

                    ////-- Inserting new round off record for newly created company
                    //RoundOffItem = new tblAdditionalItemMaster()
                    //{
                    //    ItemName = "Round Off",
                    //    Nature = 1,
                    //    SystemRecord = 1,
                    //    ItemType = 0,
                    //    Perc = 0,
                    //    CalculatePerc = false,
                    //    CalculateOnID = 1,
                    //    IsInclusive = false,
                    //    DefaultRecord = false,
                    //    rcdt = DateTime.Now,
                    //    rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID,
                    //    tblCompany = SaveModel
                    //};
                    //db.tblAdditionalItemMasters.Add(RoundOffItem);

                    //DefaultPriceList = new tblPriceList()
                    //{
                    //    PriceListName = "Default",
                    //    PriceListShortName = "D",
                    //    tblCompany = SaveModel
                    //};
                    //db.tblPriceLists.Add(DefaultPriceList);

                    //CashAccount = new tblAccount()
                    //{
                    //    AccountName = "Cash",
                    //    NameTitle = "",
                    //    CityID = SaveModel.CityID,
                    //};
                    //db.tblAccounts.Add(CashAccount);

     //               // Copieng settings from existing company;
     //               if (CopySettingsFromCompanyID != null)
					//{
					//	var NewSettings = db.tblSettingsL1.Where(r => r.CompanyID == CopySettingsFromCompanyID);

					//	if(NewSettings != null)
					//	{
     //                       foreach (var rSetting in NewSettings)
     //                       {
     //                           var NewSetting = (tblSettingsL1)Model.CommonFunctions.CloneObject(rSetting);
     //                           NewSetting.tblCompany = SaveModel;
     //                           db.tblSettingsL1.Add(NewSetting);
     //                       }
					//	}
					//}
				}
				else
				{
					SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
					SaveModel.redt = DateTime.Now;
					db.tblCompanies.Attach(SaveModel);
					db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
				}

				//--
				try
				{
					db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.CompanyID;
					res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
				}
				catch (Exception ex)
				{
                    CommonFunctions.GetFinalError(res, ex);
                    return res;
				}

                //DAL.Settings.SettingsDAL SettingDALObj = new SettingsDAL();
                //if (RoundOffItem != null)
                //{
                //    // If completed successfully and new company created then move newly added round off item's id in setting
                //    SettingDALObj.SaveSettingL1("RoundOffAddLessID", RoundOffItem.AdditionaItemID, SaveModel.CompanyID);
                //    SettingDALObj.SaveSettingL1("ApplyRoundOff", true, SaveModel.CompanyID);
                //}
                //if(CashAccount != null)
                //{
                //    // Default cash Account id
                //    SettingDALObj.SaveSettingL1("SaleInvoiceDefaultAccountID", CashAccount.AccountID, SaveModel.CompanyID);
                //}
            }
			return res;
		}

        public SavingResult SaveLogoFileName(int CompanyID, string FileName)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var SaveModel = db.tblCompanies.Find(CompanyID);
                if(SaveModel == null)
                {
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    res.ValidationError = "Selected company not found. It may be deleted over network. Please check again or contact your administrator.";
                    return res;
                }

                SaveModel.CompanyLogoFileName = FileName;
                db.tblCompanies.Attach(SaveModel);
                db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.CompanyID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }
                return res;
            }
        }

        public tblCompany FindSaveModelByPrimeKey(long ID)
		{
			using (dbVisionEntities db = new dbVisionEntities())
			{
				return db.tblCompanies.Find(ID);
			}
		}

		public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
		{
			BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
			if(DeleteID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID)
			{
				Result.ValidationMessage = "Can not delete current logged in company. Please log in different company and try to delete.";
			}
			//using (dbVisionEntities db = new dbVisionEntities())
			//{

				//bool InState = db.tblCompanies.FirstOrDefault(r => r.CompanyID == DeleteID) != null;

				//if (InState)
				//{
				//    Result.ValidationMessage = "Country is selected in company";
				//}
			//}
			Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
			return Result;
		}

		public SavingResult DeleteRecord(long DeleteID)
		{
			SavingResult res = new SavingResult();

			using (dbVisionEntities db = new dbVisionEntities())
			{
				if (DeleteID != 0)
				{
					SavingResult DataDelRes = new SavingResult();

                    tblCompany RecordToDelete = db.tblCompanies.FirstOrDefault(r => r.CompanyID == DeleteID);

                    if (RecordToDelete == null)
					{
						res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
						res.ExecutionResult = eExecutionResult.ValidationError;
						return res;
					}

                    RecordToDelete.rstate = (byte)eRecordState.Deleted;
                    db.tblCompanies.Attach(RecordToDelete);
                    db.Entry(RecordToDelete).State = System.Data.Entity.EntityState.Modified;

					/// financial Period and all financial data
					DAL.Settings.FinPeriodDAL FinPeriodDALObj = new FinPeriodDAL();

					List<tblFinPeriod> FinPeriodRecrods = db.tblFinPeriods.Where(r => r.CompanyID == DeleteID).ToList();
					foreach (tblFinPeriod FinPer in FinPeriodRecrods)
					{
                        DataDelRes = FinPeriodDALObj.DeleteRecord(FinPer, db);

                        if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
						{
							return res;
						}
					}

                    ///// Additional Item Master
                    //DAL.Sales.AdditionalItemMasterDAL AdditionalItemDALObj = new Sales.AdditionalItemMasterDAL();
                    //List<tblAdditionalItemMaster> AdditionalItems = db.tblAdditionalItemMasters.Where(r => r.CompanyID == DeleteID).ToList();
                    //foreach (tblAdditionalItemMaster AddItem in AdditionalItems)
                    //{
                    //	DataDelRes = AdditionalItemDALObj.DeleteRecord(AddItem, db);
                    //	if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //	{
                    //		return res;
                    //	}
                    //}

                    //               // All grid report format user settings
                    //               db.tblGridLayouts.RemoveRange( db.tblGridLayouts.Where(r => r.CompanyID == DeleteID));

                    ///// Account 
                    //DAL.Account.AccountDAL AccountDALObj = new Account.AccountDAL();
                    //List<tblAccount> Accounts = db.tblAccounts.Where(r => r.CompanyID == DeleteID).ToList();
                    //foreach (tblAccount Account in Accounts)
                    //{
                    //	DataDelRes = AccountDALObj.DeleteRecord(Account, db);
                    //	if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //	{
                    //		return res;
                    //	}
                    //}

                    //               /// Product 
                    //               DAL.Product.ProductDAL ProductDALObj = new Product.ProductDAL();
                    //List<tblProduct> Products = db.tblProducts.Where(r => r.CompanyID == DeleteID).ToList();
                    //foreach (tblProduct DeletingRecord in Products)
                    //{
                    //	DataDelRes = ProductDALObj.DeleteRecord(DeletingRecord, db);
                    //	if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //	{
                    //		return res;
                    //	}
                    //}

                    ///// Price List Name Master
                    //DAL.Product.PriceListDAL PriceListDALObj = new Product.PriceListDAL();
                    //List<tblPriceList> PriceLists = db.tblPriceLists.Where(r => r.CompanyID == DeleteID).ToList();
                    //foreach (tblPriceList DeletingRecord in PriceLists)
                    //{
                    //	DataDelRes = PriceListDALObj.DeleteRecord(DeletingRecord, db);
                    //	if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //	{
                    //		return res;
                    //	}
                    //}


                    //               /// Transport
                    //               DAL.Sales.TransportDAL TransportDALObj = new Sales.TransportDAL();
                    //               List<tblTransport> Transportes = db.tblTransports.Where(r => r.CompanyID == DeleteID).ToList();
                    //               foreach (tblTransport DeletingRecord in Transportes)
                    //               {
                    //                   DataDelRes = TransportDALObj.DeleteRecord(DeletingRecord, db);
                    //                   if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //                   {
                    //                       return res;
                    //                   }
                    //               }

                    //               /// Purchase Return Prefix
                    //               DAL.Purchase.PurchaseReturnNoPrefixDAL PurchaseReturnNoPrefixDALObj = new Purchase.PurchaseReturnNoPrefixDAL();
                    //               List<tblPurchaseReturnNoPrefix> PurchaseReturnNoPrefixes = db.tblPurchaseReturnNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    //               foreach (tblPurchaseReturnNoPrefix DeletingRecord in PurchaseReturnNoPrefixes)
                    //               {
                    //                   DataDelRes = PurchaseReturnNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                    //                   if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //                   {
                    //                       return res;
                    //                   }
                    //               }

                    //               /// Purchase Bill Prefix
                    //               DAL.Purchase.PurchaseReceiptNoPrefixDAL PurchaseReceiptNoPrefixDALObj = new Purchase.PurchaseReceiptNoPrefixDAL();
                    //               List<tblPurchaseReceiptNoPrefix> PurchaseReceiptNoPrefixes = db.tblPurchaseReceiptNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    //               foreach (tblPurchaseReceiptNoPrefix DeletingRecord in PurchaseReceiptNoPrefixes)
                    //               {
                    //                   DataDelRes = PurchaseReceiptNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                    //                   if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //                   {
                    //                       return res;
                    //                   }
                    //               }

                    //               /// Quotation Prefix
                    //               DAL.Sales.SaleQuoteNoPrefixDAL SaleQuoteNoPrefixDALObj = new Sales.SaleQuoteNoPrefixDAL();
                    //               List<tblSaleQuoteNoPrefix> SaleQuoteNoPrefixes = db.tblSaleQuoteNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    //               foreach (tblSaleQuoteNoPrefix DeletingRecord in SaleQuoteNoPrefixes)
                    //               {
                    //                   DataDelRes = SaleQuoteNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                    //                   if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //                   {
                    //                       return res;
                    //                   }
                    //               }


                    //               /// Sale Return Prefix
                    //               DAL.Sales.SaleReturnNoPrefixDAL SaleReturnNoPrefixDALObj = new Sales.SaleReturnNoPrefixDAL();
                    //               List<tblSaleReturnNoPrefix> SaleReturnNoPrefixes = db.tblSaleReturnNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    //               foreach (tblSaleReturnNoPrefix DeletingRecord in SaleReturnNoPrefixes)
                    //               {
                    //                   DataDelRes = SaleReturnNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                    //                   if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //                   {
                    //                       return res;
                    //                   }
                    //               }


                    //               /// Sale Invoice Prefix
                    //               DAL.Sales.SaleInvoiceNoPrefixDAL SaleInvoiceNoPrefixDALObj = new Sales.SaleInvoiceNoPrefixDAL();
                    //               List<tblSaleInvoiceNoPrefix> SaleInvoiceNoPrefixes = db.tblSaleInvoiceNoPrefixes.Where(r => r.CompanyID == DeleteID).ToList();
                    //               foreach (tblSaleInvoiceNoPrefix DeletingRecord in SaleInvoiceNoPrefixes)
                    //               {
                    //                   DataDelRes = SaleInvoiceNoPrefixDALObj.DeleteRecord(DeletingRecord, db);
                    //                   if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                    //                   {
                    //                       return res;
                    //                   }
                    //               }

                    ///// Deleting settings for the company
                    //db.tblSettingsL1.RemoveRange(db.tblSettingsL1.Where(r => r.CompanyID == DeleteID));

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
			}
			return res;
		}

        public SavingResult Authorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblCompanies.FirstOrDefault(r => r.CompanyID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblCompanies.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;

                //--
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

        public SavingResult UnAuthorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblCompanies.FirstOrDefault(r => r.CompanyID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblCompanies.Attach(rec);
                db.Entry(rec).State = System.Data.Entity.EntityState.Modified;

                //--
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

        public List<CompanyEditListModel> GetEditList()
		{
			using (dbVisionEntities db = new dbVisionEntities())
			{
                byte RecordState_Deleted = (byte)eRecordState.Deleted;


                return (from r in db.tblCompanies

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted

                        orderby r.CompanyName
						select new CompanyEditListModel()
						{
							CompanyID = r.CompanyID,
							CompanyName = r.CompanyName,

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),

                        }).ToList(); ;
			}
		}

        public List<CompanyMultiSelectLookupModel> GetMuliSelectLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;


                return (from r in db.tblCompanies

                        where r.rstate != RecordState_Deleted

                        orderby r.CompanyName
                        select new CompanyMultiSelectLookupModel()
                        {
                            CompanyID = r.CompanyID,
                            CompanyName = r.CompanyName,

                        }).ToList();
            }
        }

        public List<CompanyLookupModel> GetLookupList(int UserGroupID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from r in db.tblCompanies
                        join p in db.tblUserGroupPermissionOnCompanies on new { r.CompanyID, UserGroupID } equals new { p.CompanyID, p.UserGroupID }


                        join jsetting in db.tblSettingsL1 on new { r.CompanyID, SettingName = "License_ValidUpto" } equals new { jsetting.CompanyID, jsetting.SettingName } into gsetting
                        from setting in gsetting.DefaultIfEmpty()

                        where r.rstate != RecordState_Deleted
                            && (setting == null || setting.SettingValueDateTime == null || setting.SettingValueDateTime >= DateTime.Now)

                        orderby r.CompanyName
                        select new CompanyLookupModel()
                        {
                            CompanyID = r.CompanyID,
                            CompanyName = r.CompanyName,

                        }).ToList();
            }
        }

        public List<CompanyLookupModel> GetLookupList()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from r in db.tblCompanies

                        where r.rstate != RecordState_Deleted

                        orderby r.CompanyName
                        select new CompanyLookupModel()
                        {
                            CompanyID = r.CompanyID,
                            CompanyName = r.CompanyName,
                        }).ToList();
            }
        }

        public CompanyDetailViewModel GetCompanyDetail(long CompanyID)
		{
			using (dbVisionEntities db = new dbVisionEntities())
			{
				tblCompany r = db.tblCompanies.FirstOrDefault(r1 => r1.CompanyID == CompanyID);
				if (r == null)
				{
					return null;
				}
				else
				{
					return ConvertToDetailViewModel(r);
				}
			}
		}

		public static CompanyDetailViewModel GetFirstCompany(int UserGroupID)
		{
			using (dbVisionEntities db = new dbVisionEntities())
			{
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                tblCompany company = (from r in db.tblCompanies
                                join p in db.tblUserGroupPermissionOnCompanies on new { r.CompanyID, UserGroupID } equals new { p.CompanyID, p.UserGroupID }
                                where r.rstate != RecordState_Deleted
                                select r).FirstOrDefault();

				if (company == null)
				{
					return null;
				}
				else
				{
					return ConvertToDetailViewModel(company);
				}
			}
		}

		public static CompanyDetailViewModel ConvertToDetailViewModel(tblCompany r)
		{
			return new CompanyDetailViewModel()
			{
				CompanyID = r.CompanyID,
				CompanyName = r.CompanyName,
				//Address = r.Address,
				CityID = r.CityID,
				PIN = r.PIN,
				Phone1 = r.Phone1,
				MobileNo1 = r.MobileNo1,
				EMailID = r.EMailID,
				Website = r.Website,
				//PAN = r.PAN,
				//GSTIN = r.GSTIN,
				//LicenseName = r.LicenseName,
				//LicenseNo = r.LicenseNo,
				//Jurisdiction = r.Jurisdiction,
				BusinessStartedFrom = r.BusinessStartedFrom,
				//City = CityDAL.ConvertToDetailViewModel(r.tblCity)
			};
		}

		public static Model.Reports.CompanyDetailReportModel GetCompanyDetailReportModel(long CompanyID)
		{
			using (dbVisionEntities db = new dbVisionEntities())
			{
				tblCompany r = db.tblCompanies.FirstOrDefault(r1 => r1.CompanyID == CompanyID);
				if (r == null)
				{
					return null;
				}
				else
				{
					return new CompanyDetailReportModel()
					{
						CompanyID = r.CompanyID,
						CompanyName = r.CompanyName,
						Address = r.Address1,
						CityID = r.CityID,
						PIN = r.PIN,
						Phone1 = r.Phone1,
						MobileNo1 = r.MobileNo1,
						EMailID = r.EMailID,
						Website = r.Website,
						BusinessStartedFrom = r.BusinessStartedFrom,
						CityName = r.tblCity.CityName,
						StateName = r.tblCity.tblState.StateName,
						StateNameShort = r.tblCity.tblState.StateShortName ?? r.tblCity.tblState.StateName,
						CountryName = r.tblCity.tblState.tblCountry.CountryName,
					};
				}
			}
		}

		public bool IsDuplicateRecord(string CompanyName, long ID)
		{
			using (dbVisionEntities db = new dbVisionEntities())
			{
				return IsDuplicateRecord(CompanyName, ID, db);
			}
		}
		public bool IsDuplicateRecord(string CompanyName, long ID, dbVisionEntities db)
		{
			if (db.tblCompanies.FirstOrDefault(i => i.CompanyName == CompanyName && i.CompanyID != ID) != null)
			{
				return true;
			}
			return false;
		}

		public static int CompanyCount(int UserGroupID)
		{
			using (dbVisionEntities db = new dbVisionEntities())
			{
                byte RecordState_Deleted = (byte)eRecordState.Deleted;

                return (from r in db.tblCompanies
                         join p in db.tblUserGroupPermissionOnCompanies on new { r.CompanyID, UserGroupID } equals new { p.CompanyID, p.UserGroupID }
                         where r.rstate != RecordState_Deleted
                        select r.CompanyID).Count();
			}
		}

        public int GenerateNewCode(dbVisionEntities db)
        {
            return (db.tblCompanies.Max(r => (int?)r.CompanyCode) ?? 0) + 1;
        }

        public int GenerateNewCode()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return GenerateNewCode(db);
            }
        }

        public int GetCompanyCount()
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return db.tblCompanies.Count(r=> r.rstate != (int)RecordState_Deleted);
            }
        }
	}
}
