using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyManagement.Models.Entities
{
    public class EmployeeSalary : Generic
    {
        public decimal Salary { get; set; }
        public string Date { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        //Foreign key for Employee Detail
        [ForeignKey("EmployeeDetail")]
        public int EmployeeId { get; set; }
        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}