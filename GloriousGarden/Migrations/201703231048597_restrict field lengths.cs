namespace GloriousGarden.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restrictfieldlengths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Crops", "CropName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Crops", "Variety", c => c.String(maxLength: 255));
            AlterColumn("dbo.Crops", "notes", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Crops", "notes", c => c.String());
            AlterColumn("dbo.Crops", "Variety", c => c.String());
            AlterColumn("dbo.Crops", "CropName", c => c.String(nullable: false));
        }
    }
}
