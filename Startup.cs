using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(e_Office.Startup))]
namespace e_Office
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
