//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DairyManagement.Models.LiveDBEDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountDetail()
        {
            this.AccountSPs = new HashSet<AccountSP>();
        }
    
        public int Id { get; set; }
        public Nullable<decimal> OldStock { get; set; }
        public Nullable<decimal> TodayMilk { get; set; }
        public Nullable<decimal> TotalPurchase { get; set; }
        public Nullable<decimal> TotalSell { get; set; }
        public Nullable<decimal> AvailableStock { get; set; }
        public Nullable<decimal> RealStock { get; set; }
        public Nullable<decimal> StockDifference { get; set; }
        public Nullable<int> VendorId { get; set; }
        public Nullable<System.DateTime> AccountDateTime { get; set; }
        public string TodayMilkNote { get; set; }
        public string TotalPurchaseNote { get; set; }
        public string TotalSellNote { get; set; }
        public string AvailableStockNote { get; set; }
        public string RealStockNote { get; set; }
        public string StockDifferenceNote { get; set; }
        public Nullable<bool> ConsiderOldStock { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountSP> AccountSPs { get; set; }
        public virtual VendorInfo VendorInfo { get; set; }
    }
}
