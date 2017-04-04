namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Get History For Customer Request
    /// </summary>
    /// <seealso cref="ES.Messages.IGetHistoryForCustomerRequest" />
    public class GetHistoryForCustomerRequest
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        public Guid RequestId { get; set; }
    }
}
