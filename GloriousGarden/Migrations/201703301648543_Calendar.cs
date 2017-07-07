namespace GloriousGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calendar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EventDate = c.DateTime(nullable: false),
                        EventAction = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CalendarItems");
        }
    }
}
