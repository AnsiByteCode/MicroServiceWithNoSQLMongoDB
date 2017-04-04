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
    #endregion

    /// <summary>
    /// Remove from Cart
    /// </summary>
    /// <seealso cref="MassTransit.IConsumer{ES.CommandStack.Requests.RemoveFromCartRequest}" />
    public class RemoveFromCartConsumer : IConsumer<RemoveFromCartRequest>
    {
        /// <summary>
        /// The Cart service
        /// </summary>
        private IService<Cart> cartService;

        /// <summary>
        /// The cart repository
        /// </summary>
        private ICartRepository eventStoreRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveFromCartConsumer" /> class.
        /// </summary>
        /// <param name="cartService">The product service.</param>
        /// <param name="eventStoreRepository">The event store repository.</param>
        public RemoveFromCartConsumer(IService<Cart> cartService, ICartRepository eventStoreRepository)
        {
            this.cartService = cartService;
            this.eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<RemoveFromCartRequest> context)
        {
            try
            {
                var isexistQuery = Query.Matches("Id", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.Id.ToString() + "$/i"));
                var cartItems = cartService.FilterWithQuery(isexistQuery).ToList();
                if (cartItems.Count > 0)
                {
                    var cartItem = cartItems.FirstOrDefault();
                    eventStoreRepository.Save(new ES.Domain.Cart(cartItem.Id, cartItem.Name,cartItem.Category, cartItem.Description, Convert.ToDecimal(cartItem.Price), Convert.ToInt32(cartItem.Qty), cartItem.ProductId, cartItem.CustomerId, "Delete"));
                    cartService.Delete(isexistQuery);
                    await context.RespondAsync(new RemoveFromCartResponse
                    {
                        Success = true,
                        Message = "ok"
                    });
                }
                else
                {
                    await context.RespondAsync(new RemoveFromCartResponse
                    {
                        Success = false,
                        Message = "Item in the cart not exists"
                    });
                }
            }
            catch (Exception exc)
            {
                await context.RespondAsync(new InsertUpdateProductResponse
                {
                    Success = false,
                    Message = "Failed" + Environment.NewLine + exc.Message
                });
                throw;
            }
        }
    }
}
