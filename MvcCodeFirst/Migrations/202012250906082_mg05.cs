namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Image = c.Binary(storeType: "image"),
                        IssueDate = c.DateTime(nullable: false, storeType: "date"),
                        Amount = c.Long(nullable: false),
                        AccountTypeID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccountType", t => t.AccountTypeID, cascadeDelete: true)
                .Index(t => t.AccountTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "AccountTypeID", "dbo.AccountType");
            DropIndex("dbo.Client", new[] { "AccountTypeID" });
            DropTable("dbo.Client");
            DropTable("dbo.AccountType");
        }
    }
}
