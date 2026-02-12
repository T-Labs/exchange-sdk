using System;

namespace TLabs.ExchangeSdk.Depository
{
    public class AccountBalance
    {
        public Guid AccountId { get; set; }

        public AccountChart AccountChart { get; set; }

        public string CurrencyCode { get; set; }

        public string UserId { get; set; }

        public decimal Balance { get; set; }

        public override string ToString() =>
            $"{nameof(AccountBalance)}({AccountChart?.ValueKey}, {Balance} {CurrencyCode}, user:{UserId} )";
    }
}
