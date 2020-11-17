using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppEnterwell.Startup))]
namespace WebAppEnterwell
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
