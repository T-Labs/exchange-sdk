using System;

namespace TLabs.ExchangeSdk.Depository
{
    public class CryptoDepositListItemDto
    {
        public Guid TransactionId { get; set; }
        public DateTimeOffset Datetime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }
        public string UserId { get; set; }
        public string TxId { get; set; }
        public string ActionId { get; set; }
    }
}
