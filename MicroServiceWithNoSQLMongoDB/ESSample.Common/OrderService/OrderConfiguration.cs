namespace ESSample.Common.OrderService
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Order Configuration
    /// </summary>
    public class OrderConfiguration
    {
        /// <summary>
        /// The port
        /// </summary>
        public static string Port = ConfigurationManager.AppSettings["OrderServicePort"];

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
        /// The Order collection name
        /// </summary>
        public static string OrderCollectionName = ConfigurationManager.AppSettings["OrderCollectionName"];

        /// <summary>
        /// The Order service name
        /// </summary>
        public static string OrderServiceName = ConfigurationManager.AppSettings["OrderServiceName"];

        /// <summary>
        /// The Order service display name
        /// </summary>
        public static string OrderServiceDisplayName = ConfigurationManager.AppSettings["OrderServiceDisplayName"];
    }

    /// <summary>
    /// Order Status 
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// The created
        /// </summary>
        Created = 1,
        /// <summary>
        /// The confirmed
        /// </summary>
        Confirmed = 2,
        /// <summary>
        /// The shipped
        /// </summary>
        Shipped = 3,
        /// <summary>
        /// The delivered
        /// </summary>
        Delivered = 4
    }
}
