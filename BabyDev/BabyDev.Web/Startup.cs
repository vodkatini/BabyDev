using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BabyDev.Web.Startup))]
namespace BabyDev.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
