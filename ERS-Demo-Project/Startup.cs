using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERS_Demo_Project.Startup))]
namespace ERS_Demo_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
