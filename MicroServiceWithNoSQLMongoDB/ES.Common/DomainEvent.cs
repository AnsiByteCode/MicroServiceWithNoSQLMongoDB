namespace ES.Common
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Domain Event
    /// </summary>
    public abstract class DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEvent"/> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        /// <summary>
        /// Gets the aggregate identifier.
        /// </summary>
        /// <value>
        /// The aggregate identifier.
        /// </value>
        public Guid AggregateId { get; set;}

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version { get; set; }
    }
}