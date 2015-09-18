using System.Web.Http;
using Fleetmatics.OauthApi.Mapper;

namespace Fleetmatics.OauthApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfiguration.Configure();
        }
    }
}
