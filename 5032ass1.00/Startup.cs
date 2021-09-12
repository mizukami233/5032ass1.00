using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5032ass1._00.Startup))]
namespace _5032ass1._00
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
