using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAdminSIP.Startup))]
namespace WebAdminSIP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
