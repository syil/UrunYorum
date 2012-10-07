using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Base.Interfaces;
using System.Web.Security;

namespace UrunYorum.Core.Membership
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
