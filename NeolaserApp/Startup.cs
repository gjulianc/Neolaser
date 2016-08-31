using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeolaserApp.Startup))]
namespace NeolaserApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
