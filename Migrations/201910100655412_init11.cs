namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardEntries", "CC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardEntries", "CC");
        }
    }
}
