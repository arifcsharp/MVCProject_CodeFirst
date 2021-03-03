namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Products", "ConfirmPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ConfirmPassword");
            DropColumn("dbo.Products", "Password");
        }
    }
}
