using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Time.Management.Startup))]
namespace Time.Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
