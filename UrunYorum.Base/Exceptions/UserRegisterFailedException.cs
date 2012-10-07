using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base.Exceptions
{
    public class UserRegisterFailedException : NonFatalException
    {
        public UserRegisterFailedException(string message)
            : base(message)
        {

        }
    }
}
