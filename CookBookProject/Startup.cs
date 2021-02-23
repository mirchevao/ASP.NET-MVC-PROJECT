using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CookBookProject.Startup))]
namespace CookBookProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
