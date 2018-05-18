namespace Capo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToPlaceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Description");
        }
    }
}
