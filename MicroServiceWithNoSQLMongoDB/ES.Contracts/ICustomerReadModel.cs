namespace ES.Contracts
{
    #region Using
    using ES.Domain.QueryModels;
    #endregion

    /// <summary>
    /// ICustomer ReadModel
    /// </summary>
    public interface ICustomerReadModel
    {
        /// <summary>
        /// Gets the login details.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        GetLoginDetails GetLoginDetails(string email,string password);
    }
}
