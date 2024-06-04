using System;
using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Models;

public class CurrencyListingContentReaction
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string UserId { get; set; }

    public bool IsLiked { get; set; }
    public DateTimeOffset DateCreated { get; set; }

    public long? CurrencyListingNewsId { get; set; }
    public CurrencyListingNews CurrencyListingNews { get; set; }

    public long? CommentId { get; set; }
    public NewsComment Comment { get; set; }
}
