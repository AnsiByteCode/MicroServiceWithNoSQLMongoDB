namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Insert Product Request
    /// </summary>
    public class AddtoCartRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertProductRequest" /> class.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        public AddtoCartRequest(Guid productId,Guid customerId)
        {
            ProductId = productId;
            CustomerId = customerId;
        }

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
