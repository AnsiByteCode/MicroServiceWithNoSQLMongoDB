namespace ES.CommandStack.Events
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Create Order Event
    /// </summary>
    /// <seealso cref="ES.CommandStack.Events.ICreateOrderEvent" />
    public class CreateOrderEvent : ICreateOrderEvent
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; set; }
    }
}
