using Flurl.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

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
                .GetJsonAsync<List<string>>();
        }
    }
}
