using System.Net.Http.Headers;
using System.Web.Http;

namespace Intricon.PrescriptionEngine
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "audion8",
                routeTemplate: "api/audion8",
                defaults: new { controller = "fitting" });

            config.Routes.MapHttpRoute(
                name: "fit",
                routeTemplate: "api/fit",
                defaults: new { controller = "fitting" });

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("text/html"));

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("text/plain"));

            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString =
                "M-d-yyyy";

            // config.Filters.Add(new ApiAuthorizeAttribute());
        }
    }
}
