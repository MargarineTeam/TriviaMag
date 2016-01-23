using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using TriviaMag.Data;
using TriviaMag.Data.Migrations;

[assembly: OwinStartupAttribute(typeof(TriviaMag.Web.Startup))]
namespace TriviaMag.Web
{
    public partial class Startup {

        public void Configuration(IAppBuilder app) {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TriviaMagDbContext, Configuration>(true));
            ConfigureAuth(app);
        }
    }
}
