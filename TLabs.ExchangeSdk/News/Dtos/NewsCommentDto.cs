using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News.Dtos;

public class NewsCommentDto
{
    public long? NewsItemId { get; set; }
    public string CurrencyListingCode { get; set; }
    public string UserId { get; set; }

    [Required]
    public string Text { get; set; }
}
