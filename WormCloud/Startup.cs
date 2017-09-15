using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WormCloud.Startup))]
namespace WormCloud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
