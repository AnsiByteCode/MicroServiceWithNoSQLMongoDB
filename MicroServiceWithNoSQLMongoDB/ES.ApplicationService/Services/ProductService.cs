namespace ES.ApplicationService
{
    #region Using
    using ES.CommandStack.Requests;
    using ES.CommandStack.Responses;
    using ESSample.Common.ProductService;
    using System;
    using System.Threading.Tasks;
    #endregion
    /// <summary>
    /// Product Service
    /// </summary>
    /// <seealso cref="ES.Contracts.IProductService" />
    public class ProductService : IProductService
    {
        /// <summary>
        /// The _request client creator
        /// </summary>
        private readonly IRequestClientCreator _requestClientCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="requestClientCreator">The request client creator.</param>
        public ProductService(IRequestClientCreator requestClientCreator)
        {
            _requestClientCreator = requestClientCreator;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        public async Task<GetProductsResponse> GetProducts()
        {
            var client = _requestClientCreator.Create<GetProductsRequest, GetProductsResponse>();
            var response = await client.Request(new GetProductsRequest(Guid.NewGuid()));
            return response;
        }

        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<GetProductByIdResponse> GetProductById(Guid id)
        {
            var client = _requestClientCreator.Create<GetProductByIdRequest, GetProductByIdResponse>();
            var response = await client.Request(new GetProductByIdRequest(id));
            return response;
        }

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public async Task<InsertUpdateProductResponse> InsertProduct(ProductsViewModel product)
        {
            var client = _requestClientCreator.Create<InsertUpdateProductRequest, InsertUpdateProductResponse>();
            var response = await client.Request(new InsertUpdateProductRequest(product.Id, product.Name, product.Category, product.Description, Convert.ToDecimal(product.Price), Convert.ToInt32(product.Qty), ES.Domain.Product.Inserted));
            return response;
        }

        /// <summary>
        /// Update the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public async Task<InsertUpdateProductResponse> UpdateProduct(ProductsViewModel product)
        {
            var client = _requestClientCreator.Create<InsertUpdateProductRequest, InsertUpdateProductResponse>();
            var response = await client.Request(new InsertUpdateProductRequest(product.Id, product.Name, product.Category, product.Description, Convert.ToDecimal(product.Price), Convert.ToInt32(product.Qty), ES.Domain.Product.Updated));
            return response;
        }


        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<DeleteProductResponse> DeleteProduct(Guid id)
        {
            var client = _requestClientCreator.Create<DeleteProductRequest, DeleteProductResponse>();
            var response = await client.Request(new DeleteProductRequest(id));
            return response;
        }
    }
}
