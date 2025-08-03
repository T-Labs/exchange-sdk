using System.Collections.Generic;

namespace TLabs.ExchangeSdk.CryptoAdapters.Tron;

public class ExternalFreezesDto
{
    public string GlobalAddress { get; set; }
    public List<TronTransaction> FreezeTransactions { get; set; }
}
