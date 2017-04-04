namespace Core.Entities.Models
{
    #region Using
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System;
    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// Cart entity
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonElement("Id")]
        [Display(Name = "ID")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [BsonElement("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        /// <value>
        /// The Category.
        /// </value>
        [BsonElement("Category")]
        [Display(Name = "Category")]
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        [BsonElement("Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        /// <value>
        /// The Price.
        /// </value>
        [BsonElement("Price")]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or sets the Qty
        /// </summary>
        /// <value>
        /// The Qty
        /// </value>
        [BsonElement("Qty")]
        [Display(Name = "Qty")]
        public int? Qty { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>
        /// The product identifier.
        /// </value>
        [BsonElement("ProductId")]
        [Display(Name = "ProductId")]
        [BsonRepresentation(BsonType.String)]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [BsonElement("CustomerId")]
        [Display(Name = "CustomerId")]
        [BsonRepresentation(BsonType.String)]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the _id.
        /// </summary>
        /// <value>
        /// The _id.
        /// </value>
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [Display(Name = "_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
