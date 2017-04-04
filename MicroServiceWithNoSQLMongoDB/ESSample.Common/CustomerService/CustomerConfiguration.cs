namespace ESSample.Common.CustomerService
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Customer Configuration
    /// </summary>
    public static class CustomerConfiguration
    {
        /// <summary>
        /// The port
        /// </summary>
        public static string Port = ConfigurationManager.AppSettings["CustomerServicePort"];

        /// <summary>
        /// The API base URL
        /// </summary>
        public static string ApiBaseUrl = "http://localhost:" + Port + "/api/";

        /// <summary>
        /// The connection string
        /// </summary>
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        /// <summary>
        /// The database name
        /// </summary>
        public static string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];

        /// <summary>
        /// The customer collection name
        /// </summary>
        public static string CustomerCollectionName = ConfigurationManager.AppSettings["CustomerCollectionName"];

        /// <summary>
        /// The Customer service name
        /// </summary>
        public static string CustomerServiceName = ConfigurationManager.AppSettings["CustomerServiceName"];

        /// <summary>
        /// The Customer service display name
        /// </summary>
        public static string CustomerServiceDisplayName = ConfigurationManager.AppSettings["CustomerServiceDisplayName"];
    }
}
