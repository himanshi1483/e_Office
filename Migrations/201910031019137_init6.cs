namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SubCategoryMasters", "CategoryId", "dbo.CategoryMasters");
            DropForeignKey("dbo.UserDetails", "AuthorityId", "dbo.AuthorityMasters");
            DropForeignKey("dbo.UserDetails", "DeptId", "dbo.DeptMasters");
            DropForeignKey("dbo.UserDetails", "DesignationId", "dbo.DesignationMasters");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.SubCategoryMasters", "CategoryId", "dbo.CategoryMasters", "CategoryId");
            AddForeignKey("dbo.UserDetails", "AuthorityId", "dbo.AuthorityMasters", "AuthorityId");
            AddForeignKey("dbo.UserDetails", "DeptId", "dbo.DeptMasters", "DeptId");
            AddForeignKey("dbo.UserDetails", "DesignationId", "dbo.DesignationMasters", "DesignationId");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserDetails", "DesignationId", "dbo.DesignationMasters");
            DropForeignKey("dbo.UserDetails", "DeptId", "dbo.DeptMasters");
            DropForeignKey("dbo.UserDetails", "AuthorityId", "dbo.AuthorityMasters");
            DropForeignKey("dbo.SubCategoryMasters", "CategoryId", "dbo.CategoryMasters");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserDetails", "DesignationId", "dbo.DesignationMasters", "DesignationId", cascadeDelete: true);
            AddForeignKey("dbo.UserDetails", "DeptId", "dbo.DeptMasters", "DeptId", cascadeDelete: true);
            AddForeignKey("dbo.UserDetails", "AuthorityId", "dbo.AuthorityMasters", "AuthorityId", cascadeDelete: true);
            AddForeignKey("dbo.SubCategoryMasters", "CategoryId", "dbo.CategoryMasters", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
