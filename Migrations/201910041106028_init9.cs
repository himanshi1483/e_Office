namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InwardEntries", "SendToCC", "dbo.UserDetails");
            DropIndex("dbo.InwardEntries", new[] { "SendToCC" });
            DropColumn("dbo.InwardEntries", "SendToCC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InwardEntries", "SendToCC", c => c.Int(nullable: false));
            CreateIndex("dbo.InwardEntries", "SendToCC");
            AddForeignKey("dbo.InwardEntries", "SendToCC", "dbo.UserDetails", "UserDetailId");
        }
    }
}
