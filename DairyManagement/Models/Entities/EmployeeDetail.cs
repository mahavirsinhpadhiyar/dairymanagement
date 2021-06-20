using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DairyManagement.Models.Entities
{
    public class EmployeeDetail : Generic
    {
        public EmployeeDetail()
        {
            this.EmployeeVaaraDetails = new HashSet<EmployeeVaaraDetail>();
        }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public virtual ICollection<EmployeeVaaraDetail> EmployeeVaaraDetails { get; set; }
    }
}