using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BSBWebApplication.Startup))]
namespace BSBWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
