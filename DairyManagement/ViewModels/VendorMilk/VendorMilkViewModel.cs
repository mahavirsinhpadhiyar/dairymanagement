using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DairyManagement.ViewModels.VendorMilk
{
    public class VendorMilkViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }
        [Display(Name = "Milk Type")]
        public string MilkType { get; set; }
        [Display(Name = "Please select Vendor")]
        public Nullable<int> VendorId { get; set; }
        [Display(Name = "Please select Milk Type")]
        public Nullable<int> MilkTypeId { get; set; }
        [Display(Name = "Milk Value(In Litre)")]
        [Required(ErrorMessage = "Please enter Milk Value")]
        public Nullable<decimal> MilkValue { get; set; }
        [Display(Name = "Fate Value")]
        [Required(ErrorMessage = "Please enter Fate Value")]
        public Nullable<decimal> FatValue { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        [Display(Name = "Price (Per Litre)")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Total { get; set; }
        [Display(Name = "પૈસા ચૂકવ્યા")]
        public bool MoneyPaid { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Updated By")]
        public string UpdateBy { get; set; }
        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate { get; set; }
        [Display(Name = "Updated Date")]
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public List<SelectListItem> VendorList { get; set; }
        public List<SelectListItem> MilkTypeList { get; set; }
    }
}