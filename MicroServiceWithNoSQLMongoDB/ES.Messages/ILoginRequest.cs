namespace ES.Messages
{
    #region using
    using ES.Domain.QueryModels;
    using Domain.QueryModels;
    using System;
    #endregion

    /// <summary>
    /// I Login Request
    /// </summary>
    public class ILoginRequest
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the customer details.
        /// </summary>
        /// <value>
        /// The customer details.
        /// </value>
        GetLoginDetailsViewModel CustomerDetails { get; set; }
    }
}
