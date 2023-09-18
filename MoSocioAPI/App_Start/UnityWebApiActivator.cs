using System.Web.Http;
using Unity.WebApi;

namespace MoSocioAPI.Api.App_Start
{
    public class UnityWebApiActivator
    {
        public static void Start(HttpConfiguration config)
        {
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer());
        }

        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}