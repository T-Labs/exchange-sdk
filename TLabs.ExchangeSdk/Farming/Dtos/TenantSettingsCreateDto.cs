using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Farming.Dtos;

public class TenantSettingsCreateDto
{
    public bool IsShowMiniGame { get; set; }
    public Dictionary<string, string> ColorSettings { get; set; }
}
