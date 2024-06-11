using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News
{
    public class NewsItem
    {
        [Key]
        public long Id { get; set; }

        /// <summary> Optional. NewsItem may be related to a certain CurrencyListing </summary>
        public string CurrencyListingCode { get; set; }

        public Language Language { get; set; }

        public List<NewsVersion> NewsVersions { get; set; } = new List<NewsVersion>();
        public List<NewsComment> NewsComments { get; set; }
        public List<NewsLike> NewsLikes { get; set; }
        public NewsItem()
        {
        }
        public NewsItem(string currencyListingCode)
        {
            CurrencyListingCode = currencyListingCode;
        }            
    }
}
