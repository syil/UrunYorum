﻿using System;
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

        public string Register(string userName, string password, string email)
        {
            MembershipCreateStatus status;

            provider.CreateUser(userName, password, email, null, null, true, Guid.NewGuid(), out status);
            
            if (status == MembershipCreateStatus.Success)
            {
                return userName;
            }
            else
            {
                throw new UserRegisterFailedException(ErrorCodeToString(status));
            }
        }

        public AccountInfoBase GetUserInfo(string key)
        {
            MembershipUser membershipUser = provider.GetUser(key, false);
            return (AspNetMembershipAccount)membershipUser;
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            string statusString = createStatus.ToString();
            string resourceKey = "Exceptions.ErrorMessages.UserRegister.{0}".FormatWith(statusString);

            return ResourceManager.GetString(resourceKey);
        }
    }
}
