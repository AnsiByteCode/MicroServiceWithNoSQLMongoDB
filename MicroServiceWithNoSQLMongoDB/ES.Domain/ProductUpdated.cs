
namespace ES.Domain
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Product Updated
    /// </summary>
    /// <seealso cref="ES.Common.DomainEvent" />
    public class ProductUpdated : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductUpdated" /> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="qty">The qty.</param>
        /// <param name="mode">The mode.</param>
        public ProductUpdated(Guid aggregateId, string name, string category,string description,decimal price,int qty,string mode) : base(aggregateId)
        {
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Qty = qty;
            Mode = mode;
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
        public string Description { get;}

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
        /// Gets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public string Mode { get; }
    }
}
