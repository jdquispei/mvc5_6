using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Empresas.Startup))]
namespace Empresas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
