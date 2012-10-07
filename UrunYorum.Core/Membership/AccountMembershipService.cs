using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Base.Interfaces;
using System.Web.Security;
using UrunYorum.Base.Exceptions;
using UrunYorum.Base;
using UrunYorum.Base.Utilities;

namespace UrunYorum.Core.Membership
{
    public class AccountMembershipService : IMembershipService
    {
        private readonly MembershipProvider provider;

        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            this.provider = provider ?? System.Web.Security.Membership.Provider;
        }

        public bool Validate(string userName, string password)
        {
            return provider.ValidateUser(userName, password);
        }

        public Guid Register(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            Guid providerUserKey = Guid.NewGuid();

            provider.CreateUser(userName, password, email, null, null, true, providerUserKey, out status);

            if (status == MembershipCreateStatus.Success)
            {
                return providerUserKey;
            }
            else
            {
                throw new UserRegisterFailedException(ErrorCodeToString(status));
            }
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            string statusString = createStatus.ToString();
            string resourceKey = "Exceptions.ErrorMessages.UserRegister.{0}".FormatWith(statusString);

            return ResourceManager.GetString(resourceKey);
        }
    }
}
