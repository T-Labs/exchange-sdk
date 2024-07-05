using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Farming.Dtos;

public class RewardCreateDto
{
    [Required]
    public long TenantId { get; set; }

    public decimal BaseReward { get; set; }
    public decimal IncrementPerDay { get; set; }
    public int MaxDays { get; set; }
    public RewardType RewardType { get; set; }
    public decimal AmountReward { get; set; }
}
