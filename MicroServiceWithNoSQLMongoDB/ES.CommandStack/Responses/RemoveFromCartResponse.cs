namespace ES.CommandStack.Responses
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Remove From Cart Request
    /// </summary>
    public class RemoveFromCartResponse : BaseResponse
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
