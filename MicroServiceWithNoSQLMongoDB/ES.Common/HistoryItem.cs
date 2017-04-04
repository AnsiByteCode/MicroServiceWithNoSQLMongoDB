namespace ES.Common
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// History Item
    /// </summary>
    public class HistoryItem
    {
        /// <summary>
        /// Gets or sets the domain event.
        /// </summary>
        /// <value>
        /// The domain event.
        /// </value>
        public string DomainEvent { get; set; }

        /// <summary>
        /// Gets or sets the timestamp UTC.
        /// </summary>
        /// <value>
        /// The timestamp UTC.
        /// </value>
        public DateTime TimestampUtc { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version { get; set; }
    }
}