namespace TriviaMag.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<TriviaMagDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TriviaMag.Data.TriviaMagDbContext";
        }

        protected override void Seed(TriviaMagDbContext context)
        {
        }
    }
}
