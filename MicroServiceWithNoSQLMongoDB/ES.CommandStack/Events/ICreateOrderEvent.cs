namespace ES.CommandStack.Events
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Create Order Event
    /// </summary>
    public interface ICreateOrderEvent
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        Guid CustomerId { get; set; }
    }
}
