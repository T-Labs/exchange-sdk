using System;

namespace TLabs.ExchangeSdk.Depository
{
    public class AccountDto
    {
        /// <summary>
        /// Account number
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// AccountChart code
        /// </summary>
        public string ChartCode { get; set; }

        /// <summary>
        /// AccountChart name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Account owner id
        /// </summary>
        public string UserId { get; set; }
    }
}
