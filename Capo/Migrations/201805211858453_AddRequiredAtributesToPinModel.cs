namespace Capo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAtributesToPinModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pins", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Pins", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pins", "Description", c => c.String());
            AlterColumn("dbo.Pins", "Name", c => c.String());
        }
    }
}
