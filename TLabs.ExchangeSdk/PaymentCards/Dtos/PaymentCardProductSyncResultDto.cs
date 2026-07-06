using System;

namespace TLabs.ExchangeSdk.PaymentCards.Dtos;

public class PaymentCardProductSyncResultDto
{
    public int Created { get; set; }
    public int Updated { get; set; }
    public int TotalRemote { get; set; }
    public DateTimeOffset DateSynced { get; set; }

    public override string ToString() =>
        $"{nameof(PaymentCardProductSyncResultDto)}(created:{Created}, updated:{Updated}, remote:{TotalRemote})";
}
