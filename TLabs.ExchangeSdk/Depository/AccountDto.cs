using System;

namespace TLabs.ExchangeSdk.Depository
{
    public class AccountDto
    {
        public Guid AccountId { get; set; }

        /// <summary>AccountChart code</summary>
        public string ChartCode { get; set; }

        /// <summary>AccountChart name</summary>
        public string Name { get; set; }

        /// <summary>Account owner id</summary>
        public string UserId { get; set; }

        public string CurrencyCode { get; set; }

        /// <summary>Code of crypto-adapter, only used in deposits\withdrawals</summary>
        public string AdapterCode { get; set; }
    }
}
