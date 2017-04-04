namespace Core.Entities
{
    #region Using
    using MongoDB.Driver;
    #endregion

    /// <summary>
    /// Unit Of Work
    /// </summary>
    public class UnitOfWork<T> where T : class
    {
        /// <summary>
        /// The database
        /// </summary>
        private static MongoDatabase database;

        /// <summary>
        /// The collection
        /// </summary>
        public MongoCollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{T}"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="collectionName">Name of the collection.</param>
        public UnitOfWork(ConnectionHelper helper)
        {
            var client = new MongoClient(helper.ConnectionString);
            var server = client.GetServer();
            database = server.GetDatabase(helper.DatabaseName);
            collection = database.GetCollection<T>(helper.CollectionName);
        }
    }
}
