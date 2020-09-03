using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mvcCrud.Startup))]
namespace mvcCrud
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
