namespace ProductService.Controller
{
    #region Using
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    using ES.ApplicationService.ServiceInterface;
    #endregion

    /// <summary>
    /// Order Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class OrderController : ApiController
    {
        /// <summary>
        /// The _service
        /// </summary>
        private readonly IOrderService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="orderService">The customer service.</param>
        public OrderController(IOrderService orderService)
        {
            _service = orderService;
        }

        /// <summary>
        /// Inserts the order.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> CreateOrder([FromUri] Guid customerId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.CreateOrder(customerId);
                    if (response.Success)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Gets the orders by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetOrdersByCustomerId(Guid customerId)
        {
            var response = await _service.GetOrdersByCustomerId(customerId);
            if (response.Success)
            {
                return Request.CreateResponse(HttpStatusCode.OK,response.Orders);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message);
            }
        }

        /// <summary>
        /// Gets the orders by order identifier.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetOrdersByOrderId(Guid orderId)
        {
            var response = await _service.GetOrderByOrderId(orderId);
            if (response.Success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response.Order);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message);
            }
        }
    }
}
