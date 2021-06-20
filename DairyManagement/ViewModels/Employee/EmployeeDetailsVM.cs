using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DairyManagement.ViewModels.Employee
{
    public class EmployeeDetailsVM
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter number")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}