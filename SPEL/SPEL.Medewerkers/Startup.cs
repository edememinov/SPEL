using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SPEL.Medewerkers.Startup))]
namespace SPEL.Medewerkers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
