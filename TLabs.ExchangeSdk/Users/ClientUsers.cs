using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Farming;

namespace TLabs.ExchangeSdk.Users
{
    public class ClientUsers
    {
        public ClientUsers()
        {
        }

        public virtual async Task<int> GetUsersCount()
        {
            return await $"userprofiles/users/count".InternalApi().GetJsonAsync<int>();
        }

        public async Task<ApplicationUser> GetUser(string userId)
        {
            if (userId.NotHasValue())
                return null;
            return await $"userprofiles/identityusers/{userId}".InternalApi()
                .GetJsonAsync<ApplicationUser>();
        }

        public async Task<AccountDeletionStateDto> GetAccountDeletionState(string userId)
        {
            if (userId.NotHasValue())
                return null;

            return await $"userprofiles/users/{userId}/deletion-state".InternalApi()
                .GetJsonAsync<AccountDeletionStateDto>();
        }

        public async Task DeleteAccount(string userId)
        {
            await $"userprofiles/users/{userId}/delete-account".InternalApi()
                .PostJsonAsync(null);
        }

        /// <summary>Only works with paginated requests</summary>
        /// <param name="page">Starts from 1</param>
        public async Task<PagedList<ApplicationUser>> GetUsers(DateTimeOffset? minRegisterDate = null,
            int page = 1, int pageSize = 100, string search = null,
            bool? emailConfirmed = false)
        {
            var users = await "userprofiles/users".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam(nameof(minRegisterDate), minRegisterDate?.ToString("o"))
                .SetQueryParam(nameof(page), page.ToString())
                .SetQueryParam(nameof(pageSize), pageSize.ToString())
                .SetQueryParam(nameof(search), search)
                .SetQueryParam(nameof(emailConfirmed), emailConfirmed.ToString())
                .GetJsonAsync<PagedList<ApplicationUser>>();
            return users;
        }

        public async Task<List<ApplicationUser>> GetUsersByIds(List<string> userIds = null,
            DateTimeOffset? minRegisterDate = null)
        {
            var url = "userprofiles/users/by-ids".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(5))
                .SetQueryParam(nameof(minRegisterDate), minRegisterDate?.ToString("o"));
            var appUsers = await url.PostJsonAsync<List<ApplicationUser>>(userIds);
            return appUsers;
        }

        public async Task<List<ApplicationUser>> GetUsersByEmail(string email)
        {
            if (email.NotHasValue())
                return null;
            var result = await $"userprofiles/identityusers/byemail/{email}".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .GetJsonAsync<List<ApplicationUser>>();
            return result;
        }

        public async Task<List<ApplicationUser>> GetUsersByRestriction(string restrictionName)
        {
            var result = await $"userprofiles/users/get-users-by-restriction/{restrictionName}".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .GetJsonAsync<List<ApplicationUser>>();
            return result;
        }

        public async Task<bool> GetRestrictionValue(string userId, string restrictionName)
        {
            string url = $"userprofiles/users/get-restriction/{userId}/{restrictionName}";
            var result = await url.InternalApi().GetJsonAsync<bool>();
            return result;
        }

        public async Task<List<ApplicationUser>> GetUsersByRole(string roleName)
        {
            var result = await $"userprofiles/users/byrole/{roleName}".InternalApi()
                .GetJsonAsync<List<ApplicationUser>>();
            return result;
        }

        public async Task<List<ApplicationUser>> GetAdmins()
        {
            const string adminRoleName = "Administrator";
            var result = await GetUsersByRole(adminRoleName);
            return result;
        }

        public async Task<List<string>> GetUserIdsByMerchantId(string merchantId)
        {
            var result = await $"userprofiles/users/ids-by-merchant".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam(nameof(merchantId), merchantId)
                .GetJsonAsync<List<string>>();
            return result;
        }

        public async Task<ApplicationUser> GetMerchantBySubUserId(string subUserId, string defaultMerchantId = null)
        {
            var result = await $"userprofiles/users/merchant".InternalApi()
                .SetQueryParam(nameof(subUserId), subUserId)
                .GetJsonAsync<ApplicationUser>();
            if (result == null && defaultMerchantId.HasValue())
                result = await GetUser(defaultMerchantId);
            return result;
        }

        public async Task SaveEmailRequestRecord(string userId, string email)
        {
            await $"userprofiles/users/{userId}/email-request-records".InternalApi()
                .SetQueryParam(nameof(email), email)
                .PostJsonAsync(null);
        }

        public async Task SetUserEmailConfirmed(string userId, bool isConfirmed)
        {
            await $"userprofiles/users/{userId}/email-confirm".InternalApi()
                .SetQueryParam(nameof(isConfirmed), isConfirmed)
                .PostJsonAsync(null);
        }

        public async Task SetNickname(string userId, string nickname)
        {
            await $"userprofiles/users/{userId}/nickname".InternalApi().PostJsonAsync(nickname);
        }

        public async Task<QueryResult> UpdateNames(string userId, NamesDto dto)
        {
            return await $"userprofiles/users/{userId}/names"
                .InternalApi()
                .PutJsonAsync(dto)
                .GetQueryResult();
        }

        public async Task<QueryResult> SetAdminComment(string userId, AdminCommentDto dto)
        {
            return await $"userprofiles/users/{userId}/admin-comment"
                .InternalApi()
                .PostJsonAsync(dto)
                .GetQueryResult();
        }

        public async Task SetAvatarId(string userId, string avatarId)
        {
            await $"userprofiles/users/{userId}/avatar-id".InternalApi().PostJsonAsync(avatarId);
        }

        public async Task<VipStatusDto> GetVipStatus(string userId)
        {
            if (userId.NotHasValue())
                return null;
            return await $"userprofiles/users/{userId}/vip/statuses".InternalApi()
                .GetJsonAsync<VipStatusDto>();
        }

        public async Task<QueryResult> SetVipStatus(string userId, SetVipStatusDto dto)
        {
            return await $"userprofiles/users/{userId}/vip/statuses".InternalApi()
                .PostJsonAsync(dto)
                .GetQueryResult();
        }

        public async Task<VipAssistantDto> GetVipAssistant(string userId)
        {
            if (userId.NotHasValue())
                return null;
            try
            {
                return await $"userprofiles/users/{userId}/vip/assistants".InternalApi()
                    .GetJsonAsync<VipAssistantDto>();
            }
            catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage?.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<bool> IsGoogleAuthenticatorActive(string userId)
        {
            return await $"userprofiles/users/login-ga-required/{userId}".InternalApi()
                .GetJsonAsync<bool>();
        }

        public async Task<bool> CheckGoogleAuthenticatorCode(string userId, string authCode)
        {
            if (!await IsGoogleAuthenticatorActive(userId))
                return true;
            if (!authCode.HasValue())
                return false;
            bool result = await $"identity/manage/google-auth-key/check?userId={userId}&authCode={authCode}"
                .InternalApi()
                .GetJsonAsync<bool>();
            return result;
        }

        public async Task<string> Healthcheck() => await $"userprofiles/healthcheck".InternalApi().GetStringAsync();

        public async Task<List<CustomClaim>> GetClaims(string userId, string claimType = null)
        {
            string url = $"userprofiles/identityusers/{userId}/claims";
            if (!string.IsNullOrWhiteSpace(claimType))
                url += $"/{claimType}";

            var result = await url.InternalApi()
                .GetJsonAsync<List<CustomClaim>>();
            return result;
        }

        public async Task<List<CustomClaim>> GetClaimsByTypes(List<string> claimTypes)
        {
            var result = await $"userprofiles/claims/by-types".InternalApi()
                .SetQueryParam(nameof(claimTypes), claimTypes)
                .GetJsonAsync<List<CustomClaim>>();
            return result;
        }

        public async Task<string> GetClaimValue(string userId, string claimType)
        {
            var claims = await GetClaims(userId, claimType);
            return claims.FirstOrDefault()?.Value;
        }

        public async Task CreateOrUpdateClaims(string userId, IEnumerable<CustomClaim> claims)
        {
            await $"userprofiles/identityusers/{userId}/claims".InternalApi()
                .PostJsonAsync(claims);
        }

        public async Task CreateOrUpdateClaim(string userId, CustomClaim claim)
        {
            await CreateOrUpdateClaims(userId, new List<CustomClaim> { claim });
        }

        public async Task DeleteClaims(string userId, IEnumerable<CustomClaim> claims)
        {
            await $"userprofiles/identityusers/{userId}/claims".InternalApi()
                .DeleteJsonAsync(claims);
        }

        public async Task DeleteClaim(string userId, CustomClaim claim)
        {
            await DeleteClaims(userId, new List<CustomClaim> { claim });
        }

        public async Task<List<IdentityRole>> GetAllRoles()
        {
            var result = await "userprofiles/identityroles/roles/".InternalApi()
                .GetJsonAsync<List<IdentityRole>>();
            return result;
        }

        public async Task<List<string>> GetAllRolesByUser(string userId)
        {
            var result = await $"userprofiles/identityusers/{userId}/roles".InternalApi()
                .GetJsonAsync<List<string>>();
            return result;
        }

        public async Task<List<string>> SetUserRoles(List<UserRolesModel> model, string userId)
        {
            List<string> roles = new List<string>();
            foreach (var item in model)
            {
                if (item.Allowed)
                    roles.Add(item.Name);
            }

            var result = await $"userprofiles/identityusers/{userId}/roles/addroles".InternalApi()
                .PostJsonAsync<List<string>>(roles);
            return result;
        }

        public async Task<IFlurlResponse> AddUserRole(string userId, string roleName)
        {
            var result = await $"userprofiles/identityusers/{userId}/roles/AddRole/{roleName}"
                .InternalApi().PostJsonAsync(null);
            return result;
        }

        public async Task<IFlurlResponse> DeleteUserRole(string userId, string roleName)
        {
            var result = await $"userprofiles/identityusers/{userId}/roles"
                .InternalApi().PostStringAsync(roleName);
            return result;
        }

        public async Task<bool> GetBoolClaimValue(string claimValue, string userId)
        {
            var result = await $"userprofiles/users/claims/{claimValue}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<bool>();
            return result;
        }

        public async Task<IFlurlResponse> SetBoolClaim(string claimValue, string userId, bool isActive)
        {
            var result = await $"userprofiles/users/claims/{claimValue}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(isActive), isActive)
                .PostJsonAsync(null);
            return result;
        }

        public async Task<string> GetStringClaimValue(string userId, string claimType)
        {
            var result = await $"userprofiles/users/claims/string/{claimType}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetStringAsync();
            return result;
        }

        public async Task<IFlurlResponse> SetStringClaim(string userId, string claimType, string newValue)
        {
            var result = await $"userprofiles/users/claims/string/{claimType}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(newValue), newValue)
                .PostJsonAsync(null);
            return result;
        }

        public async Task<UserSettingsModel> GetUserSettings(string userId)
        {
            var result = await $"userprofiles/users/settings/{userId}".InternalApi()
                .GetJsonAsync<UserSettingsModel>();
            return result;
        }

        public async Task<IFlurlResponse> SetUserSettings(UserSettingsModel model)
        {
            var result = await $"userprofiles/users/settings".InternalApi()
                .PostJsonAsync(model);
            return result;
        }

        public async Task<UserFinancesSetting> GetCommissionConversionSettings(string userId)
        {
            var result = await $"userprofiles/users/finances-settings/{userId}".InternalApi()
                .GetJsonAsync<UserFinancesSetting>();
            return result;
        }

        public async Task<IFlurlResponse> SetTradeCommissionConversionSetting(string userId, bool isActive)
        {
            var currentSettings = await GetCommissionConversionSettings(userId);

            var result = await $"userprofiles/users/finances-settings".InternalApi()
                .PostJsonAsync(currentSettings);
            return result;
        }

        public async Task<string> GenerateGoogleAuthKey(string userId)
        {
            var result = await $"userprofiles/users/{userId}/2fa/generate-key".InternalApi()
                .PostJsonAsync<string>(null);
            return result;
        }

        public async Task<bool> GetGoogleAuthStatus(string userId)
        {
            var result = await $"userprofiles/users/{userId}/2fa/status".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<bool>();
            return result;
        }

        public async Task<IFlurlResponse> UpdateGoogleAuthStatus(string userId, string totpCode, bool setActive)
        {
            var result = await $"userprofiles/users/{userId}/2fa/status?setActive={setActive}"
                .InternalApi()
                .PostJsonAsync(totpCode);
            return result;
        }

        public async Task<bool> VerifyGoogleAuthCode(string userId, string totpCode)
        {
            var result = await $"userprofiles/users/{userId}/2fa/verify".InternalApi()
                .PostJsonAsync<bool>(totpCode);
            return result;
        }

        public async Task<string> GetParameterValue(string key)
        {
            var result = await $"userprofiles/parameters".InternalApi()
                .SetQueryParam(nameof(key), key)
                .GetStringAsync();
            return result;
        }

        public async Task<IFlurlResponse> CreateOrUpdateParameter<T>(string key, T value)
        {
            var result = await $"userprofiles/parameters".InternalApi()
                .SetQueryParam(nameof(key), key)
                .PostJsonAsync(value.ToString());
            return result;
        }

        /// <summary>Device verification: checks trusted devices stored in UserProfiles.</summary>
        public async Task<bool> IsDeviceTrusted(string userId, string deviceId)
        {
            return await $"userprofiles/users/device-verification/is-trusted"
                .InternalApi()
                .SetQueryParam("userId", userId)
                .SetQueryParam("deviceId", deviceId)
                .GetJsonAsync<bool>();
        }

        /// <summary>
        /// Device verification: generates and stores pending code (UserProfiles).
        /// Used for both initial send and resend scenarios.
        /// </summary>
        public async Task SendDeviceVerificationCode(string userId, string email, bool isResend = false)
        {
            await $"userprofiles/users/device-verification/send-code"
                .InternalApi()
                .PostJsonAsync(new { userId, email, isResend });
        }

        /// <summary>Removes all trusted devices for user in UserProfiles.</summary>
        public async Task InvalidateTrustedDevices(string userId)
        {
            await $"userprofiles/users/device-verification/invalidate-trusted-devices"
                .InternalApi()
                .PostJsonAsync(new { userId });
        }

        /// <summary>Proxied from Identity <c>api/account/verify-device</c>.</summary>
        public async Task VerifyDevice(string email, string code, string deviceId, string userAgent)
        {
            await $"userprofiles/users/device-verification/verify"
                .InternalApi()
                .PostJsonAsync(new { email, code, deviceId, userAgent });
        }

        public virtual async Task<Dictionary<string, DateTimeOffset>> GetUserRegistrationDates()
        {
            var response = await "userprofiles/users/registrations"
                .InternalApi().GetJsonAsync<Dictionary<string, DateTimeOffset>>().GetQueryResult();

            return response.Succeeded ? response.Data : new Dictionary<string, DateTimeOffset>();
        }

        public virtual async Task<QueryResult> UpdateReferralCode(string userId, string referralCode)
        {
            var result = await $"userprofiles/users/{userId}/referral-code".InternalApi()
                .PutJsonAsync(referralCode)
                .GetQueryResult();

            return result;
        }

        /// <summary>Binds a Telegram numeric user id (from HMAC-validated initData) to a binibit userId.</summary>
        public async Task<QueryResult> SetTelegramId(string userId, long telegramId)
        {
            return await $"userprofiles/users/{userId}/telegram-id".InternalApi()
                .PutJsonAsync(telegramId)
                .GetQueryResult();
        }

        /// <summary>Looks up an already-bound userId by Telegram numeric user id, null if not bound yet.</summary>
        public async Task<string> GetUserIdByTelegramId(long telegramId)
        {
            try
            {
                return await $"userprofiles/users/by-telegram-id/{telegramId}".InternalApi()
                    .GetJsonAsync<string>();
            }
            catch (FlurlHttpException ex) when (ex.Call.HttpResponseMessage?.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a short-lived one-time token that proves ownership of <paramref name="userId"/>,
        /// to be handed to Telegram (via a deeplink) so the Mini App can later bind its telegramId to this user.
        /// </summary>
        public async Task<TelegramLinkTokenDto> CreateTelegramLinkToken(string userId)
        {
            return await $"userprofiles/users/{userId}/telegram-link-token".InternalApi()
                .PostJsonAsync(null)
                .ReceiveJson<TelegramLinkTokenDto>();
        }

        /// <summary>Consumes a link token created above and binds telegramId to the user that created it.</summary>
        public async Task<QueryResult> ConsumeTelegramLinkToken(string token, long telegramId)
        {
            return await $"userprofiles/users/telegram-link-token/{token}/consume".InternalApi()
                .PostJsonAsync(new { telegramId })
                .GetQueryResult();
        }

    }
}
