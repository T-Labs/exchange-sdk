using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            return await $"userprofiles/identityusers/{userId}".InternalApi()
                .GetJsonAsync<ApplicationUser>();
        }

        public async Task<List<ApplicationUser>> GetUsers(DateTimeOffset? minRegisterDate = null,
            int page = -1, int pageSize = 0, string search = null,
            string merchantId = null, bool? otonFlag = null)
        {
            var users = await "userprofiles/users".InternalApi()
                .SetQueryParam(nameof(minRegisterDate), minRegisterDate?.ToString("o"))
                .SetQueryParam(nameof(page), page.ToString())
                .SetQueryParam(nameof(pageSize), pageSize.ToString())
                .SetQueryParam(nameof(search), search)
                .SetQueryParam(nameof(merchantId), merchantId)
                .SetQueryParam(nameof(otonFlag), otonFlag.ToString())
                .GetJsonAsync<List<ApplicationUser>>();
            return users;
        }

        public async Task<List<ApplicationUser>> GetUsersByEmail(string email)
        {
            var result = await $"userprofiles/identityusers/byemail/{email}"
                .GetJsonAsync<List<ApplicationUser>>();
            return result;
        }

        public async Task<List<ApplicationUser>> GetUsersByRestriction(string restrictionName)
        {
            var result = await $"userprofiles/users/get-users-by-restriction/{restrictionName}".InternalApi()
                .GetJsonAsync<List<ApplicationUser>>();
            return result;
        }

        public async Task<List<string>> GetUserIdsByMerchantId(string merchantId)
        {
            var result = await $"userprofiles/users/ids-by-merchant".InternalApi()
                .SetQueryParam(nameof(merchantId), merchantId)
                .GetJsonAsync<List<string>>();
            return result;
        }

        public async Task<ApplicationUser> GetMerchantBySubUserId(string subUserId)
        {
            var result = await $"userprofiles/users/merchant".InternalApi()
                .SetQueryParam(nameof(subUserId), subUserId)
                .GetJsonAsync<ApplicationUser>();
            return result;
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
            bool result = await $"identity/manage/google-auth-key/check?userId={userId}&authCode={authCode}".InternalApi()
                .GetJsonAsync<bool>();
            return result;
        }
    }
}
