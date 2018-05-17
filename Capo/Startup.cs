using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capo.Startup))]
namespace Capo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
