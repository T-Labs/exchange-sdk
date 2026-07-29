using System;

namespace TLabs.ExchangeSdk.Depository.Futures
{
    public class FuturesLedgerAccountSnapshot
    {
        public long FuturesAccountId { get; set; }
        public string UserId { get; set; }
        public string CurrencyCode { get; set; }
        public Guid BalanceAccountId { get; set; }
        public Guid BlockedCopyTradingAccountId { get; set; }
        public decimal Balance { get; set; }
        public decimal BlockedCopyTradingBalance { get; set; }
    }
}
