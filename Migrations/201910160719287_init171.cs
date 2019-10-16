namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init171 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InwardEntries", "CreatedBy", c => c.String());
            AddColumn("dbo.InwardEntries", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.InwardEntries", "UpdatedBy", c => c.String());
            AddColumn("dbo.InwardEntries", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InwardEntries", "UpdatedOn");
            DropColumn("dbo.InwardEntries", "UpdatedBy");
            DropColumn("dbo.InwardEntries", "CreatedOn");
            DropColumn("dbo.InwardEntries", "CreatedBy");
        }
    }
}
