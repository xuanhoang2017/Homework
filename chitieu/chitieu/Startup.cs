using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chitieu.Startup))]
namespace chitieu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
