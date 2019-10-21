namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init212 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardNotes", "FwdToDept", c => c.String());
            AddColumn("dbo.InwardNotes", "FwdToCC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardNotes", "FwdToCC");
            DropColumn("dbo.InwardNotes", "FwdToDept");
        }
    }
}
