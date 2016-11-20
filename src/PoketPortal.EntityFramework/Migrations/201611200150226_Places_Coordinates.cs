namespace PoketPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Places_Coordinates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 9));
            AlterColumn("dbo.Places", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 9));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Places", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
