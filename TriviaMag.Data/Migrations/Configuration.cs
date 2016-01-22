namespace TriviaMag.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    public sealed class Configuration : DbMigrationsConfiguration<TriviaMagDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            //ContextKey = "TriviaMag.Data.TriviaMagDbContext";
        }

        protected override void Seed(TriviaMagDbContext context)
        {
            context.Answers.Count();
            //context.Answers.AddOrUpdate(p => p.Value,
            //    new Models.Answer { Value = "Veren otg" });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
