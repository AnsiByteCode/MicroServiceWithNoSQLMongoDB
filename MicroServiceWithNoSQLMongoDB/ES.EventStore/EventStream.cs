namespace ES.EventStore
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Event Stream
    /// </summary>
    public class EventStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventStream"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        public EventStream(Guid id, string type)
        {
            Id = id;
            Type = type;
            Version = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStream"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="type">The type.</param>
        /// <param name="version">The version.</param>
        public EventStream(Guid id, string type, int version)
        {
            Id = id;
            Type = type;
            Version = version;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version { get; private set; }

        /// <summary>
        /// Registers the event.
        /// </summary>
        /// <param name="event">The event.</param>
        /// <returns></returns>
        public EventWrapper RegisterEvent(DomainEvent @event)
        {
            Version++;
            @event.Version = Version;
            return new EventWrapper(@event, Version, Id);
        }
    }
}
