namespace ES.Domain
{
    #region Using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Product Deleted
    /// </summary>
    /// <seealso cref="ES.Common.DomainEvent" />
    public class ProductDeleted : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDeleted" /> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>

        public ProductDeleted(Guid aggregateId) : base(aggregateId)
        {
       
        }
    }
}
