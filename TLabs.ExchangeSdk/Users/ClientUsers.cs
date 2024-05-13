using Flurl.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Users
{
    public class ClientUsers
    {
        public ClientUsers()
        {
        }

        public async Task<int> GetUsersCount()
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

        /// <summary>Only works with paginated requests</summary>
        /// <param name="page">Starts from 1</param>
        public async Task<PagedList<ApplicationUser>> GetUsers(DateTimeOffset? minRegisterDate = null,
            int page = 1, int pageSize = 100, string search = null,
            string merchantId = null, bool? otonFlag = null, bool? emailConfirmed = false,
            BwpUserType? bwpUserType = null)
        {
            var users = await "userprofiles/users".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .SetQueryParam(nameof(minRegisterDate), minRegisterDate?.ToString("o"))
                .SetQueryParam(nameof(page), page.ToString())
                .SetQueryParam(nameof(pageSize), pageSize.ToString())
                .SetQueryParam(nameof(search), search)
                .SetQueryParam(nameof(merchantId), merchantId)
                .SetQueryParam(nameof(otonFlag), otonFlag.ToString())
                .SetQueryParam(nameof(emailConfirmed), emailConfirmed.ToString())
                .SetQueryParam(nameof(bwpUserType), bwpUserType == null ? "" : ((int)bwpUserType).ToString())
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

        public async Task SetUserEmailConfirmed(string userId, bool isConfirmed)
        {
            await $"userprofiles/users/{userId}/email-confirm".InternalApi()
                .SetQueryParam(nameof(isConfirmed), isConfirmed)
                .PostJsonAsync(null);
        }

        public async Task SetBwpUserConfirmed(string userId, bool isConfirmed)
        {
            await $"userprofiles/users/{userId}/bwp-confirm".InternalApi()
                .SetQueryParam(nameof(isConfirmed), isConfirmed)
                .PostJsonAsync(null);
        }

        public async Task SetNickname(string userId, string nickname)
        {
            await $"userprofiles/users/{userId}/nickname".InternalApi().PostJsonAsync(nickname);
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

        public async Task<IEnumerable<CustomClaim>> GetClaims(string userId, string claimType = null)
        {
            string url = $"userprofiles/identityusers/{userId}/claims";
            if (!string.IsNullOrWhiteSpace(claimType))
                url += $"/{claimType}";

            var result = await url.InternalApi()
                .GetJsonAsync<IEnumerable<CustomClaim>>();
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

        public async Task<List<string>> SetRoles(List<UserRolesModel> model, string userId)
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

        public async Task<bool> GetUserClaimValue(string claimValue, string userId)
        {
            var result = await $"userprofiles/users/claims/{claimValue}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .GetJsonAsync<bool>();
            return result;
        }

        public async Task<IFlurlResponse> SetUserClaim(string claimValue, string userId, bool isActive)
        {
            var result = await $"userprofiles/users/claims/{claimValue}".InternalApi()
                .SetQueryParam(nameof(userId), userId)
                .SetQueryParam(nameof(isActive), isActive)
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
    }
}
