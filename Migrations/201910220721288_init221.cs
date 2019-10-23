namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init221 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardNotes", "ReplyTo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardNotes", "ReplyTo");
        }
    }
}
