using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Models;

public class CurrencyListingInternalNews
{
    [Key]
    public long Id { get; set; }

    public string CurrencyCode { get; set; }

    public List<CurrencyListingNews> CurrencyListingNews { get; set; } = new List<CurrencyListingNews>();
    public List<NewsComment> CurrencyListingComments { get; set; } = new List<NewsComment>();

    public CurrencyListingInternalNews(string currencyCode)
    {
        CurrencyCode = currencyCode;
    }
}
