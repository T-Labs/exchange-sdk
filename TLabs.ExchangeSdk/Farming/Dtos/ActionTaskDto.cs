namespace TLabs.ExchangeSdk.Farming.Dtos;

public class ActionTaskDto
{
    public long TenantId { get; set; }
    public string Description { get; set; }
    public string ActionUrl { get; set; }
    public decimal RewardAmount { get; set; }
    public PlatformType Platform { get; set; }
}
