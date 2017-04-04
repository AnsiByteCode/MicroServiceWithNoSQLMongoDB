namespace CustomerService
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
    public static class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            var port = int.Parse(CustomerConfiguration.Port);
            var serviceDisplayName = CustomerConfiguration.CustomerServiceDisplayName;
            var serviceName = CustomerConfiguration.CustomerServiceName;
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

            IoCBuilder.InitWeb(Assembly.GetExecutingAssembly(), configure);
        }
    }
}