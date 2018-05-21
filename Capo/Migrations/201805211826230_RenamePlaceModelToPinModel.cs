namespace Capo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamePlaceModelToPinModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Places", newName: "Pins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Pins", newName: "Places");
        }
    }
}
