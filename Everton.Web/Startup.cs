using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Everton.Web.Startup))]
namespace Everton.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
