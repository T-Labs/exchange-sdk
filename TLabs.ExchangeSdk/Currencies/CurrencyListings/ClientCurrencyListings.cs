using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;
using TLabs.ExchangeSdk.CashDeposits;
using TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Dtos;
using TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Models;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings
{
    public class ClientCurrencyListings
    {
        private const string baseUrl = "brokerage/currency-listings";
        private const string newsBaseUrl = "news/currency-listings";

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

        public async Task<List<NewsComment>> GetComments(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/comments".InternalApi()
                .GetJsonAsync<List<NewsComment>>();
            return result;
        }

        public async Task<int> GetCommentsCount(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/comments/count".InternalApi().GetJsonAsync<int>();
            return result;
        }

        public async Task<List<CurrencyListingNews>> GetCurrencyListingNews(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/news".InternalApi()
                .GetJsonAsync<List<CurrencyListingNews>>();
            return result;
        }

        public async Task<int> GetNewsCount(string currencyCode)
        {
            var result = await $"{newsBaseUrl}/{currencyCode}/news/count".InternalApi().GetJsonAsync<int>();
            return result;
        }

        public async Task<List<CurrencyListingContentReaction>> UpdateLikeForNews(
            UpdateContentReactionDto contentReactionDto)
        {
            var result = await $"{newsBaseUrl}/news/likes".InternalApi()
                .PutJsonAsync<List<CurrencyListingContentReaction>>(contentReactionDto);
            return result;
        }

        public async Task<List<NewsComment>> GetNewsComments(long id)
        {
            var result = await $"{newsBaseUrl}/news/{id}/comments".InternalApi().GetJsonAsync<List<NewsComment>>();
            return result;
        }

        public async Task<NewsComment> CreateComment(NewsCommentDto commentDto)
        {
            var result = await $"news/news-comments".InternalApi().PostJsonAsync<NewsComment>(commentDto);
            return result;
        }

        public async Task<IFlurlResponse> DeleteComment(long id)
        {
            return await $"/news/comments/{id}".InternalApi().DeleteAsync();
        }

        public async Task<List<CurrencyListingContentReaction>> UpdateLikeForComment(
            UpdateContentReactionDto contentReactionDto)
        {
            var result = await $"news/news-comments/likes".InternalApi()
                .PutJsonAsync<List<CurrencyListingContentReaction>>(contentReactionDto);
            return result;
        }
    }
}
