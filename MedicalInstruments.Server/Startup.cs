using System;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(MedicalInstruments.Server.Startup))]

namespace MedicalInstruments.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(name: "Default",
                routeTemplate: "api/{Controller}/{Action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                });

            app.UseWebApi(config);
        }
    }
}
