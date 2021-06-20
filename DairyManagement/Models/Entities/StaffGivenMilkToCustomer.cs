using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DairyManagement.Models.Entities
{
    public class StaffGivenMilkToCustomer: Generic
    {
        public Enums.CustomerMilkType MilkType { get; set; }
        public decimal MilkGiven { get; set; }
        public DateTime Date { get; set; }

        //Foreign key for Customer Info


        [ForeignKey("CustomerInfo")]
        public Nullable<int> CustomerId { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }

        //Foreign key for Employee Detail

        [ForeignKey("EmployeeDetail")]
        public Nullable<int> EmployeeId { get; set; }
        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}