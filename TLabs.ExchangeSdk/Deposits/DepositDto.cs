using TLabs.ExchangeSdk.Commissions;

namespace TLabs.ExchangeSdk.Deposits
{
    public enum DepositType
    {
        FromCryptoAdapter = 1,
        Cash = 2,
        FromAdmin = 3,
        UserToUserTransfer = 4,
        FromAirdrop = 50,
        FromStakingLocked = 60,
    }

    public class DepositDto
    {
        public DepositType Type { get; set; } = DepositType.FromCryptoAdapter;
        public string UserId { get; set; }
        public ClientType ClientType { get; set; } = ClientType.User;
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string AdapterCode { get; set; }
        public string TxId { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }

        /// <summary>Only for Staking, other types always notify</summary>
        public bool NotificationNeeded { get; set; }

        /// <summary>Calculated in Deposits module</summary>
        public CommissionValue Commission { get; set; }

        public override string ToString() => $"{nameof(DepositDto)}({Type}, {Amount} {CurrencyCode} {AdapterCode}, {ClientType} {UserId}, " +
            $"TxId:{TxId}, {Commission?.ToString() ?? ""} )";
    }
}
