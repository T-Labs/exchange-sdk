using System.ComponentModel.DataAnnotations;

namespace TLabs.ExchangeSdk.Depository
{
    public class TxCommandDto
    {
        [Required]
        public string TxTypeCode { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public string CurrencyCode { get; set; }

        public string UserId { get; set; }

        public ClientType ClientType { get; set; } = ClientType.User;

        [Required]
        public string ActionId { get; set; }

        public string TxId { get; set; }

        public override string ToString() => $"{nameof(TxCommandDto)}(type:{TxTypeCode}, " +
            $"{Amount} {CurrencyCode}, {ClientType} {UserId}, actionId:{ActionId}, txId:{TxId})";
    }
}
