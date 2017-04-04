namespace ESSample.Web.Controllers
{
    #region Using
    using ESSample.Common.ProductService;
    using Helper;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Customer Products Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class CustomerProductsController : Controller
    {
        // GET: CustomerProducts
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IEnumerable<ProductsViewModel> products = ProductHelper.ProductsGetAll();
            return this.View(products);
        }

        /// <summary>
        /// Addtoes the cart.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public ActionResult AddtoCart(Guid productId)
        {
            var userId = CommonHelper.GetCurrentUserId();
            if (userId != Guid.Empty)
            {
                var response = CartHelper.Post(new Common.CartService.AddToCartRequestViewModel() { CustomerId = userId, ProductId = productId });
                if (response == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Cart");
                }
                else {
                    TempData["message"] = "Error occurred while adding product to cart";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}