using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Users
{
    public class ApplicationUser : IdentityUser
    {
        public DateTimeOffset RegistrationDate { get; set; }

        /// <summary>Google Authenticator key</summary>
        public string PreSharedGoogleAuthKey { get; set; }

        /// <summary>Temporary google authenticator key used in the process of generating</summary>
        public string TemporaryGeneratedGoogleAuthKey { get; set; }

        /// <summary>Bitmask of enabled two factor authentication methods for the user</summary>
        public TwoFactorMethods TwoFactorMethods { get; set; }

        /// <summary>User language</summary>
        public string Culture { get; set; }

        /// <summary>User Nickname, will be used in chat</summary>
        public string Nickname { get; set; }

        /// <summary>Referral code from n10</summary>
        public string ReferralCode { get; set; }

        /// <summary>Id of user in Oton affiliate program</summary>
        public string OtonUserId { get; set; }

        /// <summary>Id of main user (used in S7 exchange)</summary>
        public string MerchantId { get; set; }

        /// <summary>If true then other users can specify this user's id in MerchantId</summary>
        public bool IsMerchant { get; set; }
    }

    [Flags]
    public enum TwoFactorMethods
    {
        None = 0,
        Email = 1,
        Sms = 2,
        GoogleAuthenticator = 4
    }
}
