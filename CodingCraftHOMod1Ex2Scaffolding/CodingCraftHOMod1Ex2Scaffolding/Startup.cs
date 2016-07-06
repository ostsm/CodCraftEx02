using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingCraftHOMod1Ex2Scaffolding.Startup))]
namespace CodingCraftHOMod1Ex2Scaffolding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
