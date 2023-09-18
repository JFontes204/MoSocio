using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using MoSocioAPI.DAC;
using MoSocioAPI.DAC.Security;
using Owin;
using System;

namespace MoSocioAPI.Api.App_Start
{
    public class OAuthConfig
    {
        public static void Register(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions authServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider("self")
            };

            app.CreatePerOwinContext(MoSocioAPIDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseOAuthAuthorizationServer(authServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}