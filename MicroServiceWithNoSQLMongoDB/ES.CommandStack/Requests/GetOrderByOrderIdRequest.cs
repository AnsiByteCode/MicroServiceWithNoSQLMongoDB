namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Get Order By OrderId Request
    /// </summary>
    public class GetOrderByOrderIdRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderByOrderIdRequest" /> class.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        public GetOrderByOrderIdRequest(Guid orderId)
        {
            Id = orderId;
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
