namespace ES.Infrastructure.Consumers
{
    #region Using
    using CommandStack.Responses;
    using Core.Entities.Models;
    using Core.Services;
    using ES.CommandStack.Requests;
    using Repository;
    using MassTransit;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MongoDB.Driver.Builders;
    using Repository.Interface;
    using ESSample.Common.OrderService;
    #endregion

    /// <summary>
    /// Insert Order Consumer
    /// </summary>
    /// <seealso cref="MassTransit.IConsumer{ES.CommandStack.Requests.CreateOrderRequest}" />
    public class OrderCreatedConsumer : IConsumer<CreateOrderRequest>
    {
        /// <summary>
        /// The order service
        /// </summary>
        private IService<Order> orderService;

        /// <summary>
        /// The cart service
        /// </summary>
        private IService<Cart> cartService;

        /// <summary>
        /// The order repository
        /// </summary>
        private IOrderRepository eventStoreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCreatedConsumer" /> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        /// <param name="orderService">The order service.</param>
        /// <param name="eventStoreRepository">The event store repository.</param>
        public OrderCreatedConsumer(IService<Cart> cartService, IService<Order> orderService, IOrderRepository eventStoreRepository)
        {
            this.orderService = orderService;
            this.cartService = cartService;
            this.eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<CreateOrderRequest> context)
        {
            try
            {
                var orderId = Guid.NewGuid();
                var isexistQuery = Query.Matches("CustomerId", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.CustomerId + "$/i"));
                var cartDetails = cartService.FilterWithQuery(isexistQuery).ToList();
                if (cartDetails.Count > 0)
                {
                    Order order = new Order();
                    order.Id = orderId;
                    order.OrderDate = DateTime.UtcNow;
                    order.Amount = Convert.ToDecimal(cartDetails.Sum(x => (x.Price * x.Qty)));
                    order.OrderStatus = Enum.GetName(typeof(OrderStatus), OrderStatus.Created);
                    order.CustomerId = context.Message.CustomerId;
                    order.OrderDetails = cartDetails;
                    orderService.Insert(order);
                    cartService.Delete(isexistQuery);
                    eventStoreRepository.Add(new ES.Domain.Order(orderId, context.Message.CustomerId));
                }
                await context.RespondAsync(new CreateOrderResponse
                {
                    Success = true,
                    Message = "Order placed successfully",
                    OrderId = orderId
                });
            }
            catch (Exception exc)
            {
                await context.RespondAsync(new CreateOrderResponse
                {
                    Success = false,
                    Message = "Failed" + Environment.NewLine + exc.Message
                });
                throw;
            }
        }
    }
}
