namespace TriviaMag.Web.App_Start
{
    using System.Data.Entity;
    using TriviaMag.Data;
    using TriviaMag.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TriviaMagDbContext, Configuration>());
            TriviaMagDbContext.Create().Database.Initialize(true);
        }
    }
}