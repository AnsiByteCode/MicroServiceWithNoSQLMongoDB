namespace ESSample.Common
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Event Store Configuration
    /// </summary>
    public static class EventStoreConfiguration
    {
        /// <summary>
        /// The connection string
        /// </summary>
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        /// <summary>
        /// The database name
        /// </summary>
        public static string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];

        /// <summary>
        /// The events collection name
        /// </summary>
        public static string EventsCollectionName = "Events";

        /// <summary>
        /// The snap shot collection name
        /// </summary>
        public static string SnapShotCollectionName = "Snapshot";
 
        /// <summary>
        /// The event stream collection name
        /// </summary>
        public static string EventStreamCollectionName = "EventStreams";
    }
}
