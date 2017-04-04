//-----------------------------------------------------------------------
// <copyright file="ABCAPIHelper.cs" company="AnsiBytecode">
// Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace ESSample.Web
{
    #region using
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    #endregion
    /// <summary>
    /// Request Type
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// The get
        /// </summary>
        Get,

        /// <summary>
        /// The post
        /// </summary>
        Post,

        /// <summary>
        /// The put
        /// </summary>
        Put,

        /// <summary>
        /// The delete
        /// </summary>
        Delete
    }

    /// <summary>
    /// CallAPI static class
    /// </summary>
    public static class ABCApiHelper
    {
        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Http Response Message</returns>
        public static HttpResponseMessage Get(string baseUrl, string url)
        {
            return Invoke(RequestType.Get, null, baseUrl, url);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Http Response Message</returns>
        public static async Task<HttpResponseMessage> GetAsync(string baseUrl, string url)
        {
            return await InvokeAsync(RequestType.Get, null, baseUrl, url);
        }

        /// <summary>
        /// Posts the asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>Http Response Message</returns>
        public static HttpResponseMessage Post(string baseUrl, string url, HttpContent content)
        {
            return Invoke(RequestType.Post, content, baseUrl, url);
        }

        /// <summary>
        /// Posts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>Http Response Message</returns>
        public static async Task<HttpResponseMessage> PostAsync(string baseUrl, string url, HttpContent content)
        {
            return await InvokeAsync(RequestType.Post, content, baseUrl, url);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>Http Response Message</returns>
        public static HttpResponseMessage Put(string baseUrl, string url, HttpContent content)
        {
            return Invoke(RequestType.Put, content, baseUrl, url);
        }

        /// <summary>
        /// Puts the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>Http Response Message</returns>
        public static async Task<HttpResponseMessage> PutAsync(string baseUrl, string url, HttpContent content)
        {
            return await InvokeAsync(RequestType.Put, content, baseUrl, url);
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Http Response Message</returns>
        public static HttpResponseMessage Delete(string baseUrl, string url)
        {
            return Invoke(RequestType.Delete, null, baseUrl, url);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Http Response Message</returns>
        public static async Task<HttpResponseMessage> DeleteAsync(string baseUrl,string url)
        {
            return await InvokeAsync(RequestType.Delete, null, baseUrl, url);
        }

        /// <summary>
        /// Deletes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="content">The content.</param>
        /// <returns>Http Response Message</returns>
        public static async Task<HttpResponseMessage> Delete(string baseUrl, string url, HttpContent content)
        {
            return await InvokeAsync(RequestType.Delete, content, baseUrl, url);
        }

        /// <summary>
        /// Checks the API status.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns>Action Result</returns>
        public static ActionResult CheckAPIStatus(HttpStatusCode statusCode)
        {
            RedirectResult route;
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                    route = new RedirectResult("~/Account/LogOff");
                    return route;
                default:
                    route = new RedirectResult("~/Error/DBError");
                    return route;
            }
        }

        /// <summary>
        /// Invokes the specified request type.
        /// </summary>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="content">The content.</param>
        /// <param name="url">The URL.</param>
        /// <returns>Http Response Message</returns>
        private static HttpResponseMessage Invoke(RequestType requestType, HttpContent content, string baseUrl, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                switch (requestType)
                {
                    case RequestType.Get:
                        httpResponseMessage = client.GetAsync(url).Result;
                        break;
                    case RequestType.Post:
                        httpResponseMessage = client.PostAsync(url, content).Result;
                        break;
                    case RequestType.Put:
                        httpResponseMessage = client.PutAsync(url, content).Result;
                        break;
                    case RequestType.Delete:
                        httpResponseMessage = client.DeleteAsync(url).Result;
                        break;
                    default:
                        break;
                }

                return httpResponseMessage;
            }
        }

        /// <summary>
        /// Invokes the specified request type.
        /// </summary>
        /// <param name="requestType">Type of the request.</param>
        /// <param name="content">The content.</param>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// Http Response Message
        /// </returns>
        private static async Task<HttpResponseMessage> InvokeAsync(RequestType requestType, HttpContent content, string baseUrl, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                switch (requestType)
                {
                    case RequestType.Get:
                        httpResponseMessage = await client.GetAsync(url);
                        break;
                    case RequestType.Post:
                        httpResponseMessage = await client.PostAsync(url, content);
                        break;
                    case RequestType.Put:
                        httpResponseMessage = await client.PutAsync(url, content);
                        break;
                    case RequestType.Delete:
                        httpResponseMessage = await client.DeleteAsync(url);
                        break;
                    default:
                        break;
                }

                return httpResponseMessage;
            }
        }
    }
}