using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EntityFramworkDbDemo.Web.Startup))]
namespace EntityFramworkDbDemo.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
