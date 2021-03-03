using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCodeFirst.Startup))]
namespace MvcCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
