using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using UrunYorum.Base.Interfaces;
using UrunYorum.Core.Membership;
using UrunYorum.WebUI.ViewModels;

namespace UrunYorum.WebUI.Controllers
{
    public class AccountController : Controller
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (AuthenticationService == null) { AuthenticationService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.Validate(model.UserName, model.Password))
                {
                    AuthenticationService.SignIn(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOff()
        {
            AuthenticationService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                Guid userKey = MembershipService.Register(model.UserName, model.Password, model.Email);

                AuthenticationService.SignIn(model.UserName, false /* createPersistentCookie */);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}
