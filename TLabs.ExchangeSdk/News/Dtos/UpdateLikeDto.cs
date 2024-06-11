using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.News.Dtos;

public class UpdateLikeDto
{
    [Required]
    public long ContentId { get; set; }

    [Required]
    public string UserId { get; set; }

    public override string ToString() => $"ContentId: {ContentId}, UserId: {UserId}";

}
