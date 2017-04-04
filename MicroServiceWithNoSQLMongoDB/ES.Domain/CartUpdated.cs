namespace ES.Domain
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    public class CartUpdated : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartUpdated" /> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="mode">The mode.</param>
        public CartUpdated(Guid aggregateId, string name, string category, string description, decimal price, int qty,Guid productId,Guid customerId, string mode) : base(aggregateId)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Qty = qty;
            ProductId = productId;
            CustomerId = customerId;
            Mode = mode;
            AggregateId = aggregateId;
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
