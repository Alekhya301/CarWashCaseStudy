using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarMVC.Startup))]
namespace CarMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
