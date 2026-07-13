using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Users
{
    /// <summary>
    /// Binds/looks up the mapping between a Telegram numeric user id and a binibit userId
    /// (used to connect the Telegram Mini App to binibit.com - see TelegramGrantValidator in
    /// stock-n10-identity and ApiTelegramLinkController in stock-n10-webapp).
    /// </summary>
    public class ClientTelegram
    {
        public ClientTelegram()
        {
        }

        /// <summary>Binds a Telegram numeric user id (from HMAC-validated initData) to a binibit userId.</summary>
        public virtual async Task<QueryResult> SetTelegramId(string userId, long telegramId)
        {
            return await $"userprofiles/users/{userId}/telegram-id".InternalApi()
                .PutJsonAsync(telegramId)
                .GetQueryResult();
        }

        /// <summary>Looks up an already-bound userId by Telegram numeric user id, null if not bound yet.</summary>
        public virtual async Task<string> GetUserIdByTelegramId(long telegramId)
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
        public virtual async Task<TelegramLinkTokenDto> CreateTelegramLinkToken(string userId)
        {
            return await $"userprofiles/users/{userId}/telegram-link-token".InternalApi()
                .PostJsonAsync(null)
                .ReceiveJson<TelegramLinkTokenDto>();
        }

        /// <summary>Consumes a link token created above and binds telegramId to the user that created it.</summary>
        public virtual async Task<QueryResult> ConsumeTelegramLinkToken(string token, long telegramId)
        {
            return await $"userprofiles/users/telegram-link-token/{token}/consume".InternalApi()
                .PostJsonAsync(new { telegramId })
                .GetQueryResult();
        }
    }
}
