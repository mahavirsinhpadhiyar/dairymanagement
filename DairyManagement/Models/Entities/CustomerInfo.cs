using System;
using System.ComponentModel.DataAnnotations;

namespace DairyManagement.Models.Entities
{
    public class CustomerInfo : Generic
    {
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerAddress { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}