using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GMUProject.Startup))]
namespace GMUProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
