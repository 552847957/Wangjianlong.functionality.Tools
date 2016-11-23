using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Wangjianlong.functionality.Web.Startup))]
namespace Wangjianlong.functionality.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
