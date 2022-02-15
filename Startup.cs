using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECOMMERCE_Project_ASPNET.Startup))]
namespace ECOMMERCE_Project_ASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
