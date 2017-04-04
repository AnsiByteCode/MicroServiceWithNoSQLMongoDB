namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Get Cart By CustomerId Request
    /// </summary>
    public class GetCartByCustomerIdRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartByCustomerIdRequest"/> class.
        /// </summary>
        /// <param name="customerId">The request identifier.</param>
        public GetCartByCustomerIdRequest(Guid customerId)
        {
            Id = customerId;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}
