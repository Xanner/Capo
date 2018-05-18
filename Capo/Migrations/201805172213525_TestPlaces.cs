namespace Capo.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class TestPlaces : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                  INSERT INTO [dbo].[Places] ([Name], [Longitude], [Latitude], [Description]) VALUES ( N'Krak�w', 19, 50, N'Wyprowadz� inwald� na w�zku')
                  INSERT INTO [dbo].[Places] ([Name], [Longitude], [Latitude], [Description]) VALUES ( N'Krak�w', 18, 50, N'Zjem komu� psa')
                  INSERT INTO [dbo].[Places] ([Name], [Longitude], [Latitude], [Description]) VALUES ( N'Krak�w', 17, 50, N'Zjem komu� kota')
            ");
        }

        public override void Down()
        {
        }
    }
}
