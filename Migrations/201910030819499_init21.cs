namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init21 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.UserDetails", "DeptId");
            CreateIndex("dbo.UserDetails", "DesignationId");
            CreateIndex("dbo.UserDetails", "AuthorityId");
            AddForeignKey("dbo.UserDetails", "AuthorityId", "dbo.AuthorityMasters", "AuthorityId", cascadeDelete: true);
            AddForeignKey("dbo.UserDetails", "DeptId", "dbo.DeptMasters", "DeptId", cascadeDelete: true);
            AddForeignKey("dbo.UserDetails", "DesignationId", "dbo.DesignationMasters", "DesignationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetails", "DesignationId", "dbo.DesignationMasters");
            DropForeignKey("dbo.UserDetails", "DeptId", "dbo.DeptMasters");
            DropForeignKey("dbo.UserDetails", "AuthorityId", "dbo.AuthorityMasters");
            DropIndex("dbo.UserDetails", new[] { "AuthorityId" });
            DropIndex("dbo.UserDetails", new[] { "DesignationId" });
            DropIndex("dbo.UserDetails", new[] { "DeptId" });
        }
    }
}
