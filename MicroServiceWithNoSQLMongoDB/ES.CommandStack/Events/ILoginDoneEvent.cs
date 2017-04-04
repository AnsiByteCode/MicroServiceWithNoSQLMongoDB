namespace ES.CommandStack.Events
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// I Login Done Event
    /// </summary>
    public interface ILoginDoneEvent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }
    }
}
