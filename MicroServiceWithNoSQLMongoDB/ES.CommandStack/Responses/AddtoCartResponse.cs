namespace ES.CommandStack.Responses
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Insert Product Response
    /// </summary>
    public class AddtoCartResponse : BaseResponse
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
