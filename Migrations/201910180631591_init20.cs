namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InwardNotes", "IsSigned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InwardNotes", "IsSigned", c => c.String());
        }
    }
}
