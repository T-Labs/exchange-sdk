using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<CurrencyListing>> GetCurrencyListings(string userId = null, CurrencyListingStatus? status = null)
        {
            var result = await $"{baseUrl}".InternalApi()
                .SetQueryParam(nameof(userId), userId?.Trim().NullIfEmpty())
                .SetQueryParam(nameof(status), status == null ? "" : ((int)status).ToString())
                .GetJsonAsync<List<CurrencyListing>>();
            return result;
        }

        public async Task<CurrencyListing> GetCurrencyListing(string currencyCode)
        {
            var result = await $"{baseUrl}/{currencyCode}".InternalApi()
                .SetQueryParam(nameof(currencyCode), currencyCode?.Trim())
                .GetJsonAsync<CurrencyListing>();
            return result;
        }

        public async Task<CurrencyListing> CreateCurrencyListing(CurrencyListingCreateDto currencyListingCreateDto)
        {
            var createdListing = await $"{baseUrl}".InternalApi()
                .PostJsonAsync<CurrencyListing>(currencyListingCreateDto);
            return createdListing;
        }

        public async Task<CurrencyListing> UpdateCurrencyListing(CurrencyListingCreateDto currencyListingCreateDto)
        {
            var createdListing = await $"{baseUrl}/{currencyListingCreateDto.CurrencyCode}".InternalApi()
                .PutJsonAsync<CurrencyListing>(currencyListingCreateDto);
            return createdListing;
        }

        public async Task<QueryResult> ChangeStatusCurrencyListing(string currencyCode, CurrencyListingStatus newStatus)
        {
            var result = await $"{baseUrl}/status/{currencyCode}".InternalApi()
                .SetQueryParam(nameof(newStatus), newStatus)
                .PutJsonAsync(null).GetQueryResult();
            return result;
        }

        public async Task<QueryResult> StartDeployToTon(string currencyCode)
        {
            var result = await $"{baseUrl}/deploy/{currencyCode}".InternalApi()
                .PutJsonAsync(null).GetQueryResult();
            return result;
        }

        public async Task<CurrencyListingSettings> GetSettings()
        {
            var result = await $"{baseUrl}/settings".InternalApi()
                .GetJsonAsync<CurrencyListingSettings>();
            return result;
        }

        public async Task<List<string>> GetCurrencyListingCodes()
        {
            var result = await $"brokerage/currency-listings/codes".InternalApi()
                .GetJsonAsync<List<string>>();
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

        public async Task<int> GetCurrencyListingCommentCount(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/comments/count".InternalApi().GetJsonAsync<int>();
            return result;
        }

        public async Task<NewsComment> CreateCurrencyListingComment(NewsCommentDto commentDto)
        {
            var result = await $"{newsBaseUrl}/comments".InternalApi().PostJsonAsync<NewsComment>(commentDto);
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

        public async Task<List<NewsComment>> GetCurrencyListingNewsComments(long id)
        {
            var result = await $"{newsBaseUrl}/news/{id}/comments".InternalApi().GetJsonAsync<List<NewsComment>>();
            return result;
        }

        public async Task<int> GetCurrencyListingNewsCommentCount(long id)
        {
            var result = await $"{newsBaseUrl}/news/{id}/comments/count".InternalApi().GetJsonAsync<int>();
            return result;
        }

        public async Task<List<NewsLike>> UpdateCurrencyListingNewsLike(
            UpdateLikeDto updateLikeDto)
        {
            var result = await $"{newsBaseUrl}/news/likes".InternalApi().PutJsonAsync<List<NewsLike>>(updateLikeDto);
            return result;
        }

        #endregion News CurrencyListingsNewsController
    }
}
