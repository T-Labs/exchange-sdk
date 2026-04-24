using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Users
{
    public class ClientFavoritePairs
    {
        public ClientFavoritePairs()
        {
        }

        public virtual async Task<List<string>> GetFavoritePairs(string userId)
        {
            if (userId.NotHasValue())
                return new List<string>();
            return await $"userprofiles/users/{userId}/favorite-pairs".InternalApi()
                .GetJsonAsync<List<string>>();
        }

        public virtual async Task AddFavoritePair(string userId, string currencyPairCode)
        {
            await $"userprofiles/users/{userId}/favorite-pairs/{currencyPairCode}".InternalApi()
                .PostJsonAsync(null);
        }

        public virtual async Task RemoveFavoritePair(string userId, string currencyPairCode)
        {
            await $"userprofiles/users/{userId}/favorite-pairs/{currencyPairCode}".InternalApi()
                .DeleteAsync();
        }
    }
}
