namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InwardEntries", "InwardDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InwardEntries", "InwardDate", c => c.DateTime(nullable: false));
        }
    }
}
