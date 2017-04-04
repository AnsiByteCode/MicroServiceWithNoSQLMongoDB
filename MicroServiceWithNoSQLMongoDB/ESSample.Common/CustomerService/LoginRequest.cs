
namespace ESSample.Common.CustomerService
{
    #region Using
    using System.ComponentModel.DataAnnotations;
    #endregion

    /// <summary>
    /// Login Request
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [Required]
        public string Password { get; set; }
    }
}
