namespace ES.Repository.Interface
{
    #region Using
    using ES.Common;
    using ES.Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Order Repository
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Adds the specified Order.
        /// </summary>
        /// <param name="order">The order.</param>
        void Add(Order order);

        /// <summary>
        /// Saves the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        void Save(Order order);

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        Order FindById(Guid orderId);

        /// <summary>
        /// Gets all ids.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Guid> GetAllIds();

        /// <summary>
        /// Saves the snapshot.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        /// <param name="order">The order.</param>
        void SaveSnapshot(OrderSnapshot snapshot, Order order);

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        OrderSnapshot GetLatestSnapshot(Guid orderId);

        /// <summary>
        /// Gets the history for order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<HistoryItem>> GetHistoryForOrder(Guid orderId);
    }
}
