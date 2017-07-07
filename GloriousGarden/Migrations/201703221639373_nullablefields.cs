namespace GloriousGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablefields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Crops", "PlantedDate", c => c.DateTime());
            AlterColumn("dbo.Crops", "GerminationDate", c => c.DateTime());
            AlterColumn("dbo.Crops", "HarvestDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Crops", "HarvestDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Crops", "GerminationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Crops", "PlantedDate", c => c.DateTime(nullable: false));
        }
    }
}
