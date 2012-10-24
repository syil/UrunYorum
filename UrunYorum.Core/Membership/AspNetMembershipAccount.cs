using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Base;
using System.Web.Security;

namespace UrunYorum.Core.Membership
{
    public class AspNetMembershipAccount : AccountInfoBase
    {
        public static explicit operator AspNetMembershipAccount(MembershipUser mu)
        {
            return new AspNetMembershipAccount
            {
                UserName = mu.UserName,
                Email = mu.Email,
                RealName = mu.UserName,
                Key = mu.UserName
            };
        }
    }
}
