namespace Capo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlacesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Longitude = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pins", "Place_Id", c => c.Int());
            CreateIndex("dbo.Pins", "Place_Id");
            AddForeignKey("dbo.Pins", "Place_Id", "dbo.Places", "Id");
            DropColumn("dbo.Pins", "Longitude");
            DropColumn("dbo.Pins", "Latitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pins", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Pins", "Longitude", c => c.Double(nullable: false));
            DropForeignKey("dbo.Pins", "Place_Id", "dbo.Places");
            DropIndex("dbo.Pins", new[] { "Place_Id" });
            DropColumn("dbo.Pins", "Place_Id");
            DropTable("dbo.Places");
        }
    }
}
