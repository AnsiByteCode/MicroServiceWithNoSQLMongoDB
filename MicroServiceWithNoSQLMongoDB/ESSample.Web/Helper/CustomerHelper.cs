//-----------------------------------------------------------------------
// <copyright file="CommonHelper.cs" company="AnsiBytecode">
// Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace YourFeedback.Web.Helper
{
    #region using
    using System.Collections.Generic;
    using System.Net.Http;
    using ES.Domain.QueryModels;
    using ESSample.Web;
    using ESSample.Common.CustomerService;
    using ABC.Common.Helper;
    using ES.ApplicationService;
    using System;
    using ESSample.Common.CartService;
    #endregion

    /// <summary>
    /// Customer Helper
    /// </summary>
    public static class CustomerHelper
    {
       
        /// <summary>
        /// Logins the specified login request.
        /// </summary>
        /// <param name="loginRequest">The login request.</param>
        /// <returns></returns>
        public static GetLoginDetailsViewModel Login(LoginRequest loginRequest)
        {
            try
            {
                HttpContent content = new ObjectContent<LoginRequest>(loginRequest, JsonFormatterHelper.Instance.JsonMediaTypeFormatterInstance);
                var response = ABCApiHelper.Post(CustomerConfiguration.ApiBaseUrl, "Customer/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<GetLoginDetailsViewModel>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}