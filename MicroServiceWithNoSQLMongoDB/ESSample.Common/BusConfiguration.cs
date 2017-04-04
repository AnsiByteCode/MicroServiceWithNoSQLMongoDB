namespace ESSample.Common
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Bus Configuration
    /// </summary>
    public class BusConfiguration
    {
        /// <summary>
        /// The use in memory bus
        /// </summary>
        public static string UseInMemoryBus = ConfigurationManager.AppSettings["UseInMemoryBus"];

        /// <summary>
        /// The end point
        /// </summary>
        public static string EndPoint = ConfigurationManager.AppSettings["Endpoint"];

        /// <summary>
        /// The rabbit mq URI
        /// </summary>
        public static string RabbitMqUri = ConfigurationManager.AppSettings["RabbitMqUri"];

        /// <summary>
        /// The rabbit mq user
        /// </summary>
        public static string RabbitMqUser = ConfigurationManager.AppSettings["RabbitMqUser"];

        /// <summary>
        /// The rabbit mq password
        /// </summary>
        public static string RabbitMqPassword = ConfigurationManager.AppSettings["RabbitMqPassword"];

        /// <summary>
        /// The service address in memory
        /// </summary>
        public static string ServiceAddressInMemory = ConfigurationManager.AppSettings["ServiceAddressInMemory"];

        /// <summary>
        /// The service address
        /// </summary>
        public static string ServiceAddress = ConfigurationManager.AppSettings["ServiceAddress"];
    }
}
