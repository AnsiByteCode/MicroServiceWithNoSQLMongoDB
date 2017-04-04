namespace ESSample.Web.Helper
{
    #region Using
    using ABC.Common.Helper;
    using ESSample.Common.CustomerService;
    using ESSample.Common.ProductService;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    #endregion

    /// <summary>
    /// Product Helper
    /// </summary>
    public static class ProductHelper
    {
        /// <summary>
        /// Productses the get all.
        /// </summary>
        /// <returns></returns>
        public static List<ProductsViewModel> ProductsGetAll()
        {
            try
            {
                var response = ABCApiHelper.Get(ProductConfiguration.ApiBaseUrl, "Product/GetAll/");
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<ProductsViewModel>>().Result;
                }
                else
                {
                    return new List<ProductsViewModel>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the product by identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public static ProductsViewModel GetProductById(Guid productId)
        {
            try
            {
                var response = ABCApiHelper.Get(ProductConfiguration.ApiBaseUrl, "Product/GetById/" + productId.ToString());
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<ProductsViewModel>().Result;
                }
                else
                {
                    return new ProductsViewModel();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Posts the specified product view model.
        /// </summary>
        /// <param name="productViewModel">The product view model.</param>
        /// <returns></returns>
        public static HttpStatusCode Post(ProductsViewModel productViewModel)
        {
            try
            {
                HttpContent content = new ObjectContent<ProductsViewModel>(productViewModel, JsonFormatterHelper.Instance.JsonMediaTypeFormatterInstance);
                var response = ABCApiHelper.Post(ProductConfiguration.ApiBaseUrl, "Product/InsertProduct", content);
                return response.StatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Puts the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <param name="productViewModel">The product view model.</param>
        /// <returns></returns>
        public static HttpStatusCode Put(Guid productId,ProductsViewModel productViewModel)
        {
            try
            {
                HttpContent content = new ObjectContent<ProductsViewModel>(productViewModel, JsonFormatterHelper.Instance.JsonMediaTypeFormatterInstance);
                var response = ABCApiHelper.Put(ProductConfiguration.ApiBaseUrl, "Product/UpdateProduct", content);
                return response.StatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes the specified product identifier.
        /// </summary>
        /// <param name="productId">The product identifier.</param>
        /// <returns></returns>
        public static HttpStatusCode Delete(Guid productId)
        {
            try
            {
                var response = ABCApiHelper.Delete(ProductConfiguration.ApiBaseUrl, "Product/DeleteProduct/" + productId.ToString());
                return response.StatusCode;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}