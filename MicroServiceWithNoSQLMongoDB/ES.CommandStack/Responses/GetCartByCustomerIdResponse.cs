namespace ES.CommandStack.Responses
{
    #region Using
    using ESSample.Common.CartService;
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Get Cart By Customer Id Response
    /// </summary>
    public class GetCartByCustomerIdResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        public Guid ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the cart details.
        /// </summary>
        /// <value>
        /// The cart details.
        /// </value>
        public List<CartViewModel> CartDetails { get; set; }
    }
}
