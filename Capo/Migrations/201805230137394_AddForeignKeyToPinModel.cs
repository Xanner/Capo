namespace Capo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToPinModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pins", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Pins", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Pins", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Pins", name: "ApplicationUserId", newName: "ApplicationUser_Id");
        }
    }
}
