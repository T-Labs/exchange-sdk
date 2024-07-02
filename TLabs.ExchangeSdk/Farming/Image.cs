using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming;

public class Image
{
    [Key]
    public string Id { get; set; }

    public long? TenantId { get; set; }
    public long? TgUserId { get; set; }
    public byte[] Data { get; set; }

    public static string GetUrl(string imageId) =>
        string.IsNullOrWhiteSpace(imageId) ? "" : $"/farming/image/{imageId}";
}
