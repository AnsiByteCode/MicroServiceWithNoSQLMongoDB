namespace ES.Domain
{
    #region using
    using ES.Common;
    using System;
    #endregion

    /// <summary>
    /// Login Requested
    /// </summary>
    /// <seealso cref="ES.Common.DomainEvent" />
    public class LoginRequested : DomainEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRequested"/> class.
        /// </summary>
        /// <param name="aggregateId">The aggregate identifier.</param>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        public LoginRequested(Guid aggregateId, string email, string password) : base(aggregateId)
        {
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; }
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; }
    }
}
