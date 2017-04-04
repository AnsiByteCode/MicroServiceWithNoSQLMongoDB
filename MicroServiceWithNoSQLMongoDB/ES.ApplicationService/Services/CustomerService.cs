namespace ES.ApplicationService
{
    #region Using
    using ApplicationService;
    using ES.CommandStack.Requests;
    using ES.CommandStack.Responses;
    using System;
    using System.Threading.Tasks;
    #endregion

    /// <summary>
    /// Customer Service
    /// </summary>
    /// <seealso cref="ES.Contracts.ICustomerService" />
    public class CustomerService : ICustomerService
    {
        private readonly IRequestClientCreator _requestClientCreator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="requestClientCreator">The request client creator.</param>
        public CustomerService(IRequestClientCreator requestClientCreator)
        {
            _requestClientCreator = requestClientCreator;
        }

        /// <summary>
        /// Gets the login details.
        /// </summary>
        /// <param name="loginRequest">The login request.</param>
        /// <returns></returns>
        public async Task<GetLoginDetailsResponse> GetLoginDetails(string email, string password)
        {
            var client = _requestClientCreator.Create<GetLoginDetailsRequest, GetLoginDetailsResponse>();
            var createCustomerRequest = new GetLoginDetailsRequest(Guid.NewGuid(), email, password);
            var response = await client.Request(createCustomerRequest);
            return response;
        }

    }
}
