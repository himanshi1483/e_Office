namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "Salutation", c => c.String());
            AlterColumn("dbo.UserDetails", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "Gender", c => c.Int(nullable: false));
            AlterColumn("dbo.UserDetails", "Salutation", c => c.Int(nullable: false));
        }
    }
}
