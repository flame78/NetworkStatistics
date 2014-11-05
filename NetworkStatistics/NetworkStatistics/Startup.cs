using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetworkStatistics.Startup))]
namespace NetworkStatistics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
