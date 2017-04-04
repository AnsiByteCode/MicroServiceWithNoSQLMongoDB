namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Get Products Request
    /// </summary>
    public class GetProductsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductsRequest"/> class.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        public GetProductsRequest(Guid requestId)
        {
            Id = requestId;
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
