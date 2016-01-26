using Microsoft.Owin;
using Owin;
using TriviaMag.Web.App_Start;

[assembly: OwinStartupAttribute(typeof(TriviaMag.Web.Startup))]
namespace TriviaMag.Web
{
    public partial class Startup {

        public void Configuration(IAppBuilder app) {

            DatabaseConfig.Initialize();
            ConfigureAuth(app);

        }
    }
}
