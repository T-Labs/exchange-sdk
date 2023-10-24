using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers.Helpers;

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

        public string PublicId { get; set; }

        public string PrivateId { get; set; }

        /// <summary>Only used in BWP project. User can be a Merchant or a Trader</summary>
        public BwpUserType BwpUserType { get; set; } = BwpUserType.Default;

        /// <summary>Only used in BWP project. Admin should confirm user if he is a Merchant or a Trader</summary>
        public bool IsBwpUserConfirmed { get; set; }

        public bool TwoFactorEmail {
            get => FlagsHelper.IsSet(TwoFactorMethods, TwoFactorMethods.Email);
            set => TwoFactorMethods =
                value
                    ? FlagsHelper.Set(TwoFactorMethods, TwoFactorMethods.Email)
                    : FlagsHelper.Unset(TwoFactorMethods, TwoFactorMethods.Email);
        }

        public bool TwoFactorSms {
            get => FlagsHelper.IsSet(TwoFactorMethods, TwoFactorMethods.Sms);
            set => TwoFactorMethods =
                value
                    ? FlagsHelper.Set(TwoFactorMethods, TwoFactorMethods.Sms)
                    : FlagsHelper.Unset(TwoFactorMethods, TwoFactorMethods.Sms);
        }

        public bool TwoFactorGa {
            get => FlagsHelper.IsSet(TwoFactorMethods, TwoFactorMethods.GoogleAuthenticator);
            set => TwoFactorMethods =
                value
                    ? FlagsHelper.Set(TwoFactorMethods, TwoFactorMethods.GoogleAuthenticator)
                    : FlagsHelper.Unset(TwoFactorMethods, TwoFactorMethods.GoogleAuthenticator);
        }

        public bool IsGARequiredOnLogin => !string.IsNullOrEmpty(PreSharedGoogleAuthKey) && TwoFactorGa;

        public void ClearSensitiveData()
        {
            AccessFailedCount = 0;
            ConcurrencyStamp = "";
            LockoutEnabled = false;
            LockoutEnd = null;
            TwoFactorEnabled = false;
            PasswordHash = "";
            SecurityStamp = "";
            PreSharedGoogleAuthKey = "";
            TemporaryGeneratedGoogleAuthKey = "";
        }
    }

    [Flags]
    public enum TwoFactorMethods
    {
        None = 0,
        Email = 1,
        Sms = 2,
        GoogleAuthenticator = 4
    }

    /// <summary>Only used in BWP project</summary>
    public enum BwpUserType
    {
        Default = 0,
        Merchant = 10,
        Trader = 20,
    }
}
