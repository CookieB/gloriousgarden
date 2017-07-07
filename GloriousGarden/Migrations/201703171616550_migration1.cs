namespace GloriousGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Crops", "CropName", c => c.String());
            AddColumn("dbo.Crops", "Variety", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Crops", "Variety");
            DropColumn("dbo.Crops", "CropName");
        }
    }
}
