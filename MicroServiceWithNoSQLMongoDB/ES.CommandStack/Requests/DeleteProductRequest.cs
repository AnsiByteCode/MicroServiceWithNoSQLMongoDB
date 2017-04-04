namespace ES.CommandStack.Requests
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Delete Product Request
    /// </summary>
    public class DeleteProductRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductRequest" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public DeleteProductRequest(Guid id)
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
