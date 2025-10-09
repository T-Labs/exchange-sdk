namespace TLabs.ExchangeSdk.Currencies
{
    public class CurrencyPair
    {
        public string Code => $"{CurrencyToId}_{CurrencyFromId}";

        /// <summary>
        /// Is currency pair halted
        /// </summary>
        public bool IsHalted { get; set; }

        /// <summary>
        /// Is currency pair halted
        /// </summary>
        public bool IsShowedForUsers { get; set; }

        /// <summary>
        /// Quote Currency Code
        /// </summary>
        public string CurrencyFromId { get; set; }

        public virtual Currency CurrencyFrom { get; set; }

        /// <summary>
        /// Base Currency Code
        /// </summary>
        public string CurrencyToId { get; set; }

        public virtual Currency CurrencyTo { get; set; }

        public string OverridedName { get; set; }

        /// <summary>
        /// How many decimal digits should price have after rounding
        /// </summary>
        public int DigitsPrice { get; set; }
        public int UiDigitsPrice { get; set; } = 6;

        /// <summary>
        /// How many decimal digits should Order/Deal amount have after rounding
        /// </summary>
        public int DigitsAmount { get; set; }
        public int UiDigitsAmount { get; set; } = 6;

        public bool SendToCoinmarketcap { get; set; } = true;

        /// <summary>Listed on the exchange</summary>
        public bool AvailableOnExchange { get; set; }

        public bool AvailableOnP2P { get; set; }

        public int DigitsPriceP2P { get; set; }
        public int DigitsAmountP2P { get; set; }

        /// <summary>
        /// Fair launch is a special type of token listing where the token is sold through bonding curve
        /// and then deployed to DEX.
        /// </summary>
        public bool UseFairLaunchTrading { get; set; }

        public CurrencyPair()
        {
        }

        public CurrencyPair(string currencyToId, string currencyFromId)
        {
            CurrencyToId = currencyToId;
            CurrencyFromId = currencyFromId;
        }

        public CurrencyPair(string code) : this(GetCurrencyToId(code), GetCurrencyFromId(code))
        {
        }

        public static string GetCurrencyToId(string code) => code.Split(new char[] { '_' })[0];

        public static string GetCurrencyFromId(string code) => code.Split(new char[] { '_' })[1];

        public string GetDisplayName => string.IsNullOrEmpty(OverridedName) ? (CurrencyToId + "/" + CurrencyFromId) : OverridedName;

        public override string ToString() => $"{nameof(CurrencyPair)}({Code} {OverridedName}, {CurrencyToId}-{CurrencyFromId}, " +
            $"digits:{DigitsPrice} {DigitsAmount}, {(IsHalted ? "halted" : "")} {(IsShowedForUsers ? "showed" : "")})";
    }
}
