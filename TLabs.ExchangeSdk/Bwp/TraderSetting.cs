using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Bwp;

public class TraderSetting
{
    [Key]
    public string UserId { get; set; }

    public bool IsOnline { get; set; }
    public bool IsAdminSetActive { get; set; }
    public bool AllowedNegativeBalances { get; set; }
}
