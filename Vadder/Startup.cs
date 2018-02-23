using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vadder.Startup))]
namespace Vadder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
