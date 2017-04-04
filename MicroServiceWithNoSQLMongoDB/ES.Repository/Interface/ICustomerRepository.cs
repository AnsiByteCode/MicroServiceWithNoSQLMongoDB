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
    /// ICustomer Repository
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Adds the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void Add(Customer customer);

        /// <summary>
        /// Saves the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        void Save(Customer customer);
        /// <summary>
        /// Finds the by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        Customer FindById(Guid customerId);

        /// <summary>
        /// Gets all ids.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Guid> GetAllIds();
        /// <summary>
        /// Saves the snapshot.
        /// </summary>
        /// <param name="snapshot">The snapshot.</param>
        /// <param name="customer">The customer.</param>
        void SaveSnapshot(CustomerSnapshot snapshot, Customer customer);
        /// <summary>
        /// Gets the latest snapshot.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        CustomerSnapshot GetLatestSnapshot(Guid customerId);

        /// <summary>
        /// Gets the history for customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<HistoryItem>> GetHistoryForCustomer(Guid customerId);
    }
}
