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

        public string PreSharedGoogleAuthKey { get; set; }

        public string TemporaryGeneratedGoogleAuthKey { get; set; }

        public TwoFactorMethods TwoFactorMethods { get; set; }

        public string Culture { get; set; }

        public string Nickname { get; set; }

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
