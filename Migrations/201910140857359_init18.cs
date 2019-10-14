namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init18 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskModels", "TaskPriority", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskModels", "TaskPriority", c => c.Int(nullable: false));
        }
    }
}
