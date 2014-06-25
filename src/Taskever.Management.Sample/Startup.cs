using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Taskever.Management.Sample.Startup))]
namespace Taskever.Management.Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
