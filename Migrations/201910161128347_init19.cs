namespace e_Office.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init19 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InwardNotes",
                c => new
                    {
                        NotesId = c.Int(nullable: false, identity: true),
                        InwardId = c.Int(nullable: false),
                        NoteType = c.String(),
                        NoteText = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        IsSigned = c.String(),
                    })
                .PrimaryKey(t => t.NotesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InwardNotes");
        }
    }
}
