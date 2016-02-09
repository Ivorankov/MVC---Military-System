using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MilitarySystem.Web.Startup))]
namespace MilitarySystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
