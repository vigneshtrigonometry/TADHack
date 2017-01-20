using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECMS_Presentation.Startup))]
namespace ECMS_Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
