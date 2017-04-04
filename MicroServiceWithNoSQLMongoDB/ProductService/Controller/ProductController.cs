namespace ProductService.Controller
{
    #region Using
    using ES.ApplicationService;
    using ESSample.Common.ProductService;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Http;
    #endregion

    /// <summary>
    /// Product Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ProductController : ApiController
    {
        /// <summary>
        /// The _service
        /// </summary>
        private readonly IProductService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Http Response Message</returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll()
        {
            var result = await _service.GetProducts();
            if (result.Products != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.Products);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<HttpResponseMessage> GetById(Guid id)
        {
            var result = await _service.GetProductById(id);
            if (result.ProductDetail != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.ProductDetail);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }
        }

        /// <summary>
        /// Inserts the product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> InsertProduct(ProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.InsertProduct(model);
                    if (response.Success)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message);
                    }
                }
                catch (Exception)
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
        /// Updates the product.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<HttpResponseMessage> UpdateProduct(ProductsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _service.UpdateProduct(model);
                    if (response.Success)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message);
                    }
                }
                catch (Exception)
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
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteProduct(Guid id)
        {
            var response = await _service.DeleteProduct(id);
            if (response.Success)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message);
            }
        }
    }
}
