namespace ES.CommandStack.Events
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// ICart Event
    /// </summary>
    public interface ICartEvent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        /// <value>
        /// The Category.
        /// </value>
        string Category { get; set; }
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the Qty
        /// </summary>
        /// <value>
        /// The Qty
        /// </value>

        int? Qty { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        Guid CustomerId { get; set; }
    }
}
