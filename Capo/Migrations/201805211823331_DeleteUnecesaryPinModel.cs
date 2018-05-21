namespace Capo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUnecesaryPinModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pins", "Place_Id", "dbo.Places");
            DropIndex("dbo.Pins", new[] { "Place_Id" });
            DropTable("dbo.Pins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PinType = c.String(),
                        Description = c.String(),
                        Place_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Pins", "Place_Id");
            AddForeignKey("dbo.Pins", "Place_Id", "dbo.Places", "Id");
        }
    }
}
