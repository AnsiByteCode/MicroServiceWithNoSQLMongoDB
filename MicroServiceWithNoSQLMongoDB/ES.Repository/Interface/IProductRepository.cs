namespace ES.Repository
{
    #region using
    using ES.Common;
    using ES.Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// IProduct Repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Adds the specified Product.
        /// </summary>
        /// <param name="Product">The Product.</param>
        void Add(Product Product);

        /// <summary>
        /// Saves the specified Product.
        /// </summary>
        /// <param name="Product">The Product.</param>
        void Save(Product Product);
        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="ProductId">The Product identifier.</param>
        /// <returns></returns>
        Product FindById(Guid ProductId);

        /// <summary>
        /// Gets all ids.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Guid> GetAllIds();
        /// <summary>
        /// Saves the snapshot.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        /// <param name="Product">The Product.</param>
        void SaveSnapshot(ProductSnapshot snapshot, Product Product);
        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="ProductId">The Product identifier.</param>
        /// <returns></returns>
        ProductSnapshot GetLatestSnapshot(Guid ProductId);

        /// <summary>
        /// Gets the history for Product.
        /// </summary>
        /// <param name="ProductId">The Product identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<HistoryItem>> GetHistoryForProduct(Guid ProductId);  
    }
}
