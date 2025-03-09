using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.Affiliate
{
    public class ReferralTariff
    {
        [Key]
        public TariffType Type { get; set; }

        /// <summary>
        /// How much balance needed to activate this tariff
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Until which level affect payments
        /// </summary>
        public int AllowedLevel { get; set; }
    }

    public enum TariffType
    {
        Free, Business
    }
}
