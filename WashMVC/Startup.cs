using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WashMVC.Startup))]
namespace WashMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
