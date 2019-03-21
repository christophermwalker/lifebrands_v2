using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lifebrands_v2.Startup))]
namespace lifebrands_v2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
