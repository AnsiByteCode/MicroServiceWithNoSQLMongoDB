namespace ES.ApplicationService
{
    #region Using
    using ES.CommandStack.Responses;
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// IHistory Service
    /// </summary>
    public interface IHistoryService
    {
        /// <summary>
        /// Gets the history for customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        Task<GetHistoryForCustomerResponse> GetHistoryForCustomer(Guid customerId);
    }
}
