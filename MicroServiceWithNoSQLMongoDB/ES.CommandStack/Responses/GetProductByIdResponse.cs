namespace ES.CommandStack.Responses
{
    #region Using
    using ESSample.Common.ProductService;
    using System;
    #endregion

    /// <summary>
    /// Get Product By Id Response
    /// </summary>
    public class GetProductByIdResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        public Guid ResponseId { get; set; }
      
        /// <summary>
        /// Gets or sets the product detail.
        /// </summary>
        /// <value>
        /// The product detail.
        /// </value>
        public ProductsViewModel ProductDetail { get; set; }
    }
}
