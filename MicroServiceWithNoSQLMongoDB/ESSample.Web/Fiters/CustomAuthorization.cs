using ESSample.Web.Models;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ESSample.Web.Fiters
{
    /// <summary>
    /// Custom Authorize Attribute
    /// </summary>
    /// <seealso cref="System.Web.Mvc.AuthorizeAttribute" />
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Gets or sets the users configuration key.
        /// </summary>
        /// <value>
        /// The users configuration key.
        /// </value>
        public string UsersConfigKey { get; set; }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        ///// <summary>
        ///// Called when [authorization].
        ///// </summary>
        ///// <param name="filterContext">The filter context.</param>
        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    if (filterContext.HttpContext.Request.IsAuthenticated)
        //    {
        //        var authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
                
        //        Users = string.IsNullOrEmpty(Users) ? authorizedUsers : Users;
                
        //        if (!string.IsNullOrEmpty(Users))
        //        {
        //            if (!Users.Contains(CurrentUser.Id.ToString()))
        //            {
        //                filterContext.Result = new RedirectToRouteResult(new
        //                RouteValueDictionary(new { controller = "Account", action = "Login" }));

        //                // base.OnAuthorization(filterContext); //returns to login url
        //            }
        //        }
        //    }

        //}

        /// <summary>
        /// When overridden, provides an entry point for custom authorization checks.
        /// </summary>
        /// <param name="httpContext">The HTTP context, which encapsulates all HTTP-specific information about an individual HTTP request.</param>
        /// <returns>
        /// true if the user is authorized; otherwise, false.
        /// </returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext) {
            if (httpContext.Request.IsAuthenticated) {
                if (CurrentUser != null) {
                    return true;
                }
            }
            return false;
        }
    }
}