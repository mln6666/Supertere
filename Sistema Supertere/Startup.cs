using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema_Supertere.Startup))]
namespace Sistema_Supertere
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
