using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyManagement.Models.Entities
{
    public class VendorMilkInfo: Generic
    {
        public Nullable<decimal> MilkValue { get; set; }
        public Nullable<decimal> FatValue { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public virtual UserInfo UserInfo1 { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public bool MoneyPaid { get; set; }

        //Foreign key for Vendor Info

        [ForeignKey("VendorInfo")]
        public Nullable<int> VendorId { get; set; }
        public virtual VendorInfo VendorInfo { get; set; }

        //Foreign key for Milk Type

        [ForeignKey("MilkType")]
        public Nullable<int> MilkTypeId { get; set; }
        public virtual MilkType MilkType { get; set; }
    }
}