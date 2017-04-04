using ESSample.Common.CustomerService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YourFeedback.Web.Helper;

namespace ESSample.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// Logins the specified login view model.
        /// </summary>
        /// <param name="loginRequest">The login request.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                var user = CustomerHelper.Login(loginRequest);
                if (user != null)
                {
                    //set login part
                    string userData = JsonConvert.SerializeObject(user);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(15), false, //pass here true, if you want to implement remember me functionality
                    userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Email or password you entrered is incorrect");
            }
            return View(loginRequest);
        }

        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        /// <summary>
        /// Errors this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }
    }
}