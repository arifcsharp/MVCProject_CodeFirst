namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration01 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccountHolders", "DOB");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountHolders", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
