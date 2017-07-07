using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GloriousGarden.Startup))]
namespace GloriousGarden
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
