namespace TLabs.ExchangeSdk.Farming.Dtos;

public class MiniGameResultDto
{
    public long StartTimeUnix { get; set; }
    public long EndTimeUnix { get; set; }
    public int Score { get; set; }

    public long TenantId { get; set; }
    public long TgUserId { get; set; }
}
