namespace ES.Common
{
    #region Using
    using Newtonsoft.Json;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Event Sourced Aggregate
    /// </summary>
    /// <seealso cref="ES.Common.Entity" />
    public abstract class EventSourcedAggregate : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventSourcedAggregate"/> class.
        /// </summary>
        public EventSourcedAggregate()
        {
            Changes = new List<DomainEvent>();
        }

        /// <summary>
        /// Gets the changes.
        /// </summary>
        /// <value>
        /// The changes.
        /// </value>
        [JsonIgnore]
        public List<DomainEvent> Changes { get; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version { get; protected set; }

        /// <summary>
        /// Applies the specified changes.
        /// </summary>
        /// <param name="changes">The changes.</param>
        public abstract void Apply(DomainEvent changes);
    }
}