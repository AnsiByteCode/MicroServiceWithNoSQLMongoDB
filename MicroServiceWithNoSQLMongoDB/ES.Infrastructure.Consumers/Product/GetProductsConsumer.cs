namespace ES.Infrastructure.Consumers
{
    #region Using
    using CommandStack.Responses;
    using Core.Entities.Models;
    using Core.Services;
    using Domain.QueryModels;
    using ES.CommandStack.Requests;
    using ESSample.Common.ProductService;
    using MassTransit;
    using Repository;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    public class GetProductsConsumer : IConsumer<GetProductsRequest>
    {
        /// <summary>
        /// The customer service
        /// </summary>
        private IService<Product> productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLoginDetailsConsumer"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public GetProductsConsumer(IService<Product> productService, ICustomerRepository eventStoreRepository)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<GetProductsRequest> context)
        {
            try
            {
                await context.RespondAsync(new GetProductsResponse
                {
                    Products = productService.GetAll().Select(x => new ProductsViewModel()
                    {
                        Category = x.Category,
                        Description = x.Description,
                        Id = x.Id,
                        Name = x.Name,
                        Price = x.Price,
                        Qty = x.Qty
                    }).OrderBy(x => x.Name).ToList(),
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
                        Message = "Failed" + Environment.NewLine + exc.Message
                    });
                throw;
            }
        }
    }
}
