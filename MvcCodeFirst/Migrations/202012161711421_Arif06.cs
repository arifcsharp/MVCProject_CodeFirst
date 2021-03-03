namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arif06 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Country", c => c.String(nullable: false));
        }
    }
}
