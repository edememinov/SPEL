using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPEL.Leden.Startup))]
namespace SPEL.Leden
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
