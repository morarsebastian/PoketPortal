namespace PoketPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Places : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 9),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 9),
                        Properties = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Places");
        }
    }
}
