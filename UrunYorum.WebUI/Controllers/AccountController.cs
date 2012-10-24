using System;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using UrunYorum.Core;
using UrunYorum.WebUI.ViewModels;
using UrunYorum.Data.Entities;

namespace UrunYorum.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.Validate(model.UserName, model.Password))
                {
                    AuthenticationService.SignIn(model.UserName, true);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/main");
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

        public ActionResult AjaxLogIn(LogInModel model)
        {
            return View();
        }

        public RedirectResult LogOff(string returnUrl)
        {
            AuthenticationService.SignOut();

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/main");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            // Attempt to register the user
            try
            {
                string userKey = MembershipService.Register(model.UserName, model.Password, model.Email);

                Login loginEntity = new Login()
                {
                    AuthenticateKey = userKey,
                    AuthenticateDate = DateTime.Now,
                    IsAuthenticated = true,
                    IsDeleted = false,
                };

                AuthenticationService.SignIn(model.UserName, false /* createPersistentCookie */);
            }
            catch (Exception exc)
            {
                bool rethrow = ExceptionPolicy.HandleException(exc, SystemConstants.ExceptionLogPolicyName);
                if (rethrow)
                    throw;
            }

            return Redirect("/main");
        }

        [ChildActionOnly]
        public PartialViewResult _LoginStatus()
        {
            ViewBag.UserName = User.Identity.Name;
            ViewBag.IsAuthenticated = User.Identity.IsAuthenticated;

            return PartialView();
        }
    }
}
