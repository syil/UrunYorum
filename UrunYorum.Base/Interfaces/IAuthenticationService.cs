using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base.Interfaces
{
    public interface IAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}
