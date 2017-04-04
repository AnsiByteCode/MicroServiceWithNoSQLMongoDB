namespace ESSample.Common.CartService
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Cart Configuration
    /// </summary>
    public class CartConfiguration
    {
        /// <summary>
        /// The port
        /// </summary>
        public static string Port = ConfigurationManager.AppSettings["CartServicePort"];

        /// <summary>
        /// The API base URL
        /// </summary>
        public static string ApiBaseUrl = "http://localhost:"+ Port + "/api/";

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
        public static string CartCollectionName = ConfigurationManager.AppSettings["CartCollectionName"];

        /// <summary>
        /// The cart service name
        /// </summary>
        public static string CartServiceName = ConfigurationManager.AppSettings["CartServiceName"];

        /// <summary>
        /// The cart service display name
        /// </summary>
        public static string CartServiceDisplayName = ConfigurationManager.AppSettings["CartServiceDisplayName"];
    }
}
