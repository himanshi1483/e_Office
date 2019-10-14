namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskModels", "TaskPriority", c => c.Int(nullable: false));
            DropColumn("dbo.TaskModels", "TaskStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "TaskStatus", c => c.String());
            DropColumn("dbo.TaskModels", "TaskPriority");
        }
    }
}
