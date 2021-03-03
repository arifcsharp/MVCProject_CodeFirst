namespace MvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FDRs", "AccountName", c => c.String());
            DropColumn("dbo.FDRs", "AcountName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FDRs", "AcountName", c => c.String());
            DropColumn("dbo.FDRs", "AccountName");
        }
    }
}
