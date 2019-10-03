namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InwardEntries", "SendToDept", c => c.Int(nullable: false));
            AlterColumn("dbo.InwardEntries", "SendToUser", c => c.Int(nullable: false));
            AlterColumn("dbo.InwardEntries", "SendToCC", c => c.Int(nullable: false));
            AlterColumn("dbo.InwardEntries", "Classification", c => c.Int(nullable: false));
            CreateIndex("dbo.InwardEntries", "Classification");
            CreateIndex("dbo.InwardEntries", "SendToDept");
            CreateIndex("dbo.InwardEntries", "SendToUser");
            CreateIndex("dbo.InwardEntries", "SendToCC");
            AddForeignKey("dbo.InwardEntries", "Classification", "dbo.ClassificationMasters", "ClassificationId");
            AddForeignKey("dbo.InwardEntries", "SendToDept", "dbo.DeptMasters", "DeptId");
            AddForeignKey("dbo.InwardEntries", "SendToCC", "dbo.UserDetails", "UserDetailId");
            AddForeignKey("dbo.InwardEntries", "SendToUser", "dbo.UserDetails", "UserDetailId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InwardEntries", "SendToUser", "dbo.UserDetails");
            DropForeignKey("dbo.InwardEntries", "SendToCC", "dbo.UserDetails");
            DropForeignKey("dbo.InwardEntries", "SendToDept", "dbo.DeptMasters");
            DropForeignKey("dbo.InwardEntries", "Classification", "dbo.ClassificationMasters");
            DropIndex("dbo.InwardEntries", new[] { "SendToCC" });
            DropIndex("dbo.InwardEntries", new[] { "SendToUser" });
            DropIndex("dbo.InwardEntries", new[] { "SendToDept" });
            DropIndex("dbo.InwardEntries", new[] { "Classification" });
            AlterColumn("dbo.InwardEntries", "Classification", c => c.String());
            AlterColumn("dbo.InwardEntries", "SendToCC", c => c.String());
            AlterColumn("dbo.InwardEntries", "SendToUser", c => c.String());
            AlterColumn("dbo.InwardEntries", "SendToDept", c => c.String());
        }
    }
}
