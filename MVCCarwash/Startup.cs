using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCarwash.Startup))]
namespace MVCCarwash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
