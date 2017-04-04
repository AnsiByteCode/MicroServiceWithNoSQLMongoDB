namespace ES.ApplicationService
{
    #region Using
    using ES.CommandStack.Responses;
    using ESSample.Common.ProductService;
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// IProduct Service
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets the products.
        /// </summary>
        /// <returns></returns>
        Task<GetProductsResponse> GetProducts();

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<GetProductByIdResponse> GetProductById(Guid id);

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        Task<InsertUpdateProductResponse> InsertProduct(ProductsViewModel product);

        /// <summary>
        /// Updates the product.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        Task<InsertUpdateProductResponse> UpdateProduct(ProductsViewModel product);

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<DeleteProductResponse> DeleteProduct(Guid id);
    }
}
