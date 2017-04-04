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
    /// Customer Class
    /// </summary>
    /// <seealso cref="Core.Entities.Models.IEntityObject" />
    public class Customer
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
        [Display(Name="Name")]
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [BsonElement("Address")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [BsonElement("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [BsonElement("Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the contact no.
        /// </summary>
        /// <value>
        /// The contact no.
        /// </value>
        [BsonElement("ContactNo")]
        [Display(Name = "ContactNo")]
        public string ContactNo { get; set; }

        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [Display(Name = "_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
