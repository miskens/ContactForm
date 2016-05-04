using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyContactForm.Startup))]
namespace MyContactForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
