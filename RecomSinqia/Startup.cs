using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecomSinqia.Startup))]
namespace RecomSinqia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
