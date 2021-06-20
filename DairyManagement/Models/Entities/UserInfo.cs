using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DairyManagement.Models.Entities
{
    public class UserInfo : Generic
    {
        public UserInfo()
        {
            this.MilkTypes = new HashSet<MilkType>();
            this.MilkTypes1 = new HashSet<MilkType>();
            this.VendorInfoes = new HashSet<VendorInfo>();
            this.VendorInfoes1 = new HashSet<VendorInfo>();
            this.VendorMilkInfoes = new HashSet<VendorMilkInfo>();
            this.VendorMilkInfoes1 = new HashSet<VendorMilkInfo>();
        }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual ICollection<MilkType> MilkTypes { get; set; }
        public virtual ICollection<MilkType> MilkTypes1 { get; set; }
        public virtual ICollection<VendorInfo> VendorInfoes { get; set; }
        public virtual ICollection<VendorInfo> VendorInfoes1 { get; set; }
        public virtual ICollection<VendorMilkInfo> VendorMilkInfoes { get; set; }
        public virtual ICollection<VendorMilkInfo> VendorMilkInfoes1 { get; set; }
    }
}