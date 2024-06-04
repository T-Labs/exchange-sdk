using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Currencies.CurrencyListings.News.Dtos;

public class UpdateContentReactionDto
{
    [Required]
    public long ContentId { get; set; }

    [Required]
    public string UserId { get; set; }

    public override string ToString()
    {
        return
            $"ContentId: {ContentId}, UserId: {UserId}";
    }
}
