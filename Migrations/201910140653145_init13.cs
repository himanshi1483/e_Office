namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventCalendars",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventStart = c.DateTime(),
                        EventEnd = c.DateTime(),
                        EventName = c.String(),
                        Description = c.String(),
                        Location = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventCalendars");
        }
    }
}
