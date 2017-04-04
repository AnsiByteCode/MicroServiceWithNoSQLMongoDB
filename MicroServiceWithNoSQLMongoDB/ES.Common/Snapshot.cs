namespace ES.Common
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Snapshot
    /// </summary>
    public class Snapshot
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public int Version { get; set; }

    }
}
