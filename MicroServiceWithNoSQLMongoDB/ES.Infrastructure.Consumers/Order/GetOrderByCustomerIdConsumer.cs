namespace ES.Infrastructure.Consumers
{
    #region Using
    using Core.Entities.Models;
    using Core.Services;
    using ES.CommandStack.Requests;
    using ESSample.Common.OrderService;
    using MassTransit;
    using MongoDB.Driver.Builders;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Get Orders By CustomerId Consumer
    /// </summary>
    /// <seealso cref="MassTransit.IConsumer{ES.CommandStack.Requests.GetOrderByOrderIdRequest}" />
    class GetOrderByOrderIdConsumer : IConsumer<GetOrderByOrderIdRequest>
    {
        /// <summary>
        /// The Order service
        /// </summary>
        private IService<Order> orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderByOrderIdConsumer" /> class.
        /// </summary>
        /// <param name="orderService">The order service.</param>
        public GetOrderByOrderIdConsumer(IService<Order> orderService)
        {
            this.orderService = orderService;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<GetOrderByOrderIdRequest> context)
        {
            try
            {
                var orderDetails = orderService.FilterWithQuery(Query.Matches("Id", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.Id + "$/i"))).Select(x => new OrderViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CustomerId = x.CustomerId,
                    OrderDate = x.OrderDate,
                    OrderDetails = x.OrderDetails.Select(y => new OrderDetails
                    {
                        Category = y.Category,
                        Description = y.Description,
                        Name = y.Name,
                        Price = y.Price,
                        ProductId = y.ProductId,
                        Qty = y.Qty
                    }).ToList(),
                    OrderStatus = x.OrderStatus
                }).FirstOrDefault();

                await context.RespondAsync(new GetOrderByOrderIdResponse
                {
                    Order = orderDetails,
                    Message = "ok",
                    Id = context.Message.Id,
                    Success = true
                });

            }
            catch (Exception exc)
            {
                await
                    context.RespondAsync(new GetOrderByOrderIdResponse
                    {
                        Message = "Failed" + Environment.NewLine + exc.Message,
                        Success = false
                    });
                throw;
            }
        }
    }
}
