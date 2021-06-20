using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyManagement.Models.Entities
{
    public class EmployeeVaaraDetail : Generic
    {
        public Nullable<decimal> MilkValue { get; set; }
        public Nullable<System.DateTime> VaaraDateTime { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        //Foreign key for Employee Detail
        [ForeignKey("EmployeeDetail")]
        public Nullable<int> EmployeeId { get; set; }
        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}