namespace CustomerService.Controllers
{
    #region Using
    using ES.ApplicationService;
    using ESSample.Common.CustomerService;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    #endregion

    /// <summary>
    /// Customer Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        /// <summary>
        /// The _service
        /// </summary>
        private readonly ICustomerService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public CustomerController(ICustomerService customerService)
        {
            _service = customerService;
        }

        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="loginRequest">The login request.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Login(LoginRequest loginRequest)
        {
            if (loginRequest != null && string.IsNullOrEmpty(loginRequest.Email) == false && string.IsNullOrEmpty(loginRequest.Password) == false)
            {
                var result = await _service.GetLoginDetails(loginRequest.Email, loginRequest.Password);
                if (result.CustomerDetails != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result.CustomerDetails);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
