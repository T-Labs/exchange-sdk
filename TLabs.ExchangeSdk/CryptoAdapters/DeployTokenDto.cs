using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLabs.ExchangeSdk.CryptoAdapters
{

    public class DeployTokenDto
    {
        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public string TokenName { get; set; }

        public long TotalTokensAmount { get; set; }
        public int TokenDecimalPlaces { get; set; }

        [Required]
        public string LogoImageUrl { get; set; }

        public override string ToString() => $"{nameof(DeployTokenDto)}({CurrencyCode} {TokenName}, {LogoImageUrl})";
    }
}
