namespace ES.Infrastructure.Consumers
{
    #region Using
    using Core.Entities.Models;
    using Core.Services;
    using ES.CommandStack.Requests;
    using ES.CommandStack.Responses;
    using ES.Repository.Interface;
    using MassTransit;
    using MongoDB.Driver.Builders;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Add to Cart Consumer
    /// </summary>
    /// <seealso cref="IConsumer{AddtoCartRequest}" />
    public class AddtoCartConsumer : IConsumer<AddtoCartRequest>
    {
        /// <summary>
        /// The Product service
        /// </summary>
        private IService<Cart> cartService;

        /// <summary>
        /// The product service
        /// </summary>
        private IService<Product> productService;

        /// <summary>
        /// The product repository
        /// </summary>
        private ICartRepository eventStoreRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddtoCartConsumer" /> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        /// <param name="productService">The product service.</param>
        /// <param name="eventStoreRepository">The event store repository.</param>
        public AddtoCartConsumer(IService<Cart> cartService, IService<Product> productService, ICartRepository eventStoreRepository)
        {
            this.cartService = cartService;
            this.productService = productService;
            this.eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<AddtoCartRequest> context)
        {
            try
            {
                var productData = productService.FilterWithQuery(Query.Matches("Id", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.ProductId.ToString() + "$/i"))).FirstOrDefault();
                if (productData != null)
                {
                    var isexistQuery = Query.And(Query.Matches("ProductId", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.ProductId.ToString() + "$/i")), Query.Matches("CustomerId", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.CustomerId.ToString() + "$/i")));
                    var itemDetails = cartService.FilterWithQuery(isexistQuery).Count();
                    if (itemDetails == 0)
                    {
                        var cartId = Guid.NewGuid();
                        cartService.Insert(new Cart()
                        {
                            Category = productData.Category,
                            CustomerId = context.Message.CustomerId,
                            Description = productData.Description,
                            Id = cartId,
                            Name = productData.Name,
                            Price = productData.Price,
                            ProductId = productData.Id,
                            Qty = 1
                        });
                        eventStoreRepository.Add(new ES.Domain.Cart(cartId, productData.Name, productData.Category, productData.Description, Convert.ToDecimal(productData.Price), Convert.ToInt32(productData.Qty), productData.Id, context.Message.CustomerId, "Added"));
                    }
                    else
                    {
                        var cartItem = cartService.FilterWithQuery(isexistQuery).FirstOrDefault();
                        if (cartItem != null)
                        {
                            cartItem.Qty += 1;
                            cartService.Update(isexistQuery, cartItem);
                            eventStoreRepository.Save(new ES.Domain.Cart(cartItem.Id, productData.Name, productData.Category, productData.Description, Convert.ToDecimal(productData.Price), Convert.ToInt32(productData.Qty), productData.Id, context.Message.CustomerId, "Added"));
                        }
                    }

                    await context.RespondAsync(new AddtoCartResponse
                    {
                        Success = true,
                        Message = "ok"
                    });
                }

                await context.RespondAsync(new AddtoCartResponse
                {
                    Success = false,
                    Message = "Product Not Found",
                });
            }
            catch (Exception exc)
            {
                await context.RespondAsync(new AddtoCartResponse
                {
                    Success = false,
                    Message = "Failed" + Environment.NewLine + exc.Message
                });
                throw;
            }
        }

    }
}
