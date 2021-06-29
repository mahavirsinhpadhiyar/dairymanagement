using DairyManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DairyManagement.ViewModels.EmployeeToCustomerMilk
{
    public class EmpToCustMilkVM
    {
        public int Id { get; set; }
        [Display(Name = "Milk Type")]
        public Enums.CustomerMilkType MilkType { get; set; }
        [Display(Name = "Milk Value")]
        public decimal MilkGiven { get; set; }
        [Display(Name = "તારીખ")]
        public DateTime Date { get; set; }
        [Display(Name = "Customer")]
        public Nullable<int> CustomerId { get; set; }
        [Display(Name = "Employee")]
        public Nullable<int> EmployeeId { get; set; }
        public List<SelectListItem> CustomerInfoList { get; set; }
        public List<SelectListItem> EmployeeInfoList { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
    }
}