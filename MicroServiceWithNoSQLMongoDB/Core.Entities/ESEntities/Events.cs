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
    public class Events
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
        [BsonElement("EventType")]
        [Display(Name = "EventType")]
        public string EventType { get; set; }

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
        /// Gets or sets the payload.
        /// </summary>
        /// <value>
        /// The payload.
        /// </value>
        [BsonElement("Payload")]
        [Display(Name = "Payload")]
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the event stream identifier.
        /// </summary>
        /// <value>
        /// The event stream identifier.
        /// </value>
        [BsonElement("EventStreamId")]
        [Display(Name = "EventStreamId")]
        [BsonRepresentation(BsonType.String)]
        public Guid EventStreamId{get;set;}

        /// <summary>
        /// Gets or sets the time stamp UTC.
        /// </summary>
        /// <value>
        /// The time stamp UTC.
        /// </value>
        [BsonElement("TimeStampUtc")]
        [Display(Name = "TimeStampUtc")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TimeStampUtc { get; set; }

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
