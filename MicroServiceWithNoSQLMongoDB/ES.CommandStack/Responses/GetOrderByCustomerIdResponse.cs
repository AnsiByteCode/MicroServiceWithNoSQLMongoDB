namespace ES.CommandStack.Requests
{
    #region Using
    using ES.CommandStack.Responses;
    using ESSample.Common.OrderService;
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Get Order By CustomerId Response
    /// </summary>
    public class GetOrderByCustomerIdResponse : BaseResponse
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
        public List<OrderViewModel> Orders { get; set; }
    }
}
