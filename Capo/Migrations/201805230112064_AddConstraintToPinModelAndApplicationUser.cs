namespace Capo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintToPinModelAndApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pins", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Pins", "ApplicationUser_Id");
            AddForeignKey("dbo.Pins", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pins", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pins", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Pins", "ApplicationUser_Id");
        }
    }
}
