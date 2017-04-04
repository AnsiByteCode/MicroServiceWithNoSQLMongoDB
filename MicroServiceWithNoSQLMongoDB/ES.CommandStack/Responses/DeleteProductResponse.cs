namespace ES.CommandStack.Responses
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Delete Product Response
    /// </summary>
    public class DeleteProductResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        public Guid ResponseId { get; set; }
    }
}
