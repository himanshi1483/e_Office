namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardNotes", "ReplyToDept", c => c.String());
            AddColumn("dbo.InwardNotes", "ReplyToCC", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardNotes", "ReplyToCC");
            DropColumn("dbo.InwardNotes", "ReplyToDept");
        }
    }
}
