namespace ES.Common
{
    #region Using
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// I Event Store
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// Creates the new stream.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="domainEvents">The domain events.</param>
        void CreateNewStream(string streamName, IEnumerable<DomainEvent> domainEvents);

        /// <summary>
        /// Appends the events to stream.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="domainEvents">The domain events.</param>
        /// <param name="expectedVersion">The expected version.</param>
        void AppendEventsToStream(string streamName, IEnumerable<DomainEvent> domainEvents, int? expectedVersion);

        /// <summary>
        /// Gets the stream.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="fromVersion">From version.</param>
        /// <param name="toVersion">To version.</param>
        /// <returns></returns>
        IEnumerable<DomainEvent> GetStream(string streamName, int fromVersion, int toVersion);

        /// <summary>
        /// Adds the snapshot.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="snapshot">The snapshot.</param>
        void AddSnapshot<T>(string streamName, T snapshot);

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="streamName">Name of the stream.</param>
        /// <returns></returns>
        T GetLatestSnapshot<T>(string streamName) where T : class;

        /// <summary>
        /// Gets all stream ids.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Guid> GetAllStreamIds();

        /// <summary>
        /// Gets the history for aggregate.
        /// </summary>
        /// <param name="streamName">Name of the stream.</param>
        /// <param name="fromVersion">From version.</param>
        /// <param name="toVersion">To version.</param>
        /// <returns></returns>
        Task<IEnumerable<HistoryItem>> GetHistoryForAggregate(string streamName, int fromVersion, int toVersion);
    }
}