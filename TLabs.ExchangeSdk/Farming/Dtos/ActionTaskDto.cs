namespace TLabs.ExchangeSdk.Farming.Dtos;

public class ActionTaskDto
{
    public int TgUserId { get; set; }
    public string Description { get; set; }
    public long RewardId { get; set; }
    public string ActionUrl { get; set; }
    public decimal RewardAmount { get; set; }
    public PlatformType Platform { get; set; }
}
