namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardEntries", "DocumentName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardEntries", "DocumentName");
        }
    }
}
