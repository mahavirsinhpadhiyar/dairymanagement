using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyManagement.Models.Entities
{
    public class AccountDetail : Generic
    {
        public AccountDetail()
        {
            this.AccountDetailsLastRealStocks = new HashSet<AccountDetailsLastRealStock>();
            this.AccountSPs = new HashSet<AccountSP>();
        }
        public Nullable<decimal> OldStock { get; set; }
        public Nullable<decimal> TodayMilk { get; set; }
        public Nullable<decimal> TotalPurchase { get; set; }
        public Nullable<decimal> TotalSell { get; set; }
        public Nullable<decimal> AvailableStock { get; set; }
        public Nullable<decimal> RealStock { get; set; }
        public Nullable<decimal> StockDifference { get; set; }
        public Nullable<System.DateTime> AccountDateTime { get; set; }
        public string TodayMilkNote { get; set; }
        public string TotalPurchaseNote { get; set; }
        public string TotalSellNote { get; set; }
        public string AvailableStockNote { get; set; }
        public string RealStockNote { get; set; }
        public string StockDifferenceNote { get; set; }
        public Nullable<bool> ConsiderOldStock { get; set; }

        //Foreign key for Vendor Info
        [ForeignKey("VendorInfo")]
        public Nullable<int> VendorId { get; set; }
        public virtual VendorInfo VendorInfo { get; set; }

        public virtual ICollection<AccountDetailsLastRealStock> AccountDetailsLastRealStocks { get; set; }
        public virtual ICollection<AccountSP> AccountSPs { get; set; }
    }
}