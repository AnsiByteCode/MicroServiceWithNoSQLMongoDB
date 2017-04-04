namespace ES.Messages
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// IGet History For Customer Request
    /// </summary>
    public interface IGetHistoryForCustomerRequest
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        Guid RequestId { get; set; }
    }
}
