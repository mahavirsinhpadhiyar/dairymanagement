namespace DairyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OldStock = c.Decimal(precision: 18, scale: 2),
                        TodayMilk = c.Decimal(precision: 18, scale: 2),
                        TotalPurchase = c.Decimal(precision: 18, scale: 2),
                        TotalSell = c.Decimal(precision: 18, scale: 2),
                        AvailableStock = c.Decimal(precision: 18, scale: 2),
                        RealStock = c.Decimal(precision: 18, scale: 2),
                        StockDifference = c.Decimal(precision: 18, scale: 2),
                        AccountDateTime = c.DateTime(),
                        TodayMilkNote = c.String(),
                        TotalPurchaseNote = c.String(),
                        TotalSellNote = c.String(),
                        AvailableStockNote = c.String(),
                        RealStockNote = c.String(),
                        StockDifferenceNote = c.String(),
                        ConsiderOldStock = c.Boolean(),
                        VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VendorInfoes", t => t.VendorId)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.AccountDetailsLastRealStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RealStock = c.Decimal(precision: 18, scale: 2),
                        AccountDate = c.DateTime(),
                        AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountDetails", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AccountSPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SPValue = c.Decimal(precision: 18, scale: 2),
                        SPNote = c.String(),
                        AccountId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountDetails", t => t.AccountId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.VendorInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        LocationName = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdateBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        UserInfo_Id = c.Int(),
                        UserInfo_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id1)
                .ForeignKey("dbo.UserInfoes", t => t.CreatedBy)
                .ForeignKey("dbo.UserInfoes", t => t.UpdateBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdateBy)
                .Index(t => t.UserInfo_Id)
                .Index(t => t.UserInfo_Id1);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CreatedOn = c.DateTime(),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MilkTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MilkType1 = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        UserInfo_Id = c.Int(),
                        UserInfo_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.CreatedBy)
                .ForeignKey("dbo.UserInfoes", t => t.UpdatedBy)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id1)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.UserInfo_Id)
                .Index(t => t.UserInfo_Id1);
            
            CreateTable(
                "dbo.VendorMilkInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MilkValue = c.Decimal(precision: 18, scale: 2),
                        FatValue = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        VendorId = c.Int(),
                        MilkTypeId = c.Int(),
                        UserInfo_Id = c.Int(),
                        UserInfo1_Id = c.Int(),
                        UserInfo_Id1 = c.Int(),
                        UserInfo_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MilkTypes", t => t.MilkTypeId)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo1_Id)
                .ForeignKey("dbo.VendorInfoes", t => t.VendorId)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id1)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id2)
                .Index(t => t.VendorId)
                .Index(t => t.MilkTypeId)
                .Index(t => t.UserInfo_Id)
                .Index(t => t.UserInfo1_Id)
                .Index(t => t.UserInfo_Id1)
                .Index(t => t.UserInfo_Id2);
            
            CreateTable(
                "dbo.CustomerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerPhoneNumber = c.String(),
                        CustomerAddress = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        Address = c.String(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeVaaraDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MilkValue = c.Decimal(precision: 18, scale: 2),
                        VaaraDateTime = c.DateTime(),
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateBy = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.StaffGivenMilkToCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MilkType = c.Int(nullable: false),
                        MilkGiven = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerInfoes", t => t.CustomerId)
                .ForeignKey("dbo.EmployeeDetails", t => t.EmployeeId)
                .Index(t => t.CustomerId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaffGivenMilkToCustomers", "EmployeeId", "dbo.EmployeeDetails");
            DropForeignKey("dbo.StaffGivenMilkToCustomers", "CustomerId", "dbo.CustomerInfoes");
            DropForeignKey("dbo.EmployeeSalaries", "EmployeeId", "dbo.EmployeeDetails");
            DropForeignKey("dbo.EmployeeVaaraDetails", "EmployeeId", "dbo.EmployeeDetails");
            DropForeignKey("dbo.AccountDetails", "VendorId", "dbo.VendorInfoes");
            DropForeignKey("dbo.VendorInfoes", "UpdateBy", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorInfoes", "CreatedBy", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorMilkInfoes", "UserInfo_Id2", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorMilkInfoes", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorInfoes", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorInfoes", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.MilkTypes", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.MilkTypes", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorMilkInfoes", "VendorId", "dbo.VendorInfoes");
            DropForeignKey("dbo.VendorMilkInfoes", "UserInfo1_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorMilkInfoes", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.VendorMilkInfoes", "MilkTypeId", "dbo.MilkTypes");
            DropForeignKey("dbo.MilkTypes", "UpdatedBy", "dbo.UserInfoes");
            DropForeignKey("dbo.MilkTypes", "CreatedBy", "dbo.UserInfoes");
            DropForeignKey("dbo.AccountSPs", "AccountId", "dbo.AccountDetails");
            DropForeignKey("dbo.AccountDetailsLastRealStocks", "AccountId", "dbo.AccountDetails");
            DropIndex("dbo.StaffGivenMilkToCustomers", new[] { "EmployeeId" });
            DropIndex("dbo.StaffGivenMilkToCustomers", new[] { "CustomerId" });
            DropIndex("dbo.EmployeeSalaries", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeVaaraDetails", new[] { "EmployeeId" });
            DropIndex("dbo.VendorMilkInfoes", new[] { "UserInfo_Id2" });
            DropIndex("dbo.VendorMilkInfoes", new[] { "UserInfo_Id1" });
            DropIndex("dbo.VendorMilkInfoes", new[] { "UserInfo1_Id" });
            DropIndex("dbo.VendorMilkInfoes", new[] { "UserInfo_Id" });
            DropIndex("dbo.VendorMilkInfoes", new[] { "MilkTypeId" });
            DropIndex("dbo.VendorMilkInfoes", new[] { "VendorId" });
            DropIndex("dbo.MilkTypes", new[] { "UserInfo_Id1" });
            DropIndex("dbo.MilkTypes", new[] { "UserInfo_Id" });
            DropIndex("dbo.MilkTypes", new[] { "UpdatedBy" });
            DropIndex("dbo.MilkTypes", new[] { "CreatedBy" });
            DropIndex("dbo.VendorInfoes", new[] { "UserInfo_Id1" });
            DropIndex("dbo.VendorInfoes", new[] { "UserInfo_Id" });
            DropIndex("dbo.VendorInfoes", new[] { "UpdateBy" });
            DropIndex("dbo.VendorInfoes", new[] { "CreatedBy" });
            DropIndex("dbo.AccountSPs", new[] { "AccountId" });
            DropIndex("dbo.AccountDetailsLastRealStocks", new[] { "AccountId" });
            DropIndex("dbo.AccountDetails", new[] { "VendorId" });
            DropTable("dbo.StaffGivenMilkToCustomers");
            DropTable("dbo.EmployeeSalaries");
            DropTable("dbo.EmployeeVaaraDetails");
            DropTable("dbo.EmployeeDetails");
            DropTable("dbo.CustomerInfoes");
            DropTable("dbo.VendorMilkInfoes");
            DropTable("dbo.MilkTypes");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.VendorInfoes");
            DropTable("dbo.AccountSPs");
            DropTable("dbo.AccountDetailsLastRealStocks");
            DropTable("dbo.AccountDetails");
        }
    }
}
