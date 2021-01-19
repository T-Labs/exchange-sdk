using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Depository
{
    public class UserBalancesDto
    {
        public List<Balance> Balances { get; set; }
        public List<Balance> BalancesBlockedInOrder { get; set; }

        public UserBalancesDto()
        {
            Balances = new List<Balance>();
            BalancesBlockedInOrder = new List<Balance>();
        }

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
