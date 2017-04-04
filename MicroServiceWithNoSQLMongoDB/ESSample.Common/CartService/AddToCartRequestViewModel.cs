namespace ESSample.Common.CartService
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Add To Cart Request View Model
    /// </summary>
    public class AddToCartRequestViewModel
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }
    }
}
