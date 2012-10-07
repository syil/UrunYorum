using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base.Interfaces
{
    public interface IMembershipService
    {
        bool Validate(string userName, string password);
        Guid Register(string userName, string password, string email);
    }
}
