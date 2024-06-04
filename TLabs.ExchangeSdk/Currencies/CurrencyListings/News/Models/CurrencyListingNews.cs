using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Models;

public class CurrencyListingNews
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long CurrencyListingInternalId { get; set; }

    public CurrencyListingInternalNews CurrencyListingInternalNews { get; set; }

    public string Title { get; set; }
    public string Preview { get; set; }
    public string Body { get; set; }
    public string ImageId { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public Language Language { get; set; }
    public List<NewsComment> NewsComments { get; set; }
    public List<CurrencyListingContentReaction> NewsReactions { get; set; } = new();
}

public enum Language
{
    en = 0,
    ru = 1,
    tr = 20
};
