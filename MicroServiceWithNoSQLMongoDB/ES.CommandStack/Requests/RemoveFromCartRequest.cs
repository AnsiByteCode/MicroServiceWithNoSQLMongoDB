namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Remove From Cart Request
    /// </summary>
    public class RemoveFromCartRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveFromCartRequest" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public RemoveFromCartRequest(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; }
    }
}
