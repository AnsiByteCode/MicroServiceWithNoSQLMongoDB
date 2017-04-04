namespace ES.Infrastructure.Consumers
{
    #region Using
    using Core.Entities.Models;
    using Core.Services;
    using ES.CommandStack.Requests;
    using ES.CommandStack.Responses;
    using ESSample.Common.CartService;
    using MassTransit;
    using MongoDB.Driver.Builders;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    class GetCartByCustomerIdConsumer : IConsumer<GetCartByCustomerIdRequest>
    {
        /// <summary>
        /// The cart service
        /// </summary>
        private IService<Cart> cartService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartByCustomerIdConsumer"/> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        public GetCartByCustomerIdConsumer(IService<Cart> cartService)
        {
            this.cartService = cartService;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<GetCartByCustomerIdRequest> context)
        {
            try
            {
                var cartDetails = cartService.FilterWithQuery(Query.Matches("CustomerId", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.Id + "$/i"))).Select(x => new CartViewModel
                {
                    Category = x.Category,
                    Description = x.Description,
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Qty = x.Qty,
                    CustomerId = x.CustomerId,
                    ProductId = x.ProductId
                }).ToList();

                await context.RespondAsync(new GetCartByCustomerIdResponse
                {
                    CartDetails = cartDetails,
                    Message = "ok",
                    ResponseId = context.Message.Id,
                    Success = true
                });

            }
            catch (Exception exc)
            {
                await
                    context.RespondAsync(new GetProductsResponse
                    {
                        ResponseId = context.Message.Id,
                        Message = "Failed" + Environment.NewLine + exc.Message,
                        Success = false
                    });
                throw;
            }
        }
    }
}
