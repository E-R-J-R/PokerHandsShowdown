using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokerHandShowdown.Startup))]
namespace PokerHandShowdown
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
