using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuizWebApp2.Startup))]
namespace QuizWebApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
