namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FDRs", "BCustomerID", "dbo.BCustomers");
            DropIndex("dbo.FDRs", new[] { "BCustomerID" });
            DropTable("dbo.BCustomers");
            DropTable("dbo.FDRs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FDRs",
                c => new
                    {
                        FDRID = c.Guid(nullable: false),
                        AcountName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BCustomerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FDRID);
            
            CreateTable(
                "dbo.BCustomers",
                c => new
                    {
                        BCustomerID = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        OpeningDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BCustomerID);
            
            CreateIndex("dbo.FDRs", "BCustomerID");
            AddForeignKey("dbo.FDRs", "BCustomerID", "dbo.BCustomers", "BCustomerID", cascadeDelete: true);
        }
    }
}
