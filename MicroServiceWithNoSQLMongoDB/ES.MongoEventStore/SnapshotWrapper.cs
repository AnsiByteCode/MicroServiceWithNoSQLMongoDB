namespace ES.MongoEventStore
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Snapshot Wrapper
    /// </summary>
    public class SnapshotWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SnapshotWrapper"/> class.
        /// </summary>
        public SnapshotWrapper()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; }

        /// <summary>
        /// Gets or sets the name of the stream.
        /// </summary>
        /// <value>
        /// The name of the stream.
        /// </value>
        public string StreamName { get; set; }

        /// <summary>
        /// Gets or sets the snapshot.
        /// </summary>
        /// <value>
        /// The snapshot.
        /// </value>
        public object Snapshot { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }
    }
}
