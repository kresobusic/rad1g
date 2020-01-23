using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rad1G.Startup))]
namespace Rad1G
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
