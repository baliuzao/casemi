using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Casemi.Startup))]
namespace Casemi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
