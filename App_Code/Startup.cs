using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTIS.Startup))]
namespace PTIS
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
