using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebsiteTest.Startup))]
namespace WebsiteTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
