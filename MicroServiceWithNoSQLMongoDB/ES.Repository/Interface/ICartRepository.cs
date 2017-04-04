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
    /// Cart Repository
    /// </summary>
    public interface ICartRepository
    {
        /// <summary>
        /// Adds the specified Cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        void Add(Cart cart);

        /// <summary>
        /// Saves the specified cart.
        /// </summary>
        /// <param name="cart">The cart.</param>
        void Save(Cart cart);

        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        Cart FindById(Guid cartId);

        /// <summary>
        /// Gets all ids.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Guid> GetAllIds();

        /// <summary>
        /// Saves the snapshot.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        /// <param name="cart">The cart.</param>
        void SaveSnapshot(CartSnapshot snapshot, Cart cart);

        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        CartSnapshot GetLatestSnapshot(Guid cartId);

        /// <summary>
        /// Gets the history for cart.
        /// </summary>
        /// <param name="cartId">The cart identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<HistoryItem>> GetHistoryForCart(Guid cartId);
    }
}
