namespace ES.CommandStack.Requests
{
    #region Using
    using ES.CommandStack.Responses;
    using ESSample.Common.OrderService;
    using System;
    #endregion

    /// <summary>
    /// Get Order By OrderId Response
    /// </summary>
    public class GetOrderByOrderIdResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>
        /// The order details.
        /// </value>
        public OrderViewModel Order { get; set; }
    }
}
