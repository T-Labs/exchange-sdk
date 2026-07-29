namespace TLabs.ExchangeSdk.Depository.Futures
{
    public class FuturesLedgerOperationRequest
    {
        public string ActionId { get; set; }
        public FuturesLedgerOperationType OperationType { get; set; }
        public long FuturesAccountId { get; set; }
        public string UserId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public long? CounterpartyFuturesAccountId { get; set; }
        public string CounterpartyUserId { get; set; }
    }
}
