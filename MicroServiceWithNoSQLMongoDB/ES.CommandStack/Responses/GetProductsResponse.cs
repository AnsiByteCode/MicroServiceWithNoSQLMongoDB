namespace ES.CommandStack.Responses
{
    #region Using
    using ESSample.Common.ProductService;
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Get Products Response
    /// </summary>
    /// <seealso cref="ES.Common.Responses.BaseResponse" />
    public class GetProductsResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        public Guid ResponseId { get; set; }
    
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public List<ProductsViewModel> Products { get; set; }
    }
}
