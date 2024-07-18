namespace TLabs.ExchangeSdk.Farming.Dtos;

public class UploadImageDto
{
    public string Extension { get; set; }
    public byte[] Data { get; set; }

    /// <summary> used only for admin requests. </summary>
    public string? OldImageId { get; set; }
}
