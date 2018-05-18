namespace Capo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TestPlaces : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO [dbo].[Places] ([Name], [Longitude], [Latitude], [Description]) VALUES ( N'Kraków', 19, 50, N'Wyprowadzê inwaldê na wózku')
                  INSERT INTO [dbo].[Places] ([Name], [Longitude], [Latitude], [Description]) VALUES ( N'Kraków', 18, 50, N'Zjem komuœ psa')
                  INSERT INTO [dbo].[Places] ([Name], [Longitude], [Latitude], [Description]) VALUES ( N'Kraków', 17, 50, N'Zjem komuœ kota')
            ");
        }

        public override void Down()
        {
        }
    }
}
