using Flurl.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.News;
using TLabs.ExchangeSdk.News.Dtos;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings
{
    public class ClientCurrencyListings
    {
        private const string baseUrl = "brokerage/currency-listings";
        private const string newsBaseUrl = "news/currency-listings";

        #region Brokerage

        public async Task<List<CurrencyListing>> GetList(string userId = null, CurrencyListingStatus? status = null)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(userId), userId?.Trim().NullIfEmpty())
                .SetQueryParam(nameof(status), status == null ? "" : ((int)status).ToString())
                .GetJsonAsync<List<CurrencyListing>>();
            return result;
        }

        public async Task<CurrencyListing> Get(string currencyCode)
        {
            var result = await $"{baseUrl}/{currencyCode}".InternalApi()
                .SetQueryParam(nameof(currencyCode), currencyCode?.Trim())
                .GetJsonAsync<CurrencyListing>();
            return result;
        }

        public async Task<CurrencyListing> Create(CurrencyListing model)
        {
            var createdListing = await $"{baseUrl}".InternalApi()
                .PostJsonAsync<CurrencyListing>(model);
            return createdListing;
        }

        public async Task<CurrencyListing> Update(CurrencyListing model)
        {
            var createdListing = await $"{baseUrl}/{model.CurrencyCode}".InternalApi()
                .PutJsonAsync<CurrencyListing>(model);
            return createdListing;
        }

        public async Task<QueryResult> ChangeStatus(string currencyCode, CurrencyListingStatus newStatus)
        {
            var result = await $"{baseUrl}/status/{currencyCode}".InternalApi()
                .SetQueryParam(nameof(newStatus), newStatus)
                .PutJsonAsync(null).GetQueryResult();
            return result;
        }

        public async Task<CurrencyListingSettings> GetSettings()
        {
            var result = await $"{baseUrl}/settings".InternalApi()
                .GetJsonAsync<CurrencyListingSettings>();
            return result;
        }

        #endregion Brokerage

        #region News CurrencyListingsCommentsController

        public async Task<List<NewsComment>> GetCurrencyListingComments(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/comments".InternalApi()
                .GetJsonAsync<List<NewsComment>>();
            return result;
        }

        public async Task<NewsComment> CreateCurrencyListingComment(NewsCommentDto commentDto)
        {
            var result = await $"{newsBaseUrl}/comments".InternalApi().PostJsonAsync<NewsComment>(commentDto);
            return result;
        }

        public async Task<int> GetCurrencyListingCommentCount(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/comments/count".InternalApi().GetJsonAsync<int>();
            return result;
        }

        public async Task<List<NewsComment>> GetCurrencyListingNewsComments(long id)
        {
            var result = await $"{newsBaseUrl}/news/{id}/comments".InternalApi().GetJsonAsync<List<NewsComment>>();
            return result;
        }

        public async Task<int> GetCurrencyListingNewsCommentsCount(long id)
        {
            var result = await $"{newsBaseUrl}/news/{id}/comments/count".InternalApi().GetJsonAsync<int>();
            return result;
        }

        #endregion News CurrencyListingsCommentsController

        #region News CurrencyListingsNewsController

        public async Task<List<NewsItem>> GetCurrencyListingNewsByCurrencyCode(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/news".InternalApi()
                .GetJsonAsync<List<NewsItem>>();
            return result;
        }

        public async Task<List<NewsItem>> GetCurrencyListingNewsById(long id)
        {
            var result = await $"{newsBaseUrl}/news/{id}".InternalApi()
                .GetJsonAsync<List<NewsItem>>();
            return result;
        }

        public async Task<int> GetCurrencyListingNewsCount(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/news/count".InternalApi().GetJsonAsync<int>();
            return result;
        }

        public async Task<IFlurlResponse> DeleteComment(long id)
        {
            return await $"/news/comments/{id}".InternalApi().DeleteAsync();
        }

        public async Task<List<CurrencyListingContentReaction>> UpdateLikeForComment(
            UpdateContentReactionDto contentReactionDto)
        {
            var result = await $"{newsBaseUrl}/news/likes".InternalApi().PutJsonAsync<List<NewsLike>>(updateLikeDto);
            return result;
        }

        #endregion News CurrencyListingsNewsController
    }
}
