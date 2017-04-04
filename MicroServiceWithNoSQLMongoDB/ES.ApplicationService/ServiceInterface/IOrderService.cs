namespace ES.ApplicationService.ServiceInterface
{
    #region Using
    using ES.CommandStack.Requests;
    using ES.CommandStack.Responses;
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Order Service
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Orders the created.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        Task<CreateOrderResponse> CreateOrder(Guid customerId);

        /// <summary>
        /// Gets the orders by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        Task<GetOrderByCustomerIdResponse> GetOrdersByCustomerId(Guid customerId);

        /// <summary>
        /// Gets the order by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        Task<GetOrderByOrderIdResponse> GetOrderByOrderId(Guid orderId);
    }
}
