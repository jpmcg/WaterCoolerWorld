using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WaterCoolerWorld.Startup))]
namespace WaterCoolerWorld
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
