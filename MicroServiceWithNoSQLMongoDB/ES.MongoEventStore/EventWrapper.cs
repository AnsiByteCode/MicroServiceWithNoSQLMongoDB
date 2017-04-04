namespace ES.MongoEventStore
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Event Wrapper
    /// </summary>
    public class EventWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventWrapper"/> class.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <param name="eventNumber">The event number.</param>
        /// <param name="streamStateId">The stream state identifier.</param>
        public EventWrapper(DomainEvent @event, int eventNumber, Guid streamStateId)
        {
            Event = @event;
            Type = @event.GetType().AssemblyQualifiedName;
            EventNumber = eventNumber;
            EventStreamId = streamStateId;
            Id = Guid.NewGuid();
            TimeStampUtc = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        public DomainEvent Event { get; private set; }

        /// <summary>
        /// Gets the event stream identifier.
        /// </summary>
        /// <value>
        /// The event stream identifier.
        /// </value>
        public Guid EventStreamId { get; private set; }

        /// <summary>
        /// Gets the event number.
        /// </summary>
        /// <value>
        /// The event number.
        /// </value>
        public int EventNumber { get; private set; }

        /// <summary>
        /// Gets the time stamp UTC.
        /// </summary>
        /// <value>
        /// The time stamp UTC.
        /// </value>
        public DateTime TimeStampUtc { get; private set; }
    }
}
