namespace ESSample.Common.CustomerService
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Customer Configuration
    /// </summary>
    public static class ProductConfiguration
    {
        /// <summary>
        /// The port
        /// </summary>
        public static string Port = ConfigurationManager.AppSettings["ProductServicePort"];

        /// <summary>
        /// The API base URL
        /// </summary>
        public static string ApiBaseUrl = "http://localhost:" + ConfigurationManager.AppSettings["ProductServicePort"] + "/api/";

        /// <summary>
        /// The connection string
        /// </summary>
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        /// <summary>
        /// The database name
        /// </summary>
        public static string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];

        /// <summary>
        /// The Product collection name
        /// </summary>
        public static string ProductCollectionName = ConfigurationManager.AppSettings["ProductCollectionName"];

        /// <summary>
        /// The Product service name
        /// </summary>
        public static string ProductServiceName = ConfigurationManager.AppSettings["ProductServiceName"];

        /// <summary>
        /// The Product service display name
        /// </summary>
        public static string ProductServiceDisplayName = ConfigurationManager.AppSettings["ProductServiceDisplayName"];
    }
}
