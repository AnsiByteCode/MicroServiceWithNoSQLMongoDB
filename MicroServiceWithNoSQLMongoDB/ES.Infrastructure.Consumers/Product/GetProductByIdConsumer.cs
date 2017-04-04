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
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MassTransit.IConsumer{ES.CommandStack.Requests.GetProductByIdRequest}" />
    public class GetProductByIdConsumer : IConsumer<GetProductByIdRequest>
    {

        /// <summary>
        /// The customer service
        /// </summary>
        private IService<Product> productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetLoginDetailsConsumer"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public GetProductByIdConsumer(IService<Product> productService, ICustomerRepository eventStoreRepository)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Consumes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public async Task Consume(ConsumeContext<GetProductByIdRequest> context)
        {
            try
            {
                var filter = new Dictionary<string, string>();
                filter.Add("Id", context.Message.Id.ToString().ToUpper());
                var productDetails = productService.Filter(filter).FirstOrDefault();
                if (productDetails != null) {
                    await context.RespondAsync(new GetProductByIdResponse
                    {
                        ProductDetail = new ProductsViewModel()
                        {
                            Category = productDetails.Category,
                            Description = productDetails.Description,
                            Id = productDetails.Id,
                            Name = productDetails.Name,
                            Price = productDetails.Price,
                            Qty = productDetails.Qty
                        },
                        Message = "ok",
                        ResponseId = context.Message.Id,
                        Success = true
                    });
                }
                
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
