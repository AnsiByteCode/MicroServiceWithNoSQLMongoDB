namespace ES.Domain
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    public class RemoveCartItem : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartUpdated" /> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        public RemoveCartItem(Guid aggregateId) : base(aggregateId)
        {
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; }

        /// <summary>
        /// Gets the qty.
        /// </summary>
        /// <value>
        /// The qty.
        /// </value>
        public int Qty { get; }

        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        public Guid ProductId { get; }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public Guid CustomerId { get; }

        /// <summary>
        /// Gets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public string Mode { get; }
    }
}
