//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DairyManagement.Models.LiveDBEDMX
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountDetailsLastRealStock
    {
        public int Id { get; set; }
        public Nullable<decimal> RealStock { get; set; }
        public Nullable<System.DateTime> AccountDate { get; set; }
        public Nullable<int> AccountId { get; set; }
    
        public virtual EmployeeDetail EmployeeDetail { get; set; }
    }
}
