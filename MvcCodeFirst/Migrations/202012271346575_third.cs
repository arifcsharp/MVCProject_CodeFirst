namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.FDRs",
                c => new
                    {
                        FDRID = c.Guid(nullable: false),
                        AccountName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BCustomerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FDRID)
                .ForeignKey("dbo.BCustomers", t => t.BCustomerID, cascadeDelete: true)
                .Index(t => t.BCustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FDRs", "BCustomerID", "dbo.BCustomers");
            DropIndex("dbo.FDRs", new[] { "BCustomerID" });
            DropTable("dbo.FDRs");
            DropTable("dbo.BCustomers");
        }
    }
}
