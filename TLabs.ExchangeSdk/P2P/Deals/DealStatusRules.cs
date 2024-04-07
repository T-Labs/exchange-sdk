using System.Collections.Generic;

namespace TLabs.ExchangeSdk.P2P.Deals;

public class DealStatusRules
{
    public static readonly HashSet<DealStatus> CompletedDealStatuses = new()
    {
        DealStatus.CryptoReleased, DealStatus.Canceled, DealStatus.CanceledCryptoUnfrozen
    };
}
