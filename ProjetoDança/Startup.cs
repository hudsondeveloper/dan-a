using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoDança.Startup))]
namespace ProjetoDança
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
