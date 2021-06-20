using System;
using System.ComponentModel.DataAnnotations;

namespace DairyManagement.ViewModels.Customer
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Number")]
        [Required(ErrorMessage = "Please enter number")]
        public string CustomerPhoneNumber { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter Address")]
        public string CustomerAddress { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}