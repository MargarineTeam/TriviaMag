using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TriviaMag.Web.Startup))]
namespace TriviaMag.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
