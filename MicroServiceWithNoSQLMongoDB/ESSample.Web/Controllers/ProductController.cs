namespace ESSample.Web.Controllers
{
    #region Using
    using ESSample.Common.ProductService;
    using ESSample.Web.Helper;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;
    #endregion

    /// <summary>
    /// Product Controller
    /// </summary>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class ProductController : Controller
    {
        // GET: Product
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
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ActionResult Delete(Guid id)
        {
            var code = ProductHelper.Delete(id);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Products the insert.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProductInsert(Guid? id)
        {
            var productId = id;
            if (productId == null)
            {
                productId = Guid.Empty;
            }
            ProductsViewModel product = new ProductsViewModel();
            if (productId != Guid.Empty)
            {
                product = ProductHelper.GetProductById((Guid)productId);
            }
            return this.View(product);
        }

        /// <summary>
        /// Products the insert.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProductInsert(Guid? id, ProductsViewModel model)
        {
            var productId = id;
            var status = new HttpStatusCode();
            if (model.Id == Guid.Empty)
            {
                model.Id = Guid.NewGuid();
                status = ProductHelper.Post(model);
            }
            else
            {
                status = ProductHelper.Put(model.Id, model);
            }
            if (status == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return this.View(model);
            }
        }
    }
}