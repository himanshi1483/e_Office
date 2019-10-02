namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorityMasters",
                c => new
                    {
                        AuthorityId = c.Int(nullable: false, identity: true),
                        AuthorityName = c.String(),
                        AuthorityCode = c.String(),
                    })
                .PrimaryKey(t => t.AuthorityId);
            
            CreateTable(
                "dbo.BasicHeadMasters",
                c => new
                    {
                        BasicHeadId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BasicHeadId);
            
            CreateTable(
                "dbo.CategoryMasters",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ClassificationMasters",
                c => new
                    {
                        ClassificationId = c.Int(nullable: false, identity: true),
                        ClassificationName = c.String(),
                        ClassificationCode = c.String(),
                    })
                .PrimaryKey(t => t.ClassificationId);
            
            CreateTable(
                "dbo.DeptMasters",
                c => new
                    {
                        DeptId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        DeptCode = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.DesignationMasters",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(),
                        DesignationCode = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.DistrictMasters",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        DistrictName = c.String(),
                        DistrictCode = c.String(),
                        StateCode = c.String(),
                    })
                .PrimaryKey(t => t.DistrictId);
            
            CreateTable(
                "dbo.InwardEntries",
                c => new
                    {
                        InwardId = c.Int(nullable: false, identity: true),
                        DocumentLocation = c.String(),
                        InwardNumber = c.String(),
                        InwardDate = c.DateTime(nullable: false),
                        Subject = c.String(),
                        SendToDept = c.String(),
                        SendToUser = c.String(),
                        SendToCC = c.String(),
                        From = c.String(),
                        DueDate = c.DateTime(),
                        Action = c.String(),
                        Priority = c.String(),
                        Classification = c.String(),
                        Remarks = c.String(),
                        Tags = c.String(),
                    })
                .PrimaryKey(t => t.InwardId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SectionMasters",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        SectionName = c.String(),
                    })
                .PrimaryKey(t => t.SectionId);
            
            CreateTable(
                "dbo.StandardHeadMasters",
                c => new
                    {
                        StdHeadId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.StdHeadId);
            
            CreateTable(
                "dbo.StateMasters",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                        StateCode = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.SubCategoryMasters",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.SubHeadMasters",
                c => new
                    {
                        SubHeadId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SubHeadId);
            
            CreateTable(
                "dbo.TalukaMasters",
                c => new
                    {
                        TalukaId = c.Int(nullable: false, identity: true),
                        TalukaName = c.String(),
                        TalukaCode = c.String(),
                        DistrictCode = c.String(),
                        StateCode = c.String(),
                    })
                .PrimaryKey(t => t.TalukaId);
            
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ActivityDetail = c.String(),
                        ActivityTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserDetailId = c.Int(nullable: false, identity: true),
                        Salutation = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        EmailAddress = c.String(),
                        PhoneNo = c.String(),
                        DOB = c.DateTime(nullable: false),
                        DeptId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        AuthorityId = c.Int(nullable: false),
                        IsHOD = c.Boolean(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserDetailId);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        LoginTime = c.DateTime(),
                        LogoutTime = c.DateTime(),
                        UserIP = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserLogs");
            DropTable("dbo.UserDetails");
            DropTable("dbo.UserActivities");
            DropTable("dbo.TalukaMasters");
            DropTable("dbo.SubHeadMasters");
            DropTable("dbo.SubCategoryMasters");
            DropTable("dbo.StateMasters");
            DropTable("dbo.StandardHeadMasters");
            DropTable("dbo.SectionMasters");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.InwardEntries");
            DropTable("dbo.DistrictMasters");
            DropTable("dbo.DesignationMasters");
            DropTable("dbo.DeptMasters");
            DropTable("dbo.ClassificationMasters");
            DropTable("dbo.CategoryMasters");
            DropTable("dbo.BasicHeadMasters");
            DropTable("dbo.AuthorityMasters");
        }
    }
}
