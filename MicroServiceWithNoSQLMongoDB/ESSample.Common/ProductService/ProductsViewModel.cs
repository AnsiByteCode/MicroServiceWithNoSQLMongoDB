namespace ESSample.Common.ProductService
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Products View Model
    /// </summary>
    public class ProductsViewModel
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
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }

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
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the qty.
        /// </summary>
        /// <value>
        /// The qty.
        /// </value>
        public int? Qty { get; set; }
    }
}
