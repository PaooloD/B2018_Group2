using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Covid_Cases_Tracking_System.Startup))]
namespace Covid_Cases_Tracking_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
