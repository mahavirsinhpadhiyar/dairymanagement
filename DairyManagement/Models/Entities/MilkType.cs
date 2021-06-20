using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyManagement.Models.Entities
{
    public class MilkType : Generic
    {
        public MilkType()
        {
            this.VendorMilkInfoes = new HashSet<VendorMilkInfo>();
        }
        public string MilkType1 { get; set; }

        [ForeignKey("UserInfo")]
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

        [ForeignKey("UserInfo1")]
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public virtual UserInfo UserInfo { get; set; }
        public virtual UserInfo UserInfo1 { get; set; }
        public virtual ICollection<VendorMilkInfo> VendorMilkInfoes { get; set; }
    }
}