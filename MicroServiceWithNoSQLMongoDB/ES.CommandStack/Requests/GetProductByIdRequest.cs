namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Get Product By Id Request
    /// </summary>
    public class GetProductByIdRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductByIdRequest"/> class.
        /// </summary>
        /// <param name="requestId">The request identifier.</param>
        public GetProductByIdRequest(Guid requestId)
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
