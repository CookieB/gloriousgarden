namespace GloriousGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requiredfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Crops", "CropName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Crops", "CropName", c => c.String());
        }
    }
}
