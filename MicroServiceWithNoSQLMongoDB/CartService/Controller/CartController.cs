namespace CartService
{
    #region Using
    using ES.ApplicationService.ServiceInterface;
    using ESSample.Common.CartService;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Cors;
    #endregion

    /// <summary>
    /// Cart Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CartController : ApiController
    {
        /// <summary>
        /// The _service
        /// </summary>
        private readonly ICartService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartController" /> class.
        /// </summary>
        /// <param name="cartService">The cart service.</param>
        public CartController(ICartService cartService)
        {
            _service = cartService;
        }

        /// <summary>
        /// Gets the cart by customer identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetCartByCustomerId(Guid customerId)
        {
            var result = await _service.GetCartByCustomerId(customerId);
            if (result.Success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.CartDetails);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }

        /// <summary>
        /// Addtoes the cart.
        /// </summary>
        /// <param name="cartItem">The cart item.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> AddtoCart(AddToCartRequestViewModel cartItem)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.AddtoCart(cartItem);
                if (result.Success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }


        /// <summary>
        /// Addtoes the cart.
        /// </summary>
        /// <param name="cartItemId">The cart item identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> RemoveFromCart(Guid cartItemId)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.RemoveFromCart(cartItemId);
                if (result.Success)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result.Message);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
