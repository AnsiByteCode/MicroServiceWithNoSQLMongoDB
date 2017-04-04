namespace ESSample.Web.Helper
{
    #region Using
    using ABC.Common.Helper;
    using Common.CartService;
    using ESSample.Common.CustomerService;
    using ESSample.Common.ProductService;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    #endregion

    /// <summary>
    /// Cart Helper
    /// </summary>
    public static class CartHelper
    {
        /// <summary>
        /// Posts the specified cart view model.
        /// </summary>
        /// <param name="addToCartRequestViewModel">The add to cart request view model.</param>
        /// <returns></returns>
        public static HttpStatusCode Post(AddToCartRequestViewModel addToCartRequestViewModel)
        {
            try
            {
                HttpContent content = new ObjectContent<AddToCartRequestViewModel>(addToCartRequestViewModel, JsonFormatterHelper.Instance.JsonMediaTypeFormatterInstance);
                var response = ABCApiHelper.Post(CartConfiguration.ApiBaseUrl, "Cart/AddtoCart", content);
                return response.StatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public static List<CartViewModel> GetCartByCustomerId(Guid customerId)
        {
            try
            {
                var response = ABCApiHelper.Get(CartConfiguration.ApiBaseUrl, "Cart/GetCartByCustomerId?customerId=" + customerId.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<CartViewModel>>().Result;
                }
                else
                {
                    return new List<CartViewModel>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}