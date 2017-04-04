namespace ES.Domain
{
    #region using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Order Created
    /// </summary>
    /// <seealso cref="ES.Common.DomainEvent" />
    public class OrderCreated : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCreated"/> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        public OrderCreated(Guid aggregateId, Guid customerId) : base(aggregateId)
        {
            CustomerId = customerId;
        }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; }
    }
}
