using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarWashApi.Startup))]
namespace CarWashApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
