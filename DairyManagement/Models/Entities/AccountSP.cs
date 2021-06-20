using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DairyManagement.Models.Entities
{
    public class AccountSP : Generic
    {
        public Nullable<decimal> SPValue { get; set; }
        public string SPNote { get; set; }

        //Foreign key for Account Detail
        [ForeignKey("AccountDetail")]
        public Nullable<int> AccountId { get; set; }
        public virtual AccountDetail AccountDetail { get; set; }
    }
}