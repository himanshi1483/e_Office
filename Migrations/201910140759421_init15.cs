namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskModels",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskSummary = c.String(),
                        StartDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        TaskStatus = c.String(),
                        AssignedTo = c.String(),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskModels");
        }
    }
}
