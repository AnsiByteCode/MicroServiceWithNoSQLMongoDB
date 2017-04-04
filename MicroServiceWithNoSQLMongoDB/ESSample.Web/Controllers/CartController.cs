namespace ESSample.Web.Controllers
{
    using Helper;
    using System;
    #region Using
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Cart Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    [Authorize]
    public class CartController : Controller
    {
        // GET: Cart
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var userId = CommonHelper.GetCurrentUserId();
            if (userId != Guid.Empty)
            {
                var cartItems = CartHelper.GetCartByCustomerId(userId);
                return View(cartItems);
            }
            return RedirectToAction("Login", "Account");
        }
    }
}