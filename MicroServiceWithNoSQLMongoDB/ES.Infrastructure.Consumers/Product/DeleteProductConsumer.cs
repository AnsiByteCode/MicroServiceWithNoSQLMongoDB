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
    #endregion

    /// <summary>
    /// Insert Product Consumer
    /// </summary>
    /// <seealso cref="MassTransit.IConsumer{ES.CommandStack.Requests.DeleteProductRequest}" />
    public class DeleteProductConsumer : IConsumer<DeleteProductRequest>
    {
        /// <summary>
        /// The Product service
        /// </summary>
        private IService<Product> productService;

        /// <summary>
        /// The product repository
        /// </summary>
        private IProductRepository eventStoreRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductConsumer"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="eventStoreRepository">The event store repository.</param>
        public DeleteProductConsumer(IService<Product> productService, IProductRepository eventStoreRepository)
        {
            this.productService = productService;
            this.eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<DeleteProductRequest> context)
        {
            try
            {
                var isexistQuery = Query.Matches("Id", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.Id.ToString() + "$/i"));
                var productDetails = productService.FilterWithQuery(isexistQuery).Count();
                if (productDetails > 0)
                {
                    eventStoreRepository.Save(new ES.Domain.Product(context.Message.Id));
                    productService.Delete(isexistQuery);
                    await context.RespondAsync(new InsertUpdateProductResponse
                    {
                        Success = true,
                        Message = "ok"
                    });
                }
                else
                {
                    await context.RespondAsync(new InsertUpdateProductResponse
                    {
                        Success = false,
                        Message = "Product not exists"
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
