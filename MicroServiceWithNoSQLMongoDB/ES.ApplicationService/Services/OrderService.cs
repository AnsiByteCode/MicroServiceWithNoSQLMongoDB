namespace ES.ApplicationService
{
    #region Using
    using ES.CommandStack.Requests;
    using ES.CommandStack.Responses;
    using ServiceInterface;
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Order Service
    /// </summary>
    /// <seealso cref="ES.ApplicationService.ServiceInterface.IOrderService" />
    /// <seealso cref="ES.Contracts.IOrderService" />
    public class OrderService : IOrderService
    {
        /// <summary>
        /// The _request client creator
        /// </summary>
        private readonly IRequestClientCreator _requestClientCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderService"/> class.
        /// </summary>
        /// <param name="requestClientCreator">The request client creator.</param>
        public OrderService(IRequestClientCreator requestClientCreator)
        {
            _requestClientCreator = requestClientCreator;
        }

        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public async Task<CreateOrderResponse> CreateOrder(Guid customerId)
        {
            var client = _requestClientCreator.Create<CreateOrderRequest, CreateOrderResponse>();
            var createOrderRequest = new CreateOrderRequest(customerId);
            var response = await client.Request(createOrderRequest);
            return response;
        }

        /// <summary>
        /// Gets the order by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public async Task<GetOrderByCustomerIdResponse> GetOrdersByCustomerId(Guid customerId)
        {
            var client = _requestClientCreator.Create<GetOrderByCustomerIdRequest, GetOrderByCustomerIdResponse>();
            var createRequest = new GetOrderByCustomerIdRequest(customerId);
            var response = await client.Request(createRequest);
            return response;
        }

        /// <summary>
        /// Gets the order by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public async Task<GetOrderByOrderIdResponse> GetOrderByOrderId(Guid orderId)
        {
            var client = _requestClientCreator.Create<GetOrderByOrderIdRequest, GetOrderByOrderIdResponse>();
            var createRequest = new GetOrderByOrderIdRequest(orderId);
            var response = await client.Request(createRequest);
            return response;
        }
    }
}
