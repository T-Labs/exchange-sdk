namespace TLabs.ExchangeSdk.Farming.Dtos;

public class UploadImageDto
{
    public string Extension { get; set; }

    public byte[] Data { get; set; }
    public long? TgUserId { get; set; }
    public long? TenantId { get; set; }
    public string OldImageId { get; set; }
}
