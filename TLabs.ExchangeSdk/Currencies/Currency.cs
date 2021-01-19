namespace TLabs.ExchangeSdk.Currencies
{
    public class Currency
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Unified Crypto Asset Id from CoinMarketCap
        /// </summary>
        public int? UnifiedCryptoAssetId { get; set; }

        /// <summary>
        /// Is currency halted
        /// </summary>
        public bool IsHalted { get; set; }

        /// <summary>
        /// Is currency fiat
        /// </summary>
        public bool IsFiat { get; set; } = false;

        /// <summary>
        /// Is currency showed for users
        /// </summary>
        public bool IsShowedForUsers { get; set; }

        /// <summary>
        /// Is this currency used by users to pay commissions (can be only one such currency)
        /// </summary>
        public bool IsForCommissionConversion { get; set; }

        /// <summary>
        /// Token of which currency (null if not a token)
        /// </summary>
        public string TokenOf { get; set; } = null;

        /// <summary>
        /// Is erc20 token contract address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// How many decimal digits should balances have after rounding
        /// </summary>
        public int Digits { get; set; }

        /// <summary>
        /// Get gateway serviceId for crypto-adapter of this currency
        /// </summary>
        public string CryptoAdapterId => IsFiat ? "advcash" : (TokenOf ?? Code).ToLower();

        private Currency(string code, string value, bool isFiat = false)
        {
            Code = code;
            Value = value;
            IsShowedForUsers = true;
            IsFiat = isFiat;
        }

        public Currency()
        {
        }

        public override string ToString() => $"{nameof(Currency)}({Code} {Value}, TokenOf:{TokenOf}, digits:{Digits}, " +
            $"AdapterId:{CryptoAdapterId}, {(IsHalted ? "halted" : "")} {(IsShowedForUsers ? "showed" : "")})";
    }
}
