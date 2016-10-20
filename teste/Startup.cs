using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(teste.Startup))]
namespace teste
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
