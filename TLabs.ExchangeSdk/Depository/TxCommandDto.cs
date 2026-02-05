using System;
using System.ComponentModel.DataAnnotations;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.Depository
{
    public class TxCommandDto
    {
        public TxCommandDto()
        {
        }

        public TxCommandDto(string txTypeCode, string currencyCode, string fromUserId, string toUserId, decimal amount,
            string actionId, string txId = null)
        {
            TxTypeCode = txTypeCode;
            CurrencyCode = currencyCode;
            FromUserId = fromUserId;
            ToUserId = toUserId;
            Amount = amount;
            ActionId = actionId;
            TxId = txId;
        }

        [Required]
        public string TxTypeCode { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public string AdapterCode { get; set; }

        [Obsolete("Use FromUserId/ToUserId")]
        public string UserId { get; set; }
        [Obsolete("Use FromClientType/ToClientType")]
        public ClientType ClientType { get; set; }

        public string FromUserId { get; set; }
        public ClientType FromClientType { get; set; }

        public string ToUserId { get; set; }
        public ClientType ToClientType { get; set; }

        [Required]
        public string ActionId { get; set; }

        public string TxId { get; set; }

        public override string ToString() => $"{nameof(TxCommandDto)}(type:{TxTypeCode}, " +
            $"{Amount} {CurrencyCode}, users: {FromUserId} -> {ToUserId}, actionId:{ActionId}, txId:{TxId})";

        public void Clean()
        {
            TxTypeCode = TxTypeCode?.Trim().NullIfEmpty();
            CurrencyCode = CurrencyCode?.Trim().NullIfEmpty();
            UserId = UserId?.Trim().NullIfEmpty();
            FromUserId = FromUserId?.Trim().NullIfEmpty();
            ToUserId = ToUserId?.Trim().NullIfEmpty();
            ActionId = ActionId?.Trim().NullIfEmpty();
            TxId = TxId?.Trim().NullIfEmpty();
        }
    }
}
