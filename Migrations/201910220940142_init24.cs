namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardNotes", "InwardDoc", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardNotes", "InwardDoc");
        }
    }
}
