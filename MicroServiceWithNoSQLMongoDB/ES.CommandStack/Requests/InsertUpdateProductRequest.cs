namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Insert Product Request
    /// </summary>
    public class InsertUpdateProductRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsertProductRequest"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="category">The category.</param>
        /// <param name="description">The description.</param>
        /// <param name="price">The price.</param>
        /// <param name="qty">The qty.</param>
        public InsertUpdateProductRequest(Guid id, string name, string category, string description, decimal price, int qty,string mode)
        {
            Id = id;
            Name = name;
            Category = category;
            Description = description;
            Price = price;
            Qty = qty;
            Mode = mode;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }
        /// <summary>
        /// Gets or sets the qty.
        /// </summary>
        /// <value>
        /// The qty.
        /// </value>
        public int Qty { get; set; }

        /// <summary>
        /// Gets or sets the mode.
        /// </summary>
        /// <value>
        /// The mode.
        /// </value>
        public string Mode { get; set; }
    }
}
