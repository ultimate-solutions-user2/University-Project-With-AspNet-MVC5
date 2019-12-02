using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Unvirsity_System.Startup))]
namespace Unvirsity_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
