namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init211 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardNotes", "ForwardedTo", c => c.String());
            AddColumn("dbo.InwardNotes", "ForwardedBy", c => c.String());
            AddColumn("dbo.InwardNotes", "ForwardedOn", c => c.DateTime());
            AddColumn("dbo.InwardNotes", "RepliedToNote", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardNotes", "RepliedToNote");
            DropColumn("dbo.InwardNotes", "ForwardedOn");
            DropColumn("dbo.InwardNotes", "ForwardedBy");
            DropColumn("dbo.InwardNotes", "ForwardedTo");
        }
    }
}
