using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyManagement.Models.Entities
{
    public class VendorInfo : Generic
    {
        public VendorInfo()
        {
            this.AccountDetails = new HashSet<AccountDetail>();
            this.VendorMilkInfoes = new HashSet<VendorMilkInfo>();
        }
        public string VendorName { get; set; }
        public string LocationName { get; set; }

        [ForeignKey("UserInfo")]
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

        [ForeignKey("UserInfo1")]
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
        public virtual UserInfo UserInfo { get; set; }
        public virtual UserInfo UserInfo1 { get; set; }
        public virtual ICollection<VendorMilkInfo> VendorMilkInfoes { get; set; }
    }
}