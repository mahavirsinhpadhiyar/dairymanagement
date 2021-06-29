namespace DairyManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMoneyPaidFlagVendorMilkDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VendorMilkInfoes", "MoneyPaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VendorMilkInfoes", "MoneyPaid");
        }
    }
}
