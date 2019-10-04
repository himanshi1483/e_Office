namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
