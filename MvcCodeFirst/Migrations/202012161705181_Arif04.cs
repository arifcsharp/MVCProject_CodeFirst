namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arif04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DOB", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "District", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Age");
            DropColumn("dbo.Customers", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "State", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "District");
            DropColumn("dbo.Customers", "DOB");
        }
    }
}
