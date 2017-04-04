namespace ES.CommandStack.Events
{
    #region using
    using System;
    #endregion

    /// <summary>
    /// IProduct Created Event
    /// </summary>
    public interface IProductCreatedEvent
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
    }
}
