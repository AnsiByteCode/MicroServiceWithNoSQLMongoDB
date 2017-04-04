namespace ES.Repository.Interface
{
    #region Using
    using ES.Common;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// IEvent Store Repository
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TSnapShot">The type of the snap shot.</typeparam>
    public interface IEventStoreRepository<TEntity,TSnapShot> where TEntity : class where TSnapShot :class
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Saves the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void Save(TEntity customer);

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        TEntity FindById(Guid Id);

        /// <summary>
        /// Gets all ids.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Guid> GetAllIds();

        /// <summary>
        /// Saves the snapshot.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        /// <param name="entity">The entity.</param>
        void SaveSnapshot(TSnapShot snapshot, TEntity entity);

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        TSnapShot GetLatestSnapshot(Guid Id);

        /// <summary>
        /// Gets the history for t entity.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<HistoryItem>> GetHistoryForTEntity(Guid Id);
    }
}
