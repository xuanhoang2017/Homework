using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_2504.Startup))]
namespace _2504
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
