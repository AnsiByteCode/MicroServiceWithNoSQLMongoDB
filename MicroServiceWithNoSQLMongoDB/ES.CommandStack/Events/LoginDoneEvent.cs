namespace ES.CommandStack.Events
{
    #region Using
    using System;
    #endregion

    /// <summary>
    /// Login Done Event
    /// </summary>
    /// <seealso cref="ES.CommandStack.Events.ILoginDoneEvent" />
    public class LoginDoneEvent : ILoginDoneEvent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}
