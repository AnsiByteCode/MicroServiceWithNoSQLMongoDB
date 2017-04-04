namespace Core.Entities.Models
{
    #region Using
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// Order class
    /// </summary>
    public class Order
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
        /// Gets or sets the Amount.
        /// </summary>
        /// <value>
        /// The Amount.
        /// </value>
        [BsonElement("Amount")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the Order Date
        /// </summary>
        /// <value>
        /// The Order Date
        /// </value>
        [BsonElement("OrderDate")]
        [Display(Name = "OrderDate")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        /// <value>
        /// The order status.
        /// </value>
        [BsonElement("OrderStatus")]
        [Display(Name = "OrderStatus")]
        public string OrderStatus { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        [BsonElement("CustomerId")]
        [Display(Name = "CustomerId")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>
        /// The order details.
        /// </value>
        [BsonElement("OrderDetails")]
        [Display(Name = "OrderDetails")]
        public List<Cart> OrderDetails { get; set; }

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
