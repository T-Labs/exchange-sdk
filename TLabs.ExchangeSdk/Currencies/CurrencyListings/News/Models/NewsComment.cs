using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Models;

public class NewsComment
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public string CommentText { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public long? CurrencyListingId { get; set; }
    public CurrencyListingInternalNews CurrencyListingInternalNews { get; set; }

    public long? CurrencyListingNewsId { get; set; }
    public CurrencyListingNews CurrencyListingNews { get; set; }

    public List<CurrencyListingContentReaction> CommentReactions { get; set; } = new();


    [NotMapped]
    public string UserNickname { get; set; }
}
