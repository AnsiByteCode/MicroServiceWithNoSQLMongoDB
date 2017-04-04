namespace ES.Common
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Entity class
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; protected set; }
    }
}