using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Depository
{
    public class UserBalancesDto
    {
        public List<Balance> Balances { get; set; } = new();
        public List<Balance> BalancesBlockedInOrder { get; set; } = new();
        public List<Balance> BalancesInCurrencyOfferingsVesting { get; set; } = new();
        public List<Balance> BalancesUserBonuses { get; set; } = new();

        public class Balance
        {
            /// <summary>
            /// Available amount on account
            /// </summary>
            public decimal Amount { get; set; }

            public string CurrencyCode { get; set; }

            public string CurrencyName { get; set; }

            /// <summary>
            /// How many decimal digits should balances have after rounding
            /// </summary>
            public int Digits { get; set; }

            public bool CurrencyIsFiat { get; set; }

            public bool IsInternalCurrency { get; set; }
        }
    }
}
