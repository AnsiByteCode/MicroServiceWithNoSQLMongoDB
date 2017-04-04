namespace ESSample.Web.Helper
{
    #region Using
    using ES.Domain.QueryModels;
    using Newtonsoft.Json;
    using System;
    using System.Web;
    #endregion

    /// <summary>
    /// Common Helper
    /// </summary>
    public class CommonHelper
    {
        #region Common get methods

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns></returns>
        public static Guid GetCurrentUserId()
        {
            try
            {
                var userData = JsonConvert.DeserializeObject<GetLoginDetailsViewModel>(((System.Web.Security.FormsIdentity)((System.Security.Principal.GenericPrincipal)HttpContext.Current.User).Identity).Ticket.UserData);
                if (userData != null)
                {
                    return userData.Id;
                }
                NavigateToLogin(string.Empty);
            }
            catch
            {
                NavigateToLogin(string.Empty);
            }
            return Guid.Empty;
        }
        #endregion

        #region Navigate to Login
        /// <summary>
        /// Navigates to login.
        /// </summary>
        /// <param name="mode">The mode.</param>
        public static void NavigateToLogin(string mode)
        {
            HttpContext.Current.Response.Redirect("~/Account/Logout?md=" + mode);
        }
        #endregion
    }
}