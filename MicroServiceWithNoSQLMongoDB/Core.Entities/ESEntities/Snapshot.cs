namespace Core.Entities.ESEntities
{
    #region using
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson.Serialization.IdGenerators;
    using System;
    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// Snapshot entity
    /// </summary>
    public class SnapshotEntity
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
        public Guid EventStreamId { get; set; }

        /// <summary>
        /// Gets or sets the time stamp UTC.
        /// </summary>
        /// <value>
        /// The time stamp UTC.
        /// </value>
        [BsonElement("CreatedUtc")]
        [Display(Name = "CreatedUtc")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedUtc { get; set; }

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
