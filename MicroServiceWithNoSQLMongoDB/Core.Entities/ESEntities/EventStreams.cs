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
    /// Event Streams
    /// </summary>
    public class EventStreams
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
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [BsonElement("Type")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        [BsonElement("Version")]
        [Display(Name = "Version")]
        [BsonRepresentation(BsonType.Int32)]
        public int Version { get; set; }

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
