namespace GloriousGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class location : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LocationId);
            
            AddColumn("dbo.Crops", "LocationIdRef", c => c.Int(nullable: false));
            CreateIndex("dbo.Crops", "LocationIdRef");
            AddForeignKey("dbo.Crops", "LocationIdRef", "dbo.locations", "LocationId", cascadeDelete: true);
            DropColumn("dbo.Crops", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crops", "Location", c => c.Int(nullable: false));
            DropForeignKey("dbo.Crops", "LocationIdRef", "dbo.locations");
            DropIndex("dbo.Crops", new[] { "LocationIdRef" });
            DropColumn("dbo.Crops", "LocationIdRef");
            DropTable("dbo.locations");
        }
    }
}
