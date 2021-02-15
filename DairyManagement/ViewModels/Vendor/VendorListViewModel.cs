using System;
using System.ComponentModel.DataAnnotations;

namespace DairyManagement.ViewModels.Vendor
{
    public class VendorListViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Updated By")]
        public string UpdateBy { get; set; }
        [Display(Name = "Created On")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Updated On")]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}