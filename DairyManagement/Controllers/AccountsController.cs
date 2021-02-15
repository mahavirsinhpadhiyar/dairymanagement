using DairyManagement.Infrastructure;
using DairyManagement.Models.LiveDBEDMX;
using DairyManagement.ViewModels.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DairyManagement.Controllers
{
    [CustomAuthorize]
    public class AccountsController : HandleExceptionController
    {
        private dairymanagementEntities db = new dairymanagementEntities();
        protected DateTime YesterdayStartTime;
        protected DateTime YesterdayEndTime;
        // GET: Accounts
        public ActionResult Index(string Message)
        {
            AccountsVM accountsVM = new AccountsVM();
            accountsVM.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
            {
                Text = m.VendorName,
                Value = m.Id.ToString()
            }).ToList();
            if (!string.IsNullOrEmpty(Message))
            {
                ViewBag.Message = Message;
            }
            accountsVM.SPs = new List<AccountsVMSP>();

            //DateTime tempDateTime = DateTime.Now;
            //List<AccountDetail> OldStockDetails = new List<AccountDetail>();

            //if (db.AccountDetails.Count() > 0)
            //{
            //    tempDateTime = Convert.ToDateTime(db.AccountDetails.OrderByDescending(o => o.Id).FirstOrDefault().AccountDateTime);

            //    //To not consider without old stock entry for realstock
            //    if(tempDateTime.Date == DateTime.Today)
            //    {
            //        tempDateTime = tempDateTime.Date.AddDays(-1);
            //    }

            //    YesterdayStartTime = new DateTime(tempDateTime.Year, tempDateTime.Month, tempDateTime.Day, 0, 0, 0);
            //    YesterdayEndTime = new DateTime(tempDateTime.Year, tempDateTime.Month, tempDateTime.Day, 23, 59, 59);
            //}
            //else
            //{
            //    YesterdayStartTime = new DateTime(tempDateTime.Year, tempDateTime.Month, tempDateTime.Day - 1, 0, 0, 0);
            //    YesterdayEndTime = new DateTime(tempDateTime.Year, tempDateTime.Month, tempDateTime.Day - 1, 23, 59, 59);
            //}

            //OldStockDetails = db.AccountDetails.Where(u => u.AccountDateTime < YesterdayEndTime && u.AccountDateTime > YesterdayStartTime && u.ConsiderOldStock == true).ToList();

            //if (OldStockDetails!= null && OldStockDetails.Count() > 0)
            //{
            //    foreach (var item in OldStockDetails)
            //    {
            //        accountsVM.OldStock += Convert.ToDecimal(item.RealStock);
            //    }
            //}

            accountsVM.OldStock = Convert.ToDecimal(db.AccountDetailsLastRealStocks.FirstOrDefault()?.RealStock);
            return View(accountsVM);
        }
        public ActionResult partialAddSP(int? i, AccountsVMSP accountsVMSP)
        {
            ViewBag.i = i;
            return PartialView("_AddSP", accountsVMSP);
        }
        [HttpPost]
        public ActionResult Index(AccountsVM accountsVM, FormCollection collection)
        {
            try
            {
                accountsVM.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
                {
                    Text = m.VendorName,
                    Value = m.Id.ToString()
                }).ToList();
                if (ModelState.IsValid)
                {
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            AccountDetail ac = new AccountDetail();
                            ac.AccountDateTime = accountsVM.AccountDateTime;
                            ac.AvailableStock = accountsVM.AvailableStock;
                            ac.AvailableStockNote = accountsVM.AvailableStockNote;
                            ac.OldStock = accountsVM.OldStock;
                            ac.RealStock = accountsVM.RealStock;
                            ac.RealStockNote = accountsVM.RealStockNote;
                            ac.StockDifference = accountsVM.StockDifference;
                            ac.StockDifferenceNote = accountsVM.StockDifferenceNote;
                            ac.TodayMilk = accountsVM.TodayMilk;
                            ac.TodayMilkNote = accountsVM.TodayMilkNote;
                            ac.TotalPurchase = accountsVM.TotalPurchase;
                            ac.TotalPurchaseNote = accountsVM.TotalPurchaseNote;
                            ac.TotalSell = accountsVM.TotalSell;
                            ac.TotalSellNote = accountsVM.TotalSellNote;
                            ac.VendorId = accountsVM.VendorId;
                            ac.ConsiderOldStock = accountsVM.ConsiderOldStock;

                            db.AccountDetails.Add(ac);
                            if (db.SaveChanges() > 0)
                            {
                                List<AccountSP> accountVMSPs = AddUpdateAccountSPs(collection, ac.Id);
                                if (accountVMSPs.Count() > 0)
                                {
                                    db.AccountSPs.AddRange(accountVMSPs);
                                    if (db.SaveChanges() > 0)
                                    {
                                        if (accountsVM.ConsiderOldStock)
                                        {
                                            AddUpdateRealStock(ac, false);
                                        }
                                        transaction.Commit();
                                    }
                                }

                                return RedirectToAction("ListAccounts");
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                    return View(accountsVM);
                }
                else
                {
                    if (accountsVM.SPs == null)
                    {
                        accountsVM.SPs = new List<AccountsVMSP>();
                    }
                    return View(accountsVM);
                }
            }
            catch (System.Exception ex)
            {
            }
            return View(accountsVM);
        }
        public ActionResult ListAccounts()
        {
            List<AccountsVMs> accountsVMs = new List<AccountsVMs>();

            accountsVMs = db.AccountDetails.ToList().OrderByDescending(d => d.AccountDateTime).ThenByDescending(d => d.ConsiderOldStock).Select(d => new AccountsVMs()
            {
                AccountDateTime = Convert.ToDateTime(d.AccountDateTime).ToString("dd/MM/yyyy"),
                AccountId = d.Id,
                AvailableStock = d.AvailableStock,
                OldStock = d.OldStock,
                RealStock = d.RealStock,
                StockDifference = d.StockDifference,
                TodayMilk = d.TodayMilk,
                TotalPurchase = d.TotalPurchase,
                TotalSell = d.TotalSell,
                VendorName = d.VendorInfo.VendorName
            }).ToList();

            return View(accountsVMs);
        }
        public ActionResult Edit(int Id)
        {
            if (Id == 0)
            {
                return RedirectToAction("ListAccounts");
            }
            else
            {
                AccountsVM accountsVM = new AccountsVM();

                var accountDetail = db.AccountDetails.FirstOrDefault(d => d.Id == Id);
                if (accountDetail != null)
                {
                    accountsVM.AccountDateTime = Convert.ToDateTime(accountDetail.AccountDateTime);
                    accountsVM.AccountId = accountDetail.Id;
                    accountsVM.AvailableStock = Convert.ToDecimal(accountDetail.AvailableStock);
                    accountsVM.AvailableStockNote = accountDetail.AvailableStockNote;
                    accountsVM.ConsiderOldStock = Convert.ToBoolean(accountDetail.ConsiderOldStock);
                    accountsVM.OldStock = Convert.ToDecimal(accountDetail.OldStock);
                    accountsVM.RealStock = Convert.ToDecimal(accountDetail.RealStock);
                    accountsVM.RealStockNote = accountDetail.RealStockNote;
                    accountsVM.StockDifference = Convert.ToDecimal(accountDetail.StockDifference);
                    accountsVM.StockDifferenceNote = accountDetail.StockDifferenceNote;
                    accountsVM.TodayMilk = Convert.ToDecimal(accountDetail.TodayMilk);
                    accountsVM.TodayMilkNote = accountDetail.TodayMilkNote;
                    accountsVM.TotalPurchase = Convert.ToDecimal(accountDetail.TotalPurchase);
                    accountsVM.TotalPurchaseNote = accountDetail.TotalPurchaseNote;
                    accountsVM.TotalSell = Convert.ToDecimal(accountDetail.TotalSell);
                    accountsVM.TotalSellNote = accountDetail.TotalSellNote;
                    accountsVM.VendorId = Convert.ToInt32(accountDetail.VendorId);
                    accountsVM.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
                    {
                        Text = m.VendorName,
                        Value = m.Id.ToString()
                    }).ToList();
                    accountsVM.SPs = db.AccountSPs.Where(d => d.AccountId == accountsVM.AccountId).ToList().Select(d => new AccountsVMSP()
                    {
                        SPNote = d.SPNote,
                        SPValue = Convert.ToDecimal(d.SPValue)
                    }).ToList();
                }
                else
                {
                    return RedirectToAction("ListAccounts");
                }
                return View("Index", accountsVM);
            }
        }
        [HttpPost]
        public ActionResult Edit(AccountsVM accountsVM, FormCollection collection)
        {
            try
            {
                accountsVM.VendorList = db.VendorInfoes.ToList().Select(m => new SelectListItem()
                {
                    Text = m.VendorName,
                    Value = m.Id.ToString()
                }).ToList();
                if (ModelState.IsValid)
                {
                    if (accountsVM.AccountId == 0)
                    {

                    }
                    using (DbContextTransaction transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            AccountDetail ac = new AccountDetail();
                            ac.AccountDateTime = accountsVM.AccountDateTime;
                            ac.AvailableStock = accountsVM.AvailableStock;
                            ac.AvailableStockNote = accountsVM.AvailableStockNote;
                            ac.OldStock = accountsVM.OldStock;
                            ac.RealStock = accountsVM.RealStock;
                            ac.RealStockNote = accountsVM.RealStockNote;
                            ac.StockDifference = accountsVM.StockDifference;
                            ac.StockDifferenceNote = accountsVM.StockDifferenceNote;
                            ac.TodayMilk = accountsVM.TodayMilk;
                            ac.TodayMilkNote = accountsVM.TodayMilkNote;
                            ac.TotalPurchase = accountsVM.TotalPurchase;
                            ac.TotalPurchaseNote = accountsVM.TotalPurchaseNote;
                            ac.TotalSell = accountsVM.TotalSell;
                            ac.TotalSellNote = accountsVM.TotalSellNote;
                            ac.VendorId = accountsVM.VendorId;
                            ac.ConsiderOldStock = accountsVM.ConsiderOldStock;

                            db.AccountDetails.Add(ac);
                            if (db.SaveChanges() > 0)
                            {
                                List<AccountSP> accountVMSPs = AddUpdateAccountSPs(collection, ac.Id);
                                if (accountVMSPs.Count() > 0)
                                {
                                    db.AccountSPs.AddRange(accountVMSPs);
                                    if (db.SaveChanges() > 0)
                                    {
                                        if (accountsVM.ConsiderOldStock)
                                        {
                                            AddUpdateRealStock(ac, true);
                                        }
                                        transaction.Commit();
                                    }
                                }

                                return RedirectToAction("Index");
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                    return View(accountsVM);
                }
                else
                {
                    if (accountsVM.SPs == null)
                    {
                        accountsVM.SPs = new List<AccountsVMSP>();
                    }
                    return View(accountsVM);
                }
            }
            catch (System.Exception ex)
            {
            }
            return View(accountsVM);
        }
        private List<AccountSP> AddUpdateAccountSPs(FormCollection collection, int AccountId)
        {

            //Delete if already associated with entered account
            //Starts:
            List<AccountSP> alreadyExistAccountSPs = new List<AccountSP>();
            alreadyExistAccountSPs = db.AccountSPs.Where(d => d.AccountId == AccountId).ToList();
            if (alreadyExistAccountSPs.Count() > 0)
            {
                db.AccountSPs.RemoveRange(alreadyExistAccountSPs);
            }
            //End:
            //Delete if already associated with entered account

            List<AccountSP> accountSPs = new List<AccountSP>();
            foreach (var key in collection.AllKeys)
            {
                if (key.Contains("SPValue") && !key.Contains("Note"))
                {
                    accountSPs.Add(new AccountSP()
                    {
                        AccountId = AccountId,
                        SPValue = Convert.ToDecimal(collection[key]),
                        SPNote = collection[key + "Note"]
                    });
                }
            }

            return accountSPs;
        }
        private AccountDetailsLastRealStock AddUpdateRealStock(AccountDetail ac, bool IsAccountEdit)
        {
            AccountDetailsLastRealStock accountDetailsLastRealStock = new AccountDetailsLastRealStock();
            if (!IsAccountEdit)
            {
                accountDetailsLastRealStock = db.AccountDetailsLastRealStocks.FirstOrDefault();
                bool isExist = false;

                if (accountDetailsLastRealStock == null)
                {
                    accountDetailsLastRealStock = new AccountDetailsLastRealStock();
                }
                else
                    isExist = true;

                accountDetailsLastRealStock.RealStock = ac.RealStock;
                accountDetailsLastRealStock.AccountDate = ac.AccountDateTime;
                accountDetailsLastRealStock.AccountId = ac.Id;

                if (!isExist)
                    db.AccountDetailsLastRealStocks.Add(accountDetailsLastRealStock);

                db.SaveChanges();
            }
            else
            {
                //if condition check if last entry and consider as old stock is edit
                if (db.AccountDetails.LastOrDefault().Id == ac.Id)
                {
                    accountDetailsLastRealStock = db.AccountDetailsLastRealStocks.FirstOrDefault();
                    if (accountDetailsLastRealStock == null)
                    {
                        accountDetailsLastRealStock = new AccountDetailsLastRealStock();
                    }

                    accountDetailsLastRealStock.RealStock = ac.RealStock;
                    accountDetailsLastRealStock.AccountDate = ac.AccountDateTime;
                    accountDetailsLastRealStock.AccountId = ac.Id;

                    db.SaveChanges();
                }
            }

            return accountDetailsLastRealStock;
        }
    }
}