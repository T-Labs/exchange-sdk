namespace TLabs.ExchangeSdk.Depository.Futures
{
    public class FuturesLedgerOperationResult
    {
        public FuturesLedgerAccountSnapshot PrimaryBalance { get; set; }
        public FuturesLedgerAccountSnapshot CounterpartyBalance { get; set; }
    }
}
