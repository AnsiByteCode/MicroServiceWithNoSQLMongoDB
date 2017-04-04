namespace ES.CommandStack.Responses
{
    #region Using
    using ES.Domain.QueryModels;
    using System;
    #endregion

    /// <summary>
    /// Get Login Details Response
    /// </summary>
    public class GetLoginDetailsResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        public Guid ResponseId { get; set; }
   
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the customer details.
        /// </summary>
        /// <value>
        /// The customer details.
        /// </value>
        public GetLoginDetailsViewModel CustomerDetails { get; set; }
    }
}
