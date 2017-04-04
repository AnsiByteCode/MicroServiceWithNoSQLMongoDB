namespace ES.CommandStack.Responses
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Create Order Response
    /// </summary>
    public class CreateOrderResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        public Guid ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public Guid OrderId { get; set; }    
    }
}
