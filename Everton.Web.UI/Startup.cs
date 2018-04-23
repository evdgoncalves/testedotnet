using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Everton.Web.UI.Startup))]
namespace Everton.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
