﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dairymanagementEntities : DbContext
    {
        public dairymanagementEntities()
            : base("name=dairymanagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<AccountSP> AccountSPs { get; set; }
        public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeeVaaraDetail> EmployeeVaaraDetails { get; set; }
        public virtual DbSet<MilkType> MilkTypes { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<VendorInfo> VendorInfoes { get; set; }
        public virtual DbSet<VendorMilkInfo> VendorMilkInfoes { get; set; }
        public virtual DbSet<AccountDetailsLastRealStock> AccountDetailsLastRealStocks { get; set; }
    }
}
