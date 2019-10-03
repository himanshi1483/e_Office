namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SubCategoryMasters", "CategoryId");
            AddForeignKey("dbo.SubCategoryMasters", "CategoryId", "dbo.CategoryMasters", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategoryMasters", "CategoryId", "dbo.CategoryMasters");
            DropIndex("dbo.SubCategoryMasters", new[] { "CategoryId" });
        }
    }
}
