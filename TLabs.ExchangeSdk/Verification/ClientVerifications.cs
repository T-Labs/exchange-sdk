using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.Users;

namespace TLabs.ExchangeSdk.Verification
{
    public class ClientVerifications
    {
        public ClientVerifications()
        {
        }

        public async Task<VerificationUser> GetVerification(string userId)
        {
            var result = await $"verification/verifications/{userId}".InternalApi()
                .GetJsonAsync<VerificationUser>().GetQueryResult();
            return result.Succeeded ? result.Data : null;
        }

        /// <summary>Get verifications by userIds or all</summary>
        /// <param name="userIds">set null if you want to get all verifications</param>
        public async Task<List<VerificationUser>> GetVerifications(List<string> userIds = null)
        {
            if (userIds != null && userIds.Count == 0)
                return new();
            string url = $"verification/verifications?verificationIds={string.Join(",", userIds ?? new())}";
            var result = await url.InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .GetJsonAsync<List<VerificationUser>>();
            return result;
        }

        public async Task<List<(ApplicationUser, VerificationUser)>> LoadVerificationsForUsers(List<ApplicationUser> users)
        {
            if (users == null || users.Count == 0)
                return new();
            var verirications = (await GetVerifications(users.Select(_ => _.Id).ToList())).ToDictionary(_ => _.Id, _ => _);
            var result = users.Select(_ => (_, verirications.GetValueOrDefault(_.Id, null))).ToList();
            return result;
        }

        public async Task<bool> IsVerified(string userId)
        {
            var result = await $"verification/verifications/{userId}/verified".InternalApi()
                .GetJsonAsync<bool>();
            return result;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await $"verification/countries".InternalApi()
                .GetJsonAsync<List<Country>>();
        }

        public async Task<List<Citizenship>> GetCitizenships()
        {
            return await $"verification/citizenships".InternalApi()
                .GetJsonAsync<List<Citizenship>>();
        }

        public async Task<List<string>> GetCitizenshipUserIds(int citizenshipId)
        {
            return await $"verification/citizenships/{citizenshipId}/user-ids".InternalApi()
                .WithTimeout(TimeSpan.FromMinutes(10))
                .GetJsonAsync<List<string>>();
        }
    }
}
