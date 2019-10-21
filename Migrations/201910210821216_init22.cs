namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardNotes", "DigitalSign", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardNotes", "DigitalSign");
        }
    }
}
