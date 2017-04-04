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
    /// <seealso cref="MassTransit.IConsumer{ES.CommandStack.Requests.InsertProductRequest}" />
    public class InsertUpdateProductConsumer : IConsumer<InsertUpdateProductRequest>
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
        /// Initializes a new instance of the <see cref="InsertUpdateProductConsumer"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="eventStoreRepository">The event store repository.</param>
        public InsertUpdateProductConsumer(IService<Product> productService, IProductRepository eventStoreRepository)
        {
            this.productService = productService;
            this.eventStoreRepository = eventStoreRepository;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<InsertUpdateProductRequest> context)
        {
            try
            {
                var isexistQuery = Query.And(Query.Matches("Name", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.Name + "$/i")), Query.Matches("Category", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.Category + "$/i")));
                var productDetails = productService.FilterWithQuery(isexistQuery).ToList();
                if (context.Message.Mode == ES.Domain.Product.Updated)
                {
                    productDetails = productDetails.Where(x => x.Id != context.Message.Id).ToList();
                }

                if (productDetails.Count() == 0)
                {
                    eventStoreRepository.Save(new ES.Domain.Product(context.Message.Id, context.Message.Name, context.Message.Category, context.Message.Description, context.Message.Price, context.Message.Qty, context.Message.Mode));
                    if (context.Message.Mode == ES.Domain.Product.Updated)
                    {
                        productService.Update(Query.Matches("Id", new MongoDB.Bson.BsonRegularExpression("/^" + context.Message.Id + "$/i")), new Product() { Category = context.Message.Category, Description = context.Message.Description, Id = context.Message.Id, Name = context.Message.Name, Price = context.Message.Price, Qty = context.Message.Qty });
                    }
                    else
                    {
                        productService.Insert(new Product() { Category = context.Message.Category, Description = context.Message.Description, Id = context.Message.Id, Name = context.Message.Name, Price = context.Message.Price, Qty = context.Message.Qty });
                    }
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
                        Message = "Product already exists"
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
