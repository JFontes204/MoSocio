using Microsoft.Owin;
using MoSocioAPI.Api.App_Start;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(MoSocioAPI.Api.Startup))]

namespace MoSocioAPI.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            UnityWebApiActivator.Start(config);
            //JobSchedulerConfig.Start();
            AutoMapperConfig.RegisterMappings();
            OAuthConfig.Register(app);
            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }
    }
}
