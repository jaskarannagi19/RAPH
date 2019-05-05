using Vision.Model;
using Vision.Model.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision.DAL.Settings
{
    public class FinPeriodDAL
    {
        public SavingResult SaveNewRecord(tblFinPeriod SaveModel, FinPeriodDetailModel PrevFinPeriod, FinPeriodDetailModel NextFinPeriod,
            List<AccountClosingBalanceViewModel> COBalances, List<ProductOpeningStockViewModel> POStocks)
        {
            SavingResult res = new SavingResult();

            //--
            using (dbVisionEntities db = new dbVisionEntities())
            {
                //tblFinPeriod SaveModel;
                if (SaveModel.FinPeriodName == "")
                {
                    res.ValidationError = "Can not accept blank value. Please enter Financial Period Name.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }
                else if (IsDuplicateRecord(SaveModel.FinPeriodName, SaveModel.FinPeriodID, db))
                {
                    res.ValidationError = "Can not accept duplicate value. The Financial Period Name is already exists.";
                    res.ExecutionResult = eExecutionResult.ValidationError;
                    return res;
                }

                bool IsNewFinPeriodAdded = (SaveModel.FinPeriodID == 0);

                if (SaveModel.FinPeriodID == 0) // New Entry
                {
                    SaveModel.rcuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.rcdt = DateTime.Now;
                    SaveModel.CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID;
                    db.tblFinPeriods.Add(SaveModel);

                    if (PrevFinPeriod != null)
                    {
                        tblFinPeriod PrevFinPerSaveModel = db.tblFinPeriods.Find(PrevFinPeriod.FinPeriodID);
                        if (PrevFinPerSaveModel != null)
                        {
                            if (PrevFinPerSaveModel.FinPeriodTo == null)
                            {
                                PrevFinPerSaveModel.FinPeriodTo = SaveModel.FinPeriodFrom.Date.AddDays(-1);
                                //if (PrevFinPerSaveModel.FinPeriodName == PrevFinPerSaveModel.FinPeriodFrom.Year.ToString() + " - *")
                                //{
                                PrevFinPerSaveModel.FinPeriodName = PrevFinPerSaveModel.FinPeriodFrom.Year.ToString() + " - " + PrevFinPerSaveModel.FinPeriodTo.Value.Year.ToString();
                                //}

                                PrevFinPerSaveModel.redt = DateTime.Now;
                                db.tblFinPeriods.Attach(PrevFinPerSaveModel);
                                db.Entry(PrevFinPerSaveModel).State = System.Data.Entity.EntityState.Modified;
                            }
                        }
                    }

                }
                else
                {
                    SaveModel.reuid = Model.CommonProperties.LoginInfo.LoggedinUser.UserID;
                    SaveModel.redt = DateTime.Now;
                    db.tblFinPeriods.Attach(SaveModel);
                    db.Entry(SaveModel).State = System.Data.Entity.EntityState.Modified;
                }

                //--
                try
                {
                    db.SaveChanges();
                    res.PrimeKeyValue = SaveModel.FinPeriodID;
                    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                }
                catch (Exception ex)
                {
                    CommonFunctions.GetFinalError(res, ex);
                }


                if (IsNewFinPeriodAdded && PrevFinPeriod != null)
                {
                    //    /// Transfer Stock and Balances
                    //    DAL.Account.AccountOpeningBalanceDAL COPBDALObj = new Account.AccountOpeningBalanceDAL();
                    //    ///--- Save Account Balances
                    //    foreach (var copb in COBalances)
                    //    {
                    //        if (copb.OpeningBalance != 0)
                    //        {
                    //            COPBDALObj.SaveNewRecord(new tblAccountOpeningBalance()
                    //            {
                    //                OpeningBalanceDate = SaveModel.FinPeriodFrom.Date,
                    //                OpeningBalanceAmt = copb.OpeningBalance,
                    //                Narration = "Opening Balance T/F",
                    //                AccountID = copb.AccountID,
                    //                CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                    //                tblFinPeriod = SaveModel,
                    //                rcdt = DateTime.Now,
                    //                rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID
                    //            }, SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                    //        }
                    //    }
                    //    ///

                    //    /// Save Product Stock
                    //    DAL.Inventory.ProductOpeningStockDAL POStockDALObj = new Inventory.ProductOpeningStockDAL();
                    //    int OpeningStockVoucherTypeID = (int)Model.Inventory.eStockVoucherType.OpeningStock;
                    //    foreach (var stock in POStocks)
                    //    {
                    //        if (stock.Stock != 0)
                    //        {
                    //            POStockDALObj.SaveNewRecord(
                    //                new tblStock()
                    //                {
                    //                    StockVoucherTypeID = OpeningStockVoucherTypeID,
                    //                    VDate = SaveModel.FinPeriodFrom.Date,
                    //                    Narration = "Opening Stock T/F",
                    //                    CompanyID = CommonProperties.LoginInfo.LoggedInCompany.CompanyID,
                    //                    tblFinPeriod = SaveModel,
                    //                    rcdt = DateTime.Now,
                    //                    rcuid = CommonProperties.LoginInfo.LoggedinUser.UserID
                    //                },
                    //                new List<tblStockPDetail>() { new tblStockPDetail()
                    //                        {
                    //                            ProductID = stock.ProductID,
                    //                            Rate = stock.Rate,
                    //                            Qty = stock.Stock
                    //                        } },

                    //                SaveModel.CompanyID, SaveModel.FinPeriodID, db, res);
                    //        }
                    //    }
                    /// 
                    //--
                    try
                    {
                        db.SaveChanges();
                        res.PrimeKeyValue = SaveModel.FinPeriodID;
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

        public tblFinPeriod FindSaveModelByPrimeKey(long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblFinPeriods.Find(ID);
            }
        }

        public BeforeDeleteValidationResult ValidateBeforeDelete(long DeleteID)
        {
            BeforeDeleteValidationResult Result = new BeforeDeleteValidationResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {

                if (DeleteID == Model.CommonProperties.LoginInfo.LoggedInFinPeriod.FinPeriodID)
                {
                    Result.ValidationMessage = "Can not delete current logged in financial period. Please login other financial period to delete this.";
                }
                else
                {
                    tblFinPeriod FirstFinPer = db.tblFinPeriods.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID).OrderBy(r => r.FinPeriodFrom).FirstOrDefault();
                    tblFinPeriod LastFinPer = db.tblFinPeriods.Where(r => r.CompanyID == CommonProperties.LoginInfo.LoggedInCompany.CompanyID).OrderByDescending(r => r.FinPeriodFrom).FirstOrDefault();

                    if (DeleteID != FirstFinPer.FinPeriodID && DeleteID != LastFinPer.FinPeriodID)
                    {
                        Result.ValidationMessage = "Can not delete. Oldest or newest finacial period can be deleted.";
                    }
                    else
                    {
                        tblFinPeriod RecordToDelete = db.tblFinPeriods.FirstOrDefault(r => r.FinPeriodID == DeleteID);
                        if (RecordToDelete != null)
                        {
                            long CompanyID = RecordToDelete.CompanyID;
                            long FinPeriodID = RecordToDelete.FinPeriodID;
                            ///// Receipt
                            //List<tblReceipt> ReceiptsToDelete = db.tblReceipts.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();

                            //DAL.CashBank.ReceiptDAL RecietpDALObject = new CashBank.ReceiptDAL();
                            //foreach (tblReceipt Rec in ReceiptsToDelete)
                            //{
                            //    BeforeDeleteValidationResult ValRes = RecietpDALObject.ValidateBeforeDelete(Rec.ReceiptID);
                            //    if (!ValRes.IsValidForDelete)
                            //    {
                            //        Result.IsValidForDelete = false;
                            //        Result.ValidationMessage += "\r\nReceipt : " + ValRes.ValidationMessage;
                            //    }
                            //}

                            //// Sale 
                            //DAL.Sales.SaleInvoiceDAL SaleDALObject = new Sales.SaleInvoiceDAL();
                            //List<tblSaleInvoice> SalesToDelete = db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                            //foreach (tblSaleInvoice Rec in SalesToDelete)
                            //{
                            //    BeforeDeleteValidationResult ValRes = SaleDALObject.ValidateBeforeDelete(Rec.SaleInvoiceID);
                            //    if (!ValRes.IsValidForDelete)
                            //    {
                            //        Result.IsValidForDelete = false;
                            //        Result.ValidationMessage += "\r\nSale : " + ValRes.ValidationMessage;
                            //    }
                            //}
                        }
                    }
                }
            }
            Result.IsValidForDelete = String.IsNullOrWhiteSpace(Result.ValidationMessage);
            return Result;
        }

        public SavingResult DeleteRecord(long DeleteID)
        {
            SavingResult res = null;

            using (dbVisionEntities db = new dbVisionEntities())
            {
                res = DeleteRecord(DeleteID, db);
                if (res.ExecutionResult == eExecutionResult.ValidationError)
                {
                    return res;
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

        public SavingResult DeleteRecord(long DeleteID, dbVisionEntities db)
        {
            SavingResult res = null;
            if (DeleteID != 0)
            {
                tblFinPeriod RecordToDelete = db.tblFinPeriods.FirstOrDefault(r => r.FinPeriodID == DeleteID);

                res = DeleteRecord(RecordToDelete, db);
            }
            else
            {
                res = new SavingResult();
            }
            return res;
        }

        public SavingResult DeleteRecord(tblFinPeriod RecordToDelete, dbVisionEntities db)
        {
            SavingResult res = new SavingResult();
            if (RecordToDelete == null)
            {
                res.ValidationError = "Selected record not found. May be it has been deleted by another user over network.";
                res.ExecutionResult = eExecutionResult.ValidationError;
                return res;
            }
            else
            {
                //DateTime FinDateFrom = RecordToDelete.FinPeriodFrom;
                //DateTime? FinDateTo = RecordToDelete.FinPeriodTo.Value;
                long CompanyID = RecordToDelete.CompanyID;
                long FinPeriodID = RecordToDelete.FinPeriodID;

                ////// Sale 
                //var SaleInvoices = db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID);
                //db.tblSaleInvoiceAdditionals.RemoveRange(db.tblSaleInvoiceAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblSaleInvoiceProductDetails.RemoveRange(db.tblSaleInvoiceProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblSaleInvoices.RemoveRange(db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                //foreach (var sale in SaleInvoices)
                //{
                //    if (sale.AdvanceRecieptID != null)
                //    {
                //        db.tblReceipts.Remove(sale.tblReceipt);
                //    }
                //    if (sale.SaleQuoteID.HasValue)
                //    {
                //        tblSaleQuote SaleQuote = db.tblSaleQuotes.Find(sale.SaleQuoteID);
                //        if (SaleQuote != null)
                //        {
                //            SaleQuote.SaleInvoiceID = null;
                //            db.tblSaleQuotes.Attach(SaleQuote);
                //            db.Entry(SaleQuote).State = System.Data.Entity.EntityState.Modified;
                //        }
                //    }
                //}

                ///// Deleting Sale Invoices
                //try
                //{
                //    db.SaveChanges();
                //    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                //}
                //catch (Exception ex)
                //{
                //    CommonFunctions.GetFinalError(res, ex);
                //}
                ////DAL.Sales.SaleInvoiceDAL SaleDALObject = new Sales.SaleInvoiceDAL();
                ////List<tblSaleInvoice> SalesToDelete = db.tblSaleInvoices.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////foreach (tblSaleInvoice Rec in SalesToDelete)
                ////{
                ////    res = SaleDALObject.DeleteRecord(Rec, db);
                ////    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}

                ////// Sale Return
                //var SaleReturns = db.tblSaleReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID);
                //db.tblSaleReturnAdditionals.RemoveRange(db.tblSaleReturnAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblSaleReturnProductDetails.RemoveRange(db.tblSaleReturnProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblSaleReturns.RemoveRange(db.tblSaleReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                ////DAL.Sales.SaleReturnDAL SaleReturnDALObject = new Sales.SaleReturnDAL();
                ////List<tblSaleReturn> SaleReturnsToDelete = db.tblSaleReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////foreach (tblSaleReturn Rec in SaleReturnsToDelete)
                ////{
                ////    res = SaleReturnDALObject.DeleteRecord(Rec, db);
                ////    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}


                ////// Quotation
                //var SaleQuotes = db.tblSaleQuotes.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID);
                //db.tblSaleQuoteAdditionals.RemoveRange(db.tblSaleQuoteAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblSaleQuoteProductDetails.RemoveRange(db.tblSaleQuoteProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblSaleQuotes.RemoveRange(db.tblSaleQuotes.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                ////DAL.Sales.SaleQuoteDAL SaleQuoteDALObject = new Sales.SaleQuoteDAL();
                ////List<tblSaleQuote> SaleQuotesToDelete = db.tblSaleQuotes.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////foreach (tblSaleQuote Rec in SaleQuotesToDelete)
                ////{
                ////    res = SaleQuoteDALObject.DeleteRecord(Rec, db);
                ////    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}

                ////// PurchaseReturn Return
                //db.tblPurchaseReturnAdditionals.RemoveRange(db.tblPurchaseReturnAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblPurchaseReturnProductDetails.RemoveRange(db.tblPurchaseReturnProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblPurchaseReturns.RemoveRange(db.tblPurchaseReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                ////DAL.Purchase.PurchaseReturnDAL PurchaseReturnDALObject = new Purchase.PurchaseReturnDAL();
                ////List<tblPurchaseReturn> PurchaseReturnsToDelete = db.tblPurchaseReturns.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////foreach (tblPurchaseReturn Rec in PurchaseReturnsToDelete)
                ////{
                ////    res = PurchaseReturnDALObject.DeleteRecord(Rec, db);
                ////    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}

                ////// Purchase
                //db.tblPurchaseBillAdditionals.RemoveRange(db.tblPurchaseBillAdditionals.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblPurchaseBillProductDetails.RemoveRange(db.tblPurchaseBillProductDetails.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                //db.tblPurchaseBills.RemoveRange(db.tblPurchaseBills.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                ////DAL.Purchase.PurchaseInvoiceDAL PurchaseDALObject = new Purchase.PurchaseInvoiceDAL();
                ////List<tblPurchase> PurchasesToDelete = db.tblPurchaseBills.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////foreach (tblPurchase Rec in PurchasesToDelete)
                ////{
                ////    res = PurchaseDALObject.DeleteRecord(Rec, db);
                ////    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}


                ///// Receipt
                //db.tblReceipts.RemoveRange(db.tblReceipts.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                ////List<tblReceipt> ReceiptsToDelete = db.tblReceipts.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////DAL.Receipt.ReceiptDAL RecietpDALObject = new Receipt.ReceiptDAL();
                ////foreach (tblReceipt Rec in ReceiptsToDelete)
                ////{
                ////    res = RecietpDALObject.DeleteRecord(Rec, db);
                ////    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}


                ///// Payment
                //db.tblPayments.RemoveRange(db.tblPayments.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                ////List<tblPayment> PaymentsToDelete = db.tblPayments.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////DAL.Payment.PaymentDAL RecietpDALObject = new Payment.PaymentDAL();
                ////foreach (tblPayment Rec in PaymentsToDelete)
                ////{
                ////    res = RecietpDALObject.DeleteRecord(Rec, db);
                ////    if (res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}


                ////-- Account Balances
                //db.tblAccountBalances.RemoveRange(db.tblAccountBalances.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                ////// Inventory 
                //db.tblStockPDetails.RemoveRange(db.tblStockPDetails.Where(r => r.tblStock.CompanyID == CompanyID && r.tblStock.FinPeriodID == FinPeriodID));
                //db.tblStocks.RemoveRange(db.tblStocks.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                ///// Product Stock
                //db.tblProductStocks.RemoveRange(db.tblProductStocks.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));

                ////// Opening Balance
                //db.tblAccountOpeningBalances.RemoveRange(db.tblAccountOpeningBalances.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID));
                ////DAL.Account.AccountOpeningBalanceDAL OpeningBalanceDALObject = new Account.AccountOpeningBalanceDAL();
                ////List<tblAccountOpeningBalance> OpeningBalancesToDelete = db.tblAccountOpeningBalances.Where(r => r.CompanyID == CompanyID && r.FinPeriodID == FinPeriodID).ToList();
                ////foreach (tblAccountOpeningBalance Rec in OpeningBalancesToDelete)
                ////{
                ////    res = OpeningBalanceDALObject.DeleteRecord(Rec, db);
                ////    if(res.ExecutionResult == eExecutionResult.ErrorWhileExecuting || res.ExecutionResult == eExecutionResult.ValidationError)
                ////    {
                ////        return res;
                ////    }
                ////}



                ////// deleting all transactions
                ////if (res.ExecutionResult == eExecutionResult.ValidationError)
                ////{
                ////    return res;
                ////}

                //// Deleting sms Log
                //db.tblSMSLogs.RemoveRange(db.tblSMSLogs.Where(r => r.SendDateTime >= RecordToDelete.FinPeriodFrom && r.SendDateTime <= RecordToDelete.FinPeriodTo));

                //try
                //{
                //    db.SaveChanges();
                //    res.ExecutionResult = eExecutionResult.CommitedSucessfuly;
                //}
                //catch (Exception ex)
                //{
                //    CommonFunctions.GetFinalError(res, ex);
                //}


                /// Financial Year record removed here but will be committed from where it was called.
                /// Remove Fin Period
                //db.tblFinPeriods.Remove(RecordToDelete);
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                RecordToDelete.rstate = RecordState_Deleted;
                db.tblFinPeriods.Attach(RecordToDelete);
                db.Entry(RecordToDelete).State = System.Data.Entity.EntityState.Modified;
            }
            return res;
        }

        public SavingResult Authorize(long ID)
        {
            SavingResult res = new SavingResult();
            using (dbVisionEntities db = new dbVisionEntities())
            {
                var rec = db.tblFinPeriods.FirstOrDefault(r => r.FinPeriodID == ID);
                rec.rstate = (byte)eRecordState.Authorized;
                db.tblFinPeriods.Attach(rec);
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
                var rec = db.tblFinPeriods.FirstOrDefault(r => r.FinPeriodID == ID);
                rec.rstate = (byte)eRecordState.Active;
                db.tblFinPeriods.Attach(rec);
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

        public List<FinPeriodEditListModel> GetEditList(long CompanyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                byte RecordState_Deleted = (byte)eRecordState.Deleted;
                return (from r in db.tblFinPeriods

                        join joinrcu in db.tblUsers on r.rcuid equals joinrcu.UserID into grcu
                        from rcu in grcu.DefaultIfEmpty()

                        join joinreu in db.tblUsers on r.reuid equals joinreu.UserID into greu
                        from reu in greu.DefaultIfEmpty()

                        where r.CompanyID == CompanyID && r.rstate != RecordState_Deleted

                        orderby r.FinPeriodFrom descending

                        select new FinPeriodEditListModel()
                        {
                            FinPeriodID = r.FinPeriodID,
                            FinPeriodName = r.FinPeriodName,
                            FinPeriodFrom = r.FinPeriodFrom,
                            FinPeriodTo = r.FinPeriodTo,

                            RecordState = (eRecordState)r.rstate,
                            CreatedDateTime = r.rcdt,
                            EditedDateTime = r.redt,
                            CreatedUserID = r.rcuid,
                            EditedUserID = r.reuid,
                            CreatedUserName = (rcu != null ? rcu.UserName : ""),
                            EditedUserName = (reu != null ? reu.UserName : ""),
                        }).ToList();
            }
        }

        public FinPeriodDetailModel GetDetailModel(long FinPeriodID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblFinPeriod r = db.tblFinPeriods.FirstOrDefault(r1 => r1.FinPeriodID == FinPeriodID);
                if (r == null) return null;
                else
                {
                    return ConvertToDetailModel(r);
                }
            }
        }

        public static FinPeriodDetailModel GetFirstFinPeriod(long CompanyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblFinPeriod r = db.tblFinPeriods.FirstOrDefault(r1 => r1.CompanyID == CompanyID);
                if (r == null) return null;
                else
                {
                    return ConvertToDetailModel(r);
                }
            }
        }

        public bool IsDuplicateRecord(string FinPeriodName, long ID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return IsDuplicateRecord(FinPeriodName, ID, db);
            }
        }

        public bool IsDuplicateRecord(string FinPeriodName, long ID, dbVisionEntities db)
        {
            if (db.tblFinPeriods.FirstOrDefault(i => i.FinPeriodName == FinPeriodName && i.FinPeriodID != ID) != null)
            {
                return true;
            }
            return false;
        }

        public FinPeriodDetailModel GetLatestFinPeriod(long CompanyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblFinPeriod Ses = db.tblFinPeriods.Where(r => r.CompanyID == CompanyID).OrderByDescending(r => r.FinPeriodFrom).FirstOrDefault();
                if (Ses == null) return null;
                else
                {
                    return ConvertToDetailModel(Ses);
                }
            }
        }

        public FinPeriodDetailModel GetPreviousFinPeriod(long CompanyID, DateTime FinPerFrom)
        {
            FinPerFrom = FinPerFrom.Date;
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblFinPeriod Ses = db.tblFinPeriods.Where(r => r.CompanyID == CompanyID && r.FinPeriodTo < FinPerFrom).OrderByDescending(r => r.FinPeriodFrom).FirstOrDefault();
                if (Ses == null) return null;
                else
                {
                    return ConvertToDetailModel(Ses);
                }
            }
        }

        public FinPeriodDetailModel GetNextFinPeriod(long CompanyID, DateTime FinPerTo)
        {
            FinPerTo = FinPerTo.Date;
            using (dbVisionEntities db = new dbVisionEntities())
            {
                tblFinPeriod Ses = db.tblFinPeriods.Where(r => r.CompanyID == CompanyID && r.FinPeriodFrom > FinPerTo).OrderBy(r => r.FinPeriodFrom).FirstOrDefault();
                if (Ses == null) return null;
                else
                {
                    return ConvertToDetailModel(Ses);
                }
            }
        }

        public static FinPeriodDetailModel ConvertToDetailModel(tblFinPeriod Ses)
        {
            return new FinPeriodDetailModel()
            {
                FinPeriodID = Ses.FinPeriodID,
                FinPeriodName = Ses.FinPeriodName,
                FinPeriodFrom = Ses.FinPeriodFrom,
                FinPeriodTo = Ses.FinPeriodTo,
                CompanyID = Ses.CompanyID
            };
        }

        public static int FinPeriodsCount(long CompanyID)
        {
            using (dbVisionEntities db = new dbVisionEntities())
            {
                return db.tblFinPeriods.Count(r => r.CompanyID == CompanyID);
            }
        }

        public async Task<List<AccountClosingBalanceViewModel>> GetAccountClosingBalance(long CompanyID, long FinPeriodID)
        {
            return await Task.Run<List<AccountClosingBalanceViewModel>>(() =>
            {
                return new List<AccountClosingBalanceViewModel>();
            });
            //return await Task.Run<List<AccountClosingBalanceViewModel>>(() =>
            //{
            //    using (dbVisionEntities db = new dbVisionEntities())
            //    {
            //        var summed = from ld in db.tblLedgerDetails
            //                              join l in db.tblLedgers on ld.LedgerID equals l.LedgerID
            //                              where l.CompanyID == CompanyID && l.FinPeriodID == FinPeriodID
            //                              group ld by ld.AccountID into gr
            //                              select new { AccountID = gr.Key, Amt = gr.Sum(r => r.Amount) };

            //        var res = from Account in db.tblAccounts
            //                  join joincity in db.tblCities on Account.CityID equals joincity.CityID into gcity
            //                  from city in gcity.DefaultIfEmpty()
            //                  join joinstate in db.tblStates on city.StateID equals joinstate.StateID into gstate
            //                  from state in gstate.DefaultIfEmpty()
            //                  join joincountry in db.tblCountries on state.CountryID equals joincountry.CountryID into gcountry
            //                  from country in gcountry.DefaultIfEmpty()
            //                  join joinsum in summed on Account.AccountID equals joinsum.AccountID into gsum
            //                  from sum in gsum.DefaultIfEmpty()
            //                  orderby Account.AccountNo
            //                  select
            //                   new AccountClosingBalanceViewModel()
            //                   {
            //                       AccountID = Account.AccountID,
            //                       AccountNo = Account.AccountNo,
            //                       AccountName = Account.AccountName,
            //                       CompanyName = Account.CustomerCompanyName,
            //                       Address = Account.Address,
            //                       City = (city != null ? city.CityName : ""),
            //                       MobileNo = Account.MobileNo,
            //                       OpeningBalance = (sum != null? sum.Amt : 0)
            //                   };
            //        return res.ToList();
            //    }
            //});
        }

        public decimal GetAccountClosingBalance(long AccountID, DateTime UptoDate, long CompanyID, long FinPeriodID)
        {
            return 0;
            //UptoDate = UptoDate.Date.Add(new TimeSpan(23, 59, 59));

            //using (dbVisionEntities db = new dbVisionEntities())
            //{
            //    var OpeningBalance = from ob in db.tblAccountOpeningBalances
            //                where ob.CompanyID == CompanyID &&
            //                ob.FinPeriodID == FinPeriodID &&
            //                ob.AccountID == AccountID &&
            //                ob.OpeningBalanceDate <= UptoDate
            //                select new { AccountID = ob.AccountID, Amt = ob.OpeningBalanceAmt };

            //    var sale = from s in db.tblSaleInvoices
            //               where s.CompanyID == CompanyID &&
            //               s.FinPeriodID == FinPeriodID &&
            //               s.AccountID == AccountID &&
            //               s.SaleInvoiceDate <= UptoDate
            //               group s by s.AccountID into gs
            //               let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
            //               select new { AccountID = gs.Key, Amt = Amt };

            //    var salereturn = from s in db.tblSaleReturns
            //                     where s.CompanyID == CompanyID &&
            //                     s.FinPeriodID == FinPeriodID &&
            //                     s.AccountID == AccountID &&
            //                     s.SaleReturnDate <= UptoDate
            //                     group s by s.AccountID into gs
            //                     let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
            //                     select new { AccountID = gs.Key, Amt = -Amt };

            //    var purchase = from s in db.tblPurchaseBills
            //                   where s.CompanyID == CompanyID &&
            //                   s.FinPeriodID == FinPeriodID &&
            //                   s.AccountID == AccountID &&
            //                   s.PurchaseBillDate <= UptoDate
            //                   group s by s.AccountID into gs
            //                   let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
            //                   select new { AccountID = gs.Key, Amt = -Amt };

            //    var purchaseReturn = from s in db.tblPurchaseReturns
            //                         where s.CompanyID == CompanyID &&
            //                         s.FinPeriodID == FinPeriodID &&
            //                         s.AccountID == AccountID &&
            //                         s.PurchaseReturnDate <= UptoDate
            //                         group s by s.AccountID into gs
            //                         let Amt = gs.Sum(gr => (decimal?)gr.NetAmt) ?? 0
            //                         select new { AccountID = gs.Key, Amt = Amt };

            //    var Reciepts = from s in db.tblReceipts
            //                   where s.CompanyID == CompanyID &&
            //                   s.FinPeriodID == FinPeriodID &&
            //                   s.AccountID == AccountID &&
            //                   s.ReceiptDate <= UptoDate
            //                   group s by s.AccountID into gs
            //                   let Amt = gs.Sum(gr => (decimal?)gr.Amount) ?? 0
            //                   select new { AccountID = gs.Key, Amt = -Amt };

            //    var Payments = from s in db.tblPayments
            //                   where s.CompanyID == CompanyID &&
            //                   s.FinPeriodID == FinPeriodID &&
            //                   s.AccountID == AccountID &&
            //                   s.PaymentDate <= UptoDate
            //                   group s by s.AccountID into gs
            //                   let Amt = gs.Sum(gr => (decimal?)gr.Amount) ?? 0
            //                   select new { AccountID = gs.Key, Amt = Amt };

            //    var allTransactions = OpeningBalance.Concat(sale).Concat(salereturn).Concat(purchase).Concat(purchaseReturn).Concat(Reciepts).Concat(Payments);

            //    var summed = from s in allTransactions
            //                 where s.AccountID == AccountID
            //                 group s by s.AccountID into gs
            //                 let Amt = gs.Sum(gr => (decimal?)gr.Amt) ?? 0
            //                 select new { AccountID = gs.Key, Amt = Amt };

            //    return summed.Sum(r => (decimal?)r.Amt) ?? 0;
            //}
        }
    }
}
