namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Create Order Request
    /// </summary>
    public class CreateOrderRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateOrderRequest" /> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        public CreateOrderRequest(Guid customerId)
        {
            CustomerId = customerId;
        }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }
    }
}
