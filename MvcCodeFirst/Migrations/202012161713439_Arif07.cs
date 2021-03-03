namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arif07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Country");
        }
    }
}
