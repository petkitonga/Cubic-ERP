using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cubic_ERP.Startup))]
namespace Cubic_ERP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
