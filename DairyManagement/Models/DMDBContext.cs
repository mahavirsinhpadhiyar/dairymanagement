using DairyManagement.Models.Entities;
using System.Data.Entity;
using DairyManagement.Infrastructure;

namespace DairyManagement.Models
{
    public class DMDBContext: DbContext
    {
        public DMDBContext(): base("DMDBConnectionString")
        {
            Database.SetInitializer(new DMDBInitializer());
        }

        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<AccountDetailsLastRealStock> AccountDetailsLastRealStocks { get; set; }
        public DbSet<AccountSP> AccountSPs { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<EmployeeDetail> EmployeeInfo { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public DbSet<EmployeeVaaraDetail> EmployeeVaaraDetails { get; set; }
        public DbSet<MilkType> MilkTypes { get; set; }
        public DbSet<StaffGivenMilkToCustomer> StaffGivenMilkToCustomer { get; set; }
        public DbSet<UserInfo> UserInfoes { get; set; }
        public DbSet<VendorInfo> VendorInfoes { get; set; }
        public DbSet<VendorMilkInfo> VendorMilkInfoes { get; set; }
    }
}