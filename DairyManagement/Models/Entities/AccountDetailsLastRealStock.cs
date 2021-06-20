using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DairyManagement.Models.Entities
{
    public class AccountDetailsLastRealStock : Generic
    {
        public Nullable<decimal> RealStock { get; set; }
        public Nullable<System.DateTime> AccountDate { get; set; }

        //Foreign key for Account Detail
        [ForeignKey("AccountDetail")]
        public Nullable<int> AccountId { get; set; }
        public virtual AccountDetail AccountDetail { get; set; }
    }
}