namespace ES.CommandStack.Requests
{
    #region Using
    using ES.Domain.QueryModels;
    using System;
    using System.Collections.Generic;
    #endregion

    /// <summary>
    /// Get Login Details Request
    /// </summary>
    /// <seealso cref="ES.Messages.ILoginRequest" />
    public class GetLoginDetailsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetLoginDetailsRequest"/> class.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        public GetLoginDetailsRequest(Guid requestId, string email, string password)
        {
            Id = requestId;
            Email = email;
            Password = password;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
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
        public IEnumerable<GetLoginDetailsViewModel> CustomerDetails { get; set; }
    }
}
