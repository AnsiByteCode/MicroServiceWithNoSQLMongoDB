namespace ES.ApplicationService
{
    #region Usings
    using ES.CommandStack.Responses;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// ICustomer Service
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets the login details.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        Task<GetLoginDetailsResponse> GetLoginDetails(string email,string password);
    }
}
