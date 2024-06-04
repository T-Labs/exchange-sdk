using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Dtos;

public class NewsCommentDto
{
    public long? NewsId { get; set; }
    public string CurrencyCode { get; set; }
    public string UserId { get; set; }

    [Required]
    public string CommentText { get; set; }
}
