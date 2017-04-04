namespace ProductService
{
    #region using
    using ES.Infrastructure;
    using ESSample.Common.CustomerService;
    using MicroService4Net;
    using Newtonsoft.Json.Serialization;
    using System.Configuration;
    using System.Reflection;
    using System.Web.Http;
    #endregion

    /// <summary>
    /// Main Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            var port = int.Parse(ProductConfiguration.Port);
            var serviceDisplayName = ProductConfiguration.ProductServiceDisplayName;
            var serviceName = ProductConfiguration.ProductServiceName;
            var microService = new MicroService(port, serviceDisplayName, serviceName, configure => GetConfig(configure));
            microService.Run(args);
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="configure">The configure.</param>
        private static void GetConfig(HttpConfiguration configure)
        {
            configure.EnableCors();
            configure.Formatters.Remove(configure.Formatters.XmlFormatter);
            //// Configure JSON output to how we want it
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;

            //// camelCase JSON properties
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            configure.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            configure.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            GlobalConfiguration.Configuration.EnsureInitialized();
            IoCBuilder.InitWeb(Assembly.GetExecutingAssembly(), configure);
        }
    }
}
