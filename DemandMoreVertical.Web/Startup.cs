using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemandMoreVertical.Web.Startup))]
namespace DemandMoreVertical.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
