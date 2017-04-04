namespace ES.CommandStack.Events
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// IProduct Created Event
    /// </summary>
    /// <seealso cref="ES.CommandStack.Events.IProductCreatedEvent" />
    public class ProductCreatedEvent : IProductCreatedEvent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        /// <value>
        /// The Category.
        /// </value>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the Qty
        /// </summary>
        /// <value>
        /// The Qty
        /// </value>
        public int? Qty { get; set; }
    }
}
