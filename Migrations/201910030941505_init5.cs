namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasicHeadMasters", "BasicHeadName", c => c.String());
            AddColumn("dbo.StandardHeadMasters", "StdHeadName", c => c.String());
            AddColumn("dbo.SubHeadMasters", "SubHeadName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubHeadMasters", "SubHeadName");
            DropColumn("dbo.StandardHeadMasters", "StdHeadName");
            DropColumn("dbo.BasicHeadMasters", "BasicHeadName");
        }
    }
}
